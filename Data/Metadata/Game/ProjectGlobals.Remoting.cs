using System;
using System.Collections.Generic;

namespace game { 

	public partial class Globals : core.IRemoteObject
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
			
			data.Remoting.NewObject( Globals_Reflection.MetadataClass, this );
			
			isRemoteUploaded = true;
			RemoteCreate_Base();
		}	
		protected virtual void RemoteCreate_Base() 
		{
		}
		
		public virtual void RemoteDestroy() 
		{
			if ( !IsRemoteUploaded )
				return;
				
			RemoteDestroy_Base();
		
			data.Remoting.DeleteObject( Globals_Reflection.MetadataClass, this );
		
			isRemoteUploaded = false;
		}	
		protected virtual void RemoteDestroy_Base() 
		{
		}
		
		public virtual void RemoteUpload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUpload_Base();
		}	
		protected virtual void RemoteUpload_Base() 
		{
			data.Remoting.SetObject_Value( Globals_Reflection.MetadataClass, this, Globals_Member_name.Member, new string_Boxed { value = name } );
			data.Remoting.SetObject_ParentReference( Globals_Reflection.MetadataClass, this, Globals_Member_parent.Member, parent );
		}
		
		public virtual void RemoteUnload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUnload_Base();
		}	
		protected virtual void RemoteUnload_Base() 
		{
			data.Remoting.SetObject_ParentReference( Globals_Reflection.MetadataClass, this, Globals_Member_parent.Member, null );
		}
	}

} /* namespace game */ 
