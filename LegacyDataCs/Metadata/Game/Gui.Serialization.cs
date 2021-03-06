
// AUTOGENERATED FILE. MODIFY IT AT YOUR OWN RISK.

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;

namespace gui { 

	[XmlType("Window")]
	public class Window_Serialization : core.ReferenceSerializationObject
	{
		[XmlIgnore]
		gui.Window This;

		[XmlArray]
		[XmlArrayItem(typeof(gui.Window_Serialization),ElementName = "Window")]
		public gui.WindowsCollection_Serialization children = new gui.WindowsCollection_Serialization();

		public Vec2_Serialization position = new Vec2_Serialization ();

		public Vec2_Serialization size = new Vec2_Serialization ();

		[XmlIgnore]
		public gui.Window_Serialization parent;

		[XmlIgnore]
		public gui.GuiFile_Serialization parentFile;

		[DefaultValue("Window")]
		public string name = "Window";

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			stringToObject.Add( GuidStr.ToOptGuid(), This );	
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
			if ( children != null )
				children.CreateGuidToObjectMapping( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (gui.Window)dataObject );
		}
		protected void FromSerializationConstruct_Base( gui.Window dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
			children.FromSerializationConstruct( This.children );
			foreach( gui.Window collectionElement in This.children )
			{
				collectionElement.parent = This;
			}
			if ( position != null )
			{
				position.FromSerializationConstruct( This.position );
			}
			if ( size != null )
			{
				size.FromSerializationConstruct( This.size );
			}
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( gui.Window dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
			children.FromSerialization( stringToObject );
			if ( position != null )
				position.FromSerialization( stringToObject );
			if ( size != null )
				size.FromSerialization( stringToObject );
			This.name = name;
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (gui.Window)dataObject );
		}
		protected void ToSerialization_Base( gui.Window dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
			children.ToSerialization( This.children );
			foreach ( gui.Window_Serialization collectionElement in children )
			{
				collectionElement.parent = this;
			}
			if ( This.position != null )
			{
				position = data.Serialization.ConstructSerialization<Vec2_Serialization>( This.position.GetType() );
				position.ToSerialization( This.position );
			}
			if ( This.size != null )
			{
				size = data.Serialization.ConstructSerialization<Vec2_Serialization>( This.size.GetType() );
				size.ToSerialization( This.size );
			}
			name = This.name;
		}
		
	}

	[XmlType("WindowsCollection")]
	public class WindowsCollection_Serialization : core.SerializationCollectionOf <gui.Window_Serialization>
	{
		[XmlIgnore]
		gui.WindowsCollection This;

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
			foreach( gui.Window_Serialization collectionElement in Values )
				collectionElement.CreateGuidToObjectMapping( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (gui.WindowsCollection)dataObject );
		}
		protected void FromSerializationConstruct_Base( gui.WindowsCollection dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
			This.Clear();
			foreach( gui.Window_Serialization collectionElement in Values )
			{
				gui.Window dataCollectionElement = data.Serialization.ConstructData<gui.Window>( collectionElement.GetType() );
				collectionElement.FromSerializationConstruct( dataCollectionElement );
				This.Add( dataCollectionElement );
			}
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( gui.WindowsCollection dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
			foreach( gui.Window_Serialization collectionElement in Values )
				collectionElement.FromSerialization( stringToObject );
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (gui.WindowsCollection)dataObject );
		}
		protected void ToSerialization_Base( gui.WindowsCollection dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
			Clear();
			foreach( gui.Window dataCollectionElement in This )
			{
				gui.Window_Serialization collectionElement = data.Serialization.ConstructSerialization<gui.Window_Serialization>( dataCollectionElement.GetType() );
				collectionElement.ToSerialization( dataCollectionElement );	
				Add( collectionElement );
			}
		}
		
	}

} /* namespace gui */ 
