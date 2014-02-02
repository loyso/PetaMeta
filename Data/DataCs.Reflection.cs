using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace data
{
	public static class Reflection
	{
		private static Dictionary< System.Type,reflection.MetadataClass > DataTypeToReflection = new Dictionary< System.Type,reflection.MetadataClass >();	
	
		static Reflection()
		{
			DataTypeToReflection.Add( typeof(Vec2), Vec2_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(Vec3), Vec3_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(Vec4), Vec4_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(Color), Color_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(game.Globals), game.Globals_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(game.Game), game.Game_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(gui.Gui), gui.Gui_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(gui.GuiCommon), gui.GuiCommon_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(gui.GuiMainMenu), gui.GuiMainMenu_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(gui.GuiGame), gui.GuiGame_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(gui.GuiFile), gui.GuiFile_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(gui.GuiFilesCollection), gui.GuiFilesCollection_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(level.Levels), level.Levels_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(level.LevelFolder), level.LevelFolder_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(level.LevelFoldersCollection), level.LevelFoldersCollection_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(level.LevelBlock), level.LevelBlock_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(level.LevelBlocksCollection), level.LevelBlocksCollection_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(level.LevelFile), level.LevelFile_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(level.LevelFilesCollection), level.LevelFilesCollection_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(level.Dependency), level.Dependency_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(level.Dependencies), level.Dependencies_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(gui.Window), gui.Window_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(gui.WindowsCollection), gui.WindowsCollection_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(scene.SceneObject), scene.SceneObject_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(scene.SceneObjectsCollection), scene.SceneObjectsCollection_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(scene.SceneMesh), scene.SceneMesh_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(scene.SceneAnimMesh), scene.SceneAnimMesh_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(scene.SceneZoneTrigger), scene.SceneZoneTrigger_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(scene.Scene), scene.Scene_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(scene.ControllerBox), scene.ControllerBox_Reflection.MetadataClass );
			DataTypeToReflection.Add( typeof(scene.ControllerSphere), scene.ControllerSphere_Reflection.MetadataClass );
	
		}

		public static reflection.MetadataClass GetClass( core.DataObject obj )
		{
			reflection.MetadataClass metadataClass;
			if ( DataTypeToReflection.TryGetValue( obj.GetType(), out metadataClass ) )
				return metadataClass;
			return null;			
		}	
	}
} // // namespace data
