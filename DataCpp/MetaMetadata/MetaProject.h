
// USER'S CODE FILE. PLACE YOUR CLASSES, DATA AND FUNCTIONS HERE.

#ifndef MetaMetadata_MetaProject_h
#define MetaMetadata_MetaProject_h

#include "MetaProject.Partial.h"

namespace reflection { 

			
class MetadataFile : public core::ReferenceObject
	, public MetadataFile_Partial
{
};

			
class MetadataFolder : public core::ReferenceObject
	, public MetadataFolder_Partial
{
};

			
class MetadataMemberGroup : public core::ReferenceObject
	, public MetadataMemberGroup_Partial
{
};

			
class MetadataProject : public core::DataObject
	, public MetadataProject_Partial
{
};

} /* namespace reflection */ 

#endif // MetaMetadata_MetaProject_h
