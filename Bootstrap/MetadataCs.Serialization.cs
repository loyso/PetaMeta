using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;
using System.ComponentModel;

namespace metadata
{
	public static class Serialization
	{
		delegate core.SerializationObject	DataObjectToSerialization();
		delegate core.DataObject			DataObjectFromSerialization();

		delegate core.PartialObject			DataObjectToPartial();
		
		static public readonly System.Type[] Types = 
		{ 
			typeof(metadata.Fundamental_Serialization)
			, typeof(metadata.FundamentalBool_Serialization)
			, typeof(metadata.FundamentalString_Serialization)
			, typeof(metadata.FundamentalInt_Serialization)
			, typeof(metadata.FundamentalFloat_Serialization)
			, typeof(metadata.FundamentalByte_Serialization)
			, typeof(metadata.Enumeration_Serialization)
			, typeof(metadata.Enumerator_Serialization)
			, typeof(metadata.EnumeratorsCollection_Serialization)
			, typeof(metadata.Type_Serialization)
			, typeof(metadata.TypesCollection_Serialization)
			, typeof(metadata.MetadataClass_Serialization)
			, typeof(metadata.AbstractClass_Serialization)
			, typeof(metadata.CollectionClass_Serialization)
			, typeof(metadata.FileClass_Serialization)
			, typeof(metadata.FolderClass_Serialization)
			, typeof(metadata.FolderStorageClass_Serialization)
			, typeof(metadata.ProjectClass_Serialization)
			, typeof(metadata.MetadataFileContent_Serialization)
			, typeof(metadata.Member_Serialization)
			, typeof(metadata.MembersCollection_Serialization)
			, typeof(metadata.Value_Serialization)
			, typeof(metadata.ValueName_Serialization)
			, typeof(metadata.Reference_Serialization)
			, typeof(metadata.ParentReference_Serialization)
			, typeof(metadata.Collection_Serialization)
			, typeof(metadata.FileStorage_Serialization)
			, typeof(metadata.MetadataFile_Serialization)
			, typeof(metadata.MetadataFilesCollection_Serialization)
			, typeof(metadata.MetadataFolder_Serialization)
			, typeof(metadata.MetadataFoldersCollection_Serialization)
			, typeof(metadata.MetadataMemberGroup_Serialization)
			, typeof(metadata.MemberGroupsCollection_Serialization)
			, typeof(metadata.MetadataProject_Serialization)
			, typeof(metadata.Function_Serialization)
			, typeof(metadata.FunctionUser_Serialization)
			, typeof(metadata.FunctionLua_Serialization)
			, typeof(metadata.FunctionLuaCallCC_Serialization)
			, typeof(metadata.Argument_Serialization)
			, typeof(metadata.ArgumentsCollection_Serialization)
			, typeof(metadata.ArgumentValue_Serialization)
			, typeof(metadata.ArgumentReference_Serialization)
	
		};		
	
		static Dictionary<System.Type,DataObjectToSerialization> ToSerialization = new Dictionary<System.Type,DataObjectToSerialization>();	
		static Dictionary<System.Type,DataObjectFromSerialization> FromSerialization = new Dictionary<System.Type,DataObjectFromSerialization>();	

		static void InitSerialization()
		{
			ToSerialization.Add( typeof(metadata.FundamentalBool), () => { return new metadata.FundamentalBool_Serialization(); } );
			FromSerialization.Add( typeof(metadata.FundamentalBool_Serialization), () => { return new metadata.FundamentalBool(); } );
			ToSerialization.Add( typeof(metadata.FundamentalString), () => { return new metadata.FundamentalString_Serialization(); } );
			FromSerialization.Add( typeof(metadata.FundamentalString_Serialization), () => { return new metadata.FundamentalString(); } );
			ToSerialization.Add( typeof(metadata.FundamentalInt), () => { return new metadata.FundamentalInt_Serialization(); } );
			FromSerialization.Add( typeof(metadata.FundamentalInt_Serialization), () => { return new metadata.FundamentalInt(); } );
			ToSerialization.Add( typeof(metadata.FundamentalFloat), () => { return new metadata.FundamentalFloat_Serialization(); } );
			FromSerialization.Add( typeof(metadata.FundamentalFloat_Serialization), () => { return new metadata.FundamentalFloat(); } );
			ToSerialization.Add( typeof(metadata.FundamentalByte), () => { return new metadata.FundamentalByte_Serialization(); } );
			FromSerialization.Add( typeof(metadata.FundamentalByte_Serialization), () => { return new metadata.FundamentalByte(); } );
			ToSerialization.Add( typeof(metadata.Enumeration), () => { return new metadata.Enumeration_Serialization(); } );
			FromSerialization.Add( typeof(metadata.Enumeration_Serialization), () => { return new metadata.Enumeration(); } );
			ToSerialization.Add( typeof(metadata.Enumerator), () => { return new metadata.Enumerator_Serialization(); } );
			FromSerialization.Add( typeof(metadata.Enumerator_Serialization), () => { return new metadata.Enumerator(); } );
			ToSerialization.Add( typeof(metadata.EnumeratorsCollection), () => { return new metadata.EnumeratorsCollection_Serialization(); } );
			FromSerialization.Add( typeof(metadata.EnumeratorsCollection_Serialization), () => { return new metadata.EnumeratorsCollection(); } );
			ToSerialization.Add( typeof(metadata.TypesCollection), () => { return new metadata.TypesCollection_Serialization(); } );
			FromSerialization.Add( typeof(metadata.TypesCollection_Serialization), () => { return new metadata.TypesCollection(); } );
			ToSerialization.Add( typeof(metadata.MetadataClass), () => { return new metadata.MetadataClass_Serialization(); } );
			FromSerialization.Add( typeof(metadata.MetadataClass_Serialization), () => { return new metadata.MetadataClass(); } );
			ToSerialization.Add( typeof(metadata.AbstractClass), () => { return new metadata.AbstractClass_Serialization(); } );
			FromSerialization.Add( typeof(metadata.AbstractClass_Serialization), () => { return new metadata.AbstractClass(); } );
			ToSerialization.Add( typeof(metadata.CollectionClass), () => { return new metadata.CollectionClass_Serialization(); } );
			FromSerialization.Add( typeof(metadata.CollectionClass_Serialization), () => { return new metadata.CollectionClass(); } );
			ToSerialization.Add( typeof(metadata.FileClass), () => { return new metadata.FileClass_Serialization(); } );
			FromSerialization.Add( typeof(metadata.FileClass_Serialization), () => { return new metadata.FileClass(); } );
			ToSerialization.Add( typeof(metadata.FolderClass), () => { return new metadata.FolderClass_Serialization(); } );
			FromSerialization.Add( typeof(metadata.FolderClass_Serialization), () => { return new metadata.FolderClass(); } );
			ToSerialization.Add( typeof(metadata.FolderStorageClass), () => { return new metadata.FolderStorageClass_Serialization(); } );
			FromSerialization.Add( typeof(metadata.FolderStorageClass_Serialization), () => { return new metadata.FolderStorageClass(); } );
			ToSerialization.Add( typeof(metadata.ProjectClass), () => { return new metadata.ProjectClass_Serialization(); } );
			FromSerialization.Add( typeof(metadata.ProjectClass_Serialization), () => { return new metadata.ProjectClass(); } );
			ToSerialization.Add( typeof(metadata.MetadataFileContent), () => { return new metadata.MetadataFileContent_Serialization(); } );
			FromSerialization.Add( typeof(metadata.MetadataFileContent_Serialization), () => { return new metadata.MetadataFileContent(); } );
			ToSerialization.Add( typeof(metadata.MembersCollection), () => { return new metadata.MembersCollection_Serialization(); } );
			FromSerialization.Add( typeof(metadata.MembersCollection_Serialization), () => { return new metadata.MembersCollection(); } );
			ToSerialization.Add( typeof(metadata.Value), () => { return new metadata.Value_Serialization(); } );
			FromSerialization.Add( typeof(metadata.Value_Serialization), () => { return new metadata.Value(); } );
			ToSerialization.Add( typeof(metadata.ValueName), () => { return new metadata.ValueName_Serialization(); } );
			FromSerialization.Add( typeof(metadata.ValueName_Serialization), () => { return new metadata.ValueName(); } );
			ToSerialization.Add( typeof(metadata.Reference), () => { return new metadata.Reference_Serialization(); } );
			FromSerialization.Add( typeof(metadata.Reference_Serialization), () => { return new metadata.Reference(); } );
			ToSerialization.Add( typeof(metadata.ParentReference), () => { return new metadata.ParentReference_Serialization(); } );
			FromSerialization.Add( typeof(metadata.ParentReference_Serialization), () => { return new metadata.ParentReference(); } );
			ToSerialization.Add( typeof(metadata.Collection), () => { return new metadata.Collection_Serialization(); } );
			FromSerialization.Add( typeof(metadata.Collection_Serialization), () => { return new metadata.Collection(); } );
			ToSerialization.Add( typeof(metadata.FileStorage), () => { return new metadata.FileStorage_Serialization(); } );
			FromSerialization.Add( typeof(metadata.FileStorage_Serialization), () => { return new metadata.FileStorage(); } );
			ToSerialization.Add( typeof(metadata.MetadataFile), () => { return new metadata.MetadataFile_Serialization(); } );
			FromSerialization.Add( typeof(metadata.MetadataFile_Serialization), () => { return new metadata.MetadataFile(); } );
			ToSerialization.Add( typeof(metadata.MetadataFilesCollection), () => { return new metadata.MetadataFilesCollection_Serialization(); } );
			FromSerialization.Add( typeof(metadata.MetadataFilesCollection_Serialization), () => { return new metadata.MetadataFilesCollection(); } );
			ToSerialization.Add( typeof(metadata.MetadataFolder), () => { return new metadata.MetadataFolder_Serialization(); } );
			FromSerialization.Add( typeof(metadata.MetadataFolder_Serialization), () => { return new metadata.MetadataFolder(); } );
			ToSerialization.Add( typeof(metadata.MetadataFoldersCollection), () => { return new metadata.MetadataFoldersCollection_Serialization(); } );
			FromSerialization.Add( typeof(metadata.MetadataFoldersCollection_Serialization), () => { return new metadata.MetadataFoldersCollection(); } );
			ToSerialization.Add( typeof(metadata.MetadataMemberGroup), () => { return new metadata.MetadataMemberGroup_Serialization(); } );
			FromSerialization.Add( typeof(metadata.MetadataMemberGroup_Serialization), () => { return new metadata.MetadataMemberGroup(); } );
			ToSerialization.Add( typeof(metadata.MemberGroupsCollection), () => { return new metadata.MemberGroupsCollection_Serialization(); } );
			FromSerialization.Add( typeof(metadata.MemberGroupsCollection_Serialization), () => { return new metadata.MemberGroupsCollection(); } );
			ToSerialization.Add( typeof(metadata.MetadataProject), () => { return new metadata.MetadataProject_Serialization(); } );
			FromSerialization.Add( typeof(metadata.MetadataProject_Serialization), () => { return new metadata.MetadataProject(); } );
			ToSerialization.Add( typeof(metadata.FunctionUser), () => { return new metadata.FunctionUser_Serialization(); } );
			FromSerialization.Add( typeof(metadata.FunctionUser_Serialization), () => { return new metadata.FunctionUser(); } );
			ToSerialization.Add( typeof(metadata.FunctionLua), () => { return new metadata.FunctionLua_Serialization(); } );
			FromSerialization.Add( typeof(metadata.FunctionLua_Serialization), () => { return new metadata.FunctionLua(); } );
			ToSerialization.Add( typeof(metadata.FunctionLuaCallCC), () => { return new metadata.FunctionLuaCallCC_Serialization(); } );
			FromSerialization.Add( typeof(metadata.FunctionLuaCallCC_Serialization), () => { return new metadata.FunctionLuaCallCC(); } );
			ToSerialization.Add( typeof(metadata.ArgumentsCollection), () => { return new metadata.ArgumentsCollection_Serialization(); } );
			FromSerialization.Add( typeof(metadata.ArgumentsCollection_Serialization), () => { return new metadata.ArgumentsCollection(); } );
			ToSerialization.Add( typeof(metadata.ArgumentValue), () => { return new metadata.ArgumentValue_Serialization(); } );
			FromSerialization.Add( typeof(metadata.ArgumentValue_Serialization), () => { return new metadata.ArgumentValue(); } );
			ToSerialization.Add( typeof(metadata.ArgumentReference), () => { return new metadata.ArgumentReference_Serialization(); } );
			FromSerialization.Add( typeof(metadata.ArgumentReference_Serialization), () => { return new metadata.ArgumentReference(); } );
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
	} // Serialization
} // namespace metadata
