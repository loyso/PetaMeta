using System;
using System.Collections.Generic;

namespace reflection
{
	public partial class MetadataClass
	{
		public virtual core.DataObject	New() 									{ return null; }
		public virtual void 			Delete( core.DataObject dataObject )	{}
	}

	public partial class Value
	{
		public virtual bool SetObjectValue( core.DataObject ThisUnityped, core.DataObject dataObjectUnityped )		{ return false; }
		public virtual bool GetObjectValue( core.DataObject ThisUnityped, ref core.DataObject dataObjectUnityped )	{ return false; }

		public virtual bool GetObjectValue_ToByteStream( core.ByteStreamWriter stream, core.DataObject dataObjectUnityped ) { return false; }
	}

	public partial class Reference
	{
		public virtual bool SetObjectValue( core.DataObject ThisUnityped, core.DataObject dataObjectUnityped )		{ return false; }
		public virtual bool GetObjectValue( core.DataObject ThisUnityped, ref core.DataObject dataObjectUnityped )	{ return false; }
	}

	public partial class ParentReference
	{
		public virtual bool SetObjectValue( core.DataObject ThisUnityped, core.DataObject dataObjectUnityped )		{ return false; }
		public virtual bool GetObjectValue( core.DataObject ThisUnityped, ref core.DataObject dataObjectUnityped )	{ return false; }
	}

	public partial class FileStorage
	{
		public virtual bool SetObjectValue( core.DataObject ThisUnityped, core.DataObject dataObjectUnityped )		{ return false; }
		public virtual bool GetObjectValue( core.DataObject ThisUnityped, ref core.DataObject dataObjectUnityped )	{ return false; }
	}

	public partial class Collection
	{
		public virtual bool GetCollectionObject( core.DataObject ThisUnityped, ref core.DataObject collectionUnityped ) { return false; }
	}

} // namespace reflection
