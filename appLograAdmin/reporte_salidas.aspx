<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="reporte_salidas.aspx.cs" Inherits="appLograAdmin.reporte_salidas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:ObjectDataSource ID="odsServidores" runat="server" SelectMethod="PR_GET_LISTAR_SICI" TypeName="appLograAdmin.Clases.Cliente_servidor_extra">
        <SelectParameters>
			<asp:ControlParameter ControlID="ddlClientes" Name="pV_COD_CLIENTE" />
			<asp:ControlParameter ControlID="lblCodServidor" Name="pV_COD_SERVIDOR" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsClientesTodos" runat="server" SelectMethod="PR_GET_CLIENTE_ALL" TypeName="appLograAdmin.Clases.Clientes">
		</asp:ObjectDataSource>
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
										
									
										<!-- begin page-header -->
											<h1 class="page-header">Reporte de Salidas por Rangos</h1>
											
											Cliente:
											<asp:DropDownList ID="ddlClientes" class="form-control col-md-6" AutoPostBack="true" OnSelectedIndexChanged="ddlClientes_SelectedIndexChanged" OnDataBound="ddlClientes_DataBound" DataSourceID="odsClientesTodos" DataTextField="DESC_RAZONSOCIAL" DataValueField="cod_cliente" ForeColor="Black" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlClientes" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
			Codigo SICI:
											<asp:DropDownList ID="ddlServidor" class="form-control col-md-6"  DataSourceID="odsServidores" DataTextField="detalle" DataValueField="cod_cliente_sici" OnDataBound="ddlServidor_DataBound" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlServidor" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
											Fecha inicio:
											<input id="fecha_salida" class="form-control col-12 col-md-2"  style="background:#ecf1fa" type="date"><asp:HiddenField ID="hfFechaSalida" runat="server" />
											Fecha fin:
											<input id="fecha_retorno" class="form-control col-12 col-md-2"  style="background:#ecf1fa" type="date"><asp:HiddenField ID="hfFechaRetorno" runat="server" />
											<!-- end page-header -->
			<br />
											<!-- begin form-group row -->
											<div class="form-group row m-b-10">
											
												<div class="col-md-6">
													<asp:Button ID="btnConsultar" class="btn btn-default btn-sm" OnClientClick="recuperarFechaSalida()" OnClick="btnConsultar_Click" runat="server" Text="Generar Reporte" />
													<asp:Button ID="btnExportarPDF" class="btn btn-default btn-sm" runat="server" Text="Exportar PDF" OnClick="btnExportarPDF_Click" />
													<asp:Button ID="btnExportarExcel" class="btn btn-default btn-sm" runat="server" Text="Exportar Excel" OnClick="btnExportarExcel_Click" />
													<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
												</div>
											</div>
											<!-- end form-group row -->
											<!-- begin panel -->
											<div class="panel panel-inverse">
												<!-- begin panel-heading -->
												<div class="panel-heading">
													<div class="panel-heading-btn">
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-redo"></i></a>
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
														<a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
													</div>
													<h4 class="panel-title">Registros</h4>
												</div>
												<!-- end panel-heading -->
												
												<div class="table-responsive">
												<!-- begin panel-body -->
												<div class="panel-body">
										<%--<div class="table-responsive">--%>
														<asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="true" OnPreRender="GridView_PreRender" CssClass="table table-striped" OnRowDataBound="GridView1_RowDataBound">

														</asp:GridView>
												<%--<table id="data-table-buttons" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-wrap">RECINTO</th>
															<th class="text-nowrap">FECHA_SALIDA</th>
															<th class="text-nowrap">SALIDA</th>
															<th class="text-nowrap">INGRESO</th>
															<th class="text-nowrap">CLIENTE</th>
															<th class="text-nowrap">CODIGO</th>
															<th class="text-nowrap">DESCRIPCION</th>
															<th class="text-nowrap">LOTE_MUNDO</th>
															<th class="text-nowrap">CANTIDAD</th>
															<th class="text-nowrap">ALMACEN</th>
															<th class="text-nowrap">UBICACION</th>
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
															<td><asp:Label ID="lblcampo1" runat="server" Text='<%# Eval("RECINTO") %>'></asp:Label></td>
															<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("FECHASALIDA") %>'></asp:Label></td>
																<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("SALIDA") %>'></asp:Label></td>
																<td><asp:Label ID="Label3" runat="server" Text='<%# Eval("INGRESO") %>'></asp:Label></td>
																<td><asp:Label ID="Label4" runat="server" Text='<%# Eval("CLIENTE") %>'></asp:Label></td>
																<td><asp:Label ID="Label5" runat="server" Text='<%# Eval("CODIGO") %>'></asp:Label></td>
																<td><asp:Label ID="Label6" runat="server" Text='<%# Eval("DESCRIPCION") %>'></asp:Label></td>
																<td><asp:Label ID="Label7" runat="server" Text='<%# Eval("LOTEMUNDO") %>'></asp:Label></td>
																<td><asp:Label ID="Label11" runat="server" Text='<%# Eval("CANTIDAD") %>'></asp:Label></td>
																<td><asp:Label ID="Label10" runat="server" Text='<%# Eval("ALMACEN") %>'></asp:Label></td>
																<td><asp:Label ID="Label9" runat="server" Text='<%# Eval("UBICACION") %>'></asp:Label></td>
														</tr>
														</ItemTemplate>
														</asp:Repeater>
														
													
													</tbody>
												</table>--%>
											</div>
											<!-- end table-responsive -->
													</div>
										</div>
        </asp:View>
		 <asp:View ID="View2" runat="server">
			
			
        </asp:View>
    </asp:MultiView>
		<!-- end #content -->
	<script type="text/javascript">

        function recuperarFechaSalida() {

            document.getElementById('<%=hfFechaSalida.ClientID%>').value = document.getElementById('fecha_salida').value;
                document.getElementById('<%=hfFechaRetorno.ClientID%>').value = document.getElementById('fecha_retorno').value;
        }
        function setearFechaSalida() {

            document.getElementById('fecha_salida').value = document.getElementById('<%=hfFechaSalida.ClientID%>').value;
            document.getElementById('fecha_retorno').value = document.getElementById('<%=hfFechaRetorno.ClientID%>').value;
        }
    </script>
		<script>
            var handleDataTableButtons = function () {
                "use strict";
                0 !== $('#<%= GridView1.ClientID %>').length &&
                $('#<%= GridView1.ClientID %>').DataTable({
            dom: "Bfrtip",
            buttons: [{
                extend: "copy",
                className: "btn-sm"
            }, {
                extend: "csv",
                className: "btn-sm"
            }, {
                extend: "excel",
                className: "btn-sm"
            }, {
                extend: "pdf",
                className: "btn-sm"
            }, {
                extend: "print",
                className: "btn-sm"
            }],
            responsive: !0
        })
    },
    TableManageButtons = function () {
        "use strict";
        return {
            init: function () {
                handleDataTableButtons()
            }
        }
    }();
        </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= GridView1.ClientID %>').dataTable();
        });
        TableManageButtons.init();
    </script>	
		</div>
		<!-- end #content -->
</asp:Content>
