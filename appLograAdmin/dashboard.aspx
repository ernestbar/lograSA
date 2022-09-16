<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="appLograAdmin.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:Label ID="lblUsuario" runat="server" Visible="false" Text=""></asp:Label> 
	<!-- begin #content -->
		<div id="content" class="content">
     <!-- begin page-header -->
			<h1 class="page-header">Dashboard  <small>estado general AmasCuotas</small></h1>
			<!-- end page-header -->
			<!-- begin row -->
			<div class="row">
				<!-- begin col-3 -->
				<div class="col-lg-3 col-md-6">
					<div class="widget widget-stats bg-gradient-teal">
						<div class="stats-icon stats-icon-lg"><i class="fa fa-globe fa-fw"></i></div>
						<div class="stats-content">
							<div class="stats-title">TOTAL SOLICITUDES</div>
							<div class="stats-number">5.000</div>
							<div class="stats-progress progress">
								<div class="progress-bar" style="width: 70.1%;"></div>
							</div>
							<div class="stats-desc">Mejor que el mes anterior (70.1%)</div>
						</div>
					</div>
				</div>
				<!-- end col-3 -->
				<!-- begin col-3 -->
				<div class="col-lg-3 col-md-6">
					<div class="widget widget-stats bg-gradient-blue">
						<div class="stats-icon stats-icon-lg"><i class="fa fa-dollar-sign fa-fw"></i></div>
						<div class="stats-content">
							<div class="stats-title">TOTAL APROBACIONES</div>
							<div class="stats-number">1.000</div>
							<div class="stats-progress progress">
								<div class="progress-bar" style="width: 40.5%;"></div>
							</div>
							<div class="stats-desc">Mejor que el mes anterior (40.5%)</div>
						</div>
					</div>
				</div>
				<!-- end col-3 -->
				<!-- begin col-3 -->
				<div class="col-lg-3 col-md-6">
					<div class="widget widget-stats bg-gradient-purple">
						<div class="stats-icon stats-icon-lg"><i class="fa fa-archive fa-fw"></i></div>
						<div class="stats-content">
							<div class="stats-title">NUEVAS SOLICITUDES</div>
							<div class="stats-number">555</div>
							<div class="stats-progress progress">
								<div class="progress-bar" style="width: 76.3%;"></div>
							</div>
							<div class="stats-desc">Mejor que el mes anterior (76.3%)</div>
						</div>
					</div>
				</div>
				<!-- end col-3 -->
				<!-- begin col-3 -->
				<div class="col-lg-3 col-md-6">
					<div class="widget widget-stats bg-gradient-black">
						<div class="stats-icon stats-icon-lg"><i class="fa fa-comment-alt fa-fw"></i></div>
						<div class="stats-content">
							<div class="stats-title">SOLICITUDES RECHAZADAS</div>
							<div class="stats-number">300</div>
							<div class="stats-progress progress">
								<div class="progress-bar" style="width: 54.9%;"></div>
							</div>
							<div class="stats-desc">Mejor que el anterior mes (54.9%)</div>
						</div>
					</div>
				</div>
				<!-- end col-3 -->
			</div>
			<!-- end row -->
			<!-- begin row -->
			<div class="row">
				<!-- begin col-8 -->
				<div class="col-lg-8">
					<div class="widget-chart with-sidebar inverse-mode">
						<div class="widget-chart-content bg-black">
							<h4 class="chart-title">
								Solicitudes nacionales
								<small>Tenemos mas solicitudes de</small>
							</h4>
							<div id="visitors-line-chart" class="widget-chart-full-width nvd3-inverse-mode" style="height: 260px;"></div>
						</div>
						<div class="widget-chart-sidebar bg-black-darker">
							<div class="chart-number">
								7.000
								<small>Total solicitudes</small>
							</div>
							<div id="visitors-donut-chart" class="nvd3-inverse-mode p-t-10" style="height: 180px"></div>
							<ul class="chart-legend f-s-11">
								<li><i class="fa fa-circle fa-fw text-primary f-s-9 m-r-5 t-minus-1"></i> 34.0% <span>La Paz</span></li>
								<li><i class="fa fa-circle fa-fw text-success f-s-9 m-r-5 t-minus-1"></i> 56.0% <span>Santa Cruz</span></li>
							</ul>
						</div>
					</div>
				</div>
				<!-- end col-8 -->
				<!-- begin col-4 -->
				<%--<div class="col-lg-4">
					<div class="panel panel-inverse" data-sortable-id="index-1">
						<div class="panel-heading">
							<h4 class="panel-title">
								Visitors Origin
							</h4>
						</div>
						<div id="visitors-map" class="bg-black" style="height: 179px;"></div>
						<div class="list-group">
							<a href="javascript:;" class="list-group-item list-group-item-inverse d-flex justify-content-between align-items-center text-ellipsis">
								1. United State 
								<span class="badge f-w-500 bg-gradient-teal f-s-10">20.95%</span>
							</a> 
							<a href="javascript:;" class="list-group-item list-group-item-inverse d-flex justify-content-between align-items-center text-ellipsis">
								2. India
								<span class="badge f-w-500 bg-gradient-blue f-s-10">16.12%</span>
							</a>
							<a href="javascript:;" class="list-group-item list-group-item-inverse d-flex justify-content-between align-items-center text-ellipsis">
								3. Mongolia
								<span class="badge f-w-500 bg-gradient-grey f-s-10">14.99%</span>
							</a>
						</div>
					</div>
				</div>--%>
				<!-- end col-4 -->
			</div>
			<!-- end row -->
			</div>
</asp:Content>
