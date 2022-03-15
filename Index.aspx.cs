using System;
using System.Web.UI.WebControls;

namespace App_web_Q_and_A
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["usuariologueado"] != null)
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

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Preguntas/CrearPregunta.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Responder")    
            {

                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = GridView1.Rows[rowIndex];      

                
                Session["idpregunta"] = row.Cells[0].Text;
                Session["pregunta"] = row.Cells[1].Text;
                Response.Redirect("~/Preguntas/ResponderPregunta.aspx");
            }
            else if (e.CommandName == "Respuestas")
            {

                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = GridView1.Rows[rowIndex];


                Session["idpregunta"] = row.Cells[0].Text;
                Session["pregunta"] = row.Cells[1].Text;
                Response.Redirect("~/Preguntas/VerRespuestas.aspx");
            }



        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TableCell statusCellEstado = e.Row.Cells[4];
                TableCell statusCellResponder = e.Row.Cells[5];
                if (statusCellEstado.Text == "Cerrada")
                {
                    statusCellResponder.Enabled=false;
                }
                
                
            }
        }
    }
}