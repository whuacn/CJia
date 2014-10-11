<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstOne.aspx.cs" Inherits="CJia.Evaluation.Web.FrontStage.FirstOne" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Css/Style.css" rel="stylesheet" />
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <script src="../Js/tab.js"></script>
    <script src="../Js/jquery-1.8.0.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".ontitle").mouseenter(function () {
                $(this).css('color', '#007ACC');
            });
            $(".ontitle").mouseleave(function () {
                $(this).css('color', '#666');
            });
        });
    </script>
</head>
<body>
    <div id="warp" runat="server">
        <h2 runat="server" id="title"></h2>
        <div class="list">
            <ul>
                <li class="a1">评审标准</li>
                <li class="a2">评审要点/方法/标准</li>
                <li class="a3">评审文档</li>
            </ul>
            <ul class="myul" runat="server" id="myul">
                <li class="myli" runat="server" id="myli"><</li>
            </ul>
            <dl>
                <dt class="b1" runat="server" id="subContent"></dt>
                <dt class="b2">
                    <asp:Repeater ID="abcRep" runat="server">
                        <ItemTemplate>
                            <span runat="server"><%# GetABC(DataBinder.Eval(Container.DataItem,"COLUMN_TREE_ID").ToString())%></span>
                        </ItemTemplate>
                    </asp:Repeater>
                    <span style="visibility: hidden; height: 1px; padding: 0px; margin: 0; line-height: 1px;"></span>
                </dt>
                <dd id="MstTtz_001_1">
                    <strong id="MstTtz_001">
                        <em class="c1" onmouseover="GetTab('MstTtz_001',0)"><%=FirstContent%></em>
                        <asp:Repeater ID="sub_list2" runat="server">
                            <ItemTemplate>
                                <em class="c2" onmouseover="GetTab('MstTtz_001',<%# GetSubNum()%>)"><%# Eval("COLUMN_TREE_NAME") %></em>
                            </ItemTemplate>
                        </asp:Repeater>
                    </strong>
                    <span>
                        <asp:Repeater ID="dataRep1" runat="server">
                            <ItemTemplate>
                                <a href='<%# GetHref(DataBinder.Eval(Container.DataItem,"COLUMN_TREE_ID").ToString(),DataBinder.Eval(Container.DataItem,"DATA_CONTENT").ToString(),DataBinder.Eval(Container.DataItem,"DATA_NAME").ToString())%>' target="_blank" title="<%# Eval("DATA_NAME") %>">
                                    <div><%# Eval("DATA_NAME").ToString().Length>24?Eval("DATA_NAME").ToString().Substring(0,24):Eval("DATA_NAME").ToString() %></div>
                                    <%# Eval("CREATER_DATE") %></a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </span>
                    <asp:Repeater ID="dataRep2" runat="server" OnItemDataBound="dataRep2_ItemDataBound">
                        <ItemTemplate>
                            <span style="display: none;">
                                <asp:Repeater ID="dataRep" runat="server">
                                    <ItemTemplate>
                                        <a href='<%# GetHref(DataBinder.Eval(Container.DataItem,"COLUMN_TREE_ID").ToString(),DataBinder.Eval(Container.DataItem,"DATA_CONTENT").ToString(),DataBinder.Eval(Container.DataItem,"DATA_NAME").ToString())%>' target="_blank" title="<%# Eval("DATA_NAME") %>">
                                            <div><%# Eval("DATA_NAME").ToString().Length>24?Eval("DATA_NAME").ToString().Substring(0,24):Eval("DATA_NAME").ToString() %></div>
                                            <%# Eval("CREATER_DATE") %></a>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </span>
                        </ItemTemplate>
                    </asp:Repeater>
                </dd>
            </dl>
        </div>
        <h6 style="visibility: hidden">占位</h6>
    </div>
</body>
</html>
