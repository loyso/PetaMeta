#ifndef Core_h
#define Core_h

#define _CRT_SECURE_NO_WARNINGS
#include <cassert>

#include <vector>
#include <string>
// #include <algorithm>
#include <hash_map>

typedef std::string string;

#define CORE_ASSERT assert
#define CORE_ABORT Abort

#define CORE_NEW new
#define CORE_DELETE delete

#define CORE_PLACEMENT_NEW new

#define CORE_ALLOC malloc
#define CORE_REALLOC realloc
#define CORE_FREE delete

namespace core {

typedef unsigned char		uint8;
typedef unsigned short		uint16;
typedef unsigned int		uint32;
typedef unsigned long long	uint64;

typedef char		int8;
typedef short		int16;
typedef int			int32;
typedef long long	int64;

typedef float		float32;
typedef double		float64;

class Guid;

template < typename T >
struct Optional
{
	T Value;
	bool IsNull;

	Optional() : Value(), IsNull(true) {}

	Optional ( T value ) : Value(value), IsNull(false) {}
};

template < typename T >
Optional<T> MakeOptional( T value )
{
	return Optional<T>( value );
}

class ByteStreamReader
{
public:
	virtual size_t Size() const = 0;
	virtual size_t SizeToRead() const = 0;
	
	virtual bool ReadFloat32( float32 & value ) = 0;

	virtual bool ReadUint8 ( uint8 & value ) = 0;
	virtual bool ReadUint16( uint16 & value ) = 0;
	virtual bool ReadUint32( uint32 & value ) = 0;
	virtual bool ReadUint64( uint64 & value ) = 0;
			   
	virtual bool ReadInt8  ( int8 & value ) = 0;
	virtual bool ReadInt16 ( int16 & value ) = 0;
	virtual bool ReadInt32 ( int32 & value ) = 0;
	virtual bool ReadInt64 ( int64 & value ) = 0;
	
	virtual bool ReadSize( uint32 & size ) = 0;
	
	virtual bool ReadBytesCopy( uint32 size, void * bytes ) = 0;
	virtual bool ReadBytes( uint32 size, void const * & bytes ) = 0;
	
	virtual bool ReadGuid( Guid & guid ) = 0;

	template< typename T >
	bool ReadEnum( T & value )
	{
		int32 raw;
		if ( !ReadInt32(raw) )
			return false;
		value = (T)raw;
		return true;
	}
};

class ByteStreamWriter
{
public:
	virtual size_t Size() const = 0;
	virtual size_t SizeToWrite() const = 0;

	virtual bool WriteFloat32( float32 value ) = 0;

	virtual bool WriteUint8 ( uint8 value ) = 0;
	virtual bool WriteUint16( uint16 value ) = 0;
	virtual bool WriteUint32( uint32 value ) = 0;
	virtual bool WriteUint64( uint64 value ) = 0;
			   
	virtual bool WriteInt8  ( int8 value ) = 0;
	virtual bool WriteInt16 ( int16 value ) = 0;
	virtual bool WriteInt32 ( int32 value ) = 0;
	virtual bool WriteInt64 ( int64 value ) = 0;
	
	virtual bool WriteSize( uint32 size ) = 0;
	virtual bool WriteBytes( uint32 size, void const * bytes ) = 0;

	virtual bool WriteGuid( Guid const & guid ) = 0;

	template< typename T >
	bool WriteEnum( T value )
	{
		return WriteInt32(value);
	}
};

class NetworkByteStreamReader : public ByteStreamReader
{
public:
	NetworkByteStreamReader( void const * bytes, size_t size );
	~NetworkByteStreamReader();
	
	size_t Size() const;
	size_t SizeToRead() const;
	
	bool ReadFloat32( float32 & value );

	bool ReadUint8 ( uint8 & value );
	bool ReadUint16( uint16 & value );
	bool ReadUint32( uint32 & value );
	bool ReadUint64( uint64 & value );
			   
	bool ReadInt8  ( int8 & value );
	bool ReadInt16 ( int16 & value );
	bool ReadInt32 ( int32 & value );
	bool ReadInt64 ( int64 & value );
	
	bool ReadSize( uint32 & size );
	
	bool ReadBytesCopy( uint32 size, void * bytes );
	bool ReadBytes( uint32 size, void const * & bytes );
	
	bool ReadGuid( Guid & guid );
	
private:
	void operator=( NetworkByteStreamReader const & ) {}
	struct	Impl;
	Impl &	impl;
};

class NetworkByteStreamWriter : public ByteStreamWriter
{
public:
	NetworkByteStreamWriter( void * bytes, size_t size );
	~NetworkByteStreamWriter();
	
	size_t Size() const;
	size_t SizeToWrite() const;

	bool WriteFloat32( float32 value );

	bool WriteUint8 ( uint8 value );
	bool WriteUint16( uint16 value );
	bool WriteUint32( uint32 value );
	bool WriteUint64( uint64 value );
			   
	bool WriteInt8  ( int8 value );
	bool WriteInt16 ( int16 value );
	bool WriteInt32 ( int32 value );
	bool WriteInt64 ( int64 value );
	
	bool WriteSize( uint32 size );
	bool WriteBytes( uint32 size, void const * bytes );

	bool WriteGuid( Guid const & guid );

private:
	void operator=( NetworkByteStreamWriter const & ) {}
	struct	Impl;
	Impl &	impl;
};


class ByteOrder
{
public:
	static int16 FlipBytes(int16 value);
	static uint16 FlipBytes(uint16 value);
	static int32 FlipBytes(int32 value);
	static uint32 FlipBytes(uint32 value);
#if defined(CORE_HAVE_INT64)
	static int64 FlipBytes(int64 value);
	static uint64 FlipBytes(uint64 value);
#endif

	static int16 ToBigEndian(int16 value);
	static uint16 ToBigEndian (uint16 value);
	static int32 ToBigEndian(int32 value);
	static uint32 ToBigEndian (uint32 value);
#if defined(CORE_HAVE_INT64)
	static int64 ToBigEndian(int64 value);
	static uint64 ToBigEndian (uint64 value);
#endif

	static int16 FromBigEndian(int16 value);
	static uint16 FromBigEndian (uint16 value);
	static int32 FromBigEndian(int32 value);
	static uint32 FromBigEndian (uint32 value);
#if defined(CORE_HAVE_INT64)
	static int64 FromBigEndian(int64 value);
	static uint64 FromBigEndian (uint64 value);
#endif

	static int16 ToLittleEndian(int16 value);
	static uint16 ToLittleEndian (uint16 value);
	static int32 ToLittleEndian(int32 value);
	static uint32 ToLittleEndian (uint32 value);
#if defined(CORE_HAVE_INT64)
	static int64 ToLittleEndian(int64 value);
	static uint64 ToLittleEndian (uint64 value);
#endif

	static int16 FromLittleEndian(int16 value);
	static uint16 FromLittleEndian (uint16 value);
	static int32 FromLittleEndian(int32 value);
	static uint32 FromLittleEndian (uint32 value);
#if defined(CORE_HAVE_INT64)
	static int64 FromLittleEndian(int64 value);
	static uint64 FromLittleEndian (uint64 value);
#endif

	static int16 ToNetwork(int16 value);
	static uint16 ToNetwork (uint16 value);
	static int32 ToNetwork(int32 value);
	static uint32 ToNetwork (uint32 value);
	static float32 ToNetwork (float32 value);
#if defined(CORE_HAVE_INT64)
	static int64 ToNetwork(int64 value);
	static uint64 ToNetwork (uint64 value);
#endif

	static int16 FromNetwork(int16 value);
	static uint16 FromNetwork (uint16 value);
	static int32 FromNetwork(int32 value);
	static uint32 FromNetwork (uint32 value);
	static float32 FromNetwork (float32 value);
#if defined(CORE_HAVE_INT64)
	static int64 FromNetwork(int64 value);
	static uint64 FromNetwork (uint64 value);
#endif
};

inline uint16 ByteOrder::FlipBytes(uint16 value)
{
	return ((value >> 8) & 0x00FF) | ((value << 8) & 0xFF00);
}
inline int16 ByteOrder::FlipBytes(int16 value)
{
	return int16(FlipBytes(uint16(value)));
}
inline uint32 ByteOrder::FlipBytes(uint32 value)
{
	return ((value >> 24) & 0x000000FF) | ((value >> 8) & 0x0000FF00)
	     | ((value << 8) & 0x00FF0000) | ((value << 24) & 0xFF000000);
}
inline int32 ByteOrder::FlipBytes(int32 value)
{
	return int32(FlipBytes(uint32(value)));
}
#if defined(CORE_HAVE_INT64)
inline uint64 ByteOrder::FlipBytes(uint64 value)
{
	uint32 hi = uint32(value >> 32);
	uint32 lo = uint32(value & 0xFFFFFFFF);
	return uint64(FlipBytes(hi)) | (uint64(FlipBytes(lo)) << 32);
}
inline int64 ByteOrder::FlipBytes(int64 value)
{
	return int64(FlipBytes(uint64(value)));
}
#endif // CORE_HAVE_INT64

inline float32 ByteOrder::FromNetwork(float32 value)
{
	uint32 v = FromNetwork( *(uint32*)&value );
	return *(float32*)&v;
}

inline float32 ByteOrder::ToNetwork(float32 value)
{
	uint32 v = ToNetwork( *(uint32*)&value );
	return *(float32*)&v;
}

#define CORE_IMPLEMENT_BYTEORDER_NOOP_(op, type) \
	inline type ByteOrder::op(type value)		\
	{											\
		return value;							\
	}
#define CORE_IMPLEMENT_BYTEORDER_FLIP_(op, type) \
	inline type ByteOrder::op(type value)		\
	{											\
		return FlipBytes(value);				\
	}

#if defined(CORE_HAVE_INT64)
	#define CORE_IMPLEMENT_BYTEORDER_NOOP(op) \
		CORE_IMPLEMENT_BYTEORDER_NOOP_(op, int16)	\
		CORE_IMPLEMENT_BYTEORDER_NOOP_(op, uint16)	\
		CORE_IMPLEMENT_BYTEORDER_NOOP_(op, int32)	\
		CORE_IMPLEMENT_BYTEORDER_NOOP_(op, uint32)	\
		CORE_IMPLEMENT_BYTEORDER_NOOP_(op, int64)	\
		CORE_IMPLEMENT_BYTEORDER_NOOP_(op, uint64)
	#define CORE_IMPLEMENT_BYTEORDER_FLIP(op) \
		CORE_IMPLEMENT_BYTEORDER_FLIP_(op, int16)	\
		CORE_IMPLEMENT_BYTEORDER_FLIP_(op, uint16)	\
		CORE_IMPLEMENT_BYTEORDER_FLIP_(op, int32)	\
		CORE_IMPLEMENT_BYTEORDER_FLIP_(op, uint32)	\
		CORE_IMPLEMENT_BYTEORDER_FLIP_(op, int64)	\
		CORE_IMPLEMENT_BYTEORDER_FLIP_(op, uint64)
#else
	#define CORE_IMPLEMENT_BYTEORDER_NOOP(op) \
		CORE_IMPLEMENT_BYTEORDER_NOOP_(op, int16)	\
		CORE_IMPLEMENT_BYTEORDER_NOOP_(op, uint16)	\
		CORE_IMPLEMENT_BYTEORDER_NOOP_(op, int32)	\
		CORE_IMPLEMENT_BYTEORDER_NOOP_(op, uint32)
	#define CORE_IMPLEMENT_BYTEORDER_FLIP(op) \
		CORE_IMPLEMENT_BYTEORDER_FLIP_(op, int16)	\
		CORE_IMPLEMENT_BYTEORDER_FLIP_(op, uint16)	\
		CORE_IMPLEMENT_BYTEORDER_FLIP_(op, int32)	\
		CORE_IMPLEMENT_BYTEORDER_FLIP_(op, uint32)
#endif

#if defined(CORE_ARCH_BIG_ENDIAN)
	#define CORE_IMPLEMENT_BYTEORDER_BIG CORE_IMPLEMENT_BYTEORDER_NOOP
	#define CORE_IMPLEMENT_BYTEORDER_LIT CORE_IMPLEMENT_BYTEORDER_FLIP
#else
	#define CORE_IMPLEMENT_BYTEORDER_BIG CORE_IMPLEMENT_BYTEORDER_FLIP
	#define CORE_IMPLEMENT_BYTEORDER_LIT CORE_IMPLEMENT_BYTEORDER_NOOP
#endif

CORE_IMPLEMENT_BYTEORDER_BIG(ToBigEndian)
CORE_IMPLEMENT_BYTEORDER_BIG(FromBigEndian)
CORE_IMPLEMENT_BYTEORDER_BIG(ToNetwork)
CORE_IMPLEMENT_BYTEORDER_BIG(FromNetwork)
CORE_IMPLEMENT_BYTEORDER_LIT(ToLittleEndian)
CORE_IMPLEMENT_BYTEORDER_LIT(FromLittleEndian)


//
// C#-style Guid class
//
class Guid
{
public:
	Guid();
	Guid( char const * str );

	static Guid		New();
	static Guid		Empty;
	
	string			ToString () const;

	bool			IsEmpty() const
	{
		return *this == Empty;
	}

	bool operator== ( Guid const & rhs ) const;

	bool operator!= ( Guid const & rhs ) const
	{
		return !operator==( rhs );
	}

	bool operator< ( Guid const & rhs ) const;

	Guid ToNetwork() const
	{
		Guid guid = *this;
		guid.Data1 = ByteOrder::ToNetwork( this->Data1 );
		guid.Data2 = ByteOrder::ToNetwork( this->Data2 );
		guid.Data3 = ByteOrder::ToNetwork( this->Data3 );
		return guid;
	}
	Guid FromNetwork() const
	{
		Guid guid = *this;
		guid.Data1 = ByteOrder::FromNetwork( this->Data1 );
		guid.Data2 = ByteOrder::FromNetwork( this->Data2 );
		guid.Data3 = ByteOrder::FromNetwork( this->Data3 );
		return guid;
	}

private:
    uint32	Data1;
    uint16	Data2;
    uint16	Data3;
    uint8	Data4[ 8 ];
};

template < typename D, typename T >
D polymorphic_cast( T t )
{
	return dynamic_cast< D >( t );
}

template < typename D, typename T >
D polymorphic_downcast( T t )
{
#ifdef NDEBUG
	return static_cast< D >( t );
#else
	return dynamic_cast< D >( t );
#endif
}

//
// C#-style 'is' and 'as' operations
//
class DataObject
{
public:
	virtual ~DataObject() {}
	
	template < typename T >
	bool Is() const
	{
		return polymorphic_cast < T const * >( this ) != NULL;
	}

	template < typename T >
	T & As()
	{
		T * as = polymorphic_cast < T * >( this );
		CORE_ASSERT( as );
		return *as;
	}

	template < typename T >
	T const & As() const
	{
		T const * as = polymorphic_cast < T const * >( this );
		CORE_ASSERT( as );
		return *as;
	}
};


class ReferenceObject : public DataObject
{
public:
	Guid const & Get_Guid() const
	{
		return guid;
	}
	
	void Set_Guid( Guid const & newGuid )
	{
		guid = newGuid;
	}
	
private:
	Guid guid;
};


//
// C#-style Dictionary class
//
template < typename K, typename V >
class Dictionary
{
private:
	typedef stdext::hash_map < K, V >	Values_t;
	Values_t							Values;

public:
	typedef typename Values_t::const_iterator	ConstIterator;
	typedef typename Values_t::iterator			Iterator;
	typedef std::pair < K, V >					KeyValuePair;

	Iterator Begin()
	{
		return Values.begin();
	}

	Iterator End()
	{
		return Values.end();
	}
	
	ConstIterator Begin() const
	{
		return Values.begin();
	}

	ConstIterator End() const
	{
		return Values.end();
	}
	
	bool Empty() const
	{
		return Values.empty();
	}       	
	
    void Clear()
    {
		Values.clear();
    }
    
    bool ContainsKey( K key ) const
    {
		return Values.find( key ) != End();
    }

    bool ContainsValue( V value ) const
    {
		for ( ConstIterator i = Begin(), e = End(); i != e; ++i )
			if ( i->second == value )
				return true;
		return false;
    }
    
    void Add( K key, V value )
    {
		Values.insert( KeyValuePair(key,value) );
    }
    
    bool Remove( K key )
    {
		return Values.erase( key ) > 0;
    }
    
    bool TryGetValue( K key, V & value ) const
    {
		ConstIterator f = Values.find( key );
		if ( f == End() )
			return false;
		
		value = f->second;
		return true;
    }
};

class ICollection
{
public:
    void	Add( DataObject & item )				{ return Add_Unityped( item ); }
    void	Insert( int index, DataObject & item )	{ return Insert_Unityped( index, item ); }
    int		IndexOf( DataObject & item ) const		{ return IndexOf_Unityped( item ); }
    bool	Remove( DataObject & item )				{ return Remove_Unityped( item ); }
    void	RemoveAt( int index )					{ return RemoveAt_Unityped( index ); }
    void	Clear()									{ return Clear_Unityped(); }
	bool	Contains( DataObject & item ) const		{ return Contains_Unityped( item ); }
	bool	Empty() const							{ return Empty_Unityped(); }
	bool	CanContain( DataObject & item ) const	{ return CanContain_Unityped( item ); }
	
protected:
    virtual void	Add_Unityped( DataObject & item ) = 0;
    virtual void	Insert_Unityped( int index, DataObject & item ) = 0;
    virtual int		IndexOf_Unityped( DataObject & item ) const = 0;
    virtual bool	Remove_Unityped( DataObject & item ) = 0;
    virtual void	RemoveAt_Unityped( int index ) = 0;
    virtual void	Clear_Unityped() = 0;    
	virtual bool	Contains_Unityped( DataObject & item ) const = 0;
	virtual bool	Empty_Unityped() const = 0;
	virtual bool	CanContain_Unityped( DataObject & item ) const = 0;
};

//
// C#-style List class
//
template < typename T >
class List
{
private:
	typedef std::vector < T > Values_t;
	Values_t Values;
	
	struct Equal : std::unary_function < T, bool >
	{
		T value;
		
		Equal( T value ) : value ( value )
		{
		}
		result_type operator()(argument_type v)
		{
			return v == value;
		}
	};
	
public:
	typedef typename Values_t::const_iterator	ConstIterator;
	typedef typename Values_t::iterator			Iterator;
	
	Iterator Begin()
	{
		return Values.begin();
	}

	Iterator End()
	{
		return Values.end();
	}
	
	ConstIterator Begin() const
	{
		return Values.begin();
	}

	ConstIterator End() const
	{
		return Values.end();
	}
	
    void Add( T item )
    {
		Values.push_back( item );
    }
    
    void Insert( int index, T item )
    {
		Values.insert( Values.begin() + index, item );
    }
    
    int IndexOf( T item ) const
    {
		for ( Values_t::const_iterator i = Values.begin(), e = Values.end(); i != e; ++i )
			if ( *i == item )
				return i - Values.begin();			
		return -1;
    }
    
    bool Remove( T item )
    {
		// optimized, correct version. but requires <algorithm>.
		// return Values.erase( std::remove_if ( Begin(), End(), Equal(item) ), End() ) == End(); 
		for ( Values_t::const_iterator i = Values.begin(), e = Values.end(); i != e; ++i )
			if ( *i == item )
			{
				Values.erase( i );
				return true;
			}
		return false;
    }
    
    void RemoveAt( int index )
    {
		Values.erase( Values.begin() + index );
    }
    
    void Clear()
    {
		Values.clear();
    }
    
    template< typename P >
    T Find( P match ) const
    {
		for ( Values_t::const_iterator i = Values.begin(), e = Values.end(); i != e; ++i )
			if ( match( *i ) )
				return *i;
		return T();		
    }
    
	bool Contains( T item ) const
	{
		for ( Values_t::const_iterator i = Values.begin(), e = Values.end(); i != e; ++i )
			if ( *i == item )
				return true;
		return false;
	}
	
	bool Empty() const
	{
		return Values.empty();
	}
	
	int Count() const
	{
		return Values.size();
	}
	
	T & operator[]( int index )
	{
		return Values [ index ];
	}

	T const & operator[]( int index ) const
	{
		return Values [ index ];
	}

	void Resize( int count )
	{
		Values.resize( count );
	}
};

template < typename T >
class CollectionOf : public DataObject, public ICollection
{
private:
	typedef std::vector < T > Values_t;
	Values_t Values;
	
	struct Equal : std::unary_function < T, bool >
	{
		T value;
		
		Equal( T value ) : value ( value )
		{
		}
		result_type operator()(argument_type v)
		{
			return v == value;
		}
	};

public:
	typedef typename Values_t::const_iterator	ConstIterator;
	typedef typename Values_t::iterator			Iterator;
	
	Iterator Begin()
	{
		return Values.begin();
	}

	Iterator End()
	{
		return Values.end();
	}
	
	ConstIterator Begin() const
	{
		return Values.begin();
	}

	ConstIterator End() const
	{
		return Values.end();
	}
	
    void Add( T item )
    {
		Values.push_back( item );
    }
    
    void Insert( int index, T item )
    {
		Values.insert( Values.begin() + index, item );
    }
    
    int IndexOf( T item ) const
    {
		for ( Values_t::const_iterator i = Values.begin(), e = Values.end(); i != e; ++i )
			if ( *i == item )
				return i - Values.begin();			
		return -1;
    }
    
    bool Remove( T item )
    {
		// optimized, correct version. but requires <algorithm>.
		// return Values.erase( std::remove_if ( Begin(), End(), Equal(item) ), End() ) == End(); 
		for ( Values_t::const_iterator i = Values.begin(), e = Values.end(); i != e; ++i )
			if ( *i == item )
			{
				Values.erase( i );
				return true;
			}
		return false;
    }
    
    void RemoveAt( int index )
    {
		Values.erase( Values.begin() + index );
    }
    
    void Clear()
    {
		Values.clear();
    }
    
    template< typename P >
    T Find( P match ) const
    {
		for ( Values_t::const_iterator i = Values.begin(), e = Values.end(); i != e; ++i )
			if ( match( *i ) )
				return *i;
		return T();		
    }
    
	bool Contains( T item ) const
	{
		for ( Values_t::const_iterator i = Values.begin(), e = Values.end(); i != e; ++i )
			if ( *i == item )
				return true;
		return false;
	}
	
	bool Empty() const
	{
		return Values.empty();
	}

private:
    virtual void Add_Unityped( DataObject & item )
    {
		T typedObject = polymorphic_cast < T >( &item );
		CORE_ASSERT( typedObject );
		return Add ( typedObject );
    }
    
    virtual void Insert_Unityped( int index, DataObject & item )
    {
		T typedObject = polymorphic_cast < T >( &item );
		CORE_ASSERT( typedObject );
		return Insert ( index, typedObject );
    }
    
    virtual int	IndexOf_Unityped( DataObject & item ) const
    {
		T typedObject = polymorphic_cast < T >( &item );
		CORE_ASSERT( typedObject );
		return IndexOf ( typedObject );
    }
    
    virtual bool Remove_Unityped( DataObject & item )
    {
		T typedObject = polymorphic_cast < T >( &item );
		CORE_ASSERT( typedObject );
		return Remove( typedObject );
    }
    
    virtual void RemoveAt_Unityped( int index )
    {
		return RemoveAt( index ); 
    }
    
    virtual void Clear_Unityped()
    {
		return Clear();
    }
	
	virtual bool Contains_Unityped( DataObject & item ) const
	{
		T typedObject = polymorphic_cast < T >( &item );
		CORE_ASSERT( typedObject );
		return Contains( typedObject );
	}
	
	virtual bool Empty_Unityped() const
	{
		return Empty();
	}
	
	virtual bool CanContain_Unityped( DataObject & item ) const
	{
		T typedObject = polymorphic_cast < T >( &item );
		return typedObject != NULL;
	}	
};

namespace detail
{
	template <typename T>
	inline size_t HashValue(T begin, T end)
	{	
		// hash range of elements
		size_t val = 2166136261U;
		while(begin != end)
			val = 16777619U * val ^ (size_t)*begin++;
		return val;
	}
}

namespace Objects
{
	void Init();
	void Done();

	void Add( ReferenceObject & referenceObject );
	void Remove( ReferenceObject const & referenceObject );

	bool FindObject( core::Guid const & guid, ReferenceObject * & pReferenceObject );
}

void Abort ( const char * szText, ... );

} // namespace core

// hash value computation for Guid class
template<> 
inline size_t stdext::hash_value(const core::Guid & key)
{	
	// return core::detail::HashValue( (core::uint32*)&key, (core::uint32*)(&key+1) );
	
	// optimized, loop unrolled
	core::uint32 * pGuid = (core::uint32 *)&key;
	
	size_t val = 2166136261U;
	size_t val0 = (16777619U * val ^ (size_t)(pGuid[0]));
	size_t val1 = (16777619U * val0 ^ (size_t)(pGuid[1]));
	size_t val2 = (16777619U * val1 ^ (size_t)(pGuid[2]));
	size_t val3 = (16777619U * val2 ^ (size_t)(pGuid[3]));
	
	return val3;
}

#endif // Core_h
