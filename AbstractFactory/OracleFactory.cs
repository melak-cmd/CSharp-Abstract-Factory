
using System.Data;
using System.Data.OracleClient;

namespace AbstractFactory
{
	public class OracleFactory : ConnectionFactory
	{
		public const string Provider = "System.Data.OracleClient";

		public OracleFactory()
		{
		}

		public override IDbConnection Connection
		{
			get { return new OracleConnection(ConnectionString); }
		}

		public override IDbCommand Command
		{
			get { return new OracleCommand { Connection = (OracleConnection)this.Connection }; }
		}
	}
}