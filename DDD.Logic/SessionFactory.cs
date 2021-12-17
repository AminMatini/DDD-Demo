using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace DDD.Logic
{
    /// <summary>
    /// Config NHibrnate
    /// </summary>
    internal static class SessionFactory
    {
        private static ISessionFactory _factory;
        internal static ISession OpenSession()
        {
            return _factory.OpenSession();  
        }

        //private static ISessionFactory BuildSessionFactory(string connectionString)
        //{
        //    FluentConfiguration configuration = Fluently.Configure()
        //        .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString));
        //}


    }
}
