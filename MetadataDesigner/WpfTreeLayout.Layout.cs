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
			DataTypeToLayoutType.Add( typeof(metadata.FundamentalBool), () => { return new metadata.FundamentalBoolLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.FundamentalString), () => { return new metadata.FundamentalStringLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.FundamentalInt), () => { return new metadata.FundamentalIntLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.FundamentalFloat), () => { return new metadata.FundamentalFloatLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.FundamentalByte), () => { return new metadata.FundamentalByteLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.Enumeration), () => { return new metadata.EnumerationLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.Enumerator), () => { return new metadata.EnumeratorLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.EnumeratorsCollection), () => { return new metadata.EnumeratorsCollectionLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.TypesCollection), () => { return new metadata.TypesCollectionLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.MetadataClass), () => { return new metadata.MetadataClassLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.AbstractClass), () => { return new metadata.AbstractClassLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.CollectionClass), () => { return new metadata.CollectionClassLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.FileClass), () => { return new metadata.FileClassLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.FolderClass), () => { return new metadata.FolderClassLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.FolderStorageClass), () => { return new metadata.FolderStorageClassLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.ProjectClass), () => { return new metadata.ProjectClassLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.MetadataFileContent), () => { return new metadata.MetadataFileContentLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.MembersCollection), () => { return new metadata.MembersCollectionLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.Value), () => { return new metadata.ValueLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.ValueName), () => { return new metadata.ValueNameLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.Reference), () => { return new metadata.ReferenceLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.ParentReference), () => { return new metadata.ParentReferenceLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.Collection), () => { return new metadata.CollectionLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.FileStorage), () => { return new metadata.FileStorageLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.MetadataFile), () => { return new metadata.MetadataFileLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.MetadataFilesCollection), () => { return new metadata.MetadataFilesCollectionLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.MetadataFolder), () => { return new metadata.MetadataFolderLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.MetadataFoldersCollection), () => { return new metadata.MetadataFoldersCollectionLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.MetadataMemberGroup), () => { return new metadata.MetadataMemberGroupLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.MemberGroupsCollection), () => { return new metadata.MemberGroupsCollectionLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.MetadataProject), () => { return new metadata.MetadataProjectLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.FunctionUser), () => { return new metadata.FunctionUserLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.FunctionLua), () => { return new metadata.FunctionLuaLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.FunctionLuaCallCC), () => { return new metadata.FunctionLuaCallCCLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.ArgumentsCollection), () => { return new metadata.ArgumentsCollectionLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.ArgumentValue), () => { return new metadata.ArgumentValueLayout(); } );
			DataTypeToLayoutType.Add( typeof(metadata.ArgumentReference), () => { return new metadata.ArgumentReferenceLayout(); } );
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
