#include "DataCpp.Reflection.h"

#include "Metadata\Engine\Fundamental.Reflection.h"
#include "Metadata\Game\ProjectGlobals.Reflection.h"
#include "Metadata\Game\Project.Reflection.h"
#include "Metadata\Game\ProjectGui.Reflection.h"
#include "Metadata\Game\ProjectLevels.Reflection.h"
#include "Metadata\Game\Gui.Reflection.h"
#include "Metadata\Game\Scene.Reflection.h"

namespace data {

struct ReflectionData
{
	typedef core::Dictionary< core::Guid, core::ReferenceObject * > GuidToObject_t;
	GuidToObject_t GuidToObject;

	typedef core::List< reflection::MetadataClass * > MetadataClasses_t;
	MetadataClasses_t MetadataClasses;
};

ReflectionData * gThis = NULL;

void Reflection::Init()
{
	CORE_ASSERT( gThis == NULL );
	gThis = CORE_NEW ReflectionData();
	
	reflection::MetadataClass * pMetadataClass = NULL;
	
	pMetadataClass = CORE_NEW Vec2_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW Vec3_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW Vec4_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW Color_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW game::Globals_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW game::Game_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW gui::Gui_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW gui::GuiCommon_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW gui::GuiMainMenu_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW gui::GuiGame_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW gui::GuiFile_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW gui::GuiFilesCollection_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW level::Levels_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW level::LevelFolder_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW level::LevelFoldersCollection_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW level::LevelBlock_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW level::LevelBlocksCollection_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW level::LevelFile_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW level::LevelFilesCollection_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW level::Dependency_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW level::Dependencies_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW gui::Window_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW gui::WindowsCollection_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW scene::SceneObject_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW scene::SceneObjectsCollection_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW scene::SceneMesh_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW scene::SceneAnimMesh_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW scene::SceneZoneTrigger_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW scene::Scene_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW scene::Controller_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW scene::ControllerBox_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
	pMetadataClass = CORE_NEW scene::ControllerSphere_Reflection();
	gThis->MetadataClasses.Add( pMetadataClass );
	gThis->GuidToObject.Add( pMetadataClass->Get_Guid(), pMetadataClass );
	for ( reflection::MembersCollection_Partial::ConstIterator i = pMetadataClass->Get_Members().Begin(), e = pMetadataClass->Get_Members().End(); i!=e; ++i )
	{
		reflection::Member & member = **i;
		gThis->GuidToObject.Add( member.Get_Guid(), &member );
	}
}

void Reflection::Done()
{
	CORE_ASSERT( gThis );
	
	gThis->GuidToObject.Clear();
	
	for ( ReflectionData::MetadataClasses_t::ConstIterator i = gThis->MetadataClasses.Begin(), e = gThis->MetadataClasses.End(); i != e; ++i )
		CORE_DELETE *i;
	gThis->MetadataClasses.Clear();
	
	CORE_DELETE gThis;
	gThis = NULL;
}

bool Reflection::FindObject( core::Guid const & guid, core::ReferenceObject * & pReferenceObject )
{
	CORE_ASSERT( gThis );
	return gThis->GuidToObject.TryGetValue( guid, pReferenceObject );
}

bool Reflection::FindMetadataClass( core::Guid const & guid, reflection::MetadataClass * & pMetadataClass )
{
	core::ReferenceObject * pReferenceObject = NULL;
	if ( !FindObject( guid, pReferenceObject ) )
		return false;
	pMetadataClass = core::polymorphic_cast< reflection::MetadataClass * >( pReferenceObject );
	return pMetadataClass != NULL;
}

bool Reflection::FindMemberFunction( core::Guid const & guid, reflection::Function * & pMemberFunction )
{
	core::ReferenceObject * pReferenceObject = NULL;
	if ( !FindObject( guid, pReferenceObject ) )
		return false;
	pMemberFunction = core::polymorphic_cast< reflection::Function * >( pReferenceObject );
	return pMemberFunction != NULL;
}

bool Reflection::FindMemberValue( core::Guid const & guid, reflection::Value * & pMemberValue )
{
	core::ReferenceObject * pReferenceObject = NULL;
	if ( !FindObject( guid, pReferenceObject ) )
		return false;
	pMemberValue = core::polymorphic_cast< reflection::Value * >( pReferenceObject );
	return pMemberValue != NULL;
}

} // namespace data
