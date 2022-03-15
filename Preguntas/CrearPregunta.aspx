<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearPregunta.aspx.cs" Inherits="App_web_Q_and_A.CRUD_Preguntas.CrearPregunta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" ></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link href="Recursos/CSS/Estilos.css" rel="stylesheet" />
    <title>Hacer Pregunta</title>
</head>
<body>
    
    <form id="form1" class="form-control" runat="server">

        <div class="row"> 
            <div class="col-auto me-auto">
                 <asp:Label ID="lblBienvenida" runat="server" Text="" cssClass="h5"></asp:Label>     
            </div>           
            <div class="col-auto">
                  <asp:Button ID="BtnCerrar" cssClass="btn btn-danger" runat="server" Text="Cerrar Sesion" OnClick="BtnCerrar_Click"  />
            </div> 
          
        </div>     
         <div>
            <br/>
            <table class="">
                <tr>                    
                    <td>
                        <asp:Label ID="Label1" runat="server"  Text="Digite su pregunta:"></asp:Label>         

                        <asp:TextBox ID="txtPregunta" cssClass="form-control" runat="server" TextMode="MultiLine" Width="800px" MaxLength="500"></asp:TextBox>
                        <br />
                        <div class="row">
                            <asp:Label ID="lblError" runat="server" cssClass="alert-danger"></asp:Label>
                        </div>
                        <div class="row">
                           <asp:Label ID="lblExito" runat="server" cssClass="alert-success"></asp:Label>
                        </div>
                    </td>
                </tr>
                <br />
                <tr>                       
                    <td>
                        <br />
                        <asp:Button ID="BtnGuardar" cssClass="btn btn-dark" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" />
                        <asp:Button ID="BtnMenu" cssClass="btn btn-primary" runat="server" Text="Menu Principal" OnClick="BtnMenu_Click" />
                    </td>                   
                </tr>                
            </table>
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
