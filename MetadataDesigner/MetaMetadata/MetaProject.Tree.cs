using System;
using System.Collections.Generic;
using System.Windows;

using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Input;

using tree;

namespace metadata { 

	public partial class MetadataFileTree : tree.TreeObject
	{
		public new metadata.MetadataFile This;
		
		public metadata.MetadataFolderTree Parent;
		private metadata.MetadataFileContentTree Content;
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.MetadataFile)obj;
			string textLabel = This.Name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.MetadataFile)obj;
		    
		    NameTextBlock = new TextBlock{ Text = textLabel };
		    
			BitmapImage bitmapImage = TreeImage();
			if ( bitmapImage != null )
				TreeViewItem = new TreeViewItem{ Header = new DockPanel { Children = { new Image{ Width=16, Height=16, Source = bitmapImage }, NameTextBlock } } };
			else
				TreeViewItem = new TreeViewItem{ Header = NameTextBlock };
		
			TreeViewItem.DataContext = this;
			TreeViewItem.Selected += ( sender, e ) => { Selected(); e.Handled = true; };
			TreeViewItem.Unselected += ( sender, e ) => { Unselected(); e.Handled = true; };
			TreeViewItem.MouseDoubleClick += ( sender, e ) => { if ( TreeViewItem.IsSelected ) MouseDoubleClicked(); };
			
			TreeViewItem.IsExpanded = true;
			CreateTree_Base( obj, rootTree );
		}
		
		protected override void	CreateTree_Base( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.MetadataFile)obj;
			base.CreateTree_Base( obj, rootTree );
			if ( rootTree.ShowFileStorage )
			{
				if ( rootTree.Predicate == null || rootTree.Predicate( This.Content ) )
					if ( This.Content != null )
					{			
						Content = Trees.CreateTreeObjectFor < metadata.MetadataFileContentTree >( This.Content );
						Content.CreateTree_Label( This.Content, "Content", rootTree );
						Content.TreeViewItem.IsExpanded = true;
						TreeViewItem.Items.Add( Content.TreeViewItem );			
				Content.Parent = this;
						
					}
			}
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			NameTextBlock.Text = This.Name;
			if ( Content != null )
				Content.ObjectDataToControls();
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			if ( Parent != null )
			{
				core.IFolderStorageObject parentStorage = Parent.ParentFolderStorage();
				if ( parentStorage != null )
					return parentStorage;
			}
			return base.ParentFolderStorage();
		}
	}

	public partial class MetadataFilesCollectionTree : tree.TreeCollectionOf < metadata.MetadataFileTree >, ITreeCollection
	{
		public new metadata.MetadataFilesCollection This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.MetadataFilesCollection)obj;
			string textLabel = "MetadataFilesCollection";
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.MetadataFilesCollection)obj;
		    
		    NameTextBlock = new TextBlock{ Text = textLabel };
		    
			BitmapImage bitmapImage = TreeImage();
			if ( bitmapImage != null )
				TreeViewItem = new TreeViewItem{ Header = new DockPanel { Children = { new Image{ Width=16, Height=16, Source = bitmapImage }, NameTextBlock } } };
			else
				TreeViewItem = new TreeViewItem{ Header = NameTextBlock };
		
			TreeViewItem.DataContext = this;
			TreeViewItem.Selected += ( sender, e ) => { Selected(); e.Handled = true; };
			TreeViewItem.Unselected += ( sender, e ) => { Unselected(); e.Handled = true; };
			TreeViewItem.MouseDoubleClick += ( sender, e ) => { if ( TreeViewItem.IsSelected ) MouseDoubleClicked(); };
			
			TreeViewItem.IsExpanded = true;
		
			ContextMenu contextmenu = new ContextMenu();
			TreeViewItem.ContextMenu = contextmenu;
				
		
			{ 
				MenuItem menuItem = new MenuItem();
				menuItem.Header = "New MetadataFile";
				menuItem.Click += ( sender, e ) => 
				{
					metadata.MetadataFile item = new metadata.MetadataFile();
					item.Name = "File";
					This.Add ( item );
		
					metadata.MetadataFileTree treeItem = Trees.CreateTreeObjectFor < metadata.MetadataFileTree >( item );	
					treeItem.CreateTree( item, rootTree );
					Add( treeItem );
					TreeViewItem.Items.Add( treeItem.TreeViewItem );
					NewObject( item );
				};
				contextmenu.Items.Add(menuItem);			
			};
			{ 
				MenuItem menuItem = new MenuItem();
				menuItem.Header = "Delete";
				menuItem.Click += ( sender, e ) => 
				{
					TreeViewItem selectedTreeViewItem = (TreeViewItem)rootTree.TreeView.SelectedItem;
					if ( selectedTreeViewItem != null && selectedTreeViewItem != TreeViewItem )
					{
						metadata.MetadataFileTree treeObject = selectedTreeViewItem.DataContext as metadata.MetadataFileTree;
						if ( treeObject != null )
						{
						    treeObject.DestroyTree();
							TreeViewItem.Items.Remove( treeObject.TreeViewItem );
							Remove( treeObject );
							This.Remove( treeObject.This );
							DeleteObject( treeObject.This );
						}
					}
				};
				contextmenu.Items.Add(menuItem);			
			};
			CreateTree_Base( obj, rootTree );
		}
		
		protected override void	CreateTree_Base( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.MetadataFilesCollection)obj;
			base.CreateTree_Base( obj, rootTree );
			foreach( metadata.MetadataFile item in This )
			{
				if ( rootTree.Predicate == null || rootTree.Predicate( item ) )
				{
					metadata.MetadataFileTree treeItem = Trees.CreateTreeObjectFor < metadata.MetadataFileTree >( item );	
					treeItem.CreateTree( item, rootTree );
					{
						Add( treeItem );
						TreeViewItem.Items.Add( treeItem.TreeViewItem );
					}
				}
			}
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			foreach( metadata.MetadataFileTree treeItem in this )
				treeItem.ObjectDataToControls();
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
		bool ITreeCollection.CanContain( TreeObject treeObject )
		{
			return treeObject is metadata.MetadataFileTree;				
		}
		void ITreeCollection.Add( TreeObject treeObject )
		{
			metadata.MetadataFileTree item = (metadata.MetadataFileTree)treeObject;
			This.Add( item.This );
			Add( item );
			TreeViewItem.Items.Add( item.TreeViewItem );
		}
		void ITreeCollection.AddAfter( TreeObject treeObjectAfter, TreeObject treeObject )
		{
			metadata.MetadataFileTree after = (metadata.MetadataFileTree)treeObjectAfter;
			metadata.MetadataFileTree item = (metadata.MetadataFileTree)treeObject;
		
			int index = 0;
			if ( after != null )
				index = IndexOf( after ) + 1;
			
			This.Insert( index, item.This );
			Insert( index, item );
			TreeViewItem.Items.Insert( index, item.TreeViewItem );
		}
		void ITreeCollection.Remove( TreeObject treeObject )
		{
			metadata.MetadataFileTree item = (metadata.MetadataFileTree)treeObject;
			TreeViewItem.Items.Remove( item.TreeViewItem );
			Remove( item );
			This.Remove( item.This );		
		}
	}

	public partial class MetadataFolderTree : tree.TreeObject
	{
		public new metadata.MetadataFolder This;
		
		public metadata.MetadataFolderTree Parent;
		public metadata.MetadataProjectTree ParentProject;
		
		private metadata.MetadataFoldersCollectionTree Folders = new metadata.MetadataFoldersCollectionTree();
		
		private metadata.MetadataFilesCollectionTree Files = new metadata.MetadataFilesCollectionTree();
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.MetadataFolder)obj;
			string textLabel = This.Name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.MetadataFolder)obj;
		    
		    NameTextBlock = new TextBlock{ Text = textLabel };
		    
			BitmapImage bitmapImage = TreeImage();
			if ( bitmapImage != null )
				TreeViewItem = new TreeViewItem{ Header = new DockPanel { Children = { new Image{ Width=16, Height=16, Source = bitmapImage }, NameTextBlock } } };
			else
				TreeViewItem = new TreeViewItem{ Header = NameTextBlock };
		
			TreeViewItem.DataContext = this;
			TreeViewItem.Selected += ( sender, e ) => { Selected(); e.Handled = true; };
			TreeViewItem.Unselected += ( sender, e ) => { Unselected(); e.Handled = true; };
			TreeViewItem.MouseDoubleClick += ( sender, e ) => { if ( TreeViewItem.IsSelected ) MouseDoubleClicked(); };
			
			TreeViewItem.IsExpanded = true;
			CreateTree_Base( obj, rootTree );
		}
		
		protected override void	CreateTree_Base( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.MetadataFolder)obj;
			base.CreateTree_Base( obj, rootTree );
			if ( rootTree.Predicate == null || rootTree.Predicate( This.Folders ) )
			{
				Folders = Trees.CreateTreeObjectFor < metadata.MetadataFoldersCollectionTree >( This.Folders );
				Folders.CreateTree_Label( This.Folders, "Folders", rootTree );
				TreeViewItem.Items.Add( Folders.TreeViewItem );
			}
			foreach ( metadata.MetadataFolderTree collectionElement in Folders )
			{
				collectionElement.Parent = this;
			}	
			if ( rootTree.Predicate == null || rootTree.Predicate( This.Files ) )
			{
				Files = Trees.CreateTreeObjectFor < metadata.MetadataFilesCollectionTree >( This.Files );
				Files.CreateTree_Label( This.Files, "Files", rootTree );
				TreeViewItem.Items.Add( Files.TreeViewItem );
			}
			foreach ( metadata.MetadataFileTree collectionElement in Files )
			{
				collectionElement.Parent = this;
			}	
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			NameTextBlock.Text = This.Name;
			Folders.ObjectDataToControls();
			Files.ObjectDataToControls();
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			if ( Parent != null )
			{
				core.IFolderStorageObject parentStorage = Parent.ParentFolderStorage();
				if ( parentStorage != null )
					return parentStorage;
			}
			if ( ParentProject != null )
			{
				core.IFolderStorageObject parentStorage = ParentProject.ParentFolderStorage();
				if ( parentStorage != null )
					return parentStorage;
			}
			return base.ParentFolderStorage();
		}
	}

	public partial class MetadataFoldersCollectionTree : tree.TreeCollectionOf < metadata.MetadataFolderTree >, ITreeCollection
	{
		public new metadata.MetadataFoldersCollection This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.MetadataFoldersCollection)obj;
			string textLabel = "MetadataFoldersCollection";
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.MetadataFoldersCollection)obj;
		    
		    NameTextBlock = new TextBlock{ Text = textLabel };
		    
			BitmapImage bitmapImage = TreeImage();
			if ( bitmapImage != null )
				TreeViewItem = new TreeViewItem{ Header = new DockPanel { Children = { new Image{ Width=16, Height=16, Source = bitmapImage }, NameTextBlock } } };
			else
				TreeViewItem = new TreeViewItem{ Header = NameTextBlock };
		
			TreeViewItem.DataContext = this;
			TreeViewItem.Selected += ( sender, e ) => { Selected(); e.Handled = true; };
			TreeViewItem.Unselected += ( sender, e ) => { Unselected(); e.Handled = true; };
			TreeViewItem.MouseDoubleClick += ( sender, e ) => { if ( TreeViewItem.IsSelected ) MouseDoubleClicked(); };
			
			TreeViewItem.IsExpanded = true;
		
			ContextMenu contextmenu = new ContextMenu();
			TreeViewItem.ContextMenu = contextmenu;
				
		
			{ 
				MenuItem menuItem = new MenuItem();
				menuItem.Header = "New MetadataFolder";
				menuItem.Click += ( sender, e ) => 
				{
					metadata.MetadataFolder item = new metadata.MetadataFolder();
					item.Name = "Folder";
					This.Add ( item );
		
					metadata.MetadataFolderTree treeItem = Trees.CreateTreeObjectFor < metadata.MetadataFolderTree >( item );	
					treeItem.CreateTree( item, rootTree );
					Add( treeItem );
					TreeViewItem.Items.Add( treeItem.TreeViewItem );
					NewObject( item );
				};
				contextmenu.Items.Add(menuItem);			
			};
			{ 
				MenuItem menuItem = new MenuItem();
				menuItem.Header = "Delete";
				menuItem.Click += ( sender, e ) => 
				{
					TreeViewItem selectedTreeViewItem = (TreeViewItem)rootTree.TreeView.SelectedItem;
					if ( selectedTreeViewItem != null && selectedTreeViewItem != TreeViewItem )
					{
						metadata.MetadataFolderTree treeObject = selectedTreeViewItem.DataContext as metadata.MetadataFolderTree;
						if ( treeObject != null )
						{
						    treeObject.DestroyTree();
							TreeViewItem.Items.Remove( treeObject.TreeViewItem );
							Remove( treeObject );
							This.Remove( treeObject.This );
							DeleteObject( treeObject.This );
						}
					}
				};
				contextmenu.Items.Add(menuItem);			
			};
			CreateTree_Base( obj, rootTree );
		}
		
		protected override void	CreateTree_Base( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.MetadataFoldersCollection)obj;
			base.CreateTree_Base( obj, rootTree );
			foreach( metadata.MetadataFolder item in This )
			{
				if ( rootTree.Predicate == null || rootTree.Predicate( item ) )
				{
					metadata.MetadataFolderTree treeItem = Trees.CreateTreeObjectFor < metadata.MetadataFolderTree >( item );	
					treeItem.CreateTree( item, rootTree );
					{
						Add( treeItem );
						TreeViewItem.Items.Add( treeItem.TreeViewItem );
					}
				}
			}
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			foreach( metadata.MetadataFolderTree treeItem in this )
				treeItem.ObjectDataToControls();
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
		bool ITreeCollection.CanContain( TreeObject treeObject )
		{
			return treeObject is metadata.MetadataFolderTree;				
		}
		void ITreeCollection.Add( TreeObject treeObject )
		{
			metadata.MetadataFolderTree item = (metadata.MetadataFolderTree)treeObject;
			This.Add( item.This );
			Add( item );
			TreeViewItem.Items.Add( item.TreeViewItem );
		}
		void ITreeCollection.AddAfter( TreeObject treeObjectAfter, TreeObject treeObject )
		{
			metadata.MetadataFolderTree after = (metadata.MetadataFolderTree)treeObjectAfter;
			metadata.MetadataFolderTree item = (metadata.MetadataFolderTree)treeObject;
		
			int index = 0;
			if ( after != null )
				index = IndexOf( after ) + 1;
			
			This.Insert( index, item.This );
			Insert( index, item );
			TreeViewItem.Items.Insert( index, item.TreeViewItem );
		}
		void ITreeCollection.Remove( TreeObject treeObject )
		{
			metadata.MetadataFolderTree item = (metadata.MetadataFolderTree)treeObject;
			TreeViewItem.Items.Remove( item.TreeViewItem );
			Remove( item );
			This.Remove( item.This );		
		}
	}

	public partial class MetadataMemberGroupTree : tree.TreeObject
	{
		public new metadata.MetadataMemberGroup This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.MetadataMemberGroup)obj;
			string textLabel = This.Name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.MetadataMemberGroup)obj;
		    
		    NameTextBlock = new TextBlock{ Text = textLabel };
		    
			BitmapImage bitmapImage = TreeImage();
			if ( bitmapImage != null )
				TreeViewItem = new TreeViewItem{ Header = new DockPanel { Children = { new Image{ Width=16, Height=16, Source = bitmapImage }, NameTextBlock } } };
			else
				TreeViewItem = new TreeViewItem{ Header = NameTextBlock };
		
			TreeViewItem.DataContext = this;
			TreeViewItem.Selected += ( sender, e ) => { Selected(); e.Handled = true; };
			TreeViewItem.Unselected += ( sender, e ) => { Unselected(); e.Handled = true; };
			TreeViewItem.MouseDoubleClick += ( sender, e ) => { if ( TreeViewItem.IsSelected ) MouseDoubleClicked(); };
			
			CreateTree_Base( obj, rootTree );
		}
		
		protected override void	CreateTree_Base( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.MetadataMemberGroup)obj;
			base.CreateTree_Base( obj, rootTree );
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			NameTextBlock.Text = This.Name;
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
	}

	public partial class MemberGroupsCollectionTree : tree.TreeCollectionOf < metadata.MetadataMemberGroupTree >, ITreeCollection
	{
		public new metadata.MemberGroupsCollection This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.MemberGroupsCollection)obj;
			string textLabel = "MemberGroupsCollection";
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.MemberGroupsCollection)obj;
		    
		    NameTextBlock = new TextBlock{ Text = textLabel };
		    
			BitmapImage bitmapImage = TreeImage();
			if ( bitmapImage != null )
				TreeViewItem = new TreeViewItem{ Header = new DockPanel { Children = { new Image{ Width=16, Height=16, Source = bitmapImage }, NameTextBlock } } };
			else
				TreeViewItem = new TreeViewItem{ Header = NameTextBlock };
		
			TreeViewItem.DataContext = this;
			TreeViewItem.Selected += ( sender, e ) => { Selected(); e.Handled = true; };
			TreeViewItem.Unselected += ( sender, e ) => { Unselected(); e.Handled = true; };
			TreeViewItem.MouseDoubleClick += ( sender, e ) => { if ( TreeViewItem.IsSelected ) MouseDoubleClicked(); };
			
		
			ContextMenu contextmenu = new ContextMenu();
			TreeViewItem.ContextMenu = contextmenu;
				
		
			{ 
				MenuItem menuItem = new MenuItem();
				menuItem.Header = "New MetadataMemberGroup";
				menuItem.Click += ( sender, e ) => 
				{
					metadata.MetadataMemberGroup item = new metadata.MetadataMemberGroup();
					item.Name = "Group";
					This.Add ( item );
		
					metadata.MetadataMemberGroupTree treeItem = Trees.CreateTreeObjectFor < metadata.MetadataMemberGroupTree >( item );	
					treeItem.CreateTree( item, rootTree );
					Add( treeItem );
					TreeViewItem.Items.Add( treeItem.TreeViewItem );
					NewObject( item );
				};
				contextmenu.Items.Add(menuItem);			
			};
			{ 
				MenuItem menuItem = new MenuItem();
				menuItem.Header = "Delete";
				menuItem.Click += ( sender, e ) => 
				{
					TreeViewItem selectedTreeViewItem = (TreeViewItem)rootTree.TreeView.SelectedItem;
					if ( selectedTreeViewItem != null && selectedTreeViewItem != TreeViewItem )
					{
						metadata.MetadataMemberGroupTree treeObject = selectedTreeViewItem.DataContext as metadata.MetadataMemberGroupTree;
						if ( treeObject != null )
						{
						    treeObject.DestroyTree();
							TreeViewItem.Items.Remove( treeObject.TreeViewItem );
							Remove( treeObject );
							This.Remove( treeObject.This );
							DeleteObject( treeObject.This );
						}
					}
				};
				contextmenu.Items.Add(menuItem);			
			};
			CreateTree_Base( obj, rootTree );
		}
		
		protected override void	CreateTree_Base( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.MemberGroupsCollection)obj;
			base.CreateTree_Base( obj, rootTree );
			foreach( metadata.MetadataMemberGroup item in This )
			{
				if ( rootTree.Predicate == null || rootTree.Predicate( item ) )
				{
					metadata.MetadataMemberGroupTree treeItem = Trees.CreateTreeObjectFor < metadata.MetadataMemberGroupTree >( item );	
					treeItem.CreateTree( item, rootTree );
					{
						Add( treeItem );
						TreeViewItem.Items.Add( treeItem.TreeViewItem );
					}
				}
			}
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			foreach( metadata.MetadataMemberGroupTree treeItem in this )
				treeItem.ObjectDataToControls();
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
		bool ITreeCollection.CanContain( TreeObject treeObject )
		{
			return treeObject is metadata.MetadataMemberGroupTree;				
		}
		void ITreeCollection.Add( TreeObject treeObject )
		{
			metadata.MetadataMemberGroupTree item = (metadata.MetadataMemberGroupTree)treeObject;
			This.Add( item.This );
			Add( item );
			TreeViewItem.Items.Add( item.TreeViewItem );
		}
		void ITreeCollection.AddAfter( TreeObject treeObjectAfter, TreeObject treeObject )
		{
			metadata.MetadataMemberGroupTree after = (metadata.MetadataMemberGroupTree)treeObjectAfter;
			metadata.MetadataMemberGroupTree item = (metadata.MetadataMemberGroupTree)treeObject;
		
			int index = 0;
			if ( after != null )
				index = IndexOf( after ) + 1;
			
			This.Insert( index, item.This );
			Insert( index, item );
			TreeViewItem.Items.Insert( index, item.TreeViewItem );
		}
		void ITreeCollection.Remove( TreeObject treeObject )
		{
			metadata.MetadataMemberGroupTree item = (metadata.MetadataMemberGroupTree)treeObject;
			TreeViewItem.Items.Remove( item.TreeViewItem );
			Remove( item );
			This.Remove( item.This );		
		}
	}

	public partial class MetadataProjectTree : tree.TreeObject
	{
		public new metadata.MetadataProject This;
		
		private metadata.MetadataFolderTree Metadata;
		
		private metadata.MemberGroupsCollectionTree MemberGroups = new metadata.MemberGroupsCollectionTree();
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.MetadataProject)obj;
			string textLabel = This.ProjectName;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.MetadataProject)obj;
		    
		    NameTextBlock = new TextBlock{ Text = textLabel };
		    
			BitmapImage bitmapImage = TreeImage();
			if ( bitmapImage != null )
				TreeViewItem = new TreeViewItem{ Header = new DockPanel { Children = { new Image{ Width=16, Height=16, Source = bitmapImage }, NameTextBlock } } };
			else
				TreeViewItem = new TreeViewItem{ Header = NameTextBlock };
		
			TreeViewItem.DataContext = this;
			TreeViewItem.Selected += ( sender, e ) => { Selected(); e.Handled = true; };
			TreeViewItem.Unselected += ( sender, e ) => { Unselected(); e.Handled = true; };
			TreeViewItem.MouseDoubleClick += ( sender, e ) => { if ( TreeViewItem.IsSelected ) MouseDoubleClicked(); };
			
			TreeViewItem.IsExpanded = true;
			CreateTree_Base( obj, rootTree );
		}
		
		protected override void	CreateTree_Base( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.MetadataProject)obj;
			base.CreateTree_Base( obj, rootTree );
			if ( rootTree.Predicate == null || rootTree.Predicate( This.Metadata ) )
				if ( This.Metadata != null )
				{
					Metadata = Trees.CreateTreeObjectFor < metadata.MetadataFolderTree >( This.Metadata );
					Metadata.CreateTree_Label( This.Metadata, "Metadata", rootTree );
					TreeViewItem.Items.Add( Metadata.TreeViewItem );
					Metadata.ParentProject = this;
				}
			if ( rootTree.Predicate == null || rootTree.Predicate( This.MemberGroups ) )
			{
				MemberGroups = Trees.CreateTreeObjectFor < metadata.MemberGroupsCollectionTree >( This.MemberGroups );
				MemberGroups.CreateTree_Label( This.MemberGroups, "MemberGroups", rootTree );
				TreeViewItem.Items.Add( MemberGroups.TreeViewItem );
			}
			foreach ( metadata.MetadataMemberGroupTree collectionElement in MemberGroups )
			{
			}	
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			if ( Metadata != null )
				Metadata.ObjectDataToControls();
			MemberGroups.ObjectDataToControls();
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
	}

} /* namespace metadata */ 
