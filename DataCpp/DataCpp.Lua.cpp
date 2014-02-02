#include "DataCpp.Lua.h"

#include "Metadata\Game\Scene.Lua.h"
#include "Metadata\Game\Scene.Lua.h"

namespace data {

struct LuaData
{
};

static LuaData * gThis = NULL;

void LuaInit( lua::Host & host )
{
	CORE_ASSERT( gThis == NULL );
	gThis = CORE_NEW LuaData();
	
	scene::SceneObject_Lua::LuaTypeTableCreate( host );
	scene::SceneMesh_Lua::LuaTypeTableCreate( host );
}

void LuaDone( lua::Host & host )
{
	CORE_ASSERT( gThis );

	scene::SceneObject_Lua::LuaTypeTableDestroy( host );
	scene::SceneMesh_Lua::LuaTypeTableDestroy( host );
	
	CORE_DELETE gThis;
	gThis = NULL;
}

} // namespace data
