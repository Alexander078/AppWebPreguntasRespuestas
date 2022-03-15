using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace App_web_Q_and_A
{
    public partial class Registro : System.Web.UI.Page
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
                lblExito.Text = "";
                string patron = "App_Web_Q_and_A";
                string conectar = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                SqlConnection sqlConectar = new SqlConnection(conectar);
                SqlCommand cmd = new SqlCommand("SP_BuscarNickname", sqlConectar)
                {
                    CommandType = CommandType.StoredProcedure

                };
                cmd.Connection.Open();
                cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = tbUsuario.Text;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lblError.Text = "Nickname '"+ dr.GetString(0) + "' ya existe, intente con otro";
                    cmd.Connection.Close();

                }
                else
                {
                    cmd.Connection.Close();
                    cmd = new SqlCommand("SP_AgregarUsuario", sqlConectar)
                    {
                        CommandType = CommandType.StoredProcedure

                    };
                    cmd.Connection.Open();
                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = tbUsuario.Text;
                    cmd.Parameters.Add("@Contrasenia", SqlDbType.VarChar, 50).Value = tbPassword.Text;
                    cmd.Parameters.Add("@Patron", SqlDbType.VarChar, 50).Value = patron;
                    cmd.Parameters.Add("@IdRol", SqlDbType.Int, 50).Value = 2;
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        lblExito.Text = "Registro de Nickname Exitoso ";
                    }
                    else
                    {
                        lblError.Text = "No se pudo registrar el nuevo Nickname" + dr.GetInt32(0);
                    }
                    cmd.Connection.Close();
                }
            }

        }
    }
}