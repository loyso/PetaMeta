
// AUTOGENERATED FILE. MODIFY IT AT YOUR OWN RISK.

#ifndef Metadata_Game_Gui_Partial_h
#define Metadata_Game_Gui_Partial_h

#include "..\..\Core.h"

// forward declarations from other files

namespace gui { 
	class GuiFile; class GuiFile_Partial;
}

// dependencies

#include "..\Engine\Fundamental.h"

// forward declarations

namespace gui { 
	class Window; class Window_Partial;
	class WindowsCollection; class WindowsCollection_Partial;
}

namespace gui { 

	// classes
	
	namespace WindowsCollection_ByteStream
	{
		bool ObjectFromByteStream( core::ByteStreamReader & stream, gui::WindowsCollection & dataObject );
	};

	class WindowsCollection_Partial : public core::CollectionOf < gui::Window * >
	{
	public:
		WindowsCollection_Partial();
		~WindowsCollection_Partial();
	};

	namespace Window_ByteStream
	{
		bool ObjectFromByteStream( core::ByteStreamReader & stream, gui::Window & dataObject );
	};

	class Window_Partial
	{
	public:
		Window_Partial();
		~Window_Partial();

		gui::WindowsCollection_Partial & Get_children();
		gui::WindowsCollection_Partial const & Get_children() const;
		
		Vec2 const & Get_position() const;
		void Set_position( Vec2 const & value );
		
		Vec2 const & Get_size() const;
		void Set_size( Vec2 const & value );
		
		gui::Window * Get_parent() const;
		void Set_parent( gui::Window * value );
		
		gui::GuiFile * Get_parentFile() const;
		void Set_parentFile( gui::GuiFile * value );
		
		string Get_name() const;
		void Set_name( string value );
		
	private:
		gui::WindowsCollection_Partial children;
		Vec2 position;
		Vec2 size;
		gui::Window * parent;
		gui::GuiFile * parentFile;
		string name;
	};

} /* namespace gui */ 

#endif // Metadata_Game_Gui_Partial_h