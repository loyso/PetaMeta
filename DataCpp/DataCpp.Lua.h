#ifndef DataCpp_Lua_h
#define DataCpp_Lua_h

#include "Core.h"

namespace lua
{
	class Host;
}

namespace data {

void LuaInit( lua::Host & host );
void LuaDone( lua::Host & host );

} // namespace data

#endif // DataCpp_Lua_h
