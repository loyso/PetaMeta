
// AUTOGENERATED FILE. MODIFY IT AT YOUR OWN RISK.

using System;
using System.Runtime.InteropServices;

namespace scene { 

public partial class SceneObject
{
	public void TestFunction ( int argInt, Vec3 argVec, scene.SceneZoneTrigger argRef, scene.TriggerType argEnum, string argString, Color argColor )
	{
		core.NetworkByteStreamWriter stream = new core.NetworkByteStreamWriter();
		
		stream.WriteGuid( SceneObject_Reflection.MetadataClass.Guid );
		stream.WriteGuid( SceneObject_Member_TestFunction.Member.Guid );
		stream.WriteGuid( this.Guid );
		
		stream.WriteInt32( argInt );
		Vec3_ByteStream.ObjectToByteStream( stream, argVec );
		stream.WriteGuid( argRef != null ? argRef.Guid : Guid.Empty );
		stream.WriteInt32( (int)argEnum );
		stream.WriteBytes( System.Text.Encoding.ASCII.GetBytes( argString ) );
		Color_ByteStream.ObjectToByteStream( stream, argColor );
	
		data.remote.Client.SendToServer( stream.ToArray() );
	}
	
};


} /* namespace scene */ 
