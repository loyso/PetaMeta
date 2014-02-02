using System;
using System.Collections.Generic;

namespace gui { 

	public partial class Window : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			if ( children.ContainsObject( objectReference ) )
				return true;
			if ( position != null )
				if ( position.ContainsObject( objectReference ) )
					return true;
			if ( size != null )
				if ( size.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			children.ObjectDeleted( dataObject );
			if ( position != null )
				position.ObjectDeleted( dataObject );
			if ( size != null )
				size.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is gui.Window) )
				return;
			
			gui.Window from = fromObject as gui.Window;
			this.Guid = from.Guid;
			position.CopyObjectDataFrom( from.position );
			size.CopyObjectDataFrom( from.size );
			this.parent = from.parent;
			this.parentFile = from.parentFile;
			this.name = from.name;
		}
		
		public virtual void NewGuids()
		{
			this.Guid = Guid.NewGuid();
			children.NewGuids();
			if ( position != null )
				position.NewGuids();
			if ( size != null )
				size.NewGuids();
		}
		
		public virtual void NewNames()
		{
			this.name = "Window";
			children.NewNames();
			if ( position != null )
				position.NewNames();
			if ( size != null )
				size.NewNames();
		}
	}

	public partial class WindowsCollection : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			foreach( gui.Window item in this )
				if ( item.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			foreach( gui.Window remoteItem in this )
				remoteItem.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is gui.WindowsCollection) )
				return;
			
			gui.WindowsCollection from = fromObject as gui.WindowsCollection;
		}
		
		public virtual void NewGuids()
		{
			foreach( gui.Window item in this )
				item.NewGuids();
		}
		
		public virtual void NewNames()
		{
			foreach( gui.Window item in this )
				item.NewNames();
		}
	}

} /* namespace gui */ 
