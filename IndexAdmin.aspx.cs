using System;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace App_web_Q_and_A
{
    public partial class IndexAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuariologueado"] != null)
            {
                string usuariologueado = Session["usuariologueado"].ToString();
                lblBienvenida.Text = "Bienvenido/a " + usuariologueado;

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void BtnCerrar_Click(object sender, EventArgs e)
        {
            Session.Remove("usuariologueado");
            Response.Redirect("Login.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Cerrar")
            {

                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = GridView1.Rows[rowIndex];


                Session["idpregunta"] = row.Cells[0].Text;
                Session["pregunta"] = row.Cells[1].Text;

                string conectar = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                SqlConnection sqlConectar = new SqlConnection(conectar);
                SqlCommand cmd = new SqlCommand("SP_Mod_State_Preg", sqlConectar)
                {
                    CommandType = CommandType.StoredProcedure

                };
                cmd.Connection.Open();
                cmd.Parameters.Add("@IdPreg", SqlDbType.Int).Value = Int32.Parse(Session["idpregunta"].ToString());
                cmd.Parameters.Add("@Estado", SqlDbType.VarChar,1).Value = 'I';
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Response.Redirect("IndexAdmin.aspx");
                }
               
                cmd.Connection.Close();
                

            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell statusCellEstado = e.Row.Cells[4];
                TableCell statusCellCerrar = e.Row.Cells[5];
                if (statusCellEstado.Text == "Cerrada")
                {
                    statusCellCerrar.Text = "";
                    

                }
               


            }
        }

    }
}