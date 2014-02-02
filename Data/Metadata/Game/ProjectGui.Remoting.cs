using System;
using System.Collections.Generic;

namespace gui { 

	public partial class Gui : core.IRemoteObject
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
			
			data.Remoting.NewObject( Gui_Reflection.MetadataClass, this );
			
			isRemoteUploaded = true;
			RemoteCreate_Base();
		}	
		protected virtual void RemoteCreate_Base() 
		{
			if ( mainMenu != null )
				mainMenu.RemoteCreate();
			if ( game != null )
				game.RemoteCreate();
		}
		
		public virtual void RemoteDestroy() 
		{
			if ( !IsRemoteUploaded )
				return;
				
			RemoteDestroy_Base();
		
			data.Remoting.DeleteObject( Gui_Reflection.MetadataClass, this );
		
			isRemoteUploaded = false;
		}	
		protected virtual void RemoteDestroy_Base() 
		{
			if ( mainMenu != null )
				mainMenu.RemoteDestroy();
			if ( game != null )
				game.RemoteDestroy();
		}
		
		public virtual void RemoteUpload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUpload_Base();
		}	
		protected virtual void RemoteUpload_Base() 
		{
			data.Remoting.SetObject_Value( Gui_Reflection.MetadataClass, this, Gui_Member_name.Member, new string_Boxed { value = name } );
			data.Remoting.SetObject_Value( Gui_Reflection.MetadataClass, this, Gui_Member_mainMenu.Member, mainMenu );
			if ( mainMenu != null )
				mainMenu.RemoteUpload();
			data.Remoting.SetObject_Value( Gui_Reflection.MetadataClass, this, Gui_Member_game.Member, game );
			if ( game != null )
				game.RemoteUpload();
			data.Remoting.SetObject_ParentReference( Gui_Reflection.MetadataClass, this, Gui_Member_parent.Member, parent );
		}
		
		public virtual void RemoteUnload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUnload_Base();
		}	
		protected virtual void RemoteUnload_Base() 
		{
			if ( mainMenu != null )
				mainMenu.RemoteUnload();
			if ( game != null )
				game.RemoteUnload();
			data.Remoting.SetObject_ParentReference( Gui_Reflection.MetadataClass, this, Gui_Member_parent.Member, null );
		}
	}

	public partial class GuiCommon : core.IRemoteObject
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
			
			data.Remoting.NewObject( GuiCommon_Reflection.MetadataClass, this );
			
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
		
			data.Remoting.DeleteObject( GuiCommon_Reflection.MetadataClass, this );
		
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
			data.Remoting.SetObject_Value( GuiCommon_Reflection.MetadataClass, this, GuiCommon_Member_name.Member, new string_Boxed { value = name } );
			files.RemoteUpload();
			data.Remoting.SetObject_ParentReference( GuiCommon_Reflection.MetadataClass, this, GuiCommon_Member_parent.Member, parent );
		}
		
		public virtual void RemoteUnload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUnload_Base();
		}	
		protected virtual void RemoteUnload_Base() 
		{
			files.RemoteUnload();
			data.Remoting.SetObject_ParentReference( GuiCommon_Reflection.MetadataClass, this, GuiCommon_Member_parent.Member, null );
		}
	}

	public partial class GuiMainMenu
	{
		public override void RemoteCreate() 
		{
			if ( IsRemoteUploaded )
				return;
			
			data.Remoting.NewObject( GuiMainMenu_Reflection.MetadataClass, this );
			
			isRemoteUploaded = true;
			RemoteCreate_Base();
		}	
		protected override void RemoteCreate_Base() 
		{
			base.RemoteCreate_Base();
			
		}
		
		public override void RemoteDestroy() 
		{
			if ( !IsRemoteUploaded )
				return;
				
			RemoteDestroy_Base();
		
			data.Remoting.DeleteObject( GuiMainMenu_Reflection.MetadataClass, this );
		
			isRemoteUploaded = false;
		}	
		protected override void RemoteDestroy_Base() 
		{
			base.RemoteDestroy_Base();
			
		}
		
		public override void RemoteUpload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUpload_Base();
		}	
		protected override void RemoteUpload_Base() 
		{
			base.RemoteUpload_Base();
			
		}
		
		public override void RemoteUnload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUnload_Base();
		}	
		protected override void RemoteUnload_Base() 
		{
			base.RemoteUnload_Base();
			
		}
	}

	public partial class GuiGame
	{
		public override void RemoteCreate() 
		{
			if ( IsRemoteUploaded )
				return;
			
			data.Remoting.NewObject( GuiGame_Reflection.MetadataClass, this );
			
			isRemoteUploaded = true;
			RemoteCreate_Base();
		}	
		protected override void RemoteCreate_Base() 
		{
			base.RemoteCreate_Base();
			
		}
		
		public override void RemoteDestroy() 
		{
			if ( !IsRemoteUploaded )
				return;
				
			RemoteDestroy_Base();
		
			data.Remoting.DeleteObject( GuiGame_Reflection.MetadataClass, this );
		
			isRemoteUploaded = false;
		}	
		protected override void RemoteDestroy_Base() 
		{
			base.RemoteDestroy_Base();
			
		}
		
		public override void RemoteUpload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUpload_Base();
		}	
		protected override void RemoteUpload_Base() 
		{
			base.RemoteUpload_Base();
			
		}
		
		public override void RemoteUnload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUnload_Base();
		}	
		protected override void RemoteUnload_Base() 
		{
			base.RemoteUnload_Base();
			
		}
	}

	public partial class GuiFile : core.IRemoteObject
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
			
			data.Remoting.NewObject( GuiFile_Reflection.MetadataClass, this );
			
			isRemoteUploaded = true;
			RemoteCreate_Base();
		}	
		protected virtual void RemoteCreate_Base() 
		{
			if ( mainWindow != null )
				mainWindow.RemoteCreate();
		}
		
		public virtual void RemoteDestroy() 
		{
			if ( !IsRemoteUploaded )
				return;
				
			RemoteDestroy_Base();
		
			data.Remoting.DeleteObject( GuiFile_Reflection.MetadataClass, this );
		
			isRemoteUploaded = false;
		}	
		protected virtual void RemoteDestroy_Base() 
		{
			if ( mainWindow != null )
				mainWindow.RemoteDestroy();
		}
		
		public virtual void RemoteUpload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUpload_Base();
		}	
		protected virtual void RemoteUpload_Base() 
		{
			data.Remoting.SetObject_FileStorage( GuiFile_Reflection.MetadataClass, this, GuiFile_Member_mainWindow.Member, mainWindow );
			if ( mainWindow != null )	
				mainWindow.RemoteUpload();
			data.Remoting.SetObject_ParentReference( GuiFile_Reflection.MetadataClass, this, GuiFile_Member_parent.Member, parent );
			data.Remoting.SetObject_Value( GuiFile_Reflection.MetadataClass, this, GuiFile_Member_name.Member, new string_Boxed { value = name } );
		}
		
		public virtual void RemoteUnload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUnload_Base();
		}	
		protected virtual void RemoteUnload_Base() 
		{
			if ( mainWindow != null )
				mainWindow.RemoteUnload();
			data.Remoting.SetObject_FileStorage( GuiFile_Reflection.MetadataClass, this, GuiFile_Member_mainWindow.Member, null );		
			data.Remoting.SetObject_ParentReference( GuiFile_Reflection.MetadataClass, this, GuiFile_Member_parent.Member, null );
		}
	}

	public partial class GuiFilesCollection : core.IRemoteObject
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
			foreach( gui.GuiFile remoteItem in this )
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
			foreach( gui.GuiFile remoteItem in this )
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
			foreach( gui.GuiFile remoteItem in this )
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
			foreach( gui.GuiFile remoteItem in this )
				remoteItem.RemoteUnload();
		}
	}

} /* namespace gui */ 
