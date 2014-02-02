using System.Windows;
using System.Windows.Controls;

namespace game { 

	public partial class GameLayout : gui.Layout
	{
		private game.Game This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
		private game.GlobalsLayout globalsLayout;
		private GroupBox globals;
		private void globals_Changed()
		{
			MemberChanged_Value( Game_Reflection.MetadataClass, This, Game_Member_globals.Member, This.globals );
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private void gui_Changed()
		{
			MemberChanged_Value( Game_Reflection.MetadataClass, This, Game_Member_gui.Member, This.gui );
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private void levels_Changed()
		{
			MemberChanged_Value( Game_Reflection.MetadataClass, This, Game_Member_levels.Member, This.levels );
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
			This = (game.Game)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				DockPanel dockPanel = new DockPanel();
				dockPanel.Children.Add( new Label { Content = "globals" } );
				globals = new GroupBox { Header = dockPanel };
				if ( This.globals != null )
				{
					globalsLayout = gui.Layouts.CreateLayoutFor< game.GlobalsLayout >( This.globals );
					globalsLayout.ParentLayout = this;
					globalsLayout.ObjectChanged += globals_Changed;
			
					
					StackPanel panel = new StackPanel();
					globalsLayout.CreateControls( This.globals, panel.Children );
					globals.Content = panel;
				}
				collection.Add( globals );	
			}
			
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "Game";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			if ( globalsLayout != null )
				globalsLayout.ObjectDataToControls();
		}
	}

} /* namespace game */ 
