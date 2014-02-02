using System;
using System.Collections.Generic;

namespace metadata { 

	public abstract partial class Function
	{
		public override bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( base.ContainsObject( objectReference ) )
				return true;
			
			if ( Result != null )
				if ( Result.ContainsObject( objectReference ) )
					return true;
			if ( Arguments.ContainsObject( objectReference ) )
				return true;
			
			return false;
		}
		
		public override void ObjectDeleted( core.DataObject dataObject ) 
		{
			base.ObjectDeleted( dataObject );
			
			if ( Result != null )
				Result.ObjectDeleted( dataObject );
			Arguments.ObjectDeleted( dataObject );
		}
		
		public override void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected override void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			base.CopyObjectDataFrom_Base( fromObject );
			
			if ( !(fromObject is metadata.Function) )
				return;
			
			metadata.Function from = fromObject as metadata.Function;
			this.Guid = from.Guid;
			Result.CopyObjectDataFrom( from.Result );
			this.Remote = from.Remote;
			this.IsStatic = from.IsStatic;
		}
		
		public override void NewGuids()
		{
			base.NewGuids();
			
			if ( Result != null )
				Result.NewGuids();
			Arguments.NewGuids();
		}
		
		public override void NewNames()
		{
			base.NewNames();
			
			if ( Result != null )
				Result.NewNames();
			Arguments.NewNames();
		}
	}

	public partial class FunctionUser
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
			
			if ( !(fromObject is metadata.FunctionUser) )
				return;
			
			metadata.FunctionUser from = fromObject as metadata.FunctionUser;
			this.Guid = from.Guid;
			this.ExposeToLua = from.ExposeToLua;
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

	public partial class FunctionLua
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
			
			if ( !(fromObject is metadata.FunctionLua) )
				return;
			
			metadata.FunctionLua from = fromObject as metadata.FunctionLua;
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

	public partial class FunctionLuaCallCC
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
			
			if ( !(fromObject is metadata.FunctionLuaCallCC) )
				return;
			
			metadata.FunctionLuaCallCC from = fromObject as metadata.FunctionLuaCallCC;
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

	public abstract partial class Argument : core.IOperations
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
			if ( !(fromObject is metadata.Argument) )
				return;
			
			metadata.Argument from = fromObject as metadata.Argument;
			this.Name = from.Name;
		}
		
		public virtual void NewGuids()
		{
		}
		
		public virtual void NewNames()
		{
			this.Name = "arg";
		}
	}

	public partial class ArgumentsCollection : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			foreach( metadata.Argument item in this )
				if ( item.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			foreach( metadata.Argument remoteItem in this )
				remoteItem.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is metadata.ArgumentsCollection) )
				return;
			
			metadata.ArgumentsCollection from = fromObject as metadata.ArgumentsCollection;
		}
		
		public virtual void NewGuids()
		{
			foreach( metadata.Argument item in this )
				item.NewGuids();
		}
		
		public virtual void NewNames()
		{
			foreach( metadata.Argument item in this )
				item.NewNames();
		}
	}

	public partial class ArgumentValue
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
			
			if ( !(fromObject is metadata.ArgumentValue) )
				return;
			
			metadata.ArgumentValue from = fromObject as metadata.ArgumentValue;
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

	public partial class ArgumentReference
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
			
			if ( !(fromObject is metadata.ArgumentReference) )
				return;
			
			metadata.ArgumentReference from = fromObject as metadata.ArgumentReference;
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
