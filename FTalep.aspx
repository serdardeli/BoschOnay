<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FTalep.aspx.vb" Inherits="BoschOnay.FTalep" %>

<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=12.2.18.1017, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>İzin Talep Formu</title>
    <style type="text/css">
        html, body, form {
            overflow: hidden;
            height: 100%;
            margin: 0px;
            padding: 0px;
        }
    </style>
    <link rel="Stylesheet" type="text/css" href="Bosch.css" />

    <script type="text/javascript">
        function silsor() {
            var quit = confirm("Ekrandaki bilgileri temizlemek istiyor musunuz ? ");
            if (quit) return true;
            return false;
        }
        function yazdirsor() {
            document.getElementById("RaporGoster").PrintReport();

            var msgtxt = document.getElementById("Mesaj").innerText;
            if (msgtxt != "") {
                alert("Lütfen önce bilgileriniz kontrol edin!\n\n" + msgtxt);
                return false;
            };

            //var tsure = document.getElementById("TSure").innerText;
            //if (tsure == "0") {
            //    alert("Süre=0 olamaz! Lütfen tarih aralığını kontrol edin!\n");
            //    return false;
            //};
            var quit = confirm("Seçili kaydı kaydetmek / yazdırmak istiyor musunuz ? ");
            if (quit) return true;
            return false;
        }
        function kaydetsor() {
            var quit = confirm("Bilgileri kaydetmek istiyor musunuz ? ");
            if (quit) return true;
            return false;
        }
        function vazgecsor() {
            var quit = confirm("Kayıt işlemini iptal etmek istiyor musunuz ? ");
            if (quit) return true;
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="MainPage" runat="server" visible="true">
            <table style="width: 100%; height: 100%; background-color: whitesmoke;">
                <tr>
                    <td align="center" style="width: 100%; height: 600px;">
                        <table cellspacing="0" cellpadding="0" width="700px" style="background-color: cornflowerblue; color: white; border: none; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: lighter">
                            <tr style="height: 40px; font-size: 28px;">
                                <td></td>

                                <%--<td style="height: 30px; vertical-align: middle;">
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="Middle" ImageUrl="images/reguest.png" /></td>--%>

                                <td style="font-size: 28px; color: white; font-weight: bold; vertical-align: bottom; font-family: 'Segoe UI';" class="auto-style1">

                                    <asp:LinkButton runat="server" ID="anaekran" Text="AnaSayfa" PostBackUrl="~/FMainPage2.aspx" ForeColor="White">MyTime Request</asp:LinkButton>
                                </td>

                                <td></td>
                                <td align="right" style="width: 180px">
                                    <asp:Label ID="Tarih" runat="server" Text="09.10.2017"></asp:Label>&nbsp; </td>
                            </tr>
                            <tr style="height: 100%">
                                <td colspan="4">
                                    <table style="margin: 5px 16px 5px 16px; background-color: white">
                                        <tr>
                                            <td colspan="3" align="center">
                                                <asp:Label ID="Label1" runat="server" Font-Size="24px" BackColor="CornflowerBlue" ForeColor="White" Width="680px" Height="40px" Text="Yıllık İzin Talep Formu"></asp:Label></td>
                                        </tr>
                                        <tr style="height: 30px; font-size: 12px;">
                                            <td colspan="4" align="left">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <telerik:RadLabel ID="RSicilNo" runat="server" CssClass="labelbox" ForeColor="White" Width="110px" Text="Sicil No"></telerik:RadLabel>
                                                        </td>
                                                        <td>
                                                            <telerik:RadNumericTextBox ID="SicilNo" runat="server" Width="100px" BackColor="LightYellow" MaxLength="12" MinValue="0">
                                                                <NegativeStyle Resize="None"></NegativeStyle>
                                                                <NumberFormat ZeroPattern="n" DecimalDigits="0" GroupSeparator=""></NumberFormat>
                                                                <EmptyMessageStyle Resize="None"></EmptyMessageStyle>
                                                                <ReadOnlyStyle Resize="None"></ReadOnlyStyle>
                                                                <FocusedStyle Resize="None"></FocusedStyle>
                                                                <DisabledStyle Resize="None"></DisabledStyle>
                                                                <InvalidStyle Resize="None"></InvalidStyle>
                                                                <HoveredStyle Resize="None"></HoveredStyle>
                                                                <EnabledStyle Resize="None"></EnabledStyle>
                                                            </telerik:RadNumericTextBox>
                                                        </td>
                                                        <td>
                                                            <asp:ImageButton ID="BYenile" runat="server" ImageUrl="~/images/buttonrefresh.png" Height="24px" Width="24px" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" />
                                                        </td>
                                                    </tr>
                                                </table>

                                            </td>
                                        </tr>
                                        <tr style="height: 100%">
                                            <td colspan="2" valign="top">
                                                <table>
                                                    <tr style="height: 30px;">
                                                        <td valign="middle" align="left">
                                                            <telerik:RadLabel ID="RAdSoyad" runat="server" CssClass="labelbox" ForeColor="White" Width="110px" Text="Ad Soyad"></telerik:RadLabel>
                                                        </td>
                                                        <td style="width: 100%;">
                                                            <telerik:RadLabel ID="TAdSoyad" runat="server" Width="200px" CssClass="textbox"></telerik:RadLabel>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 30px;">
                                                        <td align="left">
                                                            <telerik:RadLabel ID="RGrup0" runat="server" CssClass="labelbox" ForeColor="White" Width="110px" Text="LGrup0"></telerik:RadLabel>
                                                        </td>
                                                        <td align="left">
                                                            <telerik:RadLabel ID="TGrup0" runat="server" Width="200px" CssClass="textbox"></telerik:RadLabel>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 30px;">
                                                        <td align="left">
                                                            <telerik:RadLabel ID="RGrup1" runat="server" CssClass="labelbox" ForeColor="White" Width="110px" Text="LGrup1"></telerik:RadLabel>
                                                        </td>
                                                        <td align="left">
                                                            <telerik:RadLabel ID="TGrup1" runat="server" Width="200px" CssClass="textbox"></telerik:RadLabel>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 30px;">
                                                        <td align="left">
                                                            <telerik:RadLabel ID="RGrup2" runat="server" CssClass="labelbox" ForeColor="White" Width="110px" Text="LGrup2"></telerik:RadLabel>
                                                        </td>
                                                        <td align="left">
                                                            <telerik:RadLabel ID="TGrup2" runat="server" Width="200px" CssClass="textbox"></telerik:RadLabel>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 30px;">
                                                        <td align="left">
                                                            <telerik:RadLabel ID="RGrup3" runat="server" CssClass="labelbox" ForeColor="White" Width="110px" Text="LGrup3"></telerik:RadLabel>
                                                        </td>
                                                        <td align="left">
                                                            <telerik:RadLabel ID="TGrup3" runat="server" Width="200px" CssClass="textbox"></telerik:RadLabel>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 30px;">
                                                        <td align="left">
                                                            <telerik:RadLabel ID="RGrup4" runat="server" CssClass="labelbox" ForeColor="White" Width="110px" Text="LGrup4"></telerik:RadLabel>
                                                        </td>
                                                        <td align="left">
                                                            <telerik:RadLabel ID="TGrup4" runat="server" Width="200px" CssClass="textbox"></telerik:RadLabel>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 30px;">
                                                        <td align="left">
                                                            <telerik:RadLabel ID="RKisim" runat="server" CssClass="labelbox" ForeColor="White" Width="110px" Text="Kısım"></telerik:RadLabel>
                                                        </td>
                                                        <td align="left">
                                                            <telerik:RadLabel ID="TKisim" runat="server" Width="200px" CssClass="textbox"></telerik:RadLabel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td valign="top">
                                                <table>
                                                    <tr style="height: 30px;">
                                                        <td align="left">
                                                            <telerik:RadLabel ID="RadLabel1" runat="server" CssClass="labelbox" ForeColor="White" Width="110px" Text="İzin Tipi"></telerik:RadLabel>
                                                        </td>
                                                        <td colspan="2" align="left">
                                                            <telerik:RadComboBox ID="rizintipi" runat="server" AutoPostBack="True">
                                                                <Items>
                                                                    <telerik:RadComboBoxItem Text="Tam Gün" Value="0" />
                                                                    <%-- <telerik:RadComboBoxItem Text="Yarım Gün Öğleden Önce" Value="1" />
                                                                    <telerik:RadComboBoxItem runat="server" Text="Yarım Gün Öğleden Sonra" Value="2" />--%>
                                                                </Items>
                                                            </telerik:RadComboBox>
                                                        </td>
                                                    </tr>

                                                    <tr style="height: 30px;">
                                                        <td style="width: 110px;" align="left">
                                                            <telerik:RadLabel ID="RBasTar" runat="server" CssClass="labelbox" ForeColor="White" Width="110px" Text="İzine Çıkış tarihi "></telerik:RadLabel>
                                                        </td>
                                                        <td style="width: 104px;" align="left">
                                                            <telerik:RadDatePicker ID="BasTar" runat="server" Culture="tr-TR" Width="100px" WrapperTableCaption="" AutoPostBack="True" Font-Size="12px">
                                                                <Calendar runat="server" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                                                </Calendar>
                                                                <DateInput runat="server" AutoPostBack="True" DateFormat="dd.MM.yyyy" DisplayDateFormat="dd.MM.yyyy" LabelWidth="40%">
                                                                    <EmptyMessageStyle Resize="None" />
                                                                    <ReadOnlyStyle Resize="None" />
                                                                    <FocusedStyle Resize="None" />
                                                                    <DisabledStyle Resize="None" />
                                                                    <InvalidStyle Resize="None" />
                                                                    <HoveredStyle Resize="None" />
                                                                    <EnabledStyle Resize="None" />
                                                                </DateInput>
                                                            </telerik:RadDatePicker>
                                                        </td>
                                                        <td style="width: 100%;" align="left">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <telerik:RadLabel ID="RBitTar" runat="server" CssClass="labelbox" ForeColor="White" Width="110px" Text="İşe Başlama Tarihi"></telerik:RadLabel>
                                                        </td>
                                                        <td>
                                                            <telerik:RadDatePicker ID="BitTar" runat="server" Culture="tr-TR" Width="100px" WrapperTableCaption="" AutoPostBack="True" Font-Size="12px">
                                                                <Calendar runat="server" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                                                </Calendar>
                                                                <DateInput runat="server" AutoPostBack="True" DateFormat="dd.MM.yyyy" DisplayDateFormat="dd.MM.yyyy" LabelWidth="40%">
                                                                    <EmptyMessageStyle Resize="None" />
                                                                    <ReadOnlyStyle Resize="None" />
                                                                    <FocusedStyle Resize="None" />
                                                                    <DisabledStyle Resize="None" />
                                                                    <InvalidStyle Resize="None" />
                                                                    <HoveredStyle Resize="None" />
                                                                    <EnabledStyle Resize="None" />
                                                                </DateInput>
                                                            </telerik:RadDatePicker>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr style="height: 30px;">
                                                        <td align="left">
                                                            <telerik:RadLabel ID="RSure" runat="server" CssClass="labelbox" ForeColor="White" Width="110px" Text="Süre"></telerik:RadLabel>
                                                        </td>
                                                        <td align="left">
                                                            <telerik:RadLabel ID="TSure" runat="server" Width="80px" CssClass="textbox"></telerik:RadLabel>
                                                        </td>
                                                        <td style="color: gray" align="left">
                                                            <telerik:RadLabel ID="RGun" runat="server" Width="80px" Text="gün"></telerik:RadLabel>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 30px;">
                                                        <td align="left">
                                                            <telerik:RadLabel ID="RTipi" runat="server" CssClass="labelbox" ForeColor="White" Width="110px" Text="Mazeret Kodu"></telerik:RadLabel>
                                                        </td>
                                                        <td colspan="2" align="left">
                                                            <telerik:RadComboBox ID="Tipi" runat="server" Enabled="false">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 60px;">
                                                        <td align="left" valign="top">
                                                            <telerik:RadLabel ID="RAciklama" runat="server" CssClass="labelbox" ForeColor="White" Width="110px" Text="Açıklama"></telerik:RadLabel>
                                                        </td>
                                                        <td colspan="2" align="left" valign="top" rowspan="1">
                                                            <telerik:RadTextBox ID="TAciklama" runat="server" BackColor="LightYellow" BorderColor="WhiteSmoke" Width="226px" Height="82px" BorderStyle="Solid" BorderWidth="1px" MaxLength="200" TextMode="MultiLine"></telerik:RadTextBox></td>
                                                    </tr>
                                                    <tr style="height: 30px;">
                                                        <td align="left">
                                                            <telerik:RadLabel ID="RadLabel2" Visible="false" runat="server" CssClass="labelbox" ForeColor="White" Width="110px" Text="Avans İstiyorum?"></telerik:RadLabel>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <asp:CheckBox runat="server" Visible="false" ID="avans" /></td>
                                                    </tr>
                                                    <tr style="height: 100%;">
                                                        <td></td>
                                                        <td style="width: 100%;"></td>
                                                        <td align="right" style="color: black;">
                                                            <asp:Label ID="Label2" runat="server" Text="Onaya Gönder"></asp:Label></td>
                                                        <td align="left">
                                                            <asp:ImageButton ID="BYazdir" runat="server" ToolTip="ONAYA GÖNDER" AlternateText="ONAYA GÖNDER" ImageUrl="~/images/onya.png" Height="32px" Width="32px" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" OnClientClick="return yazdirsor();"></asp:ImageButton></td>
                                                        <td align="right" style="color: black; padding-left: 15px;">
                                                            <asp:Label ID="Label3" runat="server" Text="Temizle"></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:ImageButton ID="BTemizle" runat="server" ToolTip="Ekran Bilgilerini Temizle" ImageUrl="~/images/clear.png" Height="32px" Width="32px" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" OnClientClick="return silsor();" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr style="height: 23px; background-color: cornflowerblue; color: white;">
                                <td align="left">&nbsp;&nbsp; (c) ERBEN 20201124</td>
                                <td align="center" style="color: red"></td>
                                <td align="right">
                                    <asp:Label ID="ITarih" runat="server" Text="Kayıt : 09.10.2017 13:15:02"></asp:Label>&nbsp;&nbsp;&nbsp; </td>
                            </tr>
                            <%--<tr style="height: 23px; background-color: white; color: blue; font-weight: bold;">
                                <td colspan="4" align="center">Not: Yıllık izin formu imzaları eksiksiz olarak, yıllık izin başlangıç tarihinden önce HRL'ye ulaştırılmalıdır.</td>
                            </tr>--%>
                            <tr style="height: 23px; background-color: white; color: red; font-weight: bold;">
                                <td colspan="4" align="center">
                                    <asp:Label ID="Mesaj" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <%--  <div id="PrintPage" runat="server" visible="false" style="width: 100%; height: 100%">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td align="center" style="width: 100%; height: 100%;">
                        <table style="width: 900px; height: 100%;">
                            <tr>
                                <td align="right" style="background-color: gainsboro; border: 1px solid lightgray">
                                    <asp:ImageButton ID="Geri" runat="server" ImageUrl="~/images/buttongeri.png" Height="32px" Width="32px" BorderColor="GhostWhite" BorderStyle="Solid" BorderWidth="1px" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="height: 100%;">
                                    <telerik:ReportViewer ID="RaporGoster" runat="server" Width="100%" Height="100%" ProgressText="Rapor hazırlanıyor..." ShowHistoryButtons="False" ShowParametersButton="False" ShowPrintPreviewButton="False" ShowRefreshButton="False" ViewMode="PrintPreview" ShowDocumentMapButton="False" ShowExportGroup="False" ShowNavigationGroup="False">
                    <typereportsource typename="BoschOnay.RBosch_MForm01.BoschRapor01, BoschOnay, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"></typereportsource>
                                    </telerik:ReportViewer>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <script type="text/javascript">
                ReportViewer.prototype.PrintReport = function () {
                    switch (this.defaultPrintFormat) {
                        case "Default":
                            this.DefaultPrint();
                            break;
                        case "PDF":
                            this.PrintAs("PDF");
                            previewFrame = document.getElementById(this.previewFrameID);
                            previewFrame.onload = function () { previewFrame.contentDocument.execCommand("print", true, null); }
                            break;
                    }
                };
            </script>
        </div>--%>
        <asp:HiddenField ID="CalGun" runat="server" />
        <asp:HiddenField ID="MaasTip" runat="server" />
        <asp:HiddenField ID="Yiliz" runat="server" />
        <asp:HiddenField ID="KayitNdx" runat="server" />
    </form>
</body>
</html>
