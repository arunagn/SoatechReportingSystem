using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Reflection;
using System.Configuration;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Criterion;
using NHibernate.Persister.Entity;
using NHibernate.Search;
using NHibernate.Event;
using NHibernate.Search.Store;
using NHibernate.Search.Event;
using NHibernate.Search.Cfg;
using NHibernate.Search.Backend;
using NHibernate.Search.Engine;
using NHibernate.Search.Impl;
using NHibernate.Cache;
using FluentNHibernate;
using FluentNHibernate.Data;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.MappingModel;
using FluentNHibernate.Mapping;
using FluentNHibernate.Search;
using FluentNHibernate.Search.Mapping;
using FluentNHibernate.Search.Cfg;
using FluentNHibernate.Search.Cfg.EventListeners;
using Lucene.Net;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Util;
using log4net;
using log4net.Config;

namespace Reporting_System
{
    public class Global : System.Web.HttpApplication
    {
        public static ISessionFactory _factory = BuidSession();

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public Global()
        {
            this.BeginRequest += new EventHandler(Global_BeginRequest);
            this.EndRequest += new EventHandler(Global_EndRequest);
        }

        private void Global_EndRequest(object sender, EventArgs e)
        {
            CurrentSessionContext.Unbind(_factory).Dispose();
        }

        private void Global_BeginRequest(object sender, EventArgs e)
        {
            CurrentSessionContext.Bind(_factory.OpenSession());
        }
        public static ISessionFactory BuidSession()
        {
            try
            {
                Assembly assembly = Assembly.LoadFrom(ConfigurationManager.AppSettings["MappingAssembly"]);
                _factory = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(c => c.FromConnectionStringWithKey("SoatechDatabase")))
                    .Mappings(m => m.FluentMappings.AddFromAssembly(assembly))
                    //.Search(s => s.DefaultAnalyzer().Standard()
                    //.DirectoryProvider().FSDirectory()
                    //.IndexBase(ConfigurationManager.AppSettings["SearchIndexFolder"])
                    //.IndexingStrategy().Event())
                    //.ExposeConfiguration(cfg =>
                    //{
                    //    cfg.SetProperty("current_session_context_class", "web");
                    //    cfg.SetListener(ListenerType.PostInsert, new FullTextIndexEventListener());
                    //    cfg.SetListener(ListenerType.PostUpdate, new FullTextIndexEventListener());
                    //    cfg.SetListener(ListenerType.PostDelete, new FullTextIndexEventListener());
                    //})
                    .BuildSessionFactory();

            }

            catch (HibernateException hex)
            {

            }
            catch (Exception ex)
            {

            }
            return _factory;
        }

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}