<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReadBorrowView.aspx.cs" Inherits="CJia.Health.Web.UI.ReadBorrowView" %>

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
            <asp:Label ID="lblMsg" runat="server" Text="对不起，您没有借阅的病案。。。。" Visible="False"></asp:Label>
            <table style="width: 100%" align="center">
                <tr style="width: 100%;">
                    <td><%--AllowPaging="True" PageSize="5" --%>
                        <asp:GridView ID="PatientGridView" runat="server" AutoGenerateColumns="False" Width="100%"
                            OnRowCommand="gvCity_RowCommand" OnRowDataBound="gvCity_RowDataBound" CssClass="GridViewStyle" BorderStyle="Solid">
                            <HeaderStyle CssClass="HeaderStyle" />
                            <Columns>
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID4" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="病案号">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRecordNO" runat="server" Text='<%# Eval("RECORDNO") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="病人ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPatientID" runat="server" Text='<%# Eval("PATIENT_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="病人姓名">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPatientName" runat="server" Text='<%# Eval("PATIENT_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="性别">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGender" runat="server" Text='<%# Eval("GENDER_NAME") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="出院日期">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl4" runat="server" Text='<%# DateTime.Parse(Eval("OUT_HOSPITAL_DATE").ToString()).ToShortDateString() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="出院科室">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl5" runat="server" Text='<%# Eval("OUT_HOSPITAL_DEPT_NAME")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="出院医生">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl6" runat="server" Text='<%# Eval("OUT_HOSPITAL_DOCTOR_NAME")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="详细信息">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtnDeletef" runat="server" CommandArgument='<%# Eval("RECORDNO") %>'
                                            CommandName="MyPatient" Font-Bold="True" ForeColor="Red" Font-Underline="False">
                                            <asp:Label ID="lblFlag" runat="server" Text='详细信息>>'></asp:Label>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="档案信息">
                                    <ItemTemplate>
                                        <a href="javascript:top.myTab.Cts('<%# Eval("PATIENT_NAME") %>「<%# Eval("RECORDNO") %>」档案','MyPictureView.aspx?id=<%#Eval("ID")%>')" style="font-weight: bold; text-decoration: none; color: red">第『<asp:Label ID="inhosTIme" runat="server" Text='<%# Eval("IN_HOSPITAL_TIME") %>' ForeColor="Blue"></asp:Label>』次入院
                                        </a>
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
