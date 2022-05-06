
using System.Data;
using System.Data.SqlClient;

namespace AbstractFactory
{
	public class MsSqlFactory : ConnectionFactory
	{
		public const string Provider = "System.Data.SqlClient";

		public MsSqlFactory()
		{
		}

		public override IDbConnection Connection
		{
			get { return new SqlConnection(ConnectionString); }
		}

		public override IDbCommand Command
		{
			get { return new SqlCommand { Connection = (SqlConnection)this.Connection }; }
		}
	}
}