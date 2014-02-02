
// AUTOGENERATED FILE. MODIFY IT AT YOUR OWN RISK.

using System;
using System.Collections.Generic;

namespace gui { 

	public static class Gui_ByteStream
	{
		public static void ObjectToByteStream( core.ByteStreamWriter stream, gui.Gui dataObject ) 
		{ 
			stream.WriteBytes( System.Text.Encoding.ASCII.GetBytes( dataObject.name ) );
			gui.GuiMainMenu_ByteStream.ObjectToByteStream( stream, dataObject.mainMenu );
			gui.GuiGame_ByteStream.ObjectToByteStream( stream, dataObject.game );
		}		
	}

	public static class GuiCommon_ByteStream
	{
		public static void ObjectToByteStream( core.ByteStreamWriter stream, gui.GuiCommon dataObject ) 
		{ 
			stream.WriteBytes( System.Text.Encoding.ASCII.GetBytes( dataObject.name ) );
		}		
	}

	public static class GuiMainMenu_ByteStream
	{
		public static void ObjectToByteStream( core.ByteStreamWriter stream, gui.GuiMainMenu dataObject ) 
		{ 
		}		
	}

	public static class GuiGame_ByteStream
	{
		public static void ObjectToByteStream( core.ByteStreamWriter stream, gui.GuiGame dataObject ) 
		{ 
		}		
	}

	public static class GuiFile_ByteStream
	{
		public static void ObjectToByteStream( core.ByteStreamWriter stream, gui.GuiFile dataObject ) 
		{ 
			stream.WriteBytes( System.Text.Encoding.ASCII.GetBytes( dataObject.name ) );
		}		
	}

	public static class GuiFilesCollection_ByteStream
	{
		public static void ObjectToByteStream( core.ByteStreamWriter stream, gui.GuiFilesCollection dataObject ) 
		{ 
		}		
	}

} /* namespace gui */ 
