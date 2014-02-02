
// USER'S CODE FILE. PLACE YOUR CLASSES, DATA AND FUNCTIONS HERE.

#ifndef MetaMetadata_MetaFunction_h
#define MetaMetadata_MetaFunction_h

#include "MetaFunction.Partial.h"

namespace reflection { 

class Argument : public core::DataObject
	, public Argument_Partial
{
};

			
class Function : public Member
	, public Function_Partial
{
public:
	virtual bool FunctionCall_FromByteStream( core::ByteStreamReader & stream, reflection::MetadataClass const & type, core::ReferenceObject * pObjectUnityped )
	{ 
		return false;
	}
};

class FunctionUser : public Function
	, public FunctionUser_Partial
{
};
			
class FunctionLua : public Function
	, public FunctionLua_Partial
{
};

class FunctionLuaCallCC : public Function
	, public FunctionLuaCallCC_Partial
{
};
				
class ArgumentValue : public Argument
	, public ArgumentValue_Partial
{
};

			
class ArgumentReference : public Argument
	, public ArgumentReference_Partial
{
};

} /* namespace reflection */ 

#endif // MetaMetadata_MetaFunction_h
