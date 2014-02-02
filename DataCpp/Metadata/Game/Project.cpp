
#include "Project.h"

#include "..\..\DataCpp.Reflection.h"
#include "..\..\DataCpp.RemoteServer.h"

namespace game { 

void Game::NewObject_Server ( core::Guid const & metadataType, core::Guid const & dataObject )
{
	reflection::MetadataClass * pMetadataClass = NULL;
	if ( !data::Reflection::FindMetadataClass( metadataType, pMetadataClass ) )
		return;

	core::ReferenceObject * pDataObject = pMetadataClass->New();
	if ( pDataObject == NULL )
		return;

	pDataObject->Set_Guid( dataObject );
	core::Objects::Add( *pDataObject );
}

void Game::DeleteObject_Server ( core::Guid const & metadataType, core::Guid const & dataObject )
{
	reflection::MetadataClass * pMetadataClass = NULL;
	if ( !data::Reflection::FindMetadataClass( metadataType, pMetadataClass ) )
		return;

	core::ReferenceObject * pDataObject = NULL;
	if ( !core::Objects::FindObject( dataObject, pDataObject ) )
		return;

	core::Objects::Remove( *pDataObject );
	pDataObject->Set_Guid( core::Guid::Empty );
	pMetadataClass->Delete( pDataObject );
}

void Game::SetObjectValue_Server ( core::Guid const & metadataType, core::Guid const & metadataMember, core::Guid const & dataObject, void const * dataValue, size_t dataValueSize )
{
	reflection::MetadataClass * pMetadataClass = NULL;
	if ( !data::Reflection::FindMetadataClass( metadataType, pMetadataClass ) )
		return;

	reflection::Member * pMember = NULL;
	if ( !pMetadataClass->FindMember( metadataMember, pMember ) )
		return;

	reflection::Value * pValue = core::polymorphic_cast < reflection::Value * >( pMember );
	if ( pValue == NULL )
		return;

	core::ReferenceObject * pDataObject = NULL;
	if ( core::Objects::FindObject( dataObject, pDataObject ) )
	{
		core::NetworkByteStreamReader stream( dataValue, dataValueSize );
		pValue->SetObjectValue_FromByteStream( *pDataObject, stream );
	}
}

void Game::SetObjectReference_Server ( core::Guid const & metadataType, core::Guid const & metadataMember, core::Guid const & dataObject, core::Guid const & referenceValue )
{
	reflection::MetadataClass * pMetadataClass = NULL;
	if ( !data::Reflection::FindMetadataClass( metadataType, pMetadataClass ) )
		return;

	reflection::Member * pMember = NULL;
	if ( !pMetadataClass->FindMember( metadataMember, pMember ) )
		return;

	reflection::Reference * pMemberReference = core::polymorphic_cast < reflection::Reference * >( pMember );
	if ( pMemberReference == NULL )
		return;

	core::ReferenceObject * pReferencedObject = NULL;
	if ( !referenceValue.IsEmpty() && !core::Objects::FindObject( referenceValue, pReferencedObject ) )
		return;

	core::ReferenceObject * pDataObject = NULL;
	if ( core::Objects::FindObject( dataObject, pDataObject ) )
		pMemberReference->SetObjectValue( *pDataObject, pReferencedObject );
}

void Game::SetObjectParentReference_Server ( core::Guid const & metadataType, core::Guid const & metadataMember, core::Guid const & dataObject, core::Guid const & referenceValue )
{
	reflection::MetadataClass * pMetadataClass = NULL;
	if ( !data::Reflection::FindMetadataClass( metadataType, pMetadataClass ) )
		return;

	reflection::Member * pMember = NULL;
	if ( !pMetadataClass->FindMember( metadataMember, pMember ) )
		return;

	reflection::ParentReference * pMemberParentReference = core::polymorphic_cast < reflection::ParentReference * >( pMember );
	if ( pMemberParentReference == NULL )
		return;

	core::ReferenceObject * pReferencedObject = NULL;
	if ( !referenceValue.IsEmpty() && !core::Objects::FindObject( referenceValue, pReferencedObject ) )
		return;

	core::ReferenceObject * pDataObject = NULL;
	if ( core::Objects::FindObject( dataObject, pDataObject ) )
		pMemberParentReference->SetObjectValue( *pDataObject, pReferencedObject );
}

void Game::SetObjectFileStorage_Server ( core::Guid const & metadataType, core::Guid const & metadataMember, core::Guid const & dataObject, core::Guid const & referenceValue )
{
	reflection::MetadataClass * pMetadataClass = NULL;
	if ( !data::Reflection::FindMetadataClass( metadataType, pMetadataClass ) )
		return;

	reflection::Member * pMember = NULL;
	if ( !pMetadataClass->FindMember( metadataMember, pMember ) )
		return;

	reflection::FileStorage * pMemberFileStorage = core::polymorphic_cast < reflection::FileStorage * >( pMember );
	if ( pMemberFileStorage == NULL )
		return;

	core::ReferenceObject * pReferencedObject = NULL;
	if ( !referenceValue.IsEmpty() && !core::Objects::FindObject( referenceValue, pReferencedObject ) )
		return;

	core::ReferenceObject * pDataObject = NULL;
	if ( core::Objects::FindObject( dataObject, pDataObject ) )
		pMemberFileStorage->SetObjectValue( *pDataObject, pReferencedObject );
}


} /* namespace game */ 
