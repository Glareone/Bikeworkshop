using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using log4net;

namespace Training.Workshop.ASP.Client
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            log4net.ILog logger = log4net.LogManager.GetLogger(typeof(_Default));
            try
            {
                logger.Info("Open Connection ");

                var connection = new SqlConnection("Data Source=KOLESNIKOV7;Initial Catalog=Training.Workshop.SQLDatabase;Integrated Security=True;");

                logger.Info("We opened and closed the connection to the database");
                connection.Close();
            }
            catch
            {
                throw new Exception("Sql connection cant reached");
            }
            
        }
    }
}
