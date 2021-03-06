
// AUTOGENERATED FILE. MODIFY IT AT YOUR OWN RISK.

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;

namespace metadata { 

	[XmlType("Type")]
	public abstract class Type_Serialization : core.ReferenceSerializationObject
	{
		[XmlIgnore]
		metadata.Type This;

		[XmlIgnore]
		public metadata.MetadataFileContent_Serialization Parent;

		[XmlAttribute]
		[DefaultValue("Type")]
		public string TypeName = "Type";

		[XmlAttribute]
		[DefaultValue("")]
		public string Namespace = "";

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			stringToObject.Add( GuidStr.ToOptGuid(), This );	
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (metadata.Type)dataObject );
		}
		protected void FromSerializationConstruct_Base( metadata.Type dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( metadata.Type dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
			This.TypeName = TypeName;
			This.Namespace = Namespace;
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (metadata.Type)dataObject );
		}
		protected void ToSerialization_Base( metadata.Type dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
			TypeName = This.TypeName;
			Namespace = This.Namespace;
		}
		
	}

	[XmlType("TypesCollection")]
	public class TypesCollection_Serialization : core.SerializationCollectionOf <metadata.Type_Serialization>
	{
		[XmlIgnore]
		metadata.TypesCollection This;

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
			foreach( metadata.Type_Serialization collectionElement in Values )
				collectionElement.CreateGuidToObjectMapping( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (metadata.TypesCollection)dataObject );
		}
		protected void FromSerializationConstruct_Base( metadata.TypesCollection dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
			This.Clear();
			foreach( metadata.Type_Serialization collectionElement in Values )
			{
				metadata.Type dataCollectionElement = metadata.Serialization.ConstructData<metadata.Type>( collectionElement.GetType() );
				collectionElement.FromSerializationConstruct( dataCollectionElement );
				This.Add( dataCollectionElement );
			}
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( metadata.TypesCollection dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
			foreach( metadata.Type_Serialization collectionElement in Values )
				collectionElement.FromSerialization( stringToObject );
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (metadata.TypesCollection)dataObject );
		}
		protected void ToSerialization_Base( metadata.TypesCollection dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
			Clear();
			foreach( metadata.Type dataCollectionElement in This )
			{
				metadata.Type_Serialization collectionElement = metadata.Serialization.ConstructSerialization<metadata.Type_Serialization>( dataCollectionElement.GetType() );
				collectionElement.ToSerialization( dataCollectionElement );	
				Add( collectionElement );
			}
		}
		
	}

	[XmlType("MetadataClass")]
	public class MetadataClass_Serialization : metadata.Type_Serialization
	{
		[XmlIgnore]
		metadata.MetadataClass This;

		[XmlAttribute]
		[DefaultValue("")]
		public string BaseClass;

		[XmlAttribute]
		[DefaultValue(true)]
		public bool IsReferenced = true;

		[XmlAttribute]
		[DefaultValue(false)]
		public bool HasMinMax = false;

		[XmlArray]
		[XmlArrayItem(typeof(metadata.Value_Serialization),ElementName = "Value")]
		[XmlArrayItem(typeof(metadata.ValueName_Serialization),ElementName = "ValueName")]
		[XmlArrayItem(typeof(metadata.Reference_Serialization),ElementName = "Reference")]
		[XmlArrayItem(typeof(metadata.ParentReference_Serialization),ElementName = "ParentReference")]
		[XmlArrayItem(typeof(metadata.Collection_Serialization),ElementName = "Collection")]
		[XmlArrayItem(typeof(metadata.FileStorage_Serialization),ElementName = "FileStorage")]
		[XmlArrayItem(typeof(metadata.FunctionUser_Serialization),ElementName = "FunctionUser")]
		[XmlArrayItem(typeof(metadata.FunctionLua_Serialization),ElementName = "FunctionLua")]
		[XmlArrayItem(typeof(metadata.FunctionLuaCallCC_Serialization),ElementName = "FunctionLuaCallCC")]
		public metadata.MembersCollection_Serialization Members = new metadata.MembersCollection_Serialization();

		[XmlAttribute]
		[DefaultValue(false)]
		public bool UserDefined = false;

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			stringToObject.Add( GuidStr.ToOptGuid(), This );	
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
			if ( Members != null )
				Members.CreateGuidToObjectMapping( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (metadata.MetadataClass)dataObject );
		}
		protected void FromSerializationConstruct_Base( metadata.MetadataClass dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
			Members.FromSerializationConstruct( This.Members );
			foreach( metadata.Member collectionElement in This.Members )
			{
			}
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( metadata.MetadataClass dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
			This.BaseClass = stringToObject.Fixup < metadata.MetadataClass >( BaseClass.ToOptGuid() );
			This.IsReferenced = IsReferenced;
			This.HasMinMax = HasMinMax;
			Members.FromSerialization( stringToObject );
			This.UserDefined = UserDefined;
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (metadata.MetadataClass)dataObject );
		}
		protected void ToSerialization_Base( metadata.MetadataClass dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
			BaseClass = ( This.BaseClass == null ? "" : This.BaseClass.Guid.ToOptString() );
			IsReferenced = This.IsReferenced;
			HasMinMax = This.HasMinMax;
			Members.ToSerialization( This.Members );
			foreach ( metadata.Member_Serialization collectionElement in Members )
			{
			}
			UserDefined = This.UserDefined;
		}
		
	}

	[XmlType("AbstractClass")]
	public class AbstractClass_Serialization : metadata.MetadataClass_Serialization
	{
		[XmlIgnore]
		metadata.AbstractClass This;

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			stringToObject.Add( GuidStr.ToOptGuid(), This );	
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (metadata.AbstractClass)dataObject );
		}
		protected void FromSerializationConstruct_Base( metadata.AbstractClass dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( metadata.AbstractClass dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (metadata.AbstractClass)dataObject );
		}
		protected void ToSerialization_Base( metadata.AbstractClass dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
		}
		
	}

	[XmlType("CollectionClass")]
	public class CollectionClass_Serialization : metadata.MetadataClass_Serialization
	{
		[XmlIgnore]
		metadata.CollectionClass This;

		[DefaultValue("")]
		public string ItemsClass;

		[DefaultValue(false)]
		public bool IsPolymorphic = false;

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			stringToObject.Add( GuidStr.ToOptGuid(), This );	
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (metadata.CollectionClass)dataObject );
		}
		protected void FromSerializationConstruct_Base( metadata.CollectionClass dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( metadata.CollectionClass dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
			This.ItemsClass = stringToObject.Fixup < metadata.MetadataClass >( ItemsClass.ToOptGuid() );
			This.IsPolymorphic = IsPolymorphic;
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (metadata.CollectionClass)dataObject );
		}
		protected void ToSerialization_Base( metadata.CollectionClass dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
			ItemsClass = ( This.ItemsClass == null ? "" : This.ItemsClass.Guid.ToOptString() );
			IsPolymorphic = This.IsPolymorphic;
		}
		
	}

	[XmlType("FileClass")]
	public class FileClass_Serialization : metadata.MetadataClass_Serialization
	{
		[XmlIgnore]
		metadata.FileClass This;

		[XmlAttribute]
		[DefaultValue("data")]
		public string FileExtension = "data";

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			stringToObject.Add( GuidStr.ToOptGuid(), This );	
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (metadata.FileClass)dataObject );
		}
		protected void FromSerializationConstruct_Base( metadata.FileClass dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( metadata.FileClass dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
			This.FileExtension = FileExtension;
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (metadata.FileClass)dataObject );
		}
		protected void ToSerialization_Base( metadata.FileClass dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
			FileExtension = This.FileExtension;
		}
		
	}

	[XmlType("FolderClass")]
	public class FolderClass_Serialization : metadata.MetadataClass_Serialization
	{
		[XmlIgnore]
		metadata.FolderClass This;

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			stringToObject.Add( GuidStr.ToOptGuid(), This );	
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (metadata.FolderClass)dataObject );
		}
		protected void FromSerializationConstruct_Base( metadata.FolderClass dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( metadata.FolderClass dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (metadata.FolderClass)dataObject );
		}
		protected void ToSerialization_Base( metadata.FolderClass dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
		}
		
	}

	[XmlType("FolderStorageClass")]
	public class FolderStorageClass_Serialization : metadata.FolderClass_Serialization
	{
		[XmlIgnore]
		metadata.FolderStorageClass This;

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			stringToObject.Add( GuidStr.ToOptGuid(), This );	
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (metadata.FolderStorageClass)dataObject );
		}
		protected void FromSerializationConstruct_Base( metadata.FolderStorageClass dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( metadata.FolderStorageClass dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (metadata.FolderStorageClass)dataObject );
		}
		protected void ToSerialization_Base( metadata.FolderStorageClass dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
		}
		
	}

	[XmlType("ProjectClass")]
	public class ProjectClass_Serialization : metadata.MetadataClass_Serialization
	{
		[XmlIgnore]
		metadata.ProjectClass This;

		[XmlAttribute]
		[DefaultValue("proj")]
		public string FileExtension = "proj";

		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (metadata.ProjectClass)dataObject );
		}
		protected void FromSerializationConstruct_Base( metadata.ProjectClass dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( metadata.ProjectClass dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
			This.FileExtension = FileExtension;
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (metadata.ProjectClass)dataObject );
		}
		protected void ToSerialization_Base( metadata.ProjectClass dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
			FileExtension = This.FileExtension;
		}
		
	}

	[XmlType("MetadataFileContent")]
	public class MetadataFileContent_Serialization : core.SerializationObject
	{
		[XmlIgnore]
		metadata.MetadataFileContent This;

		[XmlIgnore]
		public metadata.MetadataFile_Serialization Parent;

		[XmlArray]
		[XmlArrayItem(typeof(metadata.FundamentalBool_Serialization),ElementName = "FundamentalBool")]
		[XmlArrayItem(typeof(metadata.FundamentalString_Serialization),ElementName = "FundamentalString")]
		[XmlArrayItem(typeof(metadata.FundamentalInt_Serialization),ElementName = "FundamentalInt")]
		[XmlArrayItem(typeof(metadata.FundamentalFloat_Serialization),ElementName = "FundamentalFloat")]
		[XmlArrayItem(typeof(metadata.FundamentalByte_Serialization),ElementName = "FundamentalByte")]
		[XmlArrayItem(typeof(metadata.Enumeration_Serialization),ElementName = "Enumeration")]
		[XmlArrayItem(typeof(metadata.MetadataClass_Serialization),ElementName = "MetadataClass")]
		[XmlArrayItem(typeof(metadata.AbstractClass_Serialization),ElementName = "AbstractClass")]
		[XmlArrayItem(typeof(metadata.CollectionClass_Serialization),ElementName = "CollectionClass")]
		[XmlArrayItem(typeof(metadata.FileClass_Serialization),ElementName = "FileClass")]
		[XmlArrayItem(typeof(metadata.FolderClass_Serialization),ElementName = "FolderClass")]
		[XmlArrayItem(typeof(metadata.FolderStorageClass_Serialization),ElementName = "FolderStorageClass")]
		[XmlArrayItem(typeof(metadata.ProjectClass_Serialization),ElementName = "ProjectClass")]
		public metadata.TypesCollection_Serialization Types = new metadata.TypesCollection_Serialization();

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
			if ( Types != null )
				Types.CreateGuidToObjectMapping( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (metadata.MetadataFileContent)dataObject );
		}
		protected void FromSerializationConstruct_Base( metadata.MetadataFileContent dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
			Types.FromSerializationConstruct( This.Types );
			foreach( metadata.Type collectionElement in This.Types )
			{
				collectionElement.Parent = This;
			}
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( metadata.MetadataFileContent dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
			Types.FromSerialization( stringToObject );
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (metadata.MetadataFileContent)dataObject );
		}
		protected void ToSerialization_Base( metadata.MetadataFileContent dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
			Types.ToSerialization( This.Types );
			foreach ( metadata.Type_Serialization collectionElement in Types )
			{
				collectionElement.Parent = this;
			}
		}
		
	}

	[XmlType("Member")]
	public abstract class Member_Serialization : core.ReferenceSerializationObject
	{
		[XmlIgnore]
		metadata.Member This;

		[XmlAttribute]
		[DefaultValue("member")]
		public string Name = "member";

		[XmlAttribute]
		[DefaultValue("")]
		public string Group;

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			stringToObject.Add( GuidStr.ToOptGuid(), This );	
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (metadata.Member)dataObject );
		}
		protected void FromSerializationConstruct_Base( metadata.Member dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( metadata.Member dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
			This.Name = Name;
			This.Group = stringToObject.Fixup < metadata.MetadataMemberGroup >( Group.ToOptGuid() );
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (metadata.Member)dataObject );
		}
		protected void ToSerialization_Base( metadata.Member dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
			Name = This.Name;
			Group = ( This.Group == null ? "" : This.Group.Guid.ToOptString() );
		}
		
	}

	[XmlType("MembersCollection")]
	public class MembersCollection_Serialization : core.SerializationCollectionOf <metadata.Member_Serialization>
	{
		[XmlIgnore]
		metadata.MembersCollection This;

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
			foreach( metadata.Member_Serialization collectionElement in Values )
				collectionElement.CreateGuidToObjectMapping( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (metadata.MembersCollection)dataObject );
		}
		protected void FromSerializationConstruct_Base( metadata.MembersCollection dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
			This.Clear();
			foreach( metadata.Member_Serialization collectionElement in Values )
			{
				metadata.Member dataCollectionElement = metadata.Serialization.ConstructData<metadata.Member>( collectionElement.GetType() );
				collectionElement.FromSerializationConstruct( dataCollectionElement );
				This.Add( dataCollectionElement );
			}
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( metadata.MembersCollection dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
			foreach( metadata.Member_Serialization collectionElement in Values )
				collectionElement.FromSerialization( stringToObject );
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (metadata.MembersCollection)dataObject );
		}
		protected void ToSerialization_Base( metadata.MembersCollection dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
			Clear();
			foreach( metadata.Member dataCollectionElement in This )
			{
				metadata.Member_Serialization collectionElement = metadata.Serialization.ConstructSerialization<metadata.Member_Serialization>( dataCollectionElement.GetType() );
				collectionElement.ToSerialization( dataCollectionElement );	
				Add( collectionElement );
			}
		}
		
	}

	[XmlType("Value")]
	public class Value_Serialization : metadata.Member_Serialization
	{
		[XmlIgnore]
		metadata.Value This;

		[XmlAttribute]
		[DefaultValue("")]
		public string Type;

		[XmlAttribute]
		[DefaultValue(false)]
		public bool IsXmlAttr = false;

		[XmlAttribute]
		[DefaultValue(false)]
		public bool IsPolymorphic = false;

		[XmlAttribute]
		[DefaultValue("")]
		public string DefaultValue = "";

		[XmlAttribute]
		[DefaultValue("")]
		public string DefaultValueXml = "";

		[XmlAttribute]
		[DefaultValue("")]
		public string Min = "";

		[XmlAttribute]
		[DefaultValue("")]
		public string Max = "";

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			stringToObject.Add( GuidStr.ToOptGuid(), This );	
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (metadata.Value)dataObject );
		}
		protected void FromSerializationConstruct_Base( metadata.Value dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( metadata.Value dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
			This.Type = stringToObject.Fixup < metadata.Type >( Type.ToOptGuid() );
			This.IsXmlAttr = IsXmlAttr;
			This.IsPolymorphic = IsPolymorphic;
			This.DefaultValue = DefaultValue;
			This.DefaultValueXml = DefaultValueXml;
			This.Min = Min;
			This.Max = Max;
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (metadata.Value)dataObject );
		}
		protected void ToSerialization_Base( metadata.Value dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
			Type = ( This.Type == null ? "" : This.Type.Guid.ToOptString() );
			IsXmlAttr = This.IsXmlAttr;
			IsPolymorphic = This.IsPolymorphic;
			DefaultValue = This.DefaultValue;
			DefaultValueXml = This.DefaultValueXml;
			Min = This.Min;
			Max = This.Max;
		}
		
	}

	[XmlType("ValueName")]
	public class ValueName_Serialization : metadata.Value_Serialization
	{
		[XmlIgnore]
		metadata.ValueName This;

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			stringToObject.Add( GuidStr.ToOptGuid(), This );	
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (metadata.ValueName)dataObject );
		}
		protected void FromSerializationConstruct_Base( metadata.ValueName dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( metadata.ValueName dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (metadata.ValueName)dataObject );
		}
		protected void ToSerialization_Base( metadata.ValueName dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
		}
		
	}

	[XmlType("Reference")]
	public class Reference_Serialization : metadata.Member_Serialization
	{
		[XmlIgnore]
		metadata.Reference This;

		[XmlAttribute]
		[DefaultValue("")]
		public string Type;

		[XmlAttribute]
		[DefaultValue(false)]
		public bool IsXmlAttr = false;

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			stringToObject.Add( GuidStr.ToOptGuid(), This );	
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (metadata.Reference)dataObject );
		}
		protected void FromSerializationConstruct_Base( metadata.Reference dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( metadata.Reference dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
			This.Type = stringToObject.Fixup < metadata.MetadataClass >( Type.ToOptGuid() );
			This.IsXmlAttr = IsXmlAttr;
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (metadata.Reference)dataObject );
		}
		protected void ToSerialization_Base( metadata.Reference dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
			Type = ( This.Type == null ? "" : This.Type.Guid.ToOptString() );
			IsXmlAttr = This.IsXmlAttr;
		}
		
	}

	[XmlType("ParentReference")]
	public class ParentReference_Serialization : metadata.Member_Serialization
	{
		[XmlIgnore]
		metadata.ParentReference This;

		[XmlAttribute]
		[DefaultValue("")]
		public string Type;

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			stringToObject.Add( GuidStr.ToOptGuid(), This );	
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (metadata.ParentReference)dataObject );
		}
		protected void FromSerializationConstruct_Base( metadata.ParentReference dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( metadata.ParentReference dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
			This.Type = stringToObject.Fixup < metadata.MetadataClass >( Type.ToOptGuid() );
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (metadata.ParentReference)dataObject );
		}
		protected void ToSerialization_Base( metadata.ParentReference dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
			Type = ( This.Type == null ? "" : This.Type.Guid.ToOptString() );
		}
		
	}

	[XmlType("Collection")]
	public class Collection_Serialization : metadata.Member_Serialization
	{
		[XmlIgnore]
		metadata.Collection This;

		[XmlAttribute]
		[DefaultValue("")]
		public string Type;

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			stringToObject.Add( GuidStr.ToOptGuid(), This );	
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (metadata.Collection)dataObject );
		}
		protected void FromSerializationConstruct_Base( metadata.Collection dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( metadata.Collection dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
			This.Type = stringToObject.Fixup < metadata.CollectionClass >( Type.ToOptGuid() );
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (metadata.Collection)dataObject );
		}
		protected void ToSerialization_Base( metadata.Collection dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
			Type = ( This.Type == null ? "" : This.Type.Guid.ToOptString() );
		}
		
	}

	[XmlType("FileStorage")]
	public class FileStorage_Serialization : metadata.Member_Serialization
	{
		[XmlIgnore]
		metadata.FileStorage This;

		[XmlAttribute]
		[DefaultValue("")]
		public string Type;

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			stringToObject.Add( GuidStr.ToOptGuid(), This );	
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (metadata.FileStorage)dataObject );
		}
		protected void FromSerializationConstruct_Base( metadata.FileStorage dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( metadata.FileStorage dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
			This.Type = stringToObject.Fixup < metadata.MetadataClass >( Type.ToOptGuid() );
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (metadata.FileStorage)dataObject );
		}
		protected void ToSerialization_Base( metadata.FileStorage dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
			Type = ( This.Type == null ? "" : This.Type.Guid.ToOptString() );
		}
		
	}

} /* namespace metadata */ 
