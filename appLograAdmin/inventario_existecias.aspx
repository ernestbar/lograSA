﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="inventario_existecias.aspx.cs" Inherits="appLograAdmin.inventario_existecias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    	<%--<asp:ObjectDataSource ID="odsReporte" runat="server" SelectMethod="PR_INGRESOS" TypeName="appLograAdmin.Clases.Reportes">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlDominio" Name="PV_DOMINIO" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>--%>
	<asp:ObjectDataSource ID="odsServidores" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appLograAdmin.Clases.Dominios">
        <SelectParameters>
			<asp:Parameter Name="PV_DOMINIO" DefaultValue="SERVIDORES" />
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
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
			  <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
										
									
										<!-- begin page-header -->
											<h1 class="page-header">Visibilidad de inventario de existencias en línea</h1>
											Servidor:
											<asp:DropDownList ID="ddlServidor" class="form-control col-md-6"  DataSourceID="odsServidores" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlServidor_DataBound" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlServidor" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
											Cliente:
											<asp:DropDownList ID="ddlClientes" class="form-control col-md-6"  OnDataBound="ddlClientes_DataBound" DataSourceID="odsClientesTodos" DataTextField="DESC_RAZONSOCIAL" DataValueField="cod_cliente" ForeColor="Black" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlClientes" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
											Fecha:
											<input id="fecha_salida" class="form-control col-12 col-md-2"  style="background:#ecf1fa" type="date"><asp:HiddenField ID="hfFechaSalida" runat="server" />
											Tipo Rerporte:
											<asp:RadioButtonList ID="rblTipoReporte" CssClass="form-control" RepeatDirection="Horizontal"  runat="server">
												<asp:ListItem>RESUMEN</asp:ListItem>
												<asp:ListItem>DETALLADO</asp:ListItem>
											</asp:RadioButtonList>
											<!-- end page-header -->
											<!-- begin form-group row -->
											<div class="form-group row m-b-10">
											
												<div class="col-md-6">
													<asp:Button ID="btnConsultar" class="btn-sm btn-info btn-block" OnClientClick="recuperarFechaSalida()" OnClick="btnConsultar_Click" runat="server" Text="Generar Reporte" />
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
													<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                        <EditRowStyle BackColor="#999999" />
                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
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

        function recuperarFechaSalida() {

            document.getElementById('<%=hfFechaSalida.ClientID%>').value = document.getElementById('fecha_salida').value;
                
        }

    </script>
			
		</div>
		<!-- end #content -->
</asp:Content>