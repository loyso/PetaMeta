
#ifndef Metadata_Game_Scene_h
#define Metadata_Game_Scene_h

#include "Scene.Partial.h"
#include "Scene.Lua.h"

namespace scene { 

			
class SceneObject : public core::ReferenceObject
	, public SceneObject_Partial
	, public SceneObject_Lua
{
public:
	bool TestFunction ( int argInt, Vec3 const & argVec, SceneZoneTrigger * argRef, TriggerType argEnum, string const & argString, Color const & argColor );
	bool TestLua ( bool argBool, Vec3 const & argVec3, float argFloat, SceneObject * argRef );
};

			
class SceneMesh : public SceneObject
	, public SceneMesh_Partial
	, public SceneMesh_Lua
{
public:
	SceneAnimMesh * TestLuaDerived( int argInt );
};

			
class SceneAnimMesh : public SceneMesh
	, public SceneAnimMesh_Partial
{
};

			
class Controller : public core::ReferenceObject
	, public Controller_Partial
{
};

			
class SceneZoneTrigger : public SceneObject
	, public SceneZoneTrigger_Partial
{
};

			
class Scene : public core::ReferenceObject
	, public Scene_Partial
{
};

			
class ControllerBox : public Controller
	, public ControllerBox_Partial
{
};

			
class ControllerSphere : public Controller
	, public ControllerSphere_Partial
{
};

} /* namespace scene */ 

#endif // Metadata_Game_Scene_h
