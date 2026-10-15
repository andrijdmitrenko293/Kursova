using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kursova.DatabaseConfig;
using MySqlConnector;


namespace Kursova
{
	public class DatabaseConfig
	{
		public class DbConfig
		{
			public string Server { get; set; } = "localhost";
			public string User { get; set; } = "root";
			public string Password { get; set; } = ""; // Ваш пароль до MySQL
			public string Database { get; set; } = "vet_clinic";
		}
	}
	public class ConnectionStringBuilder
	{
		public static string Build(DbConfig config)
		{
			var builder = new MySqlConnectionStringBuilder
			{
				Server = config.Server,
				UserID = config.User,
				Password = config.Password,
				Database = config.Database
			};
			return builder.ConnectionString;
		}
	}
}
