using System;
using System.Collections.Generic;

namespace level 
{ 
	public partial class LevelFolder
	{
		public bool DependsOn( core.IFolderStorageObject folderStorageObject )
		{
			foreach( level.Dependency d in dependencies )
			{
				if ( d.LevelFolder == folderStorageObject )
					return true;
				if ( d.LevelFolder.DependsOn( folderStorageObject ) )
					return true;
			}
			return false;
		}
	}
}

namespace gui 
{ 
	public partial class GuiCommon
	{
		public bool DependsOn( core.IFolderStorageObject folderStorageObject )
		{
			return false;
		}
	}
}

namespace data
{
	namespace remote
	{
		public class Client
		{
			public static void SendToServer( byte[] message )
			{
			}
		}
	}
}

namespace data
{
	public partial class Remoting
	{
		public static void NewObject( reflection.MetadataClass metadataClass, core.ReferenceObject referenceObject ) 
		{
			game.Game.NewObject_Server( metadataClass.Guid, referenceObject.Guid );
		} 
		public static void DeleteObject( reflection.MetadataClass metadataClass, core.ReferenceObject referenceObject ) 
		{
			game.Game.DeleteObject_Server( metadataClass.Guid, referenceObject.Guid );
		} 

		public static void SetObject_Value( reflection.MetadataClass metadataClass, core.ReferenceObject referenceObject, reflection.Value member, core.DataObject dataValue )
		{
			core.NetworkByteStreamWriter stream = new core.NetworkByteStreamWriter();
			member.GetObjectValue_ToByteStream( stream, dataValue );
			game.Game.SetObjectValue_Server( metadataClass.Guid, member.Guid, referenceObject.Guid, stream.ToArray() );
		}
		public static void SetObject_Reference( reflection.MetadataClass metadataClass, core.ReferenceObject referenceObject, reflection.Reference member, core.ReferenceObject referenceValue )
		{
			game.Game.SetObjectReference_Server( metadataClass.Guid, member.Guid, referenceObject.Guid, referenceValue != null ? referenceValue.Guid : Guid.Empty );
		}
		public static void SetObject_ParentReference( reflection.MetadataClass metadataClass, core.ReferenceObject referenceObject, reflection.ParentReference member, core.ReferenceObject referenceValue )
		{
			game.Game.SetObjectParentReference_Server( metadataClass.Guid, member.Guid, referenceObject.Guid, referenceValue != null ? referenceValue.Guid : Guid.Empty );
		}
		public static void SetObject_FileStorage( reflection.MetadataClass metadataClass, core.ReferenceObject referenceObject, reflection.FileStorage member, core.ReferenceObject referenceValue )
		{
			game.Game.SetObjectFileStorage_Server( metadataClass.Guid, member.Guid, referenceObject.Guid, referenceValue != null ? referenceValue.Guid : Guid.Empty );
		}
	}
}