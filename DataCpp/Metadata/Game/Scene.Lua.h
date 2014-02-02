#ifndef Metadata_Game_Scene_Lua_h
#define Metadata_Game_Scene_Lua_h

// AUTOGENERATED FILE. MODIFY IT AT YOUR OWN RISK.

// forward declarations from other files

struct lua_State;

namespace lua
{
	class Table;
	class Host;
}

// dependencies

#include "..\Engine\Fundamental.h"

namespace scene { 

	// forward declarations
	
	class SceneObject;
	class SceneObjectsCollection;
	class SceneMesh;
	class SceneAnimMesh;
	class SceneZoneTrigger;
	class Scene;
	class Controller;
	class ControllerBox;
	class ControllerSphere;
	
	// lua classes
	
	class SceneObject_Lua
	{
	public:
		SceneObject_Lua();
		~SceneObject_Lua();
		
		static void LuaTypeTableCreate( lua::Host & host );
		static void LuaTypeTableDestroy( lua::Host & host );
		
		static int LuaLookup ( lua_State * L );
		
		void LuaTableCreate( lua::Host & host );
		void LuaTableDestroy( lua::Host & host );
		bool TestLuaCC( float argStr, byte argByte);
		bool LuaConstructor();
		bool LuaDestructor();
	
		lua::Table &	LuaTable	() const;
		lua::Table *	LuaTableGet	() const;
		void			LuaTableSet	( lua::Table * pTable );	
	
	private:
		lua::Table * pLuaTable;
	};

	class SceneMesh_Lua
	{
	public:
		SceneMesh_Lua();
		~SceneMesh_Lua();
		
		static void LuaTypeTableCreate( lua::Host & host );
		static void LuaTypeTableDestroy( lua::Host & host );
		
		static int LuaLookup ( lua_State * L );
		
		void LuaTableCreate( lua::Host & host );
		void LuaTableDestroy( lua::Host & host );
		core::Optional<scene::Controller*> TestLuaCall( Vec2 const & argVal, scene::SceneMesh* argRef);
	};

} /* namespace scene */ 

#endif // Metadata_Game_Scene_Lua_h
