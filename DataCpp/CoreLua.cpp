
#include "CoreLua.h"

extern "C"
{
#include "../LibThirdParty/Lua/src/lua.h"
#include "../LibThirdParty/Lua/src/lauxlib.h"
#include "../LibThirdParty/Lua/src/lualib.h"
};

#ifdef NDEBUG
#	define CORE_VERIFY(x) (x) 
#else
#	define CORE_VERIFY(x) CORE_ASSERT(x)
#endif

namespace lua
{

void * TABLE_THIS = "__this";

//////////////////////////////////////////////////////////////////////////

Variant::Variant( string value ) 
	: type( type_string )
{ 
	value_string = CORE_NEW char[ value.size()+1 ];
	strcpy( value_string, value.c_str() );
}

Variant::~Variant()
{
	switch ( type )
	{
	case type_string:
		CORE_DELETE value_string;
		value_string = NULL;
		break;
	default:
		break;
	}
}


//////////////////////////////////////////////////////////////////////////

Table::Table( Host & host )
	: m_Host ( host )
{
	// register us
	lua_pushlightuserdata( m_Host.m_pL, this );
	lua_pushvalue ( m_Host.m_pL, -2 );
	lua_settable ( m_Host.m_pL, LUA_REGISTRYINDEX );
}

Table::~Table()
{
	Push( m_Host );

	lua_pushlightuserdata ( m_Host.m_pL, TABLE_THIS );
	lua_pushnil( m_Host.m_pL );
	lua_rawset ( m_Host.m_pL, -3 );

	// clear metatable
	lua_pushnil( m_Host.m_pL );
	CORE_VERIFY ( lua_setmetatable( m_Host.m_pL, -2 ) );

	Pop ( m_Host );

	// unregister us
	lua_pushlightuserdata( m_Host.m_pL, this );
	lua_pushnil( m_Host.m_pL );
	lua_settable ( m_Host.m_pL, LUA_REGISTRYINDEX );
}

void Table::Push( State & state )
{
	lua_pushlightuserdata ( state.m_pL, this );
	lua_gettable ( state.m_pL, LUA_REGISTRYINDEX ); 
	CORE_ASSERT ( lua_istable( state.m_pL, -1 ) );
}

void Table::Pop( State & state )
{
	CORE_ASSERT ( lua_istable( state.m_pL, -1 ) );
	lua_pop ( state.m_pL, 1 );
}

void Table::SetMetatableIndexGlobal ()
{
	Push( m_Host );

	// create metatable
	lua_newtable	( m_Host.m_pL );

	// setup metatable
	lua_pushstring	( m_Host.m_pL, "__index" );
	lua_pushvalue	( m_Host.m_pL, LUA_GLOBALSINDEX );
	lua_settable	( m_Host.m_pL, -3 );

	// set it's metatable
	CORE_VERIFY ( lua_setmetatable( m_Host.m_pL, -2 ) );
}

void Table::SetMetatableIndex ( Table & table )
{
	CORE_ASSERT ( &m_Host == &table.m_Host );
	CORE_ASSERT ( m_Host.m_pL == table.m_Host.m_pL );

	Push( m_Host ); // push table

	// create metatable
	lua_newtable	( m_Host.m_pL );

	// setup metatable
	lua_pushstring	( m_Host.m_pL, "__index" );
	table.Push( m_Host );
	lua_settable	( m_Host.m_pL, -3 );

	// set it's metatable
	CORE_VERIFY ( lua_setmetatable( m_Host.m_pL, -2 ) );

	Pop ( m_Host ); // pop table
}

void Table::SetMetatableIndex( CFunction_t lookupFunction )
{
	Push( m_Host );

	// create meta table
	lua_newtable ( m_Host.m_pL );

	lua_pushstring ( m_Host.m_pL, "__index" );
	lua_pushcfunction ( m_Host.m_pL, lookupFunction );
	lua_settable ( m_Host.m_pL, -3 );

	// set it's metatable
	CORE_VERIFY ( lua_setmetatable( m_Host.m_pL, -2 ) );

	lua_pop ( m_Host.m_pL, 1 ); // pop table
}

void Table::ResetMetatable()
{
	Push( m_Host );
	lua_pushnil ( m_Host.m_pL );
	CORE_VERIFY ( lua_setmetatable( m_Host.m_pL, -2 ) );
	lua_pop( m_Host.m_pL, 1 );
}

void Table::ResetMetatableIndex()
{
	Push( m_Host );
	CORE_VERIFY ( lua_getmetatable( m_Host.m_pL, -1 ) );
	lua_pushstring( m_Host.m_pL, "__index" );
	lua_pushnil( m_Host.m_pL );
	lua_rawset( m_Host.m_pL, -3 );
	lua_pop ( m_Host.m_pL, 2 ); // pop metatable and table
}

void Table::SetBoolean ( char const * name, bool value )
{
	Push( m_Host );
	lua_pushboolean( m_Host.m_pL, value );
	lua_setfield ( m_Host.m_pL, -2, name );
	CORE_ASSERT ( lua_istable( m_Host.m_pL, -1 ) );
	lua_pop( m_Host.m_pL, 1 );
}

void Table::SetFunction	( char const * name, CFunction_t function )
{
	Push( m_Host );
	lua_pushcfunction ( m_Host.m_pL, function );
	lua_setfield ( m_Host.m_pL, -2, name );
	CORE_ASSERT ( lua_istable( m_Host.m_pL, -1 ) );
	lua_pop( m_Host.m_pL, 1 );
}

void Table::SetTable ( char const * name, Table & table )
{
	Push( m_Host );
	lua_pushstring( m_Host.m_pL, name );
	table.Push ( m_Host );
	lua_rawset ( m_Host.m_pL, -3 );
	lua_pop( m_Host.m_pL, 1 );
}

void Table::ResetField ( char const * name )
{
	Push( m_Host );
	lua_pushstring( m_Host.m_pL, name );
	lua_pushnil( m_Host.m_pL );
	lua_rawset ( m_Host.m_pL, -3 );
	lua_pop( m_Host.m_pL, 1 );
}

void Table::Clear()
{
	Push( m_Host );
	
	lua_pushnil( m_Host.m_pL );  // first key
	// this table is in the stack at index -2
	while ( lua_next( m_Host.m_pL, -2 ) != 0 )
	{
		// 'key' is at index -2 and 'value' at index -1
		
		// skip __table field
		if ( !m_Host.IsStrArg ( -2 ) || m_Host.GetLightUserdata( -2 ) != TABLE_THIS )
		{
			lua_pushvalue( m_Host.m_pL, -2 ); // copy key
			lua_pushnil( m_Host.m_pL ); // nil value

			lua_rawset( m_Host.m_pL, -5 );
		}

		lua_pop( m_Host.m_pL, 1 );  // removes 'value'; keeps 'key' for next iteration
	}

	lua_pop( m_Host.m_pL, 1 );
}

void Table::SetThis	( DataObject * pThis )
{
	Push ( m_Host );
	
	lua_pushlightuserdata( m_Host.m_pL, TABLE_THIS ); // key
	lua_pushlightuserdata( m_Host.m_pL, pThis ); // value
	lua_rawset ( m_Host.m_pL, -3 );
	
	lua_pop( m_Host.m_pL, 1 );
}

DataObject * Table::GetThis ()
{
	Push ( m_Host );

	lua_pushlightuserdata( m_Host.m_pL, TABLE_THIS ); // key
	lua_rawget ( m_Host.m_pL, -2 );

	CORE_ASSERT ( m_Host.IsLightUserdata ( -1 ) );
	DataObject * result = static_cast < DataObject * > ( m_Host.GetLightUserdata ( -1 ) );
	
	lua_pop( m_Host.m_pL, 2 );
	return result;
}

void Table::ResetThis ()
{
	Push ( m_Host );

	lua_pushlightuserdata( m_Host.m_pL, TABLE_THIS ); // key
	lua_pushnil( m_Host.m_pL );
	lua_rawset ( m_Host.m_pL, -3 );

	lua_pop( m_Host.m_pL, 1 );
}

void Table::LightUserdataSet( void const * key, void * pData )
{
	Push ( m_Host );
	lua_pushlightuserdata( m_Host.m_pL, (void *)key );
	lua_pushlightuserdata( m_Host.m_pL, pData );
	lua_rawset ( m_Host.m_pL, -3 );
	lua_pop( m_Host.m_pL, 1 );
}

bool Table::LightUserdataGet( void const * key, void * & pData )
{
	bool result = false;
	Push ( m_Host );
	lua_pushlightuserdata( m_Host.m_pL, (void *)key );
	lua_rawget ( m_Host.m_pL, -2 );

	if ( m_Host.IsLightUserdata ( -1 ) )
	{
		pData = m_Host.GetLightUserdata ( -1 );
		result = true;
	}

	lua_pop( m_Host.m_pL, 2 );
	return result;
}

bool Table::PushFunction ( char const * functionName )
{
	return PushFunction( m_Host, functionName );
}

bool Table::PushFunction ( State & state, char const * functionName )
{
	Push( state );

	lua_pushstring( m_Host.m_pL, functionName );
	lua_gettable( m_Host.m_pL, -2 );

	lua_remove( m_Host.m_pL, -2 );

	if ( m_Host.IsFunction ( -1 ) )
		return true;

	lua_remove( m_Host.m_pL, -1 );
	return false;
}

bool Table::PushTable ( char const * tableName )
{
	Push ( m_Host );
	lua_getfield( m_Host.m_pL, -1, tableName );

	lua_remove( m_Host.m_pL, -2 );

	if ( m_Host.IsTable ( -1 ) )
		return true;

	lua_remove( m_Host.m_pL, -1 );
	return false;
}

void Table::PushValueAt	( State & state, int index )
{
	Push( state ); // self
	lua_pushvalue ( state.m_pL, index ); // copy key
	lua_gettable( state.m_pL, -2 );

	lua_remove( state.m_pL, -2 ); // remove self, leave just value on the stack
}

bool Table::RunChunk ( Chunk & chunk )
{
	chunk.Push();
	Push( m_Host );
    CORE_VERIFY ( lua_setfenv( m_Host.m_pL, -2 ) );

	bool result = m_Host.FunctionCall ( 0, 0 );
	return result;
}

void Table::WeakRefs()
{
	Push( m_Host );
	CORE_VERIFY ( lua_getmetatable( m_Host.m_pL, -1 ) );
	lua_pushstring( m_Host.m_pL, "kv" );
	lua_setfield( m_Host.m_pL, -2, "__mode" );
	lua_pop ( m_Host.m_pL, 2 ); // pop metatable and table
}

static int Lua_ReadOnly( lua_State * L )
{
	State state ( L );
	return state.FunctionError( "attempt to write into read only table" );
}

void Table::ReadOnly()
{
	Push( m_Host );
	CORE_VERIFY ( lua_getmetatable( m_Host.m_pL, -1 ) );
	lua_pushcfunction ( m_Host.m_pL, Lua_ReadOnly ); 
	lua_setfield( m_Host.m_pL, -2, "__newindex" );
	lua_pop ( m_Host.m_pL, 2 ); // pop metatable and table
}

void Table::ReadOnlyReset()
{
	Push( m_Host );
	CORE_VERIFY ( lua_getmetatable( m_Host.m_pL, -1 ) );
	lua_pushnil ( m_Host.m_pL );
	lua_setfield( m_Host.m_pL, -2, "__newindex" );
	lua_pop ( m_Host.m_pL, 2 ); // pop metatable and table
}

//////////////////////////////////////////////////////////////////////////

State::State( lua_State * L )
	: m_pL ( L )
{
	CORE_ASSERT ( m_pL );
}

State::~State()
{
}

void * State::GetTableThis ( int index ) const
{
	CORE_ASSERT ( lua_istable ( m_pL, index ) );
	
	lua_pushlightuserdata( m_pL, TABLE_THIS ); // key
	lua_rawget( m_pL, index );

	void * pThis = NULL;
	if ( IsLightUserdata ( -1 ) )
		pThis = GetLightUserdata ( -1 );
	
	lua_pop ( m_pL, 1 );
	return pThis;
}

size_t State::ObjLen ( int index ) const
{
	return lua_objlen( m_pL, index );
}

int	State::NumArgs() const
{
	return lua_gettop( m_pL );
}

bool State::IsFunction( int index ) const
{
	return lua_isfunction ( m_pL, index );
}

bool State::IsCFunction( int index ) const
{
	return !!lua_iscfunction ( m_pL, index );
}

bool State::IsNil( int index ) const
{
	return lua_isnil ( m_pL, index );
}

bool State::IsBoolArg ( int index ) const
{
	return lua_isboolean( m_pL, index );
}

bool State::IsDoubleArg ( int index ) const
{
	return lua_isnumber ( m_pL, index ) != 0;
}

bool State::IsFloatArg ( int index ) const
{
	return lua_isnumber( m_pL, index ) != 0;
}

bool State::IsIntArg ( int index ) const
{
	return lua_isnumber( m_pL, index ) != 0;
}

bool State::IsStrArg ( int index ) const
{
	return lua_type( m_pL, index ) == LUA_TSTRING;
}

bool State::IsLightUserdata	( int index ) const
{
	return lua_islightuserdata( m_pL, index );
}

bool State::IsUserdata	( int index ) const
{
	return lua_type ( m_pL, index ) == LUA_TUSERDATA;
}

bool State::IsTable	( int index ) const
{
	return lua_istable ( m_pL, index );
}

bool State::IsThread ( int index ) const
{
	return lua_isthread ( m_pL, index );
}

bool State::IsVec2 ( int index ) const
{
	if ( !IsUserdata ( index ) )
		return false;

	if ( !IsUserTypedSize < Variant > ( index ) )
		return false;

	Variant const * pVariant = GetUserTyped < Variant const * >( index );
	return pVariant->Get_Type() == Variant( Vec2() ).Get_Type();
}

bool State::IsVec3 ( int index ) const
{
	if ( !IsUserdata ( index ) )
		return false;

	if ( !IsUserTypedSize < Variant > ( index ) )
		return false;

	Variant const * pVariant = GetUserTyped < Variant const * >( index );
	return pVariant->Get_Type() == Variant( Vec3() ).Get_Type();
}

bool State::IsVec4 ( int index ) const
{
	if ( !IsUserdata ( index ) )
		return false;

	if ( !IsUserTypedSize < Variant > ( index ) )
		return false;

	Variant const * pVariant = GetUserTyped < Variant const * >( index );
	return pVariant->Get_Type() == Variant( Vec4() ).Get_Type();
}

bool State::GetBoolArg ( int index ) const
{
	CORE_ASSERT(lua_isboolean( m_pL, index ) );
	return !!lua_toboolean( m_pL, index );
}

double State::GetDoubleArg ( int index ) const
{
	CORE_ASSERT ( lua_isnumber ( m_pL, index ) );
	return lua_tonumber ( m_pL, index );
}

float State::GetFloatArg ( int index ) const
{
	CORE_ASSERT(lua_isnumber( m_pL, index ));
	return lua_tonumber( m_pL, index );
}

int	State::GetIntArg ( int index ) const
{
	CORE_ASSERT(lua_isnumber( m_pL, index ));
	return lua_tointeger( m_pL, index );
}

const char * State::GetStrArg ( int index ) const
{
	CORE_ASSERT(lua_isstring( m_pL, index ));
	return lua_tostring( m_pL, index );
}

size_t State::GetStrLen	( int index ) const
{
	CORE_ASSERT(lua_isstring( m_pL, index ));
	return lua_strlen( m_pL, index );
}


void * State::GetLightUserdata( int index ) const
{
	CORE_ASSERT ( lua_islightuserdata ( m_pL, index ) );
	return lua_touserdata( m_pL, index );
}

void * State::GetUserdata( int index ) const
{
	CORE_ASSERT ( IsUserdata ( index ) );
	return lua_touserdata( m_pL, index );
}

lua_State *	State::GetThread ( int index ) const
{
	CORE_ASSERT ( IsThread ( index ) );
	return lua_tothread ( m_pL, index );
}

CFunction_t	State::GetCFunction	( int index ) const
{
	CORE_ASSERT ( IsCFunction( index ) );
	return lua_tocfunction( m_pL, index );
}

Vec2 & State::GetVec2 ( int index ) const
{
	return GetTypedUserdata < Vec2& >( index );
}

Vec3 & State::GetVec3 ( int index ) const
{
	return GetTypedUserdata < Vec3& >( index );
}

Vec4 & State::GetVec4 ( int index ) const
{
	return GetTypedUserdata < Vec4& >( index );
}

const char * State::GetTypeName ( int index ) const
{
	return lua_typename( m_pL, lua_type( m_pL, index ) );
}

bool State::GetArguments ( Arguments_t & args ) const
{
	CORE_ASSERT ( args.Empty() );

	int n = NumArgs();
	args.Resize( n );

	for ( int i = 1; i <= n; ++i )
	{
		int a = i - 1;
		switch ( lua_type( m_pL, i ) )
		{
		case LUA_TNONE:
			return false;
		case LUA_TNIL: 
			args [ a ] = Variant ();
			break;
		case LUA_TNUMBER: 
			args [ a ] = Variant ( GetFloatArg( i ) );
			break;
		case LUA_TBOOLEAN:
			args [ a ] = Variant ( GetBoolArg( i ) );
			break;
		case LUA_TSTRING: 
			args [ a ] = Variant ( string ( GetStrArg( i ) ) );
			break;
		case LUA_TTABLE: 
			args [ a ] = Variant ();
			break;
		case LUA_TFUNCTION:
			/// ?
			break;
		case LUA_TUSERDATA: 
			args [ a ] = Variant ( *GetUserTyped < Variant const * >( i ) );
			break;
		case LUA_TTHREAD: 
			args [ a ] = Variant ();
			break;
		case LUA_TLIGHTUSERDATA:
			args [ a ] = Variant ();
			break;
		}
	}

	return true;
}


void State::PushNil ()
{
	lua_pushnil( m_pL );
}

void State::PushString ( char const * szString )
{
	lua_pushstring( m_pL, szString );
}

void State::PushBool ( bool value )
{
	lua_pushboolean( m_pL, value );
}

void State::PushFloat ( float value )
{
	lua_pushnumber( m_pL, value );
}

void State::PushInt ( int value )
{
	lua_pushinteger( m_pL, value );
}

void State::PushLightUserdata ( void * userdata )
{
	lua_pushlightuserdata( m_pL, userdata );
}

void State::PushThread ( lua_State * thread )
{
	CORE_VERIFY ( lua_pushthread ( thread ) != 1 );
	lua_xmove( thread, m_pL, 1 );
}

void State::PushTable ( Table & table )
{
	table.Push ( *this );
}

//////////////////////////////////////////////////////////////////////////

static int Lua_Vec2Add( lua_State * L )
{
	State state ( L );
	if ( !state.IsVec2( 1 ) || !state.IsVec2( 2 ) )
		return state.FunctionError( "attempt to add a non-vec2 value" );

	state.PushVec2( state.GetVec2( 1 ) + state.GetVec2( 2 ) );
	return 1;
}

static int Lua_Vec2Sub( lua_State * L )
{
	State state ( L );
	if ( !state.IsVec2( 1 ) || !state.IsVec2( 2 ) )
		return state.FunctionError( "attempt to sub a non-vec2 value" );

	state.PushVec2( state.GetVec2( 1 ) - state.GetVec2( 2 ) );
	return 1;
}

static int Lua_Vec2Mul( lua_State * L )
{
	State state ( L );
	if ( state.IsVec2( 1 ) && state.IsFloatArg( 2 ) )
	{
		state.PushVec2( state.GetVec2( 1 ) * state.GetFloatArg( 2 ) );
		return 1;
	}
	else if ( state.IsFloatArg( 1 ) && state.IsVec2( 2 ) )
	{
		state.PushVec2( state.GetFloatArg( 1 ) * state.GetVec2( 2 ) );
		return 1;
	}

	return state.FunctionError( "attempt to mul a non-vec2 value or non-scalar value" );
}

static int Lua_Vec2Div( lua_State * L )
{
	State state ( L );
	if ( state.IsVec2( 1 ) && state.IsFloatArg( 2 ) )
	{
		state.PushVec2( state.GetVec2( 1 ) / state.GetFloatArg( 2 ) );
		return 1;
	}
	else if ( state.IsFloatArg( 1 ) && state.IsVec2( 2 ) )
	{
		state.PushVec2( state.GetVec2( 2 ) / state.GetFloatArg( 1 ) );
		return 1;
	}

	return state.FunctionError( "attempt to div a non-vec2 value or non-scalar value" );
}

static int Lua_Vec2Unm( lua_State * L )
{
	State state ( L );
	if ( !state.IsVec2( 1 ) )
		return state.FunctionError( "attempt to unm a non-vec2 value" );

	state.PushVec2( -state.GetVec2( 1 ) );
	return 1;
}

static int Lua_Vec2Len( lua_State * L )
{
	State state ( L );
	if ( !state.IsVec2( 1 ) )
		return state.FunctionError( "attempt to len a non-vec2 value" );

	state.PushFloat( Vec2Length ( state.GetVec2( 1 ) ) );
	return 1;
}

static int Lua_Vec2Eq( lua_State * L )
{
	State state ( L );
	if ( !state.IsVec2( 1 ) || !state.IsVec2( 2 ) )
		return state.FunctionError( "attempt to eq a non-vec2 value" );

	state.PushBool( state.GetVec2( 1 ) == state.GetVec2( 2 ) );
	return 1;
}


static int Lua_Vec2Index( lua_State * L )
{
	State state ( L );
	if ( !state.IsVec2( 1 ) )
		return state.FunctionError( "attempt to index a non-vec2 value" );

	if ( state.IsIntArg( 2 ) )
	{
		int index = state.GetIntArg( 2 );
		if ( index >= 1 && index <= 2 )
		{
			state.PushFloat( state.GetVec2( 1 ) [ index - 1 ] );
			return 1;
		}
	}

	if ( state.IsStrArg( 2 ) )
	{
		char c = *state.GetStrArg( 2 );
		switch (c)
		{
		case 'x':
			state.PushFloat( state.GetVec2( 1 ).x );
			return 1;
		case 'y':
			state.PushFloat( state.GetVec2( 1 ).y );
			return 1;
		}
	}

	return state.FunctionError( "vec2 index: bad index" );
}


static int Lua_Vec2NewIndex( lua_State * L )
{
	State state ( L );
	if ( !state.IsVec2( 1 ) )
		return state.FunctionError( "attempt to newindex a non-vec2 value" );

	Vec2 & vec = state.GetVec2( 1 );

	float value = 0;
	if ( state.IsFloatArg ( 3 ) )
		value = state.GetFloatArg ( 3 );

	int index = 0;
	if ( state.IsIntArg( 2 ) )
		index = state.GetIntArg( 2 );
	if ( index >= 1 && index <= 2 )
	{
		vec [ index - 1 ] = value;
		return 0;
	}

	if ( state.IsStrArg( 2 ) )
	{
		char c = *state.GetStrArg( 2 );
		switch (c)
		{
		case 'x':
			vec.x = value;
			return 0;
		case 'y':
			vec.y = value;
			return 0;
		}
	}

	return state.FunctionError( "vec2 newindex: bad index" );
}


static int Lua_Vec2Pow( lua_State * L ) // the ^ operation
{
	State state ( L );
	if ( !state.IsVec2( 1 ) || !state.IsVec2( 2 ) )
		return state.FunctionError( "attempt to dot a non-vec2 value" );

	state.PushFloat( Vec2Dot ( state.GetVec2( 1 ), state.GetVec2( 2 ) ) );
	return 1;
}

static int Lua_Vec2( lua_State * L )
{
	State state ( L );

	Vec2 result ( 0, 0 );
	
	switch ( state.NumArgs() )
	{
	case 2:
		if ( !state.IsFloatArg( 2 ) )
			return state.FunctionError( "attempt to create vec2 value using not a number y" );
		result.y = state.GetFloatArg( 2 );
		// note: fall thru
	case 1:
		if ( !state.IsFloatArg( 1 ) )
			return state.FunctionError( "attempt to create vec2 value using not a number x" );
		result.x = state.GetFloatArg( 1 );
	}

	state.PushVec2( result );
	return 1;
}

//////////////////////////////////////////////////////////////////////////

static int Lua_Vec3Add( lua_State * L )
{
	State state ( L );
	if ( !state.IsVec3( 1 ) || !state.IsVec3( 2 ) )
		return state.FunctionError( "attempt to add a non-vec3 value" );

	state.PushVec3( state.GetVec3( 1 ) + state.GetVec3( 2 ) );
	return 1;
}

static int Lua_Vec3Sub( lua_State * L )
{
	State state ( L );
	if ( !state.IsVec3( 1 ) || !state.IsVec3( 2 ) )
		return state.FunctionError( "attempt to sub a non-vec3 value" );

	state.PushVec3( state.GetVec3( 1 ) - state.GetVec3( 2 ) );
	return 1;
}

static int Lua_Vec3Mul( lua_State * L )
{
	State state ( L );
	if ( state.IsVec3( 1 ) && state.IsFloatArg( 2 ) )
	{
		state.PushVec3( state.GetVec3( 1 ) * state.GetFloatArg( 2 ) );
		return 1;
	}
	else if ( state.IsFloatArg( 1 ) && state.IsVec3( 2 ) )
	{
		state.PushVec3( state.GetFloatArg( 1 ) * state.GetVec3( 2 ) );
		return 1;
	}

	return state.FunctionError( "attempt to mul a non-vec3 value or non-scalar value" );
}

static int Lua_Vec3Div( lua_State * L )
{
	State state ( L );
	if ( state.IsVec3( 1 ) && state.IsFloatArg( 2 ) )
	{
		state.PushVec3( state.GetVec3( 1 ) / state.GetFloatArg( 2 ) );
		return 1;
	}
	else if ( state.IsFloatArg( 1 ) && state.IsVec3( 2 ) )
	{
		state.PushVec3( state.GetVec3( 2 ) / state.GetFloatArg( 1 ) );
		return 1;
	}

	return state.FunctionError( "attempt to div a non-vec3 value or non-scalar value" );
}

static int Lua_Vec3Unm( lua_State * L )
{
	State state ( L );
	if ( !state.IsVec3( 1 ) )
		return state.FunctionError( "attempt to unm a non-vec3 value" );

	state.PushVec3( -state.GetVec3( 1 ) );
	return 1;
}

static int Lua_Vec3Len( lua_State * L )
{
	State state ( L );
	if ( !state.IsVec3( 1 ) )
		return state.FunctionError( "attempt to len a non-vec3 value" );

	state.PushFloat( Vec3Length ( state.GetVec3( 1 ) ) );
	return 1;
}

static int Lua_Vec3Eq( lua_State * L )
{
	State state ( L );
	if ( !state.IsVec3( 1 ) || !state.IsVec3( 2 ) )
		return state.FunctionError( "attempt to eq a non-vec3 value" );

	state.PushBool( state.GetVec3( 1 ) == state.GetVec3( 2 ) );
	return 1;
}

static int Lua_Vec3Index( lua_State * L )
{
	State state ( L );
	if ( !state.IsVec3( 1 ) )
		return state.FunctionError( "attempt to index a non-vec3 value" );

	if ( state.IsIntArg( 2 ) )
	{
		int index = state.GetIntArg( 2 );
		if ( index >= 1 && index <= 3 )
		{
			state.PushFloat( state.GetVec3( 1 ) [ index - 1 ] );
			return 1;
		}
	}

	if ( state.IsStrArg( 2 ) )
	{
		char c = *state.GetStrArg( 2 );
		switch (c)
		{
		case 'x':
			state.PushFloat( state.GetVec3( 1 ).x );
			return 1;
		case 'y':
			state.PushFloat( state.GetVec3( 1 ).y );
			return 1;
		case 'z':
			state.PushFloat( state.GetVec3( 1 ).z );
			return 1;
		}
	}

	return state.FunctionError( "vec3 index: bad index" );
}

static int Lua_Vec3NewIndex( lua_State * L )
{
	State state ( L );
	if ( !state.IsVec3( 1 ) )
		return state.FunctionError( "attempt to newindex a non-vec3 value" );

	Vec3 & vec = state.GetVec3( 1 );

	float value = 0;
	if ( state.IsFloatArg ( 3 ) )
		value = state.GetFloatArg ( 3 );

	int index = 0;
	if ( state.IsIntArg( 2 ) )
		index = state.GetIntArg( 2 );
	if ( index >= 1 && index <= 3 )
	{
		vec [ index - 1 ] = value;
		return 0;
	}

	if ( state.IsStrArg( 2 ) )
	{
		char c = *state.GetStrArg( 2 );
		switch (c)
		{
		case 'x':
			vec.x = value;
			return 0;
		case 'y':
			vec.y = value;
			return 0;
		case 'z':
			vec.z = value;
			return 0;
		}
	}

	return state.FunctionError( "vec3 newindex: bad index" );
}

static int Lua_Vec3Mod( lua_State * L ) // the % operation
{
	State state ( L );
	if ( !state.IsVec3( 1 ) || !state.IsVec3( 2 ) )
		return state.FunctionError( "attempt to cross a non-vec3 value" );

	state.PushVec3( Vec3Cross ( state.GetVec3( 1 ), state.GetVec3( 2 ) ) );
	return 1;
}

static int Lua_Vec3Pow( lua_State * L ) // the ^ operation
{
	State state ( L );
	if ( !state.IsVec3( 1 ) || !state.IsVec3( 2 ) )
		return state.FunctionError( "attempt to dot a non-vec3 value" );

	state.PushFloat( Vec3Dot ( state.GetVec3( 1 ), state.GetVec3( 2 ) ) );
	return 1;
}

static int Lua_Vec3( lua_State * L )
{
	State state ( L );

	Vec3 result ( 0, 0, 0 );
	
	switch ( state.NumArgs() )
	{
	case 3:
		if ( !state.IsFloatArg( 3 ) )
			return state.FunctionError( "attempt to create vec3 value using not a number z" );
		result.z = state.GetFloatArg( 3 );
		// note: fall thru
	case 2:
		if ( !state.IsFloatArg( 2 ) )
			return state.FunctionError( "attempt to create vec3 value using not a number y" );
		result.y = state.GetFloatArg( 2 );
		// note: fall thru
	case 1:
		if ( !state.IsFloatArg( 1 ) )
			return state.FunctionError( "attempt to create vec3 value using not a number x" );
		result.x = state.GetFloatArg( 1 );
	}

	state.PushVec3( result );
	return 1;
}

//////////////////////////////////////////////////////////////////////////

static int Lua_Vec4Add( lua_State * L )
{
	State state ( L );
	if ( !state.IsVec4( 1 ) || !state.IsVec4( 2 ) )
		return state.FunctionError( "attempt to add a non-vec4 value" );

	state.PushVec4( state.GetVec4( 1 ) + state.GetVec4( 2 ) );
	return 1;
}

static int Lua_Vec4Sub( lua_State * L )
{
	State state ( L );
	if ( !state.IsVec4( 1 ) || !state.IsVec4( 2 ) )
		return state.FunctionError( "attempt to sub a non-vec4 value" );

	state.PushVec4( state.GetVec4( 1 ) - state.GetVec4( 2 ) );
	return 1;
}

static int Lua_Vec4Mul( lua_State * L )
{
	State state ( L );
	if ( state.IsVec4( 1 ) && state.IsFloatArg( 2 ) )
	{
		state.PushVec4( state.GetVec4( 1 ) * state.GetFloatArg( 2 ) );
		return 1;
	}
	else if ( state.IsFloatArg( 1 ) && state.IsVec4( 2 ) )
	{
		state.PushVec4( state.GetFloatArg( 1 ) * state.GetVec4( 2 ) );
		return 1;
	}

	return state.FunctionError( "attempt to mul a non-vec4 value or non-scalar value" );
}

static int Lua_Vec4Div( lua_State * L )
{
	State state ( L );
	if ( state.IsVec4( 1 ) && state.IsFloatArg( 2 ) )
	{
		state.PushVec4( state.GetVec4( 1 ) / state.GetFloatArg( 2 ) );
		return 1;
	}
	else if ( state.IsFloatArg( 1 ) && state.IsVec4( 2 ) )
	{
		state.PushVec4( state.GetVec4( 2 ) / state.GetFloatArg( 1 ) );
		return 1;
	}

	return state.FunctionError( "attempt to div a non-vec4 value or non-scalar value" );
}

static int Lua_Vec4Unm( lua_State * L )
{
	State state ( L );
	if ( !state.IsVec4( 1 ) )
		return state.FunctionError( "attempt to unm a non-vec4 value" );

	state.PushVec4( -state.GetVec4( 1 ) );
	return 1;
}

static int Lua_Vec4Len( lua_State * L )
{
	State state ( L );
	if ( !state.IsVec4( 1 ) )
		return state.FunctionError( "attempt to len a non-vec4 value" );

	state.PushFloat( Vec4Length ( state.GetVec4( 1 ) ) );
	return 1;
}

static int Lua_Vec4Eq( lua_State * L )
{
	State state ( L );
	if ( !state.IsVec4( 1 ) || !state.IsVec4( 2 ) )
		return state.FunctionError( "attempt to eq a non-vec4 value" );

	state.PushBool( state.GetVec4( 1 ) == state.GetVec4( 2 ) );
	return 1;
}


static int Lua_Vec4Index( lua_State * L )
{
	State state ( L );
	if ( !state.IsVec4( 1 ) )
		return state.FunctionError( "attempt to index a non-vec4 value" );

	if ( state.IsIntArg( 2 ) )
	{
		int index = state.GetIntArg( 2 );
		if ( index >= 1 && index <= 4 )
		{
			state.PushFloat( state.GetVec4( 1 ) [ index - 1 ] );
			return 1;
		}
	}

	if ( state.IsStrArg( 2 ) )
	{
		char c = *state.GetStrArg( 2 );
		switch (c)
		{
		case 'x':
			state.PushFloat( state.GetVec4( 1 ).x );
			return 1;
		case 'y':
			state.PushFloat( state.GetVec4( 1 ).y );
			return 1;
		case 'z':
			state.PushFloat( state.GetVec4( 1 ).z );
			return 1;
		case 'w':
			state.PushFloat( state.GetVec4( 1 ).w );
			return 1;
		}
	}

	return state.FunctionError( "vec4 index: bad index" );
}

static int Lua_Vec4NewIndex( lua_State * L )
{
	State state ( L );
	if ( !state.IsVec4( 1 ) )
		return state.FunctionError( "attempt to newindex a non-vec4 value" );

	Vec4 & vec = state.GetVec4 ( 1 );

	float value = 0;
	if ( state.IsFloatArg ( 3 ) )
		value = state.GetFloatArg ( 3 );

	int index = 0;
	if ( state.IsIntArg( 2 ) )
		index = state.GetIntArg( 2 );
	if ( index >= 1 && index <= 4 )
	{
		vec [ index - 1 ] = value;
		return 0;
	}

	if ( state.IsStrArg( 2 ) )
	{
		char c = *state.GetStrArg( 2 );
		switch (c)
		{
		case 'x':
			vec.x = value;
			return 0;
		case 'y':
			vec.y = value;
			return 0;
		case 'z':
			vec.z = value;
			return 0;
		case 'w':
			vec.w = value;
			return 0;
		}
	}

	return state.FunctionError( "vec4 newindex: bad index" );
}

static int Lua_Vec4Pow( lua_State * L ) // the ^ operation
{
	State state ( L );
	if ( !state.IsVec4( 1 ) || !state.IsVec4( 2 ) )
		return state.FunctionError( "attempt to dot a non-vec4 value" );

	state.PushFloat( Vec4Dot ( state.GetVec4( 1 ), state.GetVec4( 2 ) ) );
	return 1;
}

static int Lua_Vec4( lua_State * L )
{
	State state ( L );

	Vec4 result ( 0, 0, 0, 0 );
	
	switch ( state.NumArgs() )
	{
	case 4:
		if ( !state.IsFloatArg( 4 ) )
			return state.FunctionError( "attempt to create vec4 value using not a number w" );
		result.w = state.GetFloatArg( 4 );
		// note: fall thru
	case 3:
		if ( !state.IsFloatArg( 3 ) )
			return state.FunctionError( "attempt to create vec4 value using not a number z" );
		result.z = state.GetFloatArg( 3 );
		// note: fall thru
	case 2:
		if ( !state.IsFloatArg( 2 ) )
			return state.FunctionError( "attempt to create vec4 value using not a number y" );
		result.y = state.GetFloatArg( 2 );
		// note: fall thru
	case 1:
		if ( !state.IsFloatArg( 1 ) )
			return state.FunctionError( "attempt to create vec4 value using not a number x" );
		result.x = state.GetFloatArg( 1 );
	}

	state.PushVec4( result );
	return 1;
}

//////////////////////////////////////////////////////////////////////////

void State::PushVec2 ( Vec2 const & vec )
{
	CORE_PLACEMENT_NEW ( NewUserdata ( sizeof ( Variant ) ) ) Variant ( vec );
	// get vec4 ops meta table
	lua_pushlightuserdata( m_pL, Lua_Vec2Index );
	lua_gettable ( m_pL, LUA_REGISTRYINDEX );
	CORE_ASSERT ( IsTable ( -1 ) );
	CORE_VERIFY ( lua_setmetatable( m_pL, -2 ) );
}


void State::PushVec3 ( Vec3 const & vec )
{
	CORE_PLACEMENT_NEW ( NewUserdata ( sizeof ( Variant ) ) ) Variant ( vec );
	// get vec3 ops meta table
	lua_pushlightuserdata( m_pL, Lua_Vec3Index );
	lua_gettable ( m_pL, LUA_REGISTRYINDEX );
	CORE_ASSERT ( IsTable ( -1 ) );
	CORE_VERIFY ( lua_setmetatable( m_pL, -2 ) );
}


void State::PushVec4 ( Vec4 const & vec )
{
	CORE_PLACEMENT_NEW ( NewUserdata ( sizeof ( Variant ) ) ) Variant ( vec );
	// get vec4 ops meta table
	lua_pushlightuserdata( m_pL, Lua_Vec4Index );
	lua_gettable ( m_pL, LUA_REGISTRYINDEX );
	CORE_ASSERT ( IsTable ( -1 ) );
	CORE_VERIFY ( lua_setmetatable( m_pL, -2 ) );
}

//////////////////////////////////////////////////////////////////////////

void * State::NewUserdata ( size_t size )
{
	return lua_newuserdata (m_pL, size );
}

/// called from gc
static int Lua_DeleteVariant( lua_State * L )
{
	State state ( L );
	CORE_ASSERT ( state.NumArgs() == 1 );
	CORE_ASSERT ( state.IsUserdata( 1 ) );
	CORE_ASSERT ( state.ObjLen( 1 ) == sizeof ( Variant ) );

	Variant * pVariant = state.GetUserTyped < Variant * >( 1 );
	pVariant->~Variant();
	return 0;
}

void State::SetupTypedUserdataGc () const
{
	// get GC handler
	lua_pushlightuserdata( m_pL, Lua_DeleteVariant );
	lua_gettable ( m_pL, LUA_REGISTRYINDEX );
	CORE_ASSERT ( IsTable ( -1 ) );
	CORE_VERIFY ( lua_setmetatable( m_pL, -2 ) );
}

string IntToStr( int value )
{
	char buf [ 55 ];
	sprintf( buf, "%i", value );
	return buf;
}

string State::DebugStack() const
{
	// unwind call-stack
	int nLevel = 0;

	std::string log;

	lua_Debug ar;
	int nResult = lua_getstack (m_pL, nLevel, &ar);
	while( nResult )
	{
		string stack;
		if ( lua_getinfo (m_pL, "Sn", &ar) )
		{
			// if it's a C-func - there is no info about
			if( std::string(ar.source) == "=[C]" )
				stack += "[C function] ";
			else
			{
				// chop the @-sign
				if ( ar.source[0] == '@' )
					stack += ar.source + 1;
				else
					stack += ar.source;
				// append line number and called function type
				stack = stack + "(" + IntToStr(ar.linedefined) + ") ";
			}
			
			// append function name if determined. Otherwise append "???"
			stack = stack + "\"" + ar.namewhat + " " + ( ar.name ? ar.name : "???" ) + "\"" + " =>";
		}
		else
			// we can not extract debug information
			stack = stack + "[Unavailable] =>";

		stack += "\n";

		log = stack + log;

		nResult = lua_getstack (m_pL, nLevel, &ar);
		++nLevel;
	}

	return "Lua stack:" + log;
}

void State::PopArgs	( int count )
{
	lua_pop ( m_pL, count );
}

static int Lua_ErrorHandler ( lua_State * L )
{
	State state ( L );
	std::string errorText;

	if ( state.NumArgs() == 1 && state.IsStrArg( 1 ) )
		errorText = state.GetStrArg( 1 );

	errorText += state.DebugStack();
	state.PushString ( errorText.c_str() );
	return 1;
}

int	State::FunctionError ( const string & errorText ) const
{
	return luaL_error ( m_pL, errorText.c_str() );
}

bool State::FunctionCall ( int nArgs, int nResults )
{
	int func = -nArgs -1;
	CORE_ASSERT ( IsFunction( func ) );

	// insert error handler function before the actual function so that any
	// errors get a trace
	int top = lua_gettop( m_pL );
	lua_pushcfunction ( m_pL, Lua_ErrorHandler );
	lua_insert(m_pL, top + func );

	int iResult = lua_pcall ( m_pL, nArgs, nResults, top + func );
	lua_remove ( m_pL, top + func );

	if ( iResult )
	{
		// error message
		CORE_ASSERT ( IsStrArg( -1 ) );
		
		string result;
		switch ( iResult )
		{
		case LUA_ERRRUN:
			result = "Lua FunctionCall: runtime error";
			break;
		case LUA_ERRMEM:
			result = "Lua FunctionCall: memory allocation error";
			break;
		case LUA_ERRERR:
			result = "Lua FunctionCall: error while running the error handler function";
			break;
		}
		result = result + ", " + GetStrArg( -1 );
		ErrorReport( result );

		lua_pop( m_pL, 1 );
	}

	return iResult == 0;
}

void State::FunctionPopResults ( int nResults )
{
	lua_pop ( m_pL, nResults );
}

void State::MoveStackValuesTo ( State & state, int nValues )
{
	lua_xmove( m_pL, state.m_pL, nValues );
}

void State::CopyStackValues	( int nValues )
{
	for ( int i = 0; i < nValues; ++i )
		lua_pushvalue( m_pL, -nValues );
}

void State::CopyStackValuesTo ( State & state, int nValues )
{
	CopyStackValues ( nValues );
	lua_xmove( m_pL, state.m_pL, nValues );
}

int	State::DebugStackTop() const
{
	return lua_gettop( m_pL );
}


static void * LuaAlloc ( void *ud, void *ptr, size_t osize, size_t nsize )
{
	if ( nsize == 0 ) 
	{
		CORE_FREE(ptr);  /* ANSI requires that free(NULL) has no effect */
		return NULL;
	}
	else
		/* ANSI requires that realloc(NULL, size) == malloc(size) */
		return CORE_REALLOC ( ptr, nsize );
}

static int Lua_AtPanic( lua_State * L )
{
	State state ( L );

	if ( state.IsStrArg( 1 ) )
		CORE_ABORT ( "LUA fatal internal error: %s", state.GetStrArg( 1 ) );
	else
		CORE_ABORT ( "LUA fatal internal error" );

	return 0;
}

Host::Host()
	: State ( lua_newstate ( LuaAlloc, NULL ) )
{
	lua_atpanic ( m_pL, Lua_AtPanic );

	GcHandlerConstruct();
	VecsOpsConstruct();
	Vec2OpsConstruct();
	Vec3OpsConstruct();
	Vec4OpsConstruct();
	SignalMetatableConstruct();

	/// _G in C++
	lua_pushvalue ( m_pL, LUA_GLOBALSINDEX );
	m_pGlobalTable = CORE_NEW Table ( *this );
	lua_pop ( m_pL, 1 );

	m_pGlobalTable->SetTable( "Global", *m_pGlobalTable );

	luaopen_base ( m_pL );
	luaopen_table ( m_pL );
	// luaopen_io ( m_pL );
	// luaopen_os ( m_pL );
	luaopen_string ( m_pL );
	luaopen_math ( m_pL );
	// luaopen_debug ( m_pL );
	// luaopen_package ( m_pL );
}

Host::~Host()
{
	for ( Tables_t::Iterator i = m_Tables.Begin(); i != m_Tables.End(); ++i )
	{
		Table & table = **i;
		delete &table;
	}

	for ( Chunks_t::Iterator i = m_Chunks.Begin(); i != m_Chunks.End(); ++i )
	{
		Chunk & chunk = **i;
		delete &chunk;
	}

	delete m_pGlobalTable;
	m_pGlobalTable = NULL;

	SignalMetatableDestruct();
	Vec2OpsDestruct();
	Vec3OpsDestruct();
	Vec4OpsDestruct();
	VecsOpsDestruct();
	GcHandlerDestruct();
	lua_close( m_pL );
}

void Host::GcHandlerConstruct()
{
	lua_pushlightuserdata( m_pL, Lua_DeleteVariant );
	lua_newtable ( m_pL );
	lua_pushcfunction ( m_pL, Lua_DeleteVariant );
	lua_setfield( m_pL, -2, "__gc" );
	lua_settable( m_pL, LUA_REGISTRYINDEX );
}

void Host::GcHandlerDestruct()
{
	lua_pushlightuserdata( m_pL, Lua_DeleteVariant );
	lua_pushnil ( m_pL );
	lua_settable( m_pL, LUA_REGISTRYINDEX );
}

void Host::VecsOpsConstruct()
{
	lua_pushcfunction ( m_pL, Lua_Vec2 );
	lua_setfield( m_pL, LUA_GLOBALSINDEX, "Vec2" );
	lua_pushcfunction ( m_pL, Lua_Vec3 );
	lua_setfield( m_pL, LUA_GLOBALSINDEX, "Vec3" );
	lua_pushcfunction ( m_pL, Lua_Vec4 );
	lua_setfield( m_pL, LUA_GLOBALSINDEX, "Vec4" );
}

void Host::VecsOpsDestruct()
{
	lua_pushnil ( m_pL );
	lua_setfield( m_pL, LUA_GLOBALSINDEX, "Vec2" );
	lua_pushnil ( m_pL );
	lua_setfield( m_pL, LUA_GLOBALSINDEX, "Vec3" );
	lua_pushnil ( m_pL );
	lua_setfield( m_pL, LUA_GLOBALSINDEX, "Vec4" );
}

void Host::Vec2OpsConstruct()
{
	lua_pushlightuserdata( m_pL, Lua_Vec2Index );
	lua_newtable ( m_pL );

	lua_pushcfunction ( m_pL, Lua_DeleteVariant );
	lua_setfield( m_pL, -2, "__gc" );

	lua_pushcfunction ( m_pL, Lua_Vec2Add );
	lua_setfield( m_pL, -2, "__add" );

	lua_pushcfunction ( m_pL, Lua_Vec2Sub );
	lua_setfield( m_pL, -2, "__sub" );

	lua_pushcfunction ( m_pL, Lua_Vec2Mul );
	lua_setfield( m_pL, -2, "__mul" );

	lua_pushcfunction ( m_pL, Lua_Vec2Div );
	lua_setfield( m_pL, -2, "__div" );

	lua_pushcfunction ( m_pL, Lua_Vec2Unm );
	lua_setfield( m_pL, -2, "__unm" );

	lua_pushcfunction ( m_pL, Lua_Vec2Len );
	lua_setfield( m_pL, -2, "__len" );

	lua_pushcfunction ( m_pL, Lua_Vec2Eq );
	lua_setfield( m_pL, -2, "__eq" );

	lua_pushcfunction ( m_pL, Lua_Vec2Index );
	lua_setfield( m_pL, -2, "__index" );

	lua_pushcfunction ( m_pL, Lua_Vec2NewIndex );
	lua_setfield( m_pL, -2, "__newindex" );

	lua_pushcfunction ( m_pL, Lua_Vec2Pow );
	lua_setfield( m_pL, -2, "__pow" );

	lua_settable( m_pL, LUA_REGISTRYINDEX );
}

void Host::Vec2OpsDestruct()
{
	lua_pushlightuserdata( m_pL, Lua_Vec2Index );
	lua_pushnil ( m_pL );
	lua_settable( m_pL, LUA_REGISTRYINDEX );
}


void Host::Vec3OpsConstruct()
{
	lua_pushlightuserdata( m_pL, Lua_Vec3Index );
	lua_newtable ( m_pL );

	lua_pushcfunction ( m_pL, Lua_DeleteVariant );
	lua_setfield( m_pL, -2, "__gc" );

	lua_pushcfunction ( m_pL, Lua_Vec3Add );
	lua_setfield( m_pL, -2, "__add" );

	lua_pushcfunction ( m_pL, Lua_Vec3Sub );
	lua_setfield( m_pL, -2, "__sub" );

	lua_pushcfunction ( m_pL, Lua_Vec3Mul );
	lua_setfield( m_pL, -2, "__mul" );

	lua_pushcfunction ( m_pL, Lua_Vec3Div );
	lua_setfield( m_pL, -2, "__div" );

	lua_pushcfunction ( m_pL, Lua_Vec3Unm );
	lua_setfield( m_pL, -2, "__unm" );

	lua_pushcfunction ( m_pL, Lua_Vec3Len );
	lua_setfield( m_pL, -2, "__len" );

	lua_pushcfunction ( m_pL, Lua_Vec3Eq );
	lua_setfield( m_pL, -2, "__eq" );

	lua_pushcfunction ( m_pL, Lua_Vec3Index );
	lua_setfield( m_pL, -2, "__index" );

	lua_pushcfunction ( m_pL, Lua_Vec3NewIndex );
	lua_setfield( m_pL, -2, "__newindex" );

	lua_pushcfunction ( m_pL, Lua_Vec3Mod );
	lua_setfield( m_pL, -2, "__mod" );

	lua_pushcfunction ( m_pL, Lua_Vec3Pow );
	lua_setfield( m_pL, -2, "__pow" );

	lua_settable( m_pL, LUA_REGISTRYINDEX );
}

void Host::Vec3OpsDestruct()
{
	lua_pushlightuserdata( m_pL, Lua_Vec3Index );
	lua_pushnil ( m_pL );
	lua_settable( m_pL, LUA_REGISTRYINDEX );
}

void Host::Vec4OpsConstruct()
{
	lua_pushlightuserdata( m_pL, Lua_Vec4Index );
	lua_newtable ( m_pL );

	lua_pushcfunction ( m_pL, Lua_DeleteVariant );
	lua_setfield( m_pL, -2, "__gc" );

	lua_pushcfunction ( m_pL, Lua_Vec4Add );
	lua_setfield( m_pL, -2, "__add" );

	lua_pushcfunction ( m_pL, Lua_Vec4Sub );
	lua_setfield( m_pL, -2, "__sub" );

	lua_pushcfunction ( m_pL, Lua_Vec4Mul );
	lua_setfield( m_pL, -2, "__mul" );

	lua_pushcfunction ( m_pL, Lua_Vec4Div );
	lua_setfield( m_pL, -2, "__div" );

	lua_pushcfunction ( m_pL, Lua_Vec4Unm );
	lua_setfield( m_pL, -2, "__unm" );

	lua_pushcfunction ( m_pL, Lua_Vec4Len );
	lua_setfield( m_pL, -2, "__len" );

	lua_pushcfunction ( m_pL, Lua_Vec4Eq );
	lua_setfield( m_pL, -2, "__eq" );

	lua_pushcfunction ( m_pL, Lua_Vec4Index );
	lua_setfield( m_pL, -2, "__index" );

	lua_pushcfunction ( m_pL, Lua_Vec4NewIndex );
	lua_setfield( m_pL, -2, "__newindex" );

	lua_pushcfunction ( m_pL, Lua_Vec4Pow );
	lua_setfield( m_pL, -2, "__pow" );

	lua_settable( m_pL, LUA_REGISTRYINDEX );
}

void Host::Vec4OpsDestruct()
{
	lua_pushlightuserdata( m_pL, Lua_Vec4Index );
	lua_pushnil ( m_pL );
	lua_settable( m_pL, LUA_REGISTRYINDEX );
}

//////////////////////////////////////////////////////////////////////////

static int Lua_SignalAdd ( lua_State * L )
{
	State state ( L );

	CORE_ASSERT ( state.NumArgs() == 2 );
	CORE_ASSERT ( state.IsTable( 1 ) );
	
	if ( !state.IsFunction( 2 ) )
		return state.FunctionError( "Lua Signal+: rhs must be a function" );

	lua_getfenv ( L, 2 ); // key, RHS object table
	CORE_ASSERT ( lua_istable ( L, -1 ) );

	DataObject * pObject = state.GetTypedTableThis < DataObject * > ( -1 );
	if ( pObject == NULL )
		return state.FunctionError( "Lua Signal+: rhs must be a function with an Object table env" );

	lua_pushvalue ( L, 2 ); // value, RHS function
	lua_settable ( L, 1 );

	// return LHS
	lua_pushvalue ( L, 1 );
	return 1;
}

static int Lua_SignalSub ( lua_State * L )
{
	State state ( L );

	CORE_ASSERT ( state.NumArgs() == 2 );
	CORE_ASSERT ( state.IsTable( 1 ) );
	
	if ( !state.IsFunction( 2 ) )
		return state.FunctionError( "Lua Signal-: rhs must be a function" );

	lua_getfenv ( L, 2 ); // key, RHS object table
	CORE_ASSERT ( lua_istable ( L, -1 ) );

	DataObject * pObject = state.GetTypedTableThis < DataObject * > ( -1 );
	if ( pObject == NULL )
		return state.FunctionError( "Lua Signal-: rhs must be a function with an Object table env" );

	lua_pushnil ( L ); // value
	lua_settable ( L, 1 );

	// return LHS
	lua_pushvalue ( L, 1 );
	return 1;
}

static int Lua_SignalCall ( lua_State * L )
{
	State state ( L );

	int nArgs = state.NumArgs();
	CORE_ASSERT ( nArgs >= 1 );
	CORE_ASSERT ( state.IsTable( 1 ) );

	lua_pushnil( L );  // first key
	// we are in the stack at index 1
	while ( lua_next( L, 1 ) != 0 )
	{
		// 'key' is at index -2 and 'value' at index -1
		if ( lua_istable ( L, -2 ) && lua_isfunction ( L, -1 ) )
		{
			lua_pushvalue ( L, -2 ); // key - object table, value - function
			CORE_VERIFY ( lua_setfenv ( L, -2 ) ); // setup value env to key table

			// copy function
			lua_pushvalue( L, -1 );
			// copy args
			for ( int i = 2; i <= nArgs; ++i )
				lua_pushvalue( L, i );

			// @FIXME: and what about threads if FSM messaging?
			// B/W, non-FSM script can call FSM-yielded script and vice versa.
			if ( !state.FunctionCall( nArgs - 1, 0 ) )
				return state.FunctionError( "Lua Signal(): error running delegate function" );
		}

		lua_pop( L, 1 );  // removes 'value'; keeps 'key' for next iteration
	}

	return 0;
}

static int Lua_SubscribersNext (lua_State *L) 
{
	if ( !lua_istable ( L, 1 ) )
		return 0;

	lua_settop(L, 2);  // create a 2nd argument if there isn't one
	while ( lua_next(L, 1) != 0 )
	{
		// 'key' is at index -2 and 'value' at index -1
		if ( lua_istable ( L, -2 ) && lua_isfunction ( L, -1 ) )
		{
			lua_pushvalue ( L, -2 ); // key - object table, value - function
			CORE_VERIFY ( lua_setfenv ( L, -2 ) ); // setup value env to key table
			return 2;
		}

		lua_pop( L, 1 );  // removes 'value'; keeps 'key' for next iteration
	}

	lua_pushnil(L);
	return 1;
}

static int Lua_Subscribers (lua_State *L) 
{
	if ( !lua_istable ( L, 1 ) )
		return 0;

	lua_pushcfunction(L, Lua_SubscribersNext );  /* return generator, */
	lua_pushvalue(L, 1);  /* state, */
	lua_pushnil(L);  /* and initial value */
	return 3;
}

static int Lua_Signal ( lua_State * L )
{
	lua_newtable ( L );

	// get previously constructed metatable
	lua_pushlightuserdata( L, Lua_Signal );
	lua_gettable( L, LUA_REGISTRYINDEX );
	CORE_ASSERT ( lua_istable( L, -1 ) );

	CORE_VERIFY ( lua_setmetatable( L, -2 ) );
	return 1;
}

void Host::SignalMetatableConstruct()
{
	lua_pushlightuserdata( m_pL, Lua_Signal );
	lua_newtable ( m_pL );
	
	lua_pushcfunction ( m_pL, Lua_SignalAdd );
	lua_setfield( m_pL, -2, "__add" );

	lua_pushcfunction ( m_pL, Lua_SignalSub );
	lua_setfield( m_pL, -2, "__sub" );

	lua_pushcfunction ( m_pL, Lua_SignalCall );
	lua_setfield( m_pL, -2, "__call" );

	lua_settable( m_pL, LUA_REGISTRYINDEX );

	// setup Signal construct function
	lua_pushcfunction ( m_pL, Lua_Signal );
	lua_setfield( m_pL, LUA_GLOBALSINDEX, "Signal" );

	lua_pushcfunction ( m_pL, Lua_Subscribers );
	lua_setfield( m_pL, LUA_GLOBALSINDEX, "Subscribers" );
}

void Host::SignalMetatableDestruct()
{
	lua_pushnil ( m_pL );
	lua_setfield( m_pL, LUA_GLOBALSINDEX, "Signal" );

	lua_pushnil ( m_pL );
	lua_setfield( m_pL, LUA_GLOBALSINDEX, "Subscribers" );

	lua_pushlightuserdata( m_pL, Lua_Signal );
	lua_pushnil ( m_pL );
	lua_settable( m_pL, LUA_REGISTRYINDEX );
}

Table &	Host::TableConstruct()
{
	lua_newtable ( m_pL );
	Table * pTable = CORE_NEW Table ( *this );
	lua_pop ( m_pL, 1 );
	m_Tables.Add( pTable );
	return *pTable;
}

void Host::TableDestruct ( Table & table )
{
	m_Tables.Remove( &table );
	delete &table;
}

Chunk * Host::ChunkLoad ( Chunk::Name_t const & name, ByteStreamReader & stream )
{
	if ( !ChunkFunctionLoad( stream, name ) )
		return NULL;

	Chunk * pChunk = CORE_NEW Chunk ( *this, name );
	pChunk->ChunkFunctionRegister();

	m_Chunks.Add( pChunk );
	return pChunk;
}

bool Host::ChunkReload ( Chunk & chunk, ByteStreamReader & stream )
{
	if ( !ChunkFunctionLoad( stream, chunk.m_Name ) )
		return false;

	chunk.ChunkFunctionUnregister();
	chunk.ChunkFunctionRegister();

	if ( chunk.IsFuncTable() )
		chunk.FuncTableReload();

	return true;
}

void Host::ChunkUnload ( Chunk & chunk )
{
	m_Chunks.Remove( &chunk );
	chunk.ChunkFunctionUnregister();
	delete &chunk;
}

Table & Host::GetGlobalTable() const
{
	CORE_ASSERT ( m_pGlobalTable );
	return *m_pGlobalTable;
}

bool Host::ChunkFunctionLoad( ByteStreamReader & stream, Chunk::Name_t const & name )
{
	uint32 chunkSize;
	if ( !stream.ReadSize( chunkSize ) )
	{
		ErrorReport( "lua::Host::ChunkFunctionLoad - unable to read chunk size" );
		return false;
	}

	char * buff = CORE_NEW char [ chunkSize ];
	stream.ReadBytesCopy( chunkSize, buff );
	int iResult = luaL_loadbuffer ( m_pL, buff, chunkSize, ( "@" + name ).c_str() );
	delete buff;
	buff = NULL;

	if ( iResult )
	{
		string errorReport;
		switch ( iResult )
		{
		case LUA_ERRSYNTAX:
			errorReport = "lua::Host::ChunkFunctionLoad - syntax error during pre-compilation";
			break;
		case LUA_ERRMEM:
			errorReport = "lua::Host::ChunkFunctionLoad - memory allocation error";
			break;
		}

		if ( lua_isstring( m_pL, -1 ) )
			errorReport += ", " + string( lua_tostring( m_pL, -1 ) ) + "\n";

		ErrorReport( errorReport );
		return false;
	}

	return true;
}

//////////////////////////////////////////////////////////////////////////

Chunk::Chunk( Host & host, Name_t const & name )
	: m_Host ( host )
	, m_pFuncTable ( NULL )
	, m_Name ( name )
{
}

Chunk::~Chunk()
{
}

void Chunk::ChunkFunctionRegister()
{
	lua_pushlightuserdata( m_Host.m_pL, this );
	lua_insert ( m_Host.m_pL, -2 );
	lua_settable ( m_Host.m_pL, LUA_REGISTRYINDEX );
}

void Chunk::ChunkFunctionUnregister()
{
	lua_pushlightuserdata( m_Host.m_pL, this );
	lua_pushnil( m_Host.m_pL );
	lua_settable ( m_Host.m_pL, LUA_REGISTRYINDEX );
}

void Chunk::Push()
{
	lua_pushlightuserdata( m_Host.m_pL, this );
	lua_gettable( m_Host.m_pL, LUA_REGISTRYINDEX );
}

bool Chunk::IsFuncTable() const
{
	return m_pFuncTable != NULL;
}

Table & Chunk::FuncTable() const
{
	CORE_ASSERT ( m_pFuncTable );
	return *m_pFuncTable;
}

bool Chunk::FuncTableConstruct()
{
	CORE_ASSERT ( m_pFuncTable == NULL );

	m_pFuncTable = &m_Host.TableConstruct();
	return FuncTableReload();
}

bool Chunk::FuncTableReload()
{
	CORE_ASSERT ( m_pFuncTable );

	m_pFuncTable->Clear();

	Push();
	m_pFuncTable->Push( m_Host );
    CORE_VERIFY ( lua_setfenv( m_Host.m_pL, -2 ) );

	bool result = m_Host.FunctionCall ( 0, 0 );
	return result;
}

void Chunk::FuncTableDestruct()
{
	CORE_ASSERT ( m_pFuncTable );
	m_Host.TableDestruct( *m_pFuncTable );
	m_pFuncTable = NULL;
}

Chunk::Name_t const & Chunk::Name() const
{
	return m_Name;
}

//////////////////////////////////////////////////////////////////////////

Thread::Thread( State & parentState )
	: State ( lua_newthread( parentState.m_pL ) )
{
	/// register coroutine
	lua_pushlightuserdata( parentState.m_pL, this );
	lua_insert ( parentState.m_pL, -2 );
	lua_settable ( parentState.m_pL, LUA_REGISTRYINDEX );
}

Thread::~Thread()
{
	/// unregister coroutine
	lua_pushlightuserdata( m_pL, this );
	lua_pushnil( m_pL );
	lua_settable ( m_pL, LUA_REGISTRYINDEX );
}

lua_State *	Thread::GetLuaThread() const
{
	return m_pL;
}

bool Thread::Resume ( bool & finished, int nArgs, int & nResults )
{
	finished = true;

	int top = lua_gettop( m_pL );

	int iResult = lua_resume ( m_pL, nArgs );
	if ( iResult == 0 )
	{
		nResults = lua_gettop( m_pL ) - top + ( nArgs + 1 ); // plus function
		if ( nResults < 0 )
			nResults = 0;
	}

	if ( iResult )
	{
		string errorReport;

		switch ( iResult )
		{
		case LUA_YIELD:
			finished = false;
			return true;
		case LUA_ERRRUN:
			errorReport = "Lua FunctionCall: runtime error";
			break;
		case LUA_ERRMEM:
			errorReport = "Lua FunctionCall: memory allocation error";
			break;
		case LUA_ERRERR:
			errorReport = "Lua FunctionCall: error while running the error handler function";
			break;
		}

		// error message
		CORE_ASSERT ( IsStrArg( -1 ) );
		errorReport += ", " + string( GetStrArg( -1 ) );
		ErrorReport( errorReport );

		lua_pop( m_pL, 1 );
	}

	return iResult == 0;
}

bool Thread::ResumeFromFunction	( bool & finished, int nArgs, int & nResults )
{
	CORE_ASSERT ( IsFunction( -1 - nArgs ) );
	return Resume( finished, nArgs, nResults );
}

int	Thread::CoroutineYield()
{
	return lua_yield ( m_pL, 0 );
}

bool Thread::IsYielded() const
{
	return lua_status ( m_pL ) == LUA_YIELD;
}

//////////////////////////////////////////////////////////////////////////

Continuation::Continuation()
{
}

Continuation::~Continuation()
{
}

//////////////////////////////////////////////////////////////////////////

Call::Call ( lua::State & parentState )
	: m_Thread( parentState )
	, m_pCurrentContinuation ()
{
}

Call::~Call()
{
	CORE_DELETE m_pCurrentContinuation;
	m_pCurrentContinuation = NULL;
}

void Call::SwitchCurrentContinuation ( DataObject & This, Continuation * pContinuation )
{
	if ( m_pCurrentContinuation )
	{
		m_pCurrentContinuation->ProcessEndState( This );
		CORE_DELETE m_pCurrentContinuation;
		m_pCurrentContinuation = NULL;
	}
	
	m_pCurrentContinuation = pContinuation;
	
	if ( m_pCurrentContinuation )
		m_pCurrentContinuation->ProcessBeginState( This );
}

Continuation * Call::CurrentContinuation() const
{
	return m_pCurrentContinuation;
}

WorkResult::Enum Call::FunctionCall ( DataObject & This, int nArgs, int & nResults )
{
	CORE_ASSERT( m_Thread.IsYielded() );

	if ( !m_Thread.IsFunction( -1 - nArgs ) )
		return WorkResult::ERR;

	bool finished;
	if ( m_Thread.ResumeFromFunction ( finished, nArgs, nResults ) )
	{
		if ( finished )
			return WorkResult::RETURN;
		return WorkResult::YIELD;
	}

	ErrorReport( "lua::Call::FunctionCall: can't resume from function" );
	return WorkResult::ERR;
}

WorkResult::Enum Call::Work ( DataObject & This, float deltaTime )
{
	int nStateResults = 0;
	if ( m_pCurrentContinuation )
	{
		WorkResult::Enum result = m_pCurrentContinuation->ProcessWork( This, deltaTime, nStateResults );
		if  ( result == WorkResult::YIELD )
			return WorkResult::YIELD;

		SwitchCurrentContinuation ( This, NULL );
	}

	if ( !m_Thread.IsYielded() )
		return WorkResult::RETURN;

	bool finished;
	int nResults;
	if ( m_Thread.Resume( finished, nStateResults, nResults ) )
	{
		return finished ? WorkResult::RETURN : WorkResult::YIELD;
	}

	return WorkResult::ERR;
}

//////////////////////////////////////////////////////////////////////////

void ErrorReport ( string const & errorReport )
{
	// TODO: implement
}

} // namespace lua
