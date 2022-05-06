
using System.Data;
using System.Data.OleDb;

namespace AbstractFactory
{
	public class OleDbFactory : ConnectionFactory
	{
		public const string Provider = "System.Data.OleDbClient";

		public OleDbFactory()
		{
		}

		public override IDbConnection Connection
		{
			get { return new OleDbConnection(ConnectionString); }
		}

		public override IDbCommand Command
		{
			get { return new OleDbCommand { Connection = (OleDbConnection)this.Connection }; }
		}
	}
}