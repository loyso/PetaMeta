using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;
using System.ComponentModel;

namespace data
{
	public static class Serialization
	{
		delegate core.SerializationObject	DataObjectToSerialization();
		delegate core.DataObject			DataObjectFromSerialization();

		delegate core.PartialObject			DataObjectToPartial();
		
		static public readonly System.Type[] Types = 
		{ 
			typeof(Vec2_Serialization)
			, typeof(Vec3_Serialization)
			, typeof(Vec4_Serialization)
			, typeof(Color_Serialization)
			, typeof(game.Globals_Serialization)
			, typeof(game.Game_Serialization)
			, typeof(gui.Gui_Serialization)
			, typeof(gui.GuiCommon_Serialization)
			, typeof(gui.GuiMainMenu_Serialization)
			, typeof(gui.GuiGame_Serialization)
			, typeof(gui.GuiFile_Serialization)
			, typeof(gui.GuiFilesCollection_Serialization)
			, typeof(level.Levels_Serialization)
			, typeof(level.LevelFolder_Serialization)
			, typeof(level.LevelFoldersCollection_Serialization)
			, typeof(level.LevelBlock_Serialization)
			, typeof(level.LevelBlocksCollection_Serialization)
			, typeof(level.LevelFile_Serialization)
			, typeof(level.LevelFilesCollection_Serialization)
			, typeof(level.Dependency_Serialization)
			, typeof(level.Dependencies_Serialization)
			, typeof(gui.Window_Serialization)
			, typeof(gui.WindowsCollection_Serialization)
			, typeof(scene.SceneObject_Serialization)
			, typeof(scene.SceneObjectsCollection_Serialization)
			, typeof(scene.SceneMesh_Serialization)
			, typeof(scene.SceneAnimMesh_Serialization)
			, typeof(scene.SceneZoneTrigger_Serialization)
			, typeof(scene.Scene_Serialization)
			, typeof(scene.Controller_Serialization)
			, typeof(scene.ControllerBox_Serialization)
			, typeof(scene.ControllerSphere_Serialization)
	
		};		
	
		static Dictionary<System.Type,DataObjectToSerialization> ToSerialization = new Dictionary<System.Type,DataObjectToSerialization>();	
		static Dictionary<System.Type,DataObjectFromSerialization> FromSerialization = new Dictionary<System.Type,DataObjectFromSerialization>();	

		static void InitSerialization()
		{
			ToSerialization.Add( typeof(Vec2), () => { return new Vec2_Serialization(); } );
			FromSerialization.Add( typeof(Vec2_Serialization), () => { return new Vec2(); } );
			ToSerialization.Add( typeof(Vec3), () => { return new Vec3_Serialization(); } );
			FromSerialization.Add( typeof(Vec3_Serialization), () => { return new Vec3(); } );
			ToSerialization.Add( typeof(Vec4), () => { return new Vec4_Serialization(); } );
			FromSerialization.Add( typeof(Vec4_Serialization), () => { return new Vec4(); } );
			ToSerialization.Add( typeof(Color), () => { return new Color_Serialization(); } );
			FromSerialization.Add( typeof(Color_Serialization), () => { return new Color(); } );
			ToSerialization.Add( typeof(game.Globals), () => { return new game.Globals_Serialization(); } );
			FromSerialization.Add( typeof(game.Globals_Serialization), () => { return new game.Globals(); } );
			ToSerialization.Add( typeof(game.Game), () => { return new game.Game_Serialization(); } );
			FromSerialization.Add( typeof(game.Game_Serialization), () => { return new game.Game(); } );
			ToSerialization.Add( typeof(gui.Gui), () => { return new gui.Gui_Serialization(); } );
			FromSerialization.Add( typeof(gui.Gui_Serialization), () => { return new gui.Gui(); } );
			ToSerialization.Add( typeof(gui.GuiCommon), () => { return new gui.GuiCommon_Serialization(); } );
			FromSerialization.Add( typeof(gui.GuiCommon_Serialization), () => { return new gui.GuiCommon(); } );
			ToSerialization.Add( typeof(gui.GuiMainMenu), () => { return new gui.GuiMainMenu_Serialization(); } );
			FromSerialization.Add( typeof(gui.GuiMainMenu_Serialization), () => { return new gui.GuiMainMenu(); } );
			ToSerialization.Add( typeof(gui.GuiGame), () => { return new gui.GuiGame_Serialization(); } );
			FromSerialization.Add( typeof(gui.GuiGame_Serialization), () => { return new gui.GuiGame(); } );
			ToSerialization.Add( typeof(gui.GuiFile), () => { return new gui.GuiFile_Serialization(); } );
			FromSerialization.Add( typeof(gui.GuiFile_Serialization), () => { return new gui.GuiFile(); } );
			ToSerialization.Add( typeof(gui.GuiFilesCollection), () => { return new gui.GuiFilesCollection_Serialization(); } );
			FromSerialization.Add( typeof(gui.GuiFilesCollection_Serialization), () => { return new gui.GuiFilesCollection(); } );
			ToSerialization.Add( typeof(level.Levels), () => { return new level.Levels_Serialization(); } );
			FromSerialization.Add( typeof(level.Levels_Serialization), () => { return new level.Levels(); } );
			ToSerialization.Add( typeof(level.LevelFolder), () => { return new level.LevelFolder_Serialization(); } );
			FromSerialization.Add( typeof(level.LevelFolder_Serialization), () => { return new level.LevelFolder(); } );
			ToSerialization.Add( typeof(level.LevelFoldersCollection), () => { return new level.LevelFoldersCollection_Serialization(); } );
			FromSerialization.Add( typeof(level.LevelFoldersCollection_Serialization), () => { return new level.LevelFoldersCollection(); } );
			ToSerialization.Add( typeof(level.LevelBlock), () => { return new level.LevelBlock_Serialization(); } );
			FromSerialization.Add( typeof(level.LevelBlock_Serialization), () => { return new level.LevelBlock(); } );
			ToSerialization.Add( typeof(level.LevelBlocksCollection), () => { return new level.LevelBlocksCollection_Serialization(); } );
			FromSerialization.Add( typeof(level.LevelBlocksCollection_Serialization), () => { return new level.LevelBlocksCollection(); } );
			ToSerialization.Add( typeof(level.LevelFile), () => { return new level.LevelFile_Serialization(); } );
			FromSerialization.Add( typeof(level.LevelFile_Serialization), () => { return new level.LevelFile(); } );
			ToSerialization.Add( typeof(level.LevelFilesCollection), () => { return new level.LevelFilesCollection_Serialization(); } );
			FromSerialization.Add( typeof(level.LevelFilesCollection_Serialization), () => { return new level.LevelFilesCollection(); } );
			ToSerialization.Add( typeof(level.Dependency), () => { return new level.Dependency_Serialization(); } );
			FromSerialization.Add( typeof(level.Dependency_Serialization), () => { return new level.Dependency(); } );
			ToSerialization.Add( typeof(level.Dependencies), () => { return new level.Dependencies_Serialization(); } );
			FromSerialization.Add( typeof(level.Dependencies_Serialization), () => { return new level.Dependencies(); } );
			ToSerialization.Add( typeof(gui.Window), () => { return new gui.Window_Serialization(); } );
			FromSerialization.Add( typeof(gui.Window_Serialization), () => { return new gui.Window(); } );
			ToSerialization.Add( typeof(gui.WindowsCollection), () => { return new gui.WindowsCollection_Serialization(); } );
			FromSerialization.Add( typeof(gui.WindowsCollection_Serialization), () => { return new gui.WindowsCollection(); } );
			ToSerialization.Add( typeof(scene.SceneObject), () => { return new scene.SceneObject_Serialization(); } );
			FromSerialization.Add( typeof(scene.SceneObject_Serialization), () => { return new scene.SceneObject(); } );
			ToSerialization.Add( typeof(scene.SceneObjectsCollection), () => { return new scene.SceneObjectsCollection_Serialization(); } );
			FromSerialization.Add( typeof(scene.SceneObjectsCollection_Serialization), () => { return new scene.SceneObjectsCollection(); } );
			ToSerialization.Add( typeof(scene.SceneMesh), () => { return new scene.SceneMesh_Serialization(); } );
			FromSerialization.Add( typeof(scene.SceneMesh_Serialization), () => { return new scene.SceneMesh(); } );
			ToSerialization.Add( typeof(scene.SceneAnimMesh), () => { return new scene.SceneAnimMesh_Serialization(); } );
			FromSerialization.Add( typeof(scene.SceneAnimMesh_Serialization), () => { return new scene.SceneAnimMesh(); } );
			ToSerialization.Add( typeof(scene.SceneZoneTrigger), () => { return new scene.SceneZoneTrigger_Serialization(); } );
			FromSerialization.Add( typeof(scene.SceneZoneTrigger_Serialization), () => { return new scene.SceneZoneTrigger(); } );
			ToSerialization.Add( typeof(scene.Scene), () => { return new scene.Scene_Serialization(); } );
			FromSerialization.Add( typeof(scene.Scene_Serialization), () => { return new scene.Scene(); } );
			ToSerialization.Add( typeof(scene.ControllerBox), () => { return new scene.ControllerBox_Serialization(); } );
			FromSerialization.Add( typeof(scene.ControllerBox_Serialization), () => { return new scene.ControllerBox(); } );
			ToSerialization.Add( typeof(scene.ControllerSphere), () => { return new scene.ControllerSphere_Serialization(); } );
			FromSerialization.Add( typeof(scene.ControllerSphere_Serialization), () => { return new scene.ControllerSphere(); } );
		}
		
		static public T ConstructSerialization < T >( System.Type dataObjectType ) where T : core.SerializationObject
		{
			if ( ToSerialization.Count == 0 )
				InitSerialization();
		
			DataObjectToSerialization delegateObjectToSerialization;
			if ( ToSerialization.TryGetValue( dataObjectType, out delegateObjectToSerialization ) )
			{
				core.SerializationObject serializationObject = delegateObjectToSerialization();				
				T typedObject = serializationObject as T;
				if ( typedObject == null )
					throw new core.TypeMappingException( dataObjectType );				
				return typedObject;
			}
			return null;	
		}	

		static public T ConstructData < T >( System.Type serializationObjectType ) where T : core.DataObject
		{
			if ( FromSerialization.Count == 0 )
				InitSerialization();
				
			DataObjectFromSerialization delegateObjectFromSerialization;
			if ( FromSerialization.TryGetValue( serializationObjectType, out delegateObjectFromSerialization ) )
			{
				core.DataObject dataObject = delegateObjectFromSerialization();
				T typedObject = dataObject as T;
				if ( typedObject == null )
					throw new core.TypeMappingException( serializationObjectType );				
				return typedObject;
			}
			return null;	
		}	
		static public readonly System.Type[] Types_Sound = 
		{ 
			typeof(Vec2_Serialization)
			, typeof(Vec3_Serialization)
			, typeof(Vec4_Serialization)
			, typeof(Color_Serialization)
			, typeof(game.Globals_Serialization)
			, typeof(game.Game_Serialization_Sound)
			, typeof(gui.Gui_Serialization)
			, typeof(gui.GuiCommon_Serialization)
			, typeof(gui.GuiMainMenu_Serialization)
			, typeof(gui.GuiGame_Serialization)
			, typeof(gui.GuiFile_Serialization)
			, typeof(gui.GuiFilesCollection_Serialization)
			, typeof(level.Levels_Serialization_Sound)
			, typeof(level.LevelFolder_Serialization_Sound)
			, typeof(level.LevelFoldersCollection_Serialization_Sound)
			, typeof(level.LevelBlock_Serialization_Sound)
			, typeof(level.LevelBlocksCollection_Serialization_Sound)
			, typeof(level.LevelFile_Serialization_Sound)
			, typeof(level.LevelFilesCollection_Serialization_Sound)
			, typeof(level.Dependency_Serialization)
			, typeof(level.Dependencies_Serialization)
			, typeof(gui.Window_Serialization)
			, typeof(gui.WindowsCollection_Serialization)
			, typeof(scene.SceneObject_Serialization_Sound)
			, typeof(scene.SceneObjectsCollection_Serialization_Sound)
			, typeof(scene.SceneMesh_Serialization_Sound)
			, typeof(scene.SceneAnimMesh_Serialization_Sound)
			, typeof(scene.SceneZoneTrigger_Serialization_Sound)
			, typeof(scene.Scene_Serialization_Sound)
			, typeof(scene.Controller_Serialization)
			, typeof(scene.ControllerBox_Serialization)
			, typeof(scene.ControllerSphere_Serialization)
	
		};		
	
		static Dictionary<System.Type,DataObjectToPartial> ToPartialSound = new Dictionary<System.Type,DataObjectToPartial>();	

		static void InitPartial_Sound()
		{
			ToPartialSound.Add( typeof(game.Game), () => { return new game.Game_Serialization_Sound(); } );
			ToPartialSound.Add( typeof(level.Levels), () => { return new level.Levels_Serialization_Sound(); } );
			ToPartialSound.Add( typeof(level.LevelFolder), () => { return new level.LevelFolder_Serialization_Sound(); } );
			ToPartialSound.Add( typeof(level.LevelFoldersCollection), () => { return new level.LevelFoldersCollection_Serialization_Sound(); } );
			ToPartialSound.Add( typeof(level.LevelBlock), () => { return new level.LevelBlock_Serialization_Sound(); } );
			ToPartialSound.Add( typeof(level.LevelBlocksCollection), () => { return new level.LevelBlocksCollection_Serialization_Sound(); } );
			ToPartialSound.Add( typeof(level.LevelFile), () => { return new level.LevelFile_Serialization_Sound(); } );
			ToPartialSound.Add( typeof(level.LevelFilesCollection), () => { return new level.LevelFilesCollection_Serialization_Sound(); } );
			ToPartialSound.Add( typeof(scene.SceneObject), () => { return new scene.SceneObject_Serialization_Sound(); } );
			ToPartialSound.Add( typeof(scene.SceneObjectsCollection), () => { return new scene.SceneObjectsCollection_Serialization_Sound(); } );
			ToPartialSound.Add( typeof(scene.SceneMesh), () => { return new scene.SceneMesh_Serialization_Sound(); } );
			ToPartialSound.Add( typeof(scene.SceneAnimMesh), () => { return new scene.SceneAnimMesh_Serialization_Sound(); } );
			ToPartialSound.Add( typeof(scene.SceneZoneTrigger), () => { return new scene.SceneZoneTrigger_Serialization_Sound(); } );
			ToPartialSound.Add( typeof(scene.Scene), () => { return new scene.Scene_Serialization_Sound(); } );
		}
		
		static public T ConstructPartial_Sound < T >( System.Type dataObjectType ) where T : core.PartialObject, new()
		{
			if ( ToPartialSound.Count == 0 )
				InitPartial_Sound();
		
			DataObjectToPartial delegateObjectToPartial;
			if ( ToPartialSound.TryGetValue( dataObjectType, out delegateObjectToPartial ) )
			{
				core.PartialObject partialObject = delegateObjectToPartial();
				T typedObject = partialObject as T;
				if ( typedObject == null )
					throw new core.TypeMappingException( dataObjectType );				
				return typedObject;
			}
			return null;	
		}			
		static public readonly System.Type[] Types_SpecialFX = 
		{ 
			typeof(Vec2_Serialization)
			, typeof(Vec3_Serialization)
			, typeof(Vec4_Serialization)
			, typeof(Color_Serialization)
			, typeof(game.Globals_Serialization)
			, typeof(game.Game_Serialization_SpecialFX)
			, typeof(gui.Gui_Serialization)
			, typeof(gui.GuiCommon_Serialization)
			, typeof(gui.GuiMainMenu_Serialization)
			, typeof(gui.GuiGame_Serialization)
			, typeof(gui.GuiFile_Serialization)
			, typeof(gui.GuiFilesCollection_Serialization)
			, typeof(level.Levels_Serialization_SpecialFX)
			, typeof(level.LevelFolder_Serialization_SpecialFX)
			, typeof(level.LevelFoldersCollection_Serialization_SpecialFX)
			, typeof(level.LevelBlock_Serialization_SpecialFX)
			, typeof(level.LevelBlocksCollection_Serialization_SpecialFX)
			, typeof(level.LevelFile_Serialization_SpecialFX)
			, typeof(level.LevelFilesCollection_Serialization_SpecialFX)
			, typeof(level.Dependency_Serialization)
			, typeof(level.Dependencies_Serialization)
			, typeof(gui.Window_Serialization)
			, typeof(gui.WindowsCollection_Serialization)
			, typeof(scene.SceneObject_Serialization_SpecialFX)
			, typeof(scene.SceneObjectsCollection_Serialization_SpecialFX)
			, typeof(scene.SceneMesh_Serialization_SpecialFX)
			, typeof(scene.SceneAnimMesh_Serialization_SpecialFX)
			, typeof(scene.SceneZoneTrigger_Serialization_SpecialFX)
			, typeof(scene.Scene_Serialization_SpecialFX)
			, typeof(scene.Controller_Serialization)
			, typeof(scene.ControllerBox_Serialization)
			, typeof(scene.ControllerSphere_Serialization)
	
		};		
	
		static Dictionary<System.Type,DataObjectToPartial> ToPartialSpecialFX = new Dictionary<System.Type,DataObjectToPartial>();	

		static void InitPartial_SpecialFX()
		{
			ToPartialSpecialFX.Add( typeof(game.Game), () => { return new game.Game_Serialization_SpecialFX(); } );
			ToPartialSpecialFX.Add( typeof(level.Levels), () => { return new level.Levels_Serialization_SpecialFX(); } );
			ToPartialSpecialFX.Add( typeof(level.LevelFolder), () => { return new level.LevelFolder_Serialization_SpecialFX(); } );
			ToPartialSpecialFX.Add( typeof(level.LevelFoldersCollection), () => { return new level.LevelFoldersCollection_Serialization_SpecialFX(); } );
			ToPartialSpecialFX.Add( typeof(level.LevelBlock), () => { return new level.LevelBlock_Serialization_SpecialFX(); } );
			ToPartialSpecialFX.Add( typeof(level.LevelBlocksCollection), () => { return new level.LevelBlocksCollection_Serialization_SpecialFX(); } );
			ToPartialSpecialFX.Add( typeof(level.LevelFile), () => { return new level.LevelFile_Serialization_SpecialFX(); } );
			ToPartialSpecialFX.Add( typeof(level.LevelFilesCollection), () => { return new level.LevelFilesCollection_Serialization_SpecialFX(); } );
			ToPartialSpecialFX.Add( typeof(scene.SceneObject), () => { return new scene.SceneObject_Serialization_SpecialFX(); } );
			ToPartialSpecialFX.Add( typeof(scene.SceneObjectsCollection), () => { return new scene.SceneObjectsCollection_Serialization_SpecialFX(); } );
			ToPartialSpecialFX.Add( typeof(scene.SceneMesh), () => { return new scene.SceneMesh_Serialization_SpecialFX(); } );
			ToPartialSpecialFX.Add( typeof(scene.SceneAnimMesh), () => { return new scene.SceneAnimMesh_Serialization_SpecialFX(); } );
			ToPartialSpecialFX.Add( typeof(scene.SceneZoneTrigger), () => { return new scene.SceneZoneTrigger_Serialization_SpecialFX(); } );
			ToPartialSpecialFX.Add( typeof(scene.Scene), () => { return new scene.Scene_Serialization_SpecialFX(); } );
		}
		
		static public T ConstructPartial_SpecialFX < T >( System.Type dataObjectType ) where T : core.PartialObject, new()
		{
			if ( ToPartialSpecialFX.Count == 0 )
				InitPartial_SpecialFX();
		
			DataObjectToPartial delegateObjectToPartial;
			if ( ToPartialSpecialFX.TryGetValue( dataObjectType, out delegateObjectToPartial ) )
			{
				core.PartialObject partialObject = delegateObjectToPartial();
				T typedObject = partialObject as T;
				if ( typedObject == null )
					throw new core.TypeMappingException( dataObjectType );				
				return typedObject;
			}
			return null;	
		}			
	} // Serialization
} // namespace data
