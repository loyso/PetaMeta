using System;
using System.Collections.Generic;

namespace metadata { 

	public abstract partial class Type : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is metadata.Type) )
				return;
			
			metadata.Type from = fromObject as metadata.Type;
			this.Guid = from.Guid;
			this.Parent = from.Parent;
			this.TypeName = from.TypeName;
			this.Namespace = from.Namespace;
		}
		
		public virtual void NewGuids()
		{
			this.Guid = Guid.NewGuid();
		}
		
		public virtual void NewNames()
		{
			this.TypeName = "Type";
		}
	}

	public partial class TypesCollection : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			foreach( metadata.Type item in this )
				if ( item.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			foreach( metadata.Type remoteItem in this )
				remoteItem.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is metadata.TypesCollection) )
				return;
			
			metadata.TypesCollection from = fromObject as metadata.TypesCollection;
		}
		
		public virtual void NewGuids()
		{
			foreach( metadata.Type item in this )
				item.NewGuids();
		}
		
		public virtual void NewNames()
		{
			foreach( metadata.Type item in this )
				item.NewNames();
		}
	}

	public partial class MetadataClass
	{
		public override bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( base.ContainsObject( objectReference ) )
				return true;
			
			if ( Members.ContainsObject( objectReference ) )
				return true;
			
			return false;
		}
		
		public override void ObjectDeleted( core.DataObject dataObject ) 
		{
			base.ObjectDeleted( dataObject );
			
			if ( (dataObject as core.IOperations).ContainsObject( BaseClass ) )
				BaseClass = null;
			Members.ObjectDeleted( dataObject );
		}
		
		public override void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected override void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			base.CopyObjectDataFrom_Base( fromObject );
			
			if ( !(fromObject is metadata.MetadataClass) )
				return;
			
			metadata.MetadataClass from = fromObject as metadata.MetadataClass;
			this.Guid = from.Guid;
			this.BaseClass = from.BaseClass;
			this.IsReferenced = from.IsReferenced;
			this.HasMinMax = from.HasMinMax;
			this.UserDefined = from.UserDefined;
		}
		
		public override void NewGuids()
		{
			base.NewGuids();
			
			Members.NewGuids();
		}
		
		public override void NewNames()
		{
			base.NewNames();
			
			Members.NewNames();
		}
	}

	public partial class AbstractClass
	{
		public override bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( base.ContainsObject( objectReference ) )
				return true;
			
			
			return false;
		}
		
		public override void ObjectDeleted( core.DataObject dataObject ) 
		{
			base.ObjectDeleted( dataObject );
			
		}
		
		public override void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected override void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			base.CopyObjectDataFrom_Base( fromObject );
			
			if ( !(fromObject is metadata.AbstractClass) )
				return;
			
			metadata.AbstractClass from = fromObject as metadata.AbstractClass;
			this.Guid = from.Guid;
		}
		
		public override void NewGuids()
		{
			base.NewGuids();
			
		}
		
		public override void NewNames()
		{
			base.NewNames();
			
		}
	}

	public partial class CollectionClass
	{
		public override bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( base.ContainsObject( objectReference ) )
				return true;
			
			
			return false;
		}
		
		public override void ObjectDeleted( core.DataObject dataObject ) 
		{
			base.ObjectDeleted( dataObject );
			
			if ( (dataObject as core.IOperations).ContainsObject( ItemsClass ) )
				ItemsClass = null;
		}
		
		public override void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected override void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			base.CopyObjectDataFrom_Base( fromObject );
			
			if ( !(fromObject is metadata.CollectionClass) )
				return;
			
			metadata.CollectionClass from = fromObject as metadata.CollectionClass;
			this.Guid = from.Guid;
			this.ItemsClass = from.ItemsClass;
			this.IsPolymorphic = from.IsPolymorphic;
		}
		
		public override void NewGuids()
		{
			base.NewGuids();
			
		}
		
		public override void NewNames()
		{
			base.NewNames();
			
		}
	}

	public partial class FileClass
	{
		public override bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( base.ContainsObject( objectReference ) )
				return true;
			
			
			return false;
		}
		
		public override void ObjectDeleted( core.DataObject dataObject ) 
		{
			base.ObjectDeleted( dataObject );
			
		}
		
		public override void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected override void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			base.CopyObjectDataFrom_Base( fromObject );
			
			if ( !(fromObject is metadata.FileClass) )
				return;
			
			metadata.FileClass from = fromObject as metadata.FileClass;
			this.Guid = from.Guid;
			this.FileExtension = from.FileExtension;
		}
		
		public override void NewGuids()
		{
			base.NewGuids();
			
		}
		
		public override void NewNames()
		{
			base.NewNames();
			
		}
	}

	public partial class FolderClass
	{
		public override bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( base.ContainsObject( objectReference ) )
				return true;
			
			
			return false;
		}
		
		public override void ObjectDeleted( core.DataObject dataObject ) 
		{
			base.ObjectDeleted( dataObject );
			
		}
		
		public override void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected override void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			base.CopyObjectDataFrom_Base( fromObject );
			
			if ( !(fromObject is metadata.FolderClass) )
				return;
			
			metadata.FolderClass from = fromObject as metadata.FolderClass;
			this.Guid = from.Guid;
		}
		
		public override void NewGuids()
		{
			base.NewGuids();
			
		}
		
		public override void NewNames()
		{
			base.NewNames();
			
		}
	}

	public partial class FolderStorageClass
	{
		public override bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( base.ContainsObject( objectReference ) )
				return true;
			
			
			return false;
		}
		
		public override void ObjectDeleted( core.DataObject dataObject ) 
		{
			base.ObjectDeleted( dataObject );
			
		}
		
		public override void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected override void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			base.CopyObjectDataFrom_Base( fromObject );
			
			if ( !(fromObject is metadata.FolderStorageClass) )
				return;
			
			metadata.FolderStorageClass from = fromObject as metadata.FolderStorageClass;
			this.Guid = from.Guid;
		}
		
		public override void NewGuids()
		{
			base.NewGuids();
			
		}
		
		public override void NewNames()
		{
			base.NewNames();
			
		}
	}

	public partial class ProjectClass
	{
		public override bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( base.ContainsObject( objectReference ) )
				return true;
			
			
			return false;
		}
		
		public override void ObjectDeleted( core.DataObject dataObject ) 
		{
			base.ObjectDeleted( dataObject );
			
		}
		
		public override void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected override void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			base.CopyObjectDataFrom_Base( fromObject );
			
			if ( !(fromObject is metadata.ProjectClass) )
				return;
			
			metadata.ProjectClass from = fromObject as metadata.ProjectClass;
			this.FileExtension = from.FileExtension;
		}
		
		public override void NewGuids()
		{
			base.NewGuids();
			
		}
		
		public override void NewNames()
		{
			base.NewNames();
			
		}
	}

	public partial class MetadataFileContent : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			if ( Types.ContainsObject( objectReference ) )
				return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			Types.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is metadata.MetadataFileContent) )
				return;
			
			metadata.MetadataFileContent from = fromObject as metadata.MetadataFileContent;
			this.Parent = from.Parent;
		}
		
		public virtual void NewGuids()
		{
			Types.NewGuids();
		}
		
		public virtual void NewNames()
		{
			Types.NewNames();
		}
	}

	public abstract partial class Member : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			if ( (dataObject as core.IOperations).ContainsObject( Group ) )
				Group = null;
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is metadata.Member) )
				return;
			
			metadata.Member from = fromObject as metadata.Member;
			this.Guid = from.Guid;
			this.Name = from.Name;
			this.Group = from.Group;
		}
		
		public virtual void NewGuids()
		{
			this.Guid = Guid.NewGuid();
		}
		
		public virtual void NewNames()
		{
			this.Name = "member";
		}
	}

	public partial class MembersCollection : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			foreach( metadata.Member item in this )
				if ( item.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			foreach( metadata.Member remoteItem in this )
				remoteItem.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is metadata.MembersCollection) )
				return;
			
			metadata.MembersCollection from = fromObject as metadata.MembersCollection;
		}
		
		public virtual void NewGuids()
		{
			foreach( metadata.Member item in this )
				item.NewGuids();
		}
		
		public virtual void NewNames()
		{
			foreach( metadata.Member item in this )
				item.NewNames();
		}
	}

	public partial class Value
	{
		public override bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( base.ContainsObject( objectReference ) )
				return true;
			
			
			return false;
		}
		
		public override void ObjectDeleted( core.DataObject dataObject ) 
		{
			base.ObjectDeleted( dataObject );
			
			if ( (dataObject as core.IOperations).ContainsObject( Type ) )
				Type = null;
		}
		
		public override void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected override void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			base.CopyObjectDataFrom_Base( fromObject );
			
			if ( !(fromObject is metadata.Value) )
				return;
			
			metadata.Value from = fromObject as metadata.Value;
			this.Guid = from.Guid;
			this.Type = from.Type;
			this.IsXmlAttr = from.IsXmlAttr;
			this.IsPolymorphic = from.IsPolymorphic;
			this.DefaultValue = from.DefaultValue;
			this.DefaultValueXml = from.DefaultValueXml;
			this.Min = from.Min;
			this.Max = from.Max;
		}
		
		public override void NewGuids()
		{
			base.NewGuids();
			
		}
		
		public override void NewNames()
		{
			base.NewNames();
			
		}
	}

	public partial class ValueName
	{
		public override bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( base.ContainsObject( objectReference ) )
				return true;
			
			
			return false;
		}
		
		public override void ObjectDeleted( core.DataObject dataObject ) 
		{
			base.ObjectDeleted( dataObject );
			
		}
		
		public override void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected override void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			base.CopyObjectDataFrom_Base( fromObject );
			
			if ( !(fromObject is metadata.ValueName) )
				return;
			
			metadata.ValueName from = fromObject as metadata.ValueName;
			this.Guid = from.Guid;
		}
		
		public override void NewGuids()
		{
			base.NewGuids();
			
		}
		
		public override void NewNames()
		{
			base.NewNames();
			
		}
	}

	public partial class Reference
	{
		public override bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( base.ContainsObject( objectReference ) )
				return true;
			
			
			return false;
		}
		
		public override void ObjectDeleted( core.DataObject dataObject ) 
		{
			base.ObjectDeleted( dataObject );
			
			if ( (dataObject as core.IOperations).ContainsObject( Type ) )
				Type = null;
		}
		
		public override void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected override void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			base.CopyObjectDataFrom_Base( fromObject );
			
			if ( !(fromObject is metadata.Reference) )
				return;
			
			metadata.Reference from = fromObject as metadata.Reference;
			this.Guid = from.Guid;
			this.Type = from.Type;
			this.IsXmlAttr = from.IsXmlAttr;
		}
		
		public override void NewGuids()
		{
			base.NewGuids();
			
		}
		
		public override void NewNames()
		{
			base.NewNames();
			
		}
	}

	public partial class ParentReference
	{
		public override bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( base.ContainsObject( objectReference ) )
				return true;
			
			
			return false;
		}
		
		public override void ObjectDeleted( core.DataObject dataObject ) 
		{
			base.ObjectDeleted( dataObject );
			
			if ( (dataObject as core.IOperations).ContainsObject( Type ) )
				Type = null;
		}
		
		public override void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected override void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			base.CopyObjectDataFrom_Base( fromObject );
			
			if ( !(fromObject is metadata.ParentReference) )
				return;
			
			metadata.ParentReference from = fromObject as metadata.ParentReference;
			this.Guid = from.Guid;
			this.Type = from.Type;
		}
		
		public override void NewGuids()
		{
			base.NewGuids();
			
		}
		
		public override void NewNames()
		{
			base.NewNames();
			
		}
	}

	public partial class Collection
	{
		public override bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( base.ContainsObject( objectReference ) )
				return true;
			
			
			return false;
		}
		
		public override void ObjectDeleted( core.DataObject dataObject ) 
		{
			base.ObjectDeleted( dataObject );
			
			if ( (dataObject as core.IOperations).ContainsObject( Type ) )
				Type = null;
		}
		
		public override void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected override void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			base.CopyObjectDataFrom_Base( fromObject );
			
			if ( !(fromObject is metadata.Collection) )
				return;
			
			metadata.Collection from = fromObject as metadata.Collection;
			this.Guid = from.Guid;
			this.Type = from.Type;
		}
		
		public override void NewGuids()
		{
			base.NewGuids();
			
		}
		
		public override void NewNames()
		{
			base.NewNames();
			
		}
	}

	public partial class FileStorage
	{
		public override bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( base.ContainsObject( objectReference ) )
				return true;
			
			
			return false;
		}
		
		public override void ObjectDeleted( core.DataObject dataObject ) 
		{
			base.ObjectDeleted( dataObject );
			
			if ( (dataObject as core.IOperations).ContainsObject( Type ) )
				Type = null;
		}
		
		public override void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected override void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			base.CopyObjectDataFrom_Base( fromObject );
			
			if ( !(fromObject is metadata.FileStorage) )
				return;
			
			metadata.FileStorage from = fromObject as metadata.FileStorage;
			this.Guid = from.Guid;
			this.Type = from.Type;
		}
		
		public override void NewGuids()
		{
			base.NewGuids();
			
		}
		
		public override void NewNames()
		{
			base.NewNames();
			
		}
	}

} /* namespace metadata */ 
