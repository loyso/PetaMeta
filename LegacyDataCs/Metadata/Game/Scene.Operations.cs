using System;
using System.Collections.Generic;

namespace scene { 

	public partial class SceneObject : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			if ( position != null )
				if ( position.ContainsObject( objectReference ) )
					return true;
			if ( color != null )
				if ( color.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			if ( position != null )
				position.ObjectDeleted( dataObject );
			if ( color != null )
				color.ObjectDeleted( dataObject );
			if ( (dataObject as core.IOperations).ContainsObject( next ) )
				next = null;
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is scene.SceneObject) )
				return;
			
			scene.SceneObject from = fromObject as scene.SceneObject;
			this.Guid = from.Guid;
			this.parent = from.parent;
			position.CopyObjectDataFrom( from.position );
			this.scale = from.scale;
			color.CopyObjectDataFrom( from.color );
			this.lod = from.lod;
			this.visible = from.visible;
			this.next = from.next;
			this.isSoundEnabled = from.isSoundEnabled;
			this.isSfxEnabled = from.isSfxEnabled;
		}
		
		public virtual void NewGuids()
		{
			this.Guid = Guid.NewGuid();
			if ( position != null )
				position.NewGuids();
			if ( color != null )
				color.NewGuids();
		}
		
		public virtual void NewNames()
		{
			if ( position != null )
				position.NewNames();
			if ( color != null )
				color.NewNames();
		}
	}

	public partial class SceneObjectsCollection : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			foreach( scene.SceneObject item in this )
				if ( item.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			foreach( scene.SceneObject remoteItem in this )
				remoteItem.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is scene.SceneObjectsCollection) )
				return;
			
			scene.SceneObjectsCollection from = fromObject as scene.SceneObjectsCollection;
		}
		
		public virtual void NewGuids()
		{
			foreach( scene.SceneObject item in this )
				item.NewGuids();
		}
		
		public virtual void NewNames()
		{
			foreach( scene.SceneObject item in this )
				item.NewNames();
		}
	}

	public partial class SceneMesh
	{
		public override bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( base.ContainsObject( objectReference ) )
				return true;
			
			if ( colorSnd != null )
				if ( colorSnd.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public override void ObjectDeleted( core.DataObject dataObject ) 
		{
			base.ObjectDeleted( dataObject );
			
			if ( colorSnd != null )
				colorSnd.ObjectDeleted( dataObject );
		}
		
		public override void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected override void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			base.CopyObjectDataFrom_Base( fromObject );
			
			if ( !(fromObject is scene.SceneMesh) )
				return;
			
			scene.SceneMesh from = fromObject as scene.SceneMesh;
			this.Guid = from.Guid;
			colorSnd.CopyObjectDataFrom( from.colorSnd );
		}
		
		public override void NewGuids()
		{
			base.NewGuids();
			
			if ( colorSnd != null )
				colorSnd.NewGuids();
		}
		
		public override void NewNames()
		{
			base.NewNames();
			
			if ( colorSnd != null )
				colorSnd.NewNames();
		}
	}

	public partial class SceneAnimMesh
	{
		public override bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( base.ContainsObject( objectReference ) )
				return true;
			
			if ( positionSfx != null )
				if ( positionSfx.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public override void ObjectDeleted( core.DataObject dataObject ) 
		{
			base.ObjectDeleted( dataObject );
			
			if ( positionSfx != null )
				positionSfx.ObjectDeleted( dataObject );
		}
		
		public override void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected override void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			base.CopyObjectDataFrom_Base( fromObject );
			
			if ( !(fromObject is scene.SceneAnimMesh) )
				return;
			
			scene.SceneAnimMesh from = fromObject as scene.SceneAnimMesh;
			this.Guid = from.Guid;
			positionSfx.CopyObjectDataFrom( from.positionSfx );
		}
		
		public override void NewGuids()
		{
			base.NewGuids();
			
			if ( positionSfx != null )
				positionSfx.NewGuids();
		}
		
		public override void NewNames()
		{
			base.NewNames();
			
			if ( positionSfx != null )
				positionSfx.NewNames();
		}
	}

	public partial class SceneZoneTrigger
	{
		public override bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( base.ContainsObject( objectReference ) )
				return true;
			
			if ( ctrl != null )
				if ( ctrl.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public override void ObjectDeleted( core.DataObject dataObject ) 
		{
			base.ObjectDeleted( dataObject );
			
			if ( ctrl != null )
				ctrl.ObjectDeleted( dataObject );
		}
		
		public override void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected override void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			base.CopyObjectDataFrom_Base( fromObject );
			
			if ( !(fromObject is scene.SceneZoneTrigger) )
				return;
			
			scene.SceneZoneTrigger from = fromObject as scene.SceneZoneTrigger;
			this.Guid = from.Guid;
			this.name = from.name;
			this.triggerType = from.triggerType;
			ctrl.CopyObjectDataFrom( from.ctrl );
		}
		
		public override void NewGuids()
		{
			base.NewGuids();
			
			if ( ctrl != null )
				ctrl.NewGuids();
		}
		
		public override void NewNames()
		{
			base.NewNames();
			
			this.name = "Trigger";
			if ( ctrl != null )
				ctrl.NewNames();
		}
	}

	public partial class Scene : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			if ( mainObject != null )
				if ( mainObject.ContainsObject( objectReference ) )
					return true;
			if ( objects.ContainsObject( objectReference ) )
				return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			if ( mainObject != null )
				mainObject.ObjectDeleted( dataObject );
			objects.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is scene.Scene) )
				return;
			
			scene.Scene from = fromObject as scene.Scene;
			this.Guid = from.Guid;
			mainObject.CopyObjectDataFrom( from.mainObject );
		}
		
		public virtual void NewGuids()
		{
			this.Guid = Guid.NewGuid();
			if ( mainObject != null )
				mainObject.NewGuids();
			objects.NewGuids();
		}
		
		public virtual void NewNames()
		{
			if ( mainObject != null )
				mainObject.NewNames();
			objects.NewNames();
		}
	}

	public abstract partial class Controller : core.IOperations
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
			if ( !(fromObject is scene.Controller) )
				return;
			
			scene.Controller from = fromObject as scene.Controller;
			this.Guid = from.Guid;
			this.priority = from.priority;
		}
		
		public virtual void NewGuids()
		{
			this.Guid = Guid.NewGuid();
		}
		
		public virtual void NewNames()
		{
		}
	}

	public partial class ControllerBox
	{
		public override bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( base.ContainsObject( objectReference ) )
				return true;
			
			if ( size != null )
				if ( size.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public override void ObjectDeleted( core.DataObject dataObject ) 
		{
			base.ObjectDeleted( dataObject );
			
			if ( size != null )
				size.ObjectDeleted( dataObject );
		}
		
		public override void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected override void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			base.CopyObjectDataFrom_Base( fromObject );
			
			if ( !(fromObject is scene.ControllerBox) )
				return;
			
			scene.ControllerBox from = fromObject as scene.ControllerBox;
			this.Guid = from.Guid;
			size.CopyObjectDataFrom( from.size );
		}
		
		public override void NewGuids()
		{
			base.NewGuids();
			
			if ( size != null )
				size.NewGuids();
		}
		
		public override void NewNames()
		{
			base.NewNames();
			
			if ( size != null )
				size.NewNames();
		}
	}

	public partial class ControllerSphere
	{
		public override bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( base.ContainsObject( objectReference ) )
				return true;
			
			
			return false;
		}
		
		public override void ObjectDeleted( core.DataObject dataObject ) 
		{
			base.ObjectDeleted( dataObject );
			
		}
		
		public override void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected override void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			base.CopyObjectDataFrom_Base( fromObject );
			
			if ( !(fromObject is scene.ControllerSphere) )
				return;
			
			scene.ControllerSphere from = fromObject as scene.ControllerSphere;
			this.Guid = from.Guid;
			this.radius = from.radius;
		}
		
		public override void NewGuids()
		{
			base.NewGuids();
			
		}
		
		public override void NewNames()
		{
			base.NewNames();
			
		}
	}

} /* namespace scene */ 
