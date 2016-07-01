<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo_Import.aspx.cs" Inherits="WebFormMvcFramework.Web.WMFBase.SysUser.UserInfo_Import" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户导入</title>
    <link href="../../Themes/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="../../Themes/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/Validator/JValidator.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/artDialog/artDialog.source.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/artDialog/iframeTools.source.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/jquery.md5.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/FunctionJS.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" class="frm">
            <tr>
                <td>角色：</td>
                <td>
                    <asp:DropDownList ID="ddl_Role" runat="server" Width="194px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>文件：</td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>导入方式：</td>
                <td>
                    <asp:DropDownList ID="ddl_ImportMode" runat="server" Width="194px">
                        <asp:ListItem>清空</asp:ListItem>
                        <asp:ListItem Value="覆盖">覆盖</asp:ListItem>
                        <asp:ListItem>跳过</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <div class="frmbottom">
            <asp:LinkButton ID="Save" runat="server" class="l-btn"
                OnClick="Save_Click"><span class="l-btn-left">
            <img src="../../Themes/Images/disk.png" alt="" />导 入</span></asp:LinkButton>
            <a class="l-btn" href="javascript:void(0)" onclick="OpenClose();"><span class="l-btn-left">
                <img src="../../Themes/Images/cancel.png" alt="" />关 闭</span></a>
        </div>
    </form>
</body>
</html>
