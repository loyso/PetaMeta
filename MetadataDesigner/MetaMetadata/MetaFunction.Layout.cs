using System.Windows;
using System.Windows.Controls;

namespace metadata { 

	public abstract partial class FunctionLayout : MemberLayout
	{
		private metadata.Function This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
		private metadata.ArgumentLayout ResultLayout;
		private GroupBox Result;
		private ComboBox ResultComboBox;
		void Result_SelectionChanged( object sender, SelectionChangedEventArgs args )
		{
			switch ( ResultComboBox.SelectedIndex )
			{
			case 0:
				This.Result = null;
				ResultLayout = null;
				Result.Content = null;
				break;
			case 1:
				{
					metadata.Argument deletedObject = This.Result;
					This.Result = new metadata.ArgumentValue();
					ResultLayout = gui.Layouts.CreateLayoutFor< metadata.ArgumentLayout >( This.Result );
					ResultLayout.ParentLayout = this;
					ResultLayout.ObjectChanged += Result_Changed;
					StackPanel panel = new StackPanel();
					ResultLayout.CreateControls( This.Result, panel.Children );
					NewObject( This.Result, deletedObject );
					ResultLayout.ObjectDataToControls();
					Result.Content = panel;
				}
				break;
			case 2:
				{
					metadata.Argument deletedObject = This.Result;
					This.Result = new metadata.ArgumentReference();
					ResultLayout = gui.Layouts.CreateLayoutFor< metadata.ArgumentLayout >( This.Result );
					ResultLayout.ParentLayout = this;
					ResultLayout.ObjectChanged += Result_Changed;
					StackPanel panel = new StackPanel();
					ResultLayout.CreateControls( This.Result, panel.Children );
					NewObject( This.Result, deletedObject );
					ResultLayout.ObjectDataToControls();
					Result.Content = panel;
				}
				break;
				
				
			}
		}
		private void Result_Changed()
		{
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private RadioButton Remote_None;
		private void Remote_None_Checked(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.Remote = metadata.RemoteType.None;
			Remote_Changed();	
		}
		private RadioButton Remote_Server;
		private void Remote_Server_Checked(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.Remote = metadata.RemoteType.Server;
			Remote_Changed();	
		}
		private RadioButton Remote_Client;
		private void Remote_Client_Checked(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.Remote = metadata.RemoteType.Client;
			Remote_Changed();	
		}
		private void Remote_Changed()
		{
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private CheckBox IsStatic;
		private void IsStatic_Clicked(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
				
			This.IsStatic = IsStatic.IsChecked ?? false;
			IsStatic_Changed();
		}

		private void IsStatic_Changed()
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
			This = (metadata.Function)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				DockPanel dockPanel = new DockPanel();
				dockPanel.Children.Add( new Label { Content = "Result" } );
				ResultComboBox = new ComboBox { IsEditable = false, IsReadOnly = true, MinWidth = 128 };
				ResultComboBox.Items.Add("[null]");
				if ( This.Result == null )
					ResultComboBox.SelectedIndex = 0;
				ResultComboBox.Items.Add(" ArgumentValue" );
				if ( This.Result != null && This.Result.GetType() == typeof(metadata.ArgumentValue) )
					ResultComboBox.SelectedIndex = 1;
				ResultComboBox.Items.Add(" ArgumentReference" );
				if ( This.Result != null && This.Result.GetType() == typeof(metadata.ArgumentReference) )
					ResultComboBox.SelectedIndex = 2;
					
				dockPanel.Children.Add ( ResultComboBox );
				ResultComboBox.SelectionChanged += Result_SelectionChanged;
				
				Result = new GroupBox { Header = dockPanel };
				if ( This.Result != null )
				{
					ResultLayout = gui.Layouts.CreateLayoutFor< metadata.ArgumentLayout >( This.Result );
					ResultLayout.ParentLayout = this;
					ResultLayout.ObjectChanged += Result_Changed;
			
					
					StackPanel panel = new StackPanel();
					ResultLayout.CreateControls( This.Result, panel.Children );
					Result.Content = panel;
				}
				collection.Add( Result );	
			}
			
			{
				DockPanel panel = new DockPanel();
				StackPanel stackPanel = new StackPanel();
				Remote_None = new RadioButton { GroupName="Remote", Content="None" };
				Remote_None.Checked += Remote_None_Checked;
				stackPanel.Children.Add( Remote_None );
				Remote_Server = new RadioButton { GroupName="Remote", Content="Server" };
				Remote_Server.Checked += Remote_Server_Checked;
				stackPanel.Children.Add( Remote_Server );
				Remote_Client = new RadioButton { GroupName="Remote", Content="Client" };
				Remote_Client.Checked += Remote_Client_Checked;
				stackPanel.Children.Add( Remote_Client );
				panel.Children.Add( new Label{ Content = "Remote" } );
				panel.Children.Add( stackPanel );
				collection.Add( panel );
			}
			
			{
				IsStatic = new CheckBox { VerticalAlignment = VerticalAlignment.Center };
				IsStatic.Click += IsStatic_Clicked;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label { Content = "IsStatic" } );
				panel.Children.Add( IsStatic );
				collection.Add( panel );
			}

		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "Function";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			if ( ResultLayout != null )
				ResultLayout.ObjectDataToControls();
			switch ( This.Remote )
			{
			case metadata.RemoteType.None:
				Remote_None.IsChecked = true;
				break;
			case metadata.RemoteType.Server:
				Remote_Server.IsChecked = true;
				break;
			case metadata.RemoteType.Client:
				Remote_Client.IsChecked = true;
				break;
			} // switch
			IsStatic.IsChecked = This.IsStatic;
		}
	}

	public partial class FunctionUserLayout : FunctionLayout
	{
		private metadata.FunctionUser This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
		private CheckBox ExposeToLua;
		private void ExposeToLua_Clicked(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
				
			This.ExposeToLua = ExposeToLua.IsChecked ?? false;
			ExposeToLua_Changed();
		}

		private void ExposeToLua_Changed()
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
			This = (metadata.FunctionUser)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				ExposeToLua = new CheckBox { VerticalAlignment = VerticalAlignment.Center };
				ExposeToLua.Click += ExposeToLua_Clicked;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label { Content = "ExposeToLua" } );
				panel.Children.Add( ExposeToLua );
				collection.Add( panel );
			}

		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "FunctionUser";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			ExposeToLua.IsChecked = This.ExposeToLua;
		}
	}

	public partial class FunctionLuaLayout : FunctionLayout
	{
		private metadata.FunctionLua This = null;
		
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
			This = (metadata.FunctionLua)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "FunctionLua";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class FunctionLuaCallCCLayout : FunctionLayout
	{
		private metadata.FunctionLuaCallCC This = null;
		
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
			This = (metadata.FunctionLuaCallCC)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "FunctionLuaCallCC";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public abstract partial class ArgumentLayout : gui.Layout
	{
		private metadata.Argument This = null;
		
		private TextBox Name;
		private void Name_TextChanged(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.Name = Name.Text;
			Name_Changed();	
			NameChanged();
		}

		private void Name_Changed()
		{
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		
		public override void CreateControls ( core.DataObject dataObject, UIElementCollection collection )
		{
			CreateControls_Base( dataObject, collection );
		}
		protected override void CreateControls_Base ( core.DataObject dataObject, UIElementCollection collection )
		{
			This = (metadata.Argument)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				Name = new TextBox();
				Name.TextChanged += Name_TextChanged;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label{ Content = "Name" } );
				panel.Children.Add( Name );
				collection.Add( panel );
			}

		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			Name.Text = This.Name;
		}
	}

	public partial class ArgumentsCollectionLayout : gui.Layout
	{
		private metadata.ArgumentsCollection This = null;
		
		
		public override void CreateControls ( core.DataObject dataObject, UIElementCollection collection )
		{
			CreateControls_Base( dataObject, collection );
		}
		protected override void CreateControls_Base ( core.DataObject dataObject, UIElementCollection collection )
		{
			This = (metadata.ArgumentsCollection)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class ArgumentValueLayout : ArgumentLayout
	{
		private metadata.ArgumentValue This = null;
		
		private Label TypeLabel;
		private TextBox Type;
		private TextBox TypeGuid;
		private void Type_Clicked(object sender, RoutedEventArgs eventArgs )
		{
			core.DataObject reference = null;
		
			bool result = BrowseClicked( typeof(metadata.Type)
				, "Type"
			    , ( dataObject ) => 
			    { 
					// substitute
					if ( dataObject is metadata.Fundamental ) return true;
					if ( dataObject is metadata.FundamentalBool ) return true;
					if ( dataObject is metadata.FundamentalString ) return true;
					if ( dataObject is metadata.FundamentalInt ) return true;
					if ( dataObject is metadata.FundamentalFloat ) return true;
					if ( dataObject is metadata.FundamentalByte ) return true;
					if ( dataObject is metadata.Enumeration ) return true;
					if ( dataObject is metadata.Type ) return true;
					if ( dataObject is metadata.MetadataClass ) return true;
					if ( dataObject is metadata.AbstractClass ) return true;
					if ( dataObject is metadata.CollectionClass ) return true;
					if ( dataObject is metadata.FileClass ) return true;
					if ( dataObject is metadata.FolderClass ) return true;
					if ( dataObject is metadata.FolderStorageClass ) return true;
					if ( dataObject is metadata.ProjectClass ) return true;
					// aggregate
					if ( dataObject is metadata.TypesCollection ) return true;
					if ( dataObject is metadata.MetadataFileContent ) return true;
					if ( dataObject is metadata.MetadataFile ) return true;
					if ( dataObject is metadata.MetadataFilesCollection ) return true;
					if ( dataObject is metadata.MetadataFolder ) return true;
					if ( dataObject is metadata.MetadataFoldersCollection ) return true;
					if ( dataObject is metadata.MetadataProject ) return true;
			    	return false;
		        }   
		        , This.Type     
		        , out reference
		    );
			
			if ( result )
			{
				if ( reference == null )
				{
					This.Type = null;
					Type.Text = "[null]";
					TypeGuid.Text = "";
				}
				else if ( reference is metadata.Type )
				{			
					This.Type = (metadata.Type)reference;
					Type.Text = This.Type == null ? "[null]" : This.Type.TypeName;
					
					TypeGuid.Text = This.Type == null ? "" : This.Type.Guid.ToOptString();	
				}		
				Type_Changed();
			}	
		}
		private void Type_Changed()
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
			CreateControls_Base( dataObject, collection );
		}
		protected override void CreateControls_Base ( core.DataObject dataObject, UIElementCollection collection )
		{
			This = (metadata.ArgumentValue)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				DockPanel panel = new DockPanel();
				Type = new TextBox { IsReadOnly = true };
				TypeGuid = new TextBox { IsReadOnly = true };
				panel.Children.Add( new Label{ Content = "Type" } );
				Button button = new Button{ Content = "Browse..." };
				button.Click += Type_Clicked;
				panel.Children.Add( button );
				panel.Children.Add( Type );
				panel.Children.Add( TypeGuid );
				collection.Add( panel );
			}

		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "ArgumentValue";
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			Type.Text = This.Type == null ? "[null]" : This.Type.TypeName;
			TypeGuid.Text = This.Type == null ? "" : This.Type.Guid.ToOptString();
		}
	}

	public partial class ArgumentReferenceLayout : ArgumentLayout
	{
		private metadata.ArgumentReference This = null;
		
		private Label TypeLabel;
		private TextBox Type;
		private TextBox TypeGuid;
		private void Type_Clicked(object sender, RoutedEventArgs eventArgs )
		{
			core.DataObject reference = null;
		
			bool result = BrowseClicked( typeof(metadata.MetadataClass)
				, "MetadataClass"
			    , ( dataObject ) => 
			    { 
					// substitute
					if ( dataObject is metadata.MetadataClass ) return true;
					if ( dataObject is metadata.AbstractClass ) return true;
					if ( dataObject is metadata.CollectionClass ) return true;
					if ( dataObject is metadata.FileClass ) return true;
					if ( dataObject is metadata.FolderClass ) return true;
					if ( dataObject is metadata.FolderStorageClass ) return true;
					if ( dataObject is metadata.ProjectClass ) return true;
					// aggregate
					if ( dataObject is metadata.TypesCollection ) return true;
					if ( dataObject is metadata.MetadataFileContent ) return true;
					if ( dataObject is metadata.MetadataFile ) return true;
					if ( dataObject is metadata.MetadataFilesCollection ) return true;
					if ( dataObject is metadata.MetadataFolder ) return true;
					if ( dataObject is metadata.MetadataFoldersCollection ) return true;
					if ( dataObject is metadata.MetadataProject ) return true;
			    	return false;
		        }   
		        , This.Type     
		        , out reference
		    );
			
			if ( result )
			{
				if ( reference == null )
				{
					This.Type = null;
					Type.Text = "[null]";
					TypeGuid.Text = "";
				}
				else if ( reference is metadata.MetadataClass )
				{			
					This.Type = (metadata.MetadataClass)reference;
					Type.Text = This.Type == null ? "[null]" : This.Type.TypeName;
					
					TypeGuid.Text = This.Type == null ? "" : This.Type.Guid.ToOptString();	
				}		
				Type_Changed();
			}	
		}
		private void Type_Changed()
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
			CreateControls_Base( dataObject, collection );
		}
		protected override void CreateControls_Base ( core.DataObject dataObject, UIElementCollection collection )
		{
			This = (metadata.ArgumentReference)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				DockPanel panel = new DockPanel();
				Type = new TextBox { IsReadOnly = true };
				TypeGuid = new TextBox { IsReadOnly = true };
				panel.Children.Add( new Label{ Content = "Type" } );
				Button button = new Button{ Content = "Browse..." };
				button.Click += Type_Clicked;
				panel.Children.Add( button );
				panel.Children.Add( Type );
				panel.Children.Add( TypeGuid );
				collection.Add( panel );
			}

		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "ArgumentReference";
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			Type.Text = This.Type == null ? "[null]" : This.Type.TypeName;
			TypeGuid.Text = This.Type == null ? "" : This.Type.Guid.ToOptString();
		}
	}

} /* namespace metadata */ 
