
// USER'S CODE FILE. PLACE YOUR CLASSES, DATA AND FUNCTIONS HERE.

#ifndef MetaMetadata_MetaPrimitives_h
#define MetaMetadata_MetaPrimitives_h

#include "MetaPrimitives.Partial.h"

namespace reflection { 

			
class Fundamental : public Type
	, public Fundamental_Partial
{
};

			
class FundamentalBool : public Fundamental
	, public FundamentalBool_Partial
{
};

			
class FundamentalString : public Fundamental
	, public FundamentalString_Partial
{
};

			
class FundamentalInt : public Fundamental
	, public FundamentalInt_Partial
{
};

			
class FundamentalFloat : public Fundamental
	, public FundamentalFloat_Partial
{
};

			
class FundamentalByte : public Fundamental
	, public FundamentalByte_Partial
{
};

			
class Enumeration : public Type
	, public Enumeration_Partial
{
};

			
class Enumerator : public core::DataObject
	, public Enumerator_Partial
{
};

} /* namespace reflection */ 

#endif // MetaMetadata_MetaPrimitives_h
