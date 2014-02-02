#ifndef DataCpp_RemoteServer_h
#define DataCpp_RemoteServer_h

#include "Core.h"
#include "Reflection.h"

#include "DataCpp.Reflection.h"

namespace data
{
	namespace remote
	{
		class Server_Partial
		{
		public:
			bool ReceiveFromClient( void const * bytes, size_t bytesSize );
		};
	}
} // data

#endif // DataCpp_RemoteServer_h
