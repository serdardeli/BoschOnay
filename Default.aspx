<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="BoschOnay._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WinTime Rapor</title>
    <style type="text/css">
        html, body, form {
            overflow: hidden;
            height: 100%;
            margin: 0px;
            padding: 0px;
        }
    </style>
</head>
<body onkeydown="return (event.keyCode!=13)">
    <form id="form1" runat="server">
        <div style="width: 100%; height: 100%; background-color: white">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td align="center" style="width: 100%; height: 500px;">
                        <table cellpadding="5" cellspacing="3" style=" vertical-align: central; text-align: center;   background-repeat: no-repeat;">
                             <tr>
                                <td colspan="3" style="background-color: white;border:solid;border-color:cornflowerblue;border-width:1px;">
                                    <asp:Image  runat="server" ImageUrl="~/Images/mytime1.png"/>
                                </td>
                            </tr>
                             
                            <tr style="background-color: cornflowerblue;">
                                <td align="left">
                                    <asp:Label ID="Label1" runat="server" Font-Names="Segoe UI" ForeColor="White" Font-Size="12px" Text="Kullanıcı Kodu" Width="200px" Height="20px"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="SicilList" runat="server" Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="Devam" runat="server" Font-Names="Segoe UI" Font-Size="12px" Text="Devam" Width="75px" />
                                </td>
                            </tr>
                            <tr style="background-color: white">
                                <td align="center" colspan="3">
                                    <asp:Label ID="Label3" runat="server" Font-Names="Segoe UI" ForeColor="Red" Width="100%" Font-Size="12px">  </asp:Label>
                                </td>
                            </tr>
                            <tr style="background-color: white;border:dotted;border-color:red;">
                                <td style="font-family: Calibri; font-size: small;" colspan="3" align="center">(c) ERBEN Kontrol Sistemleri A.Ş.&nbsp;&nbsp;&nbsp;VR21.2 09072021 1230</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>