
#ifndef Metadata_Game_ProjectGui_h
#define Metadata_Game_ProjectGui_h

#include "ProjectGui.Partial.h"

namespace gui { 

			
class GuiCommon : public core::ReferenceObject
	, public GuiCommon_Partial
{
};

			
class GuiMainMenu : public GuiCommon
	, public GuiMainMenu_Partial
{
};

			
class GuiGame : public GuiCommon
	, public GuiGame_Partial
{
};

			
class Gui : public core::ReferenceObject
	, public Gui_Partial
{
};

			
class GuiFile : public core::ReferenceObject
	, public GuiFile_Partial
{
};

} /* namespace gui */ 

#endif // Metadata_Game_ProjectGui_h
