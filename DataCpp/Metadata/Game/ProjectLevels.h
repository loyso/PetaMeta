
#ifndef Metadata_Game_ProjectLevels_h
#define Metadata_Game_ProjectLevels_h

#include "ProjectLevels.Partial.h"

namespace level { 

			
class Levels : public core::ReferenceObject
	, public Levels_Partial
{
};

			
class LevelFolder : public core::ReferenceObject
	, public LevelFolder_Partial
{
};

			
class LevelBlock : public core::ReferenceObject
	, public LevelBlock_Partial
{
};

			
class LevelFile : public core::ReferenceObject
	, public LevelFile_Partial
{
};

			
class Dependency : public core::ReferenceObject
	, public Dependency_Partial
{
};

} /* namespace level */ 

#endif // Metadata_Game_ProjectLevels_h
