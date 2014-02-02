using System;
using System.Collections.Generic;

public partial class Vec2 : core.IOperations
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
		if ( !(fromObject is Vec2) )
			return;
		
		Vec2 from = fromObject as Vec2;
		this.x = from.x;
		this.y = from.y;
	}
	
	public virtual void NewGuids()
	{
	}
	
	public virtual void NewNames()
	{
	}
}

public partial class Vec3 : core.IOperations
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
		if ( !(fromObject is Vec3) )
			return;
		
		Vec3 from = fromObject as Vec3;
		this.x = from.x;
		this.y = from.y;
		this.z = from.z;
	}
	
	public virtual void NewGuids()
	{
	}
	
	public virtual void NewNames()
	{
	}
}

public partial class Vec4 : core.IOperations
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
		if ( !(fromObject is Vec4) )
			return;
		
		Vec4 from = fromObject as Vec4;
		this.x = from.x;
		this.y = from.y;
		this.z = from.z;
		this.w = from.w;
	}
	
	public virtual void NewGuids()
	{
	}
	
	public virtual void NewNames()
	{
	}
}

public partial class Color : core.IOperations
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
		if ( !(fromObject is Color) )
			return;
		
		Color from = fromObject as Color;
		this.r = from.r;
		this.g = from.g;
		this.b = from.b;
		this.a = from.a;
	}
	
	public virtual void NewGuids()
	{
	}
	
	public virtual void NewNames()
	{
	}
}

