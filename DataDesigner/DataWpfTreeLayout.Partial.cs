using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

using System.Windows.Resources;

using DataDesigner;

namespace gui
{
	public partial class Layout
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
			// clean up references
			CurrentProject.ObjectDeleted( deletedObject );
		}

		protected override bool BrowseClicked( System.Type referenceType, string title, Predicate<core.DataObject> predicate, core.DataObject currentReference, out core.DataObject reference )
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
				foreach ( KeyValuePair< core.DataObject, TreeWindow > kvp in tree.TreeObject.ObjectToTree )
				{
					treeObject = kvp.Value.RootTree.FindDataToTree( This );
					if ( treeObject != null )
						break;
				}
			}

			if ( treeObject != null )
				treeObject.ObjectDataToControls();
		}

		protected override void MemberChanged_Value( reflection.MetadataClass ThisMetadataClass, core.ReferenceObject This, reflection.Value member, core.DataObject dataValue )
		{
			data.Remoting.SetObject_Value( ThisMetadataClass, This, member, dataValue );
		}
		protected override void MemberChanged_Reference( reflection.MetadataClass ThisMetadataClass, core.ReferenceObject This, reflection.Reference member, core.ReferenceObject referenceValue )
		{
			data.Remoting.SetObject_Reference( ThisMetadataClass, This, member, referenceValue );
		}
		protected override void MemberChanged_ParentReference( reflection.MetadataClass ThisMetadataClass, core.ReferenceObject This, reflection.ParentReference member, core.ReferenceObject referenceValue )
		{
			data.Remoting.SetObject_ParentReference( ThisMetadataClass, This, member, referenceValue );
		}
		protected override void MemberChanged_FileStorage( reflection.MetadataClass ThisMetadataClass, core.ReferenceObject This, reflection.FileStorage member, core.ReferenceObject referenceValue )
		{
			data.Remoting.SetObject_FileStorage( ThisMetadataClass, This, member, referenceValue );
		}

		protected MainWindow MainWindow
		{
			get 
			{
				MainWindow mainWindow = (MainWindow)System.Windows.Application.Current.MainWindow;
				return mainWindow;
			}
		}

		protected game.Game CurrentProject
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
	public partial class Tree
	{
		public bool ShowPropertiesOnSelected = true;
	}

	public partial class TreeObject
	{
		public static Dictionary< core.DataObject, ObjectWindow >	ObjectToLayout = new Dictionary< core.DataObject, ObjectWindow >();
		public static Dictionary< core.DataObject, TreeWindow >		ObjectToTree = new Dictionary< core.DataObject, TreeWindow >();

		protected override void NewObject( core.DataObject newObject ) 
		{
			core.IOperations objectOperations = (core.IOperations)newObject;
			objectOperations.NewGuids();
			objectOperations.NewNames();

			core.ReferenceObject referenceObject = newObject as core.ReferenceObject;
			if ( referenceObject != null )
			{
				reflection.MetadataClass metadataClass = data.Reflection.GetClass( referenceObject );
				data.Remoting.NewObject( metadataClass, referenceObject );
			}
		} 

		protected override void DeleteObject( core.DataObject deletedObject ) 
		{
			// clean up references
			CurrentProject.ObjectDeleted( deletedObject );

			core.ReferenceObject referenceObject = deletedObject as core.ReferenceObject;
			if ( referenceObject != null )
			{
				reflection.MetadataClass metadataClass = data.Reflection.GetClass( referenceObject );
				data.Remoting.DeleteObject( metadataClass, referenceObject );
			}
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
			gui.Layout layout = gui.Layouts.CreateLayoutFor< gui.Layout >( This );

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

		protected game.Game CurrentProject
		{
			get 
			{
				return MainWindow.Project;
			}
		}
	}
}

namespace game
{
	public partial class GameTree
	{
		static BitmapImage BitmapImage = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/VSProject_genericproject_small.png"));
		protected override BitmapImage TreeImage() { return BitmapImage; }
	}
}

namespace gui
{
	public partial class GuiFileTree
	{
		protected override void MouseDoubleClicked()
		{
			TreeWindow treeWindow = null;
			if ( !tree.TreeObject.ObjectToTree.TryGetValue( This, out treeWindow ) )
			{
				if ( This.mainWindow == null )
				{
					This.mainWindow = new gui.Window();
					This.mainWindow.NewGuids();
					This.mainWindow.NewNames();
				}

				treeWindow = new TreeWindow{ IsFloatingAllowed = true };
				treeWindow.RootTree = new tree.Tree( false, null, null );
				treeWindow.RootTree.CreateTreeView( This.mainWindow, "Main Window" );
				treeWindow.Title = This.name;
				treeWindow.Content = treeWindow.RootTree.TreeView;
				treeWindow.Closed += ( sender, e ) => { tree.TreeObject.ObjectToTree.Remove( (sender as TreeWindow).This ); };
				treeWindow.This = This;
				treeWindow.ParentFile = this;
				tree.TreeObject.ObjectToTree.Add( This, treeWindow );

				MainWindow.DocumentsHost.Items.Add(treeWindow);
			}
			treeWindow.Focus();
		}

		static BitmapImage BitmapImage = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/VSProject_genericfile.png"));
		protected override BitmapImage TreeImage() { return BitmapImage; }
	}

	public partial class GuiCommonTree
	{
		static BitmapImage BitmapImage = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/VSFolder_closed.png"));
		protected override BitmapImage TreeImage() { return BitmapImage; }
	}
}

namespace level
{
	public partial class LevelFileTree
	{
		protected override void MouseDoubleClicked()
		{
			TreeWindow treeWindow = null;
			if ( !tree.TreeObject.ObjectToTree.TryGetValue( This, out treeWindow ) )
			{
				if ( This.scene == null )
				{
					This.scene = new scene.Scene();
					This.scene.NewGuids();
					This.scene.NewNames();
				}

				treeWindow = new TreeWindow{ IsFloatingAllowed = true };
				treeWindow.RootTree = new tree.Tree( false, null, null );
				treeWindow.RootTree.CreateTreeView( This.scene, "Scene" );
				treeWindow.Title = This.name;
				treeWindow.Content = treeWindow.RootTree.TreeView;
				treeWindow.Closed += ( sender, e ) => { tree.TreeObject.ObjectToTree.Remove( (sender as TreeWindow).This ); };
				treeWindow.This = This;
				treeWindow.ParentFile = this;
				tree.TreeObject.ObjectToTree.Add( This, treeWindow );

				MainWindow.DocumentsHost.Items.Add(treeWindow);
			}
			treeWindow.Focus();
		}

		static BitmapImage BitmapImage = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/VSProject_genericfile.png"));
		protected override BitmapImage TreeImage() { return BitmapImage; }
	}

	public partial class LevelFolderTree
	{
		static BitmapImage BitmapImage = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/VSFolder_closed.png"));
		protected override BitmapImage TreeImage() { return BitmapImage; }
	}
}

namespace scene
{
	public partial class SceneObjectTree
	{
		static BitmapImage BitmapImage = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/VSProject_bmp.png"));
		protected override BitmapImage TreeImage() { return BitmapImage; }
	}
}
