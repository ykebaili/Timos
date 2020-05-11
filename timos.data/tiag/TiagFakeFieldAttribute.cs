using System;
using System.Collections.Generic;
using System.Text;

namespace timos.data.tiag
{
	/// <summary>
	/// S'utilise quand une entit� tiag mappe une propri�t� avec un champ, mais
	/// en trichant, parce que 
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class TiagFakeFieldAttribute : Attribute
	{
		public readonly string Field;

		public TiagFakeFieldAttribute(string strField)
		{
			Field = strField;
		}
	}

	
}
