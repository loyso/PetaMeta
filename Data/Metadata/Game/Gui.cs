
// AUTOGENERATED FILE. MODIFY IT AT YOUR OWN RISK.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace gui { 

	public partial class Window : core.ReferenceObject
	{
		public gui.WindowsCollection children = new gui.WindowsCollection();
		public Vec2 position = new Vec2 ();
		public Vec2 size = new Vec2 ();
		public gui.Window parent;
		public gui.GuiFile parentFile;
		public string name = "Window";
	}

	public partial class WindowsCollection : core.CollectionOf <gui.Window>
	{
	}

} /* namespace gui */ 