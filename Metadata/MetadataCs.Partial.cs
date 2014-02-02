using System;
using System.Collections.Generic;

namespace metadata
{
	using ProcessedClassses = System.Collections.Generic.HashSet<MetadataClass>;

	public partial class Type
	{
		public string QualifiedNamespace 
		{ 
			get 
			{ 
				string qualifiedNamespace = Parent.Parent.QualifiedNamespace;
				if ( Namespace.Length > 0 )
				{
					if ( qualifiedNamespace.Length > 0 )
						qualifiedNamespace += ".";
					qualifiedNamespace += Namespace;
				}
				return qualifiedNamespace; 
			} 
		}
		
		public virtual string QualifiedTypeName 
		{ 
			get 
			{ 
				string qualifiedTypeName = QualifiedNamespace;
				if ( qualifiedTypeName.Length > 0 )
					qualifiedTypeName += ".";
				qualifiedTypeName += TypeName;
				return qualifiedTypeName;
			} 
		}
		
		public string QualifiedTypeNameCpp 
		{ 
			get 
			{ 
				return QualifiedTypeName.Replace( ".", "::" );	
			} 
		}

		public virtual string SerializationTypeName( MetadataMemberGroup group ) 
		{ 
			return TypeName;
		}

		public virtual string QualifiedSerializationTypeName( MetadataMemberGroup group ) 
		{ 
			return QualifiedTypeName;
		}
	}

	public partial class Fundamental
	{
		public override string QualifiedTypeName 
		{ 
			get 
			{ 
				return TypeName;
			} 
		}
	}

	public partial class MetadataClass
	{
		public override string SerializationTypeName( MetadataMemberGroup group ) 
		{ 
			string serializationTypeName = TypeName + "_Serialization";
			if ( group != null && !HasAllMembersDefaultGroup )
				serializationTypeName += "_" + group.Name;
			return serializationTypeName;
		}

		public override string QualifiedSerializationTypeName( MetadataMemberGroup group ) 
		{ 
			string qualifiedTypeName = QualifiedNamespace;
			if ( qualifiedTypeName.Length > 0 )
				qualifiedTypeName += ".";
			qualifiedTypeName += SerializationTypeName(group);
			return qualifiedTypeName;
		}

		public bool IsReferencedDeep
		{
			get
			{
				if ( IsReferenced )
					return true;

				if ( BaseClass != null )
					if ( BaseClass.IsReferencedDeep )
						return true;

				return false;
			}
		}

        public bool HasFundamentalsOnly
        {
            get
            {
				foreach (Member member in Members)
				{
					if ( !(member is Value) )
						return false;
					if ( !( (member as Value).Type is Fundamental ) )
						return false;
				}

				if ( BaseClass != null )
					if ( !BaseClass.HasFundamentalsOnly )
						return false;

				return true;
			}
		}

        public bool HasReferences
        {
            get
            {				
				ProcessedClassses processedClasses = new ProcessedClassses();
				return HasReferencesCyclic( processedClasses );
			}
		}
        public virtual bool HasReferencesCyclic( ProcessedClassses processedClasses )
        {
            if ( IsReferenced )
                return true;

			processedClasses.Add( this );

			foreach (Member member in Members)
            {
				MetadataClass metadataClass = null;

				if ( member is Reference )
					return true;

				if ( member is ParentReference )
				{}

				if ( member is Value )
					metadataClass = (member as Value).Type as MetadataClass;

				if ( member is Collection )
					metadataClass = (member as Collection).Type;

				if ( member is FileStorage )
					metadataClass = (member as FileStorage).Type;

				if ( metadataClass != null && !processedClasses.Contains(metadataClass) && metadataClass.HasReferencesCyclic(processedClasses) )
					return true;
            }

			// do not process BaseClass, see HasReferencesDeep

            return false;
        }

        public bool HasReferencesDeep
        {
            get
            {				
				ProcessedClassses processedClasses = new ProcessedClassses();
				return HasReferencesDeepCyclic( processedClasses );
			}
		}
        public virtual bool HasReferencesDeepCyclic( ProcessedClassses processedClasses )
        {
			if ( HasReferencesCyclic( processedClasses ) )
				return true;

			if ( BaseClass != null )
				if ( BaseClass.HasReferencesDeepCyclic( processedClasses ) )
					return true;

			return false;
		}

        public bool HasCollections
        {
            get
            {				
				ProcessedClassses processedClasses = new ProcessedClassses();
				return HasCollectionsCyclic( processedClasses );
			}
		}
        public virtual bool HasCollectionsCyclic( ProcessedClassses processedClasses )
        {
			processedClasses.Add( this );

			foreach (Member member in Members)
            {
				if ( member is Value )
				{
					MetadataClass metadataClass = (member as Value).Type as MetadataClass;
					if ( metadataClass != null && !processedClasses.Contains(metadataClass) && metadataClass.HasCollectionsCyclic( processedClasses ) )
						return true;
				}

				if ( member is Collection )
					return true;

				if ( member is FileStorage )
					return true;
			}

			if ( BaseClass != null && BaseClass.HasCollectionsCyclic( processedClasses ) )
					return true;

			return false;
		}

		public bool HasMembersOfGroup( MetadataMemberGroup memberGroup )
		{
			ProcessedClassses processedClasses = new ProcessedClassses();
			return HasMembersOfGroupCyclic( processedClasses, memberGroup );
		}
		public virtual bool HasMembersOfGroupCyclic( ProcessedClassses processedClasses, MetadataMemberGroup memberGroup )
		{
			processedClasses.Add( this );

			foreach (Member member in Members)
            {
				if ( member.Group == memberGroup )
					return true;

				MetadataClass metadataClass = null;

				if ( member is Reference )
				{}

				if ( member is ParentReference )
				{}

				if ( member is Value )
					metadataClass = (member as Value).Type as MetadataClass;

				if ( member is Collection )
					metadataClass = (member as Collection).Type;

				if ( member is FileStorage )
					metadataClass = (member as FileStorage).Type;

				if ( metadataClass != null && !processedClasses.Contains(metadataClass) && metadataClass.HasMembersOfGroupCyclic( processedClasses, memberGroup ) )
					return true;
			}

			if ( BaseClass != null && BaseClass.HasMembersOfGroupCyclic( processedClasses, memberGroup ) )
				return true;

			return false;
		}

		public bool HasAllMembersDefaultGroup
		{
			get
			{
				ProcessedClassses processedClasses = new ProcessedClassses();
				return HasAllMembersDefaultGroupCyclic( processedClasses );
			}
		}
		public virtual bool HasAllMembersDefaultGroupCyclic( ProcessedClassses processedClasses )
		{
			processedClasses.Add( this );

			foreach (Member member in Members)
			{
				if ( member.Group != null )
					return false;

				MetadataClass metadataClass = null;

				if ( member is Reference )
				{}

				if ( member is ParentReference )
				{}

				if ( member is Value )
					metadataClass = (member as Value).Type as MetadataClass;

				if ( member is Collection )
					metadataClass = (member as Collection).Type;

				if ( member is FileStorage )
					metadataClass = (member as FileStorage).Type;

				if ( metadataClass != null && !processedClasses.Contains(metadataClass) && !metadataClass.HasAllMembersDefaultGroupCyclic(processedClasses) )
					return false;
			}

			if ( BaseClass != null && !BaseClass.HasAllMembersDefaultGroupCyclic(processedClasses) )
				return false;

			return true;
		}

		public System.Collections.IEnumerable MembersByGroup( MetadataMemberGroup memberGroup ) 
		{ 
			foreach (Member member in Members)
            {
				MetadataClass metadataClass = null;

				if ( member.Group == memberGroup )
					yield return member;
				else if ( member is Reference )
				{}
				else if ( member is ParentReference )
					yield return member;
				else if ( member is Value )
					metadataClass = (member as Value).Type as MetadataClass;
				else if ( member is Collection )
					metadataClass = (member as Collection).Type;
				else if ( member is FileStorage )
					metadataClass = (member as FileStorage).Type;

				if ( metadataClass != null && !metadataClass.HasAllMembersDefaultGroup )
					if ( metadataClass.HasMembersOfGroup(memberGroup) )
						yield return member;
			}
		}
		public System.Collections.IEnumerable MembersByGroupDeep( MetadataMemberGroup memberGroup ) 
		{ 
			foreach (Member member in MembersByGroup( memberGroup ) )
				yield return member;

			if ( BaseClass != null )
				foreach (Member member in BaseClass.MembersByGroupDeep( memberGroup ) )
					yield return member;
		}
		public System.Collections.IEnumerable MembersByGroupAndName( MetadataMemberGroup memberGroup ) 
		{
			foreach (Member member in Members)
				if ( member is ValueName && ( this is FolderClass || this is FileClass ) && member.Group != memberGroup )
					yield return member;
			foreach (Member member in MembersByGroup(memberGroup) )
					yield return member;
		}

		public System.Collections.IEnumerable MembersDeep 
		{ 
			get
			{
				if ( BaseClass != null )
				{
					foreach (Member member in BaseClass.MembersDeep )
						yield return member;
				}

				foreach (Member member in Members)
					yield return member;
			}
		}

		public Member FindMemberDeep(Predicate<Member> match)
		{
			foreach ( Member m in MembersDeep )
				if ( match( m ) )
					return m;

			return null;
		}

		public bool IsDerivedFrom( MetadataClass baseClass )
		{
			if ( BaseClass != null )
			{
				if ( BaseClass == baseClass )
					return true;

				if ( BaseClass.IsDerivedFrom( baseClass ) )
					return true;
			}

			return false;
		}

		public bool IsLessEq( MetadataClass metadataClass )
		{
			if ( metadataClass == this )
				return true;
			if ( IsDerivedFrom( metadataClass ) )
				return true;
			return false;
		}

		public bool ContainsObjects( MetadataClass metadataClass )
		{
			ProcessedClassses processedClasses = new ProcessedClassses();
			return ContainsObjects_Cyclic( metadataClass, processedClasses );
		}
		public virtual bool ContainsObjects_Cyclic( MetadataClass metadataClass, ProcessedClassses processedClasses )
		{
			processedClasses.Add( this );

			foreach (Member member in Members)
			{
				MetadataClass aggregateClass = null;

				if ( member is Reference )
				{}

				if ( member is ParentReference )
				{}

				if ( member is Value )
					aggregateClass = (member as Value).Type as MetadataClass;

				if ( member is Collection )
					aggregateClass = (member as Collection).Type;

				if ( member is FileStorage )
					aggregateClass = (member as FileStorage).Type;

				if ( aggregateClass != null )
				{
					if ( metadataClass.IsLessEq( aggregateClass ) )
						return true;

					if ( !processedClasses.Contains(aggregateClass) && aggregateClass.ContainsObjects_Cyclic(metadataClass, processedClasses) )
						return true;
				}
			}

			if ( BaseClass != null && BaseClass.ContainsObjects_Cyclic(metadataClass,processedClasses) )
				return true;

			return false;
		}

		public System.Collections.IEnumerable BaseClasses
		{
			get
			{
				if ( BaseClass != null )
					yield return BaseClass.BaseClasses;

				yield return BaseClass;
			}
		}

		public MetadataClass FindBaseClass(Predicate< MetadataClass > match)
		{
			if ( BaseClass != null )
			{
				if ( match( BaseClass ) )
					return BaseClass;

				return BaseClass.FindBaseClass( match );
			}

			return null;
		}
	}

	public partial class CollectionClass
	{
		public CollectionClass()
		{
			IsReferenced = false;
		}

        public override bool HasReferencesCyclic( ProcessedClassses processedClasses )
        {
			if ( base.HasReferencesCyclic(processedClasses) )
				return true;

			if ( !processedClasses.Contains( ItemsClass ) && ItemsClass.HasReferencesCyclic(processedClasses) )
				return true;

            return false;
        }

		public override bool HasMembersOfGroupCyclic( ProcessedClassses processedClasses, MetadataMemberGroup memberGroup )
		{
			if ( base.HasMembersOfGroupCyclic( processedClasses, memberGroup ) )
				return true;
			
			if ( !processedClasses.Contains(ItemsClass) && ItemsClass.HasMembersOfGroupCyclic( processedClasses, memberGroup ) )
				return true;

			return false;
		}

		public override bool HasAllMembersDefaultGroupCyclic( ProcessedClassses processedClasses )
		{
			if ( !base.HasAllMembersDefaultGroupCyclic(processedClasses) )
				return false;

			if ( !processedClasses.Contains(ItemsClass) && !ItemsClass.HasAllMembersDefaultGroupCyclic(processedClasses) )
				return false;

			return true;
		}

		public override bool ContainsObjects_Cyclic( MetadataClass metadataClass, ProcessedClassses processedClasses )
		{
			if ( base.ContainsObjects_Cyclic(metadataClass, processedClasses) )
				return true;

			if ( !processedClasses.Contains(ItemsClass) )
			{
				if ( metadataClass.IsLessEq( ItemsClass ) )
					return true;
				if ( ItemsClass.ContainsObjects_Cyclic(metadataClass, processedClasses) )
					return true;
			}

			return false;
		}
	}

	public partial class FileClass
	{
		public FileClass()
		{
			IsReferenced = true;
		}
	}

	public partial class FolderClass
	{
		public FolderClass()
		{
			IsReferenced = true;
		}
	}

	public partial class ProjectClass
	{
		public ProjectClass()
		{
			IsReferenced = true;
		}
	}

	public partial class Value
	{
		public bool IsGuiTreeNode
		{
			get
			{
				return ( Type is MetadataClass && (Type as MetadataClass).HasCollections );
			}
		}

		public bool MinMaxDefined
		{
			get 
			{
				return Min.Length > 0 && Max.Length > 0;
			}
		}

		public bool AggregateByValue
		{
			get
			{
				if ( IsPolymorphic )
					return false;

				if ( Type is MetadataClass )
					return (Type as MetadataClass).HasFundamentalsOnly;

				return true;
			}
		}
	}

	public partial class Reference
	{
	}

	public partial class ParentReference
	{
	}

	public partial class FileStorage
	{
	}

	public partial class Collection
	{
	}

	public partial class Function
	{
		public string DeclarationCpp
		{
			get
			{
				string declaration = "";
				declaration += Name;
				declaration += "(";
				string sep=" "; 
				foreach( Argument a in Arguments ) 
				{ 
					declaration += sep;
					if ( a is ArgumentValue )
					{
						ArgumentValue argumentValue = a as ArgumentValue;
						if ( argumentValue.Type != null )
						{
							declaration += argumentValue.Type.QualifiedTypeNameCpp;
							if ( argumentValue.Type is MetadataClass )
								declaration += " const & " + argumentValue.Name;
							else
								declaration += " " + argumentValue.Name;
						}
						else
						{
							declaration += "void const * " + argumentValue.Name;
							declaration += ", core::uint32 " + argumentValue.Name + "Size";
						}
					}
					else if ( a is ArgumentReference )
					{
						ArgumentReference argumentReference = a as ArgumentReference;
						if ( argumentReference.Type != null )
						{
							declaration += argumentReference.Type.QualifiedTypeNameCpp;
							declaration += "* " + argumentReference.Name;
						}
						else
						{
							declaration += "core::Guid const & " + argumentReference.Name;
						}
					}
					sep = ", ";
				}
				declaration += ")";

				return declaration;
			}
		}

		public string DeclarationWithResultCpp
		{
			get
			{
				string declaration = "";
				if ( IsStatic )
					declaration += "static ";
				if ( Result == null )
					declaration += "void";
				else 
					declaration += Result.QualifiedTypeCpp;

				declaration += " " + DeclarationCpp;

				return declaration;
			}
		}

		public string DeclarationWithResultFullCpp( string typeName )
		{
			string declaration = "";
			if ( IsStatic )
				declaration += "static ";
			if ( Result == null )
				declaration += "void";
			else 
				declaration += Result.QualifiedTypeCpp;

			declaration += " " + typeName + "::" + DeclarationCpp;

			return declaration;
		}

		public string DeclarationWithOptionalResultCpp
		{
			get
			{
				string declaration = "";
				if ( IsStatic )
					declaration += "static ";
				if ( Result == null )
					declaration += "bool";
				else 
					declaration += "core::Optional<" + Result.QualifiedTypeCpp + ">";

				declaration += " " + DeclarationCpp;

				return declaration;
			}
		}

		public string DeclarationWithOptionalResultFullCpp( string typeName )
		{
			string declaration = "";
			if ( IsStatic )
				declaration += "static ";
			if ( Result == null )
				declaration += "bool";
			else 
				declaration += "core::Optional<" + Result.QualifiedTypeCpp + ">";

			declaration += " " + typeName + "::" + DeclarationCpp;

			return declaration;
		}

		public string DeclarationWithoutResultCpp( string resultType )
		{
			string declaration = "";
			if ( IsStatic )
				declaration += "static ";
			declaration += resultType;
			declaration += " " + DeclarationCpp;

			return declaration;
		}

		public string DeclarationWithoutResultFullCpp( string typeName, string resultType )
		{
			string declaration = "";
			if ( IsStatic )
				declaration += "static ";
			declaration += resultType;
			declaration += " " + typeName + "::" + DeclarationCpp;

			return declaration;
		}

		public string CallDeclarationCpp
		{
			get
			{
				string declaration = Name;

				declaration += "( ";

				string sep=""; 
				foreach( Argument a in Arguments ) 
				{ 
					declaration += sep;
					declaration += a.Name; 
					sep = ", "; 
				}
				declaration += " )";

				return declaration;
			}
		}
	}

	public partial class Argument
	{
		public abstract string QualifiedTypeCpp
		{
			get;
		}
	}

	public partial class ArgumentValue
	{
		public override string QualifiedTypeCpp
		{
			get { return Type != null ? Type.QualifiedTypeNameCpp : "core::List<core::uint8>"; }
		}
	}

	public partial class ArgumentReference
	{
		public override string QualifiedTypeCpp
		{
			get { return Type != null ? Type.QualifiedTypeNameCpp + "*" : "core::Guid"; }
		}
	}

	public partial class MetadataFileContent
	{
		public System.Collections.IEnumerable Classes 
		{ 
			get
			{
				foreach (Type type in Types)
				{
					MetadataClass metadataClass = type as MetadataClass;
					if ( metadataClass != null )
						yield return metadataClass;
				}
			}
		}

		public System.Collections.IEnumerable ClassesSorted
		{ 
			get
			{
				ProcessedClassses processedClassses = new ProcessedClassses();
				foreach (MetadataClass metadataClass in Classes)
					foreach (MetadataClass sortedClass in ClassesSorted_Cyclic( metadataClass, processedClassses ) )
						yield return sortedClass;
			}
		}
		public System.Collections.IEnumerable ClassesSorted_Cyclic( MetadataClass metadataClass, ProcessedClassses processedClassses )
		{
			if ( metadataClass.BaseClass != null )
				foreach (MetadataClass sortedClass in ClassesSorted_Cyclic( metadataClass.BaseClass, processedClassses ) )
					yield return sortedClass;

			foreach( Member m in metadataClass.Members )
			{
				MetadataClass valueClass = null;
				if ( m is Collection )
					valueClass = (m as Collection).Type;
				if ( m is FileStorage )
					valueClass = (m as FileStorage).Type;
				if ( m is Value )
					valueClass = (m as Value).Type as MetadataClass;

				if ( valueClass != null && !processedClassses.Contains(valueClass) && Types.Contains(valueClass) )
					foreach ( MetadataClass sortedClass in ClassesSorted_Cyclic( valueClass, processedClassses ) )
						yield return sortedClass;
			}

			if ( !processedClassses.Contains(metadataClass) && Types.Contains(metadataClass) )
			{
				processedClassses.Add( metadataClass );
				yield return metadataClass;
			}
		}

		public System.Collections.IEnumerable AggregatedClassesInOtherFiles
		{ 
			get
			{
				foreach ( MetadataClass metadataClass in Classes )
				{
					foreach( Member m in metadataClass.Members )
					{
						MetadataClass valueClass = null;
						if ( m is Collection )
							valueClass = (m as Collection).Type;
						if ( m is FileStorage )
							valueClass = (m as FileStorage).Type;
						if ( m is Value )
							valueClass = (m as Value).Type as MetadataClass;

						if ( valueClass != null && !Types.Contains( valueClass ) )
							yield return valueClass;
					}
				}
			}
		}

		public System.Collections.IEnumerable ReferencedClassesInOtherFiles
		{ 
			get
			{
				foreach ( MetadataClass metadataClass in Classes )
				{
					foreach( Member m in metadataClass.Members )
					{
						MetadataClass valueClass = null;
						if ( m is ParentReference )
							valueClass = (m as ParentReference).Type;
						if ( m is Reference )
							valueClass = (m as Reference).Type;

						if ( valueClass != null && !Types.Contains( valueClass ) )
							yield return valueClass;
					}
				}
			}
		}

		public System.Collections.IEnumerable Enumerations 
		{ 
			get
			{
				foreach (metadata.Type type in Types)
				{
					Enumeration enumeration = type as metadata.Enumeration;
					if ( enumeration != null )
						yield return enumeration;
				}
			}
		}

		public System.Collections.IEnumerable DerivedClasses( MetadataClass baseClass )
		{
			foreach (Type type in Types)
			{
				MetadataClass metadataClass = type as MetadataClass;
				if ( metadataClass != null && metadataClass.IsDerivedFrom( baseClass ) )
					yield return metadataClass;
			}
		}

		public System.Collections.IEnumerable Fundamentals 
		{ 
			get
			{
				foreach (Type type in Types)
				{
					Fundamental fundamental = type as Fundamental;
					if ( fundamental != null )
						yield return fundamental;
				}
			}
		}

		public Type Type( string typeName )
		{
			Type type = Types.Find( t => t.TypeName == typeName );
			if ( type == null )
				throw new core.TreePathException( typeName );
			return type;
		}

		public T CreateType < T >( string typeName, string namespaceName ) where T : Type, new()
		{
			T type = new T();
			type.Guid = Guid.NewGuid();
			type.TypeName = typeName;
			type.Namespace = namespaceName;
			Types.Add( type );
			return type;
		}
	}

	public partial class MetadataFile
	{
		public string QualifiedNamespace 
		{ 
			get 
			{ 
				string qualifiedNamespace = Parent.QualifiedNamespace;
				if ( Namespace.Length > 0 )
				{
					if ( qualifiedNamespace.Length > 0 )
						qualifiedNamespace += ".";
					qualifiedNamespace += Namespace;
				}
				return qualifiedNamespace; 
			} 
		}

		public string QualifiedNamespaceBegin
		{ 
			get
			{
				string qualifiedNamespace = Parent.QualifiedNamespaceBegin;
				if ( Namespace.Length > 0 )
					qualifiedNamespace += "namespace " + Namespace + " { " ;
				return qualifiedNamespace; 
			}
		}

		public string QualifiedNamespaceEnd
		{ 
			get
			{
				string qualifiedNamespace = Parent.QualifiedNamespaceEnd;
				if ( Namespace.Length > 0 )
					qualifiedNamespace += "} /* namespace "  + Namespace + " */ " ;
				return qualifiedNamespace; 
			}
		}

		public bool IsParentFolder( MetadataFolder folder )
		{
			MetadataFolder parent = Parent;
			while ( parent != null )
			{
				if ( parent == folder )
					return true;
				parent = parent.Parent;
			}
			return false;
		}

		public string RelativePathFor( MetadataFile metadataFile )
		{
			// find common upper folder
			string relativePathUpper = "";
			MetadataFolder parentUpper = Parent;
			while ( !metadataFile.IsParentFolder(parentUpper) && parentUpper != null )
			{
				relativePathUpper += @"..\";
				parentUpper = parentUpper.Parent;
			}
			
			if ( parentUpper != null )
			{
				string relativePathDeeper = "";
				MetadataFolder parentDeeper = metadataFile.Parent;
				while( parentDeeper != parentUpper && parentDeeper != null )
				{
					relativePathDeeper = parentDeeper.Name + @"\" + relativePathDeeper;
					parentDeeper = parentDeeper.Parent;
				}
				
				return relativePathUpper + relativePathDeeper;
			}

			return "";
		}

		public string RelativePathToProj
		{
			get
			{
				string relativePathUpper = "";
				MetadataFolder parentUpper = Parent;
				while ( parentUpper != null )
				{
					relativePathUpper += @"..\";
					parentUpper = parentUpper.Parent;
				}

				return relativePathUpper;
			}
		}
	}

	public partial class MetadataFolder
	{
		public string QualifiedNamespace 
		{ 
			get 
			{ 
				string qualifiedNamespace = "";				
				if ( Parent != null )
					qualifiedNamespace = Parent.QualifiedNamespace;
				if ( Namespace.Length > 0 )
				{
					if ( qualifiedNamespace.Length > 0 )
						qualifiedNamespace += ".";
					qualifiedNamespace += Namespace;
				}
				return qualifiedNamespace; 
			} 
		}

		public string QualifiedNamespaceBegin
		{ 
			get
			{
				string qualifiedNamespace = "";				
				if ( Parent != null )
					qualifiedNamespace = Parent.QualifiedNamespaceBegin;
				if ( Namespace.Length > 0 )
					qualifiedNamespace += "namespace " + Namespace + " { " ;
				return qualifiedNamespace; 
			}
		}

		public string QualifiedNamespaceEnd
		{ 
			get
			{
				string qualifiedNamespace = "";				
				if ( Parent != null )
					qualifiedNamespace = Parent.QualifiedNamespaceEnd;
				if ( Namespace.Length > 0 )
					qualifiedNamespace += "} /* namespace " + Namespace + " */ " ;
				return qualifiedNamespace; 
			}
		}

		public System.Collections.IEnumerable Classes 
		{ 
			get
			{
				foreach( MetadataFolder metadataFolder in Folders )
					foreach(MetadataClass metadataClass in metadataFolder.Classes)
						yield return metadataClass;			
				foreach( MetadataFile metadataFile in Files )
					if ( metadataFile.Content != null )
						foreach(MetadataClass metadataClass in metadataFile.Content.Classes)
							yield return metadataClass;			
			}
		}

		public System.Collections.IEnumerable FilesRecursive
		{ 
			get
			{
				foreach( MetadataFolder metadataFolder in Folders )
					foreach(MetadataFile metadataFile in metadataFolder.FilesRecursive)
						yield return metadataFile;			
				foreach(MetadataFile metadataFile in Files)
					if ( metadataFile.Content != null )
						yield return metadataFile;
			}
		}

		public System.Collections.IEnumerable FoldersRecursive
		{ 
			get
			{
				foreach( MetadataFolder metadataFolder in Folders )
				{
					yield return metadataFolder;
					foreach ( MetadataFolder metadataSubFolder in metadataFolder.FoldersRecursive )
						yield return metadataSubFolder;
				}
			}
		}

		public ProjectClass ProjectClass
		{
			get
			{
				foreach(MetadataClass metadataClass in Classes)
					if ( metadataClass is ProjectClass )
						return (ProjectClass)metadataClass;
				return null;
			}
		}

		public System.Collections.IEnumerable DerivedClasses( MetadataClass baseClass )
		{ 
			foreach( MetadataFolder metadataFolder in Folders )
				foreach(MetadataClass metadataClass in metadataFolder.DerivedClasses( baseClass ) )
					yield return metadataClass;			
			foreach( MetadataFile metadataFile in Files )
				if ( metadataFile.Content != null )
					foreach(MetadataClass metadataClass in metadataFile.Content.DerivedClasses( baseClass ) )
						yield return metadataClass;			
		}

		public System.Collections.IEnumerable BaseAndDerivedClasses( MetadataClass baseClass )
		{ 
			yield return baseClass;
			foreach ( MetadataClass metadataClass in DerivedClasses(baseClass) )
				yield return metadataClass;
		}
	}

	public partial class MetadataProject
	{
		public System.Collections.IEnumerable MemberGroupsAll
		{ 
			get
			{				
				yield return null; // main group first
				foreach ( MetadataMemberGroup group in MemberGroups )
					yield return group;
			}
		}
	}
} // namespace metadata
