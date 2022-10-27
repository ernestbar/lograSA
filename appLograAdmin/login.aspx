<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="appLograAdmin.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<meta charset="utf-8" />
	<title>Ingreso Logra SA</title>
	<meta content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" name="viewport" />
	<meta content="" name="description" />
	<meta content="" name="author" />
	
	<!-- ================== BEGIN BASE CSS STYLE ================== -->
	<link href="http://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700" rel="stylesheet" />
	<link href="assets/plugins/jquery-ui/jquery-ui.min.css" rel="stylesheet" />
	<link href="assets/plugins/bootstrap/4.1.3/css/bootstrap.min.css" rel="stylesheet" />
	<link href="assets/plugins/font-awesome/5.3/css/all.min.css" rel="stylesheet" />
	<link href="assets/plugins/animate/animate.min.css" rel="stylesheet" />
	<link href="assets/css/default/style.min.css" rel="stylesheet" />
	<link href="assets/css/default/style-responsive.min.css" rel="stylesheet" />
	<link href="assets/css/default/theme/red.css" rel="stylesheet" id="theme" />
	<!-- ================== END BASE CSS STYLE ================== -->
	
	<!-- ================== BEGIN BASE JS ================== -->
	<script src="assets/plugins/pace/pace.min.js"></script>
	<!-- ================== END BASE JS ================== -->
</head>
<body class="pace-top bg-white">
	<form runat="server" defaultbutton="btnIngresar">
	<!-- begin #page-loader -->
	<div id="page-loader" class="fade show"><span class="spinner"></span></div>
	<!-- end #page-loader -->
	
	<!-- begin #page-container -->
	<div id="page-container" class="fade">
		<!-- begin login -->
		<div class="login login-with-news-feed">
			<!-- begin news-feed -->
			<div class="news-feed">
				<div class="news-image" style="background-image: url(assets/img/login-bg/fondo_login.jpg)"></div>
				<div class="news-caption">
					<h4 class="caption-title"><b>LOGRA</b> S.A.</h4>
					<p>
						Logistica Integral de Carga.
					</p>
				</div>
			</div>
			<!-- end news-feed -->
			<!-- begin right-content -->
			<div class="right-content">
				<!-- begin login-header -->
				<div class="login-header">
					<div>
                        <img src="assets/img/logo/logo-admin.png" width="400" />
						<%--<h1><span class="logo"></span> <b>Ingreso</b> Logra SA</h1>--%>
						<%--<small>responsive bootstrap 3 admin template</small>--%>
					</div>
					<div class="icon">
						<i class="fa fa-sign-in"></i>
					</div>
				</div>
				<!-- end login-header -->
				<asp:ObjectDataSource ID="odsServidores" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appLograAdmin.Clases.Dominios">
					<SelectParameters>
						<asp:Parameter Name="pV_DOMINIO" DefaultValue="SERVIDORES" />
					</SelectParameters>
				</asp:ObjectDataSource>
				<!-- begin login-content -->
				<div class="login-content">
						<div class="form-group m-b-15">
						<div class="form-group m-b-15">
                            	<asp:DropDownList ID="ddlServidor" class="form-control col-md-12"  style="border-color:#0a3147"  DataSourceID="odsServidores" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlServidor_DataBound" runat="server"></asp:DropDownList>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Seleccione el servidor" ForeColor="Red" ControlToValidate="ddlServidor" InitialValue="SERVIDOR"  Font-Bold="True"></asp:RequiredFieldValidator>
							<%--<input type="text" class="form-control form-control-lg" placeholder="Email Address" required />--%>
						</div>
                            <asp:TextBox ID="txtUsuario" class="form-control form-control-lg" BorderColor="#0a3147" placeholder="Nombre usuario" required runat="server"></asp:TextBox>
							<%--<input type="text" class="form-control form-control-lg" placeholder="Email Address" required />--%>
						</div>
						<div class="form-group m-b-15">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" BorderColor="#0a3147" class="form-control form-control-lg" placeholder="Password" ></asp:TextBox>
							<%--<input type="password" class="form-control form-control-lg" placeholder="Password" required />--%>
						</div>
						
						<div class="login-buttons">
                            <asp:Button ID="btnIngresar" OnClick="btnIngresar_Click" class="btn btn-info btn-block btn-lg" runat="server" Text="Ingresar" />
							<%--<button type="submit" class="btn btn-success btn-block btn-lg">Sign me in</button>--%>
						</div>
						<div class="form-group m-b-15">
                            <asp:Label ID="lblAviso" runat="server" ForeColor="Red" Text=""></asp:Label>
						</div><br />
					<div class="login-buttons">
                            <asp:Button ID="btnReset" OnClick="btnReset_Click" class="btn btn-default btn-block btn-lg" OnClientClick="return confirm('Seguro que desea resetera su password??? de ser asi el nuevo password se le enviara a su correo electronico')" runat="server" Text="Olvide la Contraseña" />
							<%--<button type="submit" class="btn btn-success btn-block btn-lg">Sign me in</button>--%>
						</div>
						<%--<div class="m-t-20 m-b-40 p-b-40 text-inverse">
							Not a member yet? Click <a href="register_v3.html" class="text-success">here</a> to register.
						</div>--%>
						<hr />
						<p class="text-center text-grey-darker">
							&copy; LOGRA SA All Right Reserved 2022
						</p>
					
				</div>
				<!-- end login-content -->
			</div>
			<!-- end right-container -->
		</div>
		<!-- end login -->

		
	</div>
	<!-- end page container -->
	
	<!-- ================== BEGIN BASE JS ================== -->
	<script src="assets/plugins/jquery/jquery-3.3.1.min.js"></script>
	<script src="assets/plugins/jquery-ui/jquery-ui.min.js"></script>
	<script src="assets/plugins/bootstrap/4.1.3/js/bootstrap.bundle.min.js"></script>
	<!--[if lt IE 9]>
		<script src="assets/crossbrowserjs/html5shiv.js"></script>
		<script src="assets/crossbrowserjs/respond.min.js"></script>
		<script src="assets/crossbrowserjs/excanvas.min.js"></script>
	<![endif]-->
	<script src="assets/plugins/slimscroll/jquery.slimscroll.min.js"></script>
	<script src="assets/plugins/js-cookie/js.cookie.js"></script>
	<script src="assets/js/theme/default.min.js"></script>
	<script src="assets/js/apps.min.js"></script>
	<!-- ================== END BASE JS ================== -->

	<script>
		$(document).ready(function() {
			App.init();
		});
    </script>
		</form>
</body>
</html>
