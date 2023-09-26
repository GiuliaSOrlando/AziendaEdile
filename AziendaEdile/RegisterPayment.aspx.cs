using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AziendaEdile
{
    public partial class RegisterPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopolaDdlDipendenti();
            }
        }

        protected void PopolaDdlDipendenti()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AziendaEdileDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand queryPagamenti = new SqlCommand("SELECT ID, CONCAT(Nome, ' ', Cognome) AS NomeCompleto FROM Dipendenti", conn);
                SqlDataReader reader = queryPagamenti.ExecuteReader();
                while (reader.Read())
                {
                    ListItem item = new ListItem(reader["NomeCompleto"].ToString(), reader["ID"].ToString());
                    ddlDipendenti.Items.Add(item);
                }

            }
            catch (Exception ex) { Response.Write("An error occurred: " + ex.Message); }
            finally { conn.Close(); }
        }

        protected void RegisterPayment_Button_Click(object sender, EventArgs e)
        {
            int dipendenteID = Convert.ToInt32(ddlDipendenti.SelectedValue);
            string periodopagamento = periodopagamento_Input.Text;
            decimal ammontare = Convert.ToDecimal(ammontare_Input.Text);
            string tipopagamento = ddlTipoPagamento.SelectedValue;

            string connectionString = ConfigurationManager.ConnectionStrings["AziendaEdileDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand queryPagamenti = new SqlCommand("INSERT INTO Pagamenti(IDDipendente, PeriodoPagamento, Ammontare, Tipo) VALUES (@IDDipendente, @PeriodoPagamento, @Ammontare, @Tipo)",conn);
                queryPagamenti.Parameters.AddWithValue("@IDDipendente", dipendenteID);
                queryPagamenti.Parameters.AddWithValue("@PeriodoPagamento", periodopagamento);
                queryPagamenti.Parameters.AddWithValue("@Ammontare", ammontare);
                queryPagamenti.Parameters.AddWithValue("@Tipo", tipopagamento);

                int inserimentoeffettuato = queryPagamenti.ExecuteNonQuery();

                if (inserimentoeffettuato > 0)
                {
                    alertInserimento.Visible = true;
                    lblMessaggio.Text = "Pagamento effettuato con successo";
                }
            }
            catch (Exception ex) { Response.Write("An error occurred: " + ex.Message); }
            finally { conn.Close(); }
        }
    }
}