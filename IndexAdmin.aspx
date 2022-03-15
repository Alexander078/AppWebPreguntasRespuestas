<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexAdmin.aspx.cs" Inherits="App_web_Q_and_A.IndexAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" ></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link href="Recursos/CSS/Estilos.css" rel="stylesheet" />
    <title>Inicio (Admin)</title>
</head>
<body>
    <form id="form1" class="form-control" runat="server">
        
        <div class="row"> 
            <div class="col-auto me-auto">
                 <asp:Label ID="lblBienvenida" runat="server" Text="" cssClass="h5"></asp:Label>     
                 <asp:Label ID="Administrador" runat="server" Text="Administrador" cssClass="h5 alert-primary"></asp:Label>
            </div>           
            <div class="col-auto">
                  <asp:Button ID="BtnCerrar" cssClass="btn btn-danger" runat="server" Text="Cerrar Sesion" OnClick="BtnCerrar_Click"  />
            </div> 
          
        </div>                     
        <div class="">
            <div>
                <br />                
                <br />

                <table class="">
                    <tr>
                        <td class="">
                            
                        </td>
                    </tr>
                </table>           
            
            </div>                   
                    <br />                    
                    <asp:SqlDataSource ID="Preguntas" runat="server"
	                    ConnectionString="Data Source = DESKTOP-MSP315D; Initial Catalog =  Db_web_Q_and_A;User ID=sa; Password=12345"
	                    ProviderName="System.Data.SqlClient"
	                    SelectCommand="SP_GetPreguntas" SelectCommandType="StoredProcedure">

                    </asp:SqlDataSource>

                    <asp:GridView ID="GridView1" runat="server" class="table table-bordered table-condensed table-responsive table-hover"
	                    AutoGenerateColumns="false" DataKeyNames="Id"
	                    DataSourceID="Preguntas" OnRowCommand="GridView1_RowCommand" OnRowDataBound="OnRowDataBound">
	                    <Columns>
                            <asp:BoundField DataField="Id" HeaderText="#" />
		                    <asp:BoundField DataField="Pregunta" HeaderText="Pregunta" />
                            <asp:BoundField DataField="Usuario" HeaderText="Nickname" />
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />                              
		                    <asp:BoundField DataField="Estado" HeaderText="Estado" />		                    
		                                             
                            <asp:TemplateField >
                              <ItemTemplate>
                                 <asp:Button Text="Cerrar Pregunta" runat="server" cssClass="btn btn-success" CommandName="Cerrar" CommandArgument="<%# Container.DataItemIndex %>" />
                                 
                              </ItemTemplate>
                           </asp:TemplateField>                           

	                    </Columns>
                    </asp:GridView>
                 




        </div>
     </form>

   
</body>



</html>

<footer class="bg-dark text-center text-white">
 
  <!-- Copyright -->
  <div class="text-center p-3" style="background-color: rgba(0, 0, 0, 0.2);">
    © 2022 App Web Preguntas y Respuestas    
  </div>
  <!-- Copyright -->
</footer>
