using System;
using System.Collections.Generic;

namespace scene { 

	public partial class SceneObject : core.IRemoteObject
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
			
			data.Remoting.NewObject( SceneObject_Reflection.MetadataClass, this );
			
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
		
			data.Remoting.DeleteObject( SceneObject_Reflection.MetadataClass, this );
		
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
			data.Remoting.SetObject_ParentReference( SceneObject_Reflection.MetadataClass, this, SceneObject_Member_parent.Member, parent );
			data.Remoting.SetObject_Value( SceneObject_Reflection.MetadataClass, this, SceneObject_Member_position.Member, position );
			data.Remoting.SetObject_Value( SceneObject_Reflection.MetadataClass, this, SceneObject_Member_scale.Member, new float_Boxed { value = scale } );
			data.Remoting.SetObject_Value( SceneObject_Reflection.MetadataClass, this, SceneObject_Member_color.Member, color );
			data.Remoting.SetObject_Value( SceneObject_Reflection.MetadataClass, this, SceneObject_Member_lod.Member, new int_Boxed { value = lod } );
			data.Remoting.SetObject_Value( SceneObject_Reflection.MetadataClass, this, SceneObject_Member_visible.Member, new bool_Boxed { value = visible } );
			data.Remoting.SetObject_Reference( SceneObject_Reflection.MetadataClass, this, SceneObject_Member_next.Member, next );
			data.Remoting.SetObject_Value( SceneObject_Reflection.MetadataClass, this, SceneObject_Member_isSoundEnabled.Member, new bool_Boxed { value = isSoundEnabled } );
			data.Remoting.SetObject_Value( SceneObject_Reflection.MetadataClass, this, SceneObject_Member_isSfxEnabled.Member, new bool_Boxed { value = isSfxEnabled } );
		}
		
		public virtual void RemoteUnload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUnload_Base();
		}	
		protected virtual void RemoteUnload_Base() 
		{
			data.Remoting.SetObject_ParentReference( SceneObject_Reflection.MetadataClass, this, SceneObject_Member_parent.Member, null );
			data.Remoting.SetObject_Reference( SceneObject_Reflection.MetadataClass, this, SceneObject_Member_next.Member, null );
		}
	}

	public partial class SceneObjectsCollection : core.IRemoteObject
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
			foreach( scene.SceneObject remoteItem in this )
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
			foreach( scene.SceneObject remoteItem in this )
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
			foreach( scene.SceneObject remoteItem in this )
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
			foreach( scene.SceneObject remoteItem in this )
				remoteItem.RemoteUnload();
		}
	}

	public partial class SceneMesh
	{
		public override void RemoteCreate() 
		{
			if ( IsRemoteUploaded )
				return;
			
			data.Remoting.NewObject( SceneMesh_Reflection.MetadataClass, this );
			
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
		
			data.Remoting.DeleteObject( SceneMesh_Reflection.MetadataClass, this );
		
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
			
			data.Remoting.SetObject_Value( SceneMesh_Reflection.MetadataClass, this, SceneMesh_Member_colorSnd.Member, colorSnd );
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

	public partial class SceneAnimMesh
	{
		public override void RemoteCreate() 
		{
			if ( IsRemoteUploaded )
				return;
			
			data.Remoting.NewObject( SceneAnimMesh_Reflection.MetadataClass, this );
			
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
		
			data.Remoting.DeleteObject( SceneAnimMesh_Reflection.MetadataClass, this );
		
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
			
			data.Remoting.SetObject_Value( SceneAnimMesh_Reflection.MetadataClass, this, SceneAnimMesh_Member_positionSfx.Member, positionSfx );
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

	public partial class SceneZoneTrigger
	{
		public override void RemoteCreate() 
		{
			if ( IsRemoteUploaded )
				return;
			
			data.Remoting.NewObject( SceneZoneTrigger_Reflection.MetadataClass, this );
			
			isRemoteUploaded = true;
			RemoteCreate_Base();
		}	
		protected override void RemoteCreate_Base() 
		{
			base.RemoteCreate_Base();
			
			if ( ctrl != null )
				ctrl.RemoteCreate();
		}
		
		public override void RemoteDestroy() 
		{
			if ( !IsRemoteUploaded )
				return;
				
			RemoteDestroy_Base();
		
			data.Remoting.DeleteObject( SceneZoneTrigger_Reflection.MetadataClass, this );
		
			isRemoteUploaded = false;
		}	
		protected override void RemoteDestroy_Base() 
		{
			base.RemoteDestroy_Base();
			
			if ( ctrl != null )
				ctrl.RemoteDestroy();
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
			
			data.Remoting.SetObject_Value( SceneZoneTrigger_Reflection.MetadataClass, this, SceneZoneTrigger_Member_name.Member, new string_Boxed { value = name } );
			data.Remoting.SetObject_Value( SceneZoneTrigger_Reflection.MetadataClass, this, SceneZoneTrigger_Member_triggerType.Member, new scene.TriggerType_Boxed { value = triggerType } );
			data.Remoting.SetObject_Value( SceneZoneTrigger_Reflection.MetadataClass, this, SceneZoneTrigger_Member_ctrl.Member, ctrl );
			if ( ctrl != null )
				ctrl.RemoteUpload();
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
			
			if ( ctrl != null )
				ctrl.RemoteUnload();
		}
	}

	public partial class Scene : core.IRemoteObject
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
			
			data.Remoting.NewObject( Scene_Reflection.MetadataClass, this );
			
			isRemoteUploaded = true;
			RemoteCreate_Base();
		}	
		protected virtual void RemoteCreate_Base() 
		{
			if ( mainObject != null )
				mainObject.RemoteCreate();
			objects.RemoteCreate();
		}
		
		public virtual void RemoteDestroy() 
		{
			if ( !IsRemoteUploaded )
				return;
				
			RemoteDestroy_Base();
		
			data.Remoting.DeleteObject( Scene_Reflection.MetadataClass, this );
		
			isRemoteUploaded = false;
		}	
		protected virtual void RemoteDestroy_Base() 
		{
			if ( mainObject != null )
				mainObject.RemoteDestroy();
			objects.RemoteDestroy();
		}
		
		public virtual void RemoteUpload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUpload_Base();
		}	
		protected virtual void RemoteUpload_Base() 
		{
			data.Remoting.SetObject_Value( Scene_Reflection.MetadataClass, this, Scene_Member_mainObject.Member, mainObject );
			if ( mainObject != null )
				mainObject.RemoteUpload();
			objects.RemoteUpload();
		}
		
		public virtual void RemoteUnload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUnload_Base();
		}	
		protected virtual void RemoteUnload_Base() 
		{
			if ( mainObject != null )
				mainObject.RemoteUnload();
			objects.RemoteUnload();
		}
	}

	public abstract partial class Controller : core.IRemoteObject
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
			
			data.Remoting.NewObject( Controller_Reflection.MetadataClass, this );
			
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
		
			data.Remoting.DeleteObject( Controller_Reflection.MetadataClass, this );
		
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
			data.Remoting.SetObject_Value( Controller_Reflection.MetadataClass, this, Controller_Member_priority.Member, new int_Boxed { value = priority } );
		}
		
		public virtual void RemoteUnload() 
		{
			if ( !IsRemoteUploaded )
				return;
			RemoteUnload_Base();
		}	
		protected virtual void RemoteUnload_Base() 
		{
		}
	}

	public partial class ControllerBox
	{
		public override void RemoteCreate() 
		{
			if ( IsRemoteUploaded )
				return;
			
			data.Remoting.NewObject( ControllerBox_Reflection.MetadataClass, this );
			
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
		
			data.Remoting.DeleteObject( ControllerBox_Reflection.MetadataClass, this );
		
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
			
			data.Remoting.SetObject_Value( ControllerBox_Reflection.MetadataClass, this, ControllerBox_Member_size.Member, size );
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

	public partial class ControllerSphere
	{
		public override void RemoteCreate() 
		{
			if ( IsRemoteUploaded )
				return;
			
			data.Remoting.NewObject( ControllerSphere_Reflection.MetadataClass, this );
			
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
		
			data.Remoting.DeleteObject( ControllerSphere_Reflection.MetadataClass, this );
		
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
			
			data.Remoting.SetObject_Value( ControllerSphere_Reflection.MetadataClass, this, ControllerSphere_Member_radius.Member, new float_Boxed { value = radius } );
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

} /* namespace scene */ 
