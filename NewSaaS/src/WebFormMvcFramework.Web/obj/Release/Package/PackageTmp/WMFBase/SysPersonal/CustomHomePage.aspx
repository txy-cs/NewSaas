<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomHomePage.aspx.cs" Inherits="WebFormMvcFramework.Web.WMFBase.SysPersonal.CustomHomePage" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>自定义主页</title>
    <link href="../../Themes/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="../../Themes/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/FunctionJS.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../../Themes/kindeditor-4.1.10/themes/default/default.css" />
    <link rel="stylesheet" href="../../Themes/kindeditor-4.1.10/plugins/code/prettify.css" />
    <script charset="utf-8" src="../../Themes/kindeditor-4.1.10/kindeditor.js"></script>
    <script charset="utf-8" src="../../Themes/kindeditor-4.1.10/lang/zh_CN.js"></script>
    <script charset="utf-8" src="../../Themes/kindeditor-4.1.10/plugins/code/prettify.js"></script>
    <script>
        KindEditor.ready(function (K) {
            var editor1 = K.create('#content1', {
                cssPath: '../../Themes/kindeditor-4.1.10/plugins/code/prettify.css',
                uploadJson: '../../Themes/kindeditor-4.1.10/asp.net/upload_json.ashx',
                fileManagerJson: '../../Themes/kindeditor-4.1.10/asp.net/file_manager_json.ashx',
                items: [
        'source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'cut', 'copy', 'paste',
        'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
        'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent', 'subscript',
        'superscript', 'clearhtml', 'quickformat', 'selectall', '|', 'fullscreen', '/',
        'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
        'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image',
        'flash', 'media', 'insertfile', 'table', 'hr', 'emoticons', 'map', 'code', 'pagebreak',
        'link', 'unlink', '|'
                ],
                allowFileManager: true,
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                },
                afterBlur: function () { this.sync(); }
            });
            prettyPrint();
        });
        function MainSwitch() {
            window.top.location.href = "<%=WebFormMvcFramework.Common.DotNetConfig.ConfigHelper.GetAppSettings("VirtualDirectory") %>Frame/MainSwitch.aspx";
            return false;
        }
    </script>
</head>
<body>
    <form id="example" runat="server">
        <div class="btnbartitle">
            <div>
                自定义主页
            </div>
        </div>
        <div class="btnbarcontetn" style="margin-bottom: 1px;">
            <div style="float: left;">
                <table style="padding: 0px; margin: 0px; height: 100%;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td id="menutab" style="vertical-align: bottom;">
                            <div id="tab1" class="Tabremovesel" onclick="GetTabClick(this);Urlhref('Individuation_Set.aspx');">
                                个性化设置
                            </div>
                            <div id="tab0" class="Tabsel" onclick="GetTabClick(this);Urlhref('CustomHomePage.aspx');">
                                自定义主页
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="div-body">
            <textarea id="content1" cols="100" rows="8" style="width: 97%; height: 500px; visibility: hidden;" runat="server"></textarea>
            <div style="padding-top: 30px; padding-left: 180px;">
                <asp:Button ID="Save" runat="server" class="l-btn" OnClick="Save_Click" Text="保存设置"></asp:Button>
            </div>
        </div>
    </form>
</body>
</html>
