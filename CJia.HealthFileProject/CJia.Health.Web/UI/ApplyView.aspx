<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyView.aspx.cs" Inherits="CJia.Health.Web.UI.ApplyView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>病案借阅申请</title>
    <script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.8.18.custom.min.js" type="text/javascript"></script>
    <script src="../js/menu.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-1.8.0.min.js"></script>
    <style type="text/css">
        li {
            list-style: none;
        }

        #tab2 {
            height: 35px;
            border-bottom: 0;
        }

            #tab2 ul {
                margin: 0;
                padding: 0;
            }

            #tab2 li {
                float: left;
                padding: 0 10px;
                height: 35px;
                line-height: 35px;
                text-align: center;
                border-bottom: none;
                border-right: 1px solid #0ca2ff;
                cursor: pointer;
                background-color: white;
                color: #0ca2ff;
            }

                #tab2 li.now {
                    color: white;
                    background: #6ed0ff;
                    font-weight: bold;
                }

        .tablist {
            border-top: 10px;
            display: none;
        }

        .block {
            display: block;
        }

        .HeaderStyle {
            color: white;
            background-color: #FF6600;
            height: 30px;
            line-height: 24px;
            text-align: center;
            vertical-align: middle;
            font-weight: bold;
            font-size: 18px;
        }

        .GridViewStyle {
            border: 1px solid #D7D7D7;
            font-size: 15px;
            text-align: center;
        }
    </style>
    <script type="text/javascript">
        function setTab(m, n) {
            var menu = document.getElementById("tab" + m).getElementsByTagName("li");
            var div = document.getElementById("tablist" + m).getElementsByTagName("div");

            var showdiv = [];
            for (i = 0; j = div[i]; i++) {
                if ((" " + div[i].className + " ").indexOf(" tablist ") != -1) {
                    showdiv.push(div[i]);
                }
            }
            for (i = 0; i < menu.length; i++) {
                menu[i].className = i == n ? "now" : "";
                showdiv[i].style.display = i == n ? "block" : "none";
            }
        }
        function ClientValidate(source, arguments) {
            if (arguments.Value.length < 6)
                arguments.IsValid = false;
            else
                arguments.IsValid = true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 0 20px 130px 20px">
            <div style="height: 35px; width: 160px; background-image: url(images/top.png); text-align: center; line-height: 35px; font-size: 20px; font-weight: bold; color: #333333; float: left">
            </div>
            <div id="tab2" style="border-width: 1px; border-color: #0ca2ff; float: right; border-top-style: solid; border-left-style: solid;">
                <ul>
                    <li onclick="setTab(2,0)" class="now">单份病案</li>
                    <li onclick="setTab(2,1)">多份病案</li>
                </ul>
            </div>
            <div style="border: 1px solid #0f95e2; width: 100%; float: left">
                <div id="tablist2">
                    <div class="tablist block" style="padding-bottom: 30px">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <table style="width: 100%" align="center">
                                    <tr style="width: 100%;height: 40px;">
                                        <td style="width:9%; height: 40px; font-size: 16px; text-align: right">病案号:
                                        </td>
                                        <td style="width: 18%;">
                                            <asp:TextBox ID="txtPatientID" runat="server" BorderStyle="Solid" BorderWidth="1" BorderColor="#0F95E2"
                                                Height="20px" Width="150px" Font-Bold="True" ForeColor="#666666" Font-Size="Large"></asp:TextBox>
                                        </td>
                                        <td style="width: 10%; height: 40px; font-size: 16px; text-align: right">病人姓名:
                                        </td>
                                        <td style="width: 18%;">
                                            <asp:TextBox ID="txtPatientName" runat="server" BorderStyle="Solid" BorderWidth="1" BorderColor="#0F95E2"
                                                Height="20px" Width="150px" Font-Bold="True" ForeColor="#666666" Font-Size="Large"></asp:TextBox>
                                        </td>
                                        <td style="width:9%; height: 40px; font-size: 16px; text-align: right">时间范围:
                                        </td>
                                        <td style="width: 18%;height: 40px;">

                                        </td>
                                        <td style="text-align: left; width: 5%">
                                            <asp:Button ID="btnSelect" runat="server" Text="查询" BackColor="#6ED0FF" Font-Bold="True"
                                                Font-Size="Large" ForeColor="White" Height="25px" Width="60px" OnClick="btnSelect_Click" />
                                        </td>
                                        <td style="height: 40px; font-size: 16px; color: red;">
                                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="width:100%;">
                                        <td colspan="8">
                                            <asp:GridView ID="RecordGridView" runat="server" AutoGenerateColumns="False" Width="100%"
                                                AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                OnRowCommand="gvCity_RowCommand" OnRowDataBound="gvCity_RowDataBound" CssClass="GridViewStyle" BorderStyle="Solid">
                                                <HeaderStyle CssClass="HeaderStyle" />
                                                <Columns>
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
                                                            <asp:Label ID="lblGender" runat="server" Text='<%#Eval("GENDER_NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="出生日期">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBirthDay" runat="server" Text='<%# DateTime.Parse(Eval("BIRTHDAY").ToString()).ToShortDateString() %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="操作">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%# Eval("RECORDNO") %>'
                                                                CommandName="MyApply" Font-Bold="True" ForeColor="Red" Enabled='<%# Eval("ENABLE") %>'>
                                                                <asp:Label ID="lblFlag" runat="server" Text='<%# Eval("FLAG") %>'></asp:Label></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle BorderColor="#D7D7D7" BorderStyle="Solid" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="tablist">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table style="width: 100%" align="center">
                                    <tr>
                                        <td style="height: 40px; font-size: 20px; font-weight: bold; text-align: center"></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 40px; font-size: 20px; font-weight: bold; text-align: center"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%"
                                                AllowPaging="True" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                OnRowCommand="gvCity_RowCommand" OnRowDataBound="gvCity_RowDataBound" CssClass="GridViewStyle">
                                                <HeaderStyle CssClass="HeaderStyle" />
                                                <Columns>
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
                                                            <asp:Label ID="lblGender" runat="server" Text='<%# Eval("GENDER") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="出生日期">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBirthDay" runat="server" Text='<%# Eval("BIRTHDAY") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="操作">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnDelete" runat="server" CommandArgument='<%# Eval("RECORDNO") %>'
                                                                CommandName="MyDelete" Font-Bold="True" ForeColor="Red">
                                                                <asp:Label ID="lblFlag" runat="server" Text='<%# Eval("FLAG") %>'></asp:Label></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
