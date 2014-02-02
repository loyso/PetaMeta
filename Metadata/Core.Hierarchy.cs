using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core
{
	public abstract class IHierarchyObject
	{
	}
	
	public abstract partial class HierarchyObject : IHierarchyObject
	{
		public core.DataObject This;

		public virtual void		CreateHierarchy( core.DataObject obj ) {}
		protected virtual void	CreateHierarchy_Base( core.DataObject obj ) {}

		public virtual void		CopyObjectDataFrom( core.DataObject fromObject ) {}	
		protected virtual void	CopyObjectDataFrom_Base( core.DataObject fromObject ) {}

		public virtual void		NewGuids() {}	
		public virtual void		NewNames() {}
	}

	public abstract partial class ReferenceHierarchyObject : HierarchyObject
	{
		public new core.ReferenceObject This;

		protected override void	CreateHierarchy_Base( core.DataObject obj ) 
		{
			This = (core.ReferenceObject)obj;
		}

		public override void NewGuids() 
		{
			This.Guid = Guid.NewGuid();
		}	
	}
	
	public class HierarchyCollectionOf<T> : HierarchyObject, IEnumerable<T>
	{
		private List<T> Values = new List<T>();

		public IEnumerator<T> GetEnumerator()
		{
			return Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	    
		public void Add( T item )
		{
			Values.Add( item );
		}
	    
	    public void Remove( T item )
	    {
			Values.Remove( item );
	    }
	    
		public void Clear()
		{
			Values.Clear();
		}
	    
		public T Find( Predicate<T> match )
		{
			return Values.Find( match );
		}
	}
}
