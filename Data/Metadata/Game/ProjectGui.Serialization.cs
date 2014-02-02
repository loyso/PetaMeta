
// AUTOGENERATED FILE. MODIFY IT AT YOUR OWN RISK.

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;

namespace gui { 

	[XmlType("Gui")]
	public class Gui_Serialization : core.ReferenceSerializationObject
	{
		[XmlIgnore]
		gui.Gui This;

		[XmlAttribute]
		[DefaultValue("Gui")]
		public string name = "Gui";

		public gui.GuiMainMenu_Serialization mainMenu = new gui.GuiMainMenu_Serialization ();

		public gui.GuiGame_Serialization game = new gui.GuiGame_Serialization ();

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
			FromSerializationConstruct_Base( (gui.Gui)dataObject );
		}
		protected void FromSerializationConstruct_Base( gui.Gui dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
			if ( mainMenu != null )
			{
				This.mainMenu.parent = This;
				mainMenu.FromSerializationConstruct( This.mainMenu );
			}
			if ( game != null )
			{
				This.game.parent = This;
				game.FromSerializationConstruct( This.game );
			}
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( gui.Gui dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
			This.name = name;
			if ( mainMenu != null )
				mainMenu.FromSerialization( stringToObject );
			if ( game != null )
				game.FromSerialization( stringToObject );
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (gui.Gui)dataObject );
		}
		protected void ToSerialization_Base( gui.Gui dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
			name = This.name;
			if ( This.mainMenu != null )
			{
				mainMenu = data.Serialization.ConstructSerialization<gui.GuiMainMenu_Serialization>( This.mainMenu.GetType() );
				mainMenu.parent = this;
				mainMenu.ToSerialization( This.mainMenu );
			}
			if ( This.game != null )
			{
				game = data.Serialization.ConstructSerialization<gui.GuiGame_Serialization>( This.game.GetType() );
				game.parent = this;
				game.ToSerialization( This.game );
			}
		}
		
		public override void FileStorage_FromSerializationConstruct()
		{
			base.FileStorage_FromSerializationConstruct();
			mainMenu.FileStorage_FromSerializationConstruct();
			game.FileStorage_FromSerializationConstruct();
		}
		public override void FileStorage_FromSerialization( core.StringToObject stringToObject )
		{
			base.FileStorage_FromSerialization( stringToObject );
			mainMenu.FileStorage_FromSerialization( stringToObject );
			game.FileStorage_FromSerialization( stringToObject );
		}
		public override void FileStorage_ToSerialization()
		{
			base.FileStorage_ToSerialization();
			mainMenu.FileStorage_ToSerialization();
			game.FileStorage_ToSerialization();
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
			mainMenu.CreateDirectory(projectPath);
			game.CreateDirectory(projectPath);
		}
		
		public override void Load()
		{
			base.Load();
			mainMenu.Load();
			game.Load();
		}
		
		public override void Save()
		{
			base.Save();
			mainMenu.Save();
			game.Save();
		}
		
		public override void SaveAs(string projectPath)
		{
			base.SaveAs( projectPath );
			mainMenu.SaveAs(projectPath);
			game.SaveAs(projectPath);
		}
	}

	[XmlType("GuiCommon")]
	public class GuiCommon_Serialization : core.ReferenceSerializationObject
	{
		[XmlIgnore]
		gui.GuiCommon This;

		[XmlAttribute]
		[DefaultValue("Common")]
		public string name = "Common";

		[XmlArray]
		[XmlArrayItem(typeof(gui.GuiFile_Serialization),ElementName = "GuiFile")]
		public gui.GuiFilesCollection_Serialization files = new gui.GuiFilesCollection_Serialization();

		[XmlIgnore]
		public gui.Gui_Serialization parent;

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			stringToObject.Add( GuidStr.ToOptGuid(), This );	
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
			if ( files != null )
				files.CreateGuidToObjectMapping( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (gui.GuiCommon)dataObject );
		}
		protected void FromSerializationConstruct_Base( gui.GuiCommon dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
			files.FromSerializationConstruct( This.files );
			foreach( gui.GuiFile collectionElement in This.files )
			{
				collectionElement.parent = This;
			}
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( gui.GuiCommon dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
			This.name = name;
			files.FromSerialization( stringToObject );
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (gui.GuiCommon)dataObject );
		}
		protected void ToSerialization_Base( gui.GuiCommon dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
			name = This.name;
			files.ToSerialization( This.files );
			foreach ( gui.GuiFile_Serialization collectionElement in files )
			{
				collectionElement.parent = this;
			}
		}
		
		public override void FileStorage_FromSerializationConstruct()
		{
			base.FileStorage_FromSerializationConstruct();
			foreach( gui.GuiFile_Serialization collectionElement in files )
				collectionElement.FileStorage_FromSerializationConstruct();
		}
		public override void FileStorage_FromSerialization( core.StringToObject stringToObject )
		{
			base.FileStorage_FromSerialization( stringToObject );
			foreach( gui.GuiFile_Serialization collectionElement in files )
				collectionElement.FileStorage_FromSerialization( stringToObject );
		}
		public override void FileStorage_ToSerialization()
		{
			base.FileStorage_ToSerialization();
			foreach( gui.GuiFile_Serialization collectionElement in files )
				collectionElement.FileStorage_ToSerialization();
		}
		[XmlIgnore]
		public string RelativeName { get { return (parent == null ? "" : parent.RelativeName + @"\") + name; } }
		[XmlIgnore]
		public string RootFolderRelativeName { get { return parent == null ? "" : parent.RootFolderRelativeName + name + @"\"; } }
		[XmlIgnore]
		public string FullName { get { return parent.FullName + @"\" + name; } }
		
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
			foreach( gui.GuiFile_Serialization collectionElement in files )
				collectionElement.Load();		
		}
		
		public override void Save()
		{
			base.Save();
			foreach( gui.GuiFile_Serialization collectionElement in files )
				collectionElement.Save();		
		}
		
		public override void SaveAs(string projectPath)
		{
			base.SaveAs( projectPath );
			foreach( gui.GuiFile_Serialization collectionElement in files )
				collectionElement.SaveAs( projectPath );		
		}
	}

	[XmlType("GuiMainMenu")]
	public class GuiMainMenu_Serialization : gui.GuiCommon_Serialization
	{
		[XmlIgnore]
		gui.GuiMainMenu This;

		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (gui.GuiMainMenu)dataObject );
		}
		protected void FromSerializationConstruct_Base( gui.GuiMainMenu dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( gui.GuiMainMenu dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (gui.GuiMainMenu)dataObject );
		}
		protected void ToSerialization_Base( gui.GuiMainMenu dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
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

	[XmlType("GuiGame")]
	public class GuiGame_Serialization : gui.GuiCommon_Serialization
	{
		[XmlIgnore]
		gui.GuiGame This;

		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (gui.GuiGame)dataObject );
		}
		protected void FromSerializationConstruct_Base( gui.GuiGame dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( gui.GuiGame dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (gui.GuiGame)dataObject );
		}
		protected void ToSerialization_Base( gui.GuiGame dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
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

	[XmlType("GuiFile")]
	public class GuiFile_Serialization : core.ReferenceSerializationObject
	{
		[XmlIgnore]
		gui.GuiFile This;

		[XmlIgnore]
		public gui.Window_Serialization mainWindow;

		[XmlIgnore]
		public gui.GuiCommon_Serialization parent;

		[XmlAttribute]
		[DefaultValue("File")]
		public string name = "File";

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			stringToObject.Add( GuidStr.ToOptGuid(), This );	
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
			if ( mainWindow != null )
				mainWindow.CreateGuidToObjectMapping( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (gui.GuiFile)dataObject );
		}
		protected void FromSerializationConstruct_Base( gui.GuiFile dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( gui.GuiFile dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
			This.name = name;
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (gui.GuiFile)dataObject );
		}
		protected void ToSerialization_Base( gui.GuiFile dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
			name = This.name;
		}
		
		public override void FileStorage_FromSerializationConstruct()
		{
			base.FileStorage_FromSerializationConstruct();
			if ( mainWindow != null )
			{
				This.mainWindow = data.Serialization.ConstructData<gui.Window>( mainWindow.GetType() );
				This.mainWindow.parentFile = This;
				mainWindow.FromSerializationConstruct( This.mainWindow );
			}
		}
		public override void FileStorage_FromSerialization( core.StringToObject stringToObject )
		{
			base.FileStorage_FromSerialization( stringToObject );
			if ( mainWindow != null )
				mainWindow.FromSerialization( stringToObject );
		}
		public override void FileStorage_ToSerialization()
		{
			base.FileStorage_ToSerialization();
			if ( This.mainWindow != null )
			{
				mainWindow = new gui.Window_Serialization();
				mainWindow.parentFile = this;
				mainWindow.ToSerialization( This.mainWindow );
			}
		}
		
		[XmlIgnore]
		public string RelativeName { get { return parent.RelativeName + @"\" + name; } }
		[XmlIgnore]
		public string RelativeNameExtension { get { return RelativeName + FileExtension; } }
		[XmlIgnore]
		public string FullName { get { return parent.FullName + @"\" + name; } }
		[XmlIgnore]
		public string FullNameExtension { get { return FullName + FileExtension; } }
		public const string FileExtension = ".gui";
		[XmlIgnore]
		public string RootFolderRelativeName { get { return parent.RootFolderRelativeName + name; } }
		
		public override void Load()
		{
			base.Load();
			if ( System.IO.File.Exists( FullNameExtension ) )
			{
				FileStream filestream = new FileStream(FullNameExtension, FileMode.Open, FileAccess.Read );
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(gui.Window_Serialization), data.Serialization.Types );
				mainWindow = (gui.Window_Serialization)xmlSerializer.Deserialize(filestream);
				filestream.Close();
			}
		}
		
		public override void Save()
		{
			base.Save();
			if ( mainWindow != null )
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(gui.Window_Serialization), data.Serialization.Types );
				TextWriter textWriter = new StreamWriter(FullNameExtension);
				xmlSerializer.Serialize(textWriter, mainWindow);
				textWriter.Close();
			}
		}
		
		public override void SaveAs( string projectPath )
		{
			base.SaveAs( projectPath );
			if ( mainWindow != null )
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(gui.Window_Serialization), data.Serialization.Types );
				TextWriter textWriter = new StreamWriter( projectPath + @"\" + RelativeNameExtension );
				xmlSerializer.Serialize(textWriter, mainWindow);
				textWriter.Close();
			}
		}
	}

	[XmlType("GuiFilesCollection")]
	public class GuiFilesCollection_Serialization : core.SerializationCollectionOf <gui.GuiFile_Serialization>
	{
		[XmlIgnore]
		gui.GuiFilesCollection This;

		public override void CreateGuidToObjectMapping ( core.StringToObject stringToObject ) 
		{
			CreateGuidToObjectMapping_Base( stringToObject );
		}
		protected override void CreateGuidToObjectMapping_Base ( core.StringToObject stringToObject )
		{
			base.CreateGuidToObjectMapping_Base( stringToObject );
			foreach( gui.GuiFile_Serialization collectionElement in Values )
				collectionElement.CreateGuidToObjectMapping( stringToObject );
		}
		
		public override void FromSerializationConstruct( core.DataObject dataObject )
		{
			FromSerializationConstruct_Base( (gui.GuiFilesCollection)dataObject );
		}
		protected void FromSerializationConstruct_Base( gui.GuiFilesCollection dataObject )
		{
			This = dataObject;
			base.FromSerializationConstruct_Base( This );
			This.Clear();
			foreach( gui.GuiFile_Serialization collectionElement in Values )
			{
				gui.GuiFile dataCollectionElement = data.Serialization.ConstructData<gui.GuiFile>( collectionElement.GetType() );
				collectionElement.FromSerializationConstruct( dataCollectionElement );
				This.Add( dataCollectionElement );
			}
		}
		
		public override void FromSerialization( core.StringToObject stringToObject )
		{
			FromSerialization_Base( This, stringToObject );
		}
		protected void FromSerialization_Base( gui.GuiFilesCollection dataObject, core.StringToObject stringToObject )
		{
			base.FromSerialization_Base( This, stringToObject );	
			foreach( gui.GuiFile_Serialization collectionElement in Values )
				collectionElement.FromSerialization( stringToObject );
		}
		
		public override void ToSerialization( core.DataObject dataObject )
		{
			ToSerialization_Base( (gui.GuiFilesCollection)dataObject );
		}
		protected void ToSerialization_Base( gui.GuiFilesCollection dataObject )
		{
			This = dataObject;	
			base.ToSerialization_Base( This );
			Clear();
			foreach( gui.GuiFile dataCollectionElement in This )
			{
				gui.GuiFile_Serialization collectionElement = data.Serialization.ConstructSerialization<gui.GuiFile_Serialization>( dataCollectionElement.GetType() );
				collectionElement.ToSerialization( dataCollectionElement );	
				Add( collectionElement );
			}
		}
		
	}

} /* namespace gui */ 