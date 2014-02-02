#ifndef DataCpp_Reflection_h
#define DataCpp_Reflection_h

#include "Reflection.h"

namespace data {

namespace Reflection
{
	void Init();
	void Done();

	bool FindObject( core::Guid const & guid, core::ReferenceObject * & pReferenceObject );

	bool FindMetadataClass( core::Guid const & guid, reflection::MetadataClass * & pMetadataClass );
	
	bool FindMemberFunction( core::Guid const & guid, reflection::Function * & pMemberFunction );
	bool FindMemberValue( core::Guid const & guid, reflection::Value * & pMemberValue );
}


} // namespace data

#endif // DataCpp_Reflection_h
