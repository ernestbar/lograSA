<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="dashboard_reportes.aspx.cs" Inherits="appLograAdmin.dashboard_reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<!-- ================== BEGIN PAGE LEVEL STYLE ================== -->
    <link href='<%= Page.ResolveUrl("~/assets/plugins/nvd3/build/nv.d3.css")%>'" rel="stylesheet" />
    <!-- ================== END PAGE LEVEL STYLE ================== -->

    <!-- ================== BEGIN PAGE LEVEL JS ================== -->
	<script src='<%= Page.ResolveUrl("~/assets/plugins/d3/d3.min.js")%>'></script>
	<script src='<%= Page.ResolveUrl("~/assets/plugins/nvd3/build/nv.d3.js")%>'></script>
    <!-- ================== END PAGE LEVEL JS ================== -->

    <script type="text/javascript">
        // Gráfico de Barras
        function graficoBarras() {
            var hfgBarraSerie1 = document.getElementById('<%=hfgBarraSerie1.ClientID%>');
            <%--var hfgBarraSerie2 = document.getElementById('<%=hfgBarraSerie2.ClientID%>');--%>
            var datos = '[{ key: "Ingresos", "color": "#418CF0", values:' + hfgBarraSerie1.value +
                        ' }];';

            // Convertir cadena a objecto
            datos = eval(datos);

            nv.addGraph(function () {
                var chart = nv.models.multiBarChart()
                  .x(function (d) {
                      return d.nombre; // Configurar eje x para usar "nombre" de json
                  })
                  .y(function (d) {
                      return d.valor; // Configurar eje y para usar "valor" de json
                  }).margin({ top: 30, right: 20, bottom: 50, left: 85 }) // Añadir CSS para el margen
                  .showControls(false) // Desactivar control conmutable
                  .stacked(false); // Forzar modo normal de barra

                chart.xAxis.axisLabel('MESES'); // Etiqueta del eje horizontal
                chart.yAxis.tickFormat(d3.format('0f')); // Redondear valores del eje Y

                d3.select('#graficoBarras svg') // Seleccionar el elemento HTML por su id
                  .datum(datos) // Enviar los datos
                  .transition().duration(500) // Velocidad de transición
                  .call(chart); // Llamar y renderizar

                nv.utils.windowResize(chart.update); // Inicializar listener para cambio de tamaño de la ventana de manera que el gráfico responda y cambie su ancho

                return;
            });
        }
        function graficoBarras2() {
            var hfgBarraSerie2 = document.getElementById('<%=hfgBarraSerie2.ClientID%>');
            <%--var hfgBarraSerie2 = document.getElementById('<%=hfgBarraSerie2.ClientID%>');--%>
            var datos = '[{ key: "Salidas", "color": "#418CF0", values:' + hfgBarraSerie2.value +
                        ' }];';

            // Convertir cadena a objecto
            datos = eval(datos);

            nv.addGraph(function () {
                var chart = nv.models.multiBarChart()
                    .x(function (d) {
                        return d.nombre; // Configurar eje x para usar "nombre" de json
                    })
                    .y(function (d) {
                        return d.valor; // Configurar eje y para usar "valor" de json
                    }).margin({ top: 30, right: 20, bottom: 50, left: 85 }) // Añadir CSS para el margen
                    .showControls(false) // Desactivar control conmutable
                    .stacked(false); // Forzar modo normal de barra

                chart.xAxis.axisLabel('MESES'); // Etiqueta del eje horizontal
                chart.yAxis.tickFormat(d3.format('0f')); // Redondear valores del eje Y

                d3.select('#graficoBarras2 svg') // Seleccionar el elemento HTML por su id
                    .datum(datos) // Enviar los datos
                    .transition().duration(500) // Velocidad de transición
                    .call(chart); // Llamar y renderizar

                nv.utils.windowResize(chart.update); // Inicializar listener para cambio de tamaño de la ventana de manera que el gráfico responda y cambie su ancho

                return;
            });
        }
        // Gráfico de Líneas
        function graficoLineas() {
            var hfgLineaSerie1 = document.getElementById('<%=hfgLineaSerie1.ClientID%>');
            var datos = '[{ key: "Financiero", "color": "#418CF0", values:' + hfgLineaSerie1.value +
                        ' }];';

            var nombreProy =('<%= NombreProyJSon() %>');
            var codigoProy =('<%= CodigoProyJSon() %>');

            nombreProy = eval(nombreProy);
            codigoProy = eval(codigoProy);

            // Convertir cadena a objecto
            datos = eval(datos);

            nv.addGraph(function () {
                var chart = nv.models.lineChart() // Inicializar objeto lineChart
                    .useInteractiveGuideline(true) // Habilitar guía interactiva (tooltips) 
                    .x(function (d) { return d.x })
                    .y(function (d) { return d.y })
                    .showLegend(true)
                    .showYAxis(true)
                    .showXAxis(true)
                    .margin({ top: 30, right: 150, bottom: 200, left: 85 });
                chart.xAxis
                    .axisLabel('Proyecto') // Establecer la etiqueta del eje X (Vertical)
                    .rotateLabels(-60) // Rotar etiquetas del eje X
                    .tickValues(codigoProy)
                    .tickFormat(function (d) {
                        return nombreProy[d]
                    });
                chart.yAxis
                    .axisLabel('Porcentaje') // Establecer la etiqueta  del eje Y (Vertical)
                    .tickFormat(d3.format('.02f')); // Formato de número redondeado
                d3.select('#graficoLineas svg') // Seleccionar el elemento HTML por su id
                    .datum(datos) // Enviar datos JSON
                    .transition().duration(500) // Velocidad de transición
                    .style("font-size", "10px")
                    .call(chart); // Llamar y renderizar
                nv.utils.windowResize(chart.update); // Inicializar listener para cambio de tamaño de la ventana de manera que el gráfico responda y cambie su ancho
                return;
            });
        }
    </script>

    <style type="text/css">
        .graficoBarras {
            height: 500px;
        }
        .graficoLineas {
            height: 500px;
        }
    </style>
     	<asp:ObjectDataSource ID="odsGestion" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appLograAdmin.Clases.Dominios">
        <SelectParameters>
            <asp:Parameter Name="pV_DOMINIO" DefaultValue="GESTION" />
        </SelectParameters>
    </asp:ObjectDataSource>
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
											<h1 class="page-header">DASHBOARD DEL SISTEMA</h1>
											
											Cliente:
											<asp:DropDownList ID="ddlClientes" class="form-control col-md-6"  OnDataBound="ddlClientes_DataBound" DataSourceID="odsClientesTodos" DataTextField="DESC_RAZONSOCIAL" DataValueField="cod_cliente" ForeColor="Black" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlClientes" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
											Gestion:
											<asp:DropDownList ID="ddlGestion" class="form-control col-md-6"  DataSourceID="odsGestion" DataTextField="DESCRIPCION" DataValueField="CODIGO" OnDataBound="ddlGestion_DataBound" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlGestion" InitialValue="SELECCIONAR GESTION"  Font-Bold="True"></asp:RequiredFieldValidator>
											<%--Fecha:
											<input id="fecha_salida" class="form-control col-12 col-md-2"  style="background:#ecf1fa" required type="date"><asp:HiddenField ID="hfFechaSalida" runat="server" />
											Tipo Rerporte:
											<asp:RadioButtonList ID="rblTipoReporte" CssClass="form-control" RepeatDirection="Horizontal"  runat="server">
												<asp:ListItem>RESUMEN</asp:ListItem>
												<asp:ListItem>DETALLADO</asp:ListItem>
											</asp:RadioButtonList>--%>
											<!-- end page-header -->
			<br />
											<!-- begin form-group row -->
											<div class="form-group row m-b-10">
											
												<div class="col-md-6">
													<asp:Button ID="btnConsultar" class="btn btn-default btn-sm" OnClientClick="recuperarFechaSalida()" OnClick="btnConsultar_Click" runat="server" Text="Mostrar Dashboards" />
													<%--<asp:Button ID="btnExportarPDF" class="btn btn-default btn-sm" runat="server" Text="Exportar PDF" OnClick="btnExportarPDF_Click" />
													<asp:Button ID="btnExportarExcel" class="btn btn-default btn-sm" runat="server" Text="Exportar Excel" OnClick="btnExportarExcel_Click" />--%>
													<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
												</div>
											</div>
											<!-- end form-group row -->
            <asp:Panel ID="pnlDashboard" runat="server" Visible="false">
            <!-- begin row -->
            <div class="row">
                <!-- begin col-10 -->
                <div class="col-lg-12">
                    <div class="panel panel-inverse">
                        <!-- begin panel-heading -->
                        <div class="panel-heading">
                            <div class="panel-heading-btn">
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-redo"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
                            </div>
                            <h4 class="panel-title">DASHBOARD INGRESOS</h4>
                            <asp:HiddenField ID="hfgBarraSerie1" runat="server" />
                           <%-- <asp:HiddenField ID="hfgBarraSerie2" runat="server" />--%>
                       </div>
                        <!-- end panel-heading -->
                        <!-- begin panel-body -->
                        <div class="panel-body">
                            <div id="graficoBarras" class="with-3d-shadow with-transitions graficoBarras">
                                <svg></svg>
                            </div>
                        </div>
                        <!-- end panel-body -->
                    </div>
                </div>
                <!-- end col-10 -->
            </div>
            <!-- end row -->
                  <!-- begin row -->
            <div class="row">
                <!-- begin col-10 -->
                <div class="col-lg-12">
                    <div class="panel panel-inverse">
                        <!-- begin panel-heading -->
                        <div class="panel-heading">
                            <div class="panel-heading-btn">
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-redo"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
                            </div>
                            <h4 class="panel-title">DASHBOARD SALIDAS</h4>
                            <asp:HiddenField ID="hfgBarraSerie2" runat="server" />
                           <%-- <asp:HiddenField ID="hfgBarraSerie2" runat="server" />--%>
                       </div>
                        <!-- end panel-heading -->
                        <!-- begin panel-body -->
                        <div class="panel-body">
                            <div id="graficoBarras2" class="with-3d-shadow with-transitions graficoBarras">
                                <svg></svg>
                            </div>
                        </div>
                        <!-- end panel-body -->
                    </div>
                </div>
                <!-- end col-10 -->
            </div>
            <!-- end row -->
            <!-- begin row -->
            <div class="row">
                <!-- begin col-10 -->
                <div class="col-lg-12">
                    <div class="panel panel-inverse">
                        <!-- begin panel-heading -->
                        <div class="panel-heading">
                            <div class="panel-heading-btn">
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-success" data-click="panel-reload"><i class="fa fa-redo"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-danger" data-click="panel-remove"><i class="fa fa-times"></i></a>
                            </div>
                            <h4 class="panel-title">Porcentaje de Avance Financiero - Técnico</h4>
                            <asp:HiddenField ID="hfgLineaSerie1" runat="server" />
                        </div>
                        <!-- end panel-heading -->
                        <!-- begin panel-body -->
                        <div class="panel-body">
                            <div id="graficoLineas" class='with-3d-shadow with-transitions graficoLineas'>
                              <svg></svg>
                            </div>
                        </div>
                        <!-- end panel-body -->
                    </div>
                </div>
                <!-- end col-10 -->
            </div>
            <!-- end row -->

            <hr style="background-color: lightgray; height: 2px; border: 0;" />
            <div class="row">
                <div style="width: 120px">
                    <%--<asp:LinkButton ID="lbtnCerrar" runat="server" OnClick="lbtnCerrar_Click" CssClass="btn btn-indigo" ToolTip="Cerrar" Width="100%"><i class="fa fa-close"></i> Cerrar</asp:LinkButton>--%>
                </div>
            </div>

         </asp:Panel>
			<asp:GridView ID="GridView2" runat="server"></asp:GridView>
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
															<th class="text-nowrap">NRO_INGRESO</th>
															<th class="text-nowrap">LOTE_MUNDO</th>
															<th class="text-nowrap">FECHA_INGRESO</th>
															<th class="text-nowrap">DESCRIPCION</th>
															<th class="text-nowrap">ENVASE</th>
															<th class="text-nowrap">UNIDAD_MEDIDA</th>
															<th class="text-nowrap">PESO</th>
															<th class="text-nowrap">CANTIDAD</th>
															<th class="text-nowrap">PESO_KG</th>
															<th class="text-nowrap">UNIDAD</th>
															<th class="text-nowrap">UBIC_COD</th>
															<th class="text-nowrap">UBIC_DET</th>
															<th class="text-nowrap">SKU</th>
														
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
															<td><asp:Label ID="lblcampo1" runat="server" Text='<%# Eval("RECINTO") %>'></asp:Label></td>
															<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("NRO_INGRESO") %>'></asp:Label></td>
																<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("LOTE_MUNDO") %>'></asp:Label></td>
																<td><asp:Label ID="Label3" runat="server" Text='<%# Eval("FECHA_INGRESO") %>'></asp:Label></td>
																<td><asp:Label ID="Label4" runat="server" Text='<%# Eval("DESCRIPCION") %>'></asp:Label></td>
																<td><asp:Label ID="Label5" runat="server" Text='<%# Eval("ENVASE") %>'></asp:Label></td>
																<td><asp:Label ID="Label6" runat="server" Text='<%# Eval("UNIDAD_MEDIDA") %>'></asp:Label></td>
																<td><asp:Label ID="Label7" runat="server" Text='<%# Eval("PESO") %>'></asp:Label></td>
																<td><asp:Label ID="Label11" runat="server" Text='<%# Eval("CANTIDAD") %>'></asp:Label></td>
																<td><asp:Label ID="Label10" runat="server" Text='<%# Eval("PESO_KG") %>'></asp:Label></td>
																<td><asp:Label ID="Label9" runat="server" Text='<%# Eval("UNIDAD") %>'></asp:Label></td>
																<td><asp:Label ID="Label8" runat="server" Text='<%# Eval("UBIC_COD") %>'></asp:Label></td>
																<td><asp:Label ID="Label12" runat="server" Text='<%# Eval("UBIC_DET") %>'></asp:Label></td>
																<td><asp:Label ID="Label13" runat="server" Text='<%# Eval("SKU") %>'></asp:Label></td>
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

    <%--    function recuperarFechaSalida() {

            document.getElementById('<%=hfFechaSalida.ClientID%>').value = document.getElementById('fecha_salida').value;

        }

		function setearFechaSalida() {

            document.getElementById('fecha_salida').value = document.getElementById('<%=hfFechaSalida.ClientID%>').value;
        }--%>
    </script>

   <!-- pace -->
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
