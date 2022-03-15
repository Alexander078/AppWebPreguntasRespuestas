using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace App_web_Q_and_A.Preguntas
{
    public partial class ResponderPregunta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuariologueado"] != null)
            {
                string usuariologueado = Session["usuariologueado"].ToString();
                lblBienvenida.Text = "Responder pregunta";
                lblpregunta.Text = "Pregunta: "+ Session["pregunta"].ToString();

            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void BtnCerrar_Click(object sender, EventArgs e)
        {
            Session.Remove("usuariologueado");
            Response.Redirect("~/Login.aspx");
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (txtPregunta.Text == "")
            {
                lblError.Text = "Favor complete su respuesta";
            }
            else
            {
                lblError.Text = "";
                lblExito.Text = "";
                string conectar = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                SqlConnection sqlConectar = new SqlConnection(conectar);
                SqlCommand cmd = new SqlCommand("SP_AgregarRespuesta", sqlConectar)
                {
                    CommandType = CommandType.StoredProcedure

                };
                cmd.Connection.Open();
                cmd.Parameters.Add("@Respuesta", SqlDbType.VarChar, 500).Value = txtPregunta.Text;
                cmd.Parameters.Add("@IdPreg", SqlDbType.Int).Value = Int32.Parse(Session["idpregunta"].ToString());
                cmd.Parameters.Add("@IdUser", SqlDbType.Int).Value = Int32.Parse(Session["idusuariologueado"].ToString());
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lblExito.Text = "Se Registro la respuesta exitosamente.";
                }
                else
                {
                    lblError.Text = "No se pudo registrar la respuesta" + dr.GetInt32(0);
                }
                cmd.Connection.Close();
            }
        }

        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Index.aspx");
        }
    }
}