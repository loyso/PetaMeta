
// AUTOGENERATED FILE. MODIFY IT AT YOUR OWN RISK.

#include "Scene.h"

namespace scene { 

bool SceneObject_ByteStream::ObjectFromByteStream( core::ByteStreamReader & stream, scene::SceneObject & dataObject )
{
	Vec3 position; if ( !Vec3_ByteStream::ObjectFromByteStream( stream, position ) ) return false;
	dataObject.Set_position ( position );
	
	float scale; if ( !stream.ReadFloat32( scale ) ) return false;
	dataObject.Set_scale ( scale );
	
	Color color; if ( !Color_ByteStream::ObjectFromByteStream( stream, color ) ) return false;
	dataObject.Set_color ( color );
	
	int lod; if ( !stream.ReadInt32( lod ) ) return false;
	dataObject.Set_lod ( lod );
	
	core::uint8 visible_Byte; if ( !stream.ReadUint8( visible_Byte) ) return false;
	bool visible = !!visible_Byte;
	dataObject.Set_visible ( visible );
	
	core::uint8 isSoundEnabled_Byte; if ( !stream.ReadUint8( isSoundEnabled_Byte) ) return false;
	bool isSoundEnabled = !!isSoundEnabled_Byte;
	dataObject.Set_isSoundEnabled ( isSoundEnabled );
	
	core::uint8 isSfxEnabled_Byte; if ( !stream.ReadUint8( isSfxEnabled_Byte) ) return false;
	bool isSfxEnabled = !!isSfxEnabled_Byte;
	dataObject.Set_isSfxEnabled ( isSfxEnabled );
	
	return true;
}


SceneObject_Partial::SceneObject_Partial()
	: parent()
	, position()
	, scale(1.0f)
	, color()
	, lod(2)
	, visible()
	, next()
	, isSoundEnabled()
	, isSfxEnabled()
{
	{
		float x; float y; float z; x=1.0f, y=1.0f, z=1.0f;
		position.x = x; 
		position.y = y; 
		position.z = z; 
	}
	{
		byte r; byte g; byte b; byte a; a=0, r=255, g=255, b=255;
		color.r = r; 
		color.g = g; 
		color.b = b; 
		color.a = a; 
	}
}

SceneObject_Partial::~SceneObject_Partial()
{
	parent = NULL;
	next = NULL;
}

scene::Scene * SceneObject_Partial::Get_parent() const 
{ 
	return parent; 
}
void SceneObject_Partial::Set_parent( scene::Scene * value ) 
{ 
	parent = value; 
}

Vec3 const & SceneObject_Partial::Get_position() const 
{ 
	return position; 
}
void SceneObject_Partial::Set_position( Vec3 const & value ) 
{ 
	position = value; 
}

float SceneObject_Partial::Get_scale() const 
{ 
	return scale; 
}
void SceneObject_Partial::Set_scale( float value ) 
{ 
	scale = value; 
}

Color const & SceneObject_Partial::Get_color() const 
{ 
	return color; 
}
void SceneObject_Partial::Set_color( Color const & value ) 
{ 
	color = value; 
}

int SceneObject_Partial::Get_lod() const 
{ 
	return lod; 
}
void SceneObject_Partial::Set_lod( int value ) 
{ 
	lod = value; 
}

bool SceneObject_Partial::Get_visible() const 
{ 
	return visible; 
}
void SceneObject_Partial::Set_visible( bool value ) 
{ 
	visible = value; 
}

scene::SceneObject * SceneObject_Partial::Get_next() const 
{ 
	return next; 
}
void SceneObject_Partial::Set_next( scene::SceneObject * value ) 
{ 
	next = value; 
}

bool SceneObject_Partial::Get_isSoundEnabled() const 
{ 
	return isSoundEnabled; 
}
void SceneObject_Partial::Set_isSoundEnabled( bool value ) 
{ 
	isSoundEnabled = value; 
}

bool SceneObject_Partial::Get_isSfxEnabled() const 
{ 
	return isSfxEnabled; 
}
void SceneObject_Partial::Set_isSfxEnabled( bool value ) 
{ 
	isSfxEnabled = value; 
}


bool SceneObjectsCollection_ByteStream::ObjectFromByteStream( core::ByteStreamReader & stream, scene::SceneObjectsCollection & dataObject )
{
	return true;
}


SceneObjectsCollection_Partial::SceneObjectsCollection_Partial()
{
}

SceneObjectsCollection_Partial::~SceneObjectsCollection_Partial()
{
}


bool SceneMesh_ByteStream::ObjectFromByteStream( core::ByteStreamReader & stream, scene::SceneMesh & dataObject )
{
	Color colorSnd; if ( !Color_ByteStream::ObjectFromByteStream( stream, colorSnd ) ) return false;
	dataObject.Set_colorSnd ( colorSnd );
	
	return true;
}


SceneMesh_Partial::SceneMesh_Partial()
	: colorSnd()
{
}

SceneMesh_Partial::~SceneMesh_Partial()
{
}

Color const & SceneMesh_Partial::Get_colorSnd() const 
{ 
	return colorSnd; 
}
void SceneMesh_Partial::Set_colorSnd( Color const & value ) 
{ 
	colorSnd = value; 
}


bool SceneAnimMesh_ByteStream::ObjectFromByteStream( core::ByteStreamReader & stream, scene::SceneAnimMesh & dataObject )
{
	Vec3 positionSfx; if ( !Vec3_ByteStream::ObjectFromByteStream( stream, positionSfx ) ) return false;
	dataObject.Set_positionSfx ( positionSfx );
	
	return true;
}


SceneAnimMesh_Partial::SceneAnimMesh_Partial()
	: positionSfx()
{
}

SceneAnimMesh_Partial::~SceneAnimMesh_Partial()
{
}

Vec3 const & SceneAnimMesh_Partial::Get_positionSfx() const 
{ 
	return positionSfx; 
}
void SceneAnimMesh_Partial::Set_positionSfx( Vec3 const & value ) 
{ 
	positionSfx = value; 
}


bool SceneZoneTrigger_ByteStream::ObjectFromByteStream( core::ByteStreamReader & stream, scene::SceneZoneTrigger & dataObject )
{
	core::uint32 name_Size; if ( !stream.ReadSize( name_Size ) ) return false;
	void const * name_Bytes; if ( !stream.ReadBytes( name_Size, name_Bytes ) ) return false;
	string name ( (char*)name_Bytes, name_Size );
	dataObject.Set_name ( name );
	
	scene::TriggerType triggerType; if ( !stream.ReadEnum( triggerType ) ) return false;
	dataObject.Set_triggerType ( triggerType );
	
	scene::Controller ctrl; if ( !scene::Controller_ByteStream::ObjectFromByteStream( stream, ctrl ) ) return false;
	dataObject.Set_ctrl ( ctrl );
	
	return true;
}


SceneZoneTrigger_Partial::SceneZoneTrigger_Partial()
	: name("Trigger")
	, triggerType(scene::Character)
	, ctrl()
{
}

SceneZoneTrigger_Partial::~SceneZoneTrigger_Partial()
{
	CORE_DELETE ctrl;
	ctrl = NULL;
}

string SceneZoneTrigger_Partial::Get_name() const 
{ 
	return name; 
}
void SceneZoneTrigger_Partial::Set_name( string value ) 
{ 
	name = value; 
}

scene::TriggerType SceneZoneTrigger_Partial::Get_triggerType() const 
{ 
	return triggerType; 
}
void SceneZoneTrigger_Partial::Set_triggerType( scene::TriggerType value ) 
{ 
	triggerType = value; 
}

scene::Controller const & SceneZoneTrigger_Partial::Get_ctrl() const 
{ 
	CORE_ASSERT(ctrl); 
	return *ctrl; 
}
void SceneZoneTrigger_Partial::Set_ctrl( scene::Controller const & value ) 
{ 
	CORE_ASSERT(ctrl); 
	*ctrl = value; 
}


bool Scene_ByteStream::ObjectFromByteStream( core::ByteStreamReader & stream, scene::Scene & dataObject )
{
	scene::SceneObject mainObject; if ( !scene::SceneObject_ByteStream::ObjectFromByteStream( stream, mainObject ) ) return false;
	dataObject.Set_mainObject ( mainObject );
	
	return true;
}


Scene_Partial::Scene_Partial()
	: mainObject()
	, objects()
{
}

Scene_Partial::~Scene_Partial()
{
	CORE_DELETE mainObject;
	mainObject = NULL;
	for ( scene::SceneObjectsCollection_Partial::Iterator i = objects.Begin(), e = objects.End(); i != e; ++i )
		CORE_DELETE *i;
	objects.Clear();
}

scene::SceneObject const & Scene_Partial::Get_mainObject() const 
{ 
	CORE_ASSERT(mainObject); 
	return *mainObject; 
}
void Scene_Partial::Set_mainObject( scene::SceneObject const & value ) 
{ 
	CORE_ASSERT(mainObject); 
	*mainObject = value; 
}

scene::SceneObjectsCollection_Partial & Scene_Partial::Get_objects() 
{ 
	return objects; 
}
scene::SceneObjectsCollection_Partial const & Scene_Partial::Get_objects() const 
{ 
	return objects; 
}


bool Controller_ByteStream::ObjectFromByteStream( core::ByteStreamReader & stream, scene::Controller & dataObject )
{
	int priority; if ( !stream.ReadInt32( priority ) ) return false;
	dataObject.Set_priority ( priority );
	
	return true;
}


Controller_Partial::Controller_Partial()
	: priority(15)
{
}

Controller_Partial::~Controller_Partial()
{
}

int Controller_Partial::Get_priority() const 
{ 
	return priority; 
}
void Controller_Partial::Set_priority( int value ) 
{ 
	priority = value; 
}


bool ControllerBox_ByteStream::ObjectFromByteStream( core::ByteStreamReader & stream, scene::ControllerBox & dataObject )
{
	Vec3 size; if ( !Vec3_ByteStream::ObjectFromByteStream( stream, size ) ) return false;
	dataObject.Set_size ( size );
	
	return true;
}


ControllerBox_Partial::ControllerBox_Partial()
	: size()
{
}

ControllerBox_Partial::~ControllerBox_Partial()
{
}

Vec3 const & ControllerBox_Partial::Get_size() const 
{ 
	return size; 
}
void ControllerBox_Partial::Set_size( Vec3 const & value ) 
{ 
	size = value; 
}


bool ControllerSphere_ByteStream::ObjectFromByteStream( core::ByteStreamReader & stream, scene::ControllerSphere & dataObject )
{
	float radius; if ( !stream.ReadFloat32( radius ) ) return false;
	dataObject.Set_radius ( radius );
	
	return true;
}


ControllerSphere_Partial::ControllerSphere_Partial()
	: radius(1.5f)
{
}

ControllerSphere_Partial::~ControllerSphere_Partial()
{
}

float ControllerSphere_Partial::Get_radius() const 
{ 
	return radius; 
}
void ControllerSphere_Partial::Set_radius( float value ) 
{ 
	radius = value; 
}


} /* namespace scene */ 
