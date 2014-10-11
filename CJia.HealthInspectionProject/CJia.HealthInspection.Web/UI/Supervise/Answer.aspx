<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Answer.aspx.cs" Inherits="CJia.HealthInspection.Web.UI.Supervise.Answer" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>江西省卫生监督执法管理系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="Css/main.css" />
    <%--<script type="text/javascript">
        document.ge
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <ext:PageManager ID="pm_Main" AutoSizePanelID="rpnl_Main" runat="server" />
        <ext:RegionPanel ID="rpnl_Main" ShowBorder="false" runat="server">
            <Regions>
                <ext:Region ID="ren_Center" ShowHeader="false" Layout="Fit" Position="Center" ShowBorder="false" runat="server">
                    <Items>
                        <ext:Form ID="Form2" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            AutoScroll="true" LabelWidth="75px" runat="server" BodyPadding="10px 5px" EnableCollapse="True">
                            <Rows>
                                <ext:FormRow ColumnWidths="100%">
                                    <Items>
                                        <ext:TextBox ID="txtCheckTitleName" ShowRedStar="true" runat="server" Label="题目名称" Readonly="true" Text="" Required="True"></ext:TextBox>
                                    </Items>
                                </ext:FormRow>
                            </Rows>
                            <Rows>
                                <ext:FormRow ColumnWidths="100%">
                                    <Items>
                                        <ext:TextArea ID="areaCheckTitleContent" ShowRedStar="true" Height="105px" runat="server" Label="题目内容" Text="" Readonly="true" Required="True"></ext:TextArea>
                                    </Items>
                                </ext:FormRow>
                            </Rows>
                            <Rows>
                                <ext:FormRow ColumnWidths="100%" ID="radioRow" runat="server">
                                    <Items>
                                        <%--<ext:RadioButtonList ID="radioAnswer2" runat="server" Label="选择结果" AutoPostBack="true" OnSelectedIndexChanged="radioAnswer2_SelectedIndexChanged">
                            <ext:RadioItem Text="1"/>
                            <ext:RadioItem Text="2"/>
                        </ext:RadioButtonList>--%>
                                    </Items>
                                </ext:FormRow>
                            </Rows>
                            <Rows>
                                <ext:FormRow>
                                    <Items>
                                        <ext:TextArea ID="texCheckRusult" runat="server" ShowRedStar="true" Height="105" Label="检查笔录" Text=""></ext:TextArea>
                                    </Items>
                                </ext:FormRow>
                            </Rows>
                            <Rows>
                                <ext:FormRow>
                                    <Items>
                                        <ext:TextArea ID="txtCheckAdvice" runat="server" ShowRedStar="true" Height="105" Label="检查意见"></ext:TextArea>
                                    </Items>
                                </ext:FormRow>
                                <%--<ext:FormRow ColumnWidths="50% 50%">
                                    <Items>
                                        <ext:TextBox runat="server" ID="TextBox1" Label="测试" Required="true" AutoPostBack="true" OnTextChanged="TextBox1_TextChanged" EnableAjax="true"></ext:TextBox>
                                        <ext:Label ID="labResult" runat="server"></ext:Label>
                                    </Items>
                                </ext:FormRow>--%>
                            </Rows>
                            <Toolbars>
                                <ext:Toolbar ID="Toolbar1" Position="Bottom" runat="server">
                                    <Items>
                                        <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                                        <ext:Label ID="Label1" runat="server" Width="5" Text=""></ext:Label>
                                        <ext:Button runat="server" ID="btn_visualNext" ClientIDMode="Static" Hidden="true" OnClick="btn_visualNext_Click"></ext:Button>
                                        <ext:Button ID="btn_LastTitle" IconUrl="../../Icons/table_column.png" runat="server" Text="   上一题   " OnClick="btn_LastTitle_Click"></ext:Button>
                                        <ext:Button ID="btn_NextTitle" IconUrl="../../Icons/table_column.png" runat="server" Text="   下一题   " OnClick="btn_NextTitle_Click"></ext:Button>
                                        <%--<ext:Label ID="Label2" runat="server" Width="5" Text=""></ext:Label>
                                        <ext:Button ID="btn_Save" Text="保存" ValidateForms="sf_Edit" runat="server" Icon="TextRuler">
                                        </ext:Button>--%>
                                    </Items>
                                </ext:Toolbar>
                            </Toolbars>
                        </ext:Form>
                    </Items>

                </ext:Region>
            </Regions>
        </ext:RegionPanel>

    </form>
</body>
</html>
