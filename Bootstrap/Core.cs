using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;
using System.Net;

namespace core
{
    public abstract class DataObject
    {
    }
    
    public abstract class ReferenceObject : DataObject
    {
        public Guid Guid;
    }
    
    public abstract class FundamentalBoxed : DataObject
    {
    }

    public interface IFolderStorageObject
	{
		bool DependsOn( IFolderStorageObject folderStorage );
	}
    
	public interface ICollection
	{
		bool CanContain		( DataObject dataObject );
		void Add			( DataObject dataObject );
		void AddAfter		( DataObject dataObjectAfter, DataObject dataObject );
		void Remove			( DataObject dataObject );
	}
    
    public class CollectionOf<T> : DataObject, ICollection, IEnumerable<T> where T : DataObject
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
        
        public void Insert( int index, T item )
        {
			Values.Insert( index, item );
        }
        
        public int IndexOf( T item )
        {
			return Values.IndexOf( item );
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
        
		public T this[ int index ] 
		{ 
			get
			{
				return Values [ index ];
			}
			set
			{
				Values [ index ] = value;
			}
		}        
        
		public bool Contains( T item )
		{
			return Values.Contains( item );
		} 
		
		public bool Empty
		{
			get
			{
				return Values.Count == 0;
			}
		}

		public int Count
		{
			get 
			{
				return Values.Count;
			}
		}
		
		bool ICollection.CanContain( DataObject dataObject )
		{
			return dataObject is T;
		}
		void ICollection.Add( DataObject dataObject )
		{
			T item = (T)dataObject;
			Add( item );
		}
		void ICollection.AddAfter( DataObject dataObjectAfter, DataObject dataObject )
		{
			T after = (T)dataObjectAfter;
			T item = (T)dataObject;

			int index = 0;
			if ( after != null )
				index = IndexOf( after ) + 1;
			
			Insert( index, item );
		}
		void ICollection.Remove( DataObject dataObject )
		{
			T item = (T)dataObject;
			Remove( item );
		}	
    }
   
	public class TreePathException : System.Exception 
	{
		public TreePathException( string path )
		{
			Path = path;
		}

		public string Path;
	}    
	
	public class TypeMappingException : System.Exception 
	{
		public TypeMappingException( System.Type systemType )
		{
			SystemType = systemType;
		}

		public System.Type SystemType;
	}
	
	public static class Raw
	{
		public static byte[] Serialize( object anything )
		{
			int rawsize = Marshal.SizeOf( anything );
			IntPtr buffer = Marshal.AllocHGlobal( rawsize );
			Marshal.StructureToPtr( anything, buffer, false );
			byte[] rawdatas = new byte[ rawsize ];
			Marshal.Copy( buffer, rawdatas, 0, rawsize );
			Marshal.FreeHGlobal( buffer );
			return rawdatas;
		}

		public static object Deserialize( byte[] rawdatas, System.Type anytype )
		{
			int rawsize = Marshal.SizeOf( anytype );
			if( rawsize > rawdatas.Length )
				return null;
			IntPtr buffer = Marshal.AllocHGlobal( rawsize );
			Marshal.Copy( rawdatas, 0, buffer, rawsize );
			object retobj = Marshal.PtrToStructure( buffer, anytype );
			Marshal.FreeHGlobal( buffer );
			return retobj;
		}
		
		public static byte[] AppendArrays(byte[] a, byte[] b)
		{
			byte[] c = new byte[a.Length + b.Length];
			Buffer.BlockCopy(a, 0, c, 0, a.Length);
			Buffer.BlockCopy(b, 0, c, a.Length, b.Length);
			return c;
		}	
	}		
	
	public interface ByteStreamReader
	{
		bool ReadFloat32( ref float value );

		bool ReadUint8 ( ref byte value );
		bool ReadUint16( ref ushort value );
		bool ReadUint32( ref uint value );
		bool ReadUint64( ref ulong value );
		
		bool ReadInt8  ( ref sbyte value );
		bool ReadInt16 ( ref short value );
		bool ReadInt32 ( ref int value );
		bool ReadInt64 ( ref long value );
		
		bool ReadBytes( ref byte[] bytes );

		bool ReadGuid( ref Guid guid );
	};
	
	public interface ByteStreamWriter
	{
		void WriteFloat32( float value );

		void WriteUint8 ( byte value );
		void WriteUint16( ushort value );
		void WriteUint32( uint value );
		void WriteUint64( ulong value );
		
		void WriteInt8  ( sbyte value );
		void WriteInt16 ( short value );
		void WriteInt32 ( int value );
		void WriteInt64 ( long value );
		
		void WriteBytes( byte[] bytes );

		void WriteGuid( Guid guid );
	};

	public class NetworkByteStreamWriter : ByteStreamWriter
	{
		List < byte > data = new List < byte >();
		
		public byte[] ToArray()
		{
			return data.ToArray();
		}
		
		void Write( byte[] bytes )
		{
			data.AddRange( bytes );
		}
	
		public void WriteFloat32( float value ) { Write( BitConverter.GetBytes( IPAddress.HostToNetworkOrder( BitConverter.ToInt32( BitConverter.GetBytes(value), 0 ) ) ) ); }

		public void WriteUint8 ( byte value )	{ Write( new byte[1] { value } ); }
		public void WriteUint16( ushort value ) { Write( BitConverter.GetBytes( IPAddress.HostToNetworkOrder((short)value) ) ); }
		public void WriteUint32( uint value )	{ Write( BitConverter.GetBytes( IPAddress.HostToNetworkOrder((int)value) ) ); }
		public void WriteUint64( ulong value )	{ Write( BitConverter.GetBytes( IPAddress.HostToNetworkOrder((long)value) ) ); }
		
		public void WriteInt8  ( sbyte value )	{ Write( new byte[1] { (byte)value } ); }
		public void WriteInt16 ( short value )	{ Write( BitConverter.GetBytes( IPAddress.HostToNetworkOrder(value) ) ); }
		public void WriteInt32 ( int value )	{ Write( BitConverter.GetBytes( IPAddress.HostToNetworkOrder(value) ) ); }
		public void WriteInt64 ( long value )	{ Write( BitConverter.GetBytes( IPAddress.HostToNetworkOrder(value) ) ); }
		
		public void WriteBytes( byte[] bytes )	
		{
			const byte NetworkByteStream_SizeTag = 255;
			if ( bytes.Length >= NetworkByteStream_SizeTag )
			{
				WriteUint8( NetworkByteStream_SizeTag );
				WriteUint32( (uint)bytes.Length );
			}			
			else
				WriteUint8( (byte)bytes.Length );
			
			Write( bytes );
		}

		public void WriteGuid( Guid guid )		
		{ 
			byte[] guidBytes = guid.ToByteArray();
			Write( BitConverter.GetBytes( IPAddress.HostToNetworkOrder( BitConverter.ToInt32( guidBytes, 0 ) ) ) );
			Write( BitConverter.GetBytes( IPAddress.HostToNetworkOrder( BitConverter.ToInt16( guidBytes, 4 ) ) ) );
			Write( BitConverter.GetBytes( IPAddress.HostToNetworkOrder( BitConverter.ToInt16( guidBytes, 6 ) ) ) );
			Write( BitConverter.GetBytes( BitConverter.ToInt64( guidBytes, 8 ) ) );
		}
	};
	
} // namespace core
