
// USER'S CODE FILE. PLACE YOUR CLASSES, DATA AND FUNCTIONS HERE.

#ifndef MetaMetadata_MetaFundamental_h
#define MetaMetadata_MetaFundamental_h

#include "MetaFundamental.Partial.h"

namespace reflection { 

class bool_Boxed : public core::DataObject
{
public:
	bool value;
};

class string_Boxed : public core::DataObject
{
public:
	string value;
};

class int_Boxed : public core::DataObject
{
public:
	int value;
};

} /* namespace reflection */ 

#endif // MetaMetadata_MetaFundamental_h
