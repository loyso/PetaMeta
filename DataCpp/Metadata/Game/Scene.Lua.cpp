
// AUTOGENERATED FILE. MODIFY IT AT YOUR OWN RISK.

#include "..\..\CoreLua.h"

#include "Scene.h"

// depends on parent/reference files

namespace scene { 

namespace Lua_SceneObject
{
	static lua::Table * gTypeLuaTable;
	
	static int TestLua ( lua_State * L )
	{
		static const char FUNCTION_NAME[] = "Lua_SceneObject::TestLua";
		
		lua::State state ( L );
		if ( state.NumArgs() != 5 )
		{
			string err = FUNCTION_NAME;	err = err + ", num args error, expected: 5, got: " + lua::IntToStr( state.NumArgs() );
			return state.FunctionError ( err );
		}
		
		SceneObject * pThis = NULL;
		if ( state.IsTable ( 1 ) )
			pThis = core::polymorphic_cast < SceneObject * > ( state.GetTypedTableThis < core::DataObject * > ( 1 ) );
		else if ( state.IsTypedUserdata < core::DataObject * > ( 1 ) )
			pThis = core::polymorphic_cast < SceneObject * > ( state.GetTypedUserdata < core::DataObject * > ( 1 ) );
		else { string err = FUNCTION_NAME; err = err + ", 'this' table or pointer expected as a first argument"; return state.FunctionError ( err ); }
		
		bool argBool;
		if ( state.Is <bool> ( 2 ) )	argBool = state.Get <bool > ( 2 );
		else { string err = FUNCTION_NAME; err = err + ", argument argBool: bool expected";	return state.FunctionError ( err );	}
		
		Vec3 argVec3;
		if ( state.Is <Vec3> ( 3 ) )	argVec3 = state.Get <Vec3 > ( 3 );
		else { string err = FUNCTION_NAME; err = err + ", argument argVec3: Vec3 expected";	return state.FunctionError ( err );	}
		
		float argFloat;
		if ( state.Is <float> ( 4 ) )	argFloat = state.Get <float > ( 4 );
		else { string err = FUNCTION_NAME; err = err + ", argument argFloat: float expected";	return state.FunctionError ( err );	}
		
		scene::SceneObject * argRef;
		if ( state.IsTable ( 5 ) ) argRef = core::polymorphic_cast < SceneObject * > ( state.GetTypedTableThis < core::DataObject * > ( 5 ) );
		else if ( state.IsTypedUserdata < core::DataObject * > ( 5 ) ) argRef = core::polymorphic_cast < SceneObject * > ( state.GetTypedUserdata < core::DataObject * > ( 5 ) );
		else { string err = FUNCTION_NAME;	err = err + ", argument argRef: table or pointer expected";	return state.FunctionError ( err );	}
		
		bool res = pThis->TestLua( argBool, argVec3, argFloat, argRef );
		
		state.Push( res );
		return 1;
	}
			
} // namespace Lua_SceneObject

void SceneObject_Lua::LuaTypeTableCreate( lua::Host & host )
{
	CORE_ASSERT( Lua_SceneObject::gTypeLuaTable == NULL );
	
	lua::Table & table = host.TableConstruct();
	table.SetFunction ( "TestLua", Lua_SceneObject::TestLua );

	Lua_SceneObject::gTypeLuaTable = &table;
}

void SceneObject_Lua::LuaTypeTableDestroy( lua::Host & host )
{
	CORE_ASSERT( Lua_SceneObject::gTypeLuaTable );
	host.TableDestruct ( *Lua_SceneObject::gTypeLuaTable );
	Lua_SceneObject::gTypeLuaTable = NULL;	
}

int SceneObject_Lua::LuaLookup ( lua_State * L ) // args: [1] - table, [2] - key
{
	lua::State state ( L );
			
	CORE_ASSERT( Lua_SceneObject::gTypeLuaTable );
	Lua_SceneObject::gTypeLuaTable->PushValueAt( state, 2 );
	
	if ( state.IsCFunction( -1 ) )
		return 1;

	state.PopArgs( 1 );		
	return 0;
}

SceneObject_Lua::SceneObject_Lua()
{
	pLuaTable = NULL;
}

SceneObject_Lua::~SceneObject_Lua()
{
	CORE_ASSERT( pLuaTable == NULL );
}

lua::Table & SceneObject_Lua::LuaTable() const
{
	CORE_ASSERT( pLuaTable );
	return *pLuaTable;
}

lua::Table * SceneObject_Lua::LuaTableGet() const
{
	return pLuaTable;
}

void SceneObject_Lua::LuaTableSet( lua::Table * pTable )
{
	pLuaTable = pTable;
}

void SceneObject_Lua::LuaTableCreate( lua::Host & host )
{
	SceneObject * pThis = static_cast < SceneObject * > ( this );
	
	lua::Table & table = host.TableConstruct();
	pThis->LuaTableSet( &table );	
	
	table.SetThis( static_cast < core::DataObject * > ( pThis ) );
	table.SetMetatableIndex( LuaLookup );
}

void SceneObject_Lua::LuaTableDestroy( lua::Host & host )
{
	SceneObject * pThis = static_cast < SceneObject * > ( this );
	
	lua::Table & table = pThis->LuaTable();
	
	table.ResetMetatable();
	table.ResetThis();
	
	pThis->LuaTableSet( NULL );
	host.TableDestruct( table );
}

bool SceneObject_Lua::TestLuaCC( float argStr, byte argByte)
{
	SceneObject * pThis = static_cast < SceneObject * > ( this );

	lua::Call * pCallCc = CORE_NEW lua::Call ( pThis->LuaTable().m_Host );

	bool result = false;
	if ( pThis->LuaTable().PushFunction( pCallCc->m_Thread, "TestLuaCC" ) )
	{
		int nResults;
		lua::WorkResult::Enum workResult = pCallCc->FunctionCall( *pThis, 2, nResults );
		switch( workResult )
		{
		case lua::WorkResult::YIELD:
			result = true;
			break;
		case lua::WorkResult::RETURN:
			break;
		case lua::WorkResult::ERR:
			break;
		}
	}
	return result;
}

bool SceneObject_Lua::LuaConstructor()
{
	SceneObject * pThis = static_cast < SceneObject * > ( this );

	lua::State & state = pThis->LuaTable().m_Host;

	if ( pThis->LuaTable().PushFunction( "LuaConstructor" ) )
	{
		if ( state.FunctionCall( 0, 0 ) )
		{
			return true;
		}
	}
	return false;
}

bool SceneObject_Lua::LuaDestructor()
{
	SceneObject * pThis = static_cast < SceneObject * > ( this );

	lua::State & state = pThis->LuaTable().m_Host;

	if ( pThis->LuaTable().PushFunction( "LuaDestructor" ) )
	{
		if ( state.FunctionCall( 0, 0 ) )
		{
			return true;
		}
	}
	return false;
}


namespace Lua_SceneMesh
{
	static lua::Table * gTypeLuaTable;
	
	static int TestLuaDerived ( lua_State * L )
	{
		static const char FUNCTION_NAME[] = "Lua_SceneMesh::TestLuaDerived";
		
		lua::State state ( L );
		if ( state.NumArgs() != 2 )
		{
			string err = FUNCTION_NAME;	err = err + ", num args error, expected: 2, got: " + lua::IntToStr( state.NumArgs() );
			return state.FunctionError ( err );
		}
		
		SceneMesh * pThis = NULL;
		if ( state.IsTable ( 1 ) )
			pThis = core::polymorphic_cast < SceneMesh * > ( state.GetTypedTableThis < core::DataObject * > ( 1 ) );
		else if ( state.IsTypedUserdata < core::DataObject * > ( 1 ) )
			pThis = core::polymorphic_cast < SceneMesh * > ( state.GetTypedUserdata < core::DataObject * > ( 1 ) );
		else { string err = FUNCTION_NAME; err = err + ", 'this' table or pointer expected as a first argument"; return state.FunctionError ( err ); }
		
		int argInt;
		if ( state.Is <int> ( 2 ) )	argInt = state.Get <int > ( 2 );
		else { string err = FUNCTION_NAME; err = err + ", argument argInt: int expected";	return state.FunctionError ( err );	}
		
		scene::SceneAnimMesh * res = pThis->TestLuaDerived( argInt );
		
		if ( res == NULL )
			state.PushTypedUserdata< core::DataObject * >( res );
		else if ( res->LuaTableGet() )
			state.PushTable( res->LuaTable() );
		return 1;
	}
			
} // namespace Lua_SceneMesh

void SceneMesh_Lua::LuaTypeTableCreate( lua::Host & host )
{
	CORE_ASSERT( Lua_SceneMesh::gTypeLuaTable == NULL );
	
	lua::Table & table = host.TableConstruct();
	table.SetFunction ( "TestLuaDerived", Lua_SceneMesh::TestLuaDerived );

	Lua_SceneMesh::gTypeLuaTable = &table;
}

void SceneMesh_Lua::LuaTypeTableDestroy( lua::Host & host )
{
	CORE_ASSERT( Lua_SceneMesh::gTypeLuaTable );
	host.TableDestruct ( *Lua_SceneMesh::gTypeLuaTable );
	Lua_SceneMesh::gTypeLuaTable = NULL;	
}

int SceneMesh_Lua::LuaLookup ( lua_State * L ) // args: [1] - table, [2] - key
{
	lua::State state ( L );
			
	CORE_ASSERT( Lua_SceneMesh::gTypeLuaTable );
	Lua_SceneMesh::gTypeLuaTable->PushValueAt( state, 2 );
	
	if ( state.IsCFunction( -1 ) )
		return 1;

	state.PopArgs( 1 );		
	return scene::SceneObject_Lua::LuaLookup( L );
}

SceneMesh_Lua::SceneMesh_Lua()
{
}

SceneMesh_Lua::~SceneMesh_Lua()
{
}


void SceneMesh_Lua::LuaTableCreate( lua::Host & host )
{
	SceneMesh * pThis = static_cast < SceneMesh * > ( this );
	
	lua::Table & table = host.TableConstruct();
	pThis->LuaTableSet( &table );	
	
	table.SetThis( static_cast < core::DataObject * > ( pThis ) );
	table.SetMetatableIndex( LuaLookup );
}

void SceneMesh_Lua::LuaTableDestroy( lua::Host & host )
{
	SceneMesh * pThis = static_cast < SceneMesh * > ( this );
	
	lua::Table & table = pThis->LuaTable();
	
	table.ResetMetatable();
	table.ResetThis();
	
	pThis->LuaTableSet( NULL );
	host.TableDestruct( table );
}

core::Optional<scene::Controller*> SceneMesh_Lua::TestLuaCall( Vec2 const & argVal, scene::SceneMesh* argRef)
{
	SceneMesh * pThis = static_cast < SceneMesh * > ( this );

	lua::State & state = pThis->LuaTable().m_Host;

	if ( pThis->LuaTable().PushFunction( "TestLuaCall" ) )
	{
		state.Push( argVal );
		if ( argRef == NULL )
			state.PushTypedUserdata< core::DataObject * >( argRef );
		else if ( argRef->LuaTableGet() )
			state.PushTable( argRef->LuaTable() );
		if ( state.FunctionCall( 2, 1 ) )
		{
			scene::Controller* myRes;
			if ( state.IsTable ( -1 ) )
			{
				myRes = core::polymorphic_cast < scene::Controller* > ( state.GetTypedTableThis < core::DataObject * > ( -1 ) );
				return core::Optional< scene::Controller* >( myRes );
			}
			else if ( state.IsTypedUserdata < core::DataObject * > ( -1 ) )
			{
				myRes = core::polymorphic_cast < scene::Controller* > ( state.GetTypedUserdata < core::DataObject * > ( -1 ) );
				return core::Optional< scene::Controller* >( myRes );
			}
		}
	}
	return core::Optional<scene::Controller*>();
}


} /* namespace scene */ 
