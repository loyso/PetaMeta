
#ifndef Metadata_MetaClasses_h
#define Metadata_MetaClasses_h

#include "MetaClasses.Partial.h"

#include <cassert>

namespace core 
{
	class DataObject;
	class ReferenceObject;
	class ICollection;
}

namespace reflection { 

class Type : public core::ReferenceObject
	, public Type_Partial
{
};
		
class MetadataClass : public Type
	, public MetadataClass_Partial
{
public:
	virtual core::ReferenceObject * New() const { return NULL; }
	virtual void Delete( core::ReferenceObject * pDataObject ) const {}

	bool FindMember( core::Guid const & guid, reflection::Member * & pMember ) const;
};

			
class AbstractClass : public MetadataClass
	, public AbstractClass_Partial
{
};

			
class CollectionClass : public MetadataClass
	, public CollectionClass_Partial
{
};

			
class FileClass : public MetadataClass
	, public FileClass_Partial
{
};

			
class FolderClass : public MetadataClass
	, public FolderClass_Partial
{
};

			
class FolderStorageClass : public FolderClass
	, public FolderStorageClass_Partial
{
};

			
class ProjectClass : public MetadataClass
	, public ProjectClass_Partial
{
};

			
class MetadataFileContent : public core::DataObject
	, public MetadataFileContent_Partial
{
};

			
class Member : public core::ReferenceObject
	, public Member_Partial
{
};

			
class Value : public Member
	, public Value_Partial
{
public:
	virtual bool SetObjectValue( core::DataObject & ThisUnityped, core::DataObject * pUnityped ) const { return false; }
	virtual bool GetObjectValue( core::DataObject const & ThisUnityped, core::DataObject * & pUnityped ) const { return false; }

	virtual bool SetObjectValue_FromByteStream( core::DataObject & ThisUnityped, core::ByteStreamReader & stream ) const { return false; }
};

			
class ValueName : public Value
	, public ValueName_Partial
{
};

			
class Reference : public Member
	, public Reference_Partial
{
public:
	virtual bool SetObjectValue( core::DataObject & ThisUnityped, core::DataObject * pUnityped ) const { return false; }
	virtual bool GetObjectValue( core::DataObject const & ThisUnityped, core::DataObject * & pUnityped ) const { return false; }
};

			
class ParentReference : public Member
	, public ParentReference_Partial
{
public:
	virtual bool SetObjectValue( core::DataObject & ThisUnityped, core::DataObject * pUnityped ) const { return false; }
	virtual bool GetObjectValue( core::DataObject const & ThisUnityped, core::DataObject * & pUnityped ) const { return false; }
};

			
class Collection : public Member
	, public Collection_Partial
{
	virtual bool GetCollectionObject( core::DataObject const & ThisUnityped, core::ICollection const * & pCollectionUnityped ) const { return false; }
	virtual bool GetCollectionObject( core::DataObject & ThisUnityped, core::ICollection * & pCollectionUnityped ) const { return false; }
};

			
class FileStorage : public Member
	, public FileStorage_Partial
{
public:
	virtual bool SetObjectValue( core::DataObject & ThisUnityped, core::DataObject * pUnityped ) const { return false; }
	virtual bool GetObjectValue( core::DataObject const & ThisUnityped, core::DataObject * & pUnityped ) const { return false; }
};

} /* namespace reflection */ 

#endif // Metadata_MetaClasses_h
