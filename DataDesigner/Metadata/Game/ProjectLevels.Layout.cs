using System.Windows;
using System.Windows.Controls;

namespace level { 

	public partial class LevelsLayout : gui.Layout
	{
		private level.Levels This = null;
		
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
			This = (level.Levels)dataObject;
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
			TypeLabel.Content = "Levels";
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

	public partial class LevelFolderLayout : gui.Layout
	{
		private level.LevelFolder This = null;
		
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
			MemberChanged_Value( LevelFolder_Reflection.MetadataClass, This, LevelFolder_Member_name.Member, new string_Boxed { value = This.name } );
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
			This = (level.LevelFolder)dataObject;
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
			TypeLabel.Content = "LevelFolder";
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

	public partial class LevelFoldersCollectionLayout : gui.Layout
	{
		private level.LevelFoldersCollection This = null;
		
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
			This = (level.LevelFoldersCollection)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "LevelFoldersCollection";
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class LevelBlockLayout : gui.Layout
	{
		private level.LevelBlock This = null;
		
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
			This = (level.LevelBlock)dataObject;
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
			TypeLabel.Content = "LevelBlock";
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

	public partial class LevelBlocksCollectionLayout : gui.Layout
	{
		private level.LevelBlocksCollection This = null;
		
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
			This = (level.LevelBlocksCollection)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "LevelBlocksCollection";
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class LevelFileLayout : gui.Layout
	{
		private level.LevelFile This = null;
		
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
			This = (level.LevelFile)dataObject;
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
			TypeLabel.Content = "LevelFile";
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

	public partial class LevelFilesCollectionLayout : gui.Layout
	{
		private level.LevelFilesCollection This = null;
		
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
			This = (level.LevelFilesCollection)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "LevelFilesCollection";
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class DependencyLayout : gui.Layout
	{
		private level.Dependency This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
		private TextBox LevelFolder;
		private TextBox LevelFolderGuid;
		private void LevelFolder_Clicked(object sender, RoutedEventArgs eventArgs )
		{
			core.DataObject reference = null;
		
			bool result = BrowseClicked( typeof(level.LevelFolder)
				, "LevelFolder"
			    , ( dataObject ) => 
			    { 
					// substitute
					if ( dataObject is level.LevelFolder ) return true;
					// aggregate
					if ( dataObject is game.Game ) return true;
					if ( dataObject is level.Levels ) return true;
					if ( dataObject is level.LevelFoldersCollection ) return true;
			    	return false;
		        }   
		        , This.LevelFolder     
		        , out reference
		    );
			
			if ( result )
			{
				if ( reference == null )
				{
					This.LevelFolder = null;
					LevelFolder.Text = "[null]";
					LevelFolderGuid.Text = "";
				}
				else if ( reference is level.LevelFolder )
				{			
					This.LevelFolder = (level.LevelFolder)reference;
					LevelFolder.Text = This.LevelFolder == null ? "[null]" : This.LevelFolder.name;
					
					LevelFolderGuid.Text = This.LevelFolder == null ? "" : This.LevelFolder.Guid.ToOptString();	
				}		
				LevelFolder_Changed();
			}	
		}
		private void LevelFolder_Changed()
		{
			MemberChanged_Reference( Dependency_Reflection.MetadataClass, This, Dependency_Member_LevelFolder.Member, This.LevelFolder );
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
			This = (level.Dependency)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				DockPanel panel = new DockPanel();
				LevelFolder = new TextBox { IsReadOnly = true };
				LevelFolderGuid = new TextBox { IsReadOnly = true };
				panel.Children.Add( new Label{ Content = "LevelFolder" } );
				Button button = new Button{ Content = "Browse..." };
				button.Click += LevelFolder_Clicked;
				panel.Children.Add( button );
				panel.Children.Add( LevelFolder );
				panel.Children.Add( LevelFolderGuid );
				collection.Add( panel );
			}

		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "Dependency";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			LevelFolder.Text = This.LevelFolder == null ? "[null]" : This.LevelFolder.name;
			LevelFolderGuid.Text = This.LevelFolder == null ? "" : This.LevelFolder.Guid.ToOptString();
		}
	}

	public partial class DependenciesLayout : gui.Layout
	{
		private level.Dependencies This = null;
		
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
			This = (level.Dependencies)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "Dependencies";
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

} /* namespace level */ 
