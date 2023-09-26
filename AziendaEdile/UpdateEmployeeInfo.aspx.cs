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
    public partial class UpdateEmployeeInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int dipendenteID = Convert.ToInt32(Request.QueryString["ID"]);
                    CaricaDettagliDipendente(dipendenteID);
                }
                else
                {
                    Response.Redirect("Default.aspx"); 
                }
            }
        }

        protected void CaricaDettagliDipendente(int dipendenteID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AziendaEdileDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand queryVisualizzaDip = new SqlCommand("SELECT * FROM Dipendenti WHERE ID = @ID", conn);
                queryVisualizzaDip.Parameters.AddWithValue("@ID", dipendenteID);
                SqlDataReader reader = queryVisualizzaDip.ExecuteReader();

                if (reader.Read())
                {
                    ID_Hidden.Value = reader["ID"].ToString();
                    Nome_Input.Text = reader["Nome"].ToString();
                    Cognome_Input.Text = reader["Cognome"].ToString();
                    Indirizzo_Input.Text = reader["Indirizzo"].ToString();
                    CodiceFiscale_Input.Text = reader["CodiceFiscale"].ToString();
                    Coniugato_Input.Checked = Convert.ToBoolean(reader["Coniugato"]);
                    NumeroFigli_Input.Text = reader["NumeroFigli"].ToString();
                    Mansione_Input.Text = reader["Mansione"].ToString();
                }
                else
                {
                    Response.Write("Dipendente non trovato.");
                }

                reader.Close();
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

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ID_Hidden.Value))
            {
                int dipendenteID = Convert.ToInt32(ID_Hidden.Value);
                string nome = Nome_Input.Text;
                string cognome = Cognome_Input.Text;
                string indirizzo = Indirizzo_Input.Text;
                string codiceFiscale = CodiceFiscale_Input.Text;
                bool coniugato = Coniugato_Input.Checked;
                int numeroFigli = Convert.ToInt32(NumeroFigli_Input.Text);
                string mansione = Mansione_Input.Text;

                string connectionString = ConfigurationManager.ConnectionStrings["AziendaEdileDB"].ConnectionString.ToString();
                SqlConnection conn = new SqlConnection(connectionString);

                try
                {
                    conn.Open();
                    SqlCommand queryAggiornaDip = new SqlCommand("UPDATE Dipendenti SET Nome = @Nome, Cognome = @Cognome, Indirizzo = @Indirizzo, CodiceFiscale = @CodiceFiscale, Coniugato = @Coniugato, NumeroFigli = @NumeroFigli, Mansione = @Mansione WHERE ID = @ID", conn);
                    queryAggiornaDip.Parameters.AddWithValue("@ID", dipendenteID);
                    queryAggiornaDip.Parameters.AddWithValue("@Nome", nome);
                    queryAggiornaDip.Parameters.AddWithValue("@Cognome", cognome);
                    queryAggiornaDip.Parameters.AddWithValue("@Indirizzo", indirizzo);
                    queryAggiornaDip.Parameters.AddWithValue("@CodiceFiscale", codiceFiscale);
                    queryAggiornaDip.Parameters.AddWithValue("@Coniugato", coniugato);
                    queryAggiornaDip.Parameters.AddWithValue("@NumeroFigli", numeroFigli);
                    queryAggiornaDip.Parameters.AddWithValue("@Mansione", mansione);

                    int result = queryAggiornaDip.ExecuteNonQuery();

                    if (result > 0)
                    {
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Nessuna modifica effettuata.";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Errore durante il salvataggio delle modifiche: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        }
}