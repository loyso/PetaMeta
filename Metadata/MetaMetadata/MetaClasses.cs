
// AUTOGENERATED FILE. MODIFY IT AT YOUR OWN RISK.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace metadata { 

	public abstract partial class Type : core.ReferenceObject
	{
		public metadata.MetadataFileContent Parent;
		public string TypeName = "Type";
		public string Namespace = "";
	}

	public partial class TypesCollection : core.CollectionOf <metadata.Type>
	{
	}

	public partial class MetadataClass : metadata.Type
	{
		public metadata.MetadataClass BaseClass;
		public bool IsReferenced = true;
		public bool HasMinMax = false;
		public metadata.MembersCollection Members = new metadata.MembersCollection();
		public bool UserDefined = false;
	}

	public partial class AbstractClass : metadata.MetadataClass
	{
	}

	public partial class CollectionClass : metadata.MetadataClass
	{
		public metadata.MetadataClass ItemsClass;
		public bool IsPolymorphic = false;
	}

	public partial class FileClass : metadata.MetadataClass
	{
		public string FileExtension = "data";
	}

	public partial class FolderClass : metadata.MetadataClass
	{
	}

	public partial class FolderStorageClass : metadata.FolderClass
	{
	}

	public partial class ProjectClass : metadata.MetadataClass
	{
		public string FileExtension = "proj";
	}

	public partial class MetadataFileContent : core.DataObject
	{
		public metadata.MetadataFile Parent;
		public metadata.TypesCollection Types = new metadata.TypesCollection();
	}

	public abstract partial class Member : core.ReferenceObject
	{
		public string Name = "member";
		public metadata.MetadataMemberGroup Group;
	}

	public partial class MembersCollection : core.CollectionOf <metadata.Member>
	{
	}

	public partial class Value : metadata.Member
	{
		public metadata.Type Type;
		public bool IsXmlAttr = false;
		public bool IsPolymorphic = false;
		public string DefaultValue = "";
		public string DefaultValueXml = "";
		public string Min = "";
		public string Max = "";
	}

	public partial class ValueName : metadata.Value
	{
	}

	public partial class Reference : metadata.Member
	{
		public metadata.MetadataClass Type;
		public bool IsXmlAttr = false;
	}

	public partial class ParentReference : metadata.Member
	{
		public metadata.MetadataClass Type;
	}

	public partial class Collection : metadata.Member
	{
		public metadata.CollectionClass Type;
	}

	public partial class FileStorage : metadata.Member
	{
		public metadata.MetadataClass Type;
	}

} /* namespace metadata */ 
