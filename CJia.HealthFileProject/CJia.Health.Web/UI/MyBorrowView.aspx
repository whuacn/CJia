<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyBorrowView.aspx.cs" Inherits="CJia.Health.Web.UI.MyBorrowView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Js/Main.js"></script>
    <script type="text/javascript">
        //加载页面要使用的CSS
        loadCss(top._skinId, 'Page.css');
    </script>
    <style type="text/css">
        .HeaderStyle {
            color: white;
            background-color: #FFA54F;
            height: 30px;
            line-height: 24px;
            text-align: center;
            vertical-align: middle;
            font-weight: bold;
            font-size: 18px;
        }

        .GridViewStyle {
            border: 0.5px solid #D7D7D7;
            font-size: 15px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblMsg" runat="server" Text="对不起，您没有借阅内容。。。。" Visible="False"></asp:Label>
            <table style="width: 100%" align="center">
                <tr style="width: 100%;">
                    <td colspan="5"><%--AllowPaging="True" PageSize="5" --%>
                        <asp:GridView ID="BorrowListGridView" runat="server" AutoGenerateColumns="False" Width="100%"
                            OnRowCommand="gvCity_RowCommand" OnRowDataBound="gvCity_RowDataBound" CssClass="GridViewStyle" BorderStyle="Solid">
                            <HeaderStyle CssClass="HeaderStyle" />
                            <Columns>
                                <asp:TemplateField HeaderText="申请单编号">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApplyNO" runat="server" Text='<%# Eval("BORROW_LIST_NO") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("BORROW_LIST_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="申请时间">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRecordNO" runat="server" Text='<%# Eval("APPLY_DATE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="申请人">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPatientID" runat="server" Text='<%# Eval("APPLYER_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="申请理由">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPatientName" ToolTip='<%# Eval("APPLY_REASON") %>' runat="server" Text='<%# Eval("APPLY_REASON").ToString().Length>31 ? Eval("APPLY_REASON").ToString().Substring(0,30) + "...." : Eval("APPLY_REASON").ToString() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态">
                                    <ItemTemplate>
                                        <asp:Label ID="inhosTIme" runat="server" Text='<%# Eval("BORROW_STATE_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="开始时间">
                                    <ItemTemplate>
                                        <asp:Label ID="inhosTIe" runat="server" Text='<%# Eval("BORROW_DATE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="截止时间">
                                    <ItemTemplate>
                                        <asp:Label ID="inhosTe" runat="server" Text='<%# Eval("RETURN_DATE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="详细信息">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnDelete1" runat="server" CommandArgument='<%# Eval("BORROW_LIST_ID") %>'
                                            CommandName="MyApplyDetail" Font-Bold="True" ForeColor="Red" Font-Underline="False">
                                            <asp:Label ID="lblFlag" runat="server" Text='详细信息>>'></asp:Label>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%# Eval("BORROW_LIST_ID") %>'
                                            CommandName="MyDelete" OnClientClick="return confirm('确认归还病案吗?')" Font-Bold="True" ForeColor="Red" Font-Underline="False">
                                            <asp:Label ID="lblFlag1" runat="server" Text='归还'></asp:Label>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle BorderColor="#D7D7D7" BorderStyle="Solid" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
