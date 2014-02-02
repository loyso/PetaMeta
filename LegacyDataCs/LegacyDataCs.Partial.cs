using System;
using System.Collections.Generic;

namespace level 
{ 
	public partial class LevelFolder
	{
		public bool DependsOn( core.IFolderStorageObject folderStorageObject )
		{
			return false;
		}
	}
}

namespace gui 
{ 
	public partial class GuiCommon
	{
		public bool DependsOn( core.IFolderStorageObject folderStorageObject )
		{
			return false;
		}
	}
}
