using System;
using System.Collections.Generic;

namespace level { 

	public partial class Levels : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			if ( folders.ContainsObject( objectReference ) )
				return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			folders.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is level.Levels) )
				return;
			
			level.Levels from = fromObject as level.Levels;
			this.Guid = from.Guid;
			this.name = from.name;
			this.parent = from.parent;
		}
		
		public virtual void NewGuids()
		{
			this.Guid = Guid.NewGuid();
			folders.NewGuids();
		}
		
		public virtual void NewNames()
		{
			this.name = "Levels";
			folders.NewNames();
		}
	}

	public partial class LevelFolder : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			if ( dependencies.ContainsObject( objectReference ) )
				return true;
			if ( blocks.ContainsObject( objectReference ) )
				return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			dependencies.ObjectDeleted( dataObject );
			blocks.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is level.LevelFolder) )
				return;
			
			level.LevelFolder from = fromObject as level.LevelFolder;
			this.Guid = from.Guid;
			this.name = from.name;
			this.parent = from.parent;
		}
		
		public virtual void NewGuids()
		{
			this.Guid = Guid.NewGuid();
			dependencies.NewGuids();
			blocks.NewGuids();
		}
		
		public virtual void NewNames()
		{
			this.name = "Level";
			dependencies.NewNames();
			blocks.NewNames();
		}
	}

	public partial class LevelFoldersCollection : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			foreach( level.LevelFolder item in this )
				if ( item.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			foreach( level.LevelFolder remoteItem in this )
				remoteItem.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is level.LevelFoldersCollection) )
				return;
			
			level.LevelFoldersCollection from = fromObject as level.LevelFoldersCollection;
		}
		
		public virtual void NewGuids()
		{
			foreach( level.LevelFolder item in this )
				item.NewGuids();
		}
		
		public virtual void NewNames()
		{
			foreach( level.LevelFolder item in this )
				item.NewNames();
		}
	}

	public partial class LevelBlock : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			if ( files.ContainsObject( objectReference ) )
				return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			files.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is level.LevelBlock) )
				return;
			
			level.LevelBlock from = fromObject as level.LevelBlock;
			this.Guid = from.Guid;
			this.name = from.name;
			this.parent = from.parent;
		}
		
		public virtual void NewGuids()
		{
			this.Guid = Guid.NewGuid();
			files.NewGuids();
		}
		
		public virtual void NewNames()
		{
			this.name = "Block";
			files.NewNames();
		}
	}

	public partial class LevelBlocksCollection : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			foreach( level.LevelBlock item in this )
				if ( item.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			foreach( level.LevelBlock remoteItem in this )
				remoteItem.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is level.LevelBlocksCollection) )
				return;
			
			level.LevelBlocksCollection from = fromObject as level.LevelBlocksCollection;
		}
		
		public virtual void NewGuids()
		{
			foreach( level.LevelBlock item in this )
				item.NewGuids();
		}
		
		public virtual void NewNames()
		{
			foreach( level.LevelBlock item in this )
				item.NewNames();
		}
	}

	public partial class LevelFile : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			if ( scene != null )
				if ( scene.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			if ( scene != null )
				scene.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is level.LevelFile) )
				return;
			
			level.LevelFile from = fromObject as level.LevelFile;
			this.Guid = from.Guid;
			this.parent = from.parent;
			this.name = from.name;
		}
		
		public virtual void NewGuids()
		{
			this.Guid = Guid.NewGuid();
			if ( scene != null )
				scene.NewGuids();
		}
		
		public virtual void NewNames()
		{
			this.name = "File";
			if ( scene != null )
				scene.NewNames();
		}
	}

	public partial class LevelFilesCollection : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			foreach( level.LevelFile item in this )
				if ( item.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			foreach( level.LevelFile remoteItem in this )
				remoteItem.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is level.LevelFilesCollection) )
				return;
			
			level.LevelFilesCollection from = fromObject as level.LevelFilesCollection;
		}
		
		public virtual void NewGuids()
		{
			foreach( level.LevelFile item in this )
				item.NewGuids();
		}
		
		public virtual void NewNames()
		{
			foreach( level.LevelFile item in this )
				item.NewNames();
		}
	}

	public partial class Dependency : core.IOperations
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
			if ( (dataObject as core.IOperations).ContainsObject( LevelFolder ) )
				LevelFolder = null;
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is level.Dependency) )
				return;
			
			level.Dependency from = fromObject as level.Dependency;
			this.Guid = from.Guid;
			this.LevelFolder = from.LevelFolder;
		}
		
		public virtual void NewGuids()
		{
			this.Guid = Guid.NewGuid();
		}
		
		public virtual void NewNames()
		{
		}
	}

	public partial class Dependencies : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			foreach( level.Dependency item in this )
				if ( item.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			foreach( level.Dependency remoteItem in this )
				remoteItem.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is level.Dependencies) )
				return;
			
			level.Dependencies from = fromObject as level.Dependencies;
		}
		
		public virtual void NewGuids()
		{
			foreach( level.Dependency item in this )
				item.NewGuids();
		}
		
		public virtual void NewNames()
		{
			foreach( level.Dependency item in this )
				item.NewNames();
		}
	}

} /* namespace level */ 
