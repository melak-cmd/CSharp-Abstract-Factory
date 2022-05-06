using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AbstractFactory;
using System.Data;
using System.Data.SqlClient;

namespace AbstractFactoryPatterns
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			ConnectionFactory.Provider = "System.Data.SqlClient";
			ConnectionFactory.ConnectionStringName = "SqlConnectionStringB";
			ConnectionFactory factory = ConnectionFactory.Instance;

			IDbConnection connection = factory.Connection;
			IDbCommand command = factory.Command;


			command.CommandType = CommandType.Text;
			command.CommandText = "write your command here"; //replace it by your command
			connection.Open();
			command.ExecuteNonQuery(); //it will generate error. please modify corresponding connection string in web.config  and command text in above line
			connection.Close();
		}
	}
}
