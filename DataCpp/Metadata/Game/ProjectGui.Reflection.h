#ifndef Metadata_Game_ProjectGui_Reflection_h
#define Metadata_Game_ProjectGui_Reflection_h

// AUTOGENERATED FILE. MODIFY IT AT YOUR OWN RISK.

namespace gui { 

	// forward declarations
	class Gui;
	class GuiCommon;
	class GuiMainMenu;
	class GuiGame;
	class GuiFile;
	class GuiFilesCollection;
	
	// reflection classes
	
	class Gui_Reflection : public reflection::FolderClass
	{
	public:
		Gui_Reflection();
		
		void CopyObjectDataFromTo( Gui const & from, Gui & to );
		
		virtual core::ReferenceObject * New() const;
		virtual void Delete( core::ReferenceObject * pDataObject ) const;
	};

	class GuiCommon_Reflection : public reflection::FolderStorageClass
	{
	public:
		GuiCommon_Reflection();
		
		void CopyObjectDataFromTo( GuiCommon const & from, GuiCommon & to );
		
	};

	class GuiMainMenu_Reflection : public reflection::FolderStorageClass
	{
	public:
		GuiMainMenu_Reflection();
		
		void CopyObjectDataFromTo( GuiMainMenu const & from, GuiMainMenu & to );
		
	};

	class GuiGame_Reflection : public reflection::FolderStorageClass
	{
	public:
		GuiGame_Reflection();
		
		void CopyObjectDataFromTo( GuiGame const & from, GuiGame & to );
		
	};

	class GuiFile_Reflection : public reflection::FileClass
	{
	public:
		GuiFile_Reflection();
		
		void CopyObjectDataFromTo( GuiFile const & from, GuiFile & to );
		
	};

	class GuiFilesCollection_Reflection : public reflection::CollectionClass
	{
	public:
		GuiFilesCollection_Reflection();
		
		void CopyObjectDataFromTo( GuiFilesCollection const & from, GuiFilesCollection & to );
		
	};

} /* namespace gui */ 

#endif // Metadata_Game_ProjectGui_Reflection_h