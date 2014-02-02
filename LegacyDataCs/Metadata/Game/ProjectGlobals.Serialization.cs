
// AUTOGENERATED FILE. MODIFY IT AT YOUR OWN RISK.

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;

namespace game { 

	[XmlType("Globals")]
	public class Globals_Serialization : core.ReferenceSerializationObject
	{
		[XmlIgnore]
		game.Globals This;

		[XmlAttribute]
		[DefaultValue("Globals")]
		public string name = "Globals";

		[XmlIgnore]
		public game.Game_Serialization parent;

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			stringToObject.Add( GuidStr.ToOptGuid(), This );	
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (game.Globals)dataObject );
		}
		protected void FromSerializationConstruct_Base( game.Globals dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( game.Globals dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
			This.name = name;
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (game.Globals)dataObject );
		}
		protected void ToSerialization_Base( game.Globals dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
			name = This.name;
		}
		
		public override void FileStorage_FromSerializationConstruct()
		{
			base.FileStorage_FromSerializationConstruct();
		}
		
		public override void FileStorage_FromSerialization( core.StringToObject stringToObject )
		{
			base.FileStorage_FromSerialization( stringToObject );
		}
		public override void FileStorage_ToSerialization()
		{
			base.FileStorage_ToSerialization();
		}
		[XmlIgnore]
		public string RelativeName { get { return name; } }
		[XmlIgnore]
		public string RootFolderRelativeName { get { return name + @"\"; } }
		[XmlIgnore]
		public string FullName { get { return parent.ProjectPath + @"\" + name; } }
		
		public override void CreateDirectory(string projectPath)
		{
			Directory.CreateDirectory(projectPath + @"\"+ RelativeName);
			CreateDirectory_Base( projectPath );
		}
		protected override void CreateDirectory_Base(string projectPath)
		{
			base.CreateDirectory_Base( projectPath );
		}
		
		public override void Load()
		{
			base.Load();
		}
		
		public override void Save()
		{
			base.Save();
		}
		
		public override void SaveAs(string projectPath)
		{
			base.SaveAs( projectPath );
		}
	}

} /* namespace game */ 
