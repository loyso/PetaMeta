using System.Windows;
using System.Windows.Controls;

namespace metadata { 

	public partial class MetadataFileLayout : gui.Layout
	{
		private metadata.MetadataFile This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
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
		private TextBox Namespace;
		private void Namespace_TextChanged(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.Namespace = Namespace.Text;
			Namespace_Changed();	
		}

		private void Namespace_Changed()
		{
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private CheckBox GenerateGui;
		private void GenerateGui_Clicked(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
				
			This.GenerateGui = GenerateGui.IsChecked ?? false;
			GenerateGui_Changed();
		}

		private void GenerateGui_Changed()
		{
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private CheckBox GenerateSerialization;
		private void GenerateSerialization_Clicked(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
				
			This.GenerateSerialization = GenerateSerialization.IsChecked ?? false;
			GenerateSerialization_Changed();
		}

		private void GenerateSerialization_Changed()
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
			This = (metadata.MetadataFile)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				Name = new TextBox();
				Name.TextChanged += Name_TextChanged;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label{ Content = "Name" } );
				panel.Children.Add( Name );
				collection.Add( panel );
			}

			{
				Namespace = new TextBox();
				Namespace.TextChanged += Namespace_TextChanged;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label{ Content = "Namespace" } );
				panel.Children.Add( Namespace );
				collection.Add( panel );
			}

			{
				GenerateGui = new CheckBox { VerticalAlignment = VerticalAlignment.Center };
				GenerateGui.Click += GenerateGui_Clicked;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label { Content = "GenerateGui" } );
				panel.Children.Add( GenerateGui );
				collection.Add( panel );
			}

			{
				GenerateSerialization = new CheckBox { VerticalAlignment = VerticalAlignment.Center };
				GenerateSerialization.Click += GenerateSerialization_Clicked;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label { Content = "GenerateSerialization" } );
				panel.Children.Add( GenerateSerialization );
				collection.Add( panel );
			}

		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "MetadataFile";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			Name.Text = This.Name;
			Namespace.Text = This.Namespace;
			GenerateGui.IsChecked = This.GenerateGui;
			GenerateSerialization.IsChecked = This.GenerateSerialization;
		}
	}

	public partial class MetadataFilesCollectionLayout : gui.Layout
	{
		private metadata.MetadataFilesCollection This = null;
		
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
			This = (metadata.MetadataFilesCollection)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "MetadataFilesCollection";
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class MetadataFolderLayout : gui.Layout
	{
		private metadata.MetadataFolder This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
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
		private TextBox Namespace;
		private void Namespace_TextChanged(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.Namespace = Namespace.Text;
			Namespace_Changed();	
		}

		private void Namespace_Changed()
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
			This = (metadata.MetadataFolder)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				Name = new TextBox();
				Name.TextChanged += Name_TextChanged;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label{ Content = "Name" } );
				panel.Children.Add( Name );
				collection.Add( panel );
			}

			{
				Namespace = new TextBox();
				Namespace.TextChanged += Namespace_TextChanged;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label{ Content = "Namespace" } );
				panel.Children.Add( Namespace );
				collection.Add( panel );
			}

		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "MetadataFolder";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			Name.Text = This.Name;
			Namespace.Text = This.Namespace;
		}
	}

	public partial class MetadataFoldersCollectionLayout : gui.Layout
	{
		private metadata.MetadataFoldersCollection This = null;
		
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
			This = (metadata.MetadataFoldersCollection)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "MetadataFoldersCollection";
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class MetadataMemberGroupLayout : gui.Layout
	{
		private metadata.MetadataMemberGroup This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
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
		private TextBox PartialFileExtension;
		private void PartialFileExtension_TextChanged(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.PartialFileExtension = PartialFileExtension.Text;
			PartialFileExtension_Changed();	
		}

		private void PartialFileExtension_Changed()
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
			This = (metadata.MetadataMemberGroup)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				Name = new TextBox();
				Name.TextChanged += Name_TextChanged;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label{ Content = "Name" } );
				panel.Children.Add( Name );
				collection.Add( panel );
			}

			{
				PartialFileExtension = new TextBox();
				PartialFileExtension.TextChanged += PartialFileExtension_TextChanged;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label{ Content = "PartialFileExtension" } );
				panel.Children.Add( PartialFileExtension );
				collection.Add( panel );
			}

		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "MetadataMemberGroup";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			Name.Text = This.Name;
			PartialFileExtension.Text = This.PartialFileExtension;
		}
	}

	public partial class MemberGroupsCollectionLayout : gui.Layout
	{
		private metadata.MemberGroupsCollection This = null;
		
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
			This = (metadata.MemberGroupsCollection)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "MemberGroupsCollection";
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class MetadataProjectLayout : gui.Layout
	{
		private metadata.MetadataProject This = null;
		
		private Label TypeLabel;
		private TextBox CoreNamespace;
		private void CoreNamespace_TextChanged(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.CoreNamespace = CoreNamespace.Text;
			CoreNamespace_Changed();	
		}

		private void CoreNamespace_Changed()
		{
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private void Metadata_Changed()
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
			This = (metadata.MetadataProject)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				CoreNamespace = new TextBox();
				CoreNamespace.TextChanged += CoreNamespace_TextChanged;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label{ Content = "CoreNamespace" } );
				panel.Children.Add( CoreNamespace );
				collection.Add( panel );
			}

		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "MetadataProject";
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			CoreNamespace.Text = This.CoreNamespace;
		}
	}

} /* namespace metadata */ 
