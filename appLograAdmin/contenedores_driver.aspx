<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contenedores_driver.aspx.cs" Inherits="appLograAdmin.contenedores_driver" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Logra SA</title>
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
	
	<!-- ================== BEGIN PAGE LEVEL STYLE ================== -->
	<link href="assets/plugins/jquery-smart-wizard/src/css/smart_wizard.css" rel="stylesheet" />
	<!-- ================== END PAGE LEVEL STYLE ================== -->
	
	<!-- ================== BEGIN PAGE LEVEL CSS STYLE ================== -->
	<link href="assets/plugins/jquery-jvectormap/jquery-jvectormap.css" rel="stylesheet" />
	<link href="assets/plugins/bootstrap-calendar/css/bootstrap_calendar.css" rel="stylesheet" />
	<link href="assets/plugins/gritter/css/jquery.gritter.css" rel="stylesheet" />
	<link href="assets/plugins/nvd3/build/nv.d3.css" rel="stylesheet" />

	<link href="assets/plugins/DataTables/media/css/dataTables.bootstrap.min.css" rel="stylesheet" />
	<link href="assets/plugins/DataTables/extensions/RowReorder/css/rowReorder.bootstrap.min.css" rel="stylesheet" />
	<link href="assets/plugins/DataTables/extensions/Responsive/css/responsive.bootstrap.min.css" rel="stylesheet" />
	<link href="assets/plugins/DataTables/extensions/Buttons/css/buttons.bootstrap.min.css" rel="stylesheet" />
	<link href="assets/plugins/DataTables/extensions/ColReorder/css/colReorder.bootstrap.min.css" rel="stylesheet" />
	<!-- ================== END PAGE LEVEL CSS STYLE ================== -->
	<link href="assets/plugins/jquery-smart-wizard/src/css/smart_wizard.css" rel="stylesheet" />
	<link href="assets/plugins/parsley/src/parsley.css" rel="stylesheet" />
	<!-- ================== BEGIN BASE JS ================== -->
	<script src="assets/plugins/pace/pace.min.js"></script>
	<!-- ================== END BASE JS ================== -->
	<script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB6XhmQ0TrlvdgfDu59q1lTyBp5NskGo7I&region=BO&callback=initMap"></script>
	 
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>

	 <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- begin #page-loader -->
	<div id="page-loader" class="fade show"><span class="spinner"></span></div>
	<!-- end #page-loader -->
	<!-- begin #page-container -->
	<div id="page-container" class="fade page-sidebar-fixed page-header-fixed">
		 
		<!-- begin #header -->
		<div id="header" class="header navbar-default" style="background-color:#0a3147">
			<!-- begin navbar-header -->
			
			<!-- end navbar-header -->
			
			<!-- begin header-nav -->
		
			
			<!-- end header navigation right -->
		</div>
		
		<asp:Label ID="lblSistema" runat="server" Visible="false" Text=""></asp:Label>
		<!-- end #header -->
		<link rel="stylesheet" href="dist/test-tube.css" />
    
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .ErrorControl
        {
            background-color: #FBE3E4;
            border: solid 1px Red;
        }
    </style>
	<script type="text/javascript">
        function WebForm_OnSubmit() {
            if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                for (var i in Page_Validators) {
                    try {
                        var control = document.getElementById(Page_Validators[i].controltovalidate);
                        if (!Page_Validators[i].isvalid) {
                            control.className = "form-control ErrorControl";
                        } else {
                            control.className = "form-control";
                        }
                    } catch (e) { }
                }
                return false;
            }
            return true;
        }
    </script>
	<!-- begin #content -->
		<div id="content" class="content">
			<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
			<asp:Label ID="lblDominio" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblCodigo" runat="server" Text="3" Visible="false"></asp:Label>
			<asp:Label ID="lblCodServidor" runat="server" Text="3" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
			  <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>

    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
										<img src="assets/img/logo/logo-admin.png" width="400" />
									
										<!-- begin page-header -->
											<h1 class="page-header">Contenedores conductores</h1>
											
											<%--Cliente:
											<asp:DropDownList ID="ddlClientes" class="form-control col-md-6" AutoPostBack="true" OnSelectedIndexChanged="ddlClientes_SelectedIndexChanged" OnDataBound="ddlClientes_DataBound" DataSourceID="odsClientesTodos" DataTextField="DESC_RAZONSOCIAL" DataValueField="cod_cliente" ForeColor="Black" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlClientes" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
											Codigo SICI:
											<asp:DropDownList ID="ddlServidor" class="form-control col-md-6"  DataSourceID="odsServidores" DataTextField="detalle" DataValueField="cod_cliente_sici" OnDataBound="ddlServidor_DataBound" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlServidor" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
											Fecha:
											<input id="fecha_salida" class="form-control col-12 col-md-2" onfocus="bloquear();" style="background:#ecf1fa" required type="date"><asp:HiddenField ID="hfFechaSalida" runat="server" />--%>
											
											<!-- end page-header -->
			<br />
											<!-- begin form-group row -->
			<asp:ObjectDataSource ID="odsServidores" runat="server" SelectMethod="PR_GET_SERVIDORES" TypeName="appLograAdmin.Clases.Dominios">
				</asp:ObjectDataSource>
											<div class="form-group row m-b-10">
											Servidor:
												
                            							<asp:DropDownList ID="ddlServidor" class="form-control col-md-3" AutoPostBack="true" OnSelectedIndexChanged="ddlServidor_SelectedIndexChanged"  style="border-color:#0a3147"  DataSourceID="odsServidores" DataTextField="descripcion" DataValueField="codigo" runat="server"></asp:DropDownList>
														<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Seleccione el servidor" ForeColor="Red" ControlToValidate="ddlServidor" InitialValue="SERVIDOR"  Font-Bold="True"></asp:RequiredFieldValidator>
													<%--<input type="text" class="form-control form-control-lg" placeholder="Email Address" required />--%>
												
											</div>
											<!-- end form-group row -->
			
											<!-- begin panel -->
											<div class="panel panel-inverse">
												<!-- begin panel-heading -->
												<div class="panel-heading>
													
													<h4 class="panel-title">Registros</h4>
												</div>
												<!-- end panel-heading -->
												
												<div class="table-responsive">
												<!-- begin panel-body -->
												<div class="panel-body">
										<div class="table-responsive">
														
												<table id="data-table-default" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-wrap">ENVASE</th>
														<%--	<th class="text-nowrap">TAMAÑO</th>
															<th class="text-nowrap">CLASE</th>--%>
														<%--	<th class="text-nowrap">porcentaje</th>
															<th class="text-nowrap">color</th>--%>
														<%--	<th class="text-nowrap">SALDO</th>--%>
															<th class="text-nowrap"></th>
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
															<td><asp:Label ID="lblcampo1" runat="server" Text='<%# "ENV.:" +Eval("ENBASE") + " TAM.:" + Eval("TAMANO") + " CLASE:" + Eval("CLASE") + " SALDO:" + Eval("SALDO") %>'></asp:Label></td>
														<%--	<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("TAMANO") %>'></asp:Label></td>
																<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("CLASE") %>'></asp:Label></td>--%>
															<%--	<td><asp:Label ID="Label3" runat="server" Text='<%# Eval("pocentaje") %>'></asp:Label></td>
																<td><asp:Label ID="Label4" runat="server" Text='<%# Eval("color") %>'></asp:Label></td>--%>
																<%--<td><asp:Label ID="Label5" runat="server" Text='<%# Eval("SALDO") %>'></asp:Label></td>--%>
																<td>
																	  <div class="tube offset-1" style='<%# Eval("test") %>'>
                                                                      <div class="shine"></div>
                                                                      <div class="body">
                                                                        <div class="liquid">
                                                                          <div class="percentage"></div>
                                                                        </div>
                                                                      </div>
                                                                      <div class="meter">
                                                                        <div>100</div>
                                                                        <div>80</div>
                                                                        <div>60</div>
                                                                        <div>40</div>
                                                                        <div>20</div>
                                                                      </div>
                                                                      <div class="bubbles">
                                                                        <div></div>
                                                                        <div></div>
                                                                        <div></div>
                                                                        <div></div>
                                                                        <div></div>
                                                                      </div>
                                                                    </div>
																</td>
														</tr>
														</ItemTemplate>
														</asp:Repeater>
														
													
													</tbody>
												</table>
											</div>
											<!-- end table-responsive -->
													</div>
										</div>
												</div>
        </asp:View>
		 <asp:View ID="View2" runat="server">
			
			
        </asp:View>
    </asp:MultiView>
		
		</div>
		</div>
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
	
	<!-- ================== BEGIN PAGE LEVEL JS ================== -->
	<script src="assets/plugins/d3/d3.min.js"></script>
	<script src="assets/plugins/nvd3/build/nv.d3.js"></script>
	<script src="assets/plugins/jquery-jvectormap/jquery-jvectormap.min.js"></script>
	<script src="assets/plugins/jquery-jvectormap/jquery-jvectormap-world-merc-en.js"></script>
	<script src="assets/plugins/bootstrap-calendar/js/bootstrap_calendar.min.js"></script>
	<%--<script src="assets/plugins/gritter/js/jquery.gritter.js"></script>--%>
	<script src="assets/js/demo/dashboard-v2.min.js"></script>
	<script src="assets/js/demo/form-wizards.demo.min.js"></script>
	<script src="assets/plugins/jquery-smart-wizard/src/js/jquery.smartWizard.js"></script>

	<script src="assets/plugins/DataTables/media/js/jquery.dataTables.js"></script>
	<script src="assets/plugins/DataTables/media/js/dataTables.bootstrap.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Responsive/js/dataTables.responsive.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/RowReorder/js/dataTables.rowReorder.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/ColReorder/js/dataTables.colReorder.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/dataTables.buttons.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/buttons.bootstrap.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/buttons.flash.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/jszip.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/pdfmake.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/vfs_fonts.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/buttons.html5.min.js"></script>
	<script src="assets/plugins/DataTables/extensions/Buttons/js/buttons.print.min.js"></script>
	<script src="assets/js/demo/table-manage-default.demo.min.js"></script>
	<script src="assets/js/demo/table-manage-buttons.demo.min.js"></script>
	<script src="assets/js/demo/table-manage-rowreorder.demo.min.js"></script>
	<script src="assets/js/demo/table-manage-colreorder.demo.min.js"></script>
	<!-- ================== END PAGE LEVEL JS ================== -->
	
	<script src="assets/plugins/parsley/dist/parsley.js"></script>
	<script src="assets/plugins/highlight/highlight.common.js"></script>
	<script src="assets/js/demo/render.highlight.js"></script>
	<script src="assets/plugins/jquery-smart-wizard/src/js/jquery.smartWizard.js"></script>
	<script src="assets/plugins/jquery-smart-wizard/src/js/jquery.smartWizard.js"></script>
	<script src="assets/js/demo/form-wizards-validation.demo.min.js"></script>
	<%--<script src="assets/js/demo/form-wizards-validation.demo.min.js"></script>--%>

	
	<script>
		$(document).ready(function() {
			App.init();
			DashboardV2.init();
            Highlight.init();
			FormWizard.init();
            
			TableManageDefault.init();
			TableManageRowReorder.init();
			TableManageButtons.init();
            TableManageResponsive.init();
			TableManageColReorder.init();
			
            
		});
        var map;
        function initMap() {
            map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: -34.397, lng: 150.644 },
                zoom: 8
            });
        }
    </script>
    </form>
</body>
</html>
