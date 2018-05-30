/*
move blob field on each table to single table

ex. moving from table:
	person: face_photo.
	document: thumbnail.

ex. move to:
	thumbnail: table_name, row_key, old_column_name, content 


*/


using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace DB_Migration
{
	class Program
	{
		static void Main(string[] args)
		{
			//database name
			var db = "evi_inventory";

			//Q1. listing table, column target
			var sql1 = $"select w.Table_Name, w.COLUMN_NAME from (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '{db}' and  DATA_TYPE like '%blob%' and TABLE_NAME not in ('thumbnail') ) as w";
			var db1 = DBConnection.Instance();
			if (db1.IsConnect())
			{
				var cmd = new MySqlCommand(sql1, db1.Connection);
				var RQ1 = cmd.ExecuteReader();

				int i = 0;
				while (RQ1.Read())
				{
					//Q2. read column name as primary key
					var sql2 = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '{db}' and  COLUMN_KEY ='PRI' and TABLE_NAME='{RQ1[0]}' limit 1";
					var db2 = DBConnection.Instance();
					if (db2.IsConnect())
					{
						var pricol = new MySqlCommand(sql2, db2.Connection);
						var RQ2 = pricol.ExecuteReader();
						while (RQ2.Read())
						{
							// Q3.selecting data from target table
							//var sql3 = $"select CONCAT('{RQ1[0]}','/{RQ1[1]}',@rownum := @rownum + 1) as image_id, {RQ2[0]}, {RQ1[1]} from {RQ1[0]}, (SELECT @rownum := 0) r where length(`{RQ1[1]}`)>40 ";
							var sql3 = $"select {RQ2[0]}, {RQ1[1]} from {RQ1[0]}";
							var db3 = DBConnection.Instance();
							if (db3.IsConnect())
							{
								var old = new MySqlCommand(sql3, db3.Connection);
								var RQ3 = old.ExecuteReader();
								while (RQ3.Read())
								{
									//Q4. insert
									//var insimage = $"insert into images (image_id, image_name, content) values('{RQ3[0]}','{RQ3[1]}',?content)";
									var insimage = $"insert into thumbnail (Table_Name, Row_ID, Column_Name, Content) values('{RQ1[0]}','{RQ3[0]}','{RQ1[1]}',?content)";
									var ins = DBConnection.Instance();
									if (ins.IsConnect())
									{
										var insi = new MySqlCommand(insimage, ins.Connection);
										insi.Parameters.Add("?content", Image RQ3[1]);
										var insc = insi.ExecuteNonQuery();
										//if (insc == 1)
										//{
										//	var updateold = $"update {RQ1[0]} set {RQ1[1]}='{RQ3[0]}' where {RQ2[0]}='{RQ3[1]}'";
										//	insi = new MySqlCommand(updateold, ins.Connection);
										//	insi.ExecuteNonQuery();

										//}
										//else
										//{
										//	System.Diagnostics.Debug.Print("fail on" + RQ3[1]);
										//}

									}
								}
							}



						}
					}
				}

				Console.ReadLine();
			}
		}
	}
	public class DBConnection
	{
		private DBConnection()
		{
		}

		private string databaseName = "evi_inventory";
		public string DatabaseName
		{
			get { return databaseName; }
			set { databaseName = value; }
		}

		public string Password { get; set; }
		private MySqlConnection connection = null;
		public MySqlConnection Connection
		{
			get { return connection; }
		}

		private static DBConnection _instance = null;
		public static DBConnection Instance()
		{
			
			return new DBConnection();
		}

		public bool IsConnect()
		{
			bool result = true;
			if (Connection == null)
			{
				if (String.IsNullOrEmpty(databaseName))
					result = false;
				string connstring = string.Format("Server=localhost; database={0}; UID=root; Allow User Variables=True", databaseName);
				connection = new MySqlConnection(connstring);
				connection.Open();
				result = true;
			}

			return result;
		}

		public void Close()
		{
			connection.Close();
		}
	}
}
