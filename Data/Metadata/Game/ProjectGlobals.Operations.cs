using System;
using System.Collections.Generic;

namespace game { 

	public partial class Globals : core.IOperations
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
			if ( !(fromObject is game.Globals) )
				return;
			
			game.Globals from = fromObject as game.Globals;
			this.Guid = from.Guid;
			this.name = from.name;
			this.parent = from.parent;
		}
		
		public virtual void NewGuids()
		{
			this.Guid = Guid.NewGuid();
		}
		
		public virtual void NewNames()
		{
			this.name = "Globals";
		}
	}

} /* namespace game */ 
