using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace tree
{
	public partial class Tree
	{
	    public TreeView         TreeView;
	    public TreeObject       TreeObject;
	    public readonly bool    ShowFileStorage;
	    public readonly Predicate< core.DataObject >	Predicate;
	    public readonly	core.IFolderStorageObject		FolderStorage;
	    private Dictionary< core.DataObject, TreeObject > DataToTree = new Dictionary< core.DataObject, TreeObject >();     
	    
	    public Tree( bool showFileStorage, core.IFolderStorageObject folderStorage, Predicate< core.DataObject > predicate )
	    {
	        ShowFileStorage = showFileStorage;
	        FolderStorage = folderStorage;
	        Predicate = predicate;
	    }
	    
	    public void CreateTreeView( core.DataObject dataObject, string label )
	    {
			TreeObject = Trees.CreateTreeObjectFor <TreeObject>( dataObject );
			TreeObject.CreateTree_Label( dataObject, label, this );
			TreeObject.ObjectDataToControls();
			TreeObject.TreeViewItem.IsExpanded = true;
			
			TreeView = new TreeView { AllowDrop = true };
			TreeView.AddHandler( TreeView.MouseDownEvent, new RoutedEventHandler(this.MouseDown), true);
			TreeView.MouseMove += MouseMove;
			TreeView.DragOver += DragOver;
			TreeView.Drop += Drop;
			TreeView.Items.Add( TreeObject.TreeViewItem );    
	    }
	    
	    public void RegisterDataToTree( core.DataObject dataObject, TreeObject treeObject )
	    {
	        DataToTree.Add( dataObject, treeObject );
	    }
	    public void UnregisterDataToTree( core.DataObject dataObject )
	    {
	        DataToTree.Remove( dataObject );
	    }
	    public TreeObject FindDataToTree( core.DataObject dataObject )
	    {
	        TreeObject treeObject = null;
	        if ( !DataToTree.TryGetValue( dataObject, out treeObject ) )
    			return null;
	        return treeObject;
	    }
	    
	    // DRAG AND DROP
	    
		private Point MouseDownPoint = new Point(0, 0); 
		private TreeViewItem DragTreeViewItem = null;		

		private void MouseDown(object source, RoutedEventArgs args)
		{
			System.Windows.Input.MouseEventArgs e = (System.Windows.Input.MouseEventArgs)args;			
			TreeObject treeObject = ((FrameworkElement)e.Source).DataContext as TreeObject;
			if ( treeObject != null )
			{			
				MouseDownPoint = e.GetPosition(null); 
				DragTreeViewItem = treeObject.TreeViewItem;
			}
			else
				DragTreeViewItem = null;
		}
		void MouseMove(object sender, System.Windows.Input.MouseEventArgs e) 
		{ 
			if( DragTreeViewItem != null ) 
			{ 
				if ( e.LeftButton == System.Windows.Input.MouseButtonState.Pressed )
				{
					Point position = e.GetPosition(null); 
					if (Math.Abs(position.X - MouseDownPoint.X) > SystemParameters.MinimumHorizontalDragDistance 
						|| Math.Abs(position.Y - MouseDownPoint.Y) > SystemParameters.MinimumVerticalDragDistance) 
					{ 
						DragDrop.DoDragDrop( TreeView, DragTreeViewItem, DragDropEffects.Move );
						DragTreeViewItem = null;
					}
				}
				else
					DragTreeViewItem = null;
			}
		}
		void DragOver( Object sender, DragEventArgs e )
		{
			if( e.Data.GetDataPresent( typeof(TreeViewItem) ) ) 
			{
				TreeViewItem treeViewItem = (TreeViewItem)e.Data.GetData( typeof(TreeViewItem) );
				tree.TreeObject treeObject = treeViewItem.DataContext as tree.TreeObject;
				e.Effects = DragDropEffects.Move;
			}
			else
			{
				e.Effects = DragDropEffects.None;
			}		
		}
		void Drop( Object sender, DragEventArgs e )
		{
			if( e.Data.GetDataPresent( typeof(TreeViewItem) ) ) 
			{
				TreeViewItem sourceItem = (TreeViewItem)e.Data.GetData( typeof(TreeViewItem) );

				TreeObject source = sourceItem.DataContext as TreeObject;
				TreeObject target = (e.OriginalSource as FrameworkElement).DataContext as TreeObject;
				if ( target != null && source.TreeViewItem.Parent is TreeViewItem )
				{
					TreeViewItem sourceItemParent = (TreeViewItem)source.TreeViewItem.Parent;								
					ITreeCollection sourceCollection = sourceItemParent.DataContext as ITreeCollection;							

					TreeViewItem targetItemParent = null;
					ITreeCollection targetCollection = null;
					
					if ( target is ITreeCollection )
					{
						targetCollection = target as ITreeCollection;
						target = null;
					}
					else
					{
						targetItemParent = target.TreeViewItem.Parent as TreeViewItem;
						if ( targetItemParent != null )
							targetCollection = targetItemParent.DataContext as ITreeCollection;				
					}
					
					if ( targetCollection != null && targetCollection.CanContain( source ) )
					{
						sourceCollection.Remove( source );				
						targetCollection.AddAfter( target, source );
						
						sourceItem.IsSelected = true;					
					}
				}
			}
			
			e.Handled = true;			
		}		
	}

	public abstract class ITreeObject
	{
		protected virtual void NewObject( core.DataObject newDataObject ) {} 
		protected virtual void DeleteObject( core.DataObject newDataObject ) {} 
		
		protected virtual void Selected() {}
		protected virtual void Unselected() {}

		protected virtual void MouseDoubleClicked() {}	
		
		protected virtual BitmapImage TreeImage()
		{
			return null;
		}
		
		protected virtual void MemberChanged_Value( reflection.MetadataClass ThisMetadataClass, core.ReferenceObject This, reflection.Value member, core.DataObject dataValue ) {}
		protected virtual void MemberChanged_Reference( reflection.MetadataClass ThisMetadataClass, core.ReferenceObject This, reflection.Reference member, core.ReferenceObject referenceValue ) {}
		protected virtual void MemberChanged_ParentReference( reflection.MetadataClass ThisMetadataClass, core.ReferenceObject This, reflection.ParentReference member, core.ReferenceObject referenceValue ) {}
		protected virtual void MemberChanged_FileStorage( reflection.MetadataClass ThisMetadataClass, core.ReferenceObject This, reflection.FileStorage member, core.ReferenceObject referenceValue ) {}
	}
	
	public partial class TreeObject : ITreeObject
	{
	    public Tree RootTree;
		public core.DataObject This;
		public TreeViewItem	TreeViewItem;
		public TextBlock NameTextBlock;
		
		public virtual void	CreateTree( core.DataObject dataObject, Tree rootTree ) 
		{
		}
		public virtual void	CreateTree_Label( core.DataObject dataObject, string textLabel, tree.Tree rootTree ) 
		{
		}
		protected virtual void CreateTree_Base( core.DataObject dataObject, Tree rootTree ) 
		{
		    RootTree = rootTree;
			This = dataObject;
		    RootTree.RegisterDataToTree( This, this );
		}	

		public virtual void	DestroyTree() 
		{
		}
		protected virtual void DestroyTree_Base() 
		{
		    RootTree.UnregisterDataToTree( This );
		}
		
		public virtual void		ObjectDataToControls() {}
		protected virtual void	ObjectDataToControls_Base() {}
		
		public virtual core.IFolderStorageObject ParentFolderStorage()
		{
			return null;
		}		
	}
	
	public interface ITreeCollection
	{
		bool CanContain		( TreeObject treeObject );
		void Add			( TreeObject treeObject );
		void AddAfter		( TreeObject treeObjectAfter, TreeObject treeObject );
		void Remove			( TreeObject treeObject );
	}
	
	public abstract class TreeCollectionOf<T> : TreeObject, IEnumerable<T> where T : TreeObject
	{
		private List<T> Values = new List<T>();

		public IEnumerator<T> GetEnumerator()
		{
			return Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	    
		public void Add( T item )
		{
			Values.Add( item );
		}
	    
        public void Insert( int index, T item )
        {
			Values.Insert( index, item );
        }
        
        public int IndexOf( T item )
        {
			return Values.IndexOf( item );
        }
	    
	    public void Remove( T item )
	    {
			Values.Remove( item );
	    }
	    
		public void Clear()
		{
			Values.Clear();
		}
	    
		public T Find( Predicate<T> match )
		{
			return Values.Find( match );
		}			
	}
	
	public static class Trees
	{
		delegate TreeObject DelegateCreateTree();
	
		private static Dictionary<System.Type,DelegateCreateTree> DataTypeToTreeType = new Dictionary<System.Type,DelegateCreateTree>();	
	
		static Trees()
		{
			DataTypeToTreeType.Add( typeof(Vec2), () => { return new Vec2Tree(); } );
			DataTypeToTreeType.Add( typeof(Vec3), () => { return new Vec3Tree(); } );
			DataTypeToTreeType.Add( typeof(Vec4), () => { return new Vec4Tree(); } );
			DataTypeToTreeType.Add( typeof(Color), () => { return new ColorTree(); } );
			DataTypeToTreeType.Add( typeof(game.Globals), () => { return new game.GlobalsTree(); } );
			DataTypeToTreeType.Add( typeof(game.Game), () => { return new game.GameTree(); } );
			DataTypeToTreeType.Add( typeof(gui.Gui), () => { return new gui.GuiTree(); } );
			DataTypeToTreeType.Add( typeof(gui.GuiCommon), () => { return new gui.GuiCommonTree(); } );
			DataTypeToTreeType.Add( typeof(gui.GuiMainMenu), () => { return new gui.GuiMainMenuTree(); } );
			DataTypeToTreeType.Add( typeof(gui.GuiGame), () => { return new gui.GuiGameTree(); } );
			DataTypeToTreeType.Add( typeof(gui.GuiFile), () => { return new gui.GuiFileTree(); } );
			DataTypeToTreeType.Add( typeof(gui.GuiFilesCollection), () => { return new gui.GuiFilesCollectionTree(); } );
			DataTypeToTreeType.Add( typeof(level.Levels), () => { return new level.LevelsTree(); } );
			DataTypeToTreeType.Add( typeof(level.LevelFolder), () => { return new level.LevelFolderTree(); } );
			DataTypeToTreeType.Add( typeof(level.LevelFoldersCollection), () => { return new level.LevelFoldersCollectionTree(); } );
			DataTypeToTreeType.Add( typeof(level.LevelBlock), () => { return new level.LevelBlockTree(); } );
			DataTypeToTreeType.Add( typeof(level.LevelBlocksCollection), () => { return new level.LevelBlocksCollectionTree(); } );
			DataTypeToTreeType.Add( typeof(level.LevelFile), () => { return new level.LevelFileTree(); } );
			DataTypeToTreeType.Add( typeof(level.LevelFilesCollection), () => { return new level.LevelFilesCollectionTree(); } );
			DataTypeToTreeType.Add( typeof(level.Dependency), () => { return new level.DependencyTree(); } );
			DataTypeToTreeType.Add( typeof(level.Dependencies), () => { return new level.DependenciesTree(); } );
			DataTypeToTreeType.Add( typeof(gui.Window), () => { return new gui.WindowTree(); } );
			DataTypeToTreeType.Add( typeof(gui.WindowsCollection), () => { return new gui.WindowsCollectionTree(); } );
			DataTypeToTreeType.Add( typeof(scene.SceneObject), () => { return new scene.SceneObjectTree(); } );
			DataTypeToTreeType.Add( typeof(scene.SceneObjectsCollection), () => { return new scene.SceneObjectsCollectionTree(); } );
			DataTypeToTreeType.Add( typeof(scene.SceneMesh), () => { return new scene.SceneMeshTree(); } );
			DataTypeToTreeType.Add( typeof(scene.SceneAnimMesh), () => { return new scene.SceneAnimMeshTree(); } );
			DataTypeToTreeType.Add( typeof(scene.SceneZoneTrigger), () => { return new scene.SceneZoneTriggerTree(); } );
			DataTypeToTreeType.Add( typeof(scene.Scene), () => { return new scene.SceneTree(); } );
			DataTypeToTreeType.Add( typeof(scene.ControllerBox), () => { return new scene.ControllerBoxTree(); } );
			DataTypeToTreeType.Add( typeof(scene.ControllerSphere), () => { return new scene.ControllerSphereTree(); } );
	
		}
	
		public static T CreateTreeObjectFor < T >( core.DataObject obj ) where T : TreeObject
		{
			DelegateCreateTree delegateCreateTree;
			if ( DataTypeToTreeType.TryGetValue( obj.GetType(), out delegateCreateTree ) )
			{
				TreeObject treeObject = delegateCreateTree();				
				T typedObject = treeObject as T;
				if ( typedObject == null )
					throw new core.TypeMappingException( obj.GetType() );
				return typedObject;
			}
			return null;			
		}	
	}
	
	public partial class BrowseDialog : Window
	{
        public Tree RootTree;
		public core.DataObject Reference;

		public BrowseDialog( core.IFolderStorageObject folderStorage, Predicate<core.DataObject> predicate )
		{
			WindowStyle = WindowStyle.ToolWindow;
			RootTree = new Tree( true, folderStorage, predicate );
		}

		public bool ModalDialog( core.DataObject exploreObject, string exploreObjectName, System.Type referenceType, core.DataObject currentReference )
		{
			RootTree.CreateTreeView( exploreObject, exploreObjectName );

			if ( currentReference != null )
			{
				TreeObject treeObject = RootTree.FindDataToTree( currentReference );
				if ( treeObject != null )
				{				
					TreeViewItem treeViewItem = treeObject.TreeViewItem;
					treeViewItem.IsSelected = true;
					while ( treeViewItem != null )
					{
						treeViewItem.IsExpanded = true;
						treeViewItem = treeViewItem.Parent as TreeViewItem;
					}
				}
			}

			bool result = false;
			Reference = null;

			DockPanel dockPanel = new DockPanel();
			dockPanel.LastChildFill = true;

			DockPanel buttons = new DockPanel();

			Button buttonOk = new Button{ Content = "Ok", Width = 64 };
			buttonOk.Click += ( s, e ) =>
			{
				TreeViewItem treeViewItem = (TreeViewItem)RootTree.TreeView.SelectedItem;
				tree.TreeObject treeObject = treeViewItem.DataContext as tree.TreeObject;		
				if ( treeObject != null && referenceType.IsInstanceOfType( treeObject.This ) )
				{
					Reference = treeObject.This;
					result = true;	
					Close();
				}				
			};
			
			Button buttonCancel = new Button{ Content = "Cancel", Width = 64 };
			buttonCancel.Click += ( s, e ) =>
			{
				result = false; // cancel
				Close();
			};

			Button buttonNull = new Button{ Content = "Null", Width = 64 };
			buttonNull.Click += ( s, e ) =>
			{
				Reference = null;
				result = true;	
				Close();
			};

			buttons.Children.Add( buttonOk );
			buttons.Children.Add( buttonCancel );
			buttons.Children.Add( buttonNull );
			
			DockPanel.SetDock(buttons, Dock.Bottom);
			
			dockPanel.Children.Add( buttons );
			dockPanel.Children.Add( RootTree.TreeView );
			
			Content = dockPanel;

			ShowDialog();

			return result;
		}
	}
} // tree
