#ifndef CoreLua_h
#define CoreLua_h

#include "Core.h"

#include "Metadata\Engine\Fundamental.h"

struct lua_State;

namespace lua
{

void	ErrorReport ( string const & errorReport );
string	IntToStr ( int value );

using namespace core;

class State;
class Table;
class Chunk;
class Thread;
class Host;

class Variant
{
public:
	enum Type
	{
		  type_none = 0
		, type_bool
		, type_byte
		, type_float
		, type_int
		, type_string
		, type_object

		, type_vec2
		, type_vec3
		, type_vec4
		, type_color
	};

	template < typename T > struct TypeToId { };
	template <> struct TypeToId< bool >			{ static const Type id = type_bool; };
	template <> struct TypeToId< byte >			{ static const Type id = type_byte; };
	template <> struct TypeToId< float >		{ static const Type id = type_float; };
	template <> struct TypeToId< int >			{ static const Type id = type_int; };
	template <> struct TypeToId< string >		{ static const Type id = type_string; };
	template <> struct TypeToId< DataObject * >	{ static const Type id = type_object; };

	Type Get_Type() const { return type; }

	Variant()						: type( type_none ) {}
	Variant( bool value )			: type( type_bool ),	value_bool ( value ) {}
	Variant( uint8 value )			: type( type_byte ),	value_byte ( value ) {}
	Variant( float32 value )		: type( type_float ),	value_float ( value ) {}
	Variant( int32 value )			: type( type_int ),		value_int ( value ) {}
	Variant( string value );
	Variant( DataObject * value )	: type( type_object ),	value_object ( value ) {}

	Variant( Vec2 const & value )	: type( type_vec2 )	{ *(Vec2*)value_vec2 = value; }
	Variant( Vec3 const & value )	: type( type_vec3 )	{ *(Vec3*)value_vec3 = value; }
	Variant( Vec4 const & value )	: type( type_vec4 )	{ *(Vec4*)value_vec4 = value; }
	Variant( Color const & value )	: type( type_color ){ *(Color*)value_color = value; }

	~Variant();

	template < typename T >
	T Get_Value() {}
	
	template <>	bool&		Get_Value() { return value_bool; }
	template <>	uint8&		Get_Value() { return value_byte; }
	template <>	float32&	Get_Value() { return value_float; }
	template <>	int32&		Get_Value() { return value_int; }
	template <>	char*		Get_Value() { return value_string; }
	template <>	DataObject* Get_Value() { return value_object; }

	template <>	Vec2&	Get_Value	() { return *(Vec2*)value_vec2; }
	template <>	Vec3&	Get_Value	() { return *(Vec3*)value_vec3; }
	template <>	Vec4&	Get_Value	() { return *(Vec4*)value_vec4; }
	template <>	Color&	Get_Value	() { return *(Color*)value_color; }

private:
	Type type;

	union
	{
		bool			value_bool;
		uint8			value_byte;
		float32			value_float;
		int32			value_int;
		char *			value_string;
		DataObject *	value_object;
		byte			value_vec2[ sizeof(Vec2) ];
		byte			value_vec3[ sizeof(Vec3) ];
		byte			value_vec4[ sizeof(Vec4) ];
		byte			value_color[ sizeof(Color) ];
	};
};

typedef int (*CFunction_t) (lua_State *);
typedef core::List < Variant > Arguments_t;

///
/// LUA table
/// 
class Table
{
public:
	void	SetMetatableIndexGlobal	();
	void	SetMetatableIndex		( Table & table );
	void	SetMetatableIndex		( CFunction_t lookupFunction );

	void	ResetMetatable();
	void	ResetMetatableIndex();

	void	ReadOnly();
	void	ReadOnlyReset();

	void	Push( State & state );
	void	Pop( State & state );

	void	SetBoolean		( char const * name, bool value );
	void	SetFunction		( char const * name, CFunction_t function );
	void	SetTable		( char const * name, Table & table );

	void		SetThis		( DataObject * pThis );
	void		ResetThis	();
	DataObject* GetThis		();

	void	LightUserdataSet( void const * key, void * pData );
	bool	LightUserdataGet( void const * key, void * & pData );

	template < typename T >
	bool	LightUserdataGetTyped( void const * key, T * & pData )
	{
		void * pValue;
		if ( LightUserdataGet ( key, pValue ) )
		{
			pData = static_cast < T * > ( pValue );
			return true;
		}
		return false;
	}

	void	ResetField		( char const * name );

	bool	PushFunction	( char const * functionName );
	bool	PushFunction	( State & state, char const * functionName );
	bool	PushTable		( char const * tableName );
	void	PushValueAt		( State & state, int index );

	bool	RunChunk		( Chunk & chunk );
	void	Clear();
	void	WeakRefs();

	Host &	m_Host;

protected:
	Table( Host & host );
	virtual ~Table();

private:
	void operator=( Table const & ) {}
	friend Host;
};

///
/// LUA state machine
///
class State
{
public:
					State( lua_State * L );
					~State();

	void *			GetTableThis ( int index ) const;
	template < typename T >
	T GetTypedTableThis( int index ) const ///< unsafe typed
	{
		return static_cast < T > ( GetTableThis ( index ) );
	}

	size_t			ObjLen		( int index ) const;
	string			DebugStack() const;
	void			PopArgs		( int count );
	
	void			MoveStackValuesTo ( State & state, int nValues );
	void			CopyStackValues	  ( int nValues );
	void			CopyStackValuesTo ( State & state, int nValues );

	//////////////////////////////////////////////////////////////////////////

	bool			IsFunction		( int index ) const;
	bool			IsCFunction		( int index ) const;
	bool			IsNil			( int index ) const;
	bool			IsBoolArg		( int index ) const;
	bool			IsFloatArg		( int index ) const;
	bool			IsDoubleArg		( int index ) const;
	bool			IsIntArg		( int index ) const;
	bool			IsStrArg		( int index ) const;
	bool			IsLightUserdata	( int index ) const;
	bool			IsUserdata		( int index ) const;
	bool			IsTable			( int index ) const;
	bool			IsThread		( int index ) const;
	bool			IsVec2			( int index ) const;
	bool			IsVec3			( int index ) const;
	bool			IsVec4			( int index ) const;

	int				FunctionError	( const string & errorText ) const;
	bool			FunctionCall	( int nArgs, int nResults );
	void			FunctionPopResults ( int nResults );

	template < typename T >
	bool IsUserTypedSize( int index ) const
	{
		return ObjLen ( index ) == sizeof ( T );
	}

	template < typename T >
	bool IsTypedUserdata ( int index ) const
	{
		if ( !IsUserdata ( index ) )
			return false;
		Variant const * pVariant = GetUserTyped < Variant const * >( index );
		return pVariant->Get_Type() == Variant::TypeToId< T >::id;
	}

	template < typename T > bool Is ( int index )
	{
		return IsTypeOf < T >::Is( this, index );
	}
	template < typename T > struct IsTypeOf { static bool Is( State * pThis, int index ) {} };
	template <> struct IsTypeOf < bool >	{ static bool Is( State * pThis, int index ) { return pThis->IsBoolArg( index ); } };
	template <> struct IsTypeOf < float >	{ static bool Is( State * pThis, int index ) { return pThis->IsFloatArg( index ); } };
	template <> struct IsTypeOf < double >	{ static bool Is( State * pThis, int index ) { return pThis->IsDoubleArg( index ); } };
	template <> struct IsTypeOf < int >		{ static bool Is( State * pThis, int index ) { return pThis->IsIntArg( index ); } };
	template <> struct IsTypeOf < char* >	{ static bool Is( State * pThis, int index ) { return pThis->IsStrArg( index ); } };
	template <> struct IsTypeOf < Vec2 >	{ static bool Is( State * pThis, int index ) { return pThis->IsVec2( index ); } };
	template <> struct IsTypeOf < Vec3 >	{ static bool Is( State * pThis, int index ) { return pThis->IsVec3( index ); } };
	template <> struct IsTypeOf < Vec4 >	{ static bool Is( State * pThis, int index ) { return pThis->IsVec4( index ); } };

	//////////////////////////////////////////////////////////////////////////

	int				NumArgs		() const;

	bool			GetArguments ( Arguments_t & args ) const;

	bool			GetBoolArg		( int index ) const;
	float			GetFloatArg		( int index ) const;
	double			GetDoubleArg	( int index ) const;
	int				GetIntArg		( int index ) const;
	const char *	GetStrArg		( int index ) const;
	size_t			GetStrLen		( int index ) const;
	void *			GetLightUserdata( int index ) const;
	void *			GetUserdata		( int index ) const;
	lua_State *		GetThread		( int index ) const;
	CFunction_t		GetCFunction	( int index ) const;
	Vec2 &			GetVec2			( int index ) const;
	Vec3 &			GetVec3			( int index ) const;
	Vec4 &			GetVec4			( int index ) const;

	template < typename T >
	T GetLightTypedPtr( int index ) const
	{
		return static_cast < T > ( GetLightUserdata ( index ) );
	}

	template < typename T >
	T GetUserTyped( int index ) const
	{
		return static_cast < T > ( GetUserdata ( index ) );
	}

	template < typename T >
	T GetTypedUserdata ( int index ) const
	{
		CORE_ASSERT ( IsUserdata ( index ) );
		CORE_ASSERT ( IsUserTypedSize < Variant > ( index ) );
		Variant * pVariant = GetUserTyped < Variant * >( index );
		return pVariant->Get_Value < T >();
	}

	const char * GetTypeName ( int index ) const;

	template< typename T > T Get ( int index ) {}
	template<> char const *	Get( int index )	{ return GetStrArg( index ); }
	template<> bool			Get( int index )	{ return GetBoolArg( index ); }
	template<> float		Get( int index )	{ return GetFloatArg( index ); }
	template<> int			Get( int index )	{ return GetIntArg( index ); }
	template<> lua_State *	Get( int index )	{ return GetThread( index ); }
	template<> Vec2			Get( int index )	{ return GetVec2( index ); }
	template<> Vec3			Get( int index )	{ return GetVec3( index ); }
	template<> Vec4			Get( int index )	{ return GetVec4( index ); }

	//////////////////////////////////////////////////////////////////////////

	void * NewUserdata ( size_t size );

	void PushNil			();
	void PushString			( char const * szString );
	void PushBool			( bool value );
	void PushFloat			( float value );
	void PushInt			( int value );
	void PushLightUserdata	( void * userdata );
	void PushThread			( lua_State * thread );
	void PushTable			( Table & table );
	void PushVec2			( Vec2 const & vec );
	void PushVec3			( Vec3 const & vec );
	void PushVec4			( Vec4 const & vec );

	template< typename T >
	void PushTypedUserdata ( T const & value )
	{
		CORE_PLACEMENT_NEW ( NewUserdata ( sizeof ( Variant ) ) ) Variant ( value );
		SetupTypedUserdataGc ();
	}

	template< typename T > 
	void Push ( T value )
	{ 
		PushType<T>::Push( this, value );
	}
	template < typename T > struct PushType			{ static void Push( State * pThis, T value ) { return value; } };
	template <> struct PushType < char const * >	{ static void Push( State * pThis, char const * value )	 { pThis->PushString( value ); } };
	template <> struct PushType < bool >			{ static void Push( State * pThis, bool value )			 { pThis->PushBool( value ); } };
	template <> struct PushType < float >			{ static void Push( State * pThis, float value )		 { pThis->PushFloat( value ); } };
	template <> struct PushType < int >				{ static void Push( State * pThis, int value )			 { pThis->PushInt( value ); } };
	template <> struct PushType < lua_State * >		{ static void Push( State * pThis, lua_State * value )	 { pThis->PushThread( value ); } };
	template <> struct PushType < Table >			{ static void Push( State * pThis, Table & value )		 { pThis->PushTable( value ); } };
	template <> struct PushType < Vec2 >			{ static void Push( State * pThis, Vec2 const & value )	 { pThis->PushVec2( value ); } };
	template <> struct PushType < Vec3 >			{ static void Push( State * pThis, Vec3 const & value )	 { pThis->PushVec3( value ); } };
	template <> struct PushType < Vec4 >			{ static void Push( State * pThis, Vec4 const & value )	 { pThis->PushVec4( value ); } };

	//////////////////////////////////////////////////////////////////////////

	int	DebugStackTop() const;

protected:
	lua_State *		m_pL;
	
private:
	void SetupTypedUserdataGc () const;

	friend Table;
	friend Chunk;
	friend Thread;
};

///
/// LUA Chunk
///
class Chunk
{
public:
	typedef string Name_t;

	void Push();

	bool	IsFuncTable() const;
	Table & FuncTable() const;

	bool	FuncTableConstruct();
	void	FuncTableDestruct();
	bool	FuncTableReload();

	Host &	m_Host;
	Name_t const & Name() const;

private:
	Chunk( Host & host, Name_t const & name );
	~Chunk();

	void ChunkFunctionRegister();
	void ChunkFunctionUnregister();

	Name_t	m_Name;
	Table *	m_pFuncTable;

private:
	void operator=( Chunk const & ) {}
	friend Host;
};

///
/// LUA scripting HOST
///
class Host : public State
{
public:
	Host();
	~Host();

	Table &		TableConstruct();
	void		TableDestruct ( Table & table );

	Chunk *		ChunkLoad ( Chunk::Name_t const & name, core::ByteStreamReader & stream );
	bool		ChunkReload ( Chunk & chunk, core::ByteStreamReader & stream );
	void		ChunkUnload ( Chunk & chunk );

	Table &		GetGlobalTable() const;

private:
	typedef core::List < Table * >	Tables_t;
	Tables_t						m_Tables;

	typedef core::List < Chunk * >	Chunks_t;
	Chunks_t						m_Chunks;

	Table *	m_pGlobalTable;

	void GcHandlerConstruct();
	void GcHandlerDestruct();

	void VecsOpsConstruct();
	void VecsOpsDestruct();
	void Vec2OpsConstruct();
	void Vec2OpsDestruct();
	void Vec3OpsConstruct();
	void Vec3OpsDestruct();
	void Vec4OpsConstruct();
	void Vec4OpsDestruct();

	void SignalMetatableConstruct();
	void SignalMetatableDestruct();

	bool ChunkFunctionLoad( core::ByteStreamReader & stream, Chunk::Name_t const & name );
};

///
/// LUA thread
///
class Thread : public State
{
public:
	Thread( State & parentState );
	~Thread();

	bool	Resume				( bool & finished, int nArgs, int & nResults );
	bool	ResumeFromFunction	( bool & finished, int nArgs, int & nResults );
	int		CoroutineYield();
	bool	IsYielded() const;

	lua_State *	GetLuaThread() const;
};

//////////////////////////////////////////////////////////////////////////

namespace WorkResult
{
	enum Enum
	{
		  RETURN = 0
		, YIELD
		, ERR
	};
}

class Continuation
{
public:
	void BeginState		() {}
	void EndState		() {}

protected:
	Continuation();
	virtual ~Continuation();

private:
	virtual WorkResult::Enum ProcessWork ( DataObject & This, float deltaTime, int & nWorkResults ) = 0;

	virtual void ProcessBeginState ( DataObject & This ) = 0;
	virtual void ProcessEndState ( DataObject & This ) = 0;

	friend class Call;
};

class Call
{
public:
	Call ( lua::State & parentState );
	~Call();

	Thread m_Thread;

	void SwitchCurrentContinuation ( DataObject & This, Continuation * pContinuation );	
	int	ThreadYield ();	
	Continuation * CurrentContinuation() const;

	WorkResult::Enum	FunctionCall ( DataObject & This, int nArgs, int & nResults );
	WorkResult::Enum	Work ( DataObject & This, float deltaTime );

private:
	Continuation * m_pCurrentContinuation;
};

} // lua

#endif // CoreLua_h
