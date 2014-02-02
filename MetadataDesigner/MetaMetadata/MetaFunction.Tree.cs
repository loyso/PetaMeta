using System;
using System.Collections.Generic;
using System.Windows;

using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Input;

using tree;

namespace metadata { 

	public abstract partial class FunctionTree : MemberTree
	{
		public new metadata.Function This;
		
		
		private metadata.ArgumentsCollectionTree Arguments = new metadata.ArgumentsCollectionTree();
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.Function)obj;
			string textLabel = This.Name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.Function)obj;
		    
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
			This = (metadata.Function)obj;
			base.CreateTree_Base( obj, rootTree );
			if ( rootTree.Predicate == null || rootTree.Predicate( This.Arguments ) )
			{
				Arguments = Trees.CreateTreeObjectFor < metadata.ArgumentsCollectionTree >( This.Arguments );
				Arguments.CreateTree_Label( This.Arguments, "Arguments", rootTree );
				TreeViewItem.Items.Add( Arguments.TreeViewItem );
			}
			foreach ( metadata.ArgumentTree collectionElement in Arguments )
			{
			}	
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			NameTextBlock.Text = This.Name;
			Arguments.ObjectDataToControls();
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
	}

	public partial class FunctionUserTree : FunctionTree
	{
		public new metadata.FunctionUser This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.FunctionUser)obj;
			string textLabel = This.Name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.FunctionUser)obj;
		    
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
			This = (metadata.FunctionUser)obj;
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

	public partial class FunctionLuaTree : FunctionTree
	{
		public new metadata.FunctionLua This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.FunctionLua)obj;
			string textLabel = This.Name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.FunctionLua)obj;
		    
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
			This = (metadata.FunctionLua)obj;
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

	public partial class FunctionLuaCallCCTree : FunctionTree
	{
		public new metadata.FunctionLuaCallCC This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.FunctionLuaCallCC)obj;
			string textLabel = This.Name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.FunctionLuaCallCC)obj;
		    
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
			This = (metadata.FunctionLuaCallCC)obj;
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

	public abstract partial class ArgumentTree : tree.TreeObject
	{
		public new metadata.Argument This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.Argument)obj;
			string textLabel = This.Name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.Argument)obj;
		    
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
			This = (metadata.Argument)obj;
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

	public partial class ArgumentsCollectionTree : tree.TreeCollectionOf < metadata.ArgumentTree >, ITreeCollection
	{
		public new metadata.ArgumentsCollection This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.ArgumentsCollection)obj;
			string textLabel = "ArgumentsCollection";
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.ArgumentsCollection)obj;
		    
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
				menuItem.Header = "New ArgumentValue";
				menuItem.Click += ( sender, e ) => 
				{
					metadata.ArgumentValue item = new metadata.ArgumentValue();
					item.Name = "arg";
					This.Add ( item );
		
					metadata.ArgumentValueTree treeItem = Trees.CreateTreeObjectFor < metadata.ArgumentValueTree >( item );	
					treeItem.CreateTree( item, rootTree );
					Add( treeItem );
					TreeViewItem.Items.Add( treeItem.TreeViewItem );
					NewObject( item );
				};
				contextmenu.Items.Add(menuItem);			
			};
		
			{ 
				MenuItem menuItem = new MenuItem();
				menuItem.Header = "New ArgumentReference";
				menuItem.Click += ( sender, e ) => 
				{
					metadata.ArgumentReference item = new metadata.ArgumentReference();
					item.Name = "arg";
					This.Add ( item );
		
					metadata.ArgumentReferenceTree treeItem = Trees.CreateTreeObjectFor < metadata.ArgumentReferenceTree >( item );	
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
						metadata.ArgumentTree treeObject = selectedTreeViewItem.DataContext as metadata.ArgumentTree;
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
			This = (metadata.ArgumentsCollection)obj;
			base.CreateTree_Base( obj, rootTree );
			foreach( metadata.Argument item in This )
			{
				if ( rootTree.Predicate == null || rootTree.Predicate( item ) )
				{
					metadata.ArgumentTree treeItem = Trees.CreateTreeObjectFor < metadata.ArgumentTree >( item );	
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
			foreach( metadata.ArgumentTree treeItem in this )
				treeItem.ObjectDataToControls();
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
		bool ITreeCollection.CanContain( TreeObject treeObject )
		{
			return treeObject is metadata.ArgumentTree;				
		}
		void ITreeCollection.Add( TreeObject treeObject )
		{
			metadata.ArgumentTree item = (metadata.ArgumentTree)treeObject;
			This.Add( item.This );
			Add( item );
			TreeViewItem.Items.Add( item.TreeViewItem );
		}
		void ITreeCollection.AddAfter( TreeObject treeObjectAfter, TreeObject treeObject )
		{
			metadata.ArgumentTree after = (metadata.ArgumentTree)treeObjectAfter;
			metadata.ArgumentTree item = (metadata.ArgumentTree)treeObject;
		
			int index = 0;
			if ( after != null )
				index = IndexOf( after ) + 1;
			
			This.Insert( index, item.This );
			Insert( index, item );
			TreeViewItem.Items.Insert( index, item.TreeViewItem );
		}
		void ITreeCollection.Remove( TreeObject treeObject )
		{
			metadata.ArgumentTree item = (metadata.ArgumentTree)treeObject;
			TreeViewItem.Items.Remove( item.TreeViewItem );
			Remove( item );
			This.Remove( item.This );		
		}
	}

	public partial class ArgumentValueTree : ArgumentTree
	{
		public new metadata.ArgumentValue This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.ArgumentValue)obj;
			string textLabel = This.Name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.ArgumentValue)obj;
		    
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
			This = (metadata.ArgumentValue)obj;
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

	public partial class ArgumentReferenceTree : ArgumentTree
	{
		public new metadata.ArgumentReference This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.ArgumentReference)obj;
			string textLabel = This.Name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.ArgumentReference)obj;
		    
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
			This = (metadata.ArgumentReference)obj;
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

} /* namespace metadata */ 
