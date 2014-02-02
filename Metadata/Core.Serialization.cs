using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;
using System.ComponentModel;

namespace core
{
	public abstract class SerializationObject
	{
		public virtual void		CreateGuidToObjectMapping		( StringToObject stringToObject ) {}		
		protected virtual void	CreateGuidToObjectMapping_Base	( StringToObject stringToObject ) {}
		
		public virtual void		FromSerializationConstruct		( DataObject dataObject ) {}
		protected void			FromSerializationConstruct_Base	( DataObject dataObject ) {}

		public virtual void		FromSerialization			( StringToObject stringToObject ) {}
		protected void			FromSerialization_Base		( DataObject dataObject, StringToObject stringToObject ) {}
		
		public virtual void		ToSerialization				( DataObject dataObject ) {}
		protected void			ToSerialization_Base		( DataObject dataObject ) {}
		
		public virtual void		FileStorage_FromSerializationConstruct() {}
		public virtual void		FileStorage_FromSerialization( StringToObject stringToObject ) {}
		public virtual void		FileStorage_ToSerialization() {}
		
		public virtual void		CreateDirectory(string projectPath) {}
		protected virtual void	CreateDirectory_Base(string projectPath) {}
		public virtual void		Load() {}
		public virtual void		Save() {}
		public virtual void		SaveAs(string projectPath) {}
	}
    public abstract class ReferenceSerializationObject : SerializationObject
    {
        [XmlAttribute("Guid")]
        [DefaultValue("")]
        public string GuidStr = "";

		protected void FromSerializationConstruct_Base( ReferenceObject dataObject )
		{
			if ( GuidStr.Length > 0 )
				dataObject.Guid = GuidStr.ToOptGuid();
			else // auto-create missing guids
			{
				dataObject.Guid = Guid.NewGuid();
				GuidStr = dataObject.Guid.ToOptString();				
			}
		}

		protected void FromSerialization_Base( ReferenceObject dataObject, StringToObject stringToObject )
		{
		}				 

		protected void ToSerialization_Base( ReferenceObject dataObject )
		{
			GuidStr = dataObject.Guid.ToOptString();
		}	
    }

	public abstract class PartialObject
	{
		public virtual void FromSerializationBind	( DataObject dataObject, StringToObject stringToObject ) {}
		public virtual void FromSerialization		( StringToObject stringToObject ) {}
		public virtual void ToSerialization			( DataObject dataObject ) {}

		protected void FromSerializationBind_Base	( DataObject dataObject, StringToObject stringToObject ) {}
		protected void FromSerialization_Base		( DataObject dataObject, StringToObject stringToObject ) {}
		protected void ToSerialization_Base			( DataObject dataObject ) {}
		
		public virtual void		FileStorage_FromSerializationBind( StringToObject stringToObject ) {}
		public virtual void		FileStorage_FromSerialization( StringToObject stringToObject ) {}
		public virtual void		FileStorage_ToSerialization() {}
		
		public virtual void		CreateDirectory(string projectPath) {}
		protected virtual void	CreateDirectory_Base(string projectPath) {}
		public virtual void		Load() {}
		public virtual void		Save() {}
		public virtual void		SaveAs(string projectPath) {}				
	}
    public abstract class ReferencePartialObject : PartialObject
    {
        [XmlAttribute("Guid")]
        [DefaultValue("")]       
        public string GuidStr = "";

		protected void FromSerializationBind_Base( ReferenceObject dataObject, StringToObject stringToObject )
		{
		}

		protected void FromSerialization_Base( ReferenceObject dataObject, StringToObject stringToObject )
		{
		}				 

		protected void ToSerialization_Base( ReferenceObject dataObject )
		{
			GuidStr = dataObject.Guid.ToOptString();
		}
    }

    public class StringToObject 
	{
		private Dictionary<Guid, ReferenceObject> GuidToObject = new Dictionary<Guid, ReferenceObject>();
		
		public void Add(Guid guid, ReferenceObject referenceObject)
		{
			GuidToObject.Add(guid,referenceObject);
		}

		public T Fixup < T > (Guid guid) where T : core.ReferenceObject
		{
			if ( guid == System.Guid.Empty )
				return null;
			ReferenceObject referenceObject;
			if ( !GuidToObject.TryGetValue( guid, out referenceObject ) )
				throw new ReferencesFixupException( guid );
			T typedObject = referenceObject as T;
			if ( typedObject == null )
				throw new ReferencesFixupException( guid );
			return typedObject;
		}
	}
      
    public class SerializationCollectionOf<T> : SerializationObject, IEnumerable<T>
    {
        protected List<T> Values = new List<T>();

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
        
        public void Clear()
        {
			Values.Clear();
        }
        
        public T Find( Predicate<T> match )
        {
			return Values.Find( match );
        }
    }    
      
    public class PartialCollectionOf<T> : PartialObject, IEnumerable<T>
    {
        protected List<T> Values = new List<T>();

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
        
        public void Clear()
        {
			Values.Clear();
        }
        
        public T Find( Predicate<T> match )
        {
			return Values.Find( match );
        }
    }    
      
	public class ReferencesFixupException : System.Exception 
	{
		public ReferencesFixupException( Guid guid )
		{
			Guid = guid;
		}

		public Guid Guid;
	}
} // namespace core

#if BOOTSTRAP

public static class GuidExt
{
	public static Guid ToOptGuid( this string str )
	{
		if ( str == null || str == "" )
			return System.Guid.Empty;
		else
			return new System.Guid( str );
	}

	public static string ToOptString( this Guid guid )
	{
		if ( guid == System.Guid.Empty )
			return "";
		else
			return guid.ToString();
	}
}

#endif