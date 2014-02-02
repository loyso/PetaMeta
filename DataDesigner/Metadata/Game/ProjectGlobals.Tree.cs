using System;
using System.Collections.Generic;
using System.Windows;

using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Input;

using tree;

namespace game { 

	public partial class GlobalsTree : tree.TreeObject
	{
		public new game.Globals This;
		
		public game.GameTree parent;
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (game.Globals)obj;
			string textLabel = This.name;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (game.Globals)obj;
		    
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
			This = (game.Globals)obj;
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
			if ( parent != null )
			{
				core.IFolderStorageObject parentStorage = parent.ParentFolderStorage();
				if ( parentStorage != null )
					return parentStorage;
			}
			return base.ParentFolderStorage();
		}
	}

} /* namespace game */ 
