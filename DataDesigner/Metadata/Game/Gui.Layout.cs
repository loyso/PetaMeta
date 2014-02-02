using System.Windows;
using System.Windows.Controls;

namespace gui { 

	public partial class WindowLayout : gui.Layout
	{
		private gui.Window This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
		private Vec2Layout positionLayout;
		private GroupBox position;
		private void position_Changed()
		{
			MemberChanged_Value( Window_Reflection.MetadataClass, This, Window_Member_position.Member, This.position );
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private Vec2Layout sizeLayout;
		private GroupBox size;
		private void size_Changed()
		{
			MemberChanged_Value( Window_Reflection.MetadataClass, This, Window_Member_size.Member, This.size );
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private TextBox name;
		private void name_TextChanged(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.name = name.Text;
			name_Changed();	
			NameChanged();
		}

		private void name_Changed()
		{
			MemberChanged_Value( Window_Reflection.MetadataClass, This, Window_Member_name.Member, new string_Boxed { value = This.name } );
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		
		public override void CreateControls ( core.DataObject dataObject, UIElementCollection collection )
		{
			{
				TypeLabel = new Label();
				collection.Add( TypeLabel );		
			}
			{
				GuidLabel = new Label();
				collection.Add( GuidLabel );
			}
			CreateControls_Base( dataObject, collection );
		}
		protected override void CreateControls_Base ( core.DataObject dataObject, UIElementCollection collection )
		{
			This = (gui.Window)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				DockPanel dockPanel = new DockPanel();
				dockPanel.Children.Add( new Label { Content = "position" } );
				position = new GroupBox { Header = dockPanel };
				if ( This.position != null )
				{
					positionLayout = gui.Layouts.CreateLayoutFor< Vec2Layout >( This.position );
					positionLayout.ParentLayout = this;
					positionLayout.ObjectChanged += position_Changed;
			
					
					StackPanel panel = new StackPanel();
					positionLayout.CreateControls( This.position, panel.Children );
					position.Content = panel;
				}
				collection.Add( position );	
			}
			
			{
				DockPanel dockPanel = new DockPanel();
				dockPanel.Children.Add( new Label { Content = "size" } );
				size = new GroupBox { Header = dockPanel };
				if ( This.size != null )
				{
					sizeLayout = gui.Layouts.CreateLayoutFor< Vec2Layout >( This.size );
					sizeLayout.ParentLayout = this;
					sizeLayout.ObjectChanged += size_Changed;
			
					
					StackPanel panel = new StackPanel();
					sizeLayout.CreateControls( This.size, panel.Children );
					size.Content = panel;
				}
				collection.Add( size );	
			}
			
			{
				name = new TextBox();
				name.TextChanged += name_TextChanged;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label{ Content = "name" } );
				panel.Children.Add( name );
				collection.Add( panel );
			}

		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "Window";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			if ( positionLayout != null )
				positionLayout.ObjectDataToControls();
			if ( sizeLayout != null )
				sizeLayout.ObjectDataToControls();
			name.Text = This.name;
		}
	}

	public partial class WindowsCollectionLayout : gui.Layout
	{
		private gui.WindowsCollection This = null;
		
		private Label TypeLabel;
		
		public override void CreateControls ( core.DataObject dataObject, UIElementCollection collection )
		{
			{
				TypeLabel = new Label();
				collection.Add( TypeLabel );		
			}
			CreateControls_Base( dataObject, collection );
		}
		protected override void CreateControls_Base ( core.DataObject dataObject, UIElementCollection collection )
		{
			This = (gui.WindowsCollection)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "WindowsCollection";
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

} /* namespace gui */ 
