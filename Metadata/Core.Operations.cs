using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace core
{
	public interface IOperations
	{
		void NewNames();
		void NewGuids();
		void ObjectDeleted( core.DataObject dataObject );
		bool ContainsObject( core.DataObject objectReference );
		void CopyObjectDataFrom( core.DataObject fromObject );
	}
}
