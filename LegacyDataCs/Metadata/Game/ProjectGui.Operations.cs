using System;
using System.Collections.Generic;

namespace gui { 

	public partial class Gui : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			if ( mainMenu != null )
				if ( mainMenu.ContainsObject( objectReference ) )
					return true;
			if ( game != null )
				if ( game.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			if ( mainMenu != null )
				mainMenu.ObjectDeleted( dataObject );
			if ( game != null )
				game.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is gui.Gui) )
				return;
			
			gui.Gui from = fromObject as gui.Gui;
			this.Guid = from.Guid;
			this.name = from.name;
			mainMenu.CopyObjectDataFrom( from.mainMenu );
			game.CopyObjectDataFrom( from.game );
			this.parent = from.parent;
		}
		
		public virtual void NewGuids()
		{
			this.Guid = Guid.NewGuid();
			if ( mainMenu != null )
				mainMenu.NewGuids();
			if ( game != null )
				game.NewGuids();
		}
		
		public virtual void NewNames()
		{
			this.name = "Gui";
			if ( mainMenu != null )
				mainMenu.NewNames();
			if ( game != null )
				game.NewNames();
		}
	}

	public partial class GuiCommon : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			if ( files.ContainsObject( objectReference ) )
				return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			files.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is gui.GuiCommon) )
				return;
			
			gui.GuiCommon from = fromObject as gui.GuiCommon;
			this.Guid = from.Guid;
			this.name = from.name;
			this.parent = from.parent;
		}
		
		public virtual void NewGuids()
		{
			this.Guid = Guid.NewGuid();
			files.NewGuids();
		}
		
		public virtual void NewNames()
		{
			this.name = "Common";
			files.NewNames();
		}
	}

	public partial class GuiMainMenu
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
			
			if ( !(fromObject is gui.GuiMainMenu) )
				return;
			
			gui.GuiMainMenu from = fromObject as gui.GuiMainMenu;
			this.Guid = from.Guid;
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

	public partial class GuiGame
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
			
			if ( !(fromObject is gui.GuiGame) )
				return;
			
			gui.GuiGame from = fromObject as gui.GuiGame;
			this.Guid = from.Guid;
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

	public partial class GuiFile : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			if ( mainWindow != null )
				if ( mainWindow.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			if ( mainWindow != null )
				mainWindow.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is gui.GuiFile) )
				return;
			
			gui.GuiFile from = fromObject as gui.GuiFile;
			this.Guid = from.Guid;
			this.parent = from.parent;
			this.name = from.name;
		}
		
		public virtual void NewGuids()
		{
			this.Guid = Guid.NewGuid();
			if ( mainWindow != null )
				mainWindow.NewGuids();
		}
		
		public virtual void NewNames()
		{
			this.name = "File";
			if ( mainWindow != null )
				mainWindow.NewNames();
		}
	}

	public partial class GuiFilesCollection : core.IOperations
	{
		void core.IOperations.NewNames()		{ NewNames(); }
		void core.IOperations.NewGuids()		{ NewGuids(); }
		bool core.IOperations.ContainsObject( core.DataObject objectReference )	{ return ContainsObject( objectReference ); }
		void core.IOperations.ObjectDeleted( core.DataObject dataObject )		{ ObjectDeleted( dataObject ); }
		
		public virtual bool ContainsObject( core.DataObject objectReference ) 
		{
			if ( objectReference == this )
				return true;
		
			foreach( gui.GuiFile item in this )
				if ( item.ContainsObject( objectReference ) )
					return true;
			
			return false;
		}
		
		public virtual void ObjectDeleted( core.DataObject dataObject ) 
		{
			foreach( gui.GuiFile remoteItem in this )
				remoteItem.ObjectDeleted( dataObject );
		}
		
		public virtual void CopyObjectDataFrom( core.DataObject fromObject ) 
		{
			CopyObjectDataFrom_Base( fromObject );
		}	
		protected virtual void CopyObjectDataFrom_Base( core.DataObject fromObject ) 
		{
			if ( !(fromObject is gui.GuiFilesCollection) )
				return;
			
			gui.GuiFilesCollection from = fromObject as gui.GuiFilesCollection;
		}
		
		public virtual void NewGuids()
		{
			foreach( gui.GuiFile item in this )
				item.NewGuids();
		}
		
		public virtual void NewNames()
		{
			foreach( gui.GuiFile item in this )
				item.NewNames();
		}
	}

} /* namespace gui */ 
