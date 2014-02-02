using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core
{
	public interface IRemoteObject
	{
		void RemoteCreate();
		void RemoteDestroy();	
		void RemoteUpload();
		void RemoteUnload();
		bool IsRemoteUploaded { get; }
	}

	public interface IByteStream
	{
		void ToByteStream( core.ByteStreamWriter stream );
		void FromByteStream( core.ByteStreamReader stream );
	}
} // core
