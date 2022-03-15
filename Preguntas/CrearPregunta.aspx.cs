using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace App_web_Q_and_A.CRUD_Preguntas
{
    public partial class CrearPregunta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuariologueado"] != null)
            {
                string usuariologueado = Session["usuariologueado"].ToString();
                lblBienvenida.Text = "Hacer una pregunta";

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

        protected void BtnMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Index.aspx");
           
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (txtPregunta.Text == "" )
            {
                lblError.Text = "Favor complete el enunciado de la pregunta";
            }
            else
            {               
                lblError.Text = "";
                lblExito.Text = "";
                string conectar = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                SqlConnection sqlConectar = new SqlConnection(conectar);
                SqlCommand cmd = new SqlCommand("SP_AgregarPregunta", sqlConectar)
                {
                    CommandType = CommandType.StoredProcedure

                };
                cmd.Connection.Open();
                cmd.Parameters.Add("@Pregunta", SqlDbType.VarChar, 500).Value = txtPregunta.Text;
                cmd.Parameters.Add("@IdUser", SqlDbType.Int).Value = Int32.Parse(Session["idusuariologueado"].ToString());
                SqlDataReader dr = cmd.ExecuteReader();               

                    if (dr.Read())
                    {
                        lblExito.Text = "Se Registro la pregunta exitosamente.";
                    }
                    else
                    {
                        lblError.Text = "No se pudo registrar la pregunta" + dr.GetInt32(0);
                    }
                    cmd.Connection.Close();
            }
        }
    }
}