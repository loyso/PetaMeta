
// AUTOGENERATED FILE. MODIFY IT AT YOUR OWN RISK.

#include "Project.h"

#include "..\..\Reflection.h"

#include "Project.Reflection.h"

// depends on parent/reference files
// depends on reflection files

namespace game { 

class Game_Member_globals : public reflection::Value
{
public:
	Game_Member_globals()
	{
		Set_Guid("17cf6cc9-44c8-4f8f-ac47-1b6093007641");
		Set_Name("globals");
	}
	virtual bool SetObjectValue( core::DataObject & ThisUnityped, core::DataObject * pDataObjectUnityped ) const
	{
		game::Game * pThis = core::polymorphic_downcast< game::Game * >( &ThisUnityped );
		if ( !pThis )
			return false;
		game::Globals const * pDataObject = core::polymorphic_downcast < game::Globals const * > ( pDataObjectUnityped );
		if ( !pDataObject )
			return false;
		pThis->Set_globals( *pDataObject );
		return true;
	}
	virtual bool GetObjectValue( core::DataObject const & ThisUnityped, core::DataObject * & pDataObjectUnityped ) const
	{
		game::Game const * pThis = core::polymorphic_downcast< game::Game const * >( &ThisUnityped );
		if ( !pThis )
			return false;
		game::Globals * pDataObject = CORE_NEW game::Globals();
		*pDataObject = pThis->Get_globals();
		pDataObjectUnityped = pDataObject;
		return true;
	}
	virtual bool SetObjectValue_FromByteStream( core::DataObject & ThisUnityped, core::ByteStreamReader & stream ) const
	{
		game::Game * pThis = core::polymorphic_downcast< game::Game * >( &ThisUnityped );
		if ( !pThis )
			return false;
		game::Globals value; if ( !game::Globals_ByteStream::ObjectFromByteStream( stream, value ) ) return false;
		pThis->Set_globals( value );
		return true;
	}	
};

class Game_Member_gui : public reflection::Value
{
public:
	Game_Member_gui()
	{
		Set_Guid("76d80037-df45-4a70-97e5-d03b47c1b26f");
		Set_Name("gui");
	}
	virtual bool SetObjectValue( core::DataObject & ThisUnityped, core::DataObject * pDataObjectUnityped ) const
	{
		game::Game * pThis = core::polymorphic_downcast< game::Game * >( &ThisUnityped );
		if ( !pThis )
			return false;
		gui::Gui const * pDataObject = core::polymorphic_downcast < gui::Gui const * > ( pDataObjectUnityped );
		if ( !pDataObject )
			return false;
		pThis->Set_gui( *pDataObject );
		return true;
	}
	virtual bool GetObjectValue( core::DataObject const & ThisUnityped, core::DataObject * & pDataObjectUnityped ) const
	{
		game::Game const * pThis = core::polymorphic_downcast< game::Game const * >( &ThisUnityped );
		if ( !pThis )
			return false;
		gui::Gui * pDataObject = CORE_NEW gui::Gui();
		*pDataObject = pThis->Get_gui();
		pDataObjectUnityped = pDataObject;
		return true;
	}
	virtual bool SetObjectValue_FromByteStream( core::DataObject & ThisUnityped, core::ByteStreamReader & stream ) const
	{
		game::Game * pThis = core::polymorphic_downcast< game::Game * >( &ThisUnityped );
		if ( !pThis )
			return false;
		gui::Gui value; if ( !gui::Gui_ByteStream::ObjectFromByteStream( stream, value ) ) return false;
		pThis->Set_gui( value );
		return true;
	}	
};

class Game_Member_levels : public reflection::Value
{
public:
	Game_Member_levels()
	{
		Set_Guid("200e773c-0740-4dc1-ad0b-1d41d669f045");
		Set_Name("levels");
	}
	virtual bool SetObjectValue( core::DataObject & ThisUnityped, core::DataObject * pDataObjectUnityped ) const
	{
		game::Game * pThis = core::polymorphic_downcast< game::Game * >( &ThisUnityped );
		if ( !pThis )
			return false;
		level::Levels const * pDataObject = core::polymorphic_downcast < level::Levels const * > ( pDataObjectUnityped );
		if ( !pDataObject )
			return false;
		pThis->Set_levels( *pDataObject );
		return true;
	}
	virtual bool GetObjectValue( core::DataObject const & ThisUnityped, core::DataObject * & pDataObjectUnityped ) const
	{
		game::Game const * pThis = core::polymorphic_downcast< game::Game const * >( &ThisUnityped );
		if ( !pThis )
			return false;
		level::Levels * pDataObject = CORE_NEW level::Levels();
		*pDataObject = pThis->Get_levels();
		pDataObjectUnityped = pDataObject;
		return true;
	}
	virtual bool SetObjectValue_FromByteStream( core::DataObject & ThisUnityped, core::ByteStreamReader & stream ) const
	{
		game::Game * pThis = core::polymorphic_downcast< game::Game * >( &ThisUnityped );
		if ( !pThis )
			return false;
		level::Levels value; if ( !level::Levels_ByteStream::ObjectFromByteStream( stream, value ) ) return false;
		pThis->Set_levels( value );
		return true;
	}	
};

class Game_Member_SetObjectValue_Server : public reflection::FunctionUser
{
public:
	Game_Member_SetObjectValue_Server()
	{
		Set_Guid("3491d868-eb38-4bdb-8e24-404a06714f29");
		Set_Name("SetObjectValue_Server");
	}
	virtual bool FunctionCall_FromByteStream( core::ByteStreamReader & stream, reflection::MetadataClass const & type, core::ReferenceObject * pObjectUnityped )
	{
		core::Guid Arg_metadataType; if ( !stream.ReadGuid( Arg_metadataType ) ) return false;

		core::Guid Arg_metadataMember; if ( !stream.ReadGuid( Arg_metadataMember ) ) return false;

		core::Guid Arg_dataObject; if ( !stream.ReadGuid( Arg_dataObject ) ) return false;

		core::uint32 Arg_dataValue_Size; if ( !stream.ReadSize( Arg_dataValue_Size ) ) return false;
		void const * Arg_dataValue; if ( !stream.ReadBytes( Arg_dataValue_Size, Arg_dataValue ) ) return false;

		game::Game::SetObjectValue_Server ( Arg_metadataType, Arg_metadataMember, Arg_dataObject, Arg_dataValue, Arg_dataValue_Size );
		return true; 
	}
};

class Game_Member_SetObjectReference_Server : public reflection::FunctionUser
{
public:
	Game_Member_SetObjectReference_Server()
	{
		Set_Guid("0fbf300f-6504-4d20-841a-64d70eea4796");
		Set_Name("SetObjectReference_Server");
	}
	virtual bool FunctionCall_FromByteStream( core::ByteStreamReader & stream, reflection::MetadataClass const & type, core::ReferenceObject * pObjectUnityped )
	{
		core::Guid Arg_metadataType; if ( !stream.ReadGuid( Arg_metadataType ) ) return false;

		core::Guid Arg_metadataMember; if ( !stream.ReadGuid( Arg_metadataMember ) ) return false;

		core::Guid Arg_dataObject; if ( !stream.ReadGuid( Arg_dataObject ) ) return false;

		core::Guid Arg_referenceValue; if ( !stream.ReadGuid( Arg_referenceValue ) ) return false;

		game::Game::SetObjectReference_Server ( Arg_metadataType, Arg_metadataMember, Arg_dataObject, Arg_referenceValue );
		return true; 
	}
};

class Game_Member_SetObjectParentReference_Server : public reflection::FunctionUser
{
public:
	Game_Member_SetObjectParentReference_Server()
	{
		Set_Guid("d1c5f8b9-a077-40d2-8b14-37a2d6887af0");
		Set_Name("SetObjectParentReference_Server");
	}
	virtual bool FunctionCall_FromByteStream( core::ByteStreamReader & stream, reflection::MetadataClass const & type, core::ReferenceObject * pObjectUnityped )
	{
		core::Guid Arg_metadataType; if ( !stream.ReadGuid( Arg_metadataType ) ) return false;

		core::Guid Arg_metadataMember; if ( !stream.ReadGuid( Arg_metadataMember ) ) return false;

		core::Guid Arg_dataObject; if ( !stream.ReadGuid( Arg_dataObject ) ) return false;

		core::Guid Arg_referenceValue; if ( !stream.ReadGuid( Arg_referenceValue ) ) return false;

		game::Game::SetObjectParentReference_Server ( Arg_metadataType, Arg_metadataMember, Arg_dataObject, Arg_referenceValue );
		return true; 
	}
};

class Game_Member_SetObjectFileStorage_Server : public reflection::FunctionUser
{
public:
	Game_Member_SetObjectFileStorage_Server()
	{
		Set_Guid("7de35da6-b5c6-4c59-898d-674e50be4a93");
		Set_Name("SetObjectFileStorage_Server");
	}
	virtual bool FunctionCall_FromByteStream( core::ByteStreamReader & stream, reflection::MetadataClass const & type, core::ReferenceObject * pObjectUnityped )
	{
		core::Guid Arg_metadataType; if ( !stream.ReadGuid( Arg_metadataType ) ) return false;

		core::Guid Arg_metadataMember; if ( !stream.ReadGuid( Arg_metadataMember ) ) return false;

		core::Guid Arg_dataObject; if ( !stream.ReadGuid( Arg_dataObject ) ) return false;

		core::Guid Arg_referenceValue; if ( !stream.ReadGuid( Arg_referenceValue ) ) return false;

		game::Game::SetObjectFileStorage_Server ( Arg_metadataType, Arg_metadataMember, Arg_dataObject, Arg_referenceValue );
		return true; 
	}
};

class Game_Member_NewObject_Server : public reflection::FunctionUser
{
public:
	Game_Member_NewObject_Server()
	{
		Set_Guid("f12e94f1-f3e1-4cc1-9fda-1fb7eaed0316");
		Set_Name("NewObject_Server");
	}
	virtual bool FunctionCall_FromByteStream( core::ByteStreamReader & stream, reflection::MetadataClass const & type, core::ReferenceObject * pObjectUnityped )
	{
		core::Guid Arg_metadataType; if ( !stream.ReadGuid( Arg_metadataType ) ) return false;

		core::Guid Arg_dataObject; if ( !stream.ReadGuid( Arg_dataObject ) ) return false;

		game::Game::NewObject_Server ( Arg_metadataType, Arg_dataObject );
		return true; 
	}
};

class Game_Member_DeleteObject_Server : public reflection::FunctionUser
{
public:
	Game_Member_DeleteObject_Server()
	{
		Set_Guid("5f86a605-9657-4ed8-a312-3e67229df7e3");
		Set_Name("DeleteObject_Server");
	}
	virtual bool FunctionCall_FromByteStream( core::ByteStreamReader & stream, reflection::MetadataClass const & type, core::ReferenceObject * pObjectUnityped )
	{
		core::Guid Arg_metadataType; if ( !stream.ReadGuid( Arg_metadataType ) ) return false;

		core::Guid Arg_dataObject; if ( !stream.ReadGuid( Arg_dataObject ) ) return false;

		game::Game::DeleteObject_Server ( Arg_metadataType, Arg_dataObject );
		return true; 
	}
};


Game_Reflection::Game_Reflection()
{
	Set_Guid("56e8a41d-bf20-475f-aa07-0a512975f527");
	Set_TypeName("Game");	
	Get_Members().Add( CORE_NEW Game_Member_globals() );
	Get_Members().Add( CORE_NEW Game_Member_gui() );
	Get_Members().Add( CORE_NEW Game_Member_levels() );
	Get_Members().Add( CORE_NEW Game_Member_SetObjectValue_Server() );
	Get_Members().Add( CORE_NEW Game_Member_SetObjectReference_Server() );
	Get_Members().Add( CORE_NEW Game_Member_SetObjectParentReference_Server() );
	Get_Members().Add( CORE_NEW Game_Member_SetObjectFileStorage_Server() );
	Get_Members().Add( CORE_NEW Game_Member_NewObject_Server() );
	Get_Members().Add( CORE_NEW Game_Member_DeleteObject_Server() );
}

void Game_Reflection::CopyObjectDataFromTo( Game const & from, Game & to )
{
	// TODO: implement
}

core::ReferenceObject * Game_Reflection::New() const
{ 
	return CORE_NEW game::Game(); 
}

void Game_Reflection::Delete( core::ReferenceObject * pDataObject ) const
{ 
	CORE_DELETE pDataObject; 
}

} /* namespace game */ 
