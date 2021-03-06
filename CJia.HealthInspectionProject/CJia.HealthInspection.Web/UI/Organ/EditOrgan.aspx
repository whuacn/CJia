﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditOrgan.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.Organ.EditOrgan" %>
<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
      <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="sf_Edit" runat="server"/>
        <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
             AutoScroll="true" LabelWidth="85px" BodyPadding="25px 15px" runat="server" EnableCollapse="True">
             <Rows>
                    <ext:FormRow ColumnWidths="30% 30% 40%">
                        <Items>
                            <ext:TextBox ID="txtOrganNo" ShowRedStar="true" runat="server" Label="组织编号" MaxLength="100" Text="" Required="True"></ext:TextBox>
                            <ext:TextBox ID="txtOrganName" ShowRedStar="true" runat="server" Label="组织名称" MaxLength="100" Text="" Required="True"></ext:TextBox>
                         <%--   <ext:DropDownList ID="ddlArea" runat="server" Label="区域代码" EnableSimulateTree="true">                       
                            </ext:DropDownList>--%>
                             <ext:TextBox ID="txtArea" ShowRedStar="true" runat="server" Label="区域名称" ShowEmptyLabel="true" EmptyText="请在下列展开树中选择区域" Readonly="true" MaxLength="100" Text="" Required="True"></ext:TextBox>
                        </Items>
                    </ext:FormRow> 
                 <ext:FormRow ColumnWidths="100%">
                     <Items>
                      <ext:Tree ID="treeArea" ShowHeader="false" Title="区域选择" runat="server" OnNodeCommand="treeArea_NodeCommand">
                            </ext:Tree>
                         </Items>
                 </ext:FormRow>
                </Rows>
             <Toolbars>
                <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                    <Items>
                        <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                        <ext:Button ID="btnSave" Text="保存"  ValidateForms="sf_Edit" runat="server" Icon="TextRuler" OnClick="btnSave_Click">
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </Toolbars>
        </ext:Form>
    </form>
</body>
</html>
