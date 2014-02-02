
// USER'S CODE FILE. PLACE YOUR CLASSES, DATA AND FUNCTIONS HERE.

#include "MetaClasses.h"

namespace reflection { 

bool MetadataClass::FindMember( core::Guid const & guid, reflection::Member * & pMember ) const
{
	for ( MembersCollection_Partial::ConstIterator i = Get_Members().Begin(), e = Get_Members().End(); i != e; ++i )
	{
		reflection::Member & member = **i;
		if ( member.Get_Guid() == guid )
		{
			pMember = &member;
			return true;
		}
	}

	return false;
}


} /* namespace reflection */ 
