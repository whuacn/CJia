<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSupervise.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.Supervise.Check" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>江西省卫生监督执法管理系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
</head>
<body>
   <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="sf_Edit" runat="server"/>
        <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
             AutoScroll="true" LabelWidth="85px" BodyPadding="25px 15px" runat="server" EnableCollapse="True">
             <Rows>
                    <ext:FormRow ColumnWidths="30% 30% 30% 10%">
                        <Items>
                            <ext:TextBox ID="txtUserNo" ShowRedStar="true" runat="server" Label="编号" MaxLength="100" Text="" Required="True"></ext:TextBox>
                            <ext:TextBox ID="txtUserName" ShowRedStar="true" runat="server" Label="名称" MaxLength="100" Text="" Required="True"></ext:TextBox>
                            <ext:TextBox ID="txtOrganName" runat="server" Label="组织" MaxLength="100" Readonly="true"></ext:TextBox>
                            <ext:Button ID="btnSelectOrgan" IconUrl="../../Icons/zoom_in.png"  runat="server" Text="选择组织" OnClick="btnSelectOrgan_Click"></ext:Button>
                        </Items>
                    </ext:FormRow> 
                 <ext:FormRow ColumnWidths="100%">
                     <Items>
                          <ext:CheckBox ID="chkSupperMan" runat="server" Text="超级管理员" AutoPostBack="true" OnCheckedChanged="chkSupperMan_CheckedChanged"></ext:CheckBox>
                     </Items>
                 </ext:FormRow>
                     <ext:FormRow ColumnWidths="100%">
                        <Items>
                            <ext:GroupPanel ID="grRole" Layout="Form" runat="server" AutoHeight="true" Title="角色设置" EnableCollapse="false">
                                <Items> 
                                   <ext:Tree ID="treeRole" OnNodeCheck="treeRole_NodeCheck" ShowHeader="false"
                                        Title="功能设置" runat="server">
                                    </ext:Tree>
                            </Items>  
                            </ext:GroupPanel>
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
        <ext:Window ID="win_Edit" Hidden="true" EnableIFrame="true" Icon="ApplicationFormEdit" Target="Parent" runat="server"
            CloseAction="HidePostBack" IsModal="true" Width="880px" Height="550px">
        </ext:Window>
    </form>
</body>
</html>
