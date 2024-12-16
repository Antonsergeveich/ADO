using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Library2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Library.Select("author_id,first_name,last_name","Authors");
		}
	}
}
