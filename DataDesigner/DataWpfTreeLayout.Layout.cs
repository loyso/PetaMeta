using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Controls;

namespace gui
{
	public static class Layouts
	{
		delegate Layout DelegateCreateLayout();
	
		private static Dictionary<System.Type,DelegateCreateLayout> DataTypeToLayoutType = new Dictionary<System.Type,DelegateCreateLayout>();	

		static Layouts()
		{
			DataTypeToLayoutType.Add( typeof(Vec2), () => { return new Vec2Layout(); } );
			DataTypeToLayoutType.Add( typeof(Vec3), () => { return new Vec3Layout(); } );
			DataTypeToLayoutType.Add( typeof(Vec4), () => { return new Vec4Layout(); } );
			DataTypeToLayoutType.Add( typeof(Color), () => { return new ColorLayout(); } );
			DataTypeToLayoutType.Add( typeof(game.Globals), () => { return new game.GlobalsLayout(); } );
			DataTypeToLayoutType.Add( typeof(game.Game), () => { return new game.GameLayout(); } );
			DataTypeToLayoutType.Add( typeof(gui.Gui), () => { return new gui.GuiLayout(); } );
			DataTypeToLayoutType.Add( typeof(gui.GuiCommon), () => { return new gui.GuiCommonLayout(); } );
			DataTypeToLayoutType.Add( typeof(gui.GuiMainMenu), () => { return new gui.GuiMainMenuLayout(); } );
			DataTypeToLayoutType.Add( typeof(gui.GuiGame), () => { return new gui.GuiGameLayout(); } );
			DataTypeToLayoutType.Add( typeof(gui.GuiFile), () => { return new gui.GuiFileLayout(); } );
			DataTypeToLayoutType.Add( typeof(gui.GuiFilesCollection), () => { return new gui.GuiFilesCollectionLayout(); } );
			DataTypeToLayoutType.Add( typeof(level.Levels), () => { return new level.LevelsLayout(); } );
			DataTypeToLayoutType.Add( typeof(level.LevelFolder), () => { return new level.LevelFolderLayout(); } );
			DataTypeToLayoutType.Add( typeof(level.LevelFoldersCollection), () => { return new level.LevelFoldersCollectionLayout(); } );
			DataTypeToLayoutType.Add( typeof(level.LevelBlock), () => { return new level.LevelBlockLayout(); } );
			DataTypeToLayoutType.Add( typeof(level.LevelBlocksCollection), () => { return new level.LevelBlocksCollectionLayout(); } );
			DataTypeToLayoutType.Add( typeof(level.LevelFile), () => { return new level.LevelFileLayout(); } );
			DataTypeToLayoutType.Add( typeof(level.LevelFilesCollection), () => { return new level.LevelFilesCollectionLayout(); } );
			DataTypeToLayoutType.Add( typeof(level.Dependency), () => { return new level.DependencyLayout(); } );
			DataTypeToLayoutType.Add( typeof(level.Dependencies), () => { return new level.DependenciesLayout(); } );
			DataTypeToLayoutType.Add( typeof(gui.Window), () => { return new gui.WindowLayout(); } );
			DataTypeToLayoutType.Add( typeof(gui.WindowsCollection), () => { return new gui.WindowsCollectionLayout(); } );
			DataTypeToLayoutType.Add( typeof(scene.SceneObject), () => { return new scene.SceneObjectLayout(); } );
			DataTypeToLayoutType.Add( typeof(scene.SceneObjectsCollection), () => { return new scene.SceneObjectsCollectionLayout(); } );
			DataTypeToLayoutType.Add( typeof(scene.SceneMesh), () => { return new scene.SceneMeshLayout(); } );
			DataTypeToLayoutType.Add( typeof(scene.SceneAnimMesh), () => { return new scene.SceneAnimMeshLayout(); } );
			DataTypeToLayoutType.Add( typeof(scene.SceneZoneTrigger), () => { return new scene.SceneZoneTriggerLayout(); } );
			DataTypeToLayoutType.Add( typeof(scene.Scene), () => { return new scene.SceneLayout(); } );
			DataTypeToLayoutType.Add( typeof(scene.ControllerBox), () => { return new scene.ControllerBoxLayout(); } );
			DataTypeToLayoutType.Add( typeof(scene.ControllerSphere), () => { return new scene.ControllerSphereLayout(); } );
		}
		
		public static T CreateLayoutFor< T >( core.DataObject dataObject ) where T : Layout
		{
			DelegateCreateLayout delegateCreateLayout;
			if ( DataTypeToLayoutType.TryGetValue( dataObject.GetType(), out delegateCreateLayout ) )
			{
				Layout layout = delegateCreateLayout();
				T typedLayout = layout as T;
				if ( typedLayout == null )
					throw new core.TypeMappingException( dataObject.GetType() );
				return typedLayout;
			}
			return null;	
		}
	}
	
	public abstract class ILayout
	{
		protected virtual void NewObject( core.DataObject newObject, core.DataObject deletedObject ) {}
		protected virtual void DeleteObject( core.DataObject deletedObject ) {}
	
		protected virtual bool BrowseClicked( System.Type referenceType, string title, Predicate< core.DataObject > predicate, core.DataObject currenctReference, out core.DataObject reference )
		{
			reference = null;
			return false;
		}
		
		protected virtual void NameChanged() {}
		
		protected virtual void MemberChanged_Value( reflection.MetadataClass ThisMetadataClass, core.ReferenceObject This, reflection.Value member, core.DataObject dataValue ) {}
		protected virtual void MemberChanged_Reference( reflection.MetadataClass ThisMetadataClass, core.ReferenceObject This, reflection.Reference member, core.ReferenceObject referenceValue ) {}
		protected virtual void MemberChanged_ParentReference( reflection.MetadataClass ThisMetadataClass, core.ReferenceObject This, reflection.ParentReference member, core.ReferenceObject referenceValue ) {}
		protected virtual void MemberChanged_FileStorage( reflection.MetadataClass ThisMetadataClass, core.ReferenceObject This, reflection.FileStorage member, core.ReferenceObject referenceValue ) {}
	}

	public abstract partial class Layout : ILayout
	{
		core.DataObject This;
		public Layout	ParentLayout;
		protected bool	IsObjectDataToControls = false;
		
		public delegate void	ObjectChanged_f ();
		public ObjectChanged_f	ObjectChanged = null;
		
		public virtual void		CreateControls ( core.DataObject dataObject, UIElementCollection collection ) {}
		protected virtual void	CreateControls_Base ( core.DataObject dataObject, UIElementCollection collection ) 
		{
			This = dataObject;
		}

		public virtual void		ObjectDataToControls() {}
		protected virtual void	ObjectDataToControls_Base() {}	
	}	
} // gui
