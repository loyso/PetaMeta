using System.Windows;
using System.Windows.Controls;

namespace metadata { 

	public abstract partial class FundamentalLayout : TypeLayout
	{
		private metadata.Fundamental This = null;
		
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
			This = (metadata.Fundamental)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "Fundamental";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class FundamentalBoolLayout : FundamentalLayout
	{
		private metadata.FundamentalBool This = null;
		
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
			This = (metadata.FundamentalBool)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "FundamentalBool";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class FundamentalStringLayout : FundamentalLayout
	{
		private metadata.FundamentalString This = null;
		
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
			This = (metadata.FundamentalString)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "FundamentalString";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class FundamentalIntLayout : FundamentalLayout
	{
		private metadata.FundamentalInt This = null;
		
		private metadata.FundamentalInt ThisMin;
		private metadata.FundamentalInt ThisMax;
		public void SetMinMax( metadata.FundamentalInt minimum, metadata.FundamentalInt maximum )
		{
			ThisMin = minimum;
			ThisMax = maximum;
		}
		
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
			This = (metadata.FundamentalInt)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "FundamentalInt";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class FundamentalFloatLayout : FundamentalLayout
	{
		private metadata.FundamentalFloat This = null;
		
		private metadata.FundamentalFloat ThisMin;
		private metadata.FundamentalFloat ThisMax;
		public void SetMinMax( metadata.FundamentalFloat minimum, metadata.FundamentalFloat maximum )
		{
			ThisMin = minimum;
			ThisMax = maximum;
		}
		
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
			This = (metadata.FundamentalFloat)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "FundamentalFloat";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class FundamentalByteLayout : FundamentalLayout
	{
		private metadata.FundamentalByte This = null;
		
		private metadata.FundamentalByte ThisMin;
		private metadata.FundamentalByte ThisMax;
		public void SetMinMax( metadata.FundamentalByte minimum, metadata.FundamentalByte maximum )
		{
			ThisMin = minimum;
			ThisMax = maximum;
		}
		
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
			This = (metadata.FundamentalByte)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "FundamentalByte";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class EnumerationLayout : TypeLayout
	{
		private metadata.Enumeration This = null;
		
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
			This = (metadata.Enumeration)dataObject;
			base.CreateControls_Base( dataObject, collection );
		}
		
		public override void ObjectDataToControls()
		{
			IsObjectDataToControls = true;
			TypeLabel.Content = "Enumeration";
			GuidLabel.Content = This.Guid.ToString();
			ObjectDataToControls_Base();
			
			IsObjectDataToControls = false;
		}
		protected override void ObjectDataToControls_Base()
		{
			base.ObjectDataToControls_Base();
		}
	}

	public partial class EnumeratorLayout : gui.Layout
	{
		private metadata.Enumerator This = null;
		
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
		private Slider IntegralValue = null;
		private TextBox IntegralValue_TextBox;
		private void IntegralValue_ValueChanged(object sender, RoutedEventArgs e)
		{
			if ( IsObjectDataToControls )
				return;
		
			This.IntegralValue = (int)IntegralValue.Value;
			IntegralValue_TextBox.Text = This.IntegralValue.ToString();
			IntegralValue_Changed();
		}
		private void IntegralValue_LostKeyboardFocus( object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e )
		{
			if ( IsObjectDataToControls )
				return;
		
			bool error = false;
			try
			{
				This.IntegralValue = (int)System.Convert.ToInt32(IntegralValue_TextBox.Text);
			}
			catch ( System.FormatException ) { error = true; }
			catch ( System.OverflowException ) { error = true; }
		
			if ( error )
				IntegralValue_TextBox.Text = This.IntegralValue.ToString();
			else
				IntegralValue_Changed();
				
			if ( IntegralValue != null )
				IntegralValue.Value = This.IntegralValue;
		}

		private void IntegralValue_Changed()
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
			This = (metadata.Enumerator)dataObject;
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
				IntegralValue_TextBox = new TextBox { MinWidth = 64 };
				IntegralValue_TextBox.LostKeyboardFocus += IntegralValue_LostKeyboardFocus;
				DockPanel panel = new DockPanel();
				panel.Children.Add( new Label { Content = "IntegralValue" } );	
				panel.Children.Add( IntegralValue_TextBox );
					
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
			if ( IntegralValue != null )
				IntegralValue.Value = This.IntegralValue;
			IntegralValue_TextBox.Text = This.IntegralValue.ToString();
		}
	}

	public partial class EnumeratorsCollectionLayout : gui.Layout
	{
		private metadata.EnumeratorsCollection This = null;
		
		
		public override void CreateControls ( core.DataObject dataObject, UIElementCollection collection )
		{
			CreateControls_Base( dataObject, collection );
		}
		protected override void CreateControls_Base ( core.DataObject dataObject, UIElementCollection collection )
		{
			This = (metadata.EnumeratorsCollection)dataObject;
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

} /* namespace metadata */ 
