
// AUTOGENERATED FILE. MODIFY IT AT YOUR OWN RISK.

#ifndef Metadata_Game_Scene_Partial_h
#define Metadata_Game_Scene_Partial_h

#include "..\..\Core.h"

// forward declarations from other files


// dependencies

#include "..\Engine\Fundamental.h"

// forward declarations

namespace scene { 
	class SceneObject; class SceneObject_Partial;
	class SceneObjectsCollection; class SceneObjectsCollection_Partial;
	class SceneMesh; class SceneMesh_Partial;
	class SceneAnimMesh; class SceneAnimMesh_Partial;
	class SceneZoneTrigger; class SceneZoneTrigger_Partial;
	class Scene; class Scene_Partial;
	class Controller; class Controller_Partial;
	class ControllerBox; class ControllerBox_Partial;
	class ControllerSphere; class ControllerSphere_Partial;
}

namespace scene { 

	enum TriggerType
	{
		Projectile = 0,
		Character = 1,
	};
	
	class TriggerType_Boxed : public core::DataObject
	{
	public:
		TriggerType value;
	};
	
	// classes
	
	namespace SceneObject_ByteStream
	{
		bool ObjectFromByteStream( core::ByteStreamReader & stream, scene::SceneObject & dataObject );
	};

	class SceneObject_Partial
	{
	public:
		SceneObject_Partial();
		~SceneObject_Partial();

		scene::Scene * Get_parent() const;
		void Set_parent( scene::Scene * value );
		
		Vec3 const & Get_position() const;
		void Set_position( Vec3 const & value );
		
		float Get_scale() const;
		void Set_scale( float value );
		
		Color const & Get_color() const;
		void Set_color( Color const & value );
		
		int Get_lod() const;
		void Set_lod( int value );
		
		bool Get_visible() const;
		void Set_visible( bool value );
		
		scene::SceneObject * Get_next() const;
		void Set_next( scene::SceneObject * value );
		
		bool Get_isSoundEnabled() const;
		void Set_isSoundEnabled( bool value );
		
		bool Get_isSfxEnabled() const;
		void Set_isSfxEnabled( bool value );
		
	private:
		scene::Scene * parent;
		Vec3 position;
		float scale;
		Color color;
		int lod;
		bool visible;
		scene::SceneObject * next;
		bool isSoundEnabled;
		bool isSfxEnabled;
	};

	namespace SceneObjectsCollection_ByteStream
	{
		bool ObjectFromByteStream( core::ByteStreamReader & stream, scene::SceneObjectsCollection & dataObject );
	};

	class SceneObjectsCollection_Partial : public core::CollectionOf < scene::SceneObject * >
	{
	public:
		SceneObjectsCollection_Partial();
		~SceneObjectsCollection_Partial();
	};

	namespace SceneMesh_ByteStream
	{
		bool ObjectFromByteStream( core::ByteStreamReader & stream, scene::SceneMesh & dataObject );
	};

	class SceneMesh_Partial
	{
	public:
		SceneMesh_Partial();
		~SceneMesh_Partial();

		Color const & Get_colorSnd() const;
		void Set_colorSnd( Color const & value );
		
	private:
		Color colorSnd;
	};

	namespace SceneAnimMesh_ByteStream
	{
		bool ObjectFromByteStream( core::ByteStreamReader & stream, scene::SceneAnimMesh & dataObject );
	};

	class SceneAnimMesh_Partial
	{
	public:
		SceneAnimMesh_Partial();
		~SceneAnimMesh_Partial();

		Vec3 const & Get_positionSfx() const;
		void Set_positionSfx( Vec3 const & value );
		
	private:
		Vec3 positionSfx;
	};

	namespace Controller_ByteStream
	{
		bool ObjectFromByteStream( core::ByteStreamReader & stream, scene::Controller & dataObject );
	};

	class Controller_Partial
	{
	public:
		Controller_Partial();
		~Controller_Partial();

		int Get_priority() const;
		void Set_priority( int value );
		
	private:
		int priority;
	};

	namespace SceneZoneTrigger_ByteStream
	{
		bool ObjectFromByteStream( core::ByteStreamReader & stream, scene::SceneZoneTrigger & dataObject );
	};

	class SceneZoneTrigger_Partial
	{
	public:
		SceneZoneTrigger_Partial();
		~SceneZoneTrigger_Partial();

		string Get_name() const;
		void Set_name( string value );
		
		scene::TriggerType Get_triggerType() const;
		void Set_triggerType( scene::TriggerType value );
		
		scene::Controller const & Get_ctrl() const;
		void Set_ctrl( scene::Controller const & value );
		
	private:
		string name;
		scene::TriggerType triggerType;
		scene::Controller * ctrl;
	};

	namespace Scene_ByteStream
	{
		bool ObjectFromByteStream( core::ByteStreamReader & stream, scene::Scene & dataObject );
	};

	class Scene_Partial
	{
	public:
		Scene_Partial();
		~Scene_Partial();

		scene::SceneObject const & Get_mainObject() const;
		void Set_mainObject( scene::SceneObject const & value );
		
		scene::SceneObjectsCollection_Partial & Get_objects();
		scene::SceneObjectsCollection_Partial const & Get_objects() const;
		
	private:
		scene::SceneObject * mainObject;
		scene::SceneObjectsCollection_Partial objects;
	};

	namespace ControllerBox_ByteStream
	{
		bool ObjectFromByteStream( core::ByteStreamReader & stream, scene::ControllerBox & dataObject );
	};

	class ControllerBox_Partial
	{
	public:
		ControllerBox_Partial();
		~ControllerBox_Partial();

		Vec3 const & Get_size() const;
		void Set_size( Vec3 const & value );
		
	private:
		Vec3 size;
	};

	namespace ControllerSphere_ByteStream
	{
		bool ObjectFromByteStream( core::ByteStreamReader & stream, scene::ControllerSphere & dataObject );
	};

	class ControllerSphere_Partial
	{
	public:
		ControllerSphere_Partial();
		~ControllerSphere_Partial();

		float Get_radius() const;
		void Set_radius( float value );
		
	private:
		float radius;
	};

} /* namespace scene */ 

#endif // Metadata_Game_Scene_Partial_h
