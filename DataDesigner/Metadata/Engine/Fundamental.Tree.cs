using System;
using System.Collections.Generic;
using System.Windows;

using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Input;

using tree;

public partial class Vec2Tree : tree.TreeObject
{
	public new Vec2 This;
	
	public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
	{
		This = (Vec2)obj;
		string textLabel = "Vec2";
		CreateTree_Label( obj, textLabel, rootTree );
	}		
	public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
	{
		This = (Vec2)obj;
	    
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
		This = (Vec2)obj;
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

public partial class Vec3Tree : tree.TreeObject
{
	public new Vec3 This;
	
	public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
	{
		This = (Vec3)obj;
		string textLabel = "Vec3";
		CreateTree_Label( obj, textLabel, rootTree );
	}		
	public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
	{
		This = (Vec3)obj;
	    
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
		This = (Vec3)obj;
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

public partial class Vec4Tree : tree.TreeObject
{
	public new Vec4 This;
	
	public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
	{
		This = (Vec4)obj;
		string textLabel = "Vec4";
		CreateTree_Label( obj, textLabel, rootTree );
	}		
	public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
	{
		This = (Vec4)obj;
	    
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
		This = (Vec4)obj;
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

public partial class ColorTree : tree.TreeObject
{
	public new Color This;
	
	public override void CreateTree( core.DataObject obj, tree.Tree rootTree )
	{
		This = (Color)obj;
		string textLabel = "Color";
		CreateTree_Label( obj, textLabel, rootTree );
	}		
	public override void CreateTree_Label( core.DataObject obj, string textLabel, tree.Tree rootTree )
	{
		This = (Color)obj;
	    
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
		This = (Color)obj;
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

