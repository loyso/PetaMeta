
// AUTOGENERATED FILE. MODIFY IT AT YOUR OWN RISK.

using System;
using System.Collections.Generic;

namespace gui { 

	public static class Window_ByteStream
	{
		public static void ObjectToByteStream( core.ByteStreamWriter stream, gui.Window dataObject ) 
		{ 
			Vec2_ByteStream.ObjectToByteStream( stream, dataObject.position );
			Vec2_ByteStream.ObjectToByteStream( stream, dataObject.size );
			stream.WriteBytes( System.Text.Encoding.ASCII.GetBytes( dataObject.name ) );
		}		
	}

	public static class WindowsCollection_ByteStream
	{
		public static void ObjectToByteStream( core.ByteStreamWriter stream, gui.WindowsCollection dataObject ) 
		{ 
		}		
	}

} /* namespace gui */ 
