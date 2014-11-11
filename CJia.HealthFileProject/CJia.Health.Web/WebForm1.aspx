﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CJia.Health.Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
	<link rel="stylesheet" href="styles/main.css" type="text/css" media="screen" charset="utf-8" />

	<style>
		/* General Styles */
		h4 { color: #c5c5c5; margin-top: 50px; }
		body { margin: 0; font-family: Arial; }
		ul#blue-notification-navigation-freebie { display: table; list-style: none; margin: 0 auto; padding: 0; }
		ul#blue-notification-navigation-freebie > li { float: left; margin-right: 20px; margin-bottom: 20px; }
		ul#blue-notification-navigation-freebie > li:last-child { margin-right: 0; }
	</style>
	<script type="text/javascript" src="scripts/jquery-1.8.2.min.js"></script>
	<script type="text/javascript" src="scripts/main.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    	<ul id="blue-notification-navigation-freebie">
		<li>
				<ul class="dropdown blue-notification-navigation">
					<li>
						<div class="header">
							<span class="label" >系统</span>
							<span class="notifications">3</span>
						</div>
						<ul class="menu">
							<li class="iconize"><center>修改密码</center></li>
							<li class="iconize"><center>注销</center></li>
							<li class="iconize"><center>退出</center></li>
						</ul>
					</li>
					<li>
						<div class="header">
							<span class="label">档案借阅</span>
							<span class="notifications">2</span>
						</div>
						<ul class="menu" style="display:none">
							<li class="iconize"><center>修改密码</center></li>
							<li class="iconize"><center>注销</center></li>
							<li class="iconize"><center>退出</center></li>
						</ul>
					</li>
					<li>
						<div class="header">
							<span class="label">档案借阅</span>
							<span class="notifications">3</span>
						</div>
						<ul class="menu" style="display:none">
							<li class="iconize"><center>修改密码</center></li>
							<li class="iconize"><center>注销</center></li>
							<li class="iconize"><center>退出</center></li>
						</ul>
					</li>
					<li>
						<div class="header">
							<span class="label" >档案借阅</span>
							<span class="notifications">5</span>
						</div>
						<ul class="menu" style="display:none">
							<li class="iconize"><center>修改密码</center></li>
							<li class="iconize"><center>注销</center></li>
							<li class="iconize"><center>退出</center></li>
						</ul>
					</li>
					<li>
						<div class="header">
							<span class="label">档案借阅</span>
							<span class="notifications">1</span>
						</div>
						<ul class="menu" style="display:none">
							<li class="iconize"><center>修改密码</center></li>
							<li class="iconize"><center>注销</center></li>
							<li class="iconize"><center>退出</center></li>
						</ul>
					</li>
				</ul>
		</li>
	</ul>
    </div>
    </form>
</body>
</html>