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
			DataTypeToTreeType.Add( typeof(metadata.FundamentalBool), () => { return new metadata.FundamentalBoolTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.FundamentalString), () => { return new metadata.FundamentalStringTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.FundamentalInt), () => { return new metadata.FundamentalIntTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.FundamentalFloat), () => { return new metadata.FundamentalFloatTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.FundamentalByte), () => { return new metadata.FundamentalByteTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.Enumeration), () => { return new metadata.EnumerationTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.Enumerator), () => { return new metadata.EnumeratorTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.EnumeratorsCollection), () => { return new metadata.EnumeratorsCollectionTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.TypesCollection), () => { return new metadata.TypesCollectionTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.MetadataClass), () => { return new metadata.MetadataClassTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.AbstractClass), () => { return new metadata.AbstractClassTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.CollectionClass), () => { return new metadata.CollectionClassTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.FileClass), () => { return new metadata.FileClassTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.FolderClass), () => { return new metadata.FolderClassTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.FolderStorageClass), () => { return new metadata.FolderStorageClassTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.ProjectClass), () => { return new metadata.ProjectClassTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.MetadataFileContent), () => { return new metadata.MetadataFileContentTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.MembersCollection), () => { return new metadata.MembersCollectionTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.Value), () => { return new metadata.ValueTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.ValueName), () => { return new metadata.ValueNameTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.Reference), () => { return new metadata.ReferenceTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.ParentReference), () => { return new metadata.ParentReferenceTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.Collection), () => { return new metadata.CollectionTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.FileStorage), () => { return new metadata.FileStorageTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.MetadataFile), () => { return new metadata.MetadataFileTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.MetadataFilesCollection), () => { return new metadata.MetadataFilesCollectionTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.MetadataFolder), () => { return new metadata.MetadataFolderTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.MetadataFoldersCollection), () => { return new metadata.MetadataFoldersCollectionTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.MetadataMemberGroup), () => { return new metadata.MetadataMemberGroupTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.MemberGroupsCollection), () => { return new metadata.MemberGroupsCollectionTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.MetadataProject), () => { return new metadata.MetadataProjectTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.FunctionUser), () => { return new metadata.FunctionUserTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.FunctionLua), () => { return new metadata.FunctionLuaTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.FunctionLuaCallCC), () => { return new metadata.FunctionLuaCallCCTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.ArgumentsCollection), () => { return new metadata.ArgumentsCollectionTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.ArgumentValue), () => { return new metadata.ArgumentValueTree(); } );
			DataTypeToTreeType.Add( typeof(metadata.ArgumentReference), () => { return new metadata.ArgumentReferenceTree(); } );
	
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
