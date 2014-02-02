
#define _CRT_SECURE_NO_WARNINGS
#include <crtdbg.h>

// Macros for setting or clearing bits in the CRT debug flag 
#ifdef _DEBUG
	#define  SET_CRT_DEBUG_FIELD(a)   _CrtSetDbgFlag((a) | _CrtSetDbgFlag(_CRTDBG_REPORT_FLAG))
	#define  CLEAR_CRT_DEBUG_FIELD(a) _CrtSetDbgFlag(~(a) & _CrtSetDbgFlag(_CRTDBG_REPORT_FLAG))
#else
	#define  SET_CRT_DEBUG_FIELD(a)   ((void) 0)
	#define  CLEAR_CRT_DEBUG_FIELD(a) ((void) 0)
#endif


#include "..\DataCpp\Metadata\Game\Scene.h"
#include "..\DataCpp\DataCpp.RemoteServer.h"

#include "..\DataCpp\CoreLua.h"
#include "..\DataCpp\DataCpp.Lua.h"

typedef core::Dictionary< core::Guid, core::DataObject * > GuidToObject_t;

#pragma pack(push,1)

using namespace core;

struct RemoteMessage
{
	Guid Type;
	Guid MemberFunction;
	Guid Object;
};

struct MemberValueSet_Server_RemoteMessage : RemoteMessage
{
	core::Guid	metadataType;
	core::Guid	metadataMember;
	core::Guid	dataObject;
	core::uint8 size;
	Vec3		position;
	// int			lod;
};

struct TestFunction_RemoteMessage : RemoteMessage
{
	core::int32 argInt;
	Vec3		argVec;
	core::Guid	argRef;
	core::int32 argEnum;
	core::uint8 sizeString;
	char		argString[24];
	Color		argColor;
};
#pragma pack(pop)

int main(int argc, char* argv[])
{
	// _CrtSetBreakAlloc(454);

	SET_CRT_DEBUG_FIELD( _CRTDBG_LEAK_CHECK_DF );
	SET_CRT_DEBUG_FIELD ( _CRTDBG_ALLOC_MEM_DF );

	lua::Host * pHost = new lua::Host;

	data::Reflection::Init();
	data::LuaInit( *pHost );
	core::Objects::Init();

	scene::SceneAnimMesh * pAnimMesh = new scene::SceneAnimMesh;
	pAnimMesh->Set_Guid("391eb883-c88f-4c66-b552-0d6e18cb72e3");
	core::Objects::Add( *pAnimMesh );

	scene::SceneZoneTrigger * pZoneTrigger = new scene::SceneZoneTrigger;
	pZoneTrigger->Set_Guid("845BC085-44FF-4507-905C-2C596EA9E74B");
	core::Objects::Add( *pZoneTrigger );

	data::remote::Server * pServer = new data::remote::Server;

	{
		MemberValueSet_Server_RemoteMessage msg;
		msg.Type = core::Guid("56e8a41d-bf20-475f-aa07-0a512975f527").ToNetwork();
		msg.MemberFunction = core::Guid("3491d868-eb38-4bdb-8e24-404a06714f29").ToNetwork();
		msg.Object = core::Guid::Empty;

		msg.metadataType = core::Guid("a31ecf2f-653b-4595-8eed-c50c0d3cc116").ToNetwork();
		// msg.metadataMember = core::Guid("4d99ebcb-27de-4835-8317-be504f3959f7").ToNetwork(); // lod
		msg.metadataMember = core::Guid("fae85196-efcd-4004-a660-afbbc4ccb7d9").ToNetwork(); // position		
		msg.dataObject = core::Guid( pAnimMesh->Get_Guid() ).ToNetwork();
		// msg.lod = core::ByteOrder::ToNetwork( 13 ); msg.size = sizeof( core::int32 );
		msg.position = Vec3( 1.1f, 2.2f, 3.3f ); msg.size = sizeof( Vec3 );

		pServer->ReceiveFromClient( &msg, sizeof(msg) );
	}

	{
		TestFunction_RemoteMessage msg;
		msg.Type = core::Guid("a31ecf2f-653b-4595-8eed-c50c0d3cc116").ToNetwork();
		msg.MemberFunction = core::Guid("c4b461bf-af49-4925-874f-68827e86e992").ToNetwork();
		msg.Object = pAnimMesh->Get_Guid().ToNetwork();

		msg.argInt = core::ByteOrder::ToNetwork( 666 );
		msg.argVec = Vec3( 4.4f, 5.5f, 6.6f );
		msg.argRef = pZoneTrigger->Get_Guid().ToNetwork();
		msg.argEnum = core::ByteOrder::ToNetwork( scene::Character );
		msg.argColor = Color( 11, 22, 33, 44 );

		memcpy( msg.argString, "Hello, very long string!", 24 );
		msg.sizeString = 24;

		pServer->ReceiveFromClient( &msg, sizeof(msg) );
	}

	delete pServer;

	core::Objects::Remove( *pZoneTrigger );
	core::Objects::Remove( *pAnimMesh );
	
	delete pAnimMesh;
	delete pZoneTrigger;

	core::Objects::Done();
	data::LuaDone( *pHost );
	data::Reflection::Done();

	delete pHost;
	pHost = NULL;

	return 0;
}

