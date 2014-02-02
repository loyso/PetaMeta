using System.Windows;
using System.Windows.Controls;

namespace game { 

	public partial class GlobalsLayout : gui.Layout
	{
		private game.Globals This = null;
		
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
			MemberChanged_Value( Globals_Reflection.MetadataClass, This, Globals_Member_name.Member, new string_Boxed { value = This.name } );
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
			This = (game.Globals)dataObject;
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
			TypeLabel.Content = "Globals";
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

} /* namespace game */ 
