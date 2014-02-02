using System.Windows;
using System.Windows.Controls;

namespace scene { 

	public partial class SceneObjectLayout : gui.Layout
	{
		private scene.SceneObject This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
		private Vec3Layout positionLayout;
		private GroupBox position;
		private void position_Changed()
		{
			MemberChanged_Value( SceneObject_Reflection.MetadataClass, This, SceneObject_Member_position.Member, This.position );
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private Slider scale = null;
		private TextBox scale_TextBox;
		private void scale_ValueChanged(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.scale = (float)scale.Value;
			scale_TextBox.Text = This.scale.ToString();
			scale_Changed();
		}
		private void scale_LostKeyboardFocus( object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e )
		{
			if ( IsObjectDataToControls )
				return;
		
			bool error = false;
			try
			{
				This.scale = (float)System.Convert.ToSingle(scale_TextBox.Text);
				if ( This.scale < 0.1f ) { This.scale = 0.1f; error = true; }
				if ( This.scale > 100.0f ) { This.scale = 100.0f; error = true; }
			}
			catch ( System.FormatException ) { error = true; }
			catch ( System.OverflowException ) { error = true; }
		
			if ( error )
				scale_TextBox.Text = This.scale.ToString();
			else
				scale_Changed();
			
			if ( scale != null )
				scale.Value = This.scale;
		}

		private void scale_Changed()
		{
			MemberChanged_Value( SceneObject_Reflection.MetadataClass, This, SceneObject_Member_scale.Member, new float_Boxed { value = This.scale } );
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private ColorLayout colorLayout;
		private GroupBox color;
		private void color_Changed()
		{
			MemberChanged_Value( SceneObject_Reflection.MetadataClass, This, SceneObject_Member_color.Member, This.color );
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private Slider lod = null;
		private TextBox lod_TextBox;
		private void lod_ValueChanged(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.lod = (int)lod.Value;
			lod_TextBox.Text = This.lod.ToString();
			lod_Changed();
		}
		private void lod_LostKeyboardFocus( object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e )
		{
			if ( IsObjectDataToControls )
				return;
		
			bool error = false;
			try
			{
				This.lod = (int)System.Convert.ToInt32(lod_TextBox.Text);
				if ( This.lod < 1 ) { This.lod = 1; error = true; }
				if ( This.lod > 3 ) { This.lod = 3; error = true; }
			}
			catch ( System.FormatException ) { error = true; }
			catch ( System.OverflowException ) { error = true; }
		
			if ( error )
				lod_TextBox.Text = This.lod.ToString();
			else
				lod_Changed();
				
			if ( lod != null )
				lod.Value = This.lod;
		}

		private void lod_Changed()
		{
			MemberChanged_Value( SceneObject_Reflection.MetadataClass, This, SceneObject_Member_lod.Member, new int_Boxed { value = This.lod } );
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private CheckBox visible;
		private void visible_Clicked(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
				
			This.visible = visible.IsChecked ?? false;
			visible_Changed();
		}

		private void visible_Changed()
		{
			MemberChanged_Value( SceneObject_Reflection.MetadataClass, This, SceneObject_Member_visible.Member, new bool_Boxed { value = This.visible } );
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private TextBox next;
		private TextBox nextGuid;
		private void next_Clicked(object sender, RoutedEventArgs eventArgs )
		{
			core.DataObject reference = null;
		
			bool result = BrowseClicked( typeof(scene.SceneObject)
				, "SceneObject"
			    , ( dataObject ) => 
			    { 
					// substitute
					if ( dataObject is scene.SceneObject ) return true;
					if ( dataObject is scene.SceneMesh ) return true;
					if ( dataObject is scene.SceneAnimMesh ) return true;
					if ( dataObject is scene.SceneZoneTrigger ) return true;
					// aggregate
					if ( dataObject is game.Game ) return true;
					if ( dataObject is level.Levels ) return true;
					if ( dataObject is level.LevelFolder ) return true;
					if ( dataObject is level.LevelFoldersCollection ) return true;
					if ( dataObject is level.LevelBlock ) return true;
					if ( dataObject is level.LevelBlocksCollection ) return true;
					if ( dataObject is level.LevelFile ) return true;
					if ( dataObject is level.LevelFilesCollection ) return true;
					if ( dataObject is scene.SceneObjectsCollection ) return true;
					if ( dataObject is scene.Scene ) return true;
			    	return false;
		        }   
		        , This.next     
		        , out reference
		    );
			
			if ( result )
			{
				if ( reference == null )
				{
					This.next = null;
					next.Text = "[null]";
					nextGuid.Text = "";
				}
				else if ( reference is scene.SceneObject )
				{			
					This.next = (scene.SceneObject)reference;
					next.Text = This.next == null ? "[null]" : This.next.GetType().Name;
					
					nextGuid.Text = This.next == null ? "" : This.next.Guid.ToOptString();	
				}		
				next_Changed();
			}	
		}
		private void next_Changed()
		{
			MemberChanged_Reference( SceneObject_Reflection.MetadataClass, This, SceneObject_Member_next.Member, This.next );
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private CheckBox isSoundEnabled;
		private void isSoundEnabled_Clicked(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
				
			This.isSoundEnabled = isSoundEnabled.IsChecked ?? false;
			isSoundEnabled_Changed();
		}

		private void isSoundEnabled_Changed()
		{
			MemberChanged_Value( SceneObject_Reflection.MetadataClass, This, SceneObject_Member_isSoundEnabled.Member, new bool_Boxed { value = This.isSoundEnabled } );
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private CheckBox isSfxEnabled;
		private void isSfxEnabled_Clicked(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
				
			This.isSfxEnabled = isSfxEnabled.IsChecked ?? false;
			isSfxEnabled_Changed();
		}

		private void isSfxEnabled_Changed()
		{
			MemberChanged_Value( SceneObject_Reflection.MetadataClass, This, SceneObject_Member_isSfxEnabled.Member, new bool_Boxed { value = This.isSfxEnabled } );
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
			This = (scene.SceneObject)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				DockPanel dockPanel = new DockPanel();
				dockPanel.Children.Add( new Label { Content = "position" } );
				position = new GroupBox { Header = dockPanel };
				if ( This.position != null )
				{
					positionLayout = gui.Layouts.CreateLayoutFor< Vec3Layout >( This.position );
					positionLayout.ParentLayout = this;
					positionLayout.ObjectChanged += position_Changed;
			
					
					StackPanel panel = new StackPanel();
					positionLayout.CreateControls( This.position, panel.Children );
					position.Content = panel;
				}
				collection.Add( position );	
			}
			
			{
				scale_TextBox = new TextBox { MinWidth = 64 };
				scale_TextBox.LostKeyboardFocus += scale_LostKeyboardFocus;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label { Content = "scale" } );	
				panel.Children.Add( scale_TextBox );
				scale = new Slider();
				panel.Children.Add( scale );
				scale.Minimum = 0.1f;
				scale.Maximum = 100.0f;
				scale.ValueChanged += scale_ValueChanged; // must be the last
					
				collection.Add( panel );
			}

			{
				DockPanel dockPanel = new DockPanel();
				dockPanel.Children.Add( new Label { Content = "color" } );
				color = new GroupBox { Header = dockPanel };
				if ( This.color != null )
				{
					colorLayout = gui.Layouts.CreateLayoutFor< ColorLayout >( This.color );
					colorLayout.ParentLayout = this;
					colorLayout.ObjectChanged += color_Changed;
			
					
					StackPanel panel = new StackPanel();
					colorLayout.CreateControls( This.color, panel.Children );
					color.Content = panel;
				}
				collection.Add( color );	
			}
			
			{
				lod_TextBox = new TextBox { MinWidth = 64 };
				lod_TextBox.LostKeyboardFocus += lod_LostKeyboardFocus;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label { Content = "lod" } );	
				panel.Children.Add( lod_TextBox );
				lod = new Slider(); 
				panel.Children.Add( lod );
				lod.Minimum = 1;
				lod.Maximum = 3;
				lod.IsSnapToTickEnabled = true;
				lod.TickPlacement = System.Windows.Controls.Primitives.TickPlacement.BottomRight;
				lod.TickFrequency = 1;
				lod.ValueChanged += lod_ValueChanged; // must be the last
					
				collection.Add( panel );
			}

			{
				visible = new CheckBox { VerticalAlignment = VerticalAlignment.Center };
				visible.Click += visible_Clicked;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label { Content = "visible" } );
				panel.Children.Add( visible );
				collection.Add( panel );
			}

			{
				DockPanel panel = new DockPanel();
				next = new TextBox { IsReadOnly = true };
				nextGuid = new TextBox { IsReadOnly = true };
				panel.Children.Add( new Label{ Content = "next" } );
				Button button = new Button{ Content = "Browse..." };
				button.Click += next_Clicked;
				panel.Children.Add( button );
				panel.Children.Add( next );
				panel.Children.Add( nextGuid );
				collection.Add( panel );
			}

			{
				isSoundEnabled = new CheckBox { VerticalAlignment = VerticalAlignment.Center };
				isSoundEnabled.Click += isSoundEnabled_Clicked;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label { Content = "isSoundEnabled" } );
				panel.Children.Add( isSoundEnabled );
				collection.Add( panel );
			}

			{
				isSfxEnabled = new CheckBox { VerticalAlignment = VerticalAlignment.Center };
				isSfxEnabled.Click += isSfxEnabled_Clicked;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label { Content = "isSfxEnabled" } );
				panel.Children.Add( isSfxEnabled );
				collection.Add( panel );
			}

		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "SceneObject";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			if ( positionLayout != null )
				positionLayout.ObjectDataToControls();
			if ( scale != null )
				scale.Value = This.scale;
			scale_TextBox.Text = This.scale.ToString();
			if ( colorLayout != null )
				colorLayout.ObjectDataToControls();
			if ( lod != null )
				lod.Value = This.lod;
			lod_TextBox.Text = This.lod.ToString();
			visible.IsChecked = This.visible;
			next.Text = This.next == null ? "[null]" : This.next.GetType().Name;
			nextGuid.Text = This.next == null ? "" : This.next.Guid.ToOptString();
			isSoundEnabled.IsChecked = This.isSoundEnabled;
			isSfxEnabled.IsChecked = This.isSfxEnabled;
		}
	}

	public partial class SceneObjectsCollectionLayout : gui.Layout
	{
		private scene.SceneObjectsCollection This = null;
		
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
			This = (scene.SceneObjectsCollection)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "SceneObjectsCollection";
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class SceneMeshLayout : SceneObjectLayout
	{
		private scene.SceneMesh This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
		private ColorLayout colorSndLayout;
		private GroupBox colorSnd;
		private void colorSnd_Changed()
		{
			MemberChanged_Value( SceneMesh_Reflection.MetadataClass, This, SceneMesh_Member_colorSnd.Member, This.colorSnd );
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
			This = (scene.SceneMesh)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				DockPanel dockPanel = new DockPanel();
				dockPanel.Children.Add( new Label { Content = "colorSnd" } );
				colorSnd = new GroupBox { Header = dockPanel };
				if ( This.colorSnd != null )
				{
					colorSndLayout = gui.Layouts.CreateLayoutFor< ColorLayout >( This.colorSnd );
					colorSndLayout.ParentLayout = this;
					colorSndLayout.ObjectChanged += colorSnd_Changed;
			
					
					StackPanel panel = new StackPanel();
					colorSndLayout.CreateControls( This.colorSnd, panel.Children );
					colorSnd.Content = panel;
				}
				collection.Add( colorSnd );	
			}
			
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "SceneMesh";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			if ( colorSndLayout != null )
				colorSndLayout.ObjectDataToControls();
		}
	}

	public partial class SceneAnimMeshLayout : SceneMeshLayout
	{
		private scene.SceneAnimMesh This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
		private Vec3Layout positionSfxLayout;
		private GroupBox positionSfx;
		private void positionSfx_Changed()
		{
			MemberChanged_Value( SceneAnimMesh_Reflection.MetadataClass, This, SceneAnimMesh_Member_positionSfx.Member, This.positionSfx );
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
			This = (scene.SceneAnimMesh)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				DockPanel dockPanel = new DockPanel();
				dockPanel.Children.Add( new Label { Content = "positionSfx" } );
				positionSfx = new GroupBox { Header = dockPanel };
				if ( This.positionSfx != null )
				{
					positionSfxLayout = gui.Layouts.CreateLayoutFor< Vec3Layout >( This.positionSfx );
					positionSfxLayout.ParentLayout = this;
					positionSfxLayout.ObjectChanged += positionSfx_Changed;
			
					positionSfxLayout.SetMinMax( new Vec3 { x=1.0f, y=1.0f, z=1.0f }, new Vec3 { x=2.0f, y=2.0f, z=2.0f } );
					
					StackPanel panel = new StackPanel();
					positionSfxLayout.CreateControls( This.positionSfx, panel.Children );
					positionSfx.Content = panel;
				}
				collection.Add( positionSfx );	
			}
			
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "SceneAnimMesh";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			if ( positionSfxLayout != null )
				positionSfxLayout.ObjectDataToControls();
		}
	}

	public partial class SceneZoneTriggerLayout : SceneObjectLayout
	{
		private scene.SceneZoneTrigger This = null;
		
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
			MemberChanged_Value( SceneZoneTrigger_Reflection.MetadataClass, This, SceneZoneTrigger_Member_name.Member, new string_Boxed { value = This.name } );
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private RadioButton triggerType_Projectile;
		private void triggerType_Projectile_Checked(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.triggerType = scene.TriggerType.Projectile;
			triggerType_Changed();	
		}
		private RadioButton triggerType_Character;
		private void triggerType_Character_Checked(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.triggerType = scene.TriggerType.Character;
			triggerType_Changed();	
		}
		private void triggerType_Changed()
		{
			MemberChanged_Value( SceneZoneTrigger_Reflection.MetadataClass, This, SceneZoneTrigger_Member_triggerType.Member, new scene.TriggerType_Boxed { value = This.triggerType } );
			if ( ObjectChanged != null )
				ObjectChanged();
		}
		private scene.ControllerLayout ctrlLayout;
		private GroupBox ctrl;
		private ComboBox ctrlComboBox;
		void ctrl_SelectionChanged( object sender, SelectionChangedEventArgs args )
		{
			switch ( ctrlComboBox.SelectedIndex )
			{
			case 0:
				This.ctrl = null;
				ctrlLayout = null;
				ctrl.Content = null;
				break;
			case 1:
				{
					scene.Controller deletedObject = This.ctrl;
					This.ctrl = new scene.ControllerBox();
					ctrlLayout = gui.Layouts.CreateLayoutFor< scene.ControllerLayout >( This.ctrl );
					ctrlLayout.ParentLayout = this;
					ctrlLayout.ObjectChanged += ctrl_Changed;
					StackPanel panel = new StackPanel();
					ctrlLayout.CreateControls( This.ctrl, panel.Children );
					NewObject( This.ctrl, deletedObject );
					ctrlLayout.ObjectDataToControls();
					ctrl.Content = panel;
				}
				break;
			case 2:
				{
					scene.Controller deletedObject = This.ctrl;
					This.ctrl = new scene.ControllerSphere();
					ctrlLayout = gui.Layouts.CreateLayoutFor< scene.ControllerLayout >( This.ctrl );
					ctrlLayout.ParentLayout = this;
					ctrlLayout.ObjectChanged += ctrl_Changed;
					StackPanel panel = new StackPanel();
					ctrlLayout.CreateControls( This.ctrl, panel.Children );
					NewObject( This.ctrl, deletedObject );
					ctrlLayout.ObjectDataToControls();
					ctrl.Content = panel;
				}
				break;
				
				
			}
		}
		private void ctrl_Changed()
		{
			MemberChanged_Value( SceneZoneTrigger_Reflection.MetadataClass, This, SceneZoneTrigger_Member_ctrl.Member, This.ctrl );
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
			This = (scene.SceneZoneTrigger)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				name = new TextBox();
				name.TextChanged += name_TextChanged;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label{ Content = "name" } );
				panel.Children.Add( name );
				collection.Add( panel );
			}

			{
				DockPanel panel = new DockPanel();
				StackPanel stackPanel = new StackPanel();
				triggerType_Projectile = new RadioButton { GroupName="triggerType", Content="Projectile" };
				triggerType_Projectile.Checked += triggerType_Projectile_Checked;
				stackPanel.Children.Add( triggerType_Projectile );
				triggerType_Character = new RadioButton { GroupName="triggerType", Content="Character" };
				triggerType_Character.Checked += triggerType_Character_Checked;
				stackPanel.Children.Add( triggerType_Character );
				panel.Children.Add( new Label{ Content = "triggerType" } );
				panel.Children.Add( stackPanel );
				collection.Add( panel );
			}
			
			{
				DockPanel dockPanel = new DockPanel();
				dockPanel.Children.Add( new Label { Content = "ctrl" } );
				ctrlComboBox = new ComboBox { IsEditable = false, IsReadOnly = true, MinWidth = 128 };
				ctrlComboBox.Items.Add("[null]");
				if ( This.ctrl == null )
					ctrlComboBox.SelectedIndex = 0;
				ctrlComboBox.Items.Add(" ControllerBox" );
				if ( This.ctrl != null && This.ctrl.GetType() == typeof(scene.ControllerBox) )
					ctrlComboBox.SelectedIndex = 1;
				ctrlComboBox.Items.Add(" ControllerSphere" );
				if ( This.ctrl != null && This.ctrl.GetType() == typeof(scene.ControllerSphere) )
					ctrlComboBox.SelectedIndex = 2;
					
				dockPanel.Children.Add ( ctrlComboBox );
				ctrlComboBox.SelectionChanged += ctrl_SelectionChanged;
				
				ctrl = new GroupBox { Header = dockPanel };
				if ( This.ctrl != null )
				{
					ctrlLayout = gui.Layouts.CreateLayoutFor< scene.ControllerLayout >( This.ctrl );
					ctrlLayout.ParentLayout = this;
					ctrlLayout.ObjectChanged += ctrl_Changed;
			
					
					StackPanel panel = new StackPanel();
					ctrlLayout.CreateControls( This.ctrl, panel.Children );
					ctrl.Content = panel;
				}
				collection.Add( ctrl );	
			}
			
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "SceneZoneTrigger";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			name.Text = This.name;
			switch ( This.triggerType )
			{
			case scene.TriggerType.Projectile:
				triggerType_Projectile.IsChecked = true;
				break;
			case scene.TriggerType.Character:
				triggerType_Character.IsChecked = true;
				break;
			} // switch
			if ( ctrlLayout != null )
				ctrlLayout.ObjectDataToControls();
		}
	}

	public partial class SceneLayout : gui.Layout
	{
		private scene.Scene This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
		private scene.SceneObjectLayout mainObjectLayout;
		private GroupBox mainObject;
		private ComboBox mainObjectComboBox;
		void mainObject_SelectionChanged( object sender, SelectionChangedEventArgs args )
		{
			switch ( mainObjectComboBox.SelectedIndex )
			{
			case 0:
				This.mainObject = null;
				mainObjectLayout = null;
				mainObject.Content = null;
				break;
			case 1:
				{
					scene.SceneObject deletedObject = This.mainObject;
					This.mainObject = new scene.SceneObject();
					mainObjectLayout = gui.Layouts.CreateLayoutFor< scene.SceneObjectLayout >( This.mainObject );
					mainObjectLayout.ParentLayout = this;
					mainObjectLayout.ObjectChanged += mainObject_Changed;
					StackPanel panel = new StackPanel();
					mainObjectLayout.CreateControls( This.mainObject, panel.Children );
					NewObject( This.mainObject, deletedObject );
					mainObjectLayout.ObjectDataToControls();
					mainObject.Content = panel;
				}
				break;
			case 2:
				{
					scene.SceneObject deletedObject = This.mainObject;
					This.mainObject = new scene.SceneMesh();
					mainObjectLayout = gui.Layouts.CreateLayoutFor< scene.SceneObjectLayout >( This.mainObject );
					mainObjectLayout.ParentLayout = this;
					mainObjectLayout.ObjectChanged += mainObject_Changed;
					StackPanel panel = new StackPanel();
					mainObjectLayout.CreateControls( This.mainObject, panel.Children );
					NewObject( This.mainObject, deletedObject );
					mainObjectLayout.ObjectDataToControls();
					mainObject.Content = panel;
				}
				break;
			case 3:
				{
					scene.SceneObject deletedObject = This.mainObject;
					This.mainObject = new scene.SceneAnimMesh();
					mainObjectLayout = gui.Layouts.CreateLayoutFor< scene.SceneObjectLayout >( This.mainObject );
					mainObjectLayout.ParentLayout = this;
					mainObjectLayout.ObjectChanged += mainObject_Changed;
					StackPanel panel = new StackPanel();
					mainObjectLayout.CreateControls( This.mainObject, panel.Children );
					NewObject( This.mainObject, deletedObject );
					mainObjectLayout.ObjectDataToControls();
					mainObject.Content = panel;
				}
				break;
			case 4:
				{
					scene.SceneObject deletedObject = This.mainObject;
					This.mainObject = new scene.SceneZoneTrigger();
					mainObjectLayout = gui.Layouts.CreateLayoutFor< scene.SceneObjectLayout >( This.mainObject );
					mainObjectLayout.ParentLayout = this;
					mainObjectLayout.ObjectChanged += mainObject_Changed;
					StackPanel panel = new StackPanel();
					mainObjectLayout.CreateControls( This.mainObject, panel.Children );
					NewObject( This.mainObject, deletedObject );
					mainObjectLayout.ObjectDataToControls();
					mainObject.Content = panel;
				}
				break;
				
				
			}
		}
		private void mainObject_Changed()
		{
			MemberChanged_Value( Scene_Reflection.MetadataClass, This, Scene_Member_mainObject.Member, This.mainObject );
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
			This = (scene.Scene)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				DockPanel dockPanel = new DockPanel();
				dockPanel.Children.Add( new Label { Content = "mainObject" } );
				mainObjectComboBox = new ComboBox { IsEditable = false, IsReadOnly = true, MinWidth = 128 };
				mainObjectComboBox.Items.Add("[null]");
				if ( This.mainObject == null )
					mainObjectComboBox.SelectedIndex = 0;
				mainObjectComboBox.Items.Add(" SceneObject" );
				if ( This.mainObject != null && This.mainObject.GetType() == typeof(scene.SceneObject) )
					mainObjectComboBox.SelectedIndex = 1;
				mainObjectComboBox.Items.Add(" SceneMesh" );
				if ( This.mainObject != null && This.mainObject.GetType() == typeof(scene.SceneMesh) )
					mainObjectComboBox.SelectedIndex = 2;
				mainObjectComboBox.Items.Add(" SceneAnimMesh" );
				if ( This.mainObject != null && This.mainObject.GetType() == typeof(scene.SceneAnimMesh) )
					mainObjectComboBox.SelectedIndex = 3;
				mainObjectComboBox.Items.Add(" SceneZoneTrigger" );
				if ( This.mainObject != null && This.mainObject.GetType() == typeof(scene.SceneZoneTrigger) )
					mainObjectComboBox.SelectedIndex = 4;
					
				dockPanel.Children.Add ( mainObjectComboBox );
				mainObjectComboBox.SelectionChanged += mainObject_SelectionChanged;
				
				mainObject = new GroupBox { Header = dockPanel };
				if ( This.mainObject != null )
				{
					mainObjectLayout = gui.Layouts.CreateLayoutFor< scene.SceneObjectLayout >( This.mainObject );
					mainObjectLayout.ParentLayout = this;
					mainObjectLayout.ObjectChanged += mainObject_Changed;
			
					
					StackPanel panel = new StackPanel();
					mainObjectLayout.CreateControls( This.mainObject, panel.Children );
					mainObject.Content = panel;
				}
				collection.Add( mainObject );	
			}
			
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "Scene";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			if ( mainObjectLayout != null )
				mainObjectLayout.ObjectDataToControls();
		}
	}

	public abstract partial class ControllerLayout : gui.Layout
	{
		private scene.Controller This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
		private Slider priority = null;
		private TextBox priority_TextBox;
		private void priority_ValueChanged(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.priority = (int)priority.Value;
			priority_TextBox.Text = This.priority.ToString();
			priority_Changed();
		}
		private void priority_LostKeyboardFocus( object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e )
		{
			if ( IsObjectDataToControls )
				return;
		
			bool error = false;
			try
			{
				This.priority = (int)System.Convert.ToInt32(priority_TextBox.Text);
				if ( This.priority < 0 ) { This.priority = 0; error = true; }
				if ( This.priority > 30 ) { This.priority = 30; error = true; }
			}
			catch ( System.FormatException ) { error = true; }
			catch ( System.OverflowException ) { error = true; }
		
			if ( error )
				priority_TextBox.Text = This.priority.ToString();
			else
				priority_Changed();
				
			if ( priority != null )
				priority.Value = This.priority;
		}

		private void priority_Changed()
		{
			MemberChanged_Value( Controller_Reflection.MetadataClass, This, Controller_Member_priority.Member, new int_Boxed { value = This.priority } );
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
			This = (scene.Controller)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				priority_TextBox = new TextBox { MinWidth = 64 };
				priority_TextBox.LostKeyboardFocus += priority_LostKeyboardFocus;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label { Content = "priority" } );	
				panel.Children.Add( priority_TextBox );
				priority = new Slider(); 
				panel.Children.Add( priority );
				priority.Minimum = 0;
				priority.Maximum = 30;
				priority.IsSnapToTickEnabled = true;
				priority.TickPlacement = System.Windows.Controls.Primitives.TickPlacement.BottomRight;
				priority.TickFrequency = 1;
				priority.ValueChanged += priority_ValueChanged; // must be the last
					
				collection.Add( panel );
			}

		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "Controller";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			if ( priority != null )
				priority.Value = This.priority;
			priority_TextBox.Text = This.priority.ToString();
		}
	}

	public partial class ControllerBoxLayout : ControllerLayout
	{
		private scene.ControllerBox This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
		private Vec3Layout sizeLayout;
		private GroupBox size;
		private void size_Changed()
		{
			MemberChanged_Value( ControllerBox_Reflection.MetadataClass, This, ControllerBox_Member_size.Member, This.size );
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
			This = (scene.ControllerBox)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				DockPanel dockPanel = new DockPanel();
				dockPanel.Children.Add( new Label { Content = "size" } );
				size = new GroupBox { Header = dockPanel };
				if ( This.size != null )
				{
					sizeLayout = gui.Layouts.CreateLayoutFor< Vec3Layout >( This.size );
					sizeLayout.ParentLayout = this;
					sizeLayout.ObjectChanged += size_Changed;
			
					
					StackPanel panel = new StackPanel();
					sizeLayout.CreateControls( This.size, panel.Children );
					size.Content = panel;
				}
				collection.Add( size );	
			}
			
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "ControllerBox";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			if ( sizeLayout != null )
				sizeLayout.ObjectDataToControls();
		}
	}

	public partial class ControllerSphereLayout : ControllerLayout
	{
		private scene.ControllerSphere This = null;
		
		private Label TypeLabel;
		private Label GuidLabel;
		private Slider radius = null;
		private TextBox radius_TextBox;
		private void radius_ValueChanged(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.radius = (float)radius.Value;
			radius_TextBox.Text = This.radius.ToString();
			radius_Changed();
		}
		private void radius_LostKeyboardFocus( object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e )
		{
			if ( IsObjectDataToControls )
				return;
		
			bool error = false;
			try
			{
				This.radius = (float)System.Convert.ToSingle(radius_TextBox.Text);
				if ( This.radius < 0.5f ) { This.radius = 0.5f; error = true; }
				if ( This.radius > 29.5f ) { This.radius = 29.5f; error = true; }
			}
			catch ( System.FormatException ) { error = true; }
			catch ( System.OverflowException ) { error = true; }
		
			if ( error )
				radius_TextBox.Text = This.radius.ToString();
			else
				radius_Changed();
			
			if ( radius != null )
				radius.Value = This.radius;
		}

		private void radius_Changed()
		{
			MemberChanged_Value( ControllerSphere_Reflection.MetadataClass, This, ControllerSphere_Member_radius.Member, new float_Boxed { value = This.radius } );
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
			This = (scene.ControllerSphere)dataObject;
			base.CreateControls_Base( dataObject, collection );
			{
				radius_TextBox = new TextBox { MinWidth = 64 };
				radius_TextBox.LostKeyboardFocus += radius_LostKeyboardFocus;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label { Content = "radius" } );	
				panel.Children.Add( radius_TextBox );
				radius = new Slider();
				panel.Children.Add( radius );
				radius.Minimum = 0.5f;
				radius.Maximum = 29.5f;
				radius.ValueChanged += radius_ValueChanged; // must be the last
					
				collection.Add( panel );
			}

		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "ControllerSphere";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
			if ( radius != null )
				radius.Value = This.radius;
			radius_TextBox.Text = This.radius.ToString();
		}
	}

} /* namespace scene */ 
