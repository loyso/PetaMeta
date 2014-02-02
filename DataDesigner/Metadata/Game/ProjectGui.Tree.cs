using System;
using System.Collections.Generic;
using System.Windows;

using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Input;

using tree;

namespace gui { 

	public partial class GuiTree : tree.TreeObject
	{
		public new gui.Gui This;
		
		private gui.GuiMainMenuTree mainMenu;
		private gui.GuiGameTree game;
		public game.GameTree parent;
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (gui.Gui)obj;
			string textLabel = This.name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (gui.Gui)obj;
		    
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
			This = (gui.Gui)obj;
			base.CreateTree_Base( obj, rootTree );
			if ( rootTree.FolderStorage == null || rootTree.FolderStorage == This.mainMenu )
			if ( rootTree.Predicate == null || rootTree.Predicate( This.mainMenu ) )
				if ( This.mainMenu != null )
				{
					mainMenu = Trees.CreateTreeObjectFor < gui.GuiMainMenuTree >( This.mainMenu );
					mainMenu.CreateTree_Label( This.mainMenu, "mainMenu", rootTree );
					TreeViewItem.Items.Add( mainMenu.TreeViewItem );
					mainMenu.parent = this;
				}
			if ( rootTree.FolderStorage == null || rootTree.FolderStorage == This.game )
			if ( rootTree.Predicate == null || rootTree.Predicate( This.game ) )
				if ( This.game != null )
				{
					game = Trees.CreateTreeObjectFor < gui.GuiGameTree >( This.game );
					game.CreateTree_Label( This.game, "game", rootTree );
					TreeViewItem.Items.Add( game.TreeViewItem );
					game.parent = this;
				}
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			NameTextBlock.Text = This.name;
			if ( mainMenu != null )
				mainMenu.ObjectDataToControls();
			if ( game != null )
				game.ObjectDataToControls();
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

	public partial class GuiCommonTree : tree.TreeObject
	{
		public new gui.GuiCommon This;
		
		
		private gui.GuiFilesCollectionTree files = new gui.GuiFilesCollectionTree();
		public gui.GuiTree parent;
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (gui.GuiCommon)obj;
			string textLabel = This.name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (gui.GuiCommon)obj;
		    
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
			This = (gui.GuiCommon)obj;
			base.CreateTree_Base( obj, rootTree );
			if ( rootTree.Predicate == null || rootTree.Predicate( This.files ) )
			{
				files = Trees.CreateTreeObjectFor < gui.GuiFilesCollectionTree >( This.files );
				files.CreateTree_Label( This.files, "files", rootTree );
				TreeViewItem.Items.Add( files.TreeViewItem );
			}
			foreach ( gui.GuiFileTree collectionElement in files )
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
			return This;
		}
	}

	public partial class GuiMainMenuTree : GuiCommonTree
	{
		public new gui.GuiMainMenu This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (gui.GuiMainMenu)obj;
			string textLabel = This.name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (gui.GuiMainMenu)obj;
		    
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
			This = (gui.GuiMainMenu)obj;
			base.CreateTree_Base( obj, rootTree );
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			NameTextBlock.Text = This.name;
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return This;
		}
	}

	public partial class GuiGameTree : GuiCommonTree
	{
		public new gui.GuiGame This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (gui.GuiGame)obj;
			string textLabel = This.name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (gui.GuiGame)obj;
		    
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
			This = (gui.GuiGame)obj;
			base.CreateTree_Base( obj, rootTree );
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			NameTextBlock.Text = This.name;
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return This;
		}
	}

	public partial class GuiFileTree : tree.TreeObject
	{
		public new gui.GuiFile This;
		
		private gui.WindowTree mainWindow;
		public gui.GuiCommonTree parent;
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (gui.GuiFile)obj;
			string textLabel = This.name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (gui.GuiFile)obj;
		    
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
			This = (gui.GuiFile)obj;
			base.CreateTree_Base( obj, rootTree );
			if ( rootTree.ShowFileStorage )
			{
				if ( rootTree.Predicate == null || rootTree.Predicate( This.mainWindow ) )
					if ( This.mainWindow != null )
					{			
						mainWindow = Trees.CreateTreeObjectFor < gui.WindowTree >( This.mainWindow );
						mainWindow.CreateTree_Label( This.mainWindow, "mainWindow", rootTree );
						mainWindow.TreeViewItem.IsExpanded = true;
						TreeViewItem.Items.Add( mainWindow.TreeViewItem );			
				mainWindow.parentFile = this;
						
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
			if ( mainWindow != null )
				mainWindow.ObjectDataToControls();
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

	public partial class GuiFilesCollectionTree : tree.TreeCollectionOf < gui.GuiFileTree >, ITreeCollection
	{
		public new gui.GuiFilesCollection This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (gui.GuiFilesCollection)obj;
			string textLabel = "GuiFilesCollection";
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (gui.GuiFilesCollection)obj;
		    
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
				menuItem.Header = "New GuiFile";
				menuItem.Click += ( sender, e ) => 
				{
					gui.GuiFile item = new gui.GuiFile();
					item.name = "File";
					This.Add ( item );
		
					gui.GuiFileTree treeItem = Trees.CreateTreeObjectFor < gui.GuiFileTree >( item );	
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
						gui.GuiFileTree treeObject = selectedTreeViewItem.DataContext as gui.GuiFileTree;
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
			This = (gui.GuiFilesCollection)obj;
			base.CreateTree_Base( obj, rootTree );
			foreach( gui.GuiFile item in This )
			{
				if ( rootTree.Predicate == null || rootTree.Predicate( item ) )
				{
					gui.GuiFileTree treeItem = Trees.CreateTreeObjectFor < gui.GuiFileTree >( item );	
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
			foreach( gui.GuiFileTree treeItem in this )
				treeItem.ObjectDataToControls();
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
		bool ITreeCollection.CanContain( TreeObject treeObject )
		{
			return treeObject is gui.GuiFileTree;				
		}
		void ITreeCollection.Add( TreeObject treeObject )
		{
			gui.GuiFileTree item = (gui.GuiFileTree)treeObject;
			This.Add( item.This );
			Add( item );
			TreeViewItem.Items.Add( item.TreeViewItem );
		}
		void ITreeCollection.AddAfter( TreeObject treeObjectAfter, TreeObject treeObject )
		{
			gui.GuiFileTree after = (gui.GuiFileTree)treeObjectAfter;
			gui.GuiFileTree item = (gui.GuiFileTree)treeObject;
		
			int index = 0;
			if ( after != null )
				index = IndexOf( after ) + 1;
			
			This.Insert( index, item.This );
			Insert( index, item );
			TreeViewItem.Items.Insert( index, item.TreeViewItem );
		}
		void ITreeCollection.Remove( TreeObject treeObject )
		{
			gui.GuiFileTree item = (gui.GuiFileTree)treeObject;
			TreeViewItem.Items.Remove( item.TreeViewItem );
			Remove( item );
			This.Remove( item.This );		
		}
	}

} /* namespace gui */ 
