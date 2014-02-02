using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using metadata;

namespace TestMetadata
{
	class Program
	{
		static void Main(string[] args)
		{
			MetadataProject project = null;
			try
			{
				// project = project.ProjectLoad( @"d:\Work\PetaMeta\Media\Game" );
				project = project.ProjectLoad( @"d:\Work\PetaMeta\Media\MetaMetadata" );
				project.Load();

				foreach( MetadataFile metadataFile in project.Metadata.FilesRecursive )
				{
					foreach( MetadataClass c in metadataFile.Content.ClassesSorted )
					{
						string a = c.TypeName;
					}
					foreach( MetadataClass c in metadataFile.Content.Classes )
					{
						foreach( MetadataClass metadataClass in metadataFile.Content.Classes )
						{
							if ( c.TypeName == "Type" && metadataClass.TypeName == "CollectionClass" )
							{
							}
							if ( c.ContainsObjects( metadataClass ) )
							{
							}
						}

						foreach ( MetadataMemberGroup group in project.MemberGroupsAll )
						{						
							if ( c.HasMembersOfGroup(group) )
							{
							}
							if ( c.HasReferences )
							{
							}
							if ( c.HasAllMembersDefaultGroup )
							{
							}							
							foreach ( Member m in c.MembersByGroup(group) )
							{
							}
						}
					}
				}
				
				project.SaveAs( @"d:\Work\PetaMeta\TempMedia\ProjectCopy" + project.ProjectExtension() );
			}
			catch( core.ReferencesFixupException e )
			{
				Console.WriteLine( "ReferencesFixupException, Guid=" + e.Guid.ToString() );
			}
			catch ( core.TreePathException e )
			{
				Console.WriteLine( "TreePathException, Path=" + e.Path.ToString() );
			}	
		}
	}
}
