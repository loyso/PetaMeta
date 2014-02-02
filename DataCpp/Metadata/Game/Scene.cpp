
#include "Scene.h"

namespace scene { 

bool SceneObject::TestFunction ( int argInt, Vec3 const & argVec, SceneZoneTrigger * argRef, TriggerType argEnum, string const & argString, Color const & argColor )
{
	return true;
}

bool SceneObject::TestLua ( bool argBool, Vec3 const & argVec3, float argFloat, SceneObject * argRef )
{
	return true;
}

SceneAnimMesh * SceneMesh::TestLuaDerived( int argInt )
{
	return NULL;
}


} /* namespace scene */ 
