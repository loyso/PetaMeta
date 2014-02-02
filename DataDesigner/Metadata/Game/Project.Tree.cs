using System;
using System.Collections.Generic;
using System.Windows;

using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Input;

using tree;

namespace game { 

	public partial class GameTree : tree.TreeObject
	{
		public new game.Game This;
		
		private gui.GuiTree gui;
		private level.LevelsTree levels;
		public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
		{
			This = (game.Game)obj;
			string textLabel = This.ProjectName;
			CreateTree_Label( obj, textLabel, rootTree );
		}		
		public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
		{
			This = (game.Game)obj;
		    
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
			This = (game.Game)obj;
			base.CreateTree_Base( obj, rootTree );
			if ( rootTree.Predicate == null || rootTree.Predicate( This.gui ) )
				if ( This.gui != null )
				{
					gui = Trees.CreateTreeObjectFor < gui.GuiTree >( This.gui );
					gui.CreateTree_Label( This.gui, "gui", rootTree );
					TreeViewItem.Items.Add( gui.TreeViewItem );
					gui.parent = this;
				}
			if ( rootTree.Predicate == null || rootTree.Predicate( This.levels ) )
				if ( This.levels != null )
				{
					levels = Trees.CreateTreeObjectFor < level.LevelsTree >( This.levels );
					levels.CreateTree_Label( This.levels, "levels", rootTree );
					TreeViewItem.Items.Add( levels.TreeViewItem );
					levels.parent = this;
				}
		}
		
		public override void ObjectDataToControls()
		{
			ObjectDataToControls_Base();
		}
		protected override void ObjectDataToControls_Base()
		{
			if ( gui != null )
				gui.ObjectDataToControls();
			if ( levels != null )
				levels.ObjectDataToControls();
			base.ObjectDataToControls_Base();
		}
		
		public override core.IFolderStorageObject ParentFolderStorage() 
		{
			return base.ParentFolderStorage();
		}
	}

} /* namespace game */ 
