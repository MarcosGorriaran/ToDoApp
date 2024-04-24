using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using Npgsql;

namespace cat.itb.M6UF2Pr
{
    public class SessionFactoryCloud

    {
        const string Host = "ella.db.elephantsql.com";
        const string Db= "vohtpoqn";
        const string User = "vohtpoqn";
        const string Password = "Kxpge1zI6GmtmKt1JJfGPLnoubMuzZBM";
        private static string ConnectionString = $"Server={Host};Port=5432;Database={Db};User Id={User};Password={Password};";
        private static ISessionFactory session;

        public static ISessionFactory CreateSession<T>()
        {
            if (session != null)
                return session;

            IPersistenceConfigurer configDB = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(ConnectionString);
            var configMap =
                Fluently.Configure().Database(configDB).Mappings(
                    c => c.FluentMappings.AddFromAssemblyOf<T>());

            session = configMap.BuildSessionFactory();

            return session;
        }

        public static NHibernate.ISession Open<T>()
        {
            return CreateSession<T>().OpenSession();
        }
        public static NpgsqlConnection OpenNpgsqlConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection(
                ConnectionString
            );
            conn.Open();
            return conn;
        }
    }
}
