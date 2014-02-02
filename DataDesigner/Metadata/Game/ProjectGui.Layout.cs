using System.Windows;
using System.Windows.Controls;

namespace gui { 

	public partial class GuiLayout : gui.Layout
	{
		private gui.Gui This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
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
			MemberChanged_Value( Gui_Reflection.MetadataClass, This, Gui_Member_name.Member, new string_Boxed { value = This.name } );
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private void mainMenu_Changed()
		{
			MemberChanged_Value( Gui_Reflection.MetadataClass, This, Gui_Member_mainMenu.Member, This.mainMenu );
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private void game_Changed()
		{
			MemberChanged_Value( Gui_Reflection.MetadataClass, This, Gui_Member_game.Member, This.game );
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
			This = (gui.Gui)dataObject;
			base.CreateControls_Base( dataObject, collection );
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
			TypeLabel.Content = "Gui";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			name.Text = This.name;
		}
	}

	public partial class GuiCommonLayout : gui.Layout
	{
		private gui.GuiCommon This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
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
			This = (gui.GuiCommon)dataObject;
			base.CreateControls_Base( dataObject, collection );
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
			TypeLabel.Content = "GuiCommon";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			name.Text = This.name;
		}
	}

	public partial class GuiMainMenuLayout : GuiCommonLayout
	{
		private gui.GuiMainMenu This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
		
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
			This = (gui.GuiMainMenu)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "GuiMainMenu";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class GuiGameLayout : GuiCommonLayout
	{
		private gui.GuiGame This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
		
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
			This = (gui.GuiGame)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "GuiGame";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class GuiFileLayout : gui.Layout
	{
		private gui.GuiFile This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
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
			This = (gui.GuiFile)dataObject;
			base.CreateControls_Base( dataObject, collection );
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
			TypeLabel.Content = "GuiFile";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			name.Text = This.name;
		}
	}

	public partial class GuiFilesCollectionLayout : gui.Layout
	{
		private gui.GuiFilesCollection This = null;
		
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
			This = (gui.GuiFilesCollection)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "GuiFilesCollection";
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

} /* namespace gui */ 
