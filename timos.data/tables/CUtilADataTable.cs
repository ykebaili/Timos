using System;
using System.Data;

using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace timos.data
{
	public static class CUtilADataTable
	{
		public static DataTable UnserializeDataTable(byte[] donnees)
		{
			Stream s = new MemoryStream(donnees);
			GZipStream szip = new GZipStream(s, CompressionMode.Decompress);
			BinaryFormatter format = new BinaryFormatter();
			DataTable dt = null;
			try
			{
				dt = (DataTable)format.Deserialize(szip);
				szip.Close();
			}
			catch
			{
				dt = null;
			}
			return dt;
		}

		//----------------------------------------------------
		public static byte[] SerializeDataTable(DataTable table)
		{
			MemoryStream s = new MemoryStream();
			GZipStream szip = new GZipStream(s, CompressionMode.Compress);
			BinaryFormatter format = new BinaryFormatter();
			format.Serialize(szip, table);
			szip.Close();
			return s.ToArray();
		}

	}
}
