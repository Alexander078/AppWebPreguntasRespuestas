<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="App_web_Q_and_A.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" ></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link href="Recursos/CSS/Estilos.css" rel="stylesheet" />
    <title>Registro</title>
</head>
<body class="bg-light">
    <div class="wrapper">
        <div class="formcontent">
             <form id="formulario_Login" runat="server">
              <div class="form-control">
                  <div class="row">
                      <asp:Label class="h2" ID="lblBienvenida" runat="server" Text="Formulario de registro"></asp:Label>
                   </div>
                  <br />
                  <div>
                      <asp:Label ID="lblUsuario" runat="server" Text="Nickname:"></asp:Label>
                      <asp:TextBox ID="tbUsuario" cssClass="form-control" runat="server" placeholder="Nickname"></asp:TextBox>
                  </div>
                  <div>
                      <asp:Label ID="lblpassword" runat="server" Text="Password:"></asp:Label>
                      <asp:TextBox ID="tbPassword" TextMode="Password" cssClass="form-control" runat="server" placeholder="Password"></asp:TextBox>
                  </div>
                  <hr />
                  <div class="row">
                       <asp:Label ID="lblError" runat="server" cssClass="alert-danger"></asp:Label>
                  </div>
                  <div class="row">
                       <asp:Label ID="lblExito" runat="server" cssClass="alert-success"></asp:Label>
                  </div>
                  <br />
                  <div >
                      <asp:Button ID="BtnIngresar" cssClass="btn btn-primary btn-dark" runat="server" Text="Registrarse" OnClick="BtnIngresar_Click" />
                      <br />
                      <br />
                      <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Regresar</asp:HyperLink>
                      <br />
                  </div>

              </div>
             </form>
        </div>
    </div>
    
</body>
</html>

<footer class="bg-dark text-center text-white">
 
  <!-- Copyright -->
  <div class="text-center p-3" style="background-color: rgba(0, 0, 0, 0.2);">
    © 2022 App Web Preguntas y Respuestas    
  </div>
  <!-- Copyright -->
</footer>
