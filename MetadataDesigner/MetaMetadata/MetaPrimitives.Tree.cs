using System;
using System.Collections.Generic;
using System.Windows;

using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Input;

using tree;

namespace metadata { 

	public abstract partial class FundamentalTree : TypeTree
	{
		public new metadata.Fundamental This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.Fundamental)obj;
			string textLabel = This.TypeName;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.Fundamental)obj;
		    
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
			This = (metadata.Fundamental)obj;
			base.CreateTree_Base( obj, rootTree );
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			NameTextBlock.Text = This.TypeName;
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
	}

	public partial class FundamentalBoolTree : FundamentalTree
	{
		public new metadata.FundamentalBool This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.FundamentalBool)obj;
			string textLabel = This.TypeName;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.FundamentalBool)obj;
		    
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
			This = (metadata.FundamentalBool)obj;
			base.CreateTree_Base( obj, rootTree );
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			NameTextBlock.Text = This.TypeName;
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
	}

	public partial class FundamentalStringTree : FundamentalTree
	{
		public new metadata.FundamentalString This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.FundamentalString)obj;
			string textLabel = This.TypeName;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.FundamentalString)obj;
		    
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
			This = (metadata.FundamentalString)obj;
			base.CreateTree_Base( obj, rootTree );
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			NameTextBlock.Text = This.TypeName;
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
	}

	public partial class FundamentalIntTree : FundamentalTree
	{
		public new metadata.FundamentalInt This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.FundamentalInt)obj;
			string textLabel = This.TypeName;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.FundamentalInt)obj;
		    
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
			This = (metadata.FundamentalInt)obj;
			base.CreateTree_Base( obj, rootTree );
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			NameTextBlock.Text = This.TypeName;
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
	}

	public partial class FundamentalFloatTree : FundamentalTree
	{
		public new metadata.FundamentalFloat This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.FundamentalFloat)obj;
			string textLabel = This.TypeName;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.FundamentalFloat)obj;
		    
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
			This = (metadata.FundamentalFloat)obj;
			base.CreateTree_Base( obj, rootTree );
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			NameTextBlock.Text = This.TypeName;
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
	}

	public partial class FundamentalByteTree : FundamentalTree
	{
		public new metadata.FundamentalByte This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.FundamentalByte)obj;
			string textLabel = This.TypeName;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.FundamentalByte)obj;
		    
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
			This = (metadata.FundamentalByte)obj;
			base.CreateTree_Base( obj, rootTree );
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			NameTextBlock.Text = This.TypeName;
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
	}

	public partial class EnumerationTree : TypeTree
	{
		public new metadata.Enumeration This;
		
		
		private metadata.EnumeratorsCollectionTree Enumerators = new metadata.EnumeratorsCollectionTree();
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.Enumeration)obj;
			string textLabel = This.TypeName;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.Enumeration)obj;
		    
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
			This = (metadata.Enumeration)obj;
			base.CreateTree_Base( obj, rootTree );
			if ( rootTree.Predicate == null || rootTree.Predicate( This.Enumerators ) )
			{
				Enumerators = Trees.CreateTreeObjectFor < metadata.EnumeratorsCollectionTree >( This.Enumerators );
				Enumerators.CreateTree_Label( This.Enumerators, "Enumerators", rootTree );
				TreeViewItem.Items.Add( Enumerators.TreeViewItem );
			}
			foreach ( metadata.EnumeratorTree collectionElement in Enumerators )
			{
			}	
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			NameTextBlock.Text = This.TypeName;
			Enumerators.ObjectDataToControls();
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
	}

	public partial class EnumeratorTree : tree.TreeObject
	{
		public new metadata.Enumerator This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.Enumerator)obj;
			string textLabel = This.Name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.Enumerator)obj;
		    
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
			This = (metadata.Enumerator)obj;
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

	public partial class EnumeratorsCollectionTree : tree.TreeCollectionOf < metadata.EnumeratorTree >, ITreeCollection
	{
		public new metadata.EnumeratorsCollection This;
		
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (metadata.EnumeratorsCollection)obj;
			string textLabel = "EnumeratorsCollection";
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (metadata.EnumeratorsCollection)obj;
		    
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
				menuItem.Header = "New Enumerator";
				menuItem.Click += ( sender, e ) => 
				{
					metadata.Enumerator item = new metadata.Enumerator();
					item.Name = "Enumerator";
					This.Add ( item );
		
					metadata.EnumeratorTree treeItem = Trees.CreateTreeObjectFor < metadata.EnumeratorTree >( item );	
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
						metadata.EnumeratorTree treeObject = selectedTreeViewItem.DataContext as metadata.EnumeratorTree;
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
			This = (metadata.EnumeratorsCollection)obj;
			base.CreateTree_Base( obj, rootTree );
			foreach( metadata.Enumerator item in This )
			{
				if ( rootTree.Predicate == null || rootTree.Predicate( item ) )
				{
					metadata.EnumeratorTree treeItem = Trees.CreateTreeObjectFor < metadata.EnumeratorTree >( item );	
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
			foreach( metadata.EnumeratorTree treeItem in this )
				treeItem.ObjectDataToControls();
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
		bool ITreeCollection.CanContain( TreeObject treeObject )
		{
			return treeObject is metadata.EnumeratorTree;				
		}
		void ITreeCollection.Add( TreeObject treeObject )
		{
			metadata.EnumeratorTree item = (metadata.EnumeratorTree)treeObject;
			This.Add( item.This );
			Add( item );
			TreeViewItem.Items.Add( item.TreeViewItem );
		}
		void ITreeCollection.AddAfter( TreeObject treeObjectAfter, TreeObject treeObject )
		{
			metadata.EnumeratorTree after = (metadata.EnumeratorTree)treeObjectAfter;
			metadata.EnumeratorTree item = (metadata.EnumeratorTree)treeObject;
		
			int index = 0;
			if ( after != null )
				index = IndexOf( after ) + 1;
			
			This.Insert( index, item.This );
			Insert( index, item );
			TreeViewItem.Items.Insert( index, item.TreeViewItem );
		}
		void ITreeCollection.Remove( TreeObject treeObject )
		{
			metadata.EnumeratorTree item = (metadata.EnumeratorTree)treeObject;
			TreeViewItem.Items.Remove( item.TreeViewItem );
			Remove( item );
			This.Remove( item.This );		
		}
	}

} /* namespace metadata */ 
