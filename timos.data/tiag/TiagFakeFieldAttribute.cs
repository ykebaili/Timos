using System;
using System.Collections.Generic;
using System.Text;

namespace timos.data.tiag
{
	/// <summary>
	/// S'utilise quand une entité tiag mappe une propriété avec un champ, mais
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
