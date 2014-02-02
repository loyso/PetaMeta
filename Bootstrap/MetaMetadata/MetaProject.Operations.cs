using System;
using System.Collections.Generic;

namespace metadata { 

	public partial class MetadataFile : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			if ( Content != null )
				if ( Content.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			if ( Content != null )
				Content.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is metadata.MetadataFile) )
				return;
			
			metadata.MetadataFile from = fromObject as metadata.MetadataFile;
			this.Guid = from.Guid;
			this.Name = from.Name;
			this.Parent = from.Parent;
			this.Namespace = from.Namespace;
			this.GenerateGui = from.GenerateGui;
			this.GenerateSerialization = from.GenerateSerialization;
		}
		
		public virtual void NewGuids()
		{
			this.Guid = Guid.NewGuid();
			if ( Content != null )
				Content.NewGuids();
		}
		
		public virtual void NewNames()
		{
			this.Name = "File";
			if ( Content != null )
				Content.NewNames();
		}
	}

	public partial class MetadataFilesCollection : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			foreach( metadata.MetadataFile item in this )
				if ( item.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			foreach( metadata.MetadataFile remoteItem in this )
				remoteItem.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is metadata.MetadataFilesCollection) )
				return;
			
			metadata.MetadataFilesCollection from = fromObject as metadata.MetadataFilesCollection;
		}
		
		public virtual void NewGuids()
		{
			foreach( metadata.MetadataFile item in this )
				item.NewGuids();
		}
		
		public virtual void NewNames()
		{
			foreach( metadata.MetadataFile item in this )
				item.NewNames();
		}
	}

	public partial class MetadataFolder : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			if ( Folders.ContainsObject( objectReference ) )
				return true;
			if ( Files.ContainsObject( objectReference ) )
				return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			Folders.ObjectDeleted( dataObject );
			Files.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is metadata.MetadataFolder) )
				return;
			
			metadata.MetadataFolder from = fromObject as metadata.MetadataFolder;
			this.Guid = from.Guid;
			this.Name = from.Name;
			this.Parent = from.Parent;
			this.ParentProject = from.ParentProject;
			this.Namespace = from.Namespace;
		}
		
		public virtual void NewGuids()
		{
			this.Guid = Guid.NewGuid();
			Folders.NewGuids();
			Files.NewGuids();
		}
		
		public virtual void NewNames()
		{
			this.Name = "Folder";
			Folders.NewNames();
			Files.NewNames();
		}
	}

	public partial class MetadataFoldersCollection : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			foreach( metadata.MetadataFolder item in this )
				if ( item.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			foreach( metadata.MetadataFolder remoteItem in this )
				remoteItem.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is metadata.MetadataFoldersCollection) )
				return;
			
			metadata.MetadataFoldersCollection from = fromObject as metadata.MetadataFoldersCollection;
		}
		
		public virtual void NewGuids()
		{
			foreach( metadata.MetadataFolder item in this )
				item.NewGuids();
		}
		
		public virtual void NewNames()
		{
			foreach( metadata.MetadataFolder item in this )
				item.NewNames();
		}
	}

	public partial class MetadataMemberGroup : core.IOperations
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
			if ( !(fromObject is metadata.MetadataMemberGroup) )
				return;
			
			metadata.MetadataMemberGroup from = fromObject as metadata.MetadataMemberGroup;
			this.Guid = from.Guid;
			this.Name = from.Name;
			this.PartialFileExtension = from.PartialFileExtension;
		}
		
		public virtual void NewGuids()
		{
			this.Guid = Guid.NewGuid();
		}
		
		public virtual void NewNames()
		{
			this.Name = "Group";
		}
	}

	public partial class MemberGroupsCollection : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			foreach( metadata.MetadataMemberGroup item in this )
				if ( item.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			foreach( metadata.MetadataMemberGroup remoteItem in this )
				remoteItem.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is metadata.MemberGroupsCollection) )
				return;
			
			metadata.MemberGroupsCollection from = fromObject as metadata.MemberGroupsCollection;
		}
		
		public virtual void NewGuids()
		{
			foreach( metadata.MetadataMemberGroup item in this )
				item.NewGuids();
		}
		
		public virtual void NewNames()
		{
			foreach( metadata.MetadataMemberGroup item in this )
				item.NewNames();
		}
	}

	public partial class MetadataProject : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			if ( Metadata != null )
				if ( Metadata.ContainsObject( objectReference ) )
					return true;
			if ( MemberGroups.ContainsObject( objectReference ) )
				return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			if ( Metadata != null )
				Metadata.ObjectDeleted( dataObject );
			MemberGroups.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is metadata.MetadataProject) )
				return;
			
			metadata.MetadataProject from = fromObject as metadata.MetadataProject;
			this.ProjectName = from.ProjectName;
			this.ProjectPath = from.ProjectPath;
			this.CoreNamespace = from.CoreNamespace;
			Metadata.CopyObjectDataFrom( from.Metadata );
		}
		
		public virtual void NewGuids()
		{
			if ( Metadata != null )
				Metadata.NewGuids();
			MemberGroups.NewGuids();
		}
		
		public virtual void NewNames()
		{
			if ( Metadata != null )
				Metadata.NewNames();
			MemberGroups.NewNames();
		}
	}

} /* namespace metadata */ 
