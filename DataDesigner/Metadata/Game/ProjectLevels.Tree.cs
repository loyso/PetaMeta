using System;
using System.Collections.Generic;
using System.Windows;

using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Input;

using tree;

namespace level { 

	public partial class LevelsTree : tree.TreeObject
	{
		public new level.Levels This;
		
		
		private level.LevelFoldersCollectionTree folders = new level.LevelFoldersCollectionTree();
		public game.GameTree parent;
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (level.Levels)obj;
			string textLabel = This.name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (level.Levels)obj;
		    
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
			This = (level.Levels)obj;
			base.CreateTree_Base( obj, rootTree );
			if ( rootTree.Predicate == null || rootTree.Predicate( This.folders ) )
			{
				folders = Trees.CreateTreeObjectFor < level.LevelFoldersCollectionTree >( This.folders );
				folders.CreateTree_Label( This.folders, "folders", rootTree );
				TreeViewItem.Items.Add( folders.TreeViewItem );
			}
			foreach ( level.LevelFolderTree collectionElement in folders )
			{
				collectionElement.parent = this;
			}	
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			NameTextBlock.Text = This.name;
			folders.ObjectDataToControls();
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			if ( parent != null )
			{
				core.IFolderStorageObject parentStorage = parent.ParentFolderStorage();
				if ( parentStorage != null )
					return parentStorage;
			}
			return base.ParentFolderStorage();
		}
	}

	public partial class LevelFolderTree : tree.TreeObject
	{
		public new level.LevelFolder This;
		
		public level.LevelsTree parent;
		
		private level.DependenciesTree dependencies = new level.DependenciesTree();
		
		private level.LevelBlocksCollectionTree blocks = new level.LevelBlocksCollectionTree();
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (level.LevelFolder)obj;
			string textLabel = This.name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (level.LevelFolder)obj;
		    
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
			This = (level.LevelFolder)obj;
			base.CreateTree_Base( obj, rootTree );
			if ( rootTree.Predicate == null || rootTree.Predicate( This.dependencies ) )
			{
				dependencies = Trees.CreateTreeObjectFor < level.DependenciesTree >( This.dependencies );
				dependencies.CreateTree_Label( This.dependencies, "dependencies", rootTree );
				TreeViewItem.Items.Add( dependencies.TreeViewItem );
			}
			foreach ( level.DependencyTree collectionElement in dependencies )
			{
			}	
			if ( rootTree.Predicate == null || rootTree.Predicate( This.blocks ) )
			{
				blocks = Trees.CreateTreeObjectFor < level.LevelBlocksCollectionTree >( This.blocks );
				blocks.CreateTree_Label( This.blocks, "blocks", rootTree );
				TreeViewItem.Items.Add( blocks.TreeViewItem );
			}
			foreach ( level.LevelBlockTree collectionElement in blocks )
			{
				collectionElement.parent = this;
			}	
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			NameTextBlock.Text = This.name;
			dependencies.ObjectDataToControls();
			blocks.ObjectDataToControls();
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return This;
		}
	}

	public partial class LevelFoldersCollectionTree : tree.TreeCollectionOf < level.LevelFolderTree >, ITreeCollection
	{
		public new level.LevelFoldersCollection This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (level.LevelFoldersCollection)obj;
			string textLabel = "LevelFoldersCollection";
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (level.LevelFoldersCollection)obj;
		    
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
				menuItem.Header = "New LevelFolder";
				menuItem.Click += ( sender, e ) => 
				{
					level.LevelFolder item = new level.LevelFolder();
					item.name = "Level";
					This.Add ( item );
		
					level.LevelFolderTree treeItem = Trees.CreateTreeObjectFor < level.LevelFolderTree >( item );	
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
						level.LevelFolderTree treeObject = selectedTreeViewItem.DataContext as level.LevelFolderTree;
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
			This = (level.LevelFoldersCollection)obj;
			base.CreateTree_Base( obj, rootTree );
			foreach( level.LevelFolder item in This )
			{
				if ( rootTree.FolderStorage == null || rootTree.FolderStorage == item || rootTree.FolderStorage.DependsOn( item ) )
				if ( rootTree.Predicate == null || rootTree.Predicate( item ) )
				{
					level.LevelFolderTree treeItem = Trees.CreateTreeObjectFor < level.LevelFolderTree >( item );	
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
			foreach( level.LevelFolderTree treeItem in this )
				treeItem.ObjectDataToControls();
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
		bool ITreeCollection.CanContain( TreeObject treeObject )
		{
			return treeObject is level.LevelFolderTree;				
		}
		void ITreeCollection.Add( TreeObject treeObject )
		{
			level.LevelFolderTree item = (level.LevelFolderTree)treeObject;
			This.Add( item.This );
			Add( item );
			TreeViewItem.Items.Add( item.TreeViewItem );
		}
		void ITreeCollection.AddAfter( TreeObject treeObjectAfter, TreeObject treeObject )
		{
			level.LevelFolderTree after = (level.LevelFolderTree)treeObjectAfter;
			level.LevelFolderTree item = (level.LevelFolderTree)treeObject;
		
			int index = 0;
			if ( after != null )
				index = IndexOf( after ) + 1;
			
			This.Insert( index, item.This );
			Insert( index, item );
			TreeViewItem.Items.Insert( index, item.TreeViewItem );
		}
		void ITreeCollection.Remove( TreeObject treeObject )
		{
			level.LevelFolderTree item = (level.LevelFolderTree)treeObject;
			TreeViewItem.Items.Remove( item.TreeViewItem );
			Remove( item );
			This.Remove( item.This );		
		}
	}

	public partial class LevelBlockTree : tree.TreeObject
	{
		public new level.LevelBlock This;
		
		public level.LevelFolderTree parent;
		
		private level.LevelFilesCollectionTree files = new level.LevelFilesCollectionTree();
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (level.LevelBlock)obj;
			string textLabel = This.name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (level.LevelBlock)obj;
		    
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
			This = (level.LevelBlock)obj;
			base.CreateTree_Base( obj, rootTree );
			if ( rootTree.Predicate == null || rootTree.Predicate( This.files ) )
			{
				files = Trees.CreateTreeObjectFor < level.LevelFilesCollectionTree >( This.files );
				files.CreateTree_Label( This.files, "files", rootTree );
				TreeViewItem.Items.Add( files.TreeViewItem );
			}
			foreach ( level.LevelFileTree collectionElement in files )
			{
				collectionElement.parent = this;
			}	
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			NameTextBlock.Text = This.name;
			files.ObjectDataToControls();
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			if ( parent != null )
			{
				core.IFolderStorageObject parentStorage = parent.ParentFolderStorage();
				if ( parentStorage != null )
					return parentStorage;
			}
			return base.ParentFolderStorage();
		}
	}

	public partial class LevelBlocksCollectionTree : tree.TreeCollectionOf < level.LevelBlockTree >, ITreeCollection
	{
		public new level.LevelBlocksCollection This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (level.LevelBlocksCollection)obj;
			string textLabel = "LevelBlocksCollection";
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (level.LevelBlocksCollection)obj;
		    
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
				menuItem.Header = "New LevelBlock";
				menuItem.Click += ( sender, e ) => 
				{
					level.LevelBlock item = new level.LevelBlock();
					item.name = "Block";
					This.Add ( item );
		
					level.LevelBlockTree treeItem = Trees.CreateTreeObjectFor < level.LevelBlockTree >( item );	
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
						level.LevelBlockTree treeObject = selectedTreeViewItem.DataContext as level.LevelBlockTree;
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
			This = (level.LevelBlocksCollection)obj;
			base.CreateTree_Base( obj, rootTree );
			foreach( level.LevelBlock item in This )
			{
				if ( rootTree.Predicate == null || rootTree.Predicate( item ) )
				{
					level.LevelBlockTree treeItem = Trees.CreateTreeObjectFor < level.LevelBlockTree >( item );	
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
			foreach( level.LevelBlockTree treeItem in this )
				treeItem.ObjectDataToControls();
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
		bool ITreeCollection.CanContain( TreeObject treeObject )
		{
			return treeObject is level.LevelBlockTree;				
		}
		void ITreeCollection.Add( TreeObject treeObject )
		{
			level.LevelBlockTree item = (level.LevelBlockTree)treeObject;
			This.Add( item.This );
			Add( item );
			TreeViewItem.Items.Add( item.TreeViewItem );
		}
		void ITreeCollection.AddAfter( TreeObject treeObjectAfter, TreeObject treeObject )
		{
			level.LevelBlockTree after = (level.LevelBlockTree)treeObjectAfter;
			level.LevelBlockTree item = (level.LevelBlockTree)treeObject;
		
			int index = 0;
			if ( after != null )
				index = IndexOf( after ) + 1;
			
			This.Insert( index, item.This );
			Insert( index, item );
			TreeViewItem.Items.Insert( index, item.TreeViewItem );
		}
		void ITreeCollection.Remove( TreeObject treeObject )
		{
			level.LevelBlockTree item = (level.LevelBlockTree)treeObject;
			TreeViewItem.Items.Remove( item.TreeViewItem );
			Remove( item );
			This.Remove( item.This );		
		}
	}

	public partial class LevelFileTree : tree.TreeObject
	{
		public new level.LevelFile This;
		
		public level.LevelBlockTree parent;
		private scene.SceneTree scene;
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (level.LevelFile)obj;
			string textLabel = This.name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (level.LevelFile)obj;
		    
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
			This = (level.LevelFile)obj;
			base.CreateTree_Base( obj, rootTree );
			if ( rootTree.ShowFileStorage )
			{
				if ( rootTree.Predicate == null || rootTree.Predicate( This.scene ) )
					if ( This.scene != null )
					{			
						scene = Trees.CreateTreeObjectFor < scene.SceneTree >( This.scene );
						scene.CreateTree_Label( This.scene, "scene", rootTree );
						scene.TreeViewItem.IsExpanded = true;
						TreeViewItem.Items.Add( scene.TreeViewItem );			
						
					}
			}
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			NameTextBlock.Text = This.name;
			if ( scene != null )
				scene.ObjectDataToControls();
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			if ( parent != null )
			{
				core.IFolderStorageObject parentStorage = parent.ParentFolderStorage();
				if ( parentStorage != null )
					return parentStorage;
			}
			return base.ParentFolderStorage();
		}
	}

	public partial class LevelFilesCollectionTree : tree.TreeCollectionOf < level.LevelFileTree >, ITreeCollection
	{
		public new level.LevelFilesCollection This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (level.LevelFilesCollection)obj;
			string textLabel = "LevelFilesCollection";
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (level.LevelFilesCollection)obj;
		    
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
				menuItem.Header = "New LevelFile";
				menuItem.Click += ( sender, e ) => 
				{
					level.LevelFile item = new level.LevelFile();
					item.name = "File";
					This.Add ( item );
		
					level.LevelFileTree treeItem = Trees.CreateTreeObjectFor < level.LevelFileTree >( item );	
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
						level.LevelFileTree treeObject = selectedTreeViewItem.DataContext as level.LevelFileTree;
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
			This = (level.LevelFilesCollection)obj;
			base.CreateTree_Base( obj, rootTree );
			foreach( level.LevelFile item in This )
			{
				if ( rootTree.Predicate == null || rootTree.Predicate( item ) )
				{
					level.LevelFileTree treeItem = Trees.CreateTreeObjectFor < level.LevelFileTree >( item );	
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
			foreach( level.LevelFileTree treeItem in this )
				treeItem.ObjectDataToControls();
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
		bool ITreeCollection.CanContain( TreeObject treeObject )
		{
			return treeObject is level.LevelFileTree;				
		}
		void ITreeCollection.Add( TreeObject treeObject )
		{
			level.LevelFileTree item = (level.LevelFileTree)treeObject;
			This.Add( item.This );
			Add( item );
			TreeViewItem.Items.Add( item.TreeViewItem );
		}
		void ITreeCollection.AddAfter( TreeObject treeObjectAfter, TreeObject treeObject )
		{
			level.LevelFileTree after = (level.LevelFileTree)treeObjectAfter;
			level.LevelFileTree item = (level.LevelFileTree)treeObject;
		
			int index = 0;
			if ( after != null )
				index = IndexOf( after ) + 1;
			
			This.Insert( index, item.This );
			Insert( index, item );
			TreeViewItem.Items.Insert( index, item.TreeViewItem );
		}
		void ITreeCollection.Remove( TreeObject treeObject )
		{
			level.LevelFileTree item = (level.LevelFileTree)treeObject;
			TreeViewItem.Items.Remove( item.TreeViewItem );
			Remove( item );
			This.Remove( item.This );		
		}
	}

	public partial class DependencyTree : tree.TreeObject
	{
		public new level.Dependency This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (level.Dependency)obj;
			string textLabel = "Dependency";
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (level.Dependency)obj;
		    
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
			This = (level.Dependency)obj;
			base.CreateTree_Base( obj, rootTree );
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
	}

	public partial class DependenciesTree : tree.TreeCollectionOf < level.DependencyTree >, ITreeCollection
	{
		public new level.Dependencies This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (level.Dependencies)obj;
			string textLabel = "Dependencies";
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (level.Dependencies)obj;
		    
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
				menuItem.Header = "New Dependency";
				menuItem.Click += ( sender, e ) => 
				{
					level.Dependency item = new level.Dependency();
					This.Add ( item );
		
					level.DependencyTree treeItem = Trees.CreateTreeObjectFor < level.DependencyTree >( item );	
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
						level.DependencyTree treeObject = selectedTreeViewItem.DataContext as level.DependencyTree;
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
			This = (level.Dependencies)obj;
			base.CreateTree_Base( obj, rootTree );
			foreach( level.Dependency item in This )
			{
				if ( rootTree.Predicate == null || rootTree.Predicate( item ) )
				{
					level.DependencyTree treeItem = Trees.CreateTreeObjectFor < level.DependencyTree >( item );	
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
			foreach( level.DependencyTree treeItem in this )
				treeItem.ObjectDataToControls();
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
		bool ITreeCollection.CanContain( TreeObject treeObject )
		{
			return treeObject is level.DependencyTree;				
		}
		void ITreeCollection.Add( TreeObject treeObject )
		{
			level.DependencyTree item = (level.DependencyTree)treeObject;
			This.Add( item.This );
			Add( item );
			TreeViewItem.Items.Add( item.TreeViewItem );
		}
		void ITreeCollection.AddAfter( TreeObject treeObjectAfter, TreeObject treeObject )
		{
			level.DependencyTree after = (level.DependencyTree)treeObjectAfter;
			level.DependencyTree item = (level.DependencyTree)treeObject;
		
			int index = 0;
			if ( after != null )
				index = IndexOf( after ) + 1;
			
			This.Insert( index, item.This );
			Insert( index, item );
			TreeViewItem.Items.Insert( index, item.TreeViewItem );
		}
		void ITreeCollection.Remove( TreeObject treeObject )
		{
			level.DependencyTree item = (level.DependencyTree)treeObject;
			TreeViewItem.Items.Remove( item.TreeViewItem );
			Remove( item );
			This.Remove( item.This );		
		}
	}

} /* namespace level */ 
