using System;
using System.Configuration;
using System.Data;
using System.Reflection;

namespace AbstractFactory
{
    public abstract class ConnectionFactory
    {
        private static string _provider;
        private static ConnectionFactory _instance;
        private static string _connectionStringName;

        public static string Provider
        {
            private get { return _provider ?? "System.Data.OleDbClient"; } //sets the default provider to OleDb if not set explicitly
            set { _provider = value; }
        }

        public static string ConnectionStringName
        {
            private get { return _connectionStringName ?? "A"; } //sets the default Connectionstring to A if not set explicitly
            set { _connectionStringName = value; }
        }

        public static ConnectionFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
                    {
                        if (type.BaseType == typeof(ConnectionFactory))
                        {
                            var providerName = type.GetField("Provider").GetRawConstantValue().ToString();

                            if (providerName == Provider)
                            {
                                _instance = (ConnectionFactory) Activator.CreateInstance(type, true);
                                break;
                            }
                        }
                    }
                }

                return _instance;
            }
        }

        public abstract IDbConnection Connection { get; }

        public abstract IDbCommand Command { get; }

        protected static string ConnectionString
        {
            get
            {
                var settings = ConfigurationManager.ConnectionStrings;

                foreach (ConnectionStringSettings setting in settings)
                {
                    if (setting.ProviderName == Provider && setting.Name == _connectionStringName)
                    {
                        return setting.ConnectionString;
                    }
                }

                return null;
            }
        }
    }
}