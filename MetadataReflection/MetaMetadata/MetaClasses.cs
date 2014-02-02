
// AUTOGENERATED FILE. MODIFY IT AT YOUR OWN RISK.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace reflection { 

	public abstract partial class Type : core.ReferenceObject
	{
		public reflection.MetadataFileContent Parent;
		public string TypeName = "Type";
		public string Namespace = "";
	}

	public partial class TypesCollection : core.CollectionOf <reflection.Type>
	{
	}

	public partial class MetadataClass : reflection.Type
	{
		public reflection.MetadataClass BaseClass;
		public bool IsReferenced = true;
		public bool HasMinMax = false;
		public reflection.MembersCollection Members = new reflection.MembersCollection();
		public bool UserDefined = false;
	}

	public partial class AbstractClass : reflection.MetadataClass
	{
	}

	public partial class CollectionClass : reflection.MetadataClass
	{
		public reflection.MetadataClass ItemsClass;
		public bool IsPolymorphic = false;
	}

	public partial class FileClass : reflection.MetadataClass
	{
		public string FileExtension = "data";
	}

	public partial class FolderClass : reflection.MetadataClass
	{
	}

	public partial class FolderStorageClass : reflection.FolderClass
	{
	}

	public partial class ProjectClass : reflection.MetadataClass
	{
		public string FileExtension = "proj";
	}

	public partial class MetadataFileContent : core.DataObject
	{
		public reflection.MetadataFile Parent;
		public reflection.TypesCollection Types = new reflection.TypesCollection();
	}

	public abstract partial class Member : core.ReferenceObject
	{
		public string Name = "member";
		public reflection.MetadataMemberGroup Group;
	}

	public partial class MembersCollection : core.CollectionOf <reflection.Member>
	{
	}

	public partial class Value : reflection.Member
	{
		public reflection.Type Type;
		public bool IsXmlAttr = false;
		public bool IsPolymorphic = false;
		public string DefaultValue = "";
		public string DefaultValueXml = "";
		public string Min = "";
		public string Max = "";
	}

	public partial class ValueName : reflection.Value
	{
	}

	public partial class Reference : reflection.Member
	{
		public reflection.MetadataClass Type;
		public bool IsXmlAttr = false;
	}

	public partial class ParentReference : reflection.Member
	{
		public reflection.MetadataClass Type;
	}

	public partial class Collection : reflection.Member
	{
		public reflection.CollectionClass Type;
	}

	public partial class FileStorage : reflection.Member
	{
		public reflection.MetadataClass Type;
	}

} /* namespace reflection */ 