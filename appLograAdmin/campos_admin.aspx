<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="campos_admin.aspx.cs" Inherits="appLograAdmin.campos_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ObjectDataSource ID="odsClientesTodos" runat="server" SelectMethod="PR_GET_CLIENTE_ALL" TypeName="appLograAdmin.Clases.Clientes">
		</asp:ObjectDataSource>
	
	<asp:ObjectDataSource ID="odsCamposNoAsignado" runat="server" SelectMethod="PR_GET_CAMPO_A_ASIGNAR_CLIENTE" TypeName="appLograAdmin.Clases.Campos_clientes">
		<SelectParameters>
			<asp:ControlParameter ControlID="ddlReporte" Name="pV_COD_REPORTE" Type="String" />
			<asp:ControlParameter ControlID="ddlClientes" Name="pV_COD_CLIENTE" Type="String" />
        </SelectParameters>
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsCamposAsignado" runat="server" SelectMethod="PR_GET_CAMPO_ASIGNADO_CLIENTE" TypeName="appLograAdmin.Clases.Campos_clientes">
		<SelectParameters>
			<asp:ControlParameter ControlID="ddlReporte" Name="pV_COD_REPORTE" Type="String" />
			<asp:ControlParameter ControlID="ddlClientes" Name="pV_COD_CLIENTE" Type="String" />
        </SelectParameters>
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsSistema" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appLograAdmin.Clases.Dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="SISTEMA" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
	
	<asp:ObjectDataSource ID="odsRerportes" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appLograAdmin.Clases.Dominios">
        <SelectParameters>
			<asp:Parameter Name="PV_DOMINIO" DefaultValue="REPORTE EXISTENCIAS" />
        </SelectParameters>
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
			<asp:Label ID="lblCodMenu" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
            <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
			<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                               
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									
										<!-- begin page-header -->
											<h1 class="page-header">Asignación de campos <small></small></h1>
											Clientes:
											<asp:DropDownList ID="ddlClientes" class="form-control col-4"  OnDataBound="ddlClientes_DataBound" OnSelectedIndexChanged="ddlClientes_SelectedIndexChanged" AutoPostBack="true"  DataSourceID="odsClientesTodos" DataTextField="DESC_RAZONSOCIAL" DataValueField="cod_cliente" ForeColor="Black" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlClientes" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
											Reporte existencias:
											<asp:DropDownList ID="ddlReporte" class="form-control col-4"  OnDataBound="ddlReporte_DataBound" OnSelectedIndexChanged="ddlReporte_SelectedIndexChanged" AutoPostBack="true"  DataSourceID="odsRerportes" DataTextField="descripcion" DataValueField="codigo" ForeColor="Black" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlReporte" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
										<!-- end page-header -->
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
												<table id="data-table-default" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-wrap">CAMPOS ASIGNADOS</th>
															<th class="text-nowrap">CAMPOS NO ASIGNADOS</th>
														</tr>
													</thead>
													<tbody>
														<tr>
															<td>
																<table id="asignados">
																	<tr>
																		
																		<td>
																			CAMPO
																		</td>
																		<td>
																			OPCIONES
																		</td>
																	</tr>
																	 <asp:Repeater ID="Repeater1" DataSourceID="odsCamposAsignado" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
																		<ItemTemplate>
																			<tr class="gradeA">
																			
																				<td><asp:Label ID="lblRazonSocial" runat="server" Text='<%# Eval("CAMPO") %>'></asp:Label></td>
																				<td>
																					<asp:Button ID="btnQuitar" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("COD_REPORTE") %>' OnClick="btnQuitar_Click" runat="server" Text="Quitar" ToolTip="Eliminar menu asignado" />
																				</td>
																			</tr>
																		</ItemTemplate>
																	</asp:Repeater>
																</table>
															</td>
															<td>
																<table id="noasignados">
																	<tr>
																		
																		<td>
																			CAMPO
																		</td>
																		<td>
																			OPCIONES
																		</td>
																	</tr>
																	 <asp:Repeater ID="Repeater2" DataSourceID="odsCamposNoAsignado" OnItemDataBound="Repeater2_ItemDataBound" runat="server">
																		<ItemTemplate>
																			<tr class="gradeA">
																				
																				<td><asp:Label ID="lblRazonSocial" runat="server" Text='<%# Eval("CAMPO") %>'></asp:Label></td>
																				<td>
																					<asp:Button ID="btnAgregar" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("COD_REPORTE") %>' OnClick="btnAgregar_Click" runat="server" Text="Agregar" ToolTip="Asignar menu" />
																				</td>
																			</tr>
																		</ItemTemplate>
																	</asp:Repeater>
																</table>
															</td>
														</tr>
													</tbody>
												</table>
											</div>
											<!-- end table-responsive -->
													</div>
										</div>
        
	
			
		</div>
	
		<!-- end #content -->
</asp:Content>
