﻿#define PRINT_AUTHORS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADO
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
			Console.WriteLine(connectionString);
			Console.WriteLine("\n---------------------------\n");

			SqlConnection connection = new SqlConnection(connectionString);
			string cmd = "SELECT * FROM  Authors";
			SqlCommand command = new SqlCommand(cmd, connection);
			connection.Open();

			SqlDataReader reader = command.ExecuteReader();
			const int padding = 27;
			for (int i = 0; i < reader.FieldCount; i++)
			{
				Console.Write(reader.GetName(i).PadRight(padding));
			}
			Console.WriteLine();

			//if (!reader.IsClosed)
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					for (int i = 0; i < reader.FieldCount; i++)
					{
						Console.Write(reader[i].ToString().PadRight(padding));
					}
					Console.WriteLine();
				}
			}

			reader.Close();
			connection.Close();
			Console.WriteLine("\n=============================\n");
			///////////////////////////////////////////////////////////

			command.CommandText = "SELECT book_title, last_name+' '+first_name AS 'Author'  " +
				"FROM Books JOIN Authors ON (author=author_id)";
			connection.Open();
			reader = command.ExecuteReader();
			if (reader.HasRows)
			{
				for (int i = 0; i < reader.FieldCount; i++)
					Console.Write(reader.GetName(i).PadRight(padding));
				Console.WriteLine();
				while (reader.Read())
				{
					for (int i = 0; i < reader.FieldCount; i++)
					{
						Console.Write(reader[i].ToString().PadRight(padding));
					}
					Console.WriteLine();
				}
			}
			reader.Close();
			connection.Close();
			Console.WriteLine("\n=============================\n");
			//////////////////////////////////////////////////////////

			command.CommandText =
				"SELECT COUNT(book_id) AS 'Books count', first_name+' '+last_name AS 'Author' " +
				"FROM Books JOIN Authors ON (author=author_id)" +
				"GROUP BY first_name, last_name";
			connection.Open();
			reader=command.ExecuteReader();
			if(reader.HasRows)
			{
				for (int i = 0; i < reader.FieldCount; i++)
					Console.Write(reader.GetName(i).PadRight(padding));
				Console.WriteLine();
				while (reader.Read()) 
				{
					for(int i = 0;i < reader.FieldCount; i++)
						Console.Write(reader[i].ToString().PadRight(padding));
					Console.WriteLine() ;
				}
			}

			reader.Close();
			connection.Close();
		}
	}
}
