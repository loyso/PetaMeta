using System;
using System.Collections.Generic;

namespace game { 

	public partial class Game : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			if ( globals != null )
				if ( globals.ContainsObject( objectReference ) )
					return true;
			if ( gui != null )
				if ( gui.ContainsObject( objectReference ) )
					return true;
			if ( levels != null )
				if ( levels.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			if ( globals != null )
				globals.ObjectDeleted( dataObject );
			if ( gui != null )
				gui.ObjectDeleted( dataObject );
			if ( levels != null )
				levels.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is game.Game) )
				return;
			
			game.Game from = fromObject as game.Game;
			this.Guid = from.Guid;
			this.ProjectName = from.ProjectName;
			this.ProjectPath = from.ProjectPath;
			globals.CopyObjectDataFrom( from.globals );
			gui.CopyObjectDataFrom( from.gui );
			levels.CopyObjectDataFrom( from.levels );
		}
		
		public virtual void NewGuids()
		{
			this.Guid = Guid.NewGuid();
			if ( globals != null )
				globals.NewGuids();
			if ( gui != null )
				gui.NewGuids();
			if ( levels != null )
				levels.NewGuids();
		}
		
		public virtual void NewNames()
		{
			if ( globals != null )
				globals.NewNames();
			if ( gui != null )
				gui.NewNames();
			if ( levels != null )
				levels.NewNames();
		}
	}

} /* namespace game */ 
