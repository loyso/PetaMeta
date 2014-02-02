using System;
using System.Collections.Generic;

namespace game { 

	public partial class Game : core.IRemoteObject
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
			
			data.Remoting.NewObject( Game_Reflection.MetadataClass, this );
			
			isRemoteUploaded = true;
			RemoteCreate_Base();
		}	
		protected virtual void RemoteCreate_Base() 
		{
			if ( globals != null )
				globals.RemoteCreate();
			if ( gui != null )
				gui.RemoteCreate();
			if ( levels != null )
				levels.RemoteCreate();
		}
		
		public virtual void RemoteDestroy() 
		{
			if ( !IsRemoteUploaded )
				return;
				
			RemoteDestroy_Base();
		
			data.Remoting.DeleteObject( Game_Reflection.MetadataClass, this );
		
			isRemoteUploaded = false;
		}	
		protected virtual void RemoteDestroy_Base() 
		{
			if ( globals != null )
				globals.RemoteDestroy();
			if ( gui != null )
				gui.RemoteDestroy();
			if ( levels != null )
				levels.RemoteDestroy();
		}
		
		public virtual void RemoteUpload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUpload_Base();
		}	
		protected virtual void RemoteUpload_Base() 
		{
			data.Remoting.SetObject_Value( Game_Reflection.MetadataClass, this, Game_Member_globals.Member, globals );
			if ( globals != null )
				globals.RemoteUpload();
			data.Remoting.SetObject_Value( Game_Reflection.MetadataClass, this, Game_Member_gui.Member, gui );
			if ( gui != null )
				gui.RemoteUpload();
			data.Remoting.SetObject_Value( Game_Reflection.MetadataClass, this, Game_Member_levels.Member, levels );
			if ( levels != null )
				levels.RemoteUpload();
		}
		
		public virtual void RemoteUnload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUnload_Base();
		}	
		protected virtual void RemoteUnload_Base() 
		{
			if ( globals != null )
				globals.RemoteUnload();
			if ( gui != null )
				gui.RemoteUnload();
			if ( levels != null )
				levels.RemoteUnload();
		}
	}

} /* namespace game */ 
