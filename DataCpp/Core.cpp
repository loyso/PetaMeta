
#include "Core.h"

#include <stdlib.h>

namespace core {

Guid Guid::Empty;

static const uint8 hex2bin[] =
{
    0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,        /* 0x00 */
    0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,        /* 0x10 */
    0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,        /* 0x20 */
    0,1,2,3,4,5,6,7,8,9,0,0,0,0,0,0,        /* 0x30 */
    0,10,11,12,13,14,15,0,0,0,0,0,0,0,0,0,  /* 0x40 */
    0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,        /* 0x50 */
    0,10,11,12,13,14,15                     /* 0x60 */
};

Guid::Guid()
{
    Data1 = 0;
    Data2 = 0;
    Data3 = 0;
    Data4[ 0 ] = 0;
    Data4[ 1 ] = 0;
    Data4[ 2 ] = 0;
    Data4[ 3 ] = 0;
    Data4[ 4 ] = 0;
    Data4[ 5 ] = 0;
    Data4[ 6 ] = 0;
    Data4[ 7 ] = 0;
}

Guid::Guid( char const * s )
{
    int i;

    if (!s) { *this = Empty; return; }

    if (strlen((char*)s) != 36) { *this = Empty; return; }

    if ((s[8]!='-') || (s[13]!='-') || (s[18]!='-') || (s[23]!='-'))
        { *this = Empty; return; }

    for (i=0; i<36; i++)
    {
        if ((i == 8)||(i == 13)||(i == 18)||(i == 23)) continue;
        if (s[i] > 'f' || (!hex2bin[s[i]] && s[i] != '0')) { *this = Empty; return; };
    }

    /* in form XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX */

    Data1 = (hex2bin[s[0]] << 28 | hex2bin[s[1]] << 24 | hex2bin[s[2]] << 20 | hex2bin[s[3]] << 16 |
             hex2bin[s[4]] << 12 | hex2bin[s[5]]  << 8 | hex2bin[s[6]]  << 4 | hex2bin[s[7]]);
    Data2 =  hex2bin[s[9]] << 12 | hex2bin[s[10]] << 8 | hex2bin[s[11]] << 4 | hex2bin[s[12]];
    Data3 = hex2bin[s[14]] << 12 | hex2bin[s[15]] << 8 | hex2bin[s[16]] << 4 | hex2bin[s[17]];

    /* these are just sequential bytes */
    Data4[0] = hex2bin[s[19]] << 4 | hex2bin[s[20]];
    Data4[1] = hex2bin[s[21]] << 4 | hex2bin[s[22]];
    Data4[2] = hex2bin[s[24]] << 4 | hex2bin[s[25]];
    Data4[3] = hex2bin[s[26]] << 4 | hex2bin[s[27]];
    Data4[4] = hex2bin[s[28]] << 4 | hex2bin[s[29]];
    Data4[5] = hex2bin[s[30]] << 4 | hex2bin[s[31]];
    Data4[6] = hex2bin[s[32]] << 4 | hex2bin[s[33]];
    Data4[7] = hex2bin[s[34]] << 4 | hex2bin[s[35]];
}

Guid Guid::New()
{
	Guid guid;
	
	uint8 * pGuid = (uint8 *)&guid;
	for( int i = 0; i < 16; ++i )
		pGuid[ i ] = (uint8)rand();
		
    /* Clear the version bits and set the version (4) */
    guid.Data3 &= 0x0fff;
    guid.Data3 |= (4 << 12);
    /* Set the topmost bits of Data4 (clock_seq_hi_and_reserved) as
     * specified in RFC 4122, section 4.4.
     */
    guid.Data4[0] &= 0x3f;
    guid.Data4[0] |= 0x80;		
    
    return guid;
}

string Guid::ToString () const
{
	char strGuid [ 80 ];

	sprintf( strGuid, "%08x-%04x-%04x-%02x%02x-%02x%02x%02x%02x%02x%02x",
                 Data1, Data2, Data3,
                 Data4[0], Data4[1], Data4[2],
                 Data4[3], Data4[4], Data4[5],
                 Data4[6], Data4[7] );
                 
	return string( strGuid );
}

bool Guid::operator== ( Guid const & rhs ) const
{
	uint32 const * pThis = (uint32 const *)this;
	uint32 const * pRhs = (uint32 const *)&rhs;
	
	if ( pThis[0] != pRhs[0] ) return false;
	if ( pThis[1] != pRhs[1] ) return false;
	if ( pThis[2] != pRhs[2] ) return false;
	if ( pThis[3] != pRhs[3] ) return false;
	
	return true;
}

bool Guid::operator< ( Guid const & rhs ) const
{
	uint32 * pThis = (uint32 *)this;
	uint32 * pRhs = (uint32 *)&rhs;

	if ( pThis[0] == pRhs[0] )
	{
		if ( pThis[1] == pRhs[1] )
		{
			if ( pThis[2] == pRhs[2] )
			{
				return pThis[3] < pRhs[3];				
			}
			else
				return pThis[2] < pRhs[2];
		}
		else
			return pThis[1] < pRhs[1];
	}
	else
		return pThis[0] < pRhs[0];
}


struct ObjectsData
{
	typedef Dictionary < Guid, ReferenceObject * > GuidToObject_t;
	GuidToObject_t GuidToObject;
};

ObjectsData * gObjectsData = NULL;

void Objects::Init()
{
	CORE_ASSERT( gObjectsData == NULL );
	gObjectsData = new ObjectsData();
}

void Objects::Done()
{
	CORE_ASSERT( gObjectsData != NULL );
	delete gObjectsData;
	gObjectsData = NULL;
}

void Objects::Add( ReferenceObject & referenceObject )
{
	CORE_ASSERT( gObjectsData != NULL );
	gObjectsData->GuidToObject.Add( referenceObject.Get_Guid(), &referenceObject );
}

void Objects::Remove( ReferenceObject const & referenceObject )
{
	CORE_ASSERT( gObjectsData != NULL );
	gObjectsData->GuidToObject.Remove( referenceObject.Get_Guid() );
}

bool Objects::FindObject( core::Guid const & guid, core::ReferenceObject * & pReferenceObject )
{
	CORE_ASSERT( gObjectsData != NULL );
	return gObjectsData->GuidToObject.TryGetValue( guid, pReferenceObject );
}

////////////////////////////////////////

static const uint8 NetworkByteStream_SizeTag = 255;

struct NetworkByteStreamReader::Impl
{
	void const * bytes;
	size_t size;
	uint32 seek;
	
	template < typename T >
	bool Read( T & value )
	{
		if ( seek + sizeof(T) > size )
			return false;
			
		value = *(T const *)((uint8 const*)bytes + seek);
		seek += sizeof(T);
		return true;
	}
	
	bool ReadBytesCopy( uint32 bytesSize, void * out )
	{
		if ( seek + bytesSize > size )
			return false;
		
		memcpy( out, (uint8 const*)bytes + seek, bytesSize );
		seek += bytesSize;
		return true;
	}	

	bool ReadBytes( uint32 bytesSize, void const * & out )
	{
		if ( seek + bytesSize > size )
			return false;

		out = (uint8 const*)bytes + seek;	
		seek += bytesSize;
		return true;
	}	
};

NetworkByteStreamReader::NetworkByteStreamReader( void const * bytes, size_t size )
	: impl ( *new Impl )
{
	impl.bytes = bytes;
	impl.size = size;
	impl.seek = 0;
}
	
NetworkByteStreamReader::~NetworkByteStreamReader()
{
	delete &impl;
}

size_t NetworkByteStreamReader::Size() const
{
	return impl.size;
}

size_t NetworkByteStreamReader::SizeToRead() const
{
	return impl.size - impl.seek;
}

	
bool NetworkByteStreamReader::ReadFloat32( float32 & value )
{
	float32 raw;
	if (!impl.Read( raw ) )
		return false;
	value = ByteOrder::FromNetwork( raw );
	return true;
}

bool NetworkByteStreamReader::ReadUint8 ( uint8 & value )
{
	return impl.Read( value );
}

bool NetworkByteStreamReader::ReadUint16( uint16 & value )
{
	uint16 raw;
	if (!impl.Read( raw ) )
		return false;
	value = ByteOrder::FromNetwork( raw );
	return true;
}

bool NetworkByteStreamReader::ReadUint32( uint32 & value )
{
	uint32 raw;
	if (!impl.Read( raw ) )
		return false;
	value = ByteOrder::FromNetwork( raw );
	return true;
}

bool NetworkByteStreamReader::ReadUint64( uint64 & value )
{
	uint64 raw;
	if (!impl.Read( raw ) )
		return false;
	value = ByteOrder::FromNetwork( raw );
	return true;
}
		   
bool NetworkByteStreamReader::ReadInt8  ( int8 & value )
{
	return impl.Read( value );
}

bool NetworkByteStreamReader::ReadInt16 ( int16 & value )
{
	int16 raw;
	if (!impl.Read( raw ) )
		return false;
	value = ByteOrder::FromNetwork( raw );
	return true;
}

bool NetworkByteStreamReader::ReadInt32 ( int32 & value )
{
	int32 raw;
	if (!impl.Read( raw ) )
		return false;
	value = ByteOrder::FromNetwork( raw );
	return true;
}

bool NetworkByteStreamReader::ReadInt64 ( int64 & value )
{
	int64 raw;
	if (!impl.Read( raw ) )
		return false;
	value = ByteOrder::FromNetwork( raw );
	return true;
}

bool NetworkByteStreamReader::ReadSize( uint32 & size )
{
	uint8 sizeSmall;
	if ( !ReadUint8( sizeSmall ) )
		return false;
	if ( sizeSmall != NetworkByteStream_SizeTag )
	{
		size = sizeSmall;
		return true;
	}

	return ReadUint32( size );
}

bool NetworkByteStreamReader::ReadBytesCopy( uint32 size, void * bytes )
{
	return impl.ReadBytesCopy( size, bytes );
}

bool NetworkByteStreamReader::ReadBytes( uint32 size, void const * & bytes )
{
	return impl.ReadBytes( size, bytes );
}

bool NetworkByteStreamReader::ReadGuid( Guid & guid )
{
	Guid raw;
	if (!impl.Read( raw ) )
		return false;
	guid = raw.FromNetwork();
	return true; 
}

struct NetworkByteStreamWriter::Impl
{
	void * bytes;
	size_t size;
	uint32 seek;
	
	template < typename T >
	bool Write( T const & value )
	{
		if ( seek + sizeof(T) > size )
			return false;
		*(T *)((uint8 *)bytes + seek) = value;
		seek += sizeof(T);
		return true;
	}
	
	bool WriteBytes( uint32 bytesSize, void const * in )
	{
		if ( seek + bytesSize > size )
			return false;
		memcpy( (uint8 *)bytes + seek, in, bytesSize );	
		return true;
	}
};

NetworkByteStreamWriter::NetworkByteStreamWriter( void * bytes, size_t size )
	: impl( *new Impl)
{
	impl.bytes = bytes;
	impl.size = size;
	impl.seek = 0;
}

NetworkByteStreamWriter::~NetworkByteStreamWriter()
{
	delete &impl;
}

size_t NetworkByteStreamWriter::Size() const
{
	return impl.size;
}

size_t NetworkByteStreamWriter::SizeToWrite() const
{
	return impl.size - impl.seek;
}

bool NetworkByteStreamWriter::WriteFloat32( float32 value )
{
	return impl.Write( ByteOrder::ToNetwork(value) );
}

bool NetworkByteStreamWriter::WriteUint8 ( uint8 value )
{
	return impl.Write( value );
}

bool NetworkByteStreamWriter::WriteUint16( uint16 value )
{
	return impl.Write( ByteOrder::ToNetwork(value) );
}

bool NetworkByteStreamWriter::WriteUint32( uint32 value )
{
	return impl.Write( ByteOrder::ToNetwork(value) );
}

bool NetworkByteStreamWriter::WriteUint64( uint64 value )
{
	return impl.Write( ByteOrder::ToNetwork(value) );
}
		   
bool NetworkByteStreamWriter::WriteInt8  ( int8 value )
{
	return impl.Write( value );
}

bool NetworkByteStreamWriter::WriteInt16 ( int16 value )
{
	return impl.Write( ByteOrder::ToNetwork(value) );
}

bool NetworkByteStreamWriter::WriteInt32 ( int32 value )
{
	return impl.Write( ByteOrder::ToNetwork(value) );
}

bool NetworkByteStreamWriter::WriteInt64 ( int64 value )
{
	return impl.Write( ByteOrder::ToNetwork(value) );
}

bool NetworkByteStreamWriter::WriteSize( uint32 size )
{
	if ( size >= NetworkByteStream_SizeTag )
	{
		if ( !WriteUint8( NetworkByteStream_SizeTag ) )
			return false;
		return WriteUint32( size );
	}

	uint8 sizeSmall = (uint8)size;
	return WriteUint8( sizeSmall );
}

bool NetworkByteStreamWriter::WriteBytes( uint32 size, void const * bytes )
{
	return impl.WriteBytes( size, bytes );
}

bool NetworkByteStreamWriter::WriteGuid( Guid const & guid )
{
	return impl.Write( guid.ToNetwork() );
}

void Abort ( const char * szText, ... )
{
	// TODO: implement
}

} // namespace core
