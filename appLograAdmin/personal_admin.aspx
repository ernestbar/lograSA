<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="personal_admin.aspx.cs" Inherits="appLograAdmin.personal_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ObjectDataSource ID="odsPersonalClientes" runat="server" SelectMethod="PR_PAR_GET_PERSONAL" TypeName="appLograAdmin.Clases.Personal">
		 <SelectParameters>
            <asp:ControlParameter ControlID="ddlClientes" Name="pV_COD_CLIENTE" DefaultValue="" />
        </SelectParameters>
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsUsuarios" runat="server" SelectMethod="PR_PAR_GET_USUARIOS" TypeName="appLograAdmin.Clases.Personal">
		<SelectParameters>
			<asp:ControlParameter ControlID="lblCodPersonal" Name="pV_COD_PERSONAL" Type="String" />
		</SelectParameters>
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsRoles" runat="server" SelectMethod="PR_GET_ROLES" TypeName="appLograAdmin.Clases.Roles">
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsTipoDocumento" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appLograAdmin.Clases.Dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="TIPO DOCUMENTO" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsCargo" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appLograAdmin.Clases.Dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="CARGO" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsPais" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appLograAdmin.Clases.Dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="PAIS" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
	
	<asp:ObjectDataSource ID="odsExpedido" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appLograAdmin.Clases.Dominios">
			<SelectParameters>
				<asp:Parameter DefaultValue="CIUDAD" Name="PV_DOMINIO" Type="String" />
			</SelectParameters>
		 </asp:ObjectDataSource>
	
	<asp:ObjectDataSource ID="odsClientesTodos" runat="server" SelectMethod="PR_GET_CLIENTE_ALL" TypeName="appLograAdmin.Clases.Clientes">
		</asp:ObjectDataSource>
	 <asp:ObjectDataSource ID="odsSucursal" runat="server" SelectMethod="PR_PAR_GET_SUCURSALES" TypeName="appLograAdmin.Clases.Sucursales">
		 <SelectParameters>
            <asp:ControlParameter ControlID="ddlClientes" Name="pV_COD_CLIENTE" DefaultValue="" />
        </SelectParameters>
	</asp:ObjectDataSource>    
	<%--<asp:ObjectDataSource ID="odsCiudad" runat="server" SelectMethod="Lista" TypeName="appRRHHadmin.Clases.Ciudades">
			<SelectParameters>
				<asp:ControlParameter Name="PI_ID_PAIS" ControlID="ddlPaisRes" DefaultValue="0" />
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
			<asp:Label ID="lblCodPersonal" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblCodUsuario" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
             <asp:Label ID="lblCodUsuarioI" runat="server" Visible="false" Text=""></asp:Label>
			<asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
			<asp:Label ID="lblCodServidor" Visible="false" ForeColor="Yellow" Font-Size="Larger" runat="server" Text=""></asp:Label>
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
										Seleccione Cliente:
					<asp:DropDownList ID="ddlClientes" class="form-control col-4"  OnDataBound="ddlCliente_DataBound" OnSelectedIndexChanged="ddlClientes_SelectedIndexChanged" AutoPostBack="true"  DataSourceID="odsClientesTodos" DataTextField="DESC_RAZONSOCIAL" DataValueField="cod_cliente" ForeColor="Black" runat="server"></asp:DropDownList>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlClientes" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
										  
										<!-- begin page-header -->
											<h1 class="page-header">Registro de Personal<small></small></h1>
												<!-- begin form-group row -->
												
											
												<!-- end form-group row -->
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
															<%--<th class="text-wrap">FOTO</th>--%>
															<th class="text-wrap">NOMBRE</th>
															<th class="text-nowrap">TIPO DOC.</th>
															<th class="text-nowrap">NUMERO DOC.</th>
															<th class="text-nowrap">EXPEDIDO</th>
															<th class="text-nowrap">CARGO</th>
															<th class="text-nowrap">CELULAR</th>
															<th class="text-nowrap">FIJO</th>
															<th class="text-nowrap">INTERNO</th>
															<th class="text-nowrap">EMAIL</th>
															<th class="text-wrap">SUPERVISOR</th>
															<th class="text-nowrap">ESTADO</th>
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" DataSourceID="odsPersonalClientes" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																
															<%--<td><asp:Image ID="Image1" Height="50px" runat="server" ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("filecontent"))  %>' /></td>--%>
															<td><asp:Label ID="lblNombre" runat="server" Text='<%# Eval("NOMBRE_COMPLETO") %>'></asp:Label></td>
																<td><asp:Label ID="lblPaterno" runat="server" Text='<%# Eval("TIPO_DOCUMENTO") %>'></asp:Label></td>
																<td><asp:Label ID="lblMaterno" runat="server" Text='<%# Eval("NUMERO_DOCUMENTO") %>'></asp:Label></td>
																<td><asp:Label ID="lblMarital" runat="server" Text='<%# Eval("EXPEDIDO") %>'></asp:Label></td>
																<td><asp:Label ID="lblTipoDoc" runat="server" Text='<%# Eval("COD_CARGO") %>'></asp:Label></td>
																<td><asp:Label ID="lblNumDoc" runat="server" Text='<%# Eval("CELULAR") %>'></asp:Label></td>
																<td><asp:Label ID="lblComplemento" runat="server" Text='<%# Eval("FIJO") %>'></asp:Label></td>
																<td><asp:Label ID="lblExpedido" runat="server" Text='<%# Eval("INTERNO") %>'></asp:Label></td>
																<td><asp:Label ID="lblSucursal" runat="server" Text='<%# Eval("EMAIL") %>'></asp:Label></td>
																<td><asp:Label ID="lblSucursal1" runat="server" Text='<%# Eval("DESC_SUPERVISOR_INMEDIATO") %>'></asp:Label></td>
															<td><asp:Label ID="lblArea" runat="server" Text='<%# Eval("DESC_ESTADO") %>'></asp:Label></td>
															<td>
																<asp:Button ID="btnEditar" style="color:blue" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("COD_PERSONAL") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar" />
																<asp:Button ID="btnEliminar" style="color:blue" class="btn btn-danger btn-sm" CommandArgument='<%# Eval("COD_PERSONAL") + "|" + Eval("DESC_ESTADO") %>' OnClick="btnEliminar_Click" OnClientClick="return confirm('Seguro que desea eliminar el registro???')" runat="server" Text="Activar/Deactivar" ToolTip="Borrar registro" />
																<asp:Button ID="btnUsuarios" style="color:blue" class="btn btn-success btn-sm" CommandArgument='<%# Eval("COD_PERSONAL") %>' OnClick="btnUsuarios_Click" runat="server" Text="Ver usuario" ToolTip="Usuario del personal" />
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
				<div class="col-md-8 offset-md-1">
					
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos Personal</legend>
					
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Supervisor inmediato:</label>
						<div class="col-md-6">
                           <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlSupervisor" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>--%>
						   <asp:DropDownList ID="ddlSupervisor" DataSourceID="odsPersonalClientes" DataTextField="nombre_completo" OnDataBound="ddlSupervisor_DataBound" DataValueField="cod_personal"  ForeColor="Black" class="form-control" runat="server"></asp:DropDownList>  
						</div>
					</div>
					<!-- end form-group row -->
				<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Sucursal:</label>
						<div class="col-md-6">
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlSucursal" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
						    <asp:DropDownList ID="ddlSucursal"  ForeColor="Black" DataSourceID="odsSucursal" OnDataBound="ddlSucursal_DataBound" DataTextField="DESCRIPCION" DataValueField="COD_SUCURSAL" class="form-control" runat="server"></asp:DropDownList>
						</div>
                        
					</div>
					<!-- end form-group row -->
					
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Nombre completo:</label>
						<div class="col-md-6">
                            <%--<asp:CheckBox ID="cbPadre"  class="form-control" AutoPostBack="true" Text="SI/NO" OnCheckedChanged="cbPadre_CheckedChanged" Checked="true" runat="server" />--%>
							 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtnombres" Font-Bold="True"></asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtNombres" runat="server" class="form-control" ForeColor="Black" placeholder="NOMBRES"></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
					
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Tipo Documento:</label>
						<div class="col-md-6">
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlTipoDocumento" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
						   <asp:DropDownList ID="ddlTipoDocumento" DataSourceID="odsTipoDocumento" DataTextField="descripcion" OnDataBound="ddlTipoDocumento_DataBound" DataValueField="codigo"  ForeColor="Black" class="form-control" runat="server"></asp:DropDownList>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Número Documento:</label>
						<div class="col-md-6">
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNumeroDocumento" Font-Bold="True"></asp:RequiredFieldValidator>
						    <asp:TextBox ID="txtNumeroDocumento" ForeColor="Black" class="form-control" runat="server"  placeholder="NUMERO DE DOCUMEUNTO"></asp:TextBox>
						</div>
                        
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Expedido:</label>
						<div class="col-md-6">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlTipoDocumento" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
						    <asp:DropDownList ID="ddlExpedido"  ForeColor="Black" DataSourceID="odsExpedido" OnDataBound="ddlExpedido_DataBound" DataTextField="descripcion" DataValueField="codigo" class="form-control" runat="server"></asp:DropDownList>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Cargo:</label>
						<div class="col-md-6">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCargo" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:DropDownList ID="ddlCargo" DataSourceID="odsCargo" OnDataBound="ddlCargo_DataBound" DataTextField="descripcion" DataValueField="codigo"  ForeColor="Black" class="form-control" runat="server"></asp:DropDownList>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Telefono Celular:</label>
						<div class="col-md-6">
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCelular" Font-Bold="True"></asp:RequiredFieldValidator>
						     <asp:TextBox ID="txtCelular" ForeColor="Black" class="form-control" runat="server" ></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Telefono Fijo:</label>
						<div class="col-md-6">
						     <asp:TextBox ID="txtFijo" ForeColor="Black" class="form-control" runat="server" ></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Interno:</label>
						<div class="col-md-6">
						     <asp:TextBox ID="txtInterno" ForeColor="Black" class="form-control" runat="server" ></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Correo Electrónico:</label>
						<div class="col-md-6">
							                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmail" Font-Bold="True"></asp:RequiredFieldValidator>
						                <asp:TextBox ID="txtEmail" ForeColor="Black" class="form-control" runat="server"  placeholder="Correo Electronico"></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Nombre usuario:</label>
						<div class="col-md-6">
                            <%--<asp:CheckBox ID="cbPadre"  class="form-control" AutoPostBack="true" Text="SI/NO" OnCheckedChanged="cbPadre_CheckedChanged" Checked="true" runat="server" />--%>
							 <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtUsuario" Font-Bold="True"></asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtUsuario" runat="server" class="form-control" ForeColor="Black" placeholder="NOMBRE USUARIO"></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<%--<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Passsord:</label>
						<div class="col-md-6">
							 <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPassword" Font-Bold="True"></asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtPassword" runat="server" class="form-control" ForeColor="Black" placeholder="PASSWORD USUARIO"></asp:TextBox>
						</div>
					</div>--%>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Rol:</label>
						<div class="col-md-6">
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlRol" InitialValue="SELECCIONAR" Font-Bold="True"></asp:RequiredFieldValidator>
						    <asp:DropDownList ID="ddlRol"  ForeColor="Black" DataSourceID="odsRoles" OnDataBound="ddlRol_DataBound" DataTextField="DESCRIPCION" DataValueField="ROL" class="form-control" runat="server"></asp:DropDownList>
						</div>
                        
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Fecha desde:</label>
						<div class="col-md-6">
							<asp:Label ID="lblFechaDesde" Visible="false" runat="server" Text="" ></asp:Label>
						    <input id="fecha_salida" class="form-control" onfocus="bloquear()" style="background:#ecf1fa" required type="date"><asp:HiddenField ID="hfFechaSalida" runat="server" />
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Fecha hasta:</label>
						<div class="col-md-6">
							<asp:Label ID="lblFechaHasta" Visible="false" runat="server" Text=""></asp:Label>
						    <input id="fecha_retorno" class="form-control" onfocus="bloquear()" style="background:#ecf1fa" type="date"><asp:HiddenField ID="hfFechaRetorno" runat="server" />
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Descripcion:</label>
						<div class="col-md-6">
						                <asp:TextBox ID="txtDescripcion" ForeColor="Black" TextMode="MultiLine"  class="form-control" runat="server" ></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
						<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
							<asp:Button ID="btnGuardar" CssClass="btn btn-info" runat="server" OnClientClick="recuperarFechaSalida()" OnClick="btnGuardar_Click" Text="Guardar" />
							<asp:Button ID="btnVolverAlta" CssClass="btn btn-default"  runat="server" CausesValidation="false" OnClick="btnVolverAlta_Click" Text="Cancelar" />
						</div>
					</div>
				</div>				
				<!-- end col-8 -->
			
        </asp:View>
		<asp:View ID="View3" runat="server">
										<!-- begin form-group row -->
										<div class="form-group row m-b-10">
											
											<div class="col-md-6">
                                                <asp:Button ID="btnVolverUsuarios" class="btn-sm btn-green btn-block" OnClick="btnVolverUsuarios_Click" runat="server" Text="Volver a personal" />
												<%--<input type="text" name="Ruta" placeholder="" class="form-control" />--%>
											</div>
										</div>
										<!-- end form-group row -->
										<!-- begin page-header -->
											<h1 class="page-header">Administrar Usuarios<small></small></h1>
												<!-- begin form-group row -->
												
											
												<!-- end form-group row -->
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
															<%--<th class="text-wrap">FOTO</th>--%>
															<th class="text-wrap">NOMBRE USUARIO</th>
															<th class="text-nowrap">ROL</th>
															<th class="text-nowrap">FECHA DESDE</th>
															<th class="text-nowrap">FECHA HASTA</th>
															<th class="text-nowrap">DESCRIPCION</th>
															<th class="text-nowrap">ESTADO</th>
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater2" DataSourceID="odsUsuarios" OnItemDataBound="Repeater2_ItemDataBound" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																
															<%--<td><asp:Image ID="Image1" Height="50px" runat="server" ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("filecontent"))  %>' /></td>--%>
															<td><asp:Label ID="lblNombre" runat="server" Text='<%# Eval("USUARIO") %>'></asp:Label></td>
																<td><asp:Label ID="lblPaterno" runat="server" Text='<%# Eval("DESC_ROL") %>'></asp:Label></td>
																<td><asp:Label ID="lblMaterno" runat="server" Text='<%# Eval("FECHA_DESDE") %>'></asp:Label></td>
																<td><asp:Label ID="lblMarital" runat="server" Text='<%# Eval("FECHA_HASTA") %>'></asp:Label></td>
																<td><asp:Label ID="lblTipoDoc" runat="server" Text='<%# Eval("DESCRIPCION") %>'></asp:Label></td>
															<td><asp:Label ID="lblArea" runat="server" Text='<%# Eval("DESC_ESTADO") %>'></asp:Label></td>
															<td>
																<asp:Button ID="btnResetear" style="color:blue" class="btn btn-danger btn-sm" CommandArgument='<%# Eval("USUARIO") %>' OnClick="btnResetear_Click" OnClientClick="return confirm('Seguro que desea resetear su password???')" runat="server" Text="Resetear Password" ToolTip="Su nuevo password sera 123" />
																<asp:Button ID="btnCambiarPassword" style="color:blue" class="btn btn-success btn-sm" CommandArgument='<%# Eval("USUARIO") %>' OnClick="btnCambiarPassword_Click" runat="server" Text="Cambiar Password" ToolTip="Cambiar password actual" />
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
				<div class="col-md-8 offset-md-1">
					
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Cambio de password</legend>
			<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Password anterior:</label>
						<div class="col-md-6">
                            <%--<asp:CheckBox ID="cbPadre"  class="form-control" AutoPostBack="true" Text="SI/NO" OnCheckedChanged="cbPadre_CheckedChanged" Checked="true" runat="server" />--%>
							 <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPasswordAnterior" Font-Bold="True"></asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtPasswordAnterior" runat="server" class="form-control" ForeColor="Black" TextMode="Password" ></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Password nuevo:</label>
						<div class="col-md-6">
                            <%--<asp:CheckBox ID="cbPadre"  class="form-control" AutoPostBack="true" Text="SI/NO" OnCheckedChanged="cbPadre_CheckedChanged" Checked="true" runat="server" />--%>
							 <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPassword" Font-Bold="True"></asp:RequiredFieldValidator>
                             <asp:TextBox ID="txtPassword" runat="server" class="form-control" ForeColor="Black" TextMode="Password" ></asp:TextBox>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- end form-group row -->
						<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
							<asp:Button ID="btnGuardar2" CssClass="btn btn-info" runat="server"  OnClick="btnGuardar2_Click" Text="Guardar" />
							<asp:Button ID="btnCancelar2" CssClass="btn btn-default"  runat="server" CausesValidation="false" OnClick="btnCancelar2_Click" Text="Cancelar" />
						</div>
					</div>
				</div>				
				<!-- end col-8 -->
		</asp:View>
    </asp:MultiView>
	
		</div>
		<!-- end #content -->
	<script type="text/javascript">

        function recuperarFechaSalida() {

            document.getElementById('<%=hfFechaSalida.ClientID%>').value = document.getElementById('fecha_salida').value;
                document.getElementById('<%=hfFechaRetorno.ClientID%>').value = document.getElementById('fecha_retorno').value;
		}
        function setearFechaSalida() {
            document.getElementById('fecha_salida').value = document.getElementById('<%=hfFechaSalida.ClientID%>').value;
		}
        function setearFechaRetorno() {
            document.getElementById('fecha_retorno').value = document.getElementById('<%=hfFechaRetorno.ClientID%>').value;
        }
    </script>
</asp:Content>
