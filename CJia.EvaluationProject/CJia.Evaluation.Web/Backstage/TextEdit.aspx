<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TextEdit.aspx.cs" Inherits="CJia.Evaluation.Web.Backstage.TextEdit" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<%@ Register Assembly="ExtAspNet" Namespace="ExtAspNet" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" id="Icon" />
    <link rel="stylesheet" type="text/css" href="../../Css/main.css" />
    <script type="text/javascript" src="../ckeditor/ckeditor.js" charset="utf-8"></script>
    <script type="text/javascript" src="../ckfinder/ckfinder.js" charset="utf-8"></script>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <ext:PageManager ID="PageManager1" AjaxAspnetControls="FCKeditor1" runat="server" />
    <ext:ContentPanel ID="ContentPanel1" runat="server" Width="1000" BodyPadding="5px"
        EnableBackgroundColor="true" ShowBorder="true" ShowHeader="true" Title="标题">
        <%--<textarea id ="post_content" name="post_content">编辑</textarea>
        <script type="text/javascript">
            var editor = CKEDITOR.replace('post_content');          // 创建编辑器
            CKFinder.setupCKEditor(editor, '/ckfinder/');   // 为编辑器绑定"上传控件"
        </script>--%>
    <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server"></CKEditor:CKEditorControl>
    <ext:Button ID="Button1" Text="Button" runat="server"  OnClick="Button1_Click"></ext:Button>
    <%--<ext:HtmlEditor ID="HtmlEditor1" Height="250px" Width="500"  runat="server"></ext:HtmlEditor>--%>
    <%--<iframe id="message" width="550" height="350" runat="server" ></iframe>--%>
    <pre id="pre" runat="server" width="550" height="350"></pre>
    </ext:ContentPanel>
    </form>
</body>
</html>
