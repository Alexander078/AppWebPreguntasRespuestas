using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace App_web_Q_and_A
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (tbUsuario.Text == "" || tbPassword.Text == "")
            {
                lblError.Text = "Favor complete los campos";
            }
            else
            {
                lblError.Text = "";
                string patron = "App_Web_Q_and_A";
                string conectar = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                SqlConnection sqlConectar = new SqlConnection(conectar);
                SqlCommand cmd = new SqlCommand("SP_ValidarUsuario", sqlConectar)
                {
                    CommandType = CommandType.StoredProcedure

                };
                cmd.Connection.Open();
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = tbUsuario.Text;
                cmd.Parameters.Add("@Contrasenia", SqlDbType.VarChar, 50).Value = tbPassword.Text;
                cmd.Parameters.Add("@Patron", SqlDbType.VarChar, 50).Value = patron;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    //Agregamos una sesion de usuario
                    Session["usuariologueado"] = tbUsuario.Text;
                    Session["idusuariologueado"] = dr.GetInt32(0);

                    //lblError.Text = dr.GetInt32(0)+" " +dr.GetString(4);
                    if (dr.GetString(4) == "Admin")
                    {
                        Response.Redirect("IndexAdmin.aspx");
                    }
                    else if (dr.GetString(4) == "User")
                    {
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        Response.Redirect("Index.aspx");
                    }


                }
                else
                {
                    lblError.Text = "Error de Nickname o Contraseña";
                }
                cmd.Connection.Close();

             }

        }
    }
}