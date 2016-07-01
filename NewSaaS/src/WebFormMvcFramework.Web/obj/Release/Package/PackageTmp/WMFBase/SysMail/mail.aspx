<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mail.aspx.cs" Inherits="WebFormMvcFramework.Web.WMFBase.SysMail.mail" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>电子邮件</title>
</head>
<frameset rows="*" cols="200,*" framespacing="0" frameborder="no" border="0">
  <frame src="left.aspx" name="leftFrame" scrolling="No"  id="leftFrame" />
  <frameset rows="*">
    <frame src="recipient.aspx" name="center" id="center" />
  </frameset>
</frameset>
<body>
    <form id="form1" runat="server">
    </form>
</body>
<noframes></noframes>
</html>
