<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="menu_rol_admin.aspx.cs" Inherits="appLograAdmin.menu_rol_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
	<asp:ObjectDataSource ID="odsRolesActivos" runat="server" SelectMethod="PR_GET_ROLES" TypeName="appLograAdmin.Clases.Roles">
    </asp:ObjectDataSource>
	
	<asp:ObjectDataSource ID="odsMenusNoAsignado" runat="server" SelectMethod="PR_SEG_GET_MENUS_A_ASIGNAR" TypeName="appLograAdmin.Clases.Menus_roles">
		<SelectParameters>
			<asp:ControlParameter ControlID="ddlRol" Name="pB_ROL_ID_ROL" Type="String" />
			<asp:ControlParameter ControlID="ddlSistema" Name="pV_SISTEMA" Type="String" />
        </SelectParameters>
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsMenusAsignado" runat="server" SelectMethod="PR_SEG_GET_MENUS_ASIGNADOS" TypeName="appLograAdmin.Clases.Menus_roles">
		<SelectParameters>
			<asp:ControlParameter ControlID="ddlRol" Name="pB_ROL_ID_ROL" Type="String" />
			<asp:ControlParameter ControlID="ddlSistema" Name="pV_SISTEMA" Type="String" />
        </SelectParameters>
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsSistema" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appLograAdmin.Clases.Dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="SISTEMA" Name="PV_DOMINIO" Type="String" />
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
											<h1 class="page-header">Asignación de menús a roles <small></small></h1>
											Rol:
											<asp:DropDownList ID="ddlRol" class="form-control col-md-6" AutoPostBack="true" OnSelectedIndexChanged="ddlRol_SelectedIndexChanged"  DataSourceID="odsRolesActivos" DataTextField="DESCRIPCION" DataValueField="ROL" OnDataBound="ddlRol_DataBound" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlRol" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
											Sistema:
											<asp:DropDownList ID="ddlSistema" class="form-control col-md-6" DataSourceID="odsSistema" AutoPostBack="true" OnSelectedIndexChanged="ddlSistema_SelectedIndexChanged" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlSistema_DataBound" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlSistema" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>	
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
															<th class="text-wrap">MENU ASIGNADO</th>
															<th class="text-nowrap">MENU NO ASIGNADO</th>
														</tr>
													</thead>
													<tbody>
														<tr>
															<td>
																<table id="asignados">
																	<tr>
																		
																		<td>
																			MENU
																		</td>
																		<td>
																			OPCIONES
																		</td>
																	</tr>
																	 <asp:Repeater ID="Repeater1" DataSourceID="odsMenusAsignado" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
																		<ItemTemplate>
																			<tr class="gradeA">
																			
																				<td><asp:Label ID="lblRazonSocial" runat="server" Text='<%# Eval("DESCRIPCION") %>'></asp:Label></td>
																				<td>
																					<asp:Button ID="btnQuitar" style="color:blue" class="btn btn-danger btn-sm"  CommandArgument='<%# Eval("ROL_MENU")+ "|" + Eval("COD_MENU") %>' OnClick="btnQuitar_Click" runat="server" Text="Quitar" ToolTip="Eliminar menu asignado" />
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
																			MENU
																		</td>
																		<td>
																			OPCIONES
																		</td>
																	</tr>
																	 <asp:Repeater ID="Repeater2" DataSourceID="odsMenusNoAsignado" OnItemDataBound="Repeater2_ItemDataBound" runat="server">
																		<ItemTemplate>
																			<tr class="gradeA">
																				
																				<td><asp:Label ID="lblRazonSocial" runat="server" Text='<%# Eval("DESCRIPCION") %>'></asp:Label></td>
																				<td>
																					<asp:Button ID="btnAgregar" style="color:blue" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("COD_MENU") %>' OnClick="btnAgregar_Click" runat="server" Text="Agregar" ToolTip="Asignar menu" />
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
