using System.Windows;
using System.Windows.Controls;

namespace metadata { 

	public abstract partial class TypeLayout : gui.Layout
	{
		private metadata.Type This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
		private TextBox TypeName;
		private void TypeName_TextChanged(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.TypeName = TypeName.Text;
			TypeName_Changed();	
			NameChanged();
		}

		private void TypeName_Changed()
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
			This = (metadata.Type)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				TypeName = new TextBox();
				TypeName.TextChanged += TypeName_TextChanged;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label{ Content = "TypeName" } );
				panel.Children.Add( TypeName );
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
			TypeLabel.Content = "Type";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			TypeName.Text = This.TypeName;
			Namespace.Text = This.Namespace;
		}
	}

	public partial class TypesCollectionLayout : gui.Layout
	{
		private metadata.TypesCollection This = null;
		
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
			This = (metadata.TypesCollection)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "TypesCollection";
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class MetadataClassLayout : TypeLayout
	{
		private metadata.MetadataClass This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
		private TextBox BaseClass;
		private TextBox BaseClassGuid;
		private void BaseClass_Clicked(object sender, RoutedEventArgs eventArgs )
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
		        , This.BaseClass     
		        , out reference
		    );
			
			if ( result )
			{
				if ( reference == null )
				{
					This.BaseClass = null;
					BaseClass.Text = "[null]";
					BaseClassGuid.Text = "";
				}
				else if ( reference is metadata.MetadataClass )
				{			
					This.BaseClass = (metadata.MetadataClass)reference;
					BaseClass.Text = This.BaseClass == null ? "[null]" : This.BaseClass.TypeName;
					
					BaseClassGuid.Text = This.BaseClass == null ? "" : This.BaseClass.Guid.ToOptString();	
				}		
				BaseClass_Changed();
			}	
		}
		private void BaseClass_Changed()
		{
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private CheckBox IsReferenced;
		private void IsReferenced_Clicked(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
				
			This.IsReferenced = IsReferenced.IsChecked ?? false;
			IsReferenced_Changed();
		}

		private void IsReferenced_Changed()
		{
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private CheckBox HasMinMax;
		private void HasMinMax_Clicked(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
				
			This.HasMinMax = HasMinMax.IsChecked ?? false;
			HasMinMax_Changed();
		}

		private void HasMinMax_Changed()
		{
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private CheckBox UserDefined;
		private void UserDefined_Clicked(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
				
			This.UserDefined = UserDefined.IsChecked ?? false;
			UserDefined_Changed();
		}

		private void UserDefined_Changed()
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
			This = (metadata.MetadataClass)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				DockPanel panel = new DockPanel();
				BaseClass = new TextBox { IsReadOnly = true };
				BaseClassGuid = new TextBox { IsReadOnly = true };
				panel.Children.Add( new Label{ Content = "BaseClass" } );
				Button button = new Button{ Content = "Browse..." };
				button.Click += BaseClass_Clicked;
				panel.Children.Add( button );
				panel.Children.Add( BaseClass );
				panel.Children.Add( BaseClassGuid );
				collection.Add( panel );
			}

			{
				IsReferenced = new CheckBox { VerticalAlignment = VerticalAlignment.Center };
				IsReferenced.Click += IsReferenced_Clicked;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label { Content = "IsReferenced" } );
				panel.Children.Add( IsReferenced );
				collection.Add( panel );
			}

			{
				HasMinMax = new CheckBox { VerticalAlignment = VerticalAlignment.Center };
				HasMinMax.Click += HasMinMax_Clicked;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label { Content = "HasMinMax" } );
				panel.Children.Add( HasMinMax );
				collection.Add( panel );
			}

			{
				UserDefined = new CheckBox { VerticalAlignment = VerticalAlignment.Center };
				UserDefined.Click += UserDefined_Clicked;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label { Content = "UserDefined" } );
				panel.Children.Add( UserDefined );
				collection.Add( panel );
			}

		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "MetadataClass";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			BaseClass.Text = This.BaseClass == null ? "[null]" : This.BaseClass.TypeName;
			BaseClassGuid.Text = This.BaseClass == null ? "" : This.BaseClass.Guid.ToOptString();
			IsReferenced.IsChecked = This.IsReferenced;
			HasMinMax.IsChecked = This.HasMinMax;
			UserDefined.IsChecked = This.UserDefined;
		}
	}

	public partial class AbstractClassLayout : MetadataClassLayout
	{
		private metadata.AbstractClass This = null;
		
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
			This = (metadata.AbstractClass)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "AbstractClass";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class CollectionClassLayout : MetadataClassLayout
	{
		private metadata.CollectionClass This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
		private TextBox ItemsClass;
		private TextBox ItemsClassGuid;
		private void ItemsClass_Clicked(object sender, RoutedEventArgs eventArgs )
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
		        , This.ItemsClass     
		        , out reference
		    );
			
			if ( result )
			{
				if ( reference == null )
				{
					This.ItemsClass = null;
					ItemsClass.Text = "[null]";
					ItemsClassGuid.Text = "";
				}
				else if ( reference is metadata.MetadataClass )
				{			
					This.ItemsClass = (metadata.MetadataClass)reference;
					ItemsClass.Text = This.ItemsClass == null ? "[null]" : This.ItemsClass.TypeName;
					
					ItemsClassGuid.Text = This.ItemsClass == null ? "" : This.ItemsClass.Guid.ToOptString();	
				}		
				ItemsClass_Changed();
			}	
		}
		private void ItemsClass_Changed()
		{
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private CheckBox IsPolymorphic;
		private void IsPolymorphic_Clicked(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
				
			This.IsPolymorphic = IsPolymorphic.IsChecked ?? false;
			IsPolymorphic_Changed();
		}

		private void IsPolymorphic_Changed()
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
			This = (metadata.CollectionClass)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				DockPanel panel = new DockPanel();
				ItemsClass = new TextBox { IsReadOnly = true };
				ItemsClassGuid = new TextBox { IsReadOnly = true };
				panel.Children.Add( new Label{ Content = "ItemsClass" } );
				Button button = new Button{ Content = "Browse..." };
				button.Click += ItemsClass_Clicked;
				panel.Children.Add( button );
				panel.Children.Add( ItemsClass );
				panel.Children.Add( ItemsClassGuid );
				collection.Add( panel );
			}

			{
				IsPolymorphic = new CheckBox { VerticalAlignment = VerticalAlignment.Center };
				IsPolymorphic.Click += IsPolymorphic_Clicked;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label { Content = "IsPolymorphic" } );
				panel.Children.Add( IsPolymorphic );
				collection.Add( panel );
			}

		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "CollectionClass";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			ItemsClass.Text = This.ItemsClass == null ? "[null]" : This.ItemsClass.TypeName;
			ItemsClassGuid.Text = This.ItemsClass == null ? "" : This.ItemsClass.Guid.ToOptString();
			IsPolymorphic.IsChecked = This.IsPolymorphic;
		}
	}

	public partial class FileClassLayout : MetadataClassLayout
	{
		private metadata.FileClass This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
		private TextBox FileExtension;
		private void FileExtension_TextChanged(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.FileExtension = FileExtension.Text;
			FileExtension_Changed();	
		}

		private void FileExtension_Changed()
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
			This = (metadata.FileClass)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				FileExtension = new TextBox();
				FileExtension.TextChanged += FileExtension_TextChanged;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label{ Content = "FileExtension" } );
				panel.Children.Add( FileExtension );
				collection.Add( panel );
			}

		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "FileClass";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			FileExtension.Text = This.FileExtension;
		}
	}

	public partial class FolderClassLayout : MetadataClassLayout
	{
		private metadata.FolderClass This = null;
		
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
			This = (metadata.FolderClass)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "FolderClass";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class FolderStorageClassLayout : FolderClassLayout
	{
		private metadata.FolderStorageClass This = null;
		
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
			This = (metadata.FolderStorageClass)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "FolderStorageClass";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class ProjectClassLayout : MetadataClassLayout
	{
		private metadata.ProjectClass This = null;
		
		private Label TypeLabel;
		private TextBox FileExtension;
		private void FileExtension_TextChanged(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.FileExtension = FileExtension.Text;
			FileExtension_Changed();	
		}

		private void FileExtension_Changed()
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
			This = (metadata.ProjectClass)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				FileExtension = new TextBox();
				FileExtension.TextChanged += FileExtension_TextChanged;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label{ Content = "FileExtension" } );
				panel.Children.Add( FileExtension );
				collection.Add( panel );
			}

		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "ProjectClass";
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			FileExtension.Text = This.FileExtension;
		}
	}

	public partial class MetadataFileContentLayout : gui.Layout
	{
		private metadata.MetadataFileContent This = null;
		
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
			This = (metadata.MetadataFileContent)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "MetadataFileContent";
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public abstract partial class MemberLayout : gui.Layout
	{
		private metadata.Member This = null;
		
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
		private TextBox Group;
		private TextBox GroupGuid;
		private void Group_Clicked(object sender, RoutedEventArgs eventArgs )
		{
			core.DataObject reference = null;
		
			bool result = BrowseClicked( typeof(metadata.MetadataMemberGroup)
				, "MetadataMemberGroup"
			    , ( dataObject ) => 
			    { 
					// substitute
					if ( dataObject is metadata.MetadataMemberGroup ) return true;
					// aggregate
					if ( dataObject is metadata.MemberGroupsCollection ) return true;
					if ( dataObject is metadata.MetadataProject ) return true;
			    	return false;
		        }   
		        , This.Group     
		        , out reference
		    );
			
			if ( result )
			{
				if ( reference == null )
				{
					This.Group = null;
					Group.Text = "[null]";
					GroupGuid.Text = "";
				}
				else if ( reference is metadata.MetadataMemberGroup )
				{			
					This.Group = (metadata.MetadataMemberGroup)reference;
					Group.Text = This.Group == null ? "[null]" : This.Group.Name;
					
					GroupGuid.Text = This.Group == null ? "" : This.Group.Guid.ToOptString();	
				}		
				Group_Changed();
			}	
		}
		private void Group_Changed()
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
			This = (metadata.Member)dataObject;
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
				DockPanel panel = new DockPanel();
				Group = new TextBox { IsReadOnly = true };
				GroupGuid = new TextBox { IsReadOnly = true };
				panel.Children.Add( new Label{ Content = "Group" } );
				Button button = new Button{ Content = "Browse..." };
				button.Click += Group_Clicked;
				panel.Children.Add( button );
				panel.Children.Add( Group );
				panel.Children.Add( GroupGuid );
				collection.Add( panel );
			}

		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "Member";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			Name.Text = This.Name;
			Group.Text = This.Group == null ? "[null]" : This.Group.Name;
			GroupGuid.Text = This.Group == null ? "" : This.Group.Guid.ToOptString();
		}
	}

	public partial class MembersCollectionLayout : gui.Layout
	{
		private metadata.MembersCollection This = null;
		
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
			This = (metadata.MembersCollection)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "MembersCollection";
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class ValueLayout : MemberLayout
	{
		private metadata.Value This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
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
		private CheckBox IsXmlAttr;
		private void IsXmlAttr_Clicked(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
				
			This.IsXmlAttr = IsXmlAttr.IsChecked ?? false;
			IsXmlAttr_Changed();
		}

		private void IsXmlAttr_Changed()
		{
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private CheckBox IsPolymorphic;
		private void IsPolymorphic_Clicked(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
				
			This.IsPolymorphic = IsPolymorphic.IsChecked ?? false;
			IsPolymorphic_Changed();
		}

		private void IsPolymorphic_Changed()
		{
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private TextBox DefaultValue;
		private void DefaultValue_TextChanged(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.DefaultValue = DefaultValue.Text;
			DefaultValue_Changed();	
		}

		private void DefaultValue_Changed()
		{
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private TextBox DefaultValueXml;
		private void DefaultValueXml_TextChanged(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.DefaultValueXml = DefaultValueXml.Text;
			DefaultValueXml_Changed();	
		}

		private void DefaultValueXml_Changed()
		{
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private TextBox Min;
		private void Min_TextChanged(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.Min = Min.Text;
			Min_Changed();	
		}

		private void Min_Changed()
		{
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private TextBox Max;
		private void Max_TextChanged(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.Max = Max.Text;
			Max_Changed();	
		}

		private void Max_Changed()
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
			This = (metadata.Value)dataObject;
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

			{
				IsXmlAttr = new CheckBox { VerticalAlignment = VerticalAlignment.Center };
				IsXmlAttr.Click += IsXmlAttr_Clicked;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label { Content = "IsXmlAttr" } );
				panel.Children.Add( IsXmlAttr );
				collection.Add( panel );
			}

			{
				IsPolymorphic = new CheckBox { VerticalAlignment = VerticalAlignment.Center };
				IsPolymorphic.Click += IsPolymorphic_Clicked;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label { Content = "IsPolymorphic" } );
				panel.Children.Add( IsPolymorphic );
				collection.Add( panel );
			}

			{
				DefaultValue = new TextBox();
				DefaultValue.TextChanged += DefaultValue_TextChanged;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label{ Content = "DefaultValue" } );
				panel.Children.Add( DefaultValue );
				collection.Add( panel );
			}

			{
				DefaultValueXml = new TextBox();
				DefaultValueXml.TextChanged += DefaultValueXml_TextChanged;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label{ Content = "DefaultValueXml" } );
				panel.Children.Add( DefaultValueXml );
				collection.Add( panel );
			}

			{
				Min = new TextBox();
				Min.TextChanged += Min_TextChanged;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label{ Content = "Min" } );
				panel.Children.Add( Min );
				collection.Add( panel );
			}

			{
				Max = new TextBox();
				Max.TextChanged += Max_TextChanged;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label{ Content = "Max" } );
				panel.Children.Add( Max );
				collection.Add( panel );
			}

		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "Value";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			Type.Text = This.Type == null ? "[null]" : This.Type.TypeName;
			TypeGuid.Text = This.Type == null ? "" : This.Type.Guid.ToOptString();
			IsXmlAttr.IsChecked = This.IsXmlAttr;
			IsPolymorphic.IsChecked = This.IsPolymorphic;
			DefaultValue.Text = This.DefaultValue;
			DefaultValueXml.Text = This.DefaultValueXml;
			Min.Text = This.Min;
			Max.Text = This.Max;
		}
	}

	public partial class ValueNameLayout : ValueLayout
	{
		private metadata.ValueName This = null;
		
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
			This = (metadata.ValueName)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "ValueName";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class ReferenceLayout : MemberLayout
	{
		private metadata.Reference This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
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
		private CheckBox IsXmlAttr;
		private void IsXmlAttr_Clicked(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
				
			This.IsXmlAttr = IsXmlAttr.IsChecked ?? false;
			IsXmlAttr_Changed();
		}

		private void IsXmlAttr_Changed()
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
			This = (metadata.Reference)dataObject;
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

			{
				IsXmlAttr = new CheckBox { VerticalAlignment = VerticalAlignment.Center };
				IsXmlAttr.Click += IsXmlAttr_Clicked;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label { Content = "IsXmlAttr" } );
				panel.Children.Add( IsXmlAttr );
				collection.Add( panel );
			}

		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "Reference";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			Type.Text = This.Type == null ? "[null]" : This.Type.TypeName;
			TypeGuid.Text = This.Type == null ? "" : This.Type.Guid.ToOptString();
			IsXmlAttr.IsChecked = This.IsXmlAttr;
		}
	}

	public partial class ParentReferenceLayout : MemberLayout
	{
		private metadata.ParentReference This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
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
			{
				GuidLabel = new Label();
				collection.Add( GuidLabel );
			}
			CreateControls_Base( dataObject, collection );
		}
		protected override void CreateControls_Base ( core.DataObject dataObject, UIElementCollection collection )
		{
			This = (metadata.ParentReference)dataObject;
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
			TypeLabel.Content = "ParentReference";
			GuidLabel.Content = This.Guid.ToString();
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

	public partial class CollectionLayout : MemberLayout
	{
		private metadata.Collection This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
		private TextBox Type;
		private TextBox TypeGuid;
		private void Type_Clicked(object sender, RoutedEventArgs eventArgs )
		{
			core.DataObject reference = null;
		
			bool result = BrowseClicked( typeof(metadata.CollectionClass)
				, "CollectionClass"
			    , ( dataObject ) => 
			    { 
					// substitute
					if ( dataObject is metadata.CollectionClass ) return true;
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
				else if ( reference is metadata.CollectionClass )
				{			
					This.Type = (metadata.CollectionClass)reference;
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
			{
				GuidLabel = new Label();
				collection.Add( GuidLabel );
			}
			CreateControls_Base( dataObject, collection );
		}
		protected override void CreateControls_Base ( core.DataObject dataObject, UIElementCollection collection )
		{
			This = (metadata.Collection)dataObject;
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
			TypeLabel.Content = "Collection";
			GuidLabel.Content = This.Guid.ToString();
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

	public partial class FileStorageLayout : MemberLayout
	{
		private metadata.FileStorage This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
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
			{
				GuidLabel = new Label();
				collection.Add( GuidLabel );
			}
			CreateControls_Base( dataObject, collection );
		}
		protected override void CreateControls_Base ( core.DataObject dataObject, UIElementCollection collection )
		{
			This = (metadata.FileStorage)dataObject;
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
			TypeLabel.Content = "FileStorage";
			GuidLabel.Content = This.Guid.ToString();
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
