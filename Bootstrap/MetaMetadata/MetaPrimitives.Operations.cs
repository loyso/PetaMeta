using System;
using System.Collections.Generic;

namespace metadata { 

	public abstract partial class Fundamental
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
			
			if ( !(fromObject is metadata.Fundamental) )
				return;
			
			metadata.Fundamental from = fromObject as metadata.Fundamental;
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

	public partial class FundamentalBool
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
			
			if ( !(fromObject is metadata.FundamentalBool) )
				return;
			
			metadata.FundamentalBool from = fromObject as metadata.FundamentalBool;
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

	public partial class FundamentalString
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
			
			if ( !(fromObject is metadata.FundamentalString) )
				return;
			
			metadata.FundamentalString from = fromObject as metadata.FundamentalString;
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

	public partial class FundamentalInt
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
			
			if ( !(fromObject is metadata.FundamentalInt) )
				return;
			
			metadata.FundamentalInt from = fromObject as metadata.FundamentalInt;
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

	public partial class FundamentalFloat
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
			
			if ( !(fromObject is metadata.FundamentalFloat) )
				return;
			
			metadata.FundamentalFloat from = fromObject as metadata.FundamentalFloat;
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

	public partial class FundamentalByte
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
			
			if ( !(fromObject is metadata.FundamentalByte) )
				return;
			
			metadata.FundamentalByte from = fromObject as metadata.FundamentalByte;
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

	public partial class Enumeration
	{
		public override bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( base.ContainsObject( objectReference ) )
				return true;
			
			if ( Enumerators.ContainsObject( objectReference ) )
				return true;
			
			return false;
		}
		
		public override void ObjectDeleted( core.DataObject dataObject ) 
		{
			base.ObjectDeleted( dataObject );
			
			Enumerators.ObjectDeleted( dataObject );
		}
		
		public override void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected override void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			base.CopyObjectDataFrom_Base( fromObject );
			
			if ( !(fromObject is metadata.Enumeration) )
				return;
			
			metadata.Enumeration from = fromObject as metadata.Enumeration;
			this.Guid = from.Guid;
		}
		
		public override void NewGuids()
		{
			base.NewGuids();
			
			Enumerators.NewGuids();
		}
		
		public override void NewNames()
		{
			base.NewNames();
			
			Enumerators.NewNames();
		}
	}

	public partial class Enumerator : core.IOperations
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
			if ( !(fromObject is metadata.Enumerator) )
				return;
			
			metadata.Enumerator from = fromObject as metadata.Enumerator;
			this.Name = from.Name;
			this.IntegralValue = from.IntegralValue;
		}
		
		public virtual void NewGuids()
		{
		}
		
		public virtual void NewNames()
		{
			this.Name = "Enumerator";
		}
	}

	public partial class EnumeratorsCollection : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			foreach( metadata.Enumerator item in this )
				if ( item.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			foreach( metadata.Enumerator remoteItem in this )
				remoteItem.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is metadata.EnumeratorsCollection) )
				return;
			
			metadata.EnumeratorsCollection from = fromObject as metadata.EnumeratorsCollection;
		}
		
		public virtual void NewGuids()
		{
			foreach( metadata.Enumerator item in this )
				item.NewGuids();
		}
		
		public virtual void NewNames()
		{
			foreach( metadata.Enumerator item in this )
				item.NewNames();
		}
	}

} /* namespace metadata */ 
