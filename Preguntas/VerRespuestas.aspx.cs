using System;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace App_web_Q_and_A.Preguntas
{
    public partial class VerRespuestas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuariologueado"] != null)
            {
                string usuariologueado = Session["usuariologueado"].ToString();
                lblBienvenida.Text = "Ver Respuestas";
                lblpregunta.Text = "Pregunta: " + Session["pregunta"].ToString();

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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Like")
            {

                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = GridView1.Rows[rowIndex];


                Session["idrespuesta"] = row.Cells[0].Text;
                string Nlikes = row.Cells[4].Text;

                string conectar = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
                SqlConnection sqlConectar = new SqlConnection(conectar);
                SqlCommand cmd = new SqlCommand("SP_ModLikes", sqlConectar)
                {
                    CommandType = CommandType.StoredProcedure

                };
                cmd.Connection.Open();
                cmd.Parameters.Add("@IdResp", SqlDbType.Int).Value = Int32.Parse(Session["idrespuesta"].ToString());
                cmd.Parameters.Add("@NLikes", SqlDbType.Int).Value = Int32.Parse(Nlikes)+1;
                cmd.Parameters.Add("@IdUser", SqlDbType.Int).Value = Int32.Parse(Session["idusuariologueado"].ToString());
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Response.Redirect("VerRespuestas.aspx");
                }

                cmd.Connection.Close();

            }

        }

       protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            TableCell statusCellidrespuesta = e.Row.Cells[0];
            TableCell statusCellLike = e.Row.Cells[5];

                string conectar = ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;
            SqlConnection sqlConectar = new SqlConnection(conectar);
            SqlCommand cmd = new SqlCommand("SP_BuscarLike", sqlConectar)
            {
                CommandType = CommandType.StoredProcedure

            };
            cmd.Connection.Open();
            cmd.Parameters.Add("@IdResp", SqlDbType.Int).Value = Int32.Parse(statusCellidrespuesta.Text);
            cmd.Parameters.Add("@IdUser", SqlDbType.Int).Value = Int32.Parse(Session["idusuariologueado"].ToString());
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                    statusCellLike.Enabled = false;
                }

            cmd.Connection.Close();

                
            }
        }
    }
}