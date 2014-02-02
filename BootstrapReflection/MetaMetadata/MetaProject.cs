
// AUTOGENERATED FILE. MODIFY IT AT YOUR OWN RISK.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace reflection { 

	public partial class MetadataFile : core.ReferenceObject
	{
		public string Name = "File";
		public reflection.MetadataFolder Parent;
		public string Namespace = "";
		public reflection.MetadataFileContent Content;
		public bool GenerateGui = true;
		public bool GenerateSerialization = true;
		public string RelativeName { get { return Parent.RelativeName + @"\" + Name; } }
		public string FullName { get { return Parent.FullName + @"\" + Name; } }
		public string RootFolderRelativeName { get { return Parent.RootFolderRelativeName + Name; } }
	}

	public partial class MetadataFilesCollection : core.CollectionOf <reflection.MetadataFile>
	{
	}

	public partial class MetadataFolder : core.ReferenceObject
	{
		public string Name = "Folder";
		public reflection.MetadataFolder Parent;
		public reflection.MetadataProject ParentProject;
		public string Namespace = "";
		public reflection.MetadataFoldersCollection Folders = new reflection.MetadataFoldersCollection();
		public reflection.MetadataFilesCollection Files = new reflection.MetadataFilesCollection();
		public string RelativeName { get { return (Parent == null ? "" : Parent.RelativeName + @"\") + Name; } }
		public string RootFolderRelativeName { get { return Parent == null ? "" : Parent.RootFolderRelativeName + Name + @"\"; } }
		public string FullName { get { return (Parent == null ? ParentProject.ProjectPath : Parent.FullName ) + @"\" + Name; } }
		
		public reflection.MetadataFolder MetadataFolderCreate(string name)
		{
			reflection.MetadataFolder collectionElement = new reflection.MetadataFolder();
			collectionElement.Parent = this;
			collectionElement.Name = name;
			collectionElement.Guid = Guid.NewGuid();
			
			Folders.Add(collectionElement);
			return collectionElement;
		}
		
		public reflection.MetadataFile MetadataFileCreate(string name)
		{
			reflection.MetadataFile collectionElement = new reflection.MetadataFile();
			collectionElement.Parent = this;
			collectionElement.Name = name;
			collectionElement.Guid = Guid.NewGuid();
			
			Files.Add(collectionElement);
			return collectionElement;
		}
		
		public reflection.MetadataFolder MetadataFolderGet( string name )
		{
			reflection.MetadataFolder collectionElement = Folders.Find( f => f.Name == name );
			if ( collectionElement == null )
				throw new core.TreePathException( name );
			return collectionElement;
		}
		
		public reflection.MetadataFile MetadataFileGet( string name )
		{
			reflection.MetadataFile collectionElement = Files.Find( f => f.Name == name );
			if ( collectionElement == null )
				throw new core.TreePathException( name );
			return collectionElement;
		}
	}

	public partial class MetadataFoldersCollection : core.CollectionOf <reflection.MetadataFolder>
	{
	}

	public partial class MetadataMemberGroup : core.ReferenceObject
	{
		public string Name = "Group";
		public string PartialFileExtension;
	}

	public partial class MemberGroupsCollection : core.CollectionOf <reflection.MetadataMemberGroup>
	{
	}

	public partial class MetadataProject : core.DataObject
	{
		public string CoreNamespace = "core";
		public reflection.MetadataFolder Metadata = new reflection.MetadataFolder ();
		public reflection.MemberGroupsCollection MemberGroups = new reflection.MemberGroupsCollection();
		public string ProjectPath;
		public string ProjectName;
	}

} /* namespace reflection */ 
