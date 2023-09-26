using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AziendaEdile
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CaricaTabellaDipendenti();
                CaricaTabellaPagamenti();
            }
        }

        protected void CaricaTabellaDipendenti()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AziendaEdileDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand queryVisualizzaDip = new SqlCommand("SELECT * FROM Dipendenti", conn);
                SqlDataReader reader = queryVisualizzaDip.ExecuteReader();

                    GridViewDipendenti.DataSource = reader;
                    GridViewDipendenti.DataBind();

                reader.Close();

            }
            catch (Exception ex) { Response.Write("An error occurred: " + ex.Message); }
            finally { conn.Close(); }
        }

        protected void CaricaTabellaPagamenti()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AziendaEdileDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand queryVisualizzaPag = new SqlCommand("SELECT P.IdPagamento, D.Nome AS NomeDipendente, D.Cognome AS CognomeDipendente, P.PeriodoPagamento, P.Ammontare, P.Tipo FROM Pagamenti P INNER JOIN Dipendenti D ON P.IDDipendente = D.ID", conn);
                SqlDataReader reader = queryVisualizzaPag.ExecuteReader();

                GridViewPagamenti.DataSource = reader;
                GridViewPagamenti.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            Button btnModifica = (Button)sender;
            string dipendenteID = btnModifica.CommandArgument;

            Response.Redirect("UpdateEmployeeInfo.aspx?ID=" + dipendenteID);
        }
    }
}