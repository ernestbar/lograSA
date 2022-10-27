<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="dominio_admin.aspx.cs" Inherits="appLograAdmin.dominio_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <asp:ObjectDataSource ID="odsDominiosOnly" runat="server" SelectMethod="PR_PAR_GET_ONLY_DOMINIOS" TypeName="appLograAdmin.Clases.Dominios">
		</asp:ObjectDataSource>
	<asp:ObjectDataSource ID="odsDominios" runat="server" SelectMethod="PR_PAR_GET_DOMINIOS" TypeName="appLograAdmin.Clases.Dominios">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlDominio" Name="PV_DOMINIO" Type="String" />
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
			<asp:Label ID="lblDominio" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblCodigo" runat="server" Text="3" Visible="false"></asp:Label>
			<asp:Label ID="lblAviso" runat="server" ForeColor="Blue" Font-Size="Medium" Text=""></asp:Label>
			  <asp:Label ID="lblCodMenuRol" runat="server" Visible="false" Text=""></asp:Label>
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
											<h1 class="page-header">Parametro Dominio:</h1>
											<asp:DropDownList ID="ddlDominio" class="form-control col-md-6" AutoPostBack="true" OnSelectedIndexChanged="ddlDominio_SelectedIndexChanged"  DataSourceID="odsDominiosOnly" DataTextField="dominio" DataValueField="dominio" OnDataBound="ddlDominio_DataBound" runat="server"></asp:DropDownList>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlDominio" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>
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
															<th class="text-wrap">DOMINIO</th>
															<th class="text-nowrap">CODIGO</th>
															<th class="text-nowrap">DESCRIPCION</th>
															<th class="text-nowrap">VALOR CARACTER</th>
															<th class="text-nowrap">VALOR NUMERICO</th>
															<th class="text-nowrap">VALOR FECHA</th>
															<th class="text-nowrap" data-orderable="false">OPCIONES</th>
															
															</tr>
													</thead>
													<tbody>
                                                        <asp:Repeater ID="Repeater1" DataSourceID="odsDominios" OnItemDataBound="Repeater1_ItemDataBound" runat="server">
														<ItemTemplate>
															<tr class="gradeA">
																
															<%--<td><asp:Image ID="Image1" Height="50px" runat="server" ImageUrl='<%# @"Logos\" + Eval("CLI_ID_CLIENTE") + @"\" +  Eval("CLI_LOGO") %>' /></td>--%>
															<td><asp:Label ID="lblEsPrincipal" runat="server" Text='<%# Eval("dominio") %>'></asp:Label></td>
															<td><asp:Label ID="lblRazonSocial" runat="server" Text='<%# Eval("codigo") %>'></asp:Label></td>
															<td><asp:Label ID="lblMedioContacto" runat="server" Text='<%# Eval("descripcion") %>'></asp:Label></td>
															<td><asp:Label ID="lblValor" runat="server" Text='<%# Eval("valor_caracter") %>'></asp:Label></td>
																<td><asp:Label ID="Label1" runat="server" Text='<%# Eval("valor_numerico") %>'></asp:Label></td>
																<td><asp:Label ID="Label2" runat="server" Text='<%# Eval("valor_date") %>'></asp:Label></td>
															<td>
																<asp:Button ID="btnEditar" style="color:blue" class="btn btn-success btn-sm"  CommandArgument='<%# Eval("dominio") +"|"+Eval("codigo") %>' OnClick="btnEditar_Click" runat="server" Text="Editar" ToolTip="Editar" />
																<asp:Button ID="btnEliminar" style="color:blue" class="btn btn-danger btn-sm" CommandArgument='<%# Eval("dominio") +"|"+Eval("codigo") %>' OnClick="btnEliminar_Click" OnClientClick="return confirm('Seguro que desea eliminar el registro???')" runat="server" Text="Eliminar" ToolTip="Borrar registro" />
                                                                
																<%--<asp:Button ID="btnActivar" class="btn btn-success btn-sm" CommandArgument='<%# Eval("CLI_ID_CLIENTE") %>' OnClick="btnActivar_Click" runat="server" Text="Nuevo" ToolTip="Nueva simulacion" />--%>
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
					
					<legend class="no-border f-w-700 p-b-0 m-t-0 m-b-20 f-s-16 text-inverse">Datos Dominio</legend>
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Dominio:</label>
						<div class="col-md-6">
                            <asp:Label ID="lblNombreDominio" runat="server" Text=""></asp:Label>
                            <%--<asp:CheckBox ID="cbPadre"  class="form-control" AutoPostBack="true" Text="SI/NO" OnCheckedChanged="cbPadre_CheckedChanged" Checked="true" runat="server" />--%>
						<%--	<asp:DropDownList ID="ddlCliente" class="form-control"  DataSourceID="odsClientes" DataTextField="CLI_RAZON_SOCIAL" DataValueField="CLI_ID_CLIENTE" OnDataBound="ddlCliente_DataBound" runat="server"></asp:DropDownList>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlCliente" InitialValue="SELECCIONAR"  Font-Bold="True"></asp:RequiredFieldValidator>--%>
						</div>
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Código:</label>
						<div class="col-md-6">
                             <asp:TextBox ID="txtCodigo" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCodigo" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
					</div>
					<!-- end form-group row -->
				<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Descripción:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtDescripcion" class="form-control" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ControlToValidate="txtDescripcion" Font-Bold="True"></asp:RequiredFieldValidator>
						</div>
                        
					</div>
					<!-- end form-group row -->
					Datos opcionales:
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Valor caracter:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtValorCaracter" class="form-control" runat="server"></asp:TextBox>
						</div>
                        
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Valor numérico:</label>
						<div class="col-md-6">
                            <asp:TextBox ID="txtValorNmerico" class="form-control" runat="server"></asp:TextBox>
						</div>
                        
					</div>
					<!-- end form-group row -->
					<!-- begin form-group row -->
					<div class="form-group row m-b-10">
						<label class="col-md-3 text-md-right col-form-label">Valor fecha:</label>
						<div class="col-md-6">
                            <asp:Label ID="lblFechaDesde" runat="server" Text=""></asp:Label>
						    <input id="fecha_salida" class="form-control" style="background:#ecf1fa" type="date"><asp:HiddenField ID="hfFechaSalida" runat="server" />
						</div>
                        
					</div>
					<!-- end form-group row -->
						<div class="btn-toolbar mr-2 sw-btn-group float-right" role="group">
							<asp:Button ID="btnGuardar" CssClass="btn btn-info" OnClientClick="recuperarFechaSalida()" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
							<asp:Button ID="btnVolverAlta" CssClass="btn btn-default"  runat="server" CausesValidation="false" OnClick="btnVolverAlta_Click" Text="Cancelar" />
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
		}
        function setearFechaSalida() {
            document.getElementById('fecha_salida').value = document.getElementById('<%=hfFechaSalida.ClientID%>').value;
        }
    </script>
</asp:Content>
