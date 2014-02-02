#include "DataCpp.RemoteServer.h"

namespace data
{

bool remote::Server_Partial::ReceiveFromClient( void const * bytes, size_t bytesSize )
{
	core::NetworkByteStreamReader stream( bytes, bytesSize );
	
	core::Guid typeGuid; 
	if ( !stream.ReadGuid( typeGuid ) )
		return false;
		
	reflection::MetadataClass * pType = NULL;
	if ( !data::Reflection::FindMetadataClass( typeGuid, pType ) )
		return false;

	core::Guid memberFunctionGuid; 
	if ( !stream.ReadGuid( memberFunctionGuid ) )
		return false;
		
	reflection::Function * pMemberFunction = NULL;
	if ( !data::Reflection::FindMemberFunction( memberFunctionGuid, pMemberFunction ) )
		return false;

	core::Guid objectGuid; 
	if ( !stream.ReadGuid( objectGuid ) )
		return false;
		
	core::ReferenceObject * pObject = NULL;
	if ( !objectGuid.IsEmpty() && !core::Objects::FindObject( objectGuid, pObject ) )
		return false;

	return pMemberFunction->FunctionCall_FromByteStream( stream, *pType, pObject );
}

} // data

