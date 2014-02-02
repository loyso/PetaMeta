
#ifndef Metadata_Engine_Fundamental_h
#define Metadata_Engine_Fundamental_h

#include "Fundamental.Partial.h"

#include <string>
#include <cmath>

// missing fundamentals
typedef std::string string;
typedef unsigned char byte;

class Vec2
{
public:
	float x, y;

	/// constructor
	inline Vec2 () {};
	/// constructor from coords
	inline Vec2 ( float fX, float fY );

	/// operation minus
	inline Vec2		operator - () const;

	inline float &		operator []	( int i );
	inline float		operator []	( int i ) const;
	/// utopia data comparison
	inline bool			operator != ( const Vec2 & v ) const;
	/// utopia data comparison
	inline bool			operator == ( const Vec2 & v ) const;

	/// squared length of vector
	inline float		LengthSq ( void );
	/// length of vector
	inline float		Length () const;
	/// normalized vector
	inline Vec2 &	Normalize ();
};

///	Create 2-D vector from two point coordinates
inline Vec2::Vec2 ( float fX, float fY )
	: x ( fX ), y ( fY )
{
}

inline float & Vec2::operator [] ( int i )
{
	return *( (float *)this + i );
}

inline float	Vec2::operator [] ( int i ) const
{
	return *( (float *)this + i );
}


/// utopia data comparison
inline bool Vec2::operator != ( const Vec2 & v ) const
{
	return x != v.x || y != v.y;
}

/// utopia data comparison
inline bool Vec2::operator == ( const Vec2 & v ) const
{
	return !operator !=(v);
}

///	change sign of vector components
inline Vec2 Vec2::operator - () const
{
	return Vec2 ( -x, -y );
}

///////////////////////////////////////////////////////////////////////////////

///	Compute the square of the length of a 2-D vector
inline float
Vec2::LengthSq ( void )
{
	return x * x + y * y;
}


///	Compute the length of a 2-D vector
float Vec2::Length () const
{
	return sqrt ( x * x + y * y );
}

///	Compute a unit length 2-D vector
Vec2 & Vec2::Normalize ()
{
	const float iN = 1.0f / sqrt( x * x + y * y );
	x *= iN;
	y *= iN;
	return *this;
}


///	Compute the dot product of two 2-D vectors
inline float Vec2Dot ( const Vec2 & v1, const Vec2 & v2 )
{
	return v1.x * v2.x + v1.y * v2.y;
}


///	Compute the square of the length of a 2-D vector
inline float Vec2LengthSq ( const Vec2 & v )
{
	return v.x * v.x + v.y * v.y;
}


///	Compute the length of a 2-D vector
inline float Vec2Length ( const Vec2 & v )
{
	return sqrt ( v.x * v.x + v.y * v.y );
}


///	Compute a unit length 2-D vector
inline void Vec2Normalize ( Vec2 & result, const Vec2 & v )
{
	float iN = 1.0f / sqrt( v.x * v.x + v.y * v.y );
	result.x = v.x * iN;
	result.y = v.y * iN;
}


///	Add two 2-D vectors
inline Vec2 operator + ( const Vec2 & a, const Vec2 & b )
{
	return Vec2(a.x+b.x, a.y+b.y);
}


///	Subtract two 2-D vectors
inline Vec2 operator - ( const Vec2 & a, const Vec2 & b )
{
	return Vec2(a.x-b.x, a.y-b.y);
}


///	Multiply components of two 2-D vectors
inline Vec2 operator * ( const Vec2 & a, const Vec2 & b )
{
	return Vec2(a.x*b.x, a.y*b.y);
}


///	Add 2-D vector to another one
inline Vec2 & operator += ( Vec2 & a, const Vec2 & b )
{
	a.x += b.x;
	a.y += b.y;
	return a;
}


///	Subtract 2-D vector from another one
inline Vec2 & operator -= ( Vec2 & a, const Vec2 & b )
{
	a.x -= b.x;
	a.y -= b.y;
	return a;
}


///	Multiply components of two 2-D vectors
inline Vec2 & operator *= ( Vec2 & a, const Vec2 & b )
{
	a.x *= b.x;
	a.y *= b.y;
	return a;
}


///	Multiply 2-D vector by a floating point number
inline Vec2 operator *	( const Vec2 & a, float f )
{
	return Vec2 ( a.x * f, a.y * f );
}


///	Multiply 2-D vector by a floating point number
inline Vec2 operator *	( float f, const Vec2 & a )
{
	return Vec2 ( a.x * f, a.y * f );
}


///	Multiply 2-D vector by a floating point number
inline Vec2 & operator *=	( Vec2 & a, float f )
{
	a.x *= f;
	a.y *= f;
	return a;
}


///	Divide 2-D vector by a floating point number
inline Vec2 operator /	( const Vec2 & a, float f )
{
	return Vec2 ( a.x / f, a.y / f );
}


///	Divide 2-D vector by a floating point number
inline Vec2 & operator /=		( Vec2 & a, float f )
{
	a.x /= f;
	a.y /= f;
	return a;
}

///////////////////////////////////////////////////////////////////////////////

class Vec3
{
public:
	float x, y, z;

	/// constructor
	inline Vec3 () {};
	/// constructor from coords
	inline Vec3 ( float fX, float fY, float fZ );
	/// assignment operator
	inline Vec3 &	operator = ( const Vec3 & v );
	/// assignment plus operator
	inline Vec3 &	operator += ( const Vec3 & v );
	/// assignment minus operator
	inline Vec3 &	operator -= ( const Vec3 & v );

	/// operator plus
	inline Vec3	operator + ( const Vec3 & v ) const;
	/// operator minus
	inline Vec3	operator - ( const Vec3 & v ) const;
	/// operator multiply
	inline Vec3	operator * ( float f ) const;
	/// operator multiply
	inline Vec3	operator * ( const Vec3 & ) const;
	/// 
	inline Vec3 &	operator *= ( float f );
	
	/// operator unary minus
	inline Vec3	operator - () const;
											
	inline float &		operator []	( int i );
	inline float		operator []	( int i ) const;
	inline bool			operator == ( const Vec3 & v ) const;
	inline bool			operator != ( const Vec3 & v ) const;
	
	inline Vec3 &		operator /= ( float f );
	inline Vec3			operator / ( float f ) const;
};

///	Build 3-D vector from point coordinates
inline Vec3::Vec3 ( float fX, float fY, float fZ )
	: x ( fX ), y ( fY ), z ( fZ )
{
}

inline Vec3 & Vec3::operator = ( const Vec3 & v )
{
	x = v.x; y = v.y; z = v.z;
	return *this;
}

///	Add 3-D vector to another one
inline Vec3 & Vec3::operator += ( const Vec3 & v )
{
	x += v.x; y += v.y; z += v.z;
	return *this;
}

inline Vec3 & Vec3::operator -= ( const Vec3 & v )
{
	x -= v.x; y -= v.y; z -= v.z;
	return * this;
}

inline float & Vec3::operator [] ( int iIndex )
{
	return *( (float *)this + iIndex );
}

inline float Vec3::operator [] ( int iIndex ) const
{

	return *( (float *)this + iIndex );
}

inline bool Vec3::operator == ( const Vec3 & v ) const
{
	return x == v.x && y == v.y && z == v.z;
}

inline bool Vec3::operator != ( const Vec3 & v ) const
{
	return !operator == ( v );
}

inline Vec3 Vec3Cross( const Vec3 & a, const Vec3 & b )
{
	Vec3 out;
	out.x=a.y*b.z - a.z*b.y; out.y=a.z*b.x - a.x*b.z; out.z=a.x*b.y - a.y*b.x;
	return out;
}

///	Add two 3-D vectors
inline Vec3 Vec3::operator + ( const Vec3 & v ) const
{
	return Vec3 ( x+v.x, y+v.y, z+v.z );
}


///	Subtract two 3-D vectors
inline Vec3
Vec3::operator - ( const Vec3 & v ) const
{
	return Vec3 ( x-v.x, y-v.y, z-v.z );
}


///	Multiply 3-D vector by a floating point number
inline Vec3
Vec3::operator * ( float f ) const
{
	return Vec3 ( x*f, y*f, z*f );
}

inline Vec3 &
Vec3::operator *= ( float f )
{
	x *= f;
	y *= f; 
	z *= f;
	
	return * this;
}


/// operator unary minus
inline Vec3 Vec3::operator - () const
{
	return Vec3 ( -x, -y, -z );
}


///	Multiply 3-D vector by a floating point number
inline Vec3 operator * ( float f, const Vec3 & a )
{
	return a * f;
}

inline Vec3 & Vec3::operator /= ( float f )
{
	x /= f; y /=f; z /= f;
	return *this;
}

inline Vec3	Vec3::operator / ( float f ) const
{
	return Vec3( x/f, y/f, z/f );
}

///	Compute the dot-product of two 3-D vectors
inline float Vec3Dot ( const  Vec3 & a, const Vec3 & b )
{
	return a.x*b.x + a.y*b.y + a.z*b.z;
}

///	Returns the square of the length of a 3-D vector
inline float Vec3LengthSq ( const  Vec3 & v )
{
	return v.x*v.x + v.y*v.y + v.z*v.z;
}


///	Returns the length of a 3-D vector
inline float Vec3Length ( const  Vec3 & v )
{
	return sqrt ( Vec3LengthSq ( v ) );
}

///	Returns the normalized version of a 3-D vector
inline Vec3 Vec3Normalize ( const Vec3 & v )
{
	return v * ( 1.0f/ Vec3Length ( v ) );
}

//////////////////////////////////////////////////////////////////////////

class Vec4
{
public:
	float x, y, z, w;

	inline				Vec4 () {};
	inline				Vec4 ( float fX, float fY, float fZ, float fW );

	inline bool			operator == ( const Vec4 & v ) const;
	inline bool			operator != ( const Vec4 & v ) const;

	inline Vec4 &	operator += ( const Vec4 & v );
	inline Vec4 &	operator -= ( const Vec4 & v );
	
	inline Vec4		operator - () const;

	inline float &	operator []	( int i );
	inline float	operator []	( int i ) const;

	inline float	LengthSq ();
	inline float	Length ();
	inline Vec4		Normalize ();
};

inline Vec4::Vec4 ( float fX, float fY, float fZ, float fW )
	: x ( fX ), y ( fY ), z ( fZ ), w ( fW )
{
}

inline bool Vec4::operator == ( const Vec4 & v ) const
{
	return x == v.x && y == v.y && z == v.z && w == v.w;
}

inline bool Vec4::operator != ( const Vec4 & v ) const
{
	return !operator == ( v );
}

inline float Vec4Dot ( Vec4 a, Vec4 b )
{
	return a.x*b.x + a.y*b.y + a.z*b.z + a.w*b.w;
}

inline float Vec4LengthSq ( const Vec4 & v )
{
	return v.x*v.x + v.y*v.y + v.z*v.z + v.w*v.w;
}


inline float Vec4Length ( const Vec4 & v )
{
	return sqrt ( Vec4LengthSq ( v ) );
}


inline Vec4 & Vec4::operator += ( const Vec4 & v )
{
	x += v.x;
	y += v.y;
	z += v.z;
	w += v.w;
	
	return *this;
}

inline Vec4 & Vec4::operator -= ( const Vec4 & v )
{
	x -= v.x;
	y -= v.y;
	z -= v.z;
	w -= v.w;
	
	return *this;
}

inline Vec4 Vec4::operator - () const
{
	return Vec4 ( -x, -y, -z, -w );
}

inline Vec4 operator * ( const Vec4 & v0, const Vec4 & v1 )
{
	return Vec4 ( v0.x*v1.x, v0.y*v1.y, v0.z*v1.z, v0.w*v1.w );
}


inline Vec4 operator * ( const Vec4 & v0, float f )
{
	return Vec4 ( v0.x*f, v0.y*f, v0.z*f, v0.w*f );
}


inline Vec4 operator * ( float f, const Vec4 & v0 )
{
	return Vec4 ( v0.x*f, v0.y*f, v0.z*f, v0.w*f );
}

inline Vec4 operator / ( const Vec4 & v0, float f )
{
	return Vec4 ( v0.x/f, v0.y/f, v0.z/f, v0.w/f );
}

inline Vec4 operator - ( const Vec4 & v0, const Vec4 & v1 )
{
	Vec4 v;
	
	v.x = v0.x - v1.x;
	v.y = v0.y - v1.y;
	v.z = v0.z - v1.z;
	v.w = v0.w - v1.w;
	
	return v;
}


inline Vec4 operator + ( const Vec4 & v0, const Vec4 & v1 )
{
	Vec4 v;

	v.x = v0.x + v1.x;
	v.y = v0.y + v1.y;
	v.z = v0.z + v1.z;
	v.w = v0.w + v1.w;

	return v;
}


inline float & Vec4::operator [] ( int iIndex )
{
	return *( (float *)this + iIndex );
}

inline float Vec4::operator [] ( int iIndex ) const
{

	return *( (float *)this + iIndex );
}

//////////////////////////////////////////////////////////////////////////

class Color
{
public:
	Color() {}
	Color( byte r, byte g, byte b, byte a )
		: r(r), g(g), b(b), a(a)
	{
	}
	byte r;
	byte g;
	byte b;
	byte a;
};

////////////////////////////////////////////////////////////////////////// BOXED VALUES

class bool_Boxed : public core::DataObject
{
public:
	bool value;
};

class int_Boxed : public core::DataObject
{
public:
	int value;
};

class string_Boxed : public core::DataObject
{
public:
	string value;
};

class float_Boxed : public core::DataObject
{
public:
	float value;
};

class byte_Boxed : public core::DataObject
{
public:
	byte value;
};


class Vec2_Boxed : public core::DataObject
{
public:
	Vec2 value;
};

			
class Vec3_Boxed : public core::DataObject
{
public:
	Vec3 value;
};

			
class Vec4_Boxed : public core::DataObject
{
public:
	Vec4 value;
};
	
class Color_Boxed : public core::DataObject
{
public:
	Color value;
};


#endif // Metadata_Engine_Fundamental_h
