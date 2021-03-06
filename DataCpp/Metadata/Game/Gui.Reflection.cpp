
// AUTOGENERATED FILE. MODIFY IT AT YOUR OWN RISK.

#include "Gui.h"

#include "..\..\Reflection.h"

#include "Gui.Reflection.h"

// depends on parent/reference files
#include "ProjectGui.h"
// depends on reflection files
#include "..\Engine\Fundamental.Reflection.h"

namespace gui { 

class Window_Member_children : public reflection::Collection
{
public:
	Window_Member_children()
	{
		Set_Guid("5a18866f-dc00-45d2-bb19-93a439ef7f69");
		Set_Name("children");
	}
	virtual bool GetCollectionObject( core::DataObject const & ThisUnityped, core::ICollection const * & pCollectionUnityped ) const
	{
		gui::Window const * pThis = core::polymorphic_downcast< gui::Window const * >( &ThisUnityped );
		if ( !pThis )
			return false;		
		pCollectionUnityped = &pThis->Get_children();
		return true;
	}
	virtual bool GetCollectionObject( core::DataObject & ThisUnityped, core::ICollection * & pCollectionUnityped ) const
	{
		gui::Window * pThis = core::polymorphic_downcast< gui::Window * >( &ThisUnityped );
		if ( !pThis )
			return false;		
		pCollectionUnityped = &pThis->Get_children();
		return true;
	}
};

class Window_Member_position : public reflection::Value
{
public:
	Window_Member_position()
	{
		Set_Guid("572d08c8-4252-4f9c-bb06-54da38eca3ff");
		Set_Name("position");
	}
	virtual bool SetObjectValue( core::DataObject & ThisUnityped, core::DataObject * pDataObjectUnityped ) const
	{
		gui::Window * pThis = core::polymorphic_downcast< gui::Window * >( &ThisUnityped );
		if ( !pThis )
			return false;
		Vec2_Boxed const * pDataObject = core::polymorphic_downcast < Vec2_Boxed const * > ( pDataObjectUnityped );
		if ( !pDataObject )
			return false;
		pThis->Set_position( pDataObject->value );
		return true;
	}
	virtual bool GetObjectValue( core::DataObject const & ThisUnityped, core::DataObject * & pDataObjectUnityped ) const
	{
		gui::Window const * pThis = core::polymorphic_downcast< gui::Window const * >( &ThisUnityped );
		if ( !pThis )
			return false;
		Vec2_Boxed * pDataObject = CORE_NEW Vec2_Boxed();
		pDataObject->value = pThis->Get_position();
		pDataObjectUnityped = pDataObject;
		return true;
	}
	virtual bool SetObjectValue_FromByteStream( core::DataObject & ThisUnityped, core::ByteStreamReader & stream ) const
	{
		gui::Window * pThis = core::polymorphic_downcast< gui::Window * >( &ThisUnityped );
		if ( !pThis )
			return false;
		Vec2 value; if ( !Vec2_ByteStream::ObjectFromByteStream( stream, value ) ) return false;
		pThis->Set_position( value );
		return true;
	}	
};

class Window_Member_size : public reflection::Value
{
public:
	Window_Member_size()
	{
		Set_Guid("9d4f73b8-e0b6-40ef-9107-0d6740362974");
		Set_Name("size");
	}
	virtual bool SetObjectValue( core::DataObject & ThisUnityped, core::DataObject * pDataObjectUnityped ) const
	{
		gui::Window * pThis = core::polymorphic_downcast< gui::Window * >( &ThisUnityped );
		if ( !pThis )
			return false;
		Vec2_Boxed const * pDataObject = core::polymorphic_downcast < Vec2_Boxed const * > ( pDataObjectUnityped );
		if ( !pDataObject )
			return false;
		pThis->Set_size( pDataObject->value );
		return true;
	}
	virtual bool GetObjectValue( core::DataObject const & ThisUnityped, core::DataObject * & pDataObjectUnityped ) const
	{
		gui::Window const * pThis = core::polymorphic_downcast< gui::Window const * >( &ThisUnityped );
		if ( !pThis )
			return false;
		Vec2_Boxed * pDataObject = CORE_NEW Vec2_Boxed();
		pDataObject->value = pThis->Get_size();
		pDataObjectUnityped = pDataObject;
		return true;
	}
	virtual bool SetObjectValue_FromByteStream( core::DataObject & ThisUnityped, core::ByteStreamReader & stream ) const
	{
		gui::Window * pThis = core::polymorphic_downcast< gui::Window * >( &ThisUnityped );
		if ( !pThis )
			return false;
		Vec2 value; if ( !Vec2_ByteStream::ObjectFromByteStream( stream, value ) ) return false;
		pThis->Set_size( value );
		return true;
	}	
};

class Window_Member_parent : public reflection::ParentReference
{
public:
	Window_Member_parent()
	{
		Set_Guid("1dc51fd9-fe34-4022-9a99-2b19146092c0");
		Set_Name("parent");
	}
	virtual bool SetObjectValue( core::DataObject & ThisUnityped, core::DataObject * pDataObjectUnityped ) const
	{
		gui::Window * pThis = core::polymorphic_downcast< gui::Window * >( &ThisUnityped );
		if ( !pThis )
			return false;
			
		gui::Window * pDataObject = NULL;			
		if ( pDataObjectUnityped )
		{
			pDataObject = core::polymorphic_downcast< gui::Window * >( pDataObjectUnityped );
			if ( !pDataObject )
				return false;
		}		
		pThis->Set_parent( pDataObject );
		return true;	
	}
	virtual bool GetObjectValue( core::DataObject const & ThisUnityped, core::DataObject * & pDataObjectUnityped ) const
	{
		gui::Window const * pThis = core::polymorphic_downcast< gui::Window const * >( &ThisUnityped );
		if ( !pThis )
			return false;
		pDataObjectUnityped = pThis->Get_parent();
		return true;	
	}
};

class Window_Member_parentFile : public reflection::ParentReference
{
public:
	Window_Member_parentFile()
	{
		Set_Guid("7f1de85d-3e95-4c5c-96f1-2565c5c5576e");
		Set_Name("parentFile");
	}
	virtual bool SetObjectValue( core::DataObject & ThisUnityped, core::DataObject * pDataObjectUnityped ) const
	{
		gui::Window * pThis = core::polymorphic_downcast< gui::Window * >( &ThisUnityped );
		if ( !pThis )
			return false;
			
		gui::GuiFile * pDataObject = NULL;			
		if ( pDataObjectUnityped )
		{
			pDataObject = core::polymorphic_downcast< gui::GuiFile * >( pDataObjectUnityped );
			if ( !pDataObject )
				return false;
		}		
		pThis->Set_parentFile( pDataObject );
		return true;	
	}
	virtual bool GetObjectValue( core::DataObject const & ThisUnityped, core::DataObject * & pDataObjectUnityped ) const
	{
		gui::Window const * pThis = core::polymorphic_downcast< gui::Window const * >( &ThisUnityped );
		if ( !pThis )
			return false;
		pDataObjectUnityped = pThis->Get_parentFile();
		return true;	
	}
};

class Window_Member_name : public reflection::ValueName
{
public:
	Window_Member_name()
	{
		Set_Guid("161ae0ba-f877-4d73-9ccb-269ca75b731e");
		Set_Name("name");
	}
	virtual bool SetObjectValue( core::DataObject & ThisUnityped, core::DataObject * pDataObjectUnityped ) const
	{
		gui::Window * pThis = core::polymorphic_downcast< gui::Window * >( &ThisUnityped );
		if ( !pThis )
			return false;
		string_Boxed const * pDataObject = core::polymorphic_downcast < string_Boxed const * > ( pDataObjectUnityped );
		if ( !pDataObject )
			return false;
		pThis->Set_name( pDataObject->value );
		return true;
	}
	virtual bool GetObjectValue( core::DataObject const & ThisUnityped, core::DataObject * & pDataObjectUnityped ) const
	{
		gui::Window const * pThis = core::polymorphic_downcast< gui::Window const * >( &ThisUnityped );
		if ( !pThis )
			return false;
		string_Boxed * pDataObject = CORE_NEW string_Boxed();
		pDataObject->value = pThis->Get_name();
		pDataObjectUnityped = pDataObject;
		return true;
	}
	virtual bool SetObjectValue_FromByteStream( core::DataObject & ThisUnityped, core::ByteStreamReader & stream ) const
	{
		gui::Window * pThis = core::polymorphic_downcast< gui::Window * >( &ThisUnityped );
		if ( !pThis )
			return false;
		core::uint32 size; if ( !stream.ReadSize( size ) ) return false;
		void const * bytes; if ( !stream.ReadBytes( size, bytes ) ) return false;
		string value( (char*)bytes, size );
		pThis->Set_name( value );
		return true;
	}	
};


Window_Reflection::Window_Reflection()
{
	Set_Guid("bedc8392-d554-4e40-bc12-61edd551989b");
	Set_TypeName("Window");	
	Get_Members().Add( CORE_NEW Window_Member_children() );
	Get_Members().Add( CORE_NEW Window_Member_position() );
	Get_Members().Add( CORE_NEW Window_Member_size() );
	Get_Members().Add( CORE_NEW Window_Member_parent() );
	Get_Members().Add( CORE_NEW Window_Member_parentFile() );
	Get_Members().Add( CORE_NEW Window_Member_name() );
}

void Window_Reflection::CopyObjectDataFromTo( Window const & from, Window & to )
{
	// TODO: implement
}

core::ReferenceObject * Window_Reflection::New() const
{ 
	return CORE_NEW gui::Window(); 
}

void Window_Reflection::Delete( core::ReferenceObject * pDataObject ) const
{ 
	CORE_DELETE pDataObject; 
}


WindowsCollection_Reflection::WindowsCollection_Reflection()
{
	Set_Guid("5fd8d70c-81ba-4d60-84b6-aac42e82e833");
	Set_TypeName("WindowsCollection");	
}

void WindowsCollection_Reflection::CopyObjectDataFromTo( WindowsCollection const & from, WindowsCollection & to )
{
	// TODO: implement
}


} /* namespace gui */ 
