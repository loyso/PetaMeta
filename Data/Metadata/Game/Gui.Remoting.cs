using System;
using System.Collections.Generic;

namespace gui { 

	public partial class Window : core.IRemoteObject
	{
		public bool IsRemoteUploaded
		{
			get { return isRemoteUploaded; }
		}
		protected bool isRemoteUploaded = false;
		
		void core.IRemoteObject.RemoteCreate()  { RemoteCreate(); }
		void core.IRemoteObject.RemoteDestroy() { RemoteDestroy(); }
		void core.IRemoteObject.RemoteUpload()  { RemoteUpload(); }
		void core.IRemoteObject.RemoteUnload()  { RemoteUnload(); }
		bool core.IRemoteObject.IsRemoteUploaded { get { return IsRemoteUploaded; } }
		
		public virtual void RemoteCreate() 
		{
			if ( IsRemoteUploaded )
				return;
			
			data.Remoting.NewObject( Window_Reflection.MetadataClass, this );
			
			isRemoteUploaded = true;
			RemoteCreate_Base();
		}	
		protected virtual void RemoteCreate_Base() 
		{
			children.RemoteCreate();
		}
		
		public virtual void RemoteDestroy() 
		{
			if ( !IsRemoteUploaded )
				return;
				
			RemoteDestroy_Base();
		
			data.Remoting.DeleteObject( Window_Reflection.MetadataClass, this );
		
			isRemoteUploaded = false;
		}	
		protected virtual void RemoteDestroy_Base() 
		{
			children.RemoteDestroy();
		}
		
		public virtual void RemoteUpload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUpload_Base();
		}	
		protected virtual void RemoteUpload_Base() 
		{
			children.RemoteUpload();
			data.Remoting.SetObject_Value( Window_Reflection.MetadataClass, this, Window_Member_position.Member, position );
			data.Remoting.SetObject_Value( Window_Reflection.MetadataClass, this, Window_Member_size.Member, size );
			data.Remoting.SetObject_ParentReference( Window_Reflection.MetadataClass, this, Window_Member_parent.Member, parent );
			data.Remoting.SetObject_ParentReference( Window_Reflection.MetadataClass, this, Window_Member_parentFile.Member, parentFile );
			data.Remoting.SetObject_Value( Window_Reflection.MetadataClass, this, Window_Member_name.Member, new string_Boxed { value = name } );
		}
		
		public virtual void RemoteUnload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUnload_Base();
		}	
		protected virtual void RemoteUnload_Base() 
		{
			children.RemoteUnload();
			data.Remoting.SetObject_ParentReference( Window_Reflection.MetadataClass, this, Window_Member_parent.Member, null );
			data.Remoting.SetObject_ParentReference( Window_Reflection.MetadataClass, this, Window_Member_parentFile.Member, null );
		}
	}

	public partial class WindowsCollection : core.IRemoteObject
	{
		public bool IsRemoteUploaded
		{
			get { return isRemoteUploaded; }
		}
		protected bool isRemoteUploaded = false;
		
		void core.IRemoteObject.RemoteCreate()  { RemoteCreate(); }
		void core.IRemoteObject.RemoteDestroy() { RemoteDestroy(); }
		void core.IRemoteObject.RemoteUpload()  { RemoteUpload(); }
		void core.IRemoteObject.RemoteUnload()  { RemoteUnload(); }
		bool core.IRemoteObject.IsRemoteUploaded { get { return IsRemoteUploaded; } }
		
		public virtual void RemoteCreate() 
		{
			if ( IsRemoteUploaded )
				return;
			
			
			isRemoteUploaded = true;
			RemoteCreate_Base();
		}	
		protected virtual void RemoteCreate_Base() 
		{
			foreach( gui.Window remoteItem in this )
				remoteItem.RemoteCreate();
		}
		
		public virtual void RemoteDestroy() 
		{
			if ( !IsRemoteUploaded )
				return;
				
			RemoteDestroy_Base();
		
		
			isRemoteUploaded = false;
		}	
		protected virtual void RemoteDestroy_Base() 
		{
			foreach( gui.Window remoteItem in this )
				remoteItem.RemoteDestroy();
		}
		
		public virtual void RemoteUpload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUpload_Base();
		}	
		protected virtual void RemoteUpload_Base() 
		{
			foreach( gui.Window remoteItem in this )
				remoteItem.RemoteUpload();
		}
		
		public virtual void RemoteUnload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUnload_Base();
		}	
		protected virtual void RemoteUnload_Base() 
		{
			foreach( gui.Window remoteItem in this )
				remoteItem.RemoteUnload();
		}
	}

} /* namespace gui */ 
