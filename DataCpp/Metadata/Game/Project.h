
#ifndef Metadata_Game_Project_h
#define Metadata_Game_Project_h

#include "Project.Partial.h"

namespace game { 

			
class Game : public core::ReferenceObject
	, public Game_Partial
{
public:
	static void NewObject_Server ( core::Guid const & metadataType, core::Guid const & dataObject );
	static void DeleteObject_Server ( core::Guid const & metadataType, core::Guid const & dataObject );

	static void SetObjectValue_Server ( core::Guid const & metadataType, core::Guid const & metadataMember, core::Guid const & dataObject, void const * dataValue, size_t dataValueSize );
	static void SetObjectReference_Server ( core::Guid const & metadataType, core::Guid const & metadataMember, core::Guid const & dataObject, core::Guid const & referenceValue );
	static void SetObjectParentReference_Server ( core::Guid const & metadataType, core::Guid const & metadataMember, core::Guid const & dataObject, core::Guid const & referenceValue );
	static void SetObjectFileStorage_Server ( core::Guid const & metadataType, core::Guid const & metadataMember, core::Guid const & dataObject, core::Guid const & referenceValue );
};

} /* namespace game */ 

#endif // Metadata_Game_Project_h
