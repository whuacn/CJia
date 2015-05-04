<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyReceipt.aspx.cs" Inherits="CJia.Health.ExtWeb.UI.MyReceipt" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>病案借阅申请系统</title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="../Css/main.css" />
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="pm_Main" AutoSizePanelID="rpnl_Main" runat="server" />
    <ext:RegionPanel ID="rpnl_Main" ShowBorder="false" runat="server">
            <Regions>
                <ext:Region ID="ren_Center" ShowHeader="false" Layout="Fit" Position="Center" Margins="2 0 2 2" runat="server">
                    <Items>
                        <ext:Form ID="sf_Edit" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            AutoScroll="true"  runat="server" EnableCollapse="True">
                            <Rows>
                                <ext:FormRow ColumnWidths="72% 28%">
                                    <Items>
                                        <ext:TextBox ID="txt_unitName" AutoPostBack="true" ShowRedStar="true" runat="server" Label="单位名称" Readonly="true" MaxLength="100" Text="" Required="True"></ext:TextBox>
                                        <ext:Button ID="btn_selectUnit" IconUrl="Icons/zoom_in.png" runat="server" Text="选择单位" ></ext:Button>
                                    </Items>
                                </ext:FormRow>
                                <ext:FormRow ColumnWidths="85% 15%">
                                    <Items>
                                        <ext:TextBox ID="txt_Task" AutoPostBack="true" ShowRedStar="true" runat="server" Label="任务名称"  MaxLength="100" Text="" Required="True"></ext:TextBox>
                                        <ext:Button ID="btn_selectTask" IconUrl="Icons/zoom_in.png" runat="server" Text="选择任务"  ></ext:Button>
                                    </Items>
                                </ext:FormRow>
                                <ext:FormRow ColumnWidths="50% 50%">
                                    <Items>
                                        <ext:DropDownList ID="ddl_wuzheng" AutoPostBack="true" runat="server" Label="是否无证" EnableSimulateTree="true">
                                            <ext:ListItem Text="无证" Value="0" />
                                            <ext:ListItem Text="有证" Value="1" Selected="true"/>
                                            <ext:ListItem Text="不用发证" Value="2" />
                                        </ext:DropDownList>
                                        <ext:DropDownList ID="ddl_jiandang" AutoPostBack="true" runat="server" EnableSimulateTree="true" Label="是否已建档">
                                            <ext:ListItem Text="未建" Value="0" Selected="true"/>
                                            <ext:ListItem Text="已建" Value="1" />
                                        </ext:DropDownList>
                                    </Items>
                                </ext:FormRow>
                            </Rows>
                            <Toolbars>
                                <ext:Toolbar ID="tbr_Search" Position="Bottom" runat="server">
                                    <Items>
                                        <ext:ToolbarFill ID="tf_sb" runat="server"></ext:ToolbarFill>
                                        <ext:Button runat="server" ID="btn_visualSave" ClientIDMode="Static" Hidden="true"  ></ext:Button>
                                        <ext:Label ID="Label2" runat="server" Width="5" Text=""></ext:Label>
                                        <ext:Button ID="btn_ResultAdvice"  runat="server" Text="   检查笔录和意见书   " ValidateForms="sf_Edit"  ></ext:Button>
                                        <ext:Label ID="Label1" runat="server" Width="5" Text=""></ext:Label>
                                        <%--<ext:Button ID="btn_advice" IconUrl="../../Icons/table_column.png" runat="server" Text="   意见书   "></ext:Button>
                                        <ext:Label ID="Label2" runat="server" Width="5" Text=""></ext:Label>--%>
                                        <ext:Button ID="btn_Save" Text="保存" ValidateForms="sf_Edit" runat="server" Icon="TextRuler"  >
                                        </ext:Button>
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
