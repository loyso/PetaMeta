
// AUTOGENERATED FILE. MODIFY IT AT YOUR OWN RISK.

#include "ProjectLevels.h"

namespace level { 

bool Levels_ByteStream::ObjectFromByteStream( core::ByteStreamReader & stream, level::Levels & dataObject )
{
	core::uint32 name_Size; if ( !stream.ReadSize( name_Size ) ) return false;
	void const * name_Bytes; if ( !stream.ReadBytes( name_Size, name_Bytes ) ) return false;
	string name ( (char*)name_Bytes, name_Size );
	dataObject.Set_name ( name );
	
	return true;
}


Levels_Partial::Levels_Partial()
	: name("Levels")
	, folders()
	, parent()
{
}

Levels_Partial::~Levels_Partial()
{
	for ( level::LevelFoldersCollection_Partial::Iterator i = folders.Begin(), e = folders.End(); i != e; ++i )
		CORE_DELETE *i;
	folders.Clear();
	parent = NULL;
}

string Levels_Partial::Get_name() const 
{ 
	return name; 
}
void Levels_Partial::Set_name( string value ) 
{ 
	name = value; 
}

level::LevelFoldersCollection_Partial & Levels_Partial::Get_folders() 
{ 
	return folders; 
}
level::LevelFoldersCollection_Partial const & Levels_Partial::Get_folders() const 
{ 
	return folders; 
}

game::Game * Levels_Partial::Get_parent() const 
{ 
	return parent; 
}
void Levels_Partial::Set_parent( game::Game * value ) 
{ 
	parent = value; 
}


bool LevelFolder_ByteStream::ObjectFromByteStream( core::ByteStreamReader & stream, level::LevelFolder & dataObject )
{
	core::uint32 name_Size; if ( !stream.ReadSize( name_Size ) ) return false;
	void const * name_Bytes; if ( !stream.ReadBytes( name_Size, name_Bytes ) ) return false;
	string name ( (char*)name_Bytes, name_Size );
	dataObject.Set_name ( name );
	
	return true;
}


LevelFolder_Partial::LevelFolder_Partial()
	: name("Level")
	, parent()
	, dependencies()
	, blocks()
{
}

LevelFolder_Partial::~LevelFolder_Partial()
{
	parent = NULL;
	for ( level::Dependencies_Partial::Iterator i = dependencies.Begin(), e = dependencies.End(); i != e; ++i )
		CORE_DELETE *i;
	dependencies.Clear();
	for ( level::LevelBlocksCollection_Partial::Iterator i = blocks.Begin(), e = blocks.End(); i != e; ++i )
		CORE_DELETE *i;
	blocks.Clear();
}

string LevelFolder_Partial::Get_name() const 
{ 
	return name; 
}
void LevelFolder_Partial::Set_name( string value ) 
{ 
	name = value; 
}

level::Levels * LevelFolder_Partial::Get_parent() const 
{ 
	return parent; 
}
void LevelFolder_Partial::Set_parent( level::Levels * value ) 
{ 
	parent = value; 
}

level::Dependencies_Partial & LevelFolder_Partial::Get_dependencies() 
{ 
	return dependencies; 
}
level::Dependencies_Partial const & LevelFolder_Partial::Get_dependencies() const 
{ 
	return dependencies; 
}

level::LevelBlocksCollection_Partial & LevelFolder_Partial::Get_blocks() 
{ 
	return blocks; 
}
level::LevelBlocksCollection_Partial const & LevelFolder_Partial::Get_blocks() const 
{ 
	return blocks; 
}


bool LevelFoldersCollection_ByteStream::ObjectFromByteStream( core::ByteStreamReader & stream, level::LevelFoldersCollection & dataObject )
{
	return true;
}


LevelFoldersCollection_Partial::LevelFoldersCollection_Partial()
{
}

LevelFoldersCollection_Partial::~LevelFoldersCollection_Partial()
{
}


bool LevelBlock_ByteStream::ObjectFromByteStream( core::ByteStreamReader & stream, level::LevelBlock & dataObject )
{
	core::uint32 name_Size; if ( !stream.ReadSize( name_Size ) ) return false;
	void const * name_Bytes; if ( !stream.ReadBytes( name_Size, name_Bytes ) ) return false;
	string name ( (char*)name_Bytes, name_Size );
	dataObject.Set_name ( name );
	
	return true;
}


LevelBlock_Partial::LevelBlock_Partial()
	: name("Block")
	, parent()
	, files()
{
}

LevelBlock_Partial::~LevelBlock_Partial()
{
	parent = NULL;
	for ( level::LevelFilesCollection_Partial::Iterator i = files.Begin(), e = files.End(); i != e; ++i )
		CORE_DELETE *i;
	files.Clear();
}

string LevelBlock_Partial::Get_name() const 
{ 
	return name; 
}
void LevelBlock_Partial::Set_name( string value ) 
{ 
	name = value; 
}

level::LevelFolder * LevelBlock_Partial::Get_parent() const 
{ 
	return parent; 
}
void LevelBlock_Partial::Set_parent( level::LevelFolder * value ) 
{ 
	parent = value; 
}

level::LevelFilesCollection_Partial & LevelBlock_Partial::Get_files() 
{ 
	return files; 
}
level::LevelFilesCollection_Partial const & LevelBlock_Partial::Get_files() const 
{ 
	return files; 
}


bool LevelBlocksCollection_ByteStream::ObjectFromByteStream( core::ByteStreamReader & stream, level::LevelBlocksCollection & dataObject )
{
	return true;
}


LevelBlocksCollection_Partial::LevelBlocksCollection_Partial()
{
}

LevelBlocksCollection_Partial::~LevelBlocksCollection_Partial()
{
}


bool LevelFile_ByteStream::ObjectFromByteStream( core::ByteStreamReader & stream, level::LevelFile & dataObject )
{
	core::uint32 name_Size; if ( !stream.ReadSize( name_Size ) ) return false;
	void const * name_Bytes; if ( !stream.ReadBytes( name_Size, name_Bytes ) ) return false;
	string name ( (char*)name_Bytes, name_Size );
	dataObject.Set_name ( name );
	
	return true;
}


LevelFile_Partial::LevelFile_Partial()
	: parent()
	, scene()
	, name("File")
{
}

LevelFile_Partial::~LevelFile_Partial()
{
	parent = NULL;
	CORE_DELETE scene;
	scene = NULL;
}

level::LevelBlock * LevelFile_Partial::Get_parent() const 
{ 
	return parent; 
}
void LevelFile_Partial::Set_parent( level::LevelBlock * value ) 
{ 
	parent = value; 
}

scene::Scene * LevelFile_Partial::Get_scene() const 
{ 
	return scene; 
}
void LevelFile_Partial::Set_scene( scene::Scene * value ) 
{ 
	scene = value; 
}

string LevelFile_Partial::Get_name() const 
{ 
	return name; 
}
void LevelFile_Partial::Set_name( string value ) 
{ 
	name = value; 
}


bool LevelFilesCollection_ByteStream::ObjectFromByteStream( core::ByteStreamReader & stream, level::LevelFilesCollection & dataObject )
{
	return true;
}


LevelFilesCollection_Partial::LevelFilesCollection_Partial()
{
}

LevelFilesCollection_Partial::~LevelFilesCollection_Partial()
{
}


bool Dependency_ByteStream::ObjectFromByteStream( core::ByteStreamReader & stream, level::Dependency & dataObject )
{
	return true;
}


Dependency_Partial::Dependency_Partial()
	: LevelFolder()
{
}

Dependency_Partial::~Dependency_Partial()
{
	LevelFolder = NULL;
}

level::LevelFolder * Dependency_Partial::Get_LevelFolder() const 
{ 
	return LevelFolder; 
}
void Dependency_Partial::Set_LevelFolder( level::LevelFolder * value ) 
{ 
	LevelFolder = value; 
}


bool Dependencies_ByteStream::ObjectFromByteStream( core::ByteStreamReader & stream, level::Dependencies & dataObject )
{
	return true;
}


Dependencies_Partial::Dependencies_Partial()
{
}

Dependencies_Partial::~Dependencies_Partial()
{
}


} /* namespace level */ 
