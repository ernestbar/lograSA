<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="clientes_admin.aspx.cs" Inherits="appLograAdmin.clientes_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ObjectDataSource ID="odsClientesTodos" runat="server" SelectMethod="PR_GET_CLIENTE_ALL" TypeName="appLograAdmin.Clases.Clientes">
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTipoCliente" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appLograAdmin.Clases.Dominios">
        <SelectParameters>
			<asp:Parameter Name="PV_DOMINIO" DefaultValue="TIPO CLIENTE" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTipoDocumento" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appLograAdmin.Clases.Dominios">
        <SelectParameters>
			<asp:Parameter Name="PV_DOMINIO" DefaultValue="TIPO DOCUMENTO" />
        </SelectParameters>
    </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsDominioPais" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appLograAdmin.Clases.Dominios">
        <SelectParameters>
			<asp:Parameter Name="PV_DOMINIO" DefaultValue="PAIS" />
        </SelectParameters>
    </asp:ObjectDataSource>

	
	<%--<asp:ObjectDataSource ID="odsContactosCliente" runat="server" SelectMethod="PR_PAR_GET_MEDIOS_CONTACTO_CLIENTE" TypeName="appRRHHadmin.Clases.Medios_contratos">
		<SelectParameters>
            <asp:ControlParameter ControlID="ddlClienteFiltro" Name="PV_ID_CLIENTE" Type="String" />
        </SelectParameters>
		</asp:ObjectDataSource>--%>
	
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
			<asp:Label ID="lblCodCliente" runat="server" Text="3" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
			 <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
			<asp:Label ID="Label1" Visible="false" ForeColor="Yellow" Font-Size="Larger" runat="server" Text=""></asp:Label>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
			<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnNuevo" class="btn btn-green btn-sm col-6" OnClick="btnNuevo_Click" runat="server" Text="AGREGAR NUEVO" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
									
										<!-- begin page-header -->
											<h1 class="page-header">Administrador Clientes:</h1>
										<%--	<asp:DropDownList ID="ddlDominio" class="form-control col-md-6" AutoPostBack="true" OnSelectedIndexChanged="ddlDominio_SelectedIndexChanged"  DataSourceID="odsDominiosOnly" DataTextField="dominio" DataValueField="dominio" OnDataBound="ddlDominio_DataBound" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlDominio" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>--%>
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
												<table id="data-table-buttons" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-wrap">CODIGO SISTEMA</th>
															<th class="text-wrap">TIPO CLIENTE</th>
															<th class="text-nowrap">RAZON SOCIAL</th>
															<th class="text-nowrap">NOMBRE</th>
															<th class="text-nowrap">APELLIDO PATERNO</th>
															<th class="text-nowrap">APELLIDO MATERNO</th>
															<th class="text-nowrap">TIPO DOCUMENTO</th>
															<th class="text-nowrap">NUMERO DOCUMENTO</th>
															<th class="text-nowrap">PAIS</th>
															<th class="text-nowrap">LOGO</th>
															<th class="text-nowrap">ESTADO</th>
															
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" DataSourceID="odsClientesTodos" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																
															<%--<td><asp:Image ID="Image1" Height="50px" runat="server" ImageUrl='<%# @"Logos\" + Eval("CLI_ID_CLIENTE") + @"\" +  Eval("CLI_LOGO") %>' /></td>--%>
															<td><asp:Label ID="lblEsPrincipa1l" runat="server" Text='<%# Eval("COD_CLIENTE_SICI") %>'></asp:Label></td>
															<td><asp:Label ID="lblEsPrincipal" runat="server" Text='<%# Eval("DESC_TIPO_CLIENTE") %>'></asp:Label></td>
															<td><asp:Label ID="lblRazonSocial" runat="server" Text='<%# Eval("RAZON_SOCIAL") %>'></asp:Label></td>
															<td><asp:Label ID="lblMedioContacto0" runat="server" Text='<%# Eval("NOMBRE") %>'></asp:Label></td>
															<td><asp:Label ID="lblMedioContacto1" runat="server" Text='<%# Eval("APELLIDO_PATERNO") %>'></asp:Label></td>
															<td><asp:Label ID="lblMedioContacto2" runat="server" Text='<%# Eval("APELLIDO_MATERNO") %>'></asp:Label></td>
															<td><asp:Label ID="lblMedioContacto3" runat="server" Text='<%# Eval("DESC_TIPO_DOCUMENTO") %>'></asp:Label></td>
															<td><asp:Label ID="lblMedioContacto4" runat="server" Text='<%# Eval("NUMERO_DOCUMENTO") %>'></asp:Label></td>
															<td><asp:Label ID="lblMedioContacto5" runat="server" Text='<%# Eval("DESC_PAIS") %>'></asp:Label></td>
																<td><asp:Image ID="Image1" Width="50" runat="server" ImageUrl='<%# Eval("LOGO").ToString().Equals("".ToString()) ? "~/ClienteLogos/sin_logo.png" : "~/ClienteLogos/"+Eval("COD_CLIENTE")+"/"+Eval("LOGO") %>' /> </td>
															<%--<td><asp:Label ID="lblMedioContacto6" runat="server" Text='<%# Eval("LOGO") %>'></asp:Label></td>--%>
															<td><asp:Label ID="lblMedioContacto7" runat="server" Text='<%# Eval("DESC_ESTADO") %>'></asp:Label></td>
															
															<td>
																<asp:Button ID="btnSICI" style="color:blue" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("COD_CLIENTE") %>' OnClick="btnSICI_Click" runat="server" Text="Codigo SICI" ToolTip="Detalle SICI" />
																<asp:Button ID="btnEditar" style="color:blue" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("COD_CLIENTE") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar" />
																<asp:Button ID="btnEliminar" style="color:blue" class="btn btn-danger btn-sm" CommandArgument='<%# Eval("COD_CLIENTE") +"|"+Eval("ESTADO") %>' OnClick="btnEliminar_Click" OnClientClick="return confirm('Seguro que desea eliminar el registro???')" runat="server" Text="Activa/Desactivar" ToolTip="Borrar registro" />
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
        </asp:View>
		 <asp:View ID="View2" runat="server">
			<!-- begin row -->
			<div class="row">
				<!-- begin col-8 -->
				<div class="col-md-6 offset-md-2">
					
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos Cliente</legend>
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Codigo cliente sistemas:</label>
						<div class="col-md-6">
                             <asp:TextBox ID="txtCodCliSis" class="form-control" runat="server"></asp:TextBox>
                            <%--<asp:CheckBox ID="cbPadre"  class="form-control" AutoPostBack="true" Text="SI/NO" OnCheckedChanged="cbPadre_CheckedChanged" Checked="true" runat="server" />--%>
						<%--	<asp:DropDownList ID="ddlCliente" class="form-control"  DataSourceID="odsClientes" DataTextField="CLI_RAZON_SOCIAL" DataValueField="CLI_ID_CLIENTE" OnDataBound="ddlCliente_DataBound" runat="server"></asp:DropDownList>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCliente" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>--%>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Tipo cliente:</label>
						<div class="col-md-6">
                             			<asp:DropDownList ID="ddlTipoCliente" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoCliente_SelectedIndexChanged"  DataSourceID="odsTipoCliente" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlTipoCliente_DataBound" runat="server"></asp:DropDownList>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlTipoCliente" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
					<asp:Panel ID="Panel_juridica" Visible="false" runat="server">
						<!-- begin form-group row -->
						<div class="form-group row m-b-10">
							<label class="col-md-3 text-md-right col-form-label">Razon Social:</label>
							<div class="col-md-6">
								<asp:TextBox ID="txtRazonSocial" class="form-control" runat="server"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="txtRazonSocial" Font-Bold="True"></asp:RequiredFieldValidator>
							</div>
						</div>
						<!-- end form-group row -->
					</asp:Panel>
					<asp:Panel ID="Panel_natural" Visible="false" runat="server">
						<!-- begin form-group row -->
						<div class="form-group row m-b-10">
							<label class="col-md-3 text-md-right col-form-label">Nombre:</label>
							<div class="col-md-6">
								<asp:TextBox ID="txtNombre" class="form-control" runat="server"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtNombre" Font-Bold="True"></asp:RequiredFieldValidator>
							</div>
                        
						</div>
						<!-- end form-group row -->
								<!-- begin form-group row -->
						<div class="form-group row m-b-10">
							<label class="col-md-3 text-md-right col-form-label">Paterno:</label>
							<div class="col-md-6">
								<asp:TextBox ID="txtPaterno" class="form-control" runat="server"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtPaterno" Font-Bold="True"></asp:RequiredFieldValidator>
							</div>
                        
						</div>
						<!-- end form-group row -->
								<!-- begin form-group row -->
						<div class="form-group row m-b-10">
							<label class="col-md-3 text-md-right col-form-label">Materno:</label>
							<div class="col-md-6">
								<asp:TextBox ID="txtMaterno" class="form-control" runat="server"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtMaterno" Font-Bold="True"></asp:RequiredFieldValidator>
							</div>
						</div>
						<!-- end form-group row -->
					</asp:Panel>
				
						
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Tipo documento:</label>
						<div class="col-md-6">
                            <asp:DropDownList ID="ddlTipoDocumento" class="form-control"  DataSourceID="odsTipoDocumento" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlTipoDocumento_DataBound" runat="server"></asp:DropDownList>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlTipoDocumento" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
                        
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Numero documento:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtNumDoc" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="txtNumDoc" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
                        
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Pais:</label>
						<div class="col-md-6">
                            <asp:DropDownList ID="ddlPais" class="form-control"  DataSourceID="odsDominioPais" DataTextField="descripcion" DataValueField="codigo" OnDataBound="ddlPais_DataBound" runat="server"></asp:DropDownList>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlPais" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
                        
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Logo:</label><asp:Label ID="lblLogoAnt" runat="server" Visible="false" Text=""></asp:Label>
						<div class="col-md-6">
							<asp:FileUpload ID="fuLogo" class="form-control" runat="server" />
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label"></label>
						<div class="col-md-6">
							<asp:Image ID="imgLogo" Width="100" runat="server" />
						</div>
					</div>
					<!-- end form-group row -->
					
						<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
							<asp:Button ID="btnGuardar" CssClass="btn btn-info" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
							<asp:Button ID="btnVolverAlta" CssClass="btn btn-default"  runat="server" CausesValidation="false" OnClick="btnVolverAlta_Click" Text="Cancelar" />
						</div>
					</div>
				</div>				
				<!-- end col-8 -->
			
        </asp:View>
		<asp:View ID="View3" runat="server">
			<asp:Label ID="lblCodServidor" runat="server" Text="" Visible="false"></asp:Label>
				<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnVolverSICI1" class="btn btn-green btn-sm col-6" OnClick="btnVolverSICI1_Click" runat="server" Text="Volver a cliente" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
				<h1 class="page-header">Administrador Cliente Servidor:</h1>
										<%--	<asp:DropDownList ID="ddlDominio" class="form-control col-md-6" AutoPostBack="true" OnSelectedIndexChanged="ddlDominio_SelectedIndexChanged"  DataSourceID="odsDominiosOnly" DataTextField="dominio" DataValueField="dominio" OnDataBound="ddlDominio_DataBound" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlDominio" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>--%>
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
												<table id="data-table-buttons" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-wrap">CODIGO SERVIDOR</th>
															<th class="text-wrap">SERVIDOR</th>
															<th class="text-nowrap">CLIENTE</th>
															<th class="text-nowrap">CODIGO SICI</th>
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater2" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																
															<%--<td><asp:Image ID="Image1" Height="50px" runat="server" ImageUrl='<%# @"Logos\" + Eval("CLI_ID_CLIENTE") + @"\" +  Eval("CLI_LOGO") %>' /></td>--%>
															<td><asp:Label ID="lblEsPrincipa1l" runat="server" Text='<%# Eval("COD_SERVIDOR") %>'></asp:Label></td>
															<td><asp:Label ID="lblEsPrincipal" runat="server" Text='<%# Eval("DESC_COD_SERVIDOR") %>'></asp:Label></td>
															<td><asp:Label ID="lblRazonSocial" runat="server" Text='<%# Eval("DESC_RAZONSOCIAL") %>'></asp:Label></td>
															<td><asp:Label ID="lblMedioContacto0" runat="server" Text='<%# Eval("COD_CLIENTE_SICI") %>'></asp:Label></td>
															<td>
																<asp:Button ID="btnEditarSICI" style="color:blue" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("COD_SERVIDOR")+"|"+Eval("COD_CLIENTE") %>' OnClick="btnEditarSICI_Click"	runat="server" Text="Editar" ToolTip="Editar" />
																<asp:Button ID="btnSICIExtra" style="color:blue" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("COD_SERVIDOR")+"|"+Eval("COD_CLIENTE") %>' OnClick="btnSICIExtra_Click"	runat="server" Text="Codigos SICI Extra" ToolTip="Agragar codigos" />
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
		</asp:View>
		<asp:View ID="View4" runat="server">
			<!-- begin row -->
			<div class="row">
				<!-- begin col-8 -->
				<div class="col-md-6 offset-md-2">
					
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Editar codigo SICI</legend>
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Codigo cliente sistemas:</label>
						<div class="col-md-6">
                             <asp:TextBox ID="txtCodSICI" class="form-control" runat="server"></asp:TextBox>
                            <%--<asp:CheckBox ID="cbPadre"  class="form-control" AutoPostBack="true" Text="SI/NO" OnCheckedChanged="cbPadre_CheckedChanged" Checked="true" runat="server" />--%>
						<%--	<asp:DropDownList ID="ddlCliente" class="form-control"  DataSourceID="odsClientes" DataTextField="CLI_RAZON_SOCIAL" DataValueField="CLI_ID_CLIENTE" OnDataBound="ddlCliente_DataBound" runat="server"></asp:DropDownList>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCliente" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>--%>
						</div>
					</div>
					<!-- end form-group row -->
						<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
							<asp:Button ID="btnGuardarSICI" CssClass="btn btn-info" runat="server" OnClick="btnGuardarSICI_Click" Text="Guardar" />
							<asp:Button ID="btnVolverSICI" CssClass="btn btn-default"  runat="server" CausesValidation="false" OnClick="btnVolverSICI_Click" Text="Cancelar" />
						</div>
					</div>
				</div>				
				<!-- end col-8 -->

		</asp:View>
		<asp:View ID="View5" runat="server">
			<div class="form-group row m-b-10">
				<asp:Label ID="lblCodClienteSICIextra" runat="server" Visible="false" Text=""></asp:Label>
				<asp:Label ID="lblCodClienteExtra" runat="server" Visible="false" Text=""></asp:Label>
				<asp:Label ID="lblCodServidorExtra" runat="server" Visible="false" Text=""></asp:Label>
											<div class="col-md-6">
												 <asp:Button ID="btnNuevoCodExtra" class="btn btn-green btn-sm col-6" OnClick="btnNuevoCodExtra_Click" runat="server" Text="AGREGAR NUEVO" />
                                                <asp:Button ID="btnVolverCodigos" class="btn btn-default btn-sm col-6" OnClick="btnVolverSICI1_Click" runat="server" Text="Volver a SICI" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
									<h1 class="page-header">Administrador Codigos Extra:</h1>
										<%--	<asp:DropDownList ID="ddlDominio" class="form-control col-md-6" AutoPostBack="true" OnSelectedIndexChanged="ddlDominio_SelectedIndexChanged"  DataSourceID="odsDominiosOnly" DataTextField="dominio" DataValueField="dominio" OnDataBound="ddlDominio_DataBound" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlDominio" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>--%>
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
												<table id="data-table-buttons" class="table table-striped table-bordered">
													<thead>
														<tr>
															<th class="text-wrap">SERVIDOR</th>
															<th class="text-nowrap">CLIENTE</th>
															<th class="text-nowrap">CODIGO SICI</th>
															<th class="text-nowrap">DETALLE</th>
															<th class="text-nowrap">FECHA ELIMINACION</th>
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater3" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																
															<%--<td><asp:Image ID="Image1" Height="50px" runat="server" ImageUrl='<%# @"Logos\" + Eval("CLI_ID_CLIENTE") + @"\" +  Eval("CLI_LOGO") %>' /></td>--%>
															<td><asp:Label ID="lblEsPrincipa1l" runat="server" Text='<%# Eval("DESC_COD_SERVIDOR") %>'></asp:Label></td>
															<td><asp:Label ID="lblEsPrincipal" runat="server" Text='<%# Eval("DESC_RAZONSOCIAL") %>'></asp:Label></td>
															<td><asp:Label ID="lblRazonSocial" runat="server" Text='<%# Eval("COD_CLIENTE_SICI") %>'></asp:Label></td>
															<td><asp:Label ID="lblMedioContacto0" runat="server" Text='<%# Eval("DETALLE") %>'></asp:Label></td>
															<td><asp:Label ID="lblMedioContacto1" runat="server" Text='<%# Eval("FECHA_ELIMINACION") %>'></asp:Label></td>
															<td>
																<asp:Button ID="btnEditarSICIextra" style="color:blue" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("COD_SERVIDOR")+"|"+Eval("COD_CLIENTE")+"|"+Eval("COD_CLIENTE_SICI") %>' OnClick="btnEditarSICIextra_Click"	runat="server" Text="Editar" ToolTip="Editar" />
																<asp:Button ID="btnEliminarSICIExtra" style="color:blue" class="btn btn-danger btn-sm"  CommandArgument='<%# Eval("COD_SERVIDOR")+"|"+Eval("COD_CLIENTE")+"|"+Eval("COD_CLIENTE_SICI")+"|"+Eval("FECHA_ELIMINACION") %>' OnClick="btnEliminarSICIExtra_Click"	runat="server" Text="Eliminar/Activar" ToolTip="Elimina o activa codigos" />
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
		</asp:View>
		<asp:View ID="View6" runat="server">
			<!-- begin row -->
			<div class="row">
				<!-- begin col-8 -->
				<div class="col-md-6 offset-md-2">
					
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos codigo SICI extra</legend>
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Codigo Extra:</label>
						<div class="col-md-6">
                             <asp:TextBox ID="txtCodExtra" class="form-control" runat="server"></asp:TextBox>
                            <%--<asp:CheckBox ID="cbPadre"  class="form-control" AutoPostBack="true" Text="SI/NO" OnCheckedChanged="cbPadre_CheckedChanged" Checked="true" runat="server" />--%>
						<%--	<asp:DropDownList ID="ddlCliente" class="form-control"  DataSourceID="odsClientes" DataTextField="CLI_RAZON_SOCIAL" DataValueField="CLI_ID_CLIENTE" OnDataBound="ddlCliente_DataBound" runat="server"></asp:DropDownList>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCliente" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>--%>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Detalle:</label>
						<div class="col-md-6">
                             <asp:TextBox ID="txtDetalleExtra" class="form-control" runat="server"></asp:TextBox>
                            <%--<asp:CheckBox ID="cbPadre"  class="form-control" AutoPostBack="true" Text="SI/NO" OnCheckedChanged="cbPadre_CheckedChanged" Checked="true" runat="server" />--%>
						<%--	<asp:DropDownList ID="ddlCliente" class="form-control"  DataSourceID="odsClientes" DataTextField="CLI_RAZON_SOCIAL" DataValueField="CLI_ID_CLIENTE" OnDataBound="ddlCliente_DataBound" runat="server"></asp:DropDownList>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCliente" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>--%>
						</div>
					</div>
					<!-- end form-group row -->
						<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
							<asp:Button ID="btnGuardarSICIextra" CssClass="btn btn-info" runat="server" OnClick="btnGuardarSICIextra_Click" Text="Guardar" />
							<asp:Button ID="btnVolverSICIextra" CssClass="btn btn-default"  runat="server" CausesValidation="false" OnClick="btnVolverSICIextra_Click" Text="Cancelar" />
						</div>
					</div>
				</div>				
				<!-- end col-8 -->
		
		</asp:View>
    </asp:MultiView>
			
		</div>
		<!-- end #content -->	
</asp:Content>
