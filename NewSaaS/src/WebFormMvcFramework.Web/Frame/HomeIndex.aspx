<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeIndex.aspx.cs" Inherits="WebFormMvcFramework.Web.Frame.HomeIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%=System.Web.Configuration.WebConfigurationManager.AppSettings["Title"].ToString() %></title>
</head>
<body >
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </form>
</body>
</html>
