<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCheckTitle.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.AddCheckTitle" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>江西省卫生监督执法管理系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="Css/main.css" />
    <style type="text/css">
        .titleColor {
            color: gray;
        }
    </style>
</head>
<body>
    <form id="frm_Main" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="sf_Edit" runat="server" />
        <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
            AutoScroll="true" LabelWidth="70px" BodyPadding="25px 15px" runat="server" EnableCollapse="True">
            <Rows>
                <ext:FormRow ColumnWidths="70% 30%">
                    <Items>
                        <ext:TextBox ID="txt_TitleName" AutoPostBack="true" ShowRedStar="true" runat="server" Label="题目名称" MaxLength="100" Text="" Required="True"></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="34% 33% 33%">
                    <Items>
                        <ext:DropDownList ID="ddl_Big" AutoPostBack="true" runat="server" Label="题目分类" EnableSimulateTree="false" ShowRedStar="true" Width="200" OnSelectedIndexChanged="ddl_Big_SelectedIndexChanged">
                        </ext:DropDownList>
                        <ext:DropDownList ID="ddl_Middle" AutoPostBack="true" runat="server" EnableSimulateTree="true" Label="中分类" Width="200" OnSelectedIndexChanged="ddl_Middle_SelectedIndexChanged">
                        </ext:DropDownList>
                        <ext:DropDownList ID="ddl_Small" runat="server" EnableSimulateTree="true" Label="小分类" Width="200">
                        </ext:DropDownList>
                        <ext:Button ID="btn_ok" Text="确认"  runat="server" OnClick="btn_ok_Click">
                        </ext:Button>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextBox ID="txt_Small" Readonly="true" ShowRedStar="true" runat="server" Label="" MaxLength="100" Text="所选择的题目分类,可选择多个分类。。。" CssClass="titleColor" EmptyText="所选择的题目分类,可选择多个分类。。。"></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:TextArea ID="txt_title_content" Required="True" runat="server" Label="题目内容" Text="" ShowRedStar="true" MaxLength="200" Height="100"></ext:TextArea>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="100%">
                    <Items>
                        <ext:CheckBox ID="cb_IsChoice" Label="选择题" Checked="true" runat="server"></ext:CheckBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="20% 40% 40%">
                    <Items>
                        <ext:TextBox ID="txt_answer1" AutoPostBack="true" runat="server" Label="答案一" MaxLength="100" Text=""></ext:TextBox>
                        <ext:TextBox ID="txt_result1" AutoPostBack="true" runat="server" Label="检查笔录" MaxLength="200" Text=""></ext:TextBox>
                        <ext:TextBox ID="txt_advice1" AutoPostBack="true" runat="server" Label="生成意见" MaxLength="200" Text=""></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="20% 40% 40%">
                    <Items>
                        <ext:TextBox ID="txt_answer2" AutoPostBack="true" runat="server" Label="答案二" MaxLength="100" Text=""></ext:TextBox>
                        <ext:TextBox ID="txt_result2" AutoPostBack="true" runat="server" Label="检查笔录" MaxLength="200" Text=""></ext:TextBox>
                        <ext:TextBox ID="txt_advice2" AutoPostBack="true" runat="server" Label="生成意见" MaxLength="200" Text=""></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="20% 40% 40%">
                    <Items>
                        <ext:TextBox ID="txt_answer3" AutoPostBack="true" runat="server" Label="答案三" MaxLength="100" Text=""></ext:TextBox>
                        <ext:TextBox ID="txt_result3" AutoPostBack="true" runat="server" Label="检查笔录" MaxLength="200" Text=""></ext:TextBox>
                        <ext:TextBox ID="txt_advice3" AutoPostBack="true" runat="server" Label="生成意见" MaxLength="200" Text=""></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="20% 40% 40%">
                    <Items>
                        <ext:TextBox ID="txt_answer4" AutoPostBack="true" runat="server" Label="答案四" MaxLength="100" Text=""></ext:TextBox>
                        <ext:TextBox ID="txt_result4" AutoPostBack="true" runat="server" Label="检查笔录" MaxLength="200" Text=""></ext:TextBox>
                        <ext:TextBox ID="txt_advice4" AutoPostBack="true" runat="server" Label="生成意见" MaxLength="200" Text=""></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="20% 40% 40%">
                    <Items>
                        <ext:TextBox ID="txt_answer5" AutoPostBack="true" runat="server" Label="答案五" MaxLength="100" Text=""></ext:TextBox>
                        <ext:TextBox ID="txt_result5" AutoPostBack="true" runat="server" Label="检查笔录" MaxLength="200" Text=""></ext:TextBox>
                        <ext:TextBox ID="txt_advice5" AutoPostBack="true" runat="server" Label="生成意见" MaxLength="200" Text=""></ext:TextBox>
                    </Items>
                </ext:FormRow>
                <ext:FormRow ColumnWidths="20% 40% 40%">
                    <Items>
                        <ext:TextBox ID="txt_answer6" AutoPostBack="true" runat="server" Label="答案六" MaxLength="100" Text=""></ext:TextBox>
                        <ext:TextBox ID="txt_result6" AutoPostBack="true" runat="server" Label="检查笔录" MaxLength="200" Text=""></ext:TextBox>
                        <ext:TextBox ID="txt_advice6" AutoPostBack="true" runat="server" Label="生成意见" MaxLength="200" Text=""></ext:TextBox>
                    </Items>
                </ext:FormRow>
            </Rows>
            <Toolbars>
                <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                    <Items>
                        <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                        <ext:Button ID="btn_Save" Text="保存" ValidateForms="sf_Edit" runat="server" Icon="TextRuler" OnClick="btn_Save_Click">
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </Toolbars>
        </ext:Form>
    </form>
</body>
</html>
