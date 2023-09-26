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
    public partial class RegisterEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterEmployee_Button_Click(object sender, EventArgs e)
        {
            string nome = Nome_Input.Text;
            string cognome = Cognome_Input.Text;
            string indirizzo = Indirizzo_Input.Text;
            string codicefiscale = CF_Input.Text;
            bool coniugato = Coniugato_Chk.Checked;
            int numerofigli;
            if(!int.TryParse(NumeroFigli_Input.Text, out numerofigli))
            {
                lblMessaggio.Text = "Inserisci un numero valido";
                return;
            }
            string mansione = Mansione_Input.Text;


            string connectionString = ConfigurationManager.ConnectionStrings["AziendaEdileDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand queryDipendenti = new SqlCommand("INSERT INTO Dipendenti(Nome, Cognome, Indirizzo, CodiceFiscale, Coniugato, NumeroFigli, Mansione) VALUES (@Nome, @Cognome, @Indirizzo, @CodiceFiscale, @Coniugato, @NumeroFigli, @Mansione)", conn);
                queryDipendenti.Parameters.AddWithValue("@Nome", nome);
                queryDipendenti.Parameters.AddWithValue("@Cognome", cognome);
                queryDipendenti.Parameters.AddWithValue("@Indirizzo", indirizzo);
                queryDipendenti.Parameters.AddWithValue("@CodiceFiscale", codicefiscale);
                queryDipendenti.Parameters.AddWithValue("@Coniugato", coniugato);
                queryDipendenti.Parameters.AddWithValue("@NumeroFigli", numerofigli);
                queryDipendenti.Parameters.AddWithValue("@Mansione", mansione);

                int inserimentoeffettuato = queryDipendenti.ExecuteNonQuery();

                if (inserimentoeffettuato > 0)
                {
                    alertInserimento.Visible = true;
                    lblMessaggio.Text = "Inserimento effettuato con successo";
                }
            }
            catch (Exception ex) { Response.Write("An error occurred: " + ex.Message); }
            finally { conn.Close(); }
        }
    }
}