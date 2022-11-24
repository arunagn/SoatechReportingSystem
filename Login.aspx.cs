using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SqlMapping;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Roles;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Persister.Entity;
using NHibernate.Cache;
using FluentNHibernate;
using FluentNHibernate.Data;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.MappingModel;
using FluentNHibernate.Mapping;
using log4net;


namespace Reporting_System
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        #region Private Global Variables
        private ISession _session = null;
        /// <summary>
        /// Object for Log4net
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //   ((Panel)Master.FindControl("pnlNavigation")).Visible = false;

        }
        protected void Page_Load(object sender, EventArgs e)
        {




            //          SELECT*
            //            FROM tblClient
            //            INNER JOIN tblUser
            //ON tblClient.User_Id = tblUser.User_Id
            //INNER JOIN tblReport
            //ON tblReport.Role_id = tblUser.Role_Id;

            if (!IsPostBack)
            {
                BindDropdown();
                Session["RoleId"] = null;
                Session["UserId"] = null;
                this.Master.FindControl("lbtnLogout").Visible = false;

            }



        }

        public void BindDropdown()
        {
            try
            {
                _session = Global._factory.GetCurrentSession();
                RoleServices roleSer = new RoleServices(ref _session);

                IList<Role> roleList = roleSer.GetAllRecords();
                if (roleList != null && roleList.Count > 0)
                {
                    foreach (Role role in roleList)
                    {
                        ListItem list = new ListItem(role.Name, role.Role_Id.ToString());
                        dlRole.Items.Add(list);
                        //dlRole.DataTextField=role.Name;
                        //dlRole.DataValueField = role.Role_Id.ToString();
                        //dlRole.DataSource = role;
                        dlRole.DataBind();

                    }
                }



            }
            catch (Exception ex)
            {
                ((Label)(this.Master.FindControl("lblErrorMsg"))).Text = ex.Message.ToString();
            }


        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string RoleId = dlRole.SelectedItem.Value.ToString();
                string username = txtName.Text.ToString();
                string Password = txtPwd.Text.ToString();

                _session = Global._factory.GetCurrentSession();



                ClientService clientSer = new ClientService(ref _session);
                UserServices userSer = new UserServices(ref _session);
                IList<Client> clientList = clientSer.GetAllRecords();
                IList<User> userList = userSer.GetAllRecords();

                // MasterPage masterPage = new MasterPage();



                if (RoleId == "1")
                {
                    if (clientList != null && clientList.Count > 0)
                    {

                        foreach (Client client in clientList)
                        {
                            if (client.Email == username && client.Password == Password)
                            {

                                Session["RoleId"] = RoleId;

                                //Session["UserId"] = client.User.ToString();

                                Response.Redirect(RoleId + "/Home.aspx");
                            }
                            else
                            {
                                ((Label)(this.Master.FindControl("lblErrorMsg"))).Text = "Company Not Found.!";
                            }

                        }

                    }
                }
                else if (RoleId == "3")
                {
                    if (userList != null && userList.Count > 0)
                    {

                        foreach (User user in userList)
                        {
                            if (user.Username == username && user.Password == Password)
                            {

                                Session["RoleId"] = RoleId;

                                Session["UserId"] = user.User_Id.ToString();

                                Response.Redirect(RoleId + "/Home.aspx");
                            }
                            else
                            {
                                ((Label)(this.Master.FindControl("lblErrorMsg"))).Text = "Employee Not Found.!";
                            }

                        }

                    }
                }
                else if (RoleId == "2")
                {
                    string Adminusername = ConfigurationManager.AppSettings["DefaultUsername"].ToString();
                    string AdminPassword = ConfigurationManager.AppSettings["DefaultLoginPassword"].ToString();

                    if (Adminusername == username && AdminPassword == Password)
                    {
                        Session["RoleId"] = RoleId;
                        Response.Redirect(RoleId + "/Home.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                //errMessage.InnerHtml = ex.InnerException.Message.ToString();
                Session["RoleId"] = "0";
            }

        }
    }
}