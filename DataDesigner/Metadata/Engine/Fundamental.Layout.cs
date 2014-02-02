using System.Windows;
using System.Windows.Controls;

public partial class Vec2Layout : gui.Layout
{
	private Vec2 This = null;
	
	private Vec2 ThisMin;
	private Vec2 ThisMax;
	public void SetMinMax( Vec2 minimum, Vec2 maximum )
	{
		ThisMin = minimum;
		ThisMax = maximum;
	}
	
	private Slider x = null;
	private TextBox x_TextBox;
	private void x_ValueChanged(object sender, RoutedEventArgs e)
	{
		if ( IsObjectDataToControls )
			return;
	
		This.x = (float)x.Value;
		x_TextBox.Text = This.x.ToString();
		x_Changed();
	}
	private void x_LostKeyboardFocus( object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e )
	{
		if ( IsObjectDataToControls )
			return;
	
		bool error = false;
		try
		{
			This.x = (float)System.Convert.ToSingle(x_TextBox.Text);
			if ( ThisMin != null && This.x < ThisMin.x ) { This.x = ThisMin.x; error = true; }
			if ( ThisMax != null && This.x > ThisMax.x ) { This.x = ThisMax.x; error = true; }
		}
		catch ( System.FormatException ) { error = true; }
		catch ( System.OverflowException ) { error = true; }
	
		if ( error )
			x_TextBox.Text = This.x.ToString();
		else
			x_Changed();
		
		if ( x != null )
			x.Value = This.x;
	}

	private void x_Changed()
	{
		if ( ObjectChanged != null )
			ObjectChanged();
	}
	private Slider y = null;
	private TextBox y_TextBox;
	private void y_ValueChanged(object sender, RoutedEventArgs e)
	{
		if ( IsObjectDataToControls )
			return;
	
		This.y = (float)y.Value;
		y_TextBox.Text = This.y.ToString();
		y_Changed();
	}
	private void y_LostKeyboardFocus( object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e )
	{
		if ( IsObjectDataToControls )
			return;
	
		bool error = false;
		try
		{
			This.y = (float)System.Convert.ToSingle(y_TextBox.Text);
			if ( ThisMin != null && This.y < ThisMin.y ) { This.y = ThisMin.y; error = true; }
			if ( ThisMax != null && This.y > ThisMax.y ) { This.y = ThisMax.y; error = true; }
		}
		catch ( System.FormatException ) { error = true; }
		catch ( System.OverflowException ) { error = true; }
	
		if ( error )
			y_TextBox.Text = This.y.ToString();
		else
			y_Changed();
		
		if ( y != null )
			y.Value = This.y;
	}

	private void y_Changed()
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
		This = (Vec2)dataObject;
		base.CreateControls_Base( dataObject, collection );
		{
			x_TextBox = new TextBox { MinWidth = 64 };
			x_TextBox.LostKeyboardFocus += x_LostKeyboardFocus;
			DockPanel panel = new DockPanel();
			panel.Children.Add( new Label { Content = "x" } );	
			panel.Children.Add( x_TextBox );
			x = new Slider();
			panel.Children.Add( x );
			if ( ThisMin != null && ThisMax != null )
			{
				x.Minimum = ThisMin.x;
				x.Maximum = ThisMax.x;
			}
			x.ValueChanged += x_ValueChanged; // must be the last
				
			collection.Add( panel );
		}

		{
			y_TextBox = new TextBox { MinWidth = 64 };
			y_TextBox.LostKeyboardFocus += y_LostKeyboardFocus;
			DockPanel panel = new DockPanel();
			panel.Children.Add( new Label { Content = "y" } );	
			panel.Children.Add( y_TextBox );
			y = new Slider();
			panel.Children.Add( y );
			if ( ThisMin != null && ThisMax != null )
			{
				y.Minimum = ThisMin.y;
				y.Maximum = ThisMax.y;
			}
			y.ValueChanged += y_ValueChanged; // must be the last
				
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
		if ( x != null )
			x.Value = This.x;
		x_TextBox.Text = This.x.ToString();
		if ( y != null )
			y.Value = This.y;
		y_TextBox.Text = This.y.ToString();
	}
}

public partial class Vec3Layout : gui.Layout
{
	private Vec3 This = null;
	
	private Vec3 ThisMin;
	private Vec3 ThisMax;
	public void SetMinMax( Vec3 minimum, Vec3 maximum )
	{
		ThisMin = minimum;
		ThisMax = maximum;
	}
	
	private Slider x = null;
	private TextBox x_TextBox;
	private void x_ValueChanged(object sender, RoutedEventArgs e)
	{
		if ( IsObjectDataToControls )
			return;
	
		This.x = (float)x.Value;
		x_TextBox.Text = This.x.ToString();
		x_Changed();
	}
	private void x_LostKeyboardFocus( object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e )
	{
		if ( IsObjectDataToControls )
			return;
	
		bool error = false;
		try
		{
			This.x = (float)System.Convert.ToSingle(x_TextBox.Text);
			if ( ThisMin != null && This.x < ThisMin.x ) { This.x = ThisMin.x; error = true; }
			if ( ThisMax != null && This.x > ThisMax.x ) { This.x = ThisMax.x; error = true; }
		}
		catch ( System.FormatException ) { error = true; }
		catch ( System.OverflowException ) { error = true; }
	
		if ( error )
			x_TextBox.Text = This.x.ToString();
		else
			x_Changed();
		
		if ( x != null )
			x.Value = This.x;
	}

	private void x_Changed()
	{
		if ( ObjectChanged != null )
			ObjectChanged();
	}
	private Slider y = null;
	private TextBox y_TextBox;
	private void y_ValueChanged(object sender, RoutedEventArgs e)
	{
		if ( IsObjectDataToControls )
			return;
	
		This.y = (float)y.Value;
		y_TextBox.Text = This.y.ToString();
		y_Changed();
	}
	private void y_LostKeyboardFocus( object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e )
	{
		if ( IsObjectDataToControls )
			return;
	
		bool error = false;
		try
		{
			This.y = (float)System.Convert.ToSingle(y_TextBox.Text);
			if ( ThisMin != null && This.y < ThisMin.y ) { This.y = ThisMin.y; error = true; }
			if ( ThisMax != null && This.y > ThisMax.y ) { This.y = ThisMax.y; error = true; }
		}
		catch ( System.FormatException ) { error = true; }
		catch ( System.OverflowException ) { error = true; }
	
		if ( error )
			y_TextBox.Text = This.y.ToString();
		else
			y_Changed();
		
		if ( y != null )
			y.Value = This.y;
	}

	private void y_Changed()
	{
		if ( ObjectChanged != null )
			ObjectChanged();
	}
	private Slider z = null;
	private TextBox z_TextBox;
	private void z_ValueChanged(object sender, RoutedEventArgs e)
	{
		if ( IsObjectDataToControls )
			return;
	
		This.z = (float)z.Value;
		z_TextBox.Text = This.z.ToString();
		z_Changed();
	}
	private void z_LostKeyboardFocus( object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e )
	{
		if ( IsObjectDataToControls )
			return;
	
		bool error = false;
		try
		{
			This.z = (float)System.Convert.ToSingle(z_TextBox.Text);
			if ( ThisMin != null && This.z < ThisMin.z ) { This.z = ThisMin.z; error = true; }
			if ( ThisMax != null && This.z > ThisMax.z ) { This.z = ThisMax.z; error = true; }
		}
		catch ( System.FormatException ) { error = true; }
		catch ( System.OverflowException ) { error = true; }
	
		if ( error )
			z_TextBox.Text = This.z.ToString();
		else
			z_Changed();
		
		if ( z != null )
			z.Value = This.z;
	}

	private void z_Changed()
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
		This = (Vec3)dataObject;
		base.CreateControls_Base( dataObject, collection );
		{
			x_TextBox = new TextBox { MinWidth = 64 };
			x_TextBox.LostKeyboardFocus += x_LostKeyboardFocus;
			DockPanel panel = new DockPanel();
			panel.Children.Add( new Label { Content = "x" } );	
			panel.Children.Add( x_TextBox );
			x = new Slider();
			panel.Children.Add( x );
			if ( ThisMin != null && ThisMax != null )
			{
				x.Minimum = ThisMin.x;
				x.Maximum = ThisMax.x;
			}
			x.ValueChanged += x_ValueChanged; // must be the last
				
			collection.Add( panel );
		}

		{
			y_TextBox = new TextBox { MinWidth = 64 };
			y_TextBox.LostKeyboardFocus += y_LostKeyboardFocus;
			DockPanel panel = new DockPanel();
			panel.Children.Add( new Label { Content = "y" } );	
			panel.Children.Add( y_TextBox );
			y = new Slider();
			panel.Children.Add( y );
			if ( ThisMin != null && ThisMax != null )
			{
				y.Minimum = ThisMin.y;
				y.Maximum = ThisMax.y;
			}
			y.ValueChanged += y_ValueChanged; // must be the last
				
			collection.Add( panel );
		}

		{
			z_TextBox = new TextBox { MinWidth = 64 };
			z_TextBox.LostKeyboardFocus += z_LostKeyboardFocus;
			DockPanel panel = new DockPanel();
			panel.Children.Add( new Label { Content = "z" } );	
			panel.Children.Add( z_TextBox );
			z = new Slider();
			panel.Children.Add( z );
			if ( ThisMin != null && ThisMax != null )
			{
				z.Minimum = ThisMin.z;
				z.Maximum = ThisMax.z;
			}
			z.ValueChanged += z_ValueChanged; // must be the last
				
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
		if ( x != null )
			x.Value = This.x;
		x_TextBox.Text = This.x.ToString();
		if ( y != null )
			y.Value = This.y;
		y_TextBox.Text = This.y.ToString();
		if ( z != null )
			z.Value = This.z;
		z_TextBox.Text = This.z.ToString();
	}
}

public partial class Vec4Layout : gui.Layout
{
	private Vec4 This = null;
	
	private Vec4 ThisMin;
	private Vec4 ThisMax;
	public void SetMinMax( Vec4 minimum, Vec4 maximum )
	{
		ThisMin = minimum;
		ThisMax = maximum;
	}
	
	private Slider x = null;
	private TextBox x_TextBox;
	private void x_ValueChanged(object sender, RoutedEventArgs e)
	{
		if ( IsObjectDataToControls )
			return;
	
		This.x = (float)x.Value;
		x_TextBox.Text = This.x.ToString();
		x_Changed();
	}
	private void x_LostKeyboardFocus( object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e )
	{
		if ( IsObjectDataToControls )
			return;
	
		bool error = false;
		try
		{
			This.x = (float)System.Convert.ToSingle(x_TextBox.Text);
			if ( ThisMin != null && This.x < ThisMin.x ) { This.x = ThisMin.x; error = true; }
			if ( ThisMax != null && This.x > ThisMax.x ) { This.x = ThisMax.x; error = true; }
		}
		catch ( System.FormatException ) { error = true; }
		catch ( System.OverflowException ) { error = true; }
	
		if ( error )
			x_TextBox.Text = This.x.ToString();
		else
			x_Changed();
		
		if ( x != null )
			x.Value = This.x;
	}

	private void x_Changed()
	{
		if ( ObjectChanged != null )
			ObjectChanged();
	}
	private Slider y = null;
	private TextBox y_TextBox;
	private void y_ValueChanged(object sender, RoutedEventArgs e)
	{
		if ( IsObjectDataToControls )
			return;
	
		This.y = (float)y.Value;
		y_TextBox.Text = This.y.ToString();
		y_Changed();
	}
	private void y_LostKeyboardFocus( object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e )
	{
		if ( IsObjectDataToControls )
			return;
	
		bool error = false;
		try
		{
			This.y = (float)System.Convert.ToSingle(y_TextBox.Text);
			if ( ThisMin != null && This.y < ThisMin.y ) { This.y = ThisMin.y; error = true; }
			if ( ThisMax != null && This.y > ThisMax.y ) { This.y = ThisMax.y; error = true; }
		}
		catch ( System.FormatException ) { error = true; }
		catch ( System.OverflowException ) { error = true; }
	
		if ( error )
			y_TextBox.Text = This.y.ToString();
		else
			y_Changed();
		
		if ( y != null )
			y.Value = This.y;
	}

	private void y_Changed()
	{
		if ( ObjectChanged != null )
			ObjectChanged();
	}
	private Slider z = null;
	private TextBox z_TextBox;
	private void z_ValueChanged(object sender, RoutedEventArgs e)
	{
		if ( IsObjectDataToControls )
			return;
	
		This.z = (float)z.Value;
		z_TextBox.Text = This.z.ToString();
		z_Changed();
	}
	private void z_LostKeyboardFocus( object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e )
	{
		if ( IsObjectDataToControls )
			return;
	
		bool error = false;
		try
		{
			This.z = (float)System.Convert.ToSingle(z_TextBox.Text);
			if ( ThisMin != null && This.z < ThisMin.z ) { This.z = ThisMin.z; error = true; }
			if ( ThisMax != null && This.z > ThisMax.z ) { This.z = ThisMax.z; error = true; }
		}
		catch ( System.FormatException ) { error = true; }
		catch ( System.OverflowException ) { error = true; }
	
		if ( error )
			z_TextBox.Text = This.z.ToString();
		else
			z_Changed();
		
		if ( z != null )
			z.Value = This.z;
	}

	private void z_Changed()
	{
		if ( ObjectChanged != null )
			ObjectChanged();
	}
	private Slider w = null;
	private TextBox w_TextBox;
	private void w_ValueChanged(object sender, RoutedEventArgs e)
	{
		if ( IsObjectDataToControls )
			return;
	
		This.w = (float)w.Value;
		w_TextBox.Text = This.w.ToString();
		w_Changed();
	}
	private void w_LostKeyboardFocus( object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e )
	{
		if ( IsObjectDataToControls )
			return;
	
		bool error = false;
		try
		{
			This.w = (float)System.Convert.ToSingle(w_TextBox.Text);
			if ( ThisMin != null && This.w < ThisMin.w ) { This.w = ThisMin.w; error = true; }
			if ( ThisMax != null && This.w > ThisMax.w ) { This.w = ThisMax.w; error = true; }
		}
		catch ( System.FormatException ) { error = true; }
		catch ( System.OverflowException ) { error = true; }
	
		if ( error )
			w_TextBox.Text = This.w.ToString();
		else
			w_Changed();
		
		if ( w != null )
			w.Value = This.w;
	}

	private void w_Changed()
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
		This = (Vec4)dataObject;
		base.CreateControls_Base( dataObject, collection );
		{
			x_TextBox = new TextBox { MinWidth = 64 };
			x_TextBox.LostKeyboardFocus += x_LostKeyboardFocus;
			DockPanel panel = new DockPanel();
			panel.Children.Add( new Label { Content = "x" } );	
			panel.Children.Add( x_TextBox );
			x = new Slider();
			panel.Children.Add( x );
			if ( ThisMin != null && ThisMax != null )
			{
				x.Minimum = ThisMin.x;
				x.Maximum = ThisMax.x;
			}
			x.ValueChanged += x_ValueChanged; // must be the last
				
			collection.Add( panel );
		}

		{
			y_TextBox = new TextBox { MinWidth = 64 };
			y_TextBox.LostKeyboardFocus += y_LostKeyboardFocus;
			DockPanel panel = new DockPanel();
			panel.Children.Add( new Label { Content = "y" } );	
			panel.Children.Add( y_TextBox );
			y = new Slider();
			panel.Children.Add( y );
			if ( ThisMin != null && ThisMax != null )
			{
				y.Minimum = ThisMin.y;
				y.Maximum = ThisMax.y;
			}
			y.ValueChanged += y_ValueChanged; // must be the last
				
			collection.Add( panel );
		}

		{
			z_TextBox = new TextBox { MinWidth = 64 };
			z_TextBox.LostKeyboardFocus += z_LostKeyboardFocus;
			DockPanel panel = new DockPanel();
			panel.Children.Add( new Label { Content = "z" } );	
			panel.Children.Add( z_TextBox );
			z = new Slider();
			panel.Children.Add( z );
			if ( ThisMin != null && ThisMax != null )
			{
				z.Minimum = ThisMin.z;
				z.Maximum = ThisMax.z;
			}
			z.ValueChanged += z_ValueChanged; // must be the last
				
			collection.Add( panel );
		}

		{
			w_TextBox = new TextBox { MinWidth = 64 };
			w_TextBox.LostKeyboardFocus += w_LostKeyboardFocus;
			DockPanel panel = new DockPanel();
			panel.Children.Add( new Label { Content = "w" } );	
			panel.Children.Add( w_TextBox );
			w = new Slider();
			panel.Children.Add( w );
			if ( ThisMin != null && ThisMax != null )
			{
				w.Minimum = ThisMin.w;
				w.Maximum = ThisMax.w;
			}
			w.ValueChanged += w_ValueChanged; // must be the last
				
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
		if ( x != null )
			x.Value = This.x;
		x_TextBox.Text = This.x.ToString();
		if ( y != null )
			y.Value = This.y;
		y_TextBox.Text = This.y.ToString();
		if ( z != null )
			z.Value = This.z;
		z_TextBox.Text = This.z.ToString();
		if ( w != null )
			w.Value = This.w;
		w_TextBox.Text = This.w.ToString();
	}
}

public partial class ColorLayout : gui.Layout
{
	private Color This = null;
	
	private Color ThisMin;
	private Color ThisMax;
	public void SetMinMax( Color minimum, Color maximum )
	{
		ThisMin = minimum;
		ThisMax = maximum;
	}
	
	private Slider r;
	private TextBox r_TextBox;
	private void r_ValueChanged(object sender, RoutedEventArgs e)
	{
		if ( IsObjectDataToControls )
			return;
	
		This.r = (byte)r.Value;
		r_TextBox.Text = This.r.ToString();
		r_Changed();	
	}
	private void r_LostKeyboardFocus( object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e )
	{
		if ( IsObjectDataToControls )
			return;
	
		bool error = false;
		try
		{
			This.r = (byte)System.Convert.ToByte(r_TextBox.Text);
			if ( ThisMin != null && This.r < ThisMin.r ) { This.r = ThisMin.r; error = true; }
			if ( ThisMax != null && This.r > ThisMax.r ) { This.r = ThisMax.r; error = true; }
		}
		catch ( System.FormatException ) { error = true; }
		catch ( System.OverflowException ) { error = true; }
	
		if ( error )
			r_TextBox.Text = This.r.ToString();
		else
			r_Changed();
			
		r.Value = This.r;
	}

	private void r_Changed()
	{
		if ( ObjectChanged != null )
			ObjectChanged();
	}
	private Slider g;
	private TextBox g_TextBox;
	private void g_ValueChanged(object sender, RoutedEventArgs e)
	{
		if ( IsObjectDataToControls )
			return;
	
		This.g = (byte)g.Value;
		g_TextBox.Text = This.g.ToString();
		g_Changed();	
	}
	private void g_LostKeyboardFocus( object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e )
	{
		if ( IsObjectDataToControls )
			return;
	
		bool error = false;
		try
		{
			This.g = (byte)System.Convert.ToByte(g_TextBox.Text);
			if ( ThisMin != null && This.g < ThisMin.g ) { This.g = ThisMin.g; error = true; }
			if ( ThisMax != null && This.g > ThisMax.g ) { This.g = ThisMax.g; error = true; }
		}
		catch ( System.FormatException ) { error = true; }
		catch ( System.OverflowException ) { error = true; }
	
		if ( error )
			g_TextBox.Text = This.g.ToString();
		else
			g_Changed();
			
		g.Value = This.g;
	}

	private void g_Changed()
	{
		if ( ObjectChanged != null )
			ObjectChanged();
	}
	private Slider b;
	private TextBox b_TextBox;
	private void b_ValueChanged(object sender, RoutedEventArgs e)
	{
		if ( IsObjectDataToControls )
			return;
	
		This.b = (byte)b.Value;
		b_TextBox.Text = This.b.ToString();
		b_Changed();	
	}
	private void b_LostKeyboardFocus( object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e )
	{
		if ( IsObjectDataToControls )
			return;
	
		bool error = false;
		try
		{
			This.b = (byte)System.Convert.ToByte(b_TextBox.Text);
			if ( ThisMin != null && This.b < ThisMin.b ) { This.b = ThisMin.b; error = true; }
			if ( ThisMax != null && This.b > ThisMax.b ) { This.b = ThisMax.b; error = true; }
		}
		catch ( System.FormatException ) { error = true; }
		catch ( System.OverflowException ) { error = true; }
	
		if ( error )
			b_TextBox.Text = This.b.ToString();
		else
			b_Changed();
			
		b.Value = This.b;
	}

	private void b_Changed()
	{
		if ( ObjectChanged != null )
			ObjectChanged();
	}
	private Slider a;
	private TextBox a_TextBox;
	private void a_ValueChanged(object sender, RoutedEventArgs e)
	{
		if ( IsObjectDataToControls )
			return;
	
		This.a = (byte)a.Value;
		a_TextBox.Text = This.a.ToString();
		a_Changed();	
	}
	private void a_LostKeyboardFocus( object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e )
	{
		if ( IsObjectDataToControls )
			return;
	
		bool error = false;
		try
		{
			This.a = (byte)System.Convert.ToByte(a_TextBox.Text);
			if ( ThisMin != null && This.a < ThisMin.a ) { This.a = ThisMin.a; error = true; }
			if ( ThisMax != null && This.a > ThisMax.a ) { This.a = ThisMax.a; error = true; }
		}
		catch ( System.FormatException ) { error = true; }
		catch ( System.OverflowException ) { error = true; }
	
		if ( error )
			a_TextBox.Text = This.a.ToString();
		else
			a_Changed();
			
		a.Value = This.a;
	}

	private void a_Changed()
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
		This = (Color)dataObject;
		base.CreateControls_Base( dataObject, collection );
		{
			r_TextBox = new TextBox { MinWidth = 64 };
			r_TextBox.LostKeyboardFocus += r_LostKeyboardFocus;
			DockPanel panel = new DockPanel();
			panel.Children.Add( new Label { Content = "r" } );	
			panel.Children.Add( r_TextBox );
			r = new Slider(); 
			panel.Children.Add( r );
			r.Minimum = 0;
			r.Maximum = 255;
			if ( ThisMin != null && ThisMax != null )
			{
				r.Minimum = ThisMin.r;
				r.Maximum = ThisMax.r;
			}
			r.ValueChanged += r_ValueChanged; // must be the last
		
			collection.Add( panel );
		}

		{
			g_TextBox = new TextBox { MinWidth = 64 };
			g_TextBox.LostKeyboardFocus += g_LostKeyboardFocus;
			DockPanel panel = new DockPanel();
			panel.Children.Add( new Label { Content = "g" } );	
			panel.Children.Add( g_TextBox );
			g = new Slider(); 
			panel.Children.Add( g );
			g.Minimum = 0;
			g.Maximum = 255;
			if ( ThisMin != null && ThisMax != null )
			{
				g.Minimum = ThisMin.g;
				g.Maximum = ThisMax.g;
			}
			g.ValueChanged += g_ValueChanged; // must be the last
		
			collection.Add( panel );
		}

		{
			b_TextBox = new TextBox { MinWidth = 64 };
			b_TextBox.LostKeyboardFocus += b_LostKeyboardFocus;
			DockPanel panel = new DockPanel();
			panel.Children.Add( new Label { Content = "b" } );	
			panel.Children.Add( b_TextBox );
			b = new Slider(); 
			panel.Children.Add( b );
			b.Minimum = 0;
			b.Maximum = 255;
			if ( ThisMin != null && ThisMax != null )
			{
				b.Minimum = ThisMin.b;
				b.Maximum = ThisMax.b;
			}
			b.ValueChanged += b_ValueChanged; // must be the last
		
			collection.Add( panel );
		}

		{
			a_TextBox = new TextBox { MinWidth = 64 };
			a_TextBox.LostKeyboardFocus += a_LostKeyboardFocus;
			DockPanel panel = new DockPanel();
			panel.Children.Add( new Label { Content = "a" } );	
			panel.Children.Add( a_TextBox );
			a = new Slider(); 
			panel.Children.Add( a );
			a.Minimum = 0;
			a.Maximum = 255;
			if ( ThisMin != null && ThisMax != null )
			{
				a.Minimum = ThisMin.a;
				a.Maximum = ThisMax.a;
			}
			a.ValueChanged += a_ValueChanged; // must be the last
		
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
		r.Value = This.r;
		r_TextBox.Text = This.r.ToString();
		g.Value = This.g;
		g_TextBox.Text = This.g.ToString();
		b.Value = This.b;
		b_TextBox.Text = This.b.ToString();
		a.Value = This.a;
		a_TextBox.Text = This.a.ToString();
	}
}

