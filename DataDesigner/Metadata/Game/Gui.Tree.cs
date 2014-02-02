using System;
using System.Collections.Generic;
using System.Windows;

using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Input;

using tree;

namespace gui { 

	public partial class WindowTree : tree.TreeObject
	{
		public new gui.Window This;
		
		
		private gui.WindowsCollectionTree children = new gui.WindowsCollectionTree();
		public gui.WindowTree parent;
		public gui.GuiFileTree parentFile;
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (gui.Window)obj;
			string textLabel = This.name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (gui.Window)obj;
		    
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
			This = (gui.Window)obj;
			base.CreateTree_Base( obj, rootTree );
			if ( rootTree.Predicate == null || rootTree.Predicate( This.children ) )
			{
				children = Trees.CreateTreeObjectFor < gui.WindowsCollectionTree >( This.children );
				children.CreateTree_Label( This.children, "children", rootTree );
				TreeViewItem.Items.Add( children.TreeViewItem );
			}
			foreach ( gui.WindowTree collectionElement in children )
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
			children.ObjectDataToControls();
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
			if ( parentFile != null )
			{
				core.IFolderStorageObject parentStorage = parentFile.ParentFolderStorage();
				if ( parentStorage != null )
					return parentStorage;
			}
			return base.ParentFolderStorage();
		}
	}

	public partial class WindowsCollectionTree : tree.TreeCollectionOf < gui.WindowTree >, ITreeCollection
	{
		public new gui.WindowsCollection This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (gui.WindowsCollection)obj;
			string textLabel = "WindowsCollection";
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (gui.WindowsCollection)obj;
		    
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
				menuItem.Header = "New Window";
				menuItem.Click += ( sender, e ) => 
				{
					gui.Window item = new gui.Window();
					item.name = "Window";
					This.Add ( item );
		
					gui.WindowTree treeItem = Trees.CreateTreeObjectFor < gui.WindowTree >( item );	
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
						gui.WindowTree treeObject = selectedTreeViewItem.DataContext as gui.WindowTree;
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
			This = (gui.WindowsCollection)obj;
			base.CreateTree_Base( obj, rootTree );
			foreach( gui.Window item in This )
			{
				if ( rootTree.Predicate == null || rootTree.Predicate( item ) )
				{
					gui.WindowTree treeItem = Trees.CreateTreeObjectFor < gui.WindowTree >( item );	
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
			foreach( gui.WindowTree treeItem in this )
				treeItem.ObjectDataToControls();
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
		bool ITreeCollection.CanContain( TreeObject treeObject )
		{
			return treeObject is gui.WindowTree;				
		}
		void ITreeCollection.Add( TreeObject treeObject )
		{
			gui.WindowTree item = (gui.WindowTree)treeObject;
			This.Add( item.This );
			Add( item );
			TreeViewItem.Items.Add( item.TreeViewItem );
		}
		void ITreeCollection.AddAfter( TreeObject treeObjectAfter, TreeObject treeObject )
		{
			gui.WindowTree after = (gui.WindowTree)treeObjectAfter;
			gui.WindowTree item = (gui.WindowTree)treeObject;
		
			int index = 0;
			if ( after != null )
				index = IndexOf( after ) + 1;
			
			This.Insert( index, item.This );
			Insert( index, item );
			TreeViewItem.Items.Insert( index, item.TreeViewItem );
		}
		void ITreeCollection.Remove( TreeObject treeObject )
		{
			gui.WindowTree item = (gui.WindowTree)treeObject;
			TreeViewItem.Items.Remove( item.TreeViewItem );
			Remove( item );
			This.Remove( item.This );		
		}
	}

} /* namespace gui */ 
