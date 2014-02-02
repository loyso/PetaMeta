using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

using MetadataDesigner;

namespace gui
{
	partial class Layout
	{
		public tree.TreeObject ParentFile;

		protected override void NewObject( core.DataObject newObject, core.DataObject deletedObject ) 
		{
			core.IOperations objectOperations = (core.IOperations)newObject;
			if ( deletedObject != null )
			{
				objectOperations.CopyObjectDataFrom( deletedObject );
			}
			else
			{
				objectOperations.NewGuids();
				objectOperations.NewNames();
			}
		} 

		protected override void DeleteObject( core.DataObject deletedObject ) 
		{
			CurrentProject.ObjectDeleted( deletedObject );
		}

		protected override bool BrowseClicked( System.Type referenceType, string title, Predicate< core.DataObject > predicate, core.DataObject currentReference, out core.DataObject reference )
		{
			core.IFolderStorageObject parentFolderStorage = null;
			if ( ParentFile != null )
				parentFolderStorage = ParentFile.ParentFolderStorage();

			tree.BrowseDialog dialog = new tree.BrowseDialog( parentFolderStorage, predicate ) { Title = "Browse for " + title, Width = 512, Owner = MainWindow };
			dialog.RootTree.ShowPropertiesOnSelected = false;
		
			reference = null;

			if ( dialog.ModalDialog( CurrentProject, CurrentProject.ProjectName, referenceType, currentReference ) )
			{
				reference = dialog.Reference;
				return true;
			}

			return false;
		}

		protected override void NameChanged()
		{
			tree.TreeObject treeObject = MainWindow.ProjectTree.FindDataToTree( This );
			if ( treeObject == null )
			{
				foreach ( KeyValuePair< core.DataObject, TreeWindow > kvp in  metadata.MetadataFileTree.ObjectToTree )
				{
					treeObject = kvp.Value.RootTree.FindDataToTree( This );
					if ( treeObject != null )
						break;
				}
			}

			if ( treeObject != null )
				treeObject.ObjectDataToControls();
		}

		protected MainWindow MainWindow
		{
			get 
			{
				MainWindow mainWindow = (MainWindow)System.Windows.Application.Current.MainWindow;
				return mainWindow;
			}
		}

		protected metadata.MetadataProject CurrentProject
		{
			get 
			{
				return MainWindow.Project;
			}
		}
	}
}

namespace tree
{
	partial class Tree
	{
		public bool ShowPropertiesOnSelected = true;
	}

	partial class TreeObject
	{
		static Dictionary< core.DataObject, ObjectWindow > ObjectToLayout = new Dictionary< core.DataObject, ObjectWindow >();

		protected override void NewObject( core.DataObject newObject ) 
		{
			core.IOperations objectOperations = (core.IOperations)newObject;
			objectOperations.NewGuids();
			objectOperations.NewNames();
		} 

		protected override void DeleteObject( core.DataObject deletedObject ) 
		{
			CurrentProject.ObjectDeleted( deletedObject );
		}

		protected override void Selected() 
		{
			if ( RootTree.ShowPropertiesOnSelected )
			{
				ObjectWindow objectWindow = null;
				if ( !ObjectToLayout.TryGetValue( This, out objectWindow ) )
				{
					FrameworkElement frameworkElement = CreateLayout();			
					MainWindow.Properties.Content = frameworkElement;
				}
				else
				{
					objectWindow.SetAsActive();
					TreeViewItem.Focus();
				}
			}
		}

		protected override void Unselected() 
		{
			if ( RootTree.ShowPropertiesOnSelected )
			{
				MainWindow.Properties.Content = null;
			}
		}

		protected override void MouseDoubleClicked() 
		{
			ObjectWindow objectWindow = null;
			if ( !ObjectToLayout.TryGetValue( This, out objectWindow ) )
			{
				FrameworkElement frameworkElement = CreateLayout();

				objectWindow = new ObjectWindow{ IsFloatingAllowed = true };
				objectWindow.Title = This.GetType().Name;
				objectWindow.InfoTip = "Info tip";
				objectWindow.ContentTypeDescription = "Sample document";
				objectWindow.Closed += ( sender, e ) => { ObjectToLayout.Remove( (sender as ObjectWindow).This ); };
				objectWindow.Content = frameworkElement;
				objectWindow.This = This;
				ObjectToLayout.Add( This, objectWindow );

				MainWindow.DocumentsHost.Items.Add(objectWindow);

				if ( TreeViewItem.IsSelected )
					MainWindow.Properties.Content = null;
			}
			objectWindow.Focus();
		}

		FrameworkElement CreateLayout()
		{
			gui.Layout layout = gui.Layouts.CreateLayoutFor< gui.Layout > ( This );

			StackPanel stackPanel = new StackPanel();
			layout.CreateControls( This, stackPanel.Children );
			layout.ObjectDataToControls();

			TreeWindow treeWindow = RootTree.TreeView.Parent as TreeWindow;
			if ( treeWindow != null )
				layout.ParentFile = treeWindow.ParentFile;

			ScrollViewer scrollViewer = new ScrollViewer();
			scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
			scrollViewer.Content = stackPanel;

			return scrollViewer;
		}

		protected MainWindow MainWindow
		{
			get 
			{
				MainWindow mainWindow = (MainWindow)System.Windows.Application.Current.MainWindow;
				return mainWindow;
			}
		}

		protected metadata.MetadataProject CurrentProject
		{
			get 
			{
				return MainWindow.Project;
			}
		}
	}
}

namespace metadata
{
	public partial class MetadataFileTree
	{
		public static Dictionary< core.DataObject, TreeWindow > ObjectToTree = new Dictionary< core.DataObject, TreeWindow >();

		protected override void MouseDoubleClicked() 
		{
			TreeWindow treeWindow = null;
			if ( !ObjectToTree.TryGetValue( This, out treeWindow ) )
			{
				if ( This.Content == null )
				{
					This.Content = new metadata.MetadataFileContent();
					This.Content.NewGuids();
					This.Content.NewNames();
				}

				treeWindow = new TreeWindow{ IsFloatingAllowed = true };
				treeWindow.RootTree = new tree.Tree( false, null, null ); 
				treeWindow.RootTree.CreateTreeView( This.Content, "Content" );
				treeWindow.Title = This.Name;
				treeWindow.Content = treeWindow.RootTree.TreeView;
				treeWindow.Closed += ( sender, e ) => { ObjectToTree.Remove( (sender as TreeWindow).This ); };
				treeWindow.This = This;
				treeWindow.ParentFile = this;
				ObjectToTree.Add( This, treeWindow );

				MainWindow.DocumentsHost.Items.Add(treeWindow);
			}

			treeWindow.Focus();
		}

		static BitmapImage BitmapImage = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/VSProject_genericfile.png"));
		protected override BitmapImage TreeImage() { return BitmapImage; }
	}

	public partial class MetadataFolderTree
	{
		static BitmapImage BitmapImage = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/VSFolder_closed.png"));
		protected override BitmapImage TreeImage() { return BitmapImage; }
	}

	public partial class MetadataProjectTree
	{
		static BitmapImage BitmapImage = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/VSProject_genericproject_small.png"));
		protected override BitmapImage TreeImage() { return BitmapImage; }
	}
}

namespace metadata
{
	public partial class TypeTree
	{
		static BitmapImage BitmapImage = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/VSObject_Class.png"));
		protected override BitmapImage TreeImage() { return BitmapImage; }
	}

	public partial class MemberTree
	{
		static BitmapImage BitmapImage = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/VSObject_Field.png"));
		protected override BitmapImage TreeImage() { return BitmapImage; }
	}

	public partial class FunctionTree
	{
		static BitmapImage BitmapImage = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/VSObject_Method.png"));
		protected override BitmapImage TreeImage() { return BitmapImage; }
	}

	public partial class EnumerationTree
	{
		static BitmapImage BitmapImage = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/VSObject_Enum.png"));
		protected override BitmapImage TreeImage() { return BitmapImage; }
	}

	public partial class EnumeratorTree
	{
		static BitmapImage BitmapImage = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/VSObject_EnumItem.png"));
		protected override BitmapImage TreeImage() { return BitmapImage; }
	}
}
