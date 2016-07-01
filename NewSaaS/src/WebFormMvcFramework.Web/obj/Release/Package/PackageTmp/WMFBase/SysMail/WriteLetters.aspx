<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WriteLetters.aspx.cs" Inherits="WebFormMvcFramework.Web.WMFBase.SysMail.WriteLetters" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../../Themes/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../Themes/kindeditor-4.1.10/themes/default/default.css" />
    <link rel="stylesheet" href="../../Themes/kindeditor-4.1.10/plugins/code/prettify.css" />
    <script charset="utf-8" src="../../Themes/kindeditor-4.1.10/kindeditor.js"></script>
    <script charset="utf-8" src="../../Themes/kindeditor-4.1.10/lang/zh_CN.js"></script>
    <script charset="utf-8" src="../../Themes/kindeditor-4.1.10/plugins/code/prettify.js"></script>
    <script src="../../Themes/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/FunctionJS.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/artDialog/artDialog.source.js" type="text/javascript"></script>
    <script src="../../Themes/Scripts/artDialog/iframeTools.source.js" type="text/javascript"></script>
    <script type="text/javascript">
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
        'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'insertfile', 'table', 'hr', 'emoticons', 'code', 'pagebreak',
        'link', 'unlink'
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

        function Verification() {
            var SJR = $("*[id$=txt_Addressee]").val();
            if (SJR == "") {
                showWarningMsg("填写收件人！");
                return false;
            }
            var ZT = $("*[id$=Text1]").val();
            if (ZT != "") {
                if (ZT.length > 20) {
                    showWarningMsg("主题超出字符限制！");
                    return false;
                }
            } else {
                showWarningMsg("请填写主题！");
                return false;
            }
            var NR = $("*[id$=content1]").val();
            if (NR != "") {
                if (NR.length > 2000) {
                    showWarningMsg("主内容超出字符限制！");
                    return false;
                }
            }
            else {
                showWarningMsg("请填写内容！");
                return false;
            }
        }
    </script>
    <style type="text/css">
        .auto-style1 {
            width: 8%;
            text-align: right;
        }

        table.Ntab_02 {
            border-collapse: inherit;
            border-spacing: 0px;
            border: 0px;
            border-left: 1px solid #CCC;
            border-top: 1px solid #CCC;
        }

        .Ntab_02 td {
            /*border-right: 1px solid #CCC;*/
            border-bottom: 1px solid #CCC;
        }

        .auto-style2 {
            width: 80%;
        }

        .auto-style3 {
            width: 15%;
        }
    </style>
    <div class="btnbartitle">
        <div>
            收件箱
        </div>
    </div>
    <title>写信</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="btnbarcontetn">
            <table style="width: 100%;" class="Ntab_02 Nw_100">
                <tr class="bacTr txtBol txt12">
                    <td class="auto-style1">收件人：</td>
                    <td valign="middle" class="auto-style3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txt_Addressee" runat="server" class="txt" Style="width: 98%;"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td class="auto-style2">
                        <asp:Button ID="but_SendOut" runat="server" class="button green" OnClick="but_SendOut_Click" OnClientClick="return Verification()" Text="发 送"></asp:Button>
                    </td>
                </tr>
                <tr class="bacTr txtBol txt12">
                    <td class="auto-style1" valign="middle">邮件主题：  </td>
                    <td class="auto-style3">
                        <input type="text" id="Text1" class="txt" runat="server" style="width: 98%;" /></td>
                    <td class="auto-style3">
                        <div class="btnbartitle">
                            <div>
                                联系人
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1" valign="top">邮件内容：</td>
                    <td class="auto-style2">
                        <textarea id="content1" runat="server" style="width: 98%; height: 534px"></textarea></td>
                    <td valign="top" class="auto-style3">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:TreeView ID="tv_Department" runat="server" ImageSet="Arrows" OnSelectedNodeChanged="tv_Department_SelectedNodeChanged">
                                    <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                                    <Nodes>
                                        <asp:TreeNode Text="总公司" Value="总公司"></asp:TreeNode>
                                    </Nodes>
                                    <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                                    <ParentNodeStyle Font-Bold="False" />
                                    <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
                                </asp:TreeView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
