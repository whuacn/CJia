<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditColumTree.aspx.cs" Inherits="CJia.Evaluation.Web.Backstage.EditColumTree" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="rpnl_Main" runat="server" />
        <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
            AutoScroll="true" LabelWidth="70px" CssClass="fontSize" BodyPadding="10px" runat="server" EnableCollapse="True" Height="410">
            <Rows>
                <ext:FormRow ColumnWidths="20% 80%">
                    <Items>
                        <ext:TextBox ID="txt_parent_Column" AutoPostBack="true" ShowRedStar="true" runat="server" MaxLength="100" Required="True" Label="上级栏目" Readonly="true"></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="20% 80%">
                    <Items>
                        <ext:TextBox ID="txt_Column_Nmae" AutoPostBack="true" ShowRedStar="true" runat="server" MaxLength="100" Text="" Required="True" Label="栏目名称"></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="20% 80%">
                    <Items>
                        <ext:TextArea ID="txt_Column_Descript" runat="server" MaxLength="250" Required="True" Label="栏目说明"></ext:TextArea>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="20% 80%">
                    <Items>
                        <ext:DropDownList ID="ddl_ColumnGreade" AutoPostBack="true" runat="server" Label="等级" ShowRedStar="true">
                        </ext:DropDownList>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="20% 80%">
                    <Items>
                        <ext:TextBox ID="txt_Column_No" AutoPostBack="true" ShowRedStar="true" runat="server" MaxLength="100" Required="True" Label="序号"></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="50% 50%" >
                    <Items>
                        <ext:GroupPanel ID="gr_Duty_Dept" Layout="Form" runat="server" Height="200" AutoScroll="true" Title="责任科室" EnableCollapse="false" Hidden="true">
                            <Items>
                                <ext:Tree ID="tree_Duty_Dept" ShowHeader="false" runat="server">
                                </ext:Tree>
                            </Items>
                        </ext:GroupPanel>
                        <ext:GroupPanel ID="gr_Help_Dept" Layout="Form" runat="server" Height="200" AutoScroll="true" Title="协助科室" EnableCollapse="false" Hidden="true">
                            <Items>
                                <ext:Tree ID="tree_Help_Dept" ShowHeader="false" runat="server">
                                </ext:Tree>
                            </Items>
                        </ext:GroupPanel>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextArea ID="txt_Check_Way" AutoPostBack="true"  runat="server" MaxLength="250" Text="" Required="True" Label="评审方法" Enabled="false"></ext:TextArea>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:NumberBox Label="分配分数" ID="txt_Score" runat="server" MaxValue="100" MinValue="0" 
                             NoNegative="True" Required="True" EmptyText="请输入1到100之间的数字" Enabled="false"/>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextArea ID="txt_Score_Standard" AutoPostBack="true"  runat="server" MaxLength="250" Text="" Required="True" Label="评分标准" Enabled="false"></ext:TextArea>
                    </Items>
                </ext:FormRow>
            </Rows>
            <Toolbars>
                <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                    <Items>
                        <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                        <ext:Button runat="server" ID="btn_Save" Icon="SystemSave" Text="保存" OnClick="btn_Save_Click"></ext:Button>
                        <ext:Label ID="Label2" runat="server" Width="5" Text=""></ext:Label>
                        <ext:Button ID="btn_Cancle" Icon="Cancel" runat="server" Text=" 取消 " OnClick="btn_Cancle_Click"></ext:Button>
                        <ext:Label ID="Label1" runat="server" Width="5" Text=""></ext:Label>
                    </Items>
                </ext:Toolbar>
            </Toolbars>
        </ext:Form>
    </form>
</body>
</html>
