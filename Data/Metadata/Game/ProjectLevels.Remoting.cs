using System;
using System.Collections.Generic;

namespace level { 

	public partial class Levels : core.IRemoteObject
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
			
			data.Remoting.NewObject( Levels_Reflection.MetadataClass, this );
			
			isRemoteUploaded = true;
			RemoteCreate_Base();
		}	
		protected virtual void RemoteCreate_Base() 
		{
			folders.RemoteCreate();
		}
		
		public virtual void RemoteDestroy() 
		{
			if ( !IsRemoteUploaded )
				return;
				
			RemoteDestroy_Base();
		
			data.Remoting.DeleteObject( Levels_Reflection.MetadataClass, this );
		
			isRemoteUploaded = false;
		}	
		protected virtual void RemoteDestroy_Base() 
		{
			folders.RemoteDestroy();
		}
		
		public virtual void RemoteUpload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUpload_Base();
		}	
		protected virtual void RemoteUpload_Base() 
		{
			data.Remoting.SetObject_Value( Levels_Reflection.MetadataClass, this, Levels_Member_name.Member, new string_Boxed { value = name } );
			folders.RemoteUpload();
			data.Remoting.SetObject_ParentReference( Levels_Reflection.MetadataClass, this, Levels_Member_parent.Member, parent );
		}
		
		public virtual void RemoteUnload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUnload_Base();
		}	
		protected virtual void RemoteUnload_Base() 
		{
			folders.RemoteUnload();
			data.Remoting.SetObject_ParentReference( Levels_Reflection.MetadataClass, this, Levels_Member_parent.Member, null );
		}
	}

	public partial class LevelFolder : core.IRemoteObject
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
			
			data.Remoting.NewObject( LevelFolder_Reflection.MetadataClass, this );
			
			isRemoteUploaded = true;
			RemoteCreate_Base();
		}	
		protected virtual void RemoteCreate_Base() 
		{
			dependencies.RemoteCreate();
			blocks.RemoteCreate();
		}
		
		public virtual void RemoteDestroy() 
		{
			if ( !IsRemoteUploaded )
				return;
				
			RemoteDestroy_Base();
		
			data.Remoting.DeleteObject( LevelFolder_Reflection.MetadataClass, this );
		
			isRemoteUploaded = false;
		}	
		protected virtual void RemoteDestroy_Base() 
		{
			dependencies.RemoteDestroy();
			blocks.RemoteDestroy();
		}
		
		public virtual void RemoteUpload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUpload_Base();
		}	
		protected virtual void RemoteUpload_Base() 
		{
			data.Remoting.SetObject_Value( LevelFolder_Reflection.MetadataClass, this, LevelFolder_Member_name.Member, new string_Boxed { value = name } );
			data.Remoting.SetObject_ParentReference( LevelFolder_Reflection.MetadataClass, this, LevelFolder_Member_parent.Member, parent );
			dependencies.RemoteUpload();
			blocks.RemoteUpload();
		}
		
		public virtual void RemoteUnload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUnload_Base();
		}	
		protected virtual void RemoteUnload_Base() 
		{
			data.Remoting.SetObject_ParentReference( LevelFolder_Reflection.MetadataClass, this, LevelFolder_Member_parent.Member, null );
			dependencies.RemoteUnload();
			blocks.RemoteUnload();
		}
	}

	public partial class LevelFoldersCollection : core.IRemoteObject
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
			foreach( level.LevelFolder remoteItem in this )
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
			foreach( level.LevelFolder remoteItem in this )
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
			foreach( level.LevelFolder remoteItem in this )
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
			foreach( level.LevelFolder remoteItem in this )
				remoteItem.RemoteUnload();
		}
	}

	public partial class LevelBlock : core.IRemoteObject
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
			
			data.Remoting.NewObject( LevelBlock_Reflection.MetadataClass, this );
			
			isRemoteUploaded = true;
			RemoteCreate_Base();
		}	
		protected virtual void RemoteCreate_Base() 
		{
			files.RemoteCreate();
		}
		
		public virtual void RemoteDestroy() 
		{
			if ( !IsRemoteUploaded )
				return;
				
			RemoteDestroy_Base();
		
			data.Remoting.DeleteObject( LevelBlock_Reflection.MetadataClass, this );
		
			isRemoteUploaded = false;
		}	
		protected virtual void RemoteDestroy_Base() 
		{
			files.RemoteDestroy();
		}
		
		public virtual void RemoteUpload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUpload_Base();
		}	
		protected virtual void RemoteUpload_Base() 
		{
			data.Remoting.SetObject_Value( LevelBlock_Reflection.MetadataClass, this, LevelBlock_Member_name.Member, new string_Boxed { value = name } );
			data.Remoting.SetObject_ParentReference( LevelBlock_Reflection.MetadataClass, this, LevelBlock_Member_parent.Member, parent );
			files.RemoteUpload();
		}
		
		public virtual void RemoteUnload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUnload_Base();
		}	
		protected virtual void RemoteUnload_Base() 
		{
			data.Remoting.SetObject_ParentReference( LevelBlock_Reflection.MetadataClass, this, LevelBlock_Member_parent.Member, null );
			files.RemoteUnload();
		}
	}

	public partial class LevelBlocksCollection : core.IRemoteObject
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
			foreach( level.LevelBlock remoteItem in this )
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
			foreach( level.LevelBlock remoteItem in this )
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
			foreach( level.LevelBlock remoteItem in this )
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
			foreach( level.LevelBlock remoteItem in this )
				remoteItem.RemoteUnload();
		}
	}

	public partial class LevelFile : core.IRemoteObject
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
			
			data.Remoting.NewObject( LevelFile_Reflection.MetadataClass, this );
			
			isRemoteUploaded = true;
			RemoteCreate_Base();
		}	
		protected virtual void RemoteCreate_Base() 
		{
			if ( scene != null )
				scene.RemoteCreate();
		}
		
		public virtual void RemoteDestroy() 
		{
			if ( !IsRemoteUploaded )
				return;
				
			RemoteDestroy_Base();
		
			data.Remoting.DeleteObject( LevelFile_Reflection.MetadataClass, this );
		
			isRemoteUploaded = false;
		}	
		protected virtual void RemoteDestroy_Base() 
		{
			if ( scene != null )
				scene.RemoteDestroy();
		}
		
		public virtual void RemoteUpload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUpload_Base();
		}	
		protected virtual void RemoteUpload_Base() 
		{
			data.Remoting.SetObject_ParentReference( LevelFile_Reflection.MetadataClass, this, LevelFile_Member_parent.Member, parent );
			data.Remoting.SetObject_FileStorage( LevelFile_Reflection.MetadataClass, this, LevelFile_Member_scene.Member, scene );
			if ( scene != null )	
				scene.RemoteUpload();
			data.Remoting.SetObject_Value( LevelFile_Reflection.MetadataClass, this, LevelFile_Member_name.Member, new string_Boxed { value = name } );
		}
		
		public virtual void RemoteUnload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUnload_Base();
		}	
		protected virtual void RemoteUnload_Base() 
		{
			data.Remoting.SetObject_ParentReference( LevelFile_Reflection.MetadataClass, this, LevelFile_Member_parent.Member, null );
			if ( scene != null )
				scene.RemoteUnload();
			data.Remoting.SetObject_FileStorage( LevelFile_Reflection.MetadataClass, this, LevelFile_Member_scene.Member, null );		
		}
	}

	public partial class LevelFilesCollection : core.IRemoteObject
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
			foreach( level.LevelFile remoteItem in this )
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
			foreach( level.LevelFile remoteItem in this )
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
			foreach( level.LevelFile remoteItem in this )
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
			foreach( level.LevelFile remoteItem in this )
				remoteItem.RemoteUnload();
		}
	}

	public partial class Dependency : core.IRemoteObject
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
			
			data.Remoting.NewObject( Dependency_Reflection.MetadataClass, this );
			
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
		
			data.Remoting.DeleteObject( Dependency_Reflection.MetadataClass, this );
		
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
			data.Remoting.SetObject_Reference( Dependency_Reflection.MetadataClass, this, Dependency_Member_LevelFolder.Member, LevelFolder );
		}
		
		public virtual void RemoteUnload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUnload_Base();
		}	
		protected virtual void RemoteUnload_Base() 
		{
			data.Remoting.SetObject_Reference( Dependency_Reflection.MetadataClass, this, Dependency_Member_LevelFolder.Member, null );
		}
	}

	public partial class Dependencies : core.IRemoteObject
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
			foreach( level.Dependency remoteItem in this )
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
			foreach( level.Dependency remoteItem in this )
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
			foreach( level.Dependency remoteItem in this )
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
			foreach( level.Dependency remoteItem in this )
				remoteItem.RemoteUnload();
		}
	}

} /* namespace level */ 
