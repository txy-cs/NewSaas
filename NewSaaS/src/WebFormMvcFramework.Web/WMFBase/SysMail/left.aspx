<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="WebFormMvcFramework.Web.WMFBase.SysMail.left" %>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../Themes/Styles/Site.css" rel="stylesheet" type="text/css" />
    <title>电子邮件</title>
</head>
<body style="height: 100%; border-right-width: 1px;	border-right-style: solid;	border-right-color: #cccccc;">
    <form id="form1" runat="server">
        <div class="btnbartitle">
            <div>
                电子邮件
            </div>
        </div>
        <div class="div-body">
            &nbsp;
            &nbsp;
            <asp:LinkButton ID="lbtSearch" runat="server" class="button green" OnClick="lbtSearch_Click"><span class="icon-botton"
            style="background: url('../../Themes/images/16/email_add.png') no-repeat scroll 0px 4px;">
        </span>写 信</asp:LinkButton>
            &nbsp;
                  <asp:LinkButton ID="LinkButton1" runat="server" class="button green" OnClick="LinkButton1_Click"><span class="icon-botton"
            style="background: url('../../Themes/images/16/email_magnify.png') no-repeat scroll 0px 4px;">
        </span>收 信</asp:LinkButton>
        </div>
        <div class="btnbartitle">
            <div>
                邮件
            </div>
        </div>
        <div>
            <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                <Nodes>
                    <asp:TreeNode Text="个人文件夹" ToolTip="个人文件夹" Value="个人文件夹" ImageUrl="~/Themes/Images/个人文件夹.png">
                        <asp:TreeNode Text="收件箱" ToolTip="收件箱" Value="收件箱" ImageUrl="~/Themes/Images/收件箱.png"></asp:TreeNode>
                        <asp:TreeNode Text="已发送" ToolTip="已发送" Value="已发送" ImageUrl="~/Themes/Images/已发送.png"></asp:TreeNode>
                        <asp:TreeNode Text="已删除" ToolTip="已删除" Value="已删除" ImageUrl="~/Themes/Images/已删除.png"></asp:TreeNode>
                    </asp:TreeNode>
                </Nodes>
            </asp:TreeView>
        </div>
    </form>
</body>
</html>
