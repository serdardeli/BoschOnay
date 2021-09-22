<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AGIFormu.aspx.vb" Inherits="BoschOnay.AGIFormu" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ASGARİ GEÇİM İNDİRİMİ AİLE DURUMU BİLDİRİMİ</title>
    <script type="text/javascript">
        function silsor() {
            var quit = confirm("Seçili kaydı silmek istiyor musunuz ? ");
            if (quit) return true;
            return false;
        }
        function yazdirsor() {
            var quit = confirm("Seçili kaydı yazdırmak istiyor musunuz ? ");
            if (quit) return true;
            return false;
        }
        function kaydetsor() {
            var quit = confirm("Bilgileri kaydetmek istiyor musunuz ? ");
            if (quit) return true;
            return false;
        }
        function temizlesor() {
            var quit = confirm("Ekrandaki bilgileri temizlemek istiyor musunuz ? ");
            if (quit) return true;
            return false;
        }
        function vazgecsor() {
            var quit = confirm("Kayıt işlemini iptal etmek istiyor musunuz ? ");
            if (quit) return true;
            return false;
        }
        function sayfayazdir() {
            var prtContent = document.getElementById("PrintDoc");
            var WinPrint = window.open('', '', 'left=0,top=0,width=800,height=900,toolbar=0,scrollbars=0,status=0');
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            return true;
        }

        /*code: 48-57 Numbers
          8  - Backspace,
          35 - home key, 36 - End key
          37-40: Arrow keys, 46 - Delete key*/
        function ClearNumbers(e) {
            var x = e.which || e.keycode;
            if (x >= 48 && x <= 57)
                return false;
            else
                return true;
        }

    </script>
    <style type="text/css">
        .auto-style1 {
            width: 20%;
            height: 21px;
        }

        .auto-style2 {
        }

        .auto-style3 {
            width: 20%;
            height: 24px;
        }

        .auto-style4 {
        }

        .auto-style5 {
            width: 202px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <table style="width: 100%;">
            <tr>
                <td align="center" style="width: 100%; background-color: whitesmoke;">
                    <table style="border: thin solid #CCCCCC; width: 700px; background-color: whitesmoke;">
                        <tr>
                            <td align="center" style="width: 100%" rowspan="2">
                                <asp:Label ID="Mesaj" runat="server" Font-Names="Calibri" Font-Size="16px" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:ImageButton ID="Kaydet" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" Height="24px" ImageUrl="~/Images/buttonsave.png" Width="24px" ToolTip="Ekrandaki bilgileri kaydet" OnClientClick="return kaydetsor();" />
                            </td>
                            <td align="center">
                                <asp:ImageButton ID="Yazdir" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" Height="24px" ImageUrl="~/Images/buttonprinter.png" Width="24px" ToolTip="Ekrandaki bilgileri yazdır" OnClientClick="return sayfayazdir();" Visible="false" />
                            </td>
                            <td align="center">
                                <asp:ImageButton ID="Temizle" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" Height="24px" ImageUrl="~/Images/buttontrash.png" Width="24px" ToolTip="Ekrandaki bilgileri temizle" OnClientClick="return temizlesor();" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="LKaydet" runat="server" Text="Kaydet" Font-Names="Calibri" Font-Size="10px"></asp:Label></td>
                            <td>
                                <asp:Label ID="LYazdir" runat="server" Text="Yazdır" Font-Names="Calibri" Font-Size="10px" Visible="false"></asp:Label></td>
                            <td>
                                <asp:Label ID="LTemizle" runat="server" Text="Temizle" Font-Names="Calibri" Font-Size="10px"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 100%; background-color: whitesmoke;">
                    <div id="InputDoc" runat="server">
                        <table style="width: 700px; background-color: white;" cellspacing="5">
                            <tr>
                                <td align="center" colspan="2" style="border: 1px solid #808080; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 20px; font-weight: bold;">AİLE DURUMU VE ÖZLÜK VERİLERİ BİLDİRİMİ</td>
                            </tr>
                            <tr>
                                <td align="center" style="border: 1px solid #808080; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 14px; width: 50%; font-weight: bold;">Personel Bilgileri</td>
                                <td align="center" style="border: 1px solid #808080; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 14px; width: 50%; font-weight: bold;">İletişim / Adres Bilgileri</td>
                            </tr>
                            <tr>
                                <td colspan="2" align="left">
                                    <table style="width: 100%; border: 1px solid #808080; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px;">
                                        <tr>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Personel No</td>
                                            <td class="auto-style5">
                                                <asp:TextBox ID="pSicilNo" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" Width="130px" MaxLength="16" BackColor="Ivory" BorderWidth="1px" AutoPostBack="True"></asp:TextBox>
                                            </td>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Cep Telefonu</td>
                                            <td>
                                                <telerik:RadMaskedTextBox ID="pCepNo" runat="server" DisplayMask="(###) ### ## ##" Mask="(###) ### ## ##" Width="170px" TabIndex="8"></telerik:RadMaskedTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Adı Soyadı</td>
                                            <td class="auto-style5">
                                                <asp:TextBox ID="pAdSoyad" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" ReadOnly="True" Width="170px" MaxLength="50" BorderWidth="1px" TabIndex="1"></asp:TextBox>
                                            </td>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">İl</td>
                                            <td>
                                                <asp:TextBox ID="pIl" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" Width="170px" MaxLength="25" BackColor="Ivory" BorderWidth="1px" TabIndex="9" onkeypress="return ClearNumbers(event)"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Bölüm</td>
                                            <td class="auto-style5">
                                                <asp:TextBox ID="pBolum" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" ReadOnly="True" Width="170px" MaxLength="50" BorderWidth="1px" TabIndex="2"></asp:TextBox>
                                            </td>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">İlçe</td>
                                            <td>
                                                <asp:TextBox ID="pIlce" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" Width="170px" MaxLength="25" BackColor="Ivory" BorderWidth="1px" TabIndex="10" onkeypress="return ClearNumbers(event)"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;" class="auto-style3">Masraf Yeri</td>
                                            <td class="auto-style5">
                                                <asp:TextBox ID="pMasrafYeri" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" ReadOnly="True" Width="170px" MaxLength="50" BorderWidth="1px" TabIndex="3"></asp:TextBox>
                                            </td>
                                            <td style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;" class="auto-style3">Adres</td>
                                            <td class="auto-style4" rowspan="4" valign="top">
                                                <asp:TextBox ID="pAdres" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" Width="170px" MaxLength="250" BackColor="Ivory" BorderWidth="1px" TabIndex="11" Height="78px" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">
                                                <asp:Label ID="lAskerlik" runat="server" Text="Askerlik Durumu"></asp:Label>
                                            </td>
                                            <td class="auto-style5">
                                                <asp:DropDownList ID="pAskerlik" runat="server" Width="150px" AutoPostBack="True" TabIndex="4">
                                                    <asp:ListItem Text="" />
                                                    <asp:ListItem Text="Yaptı" />
                                                    <asp:ListItem Text="Tecilli" />
                                                    <asp:ListItem Text="Muaf" />
                                                    <asp:ListItem Text="Yükümlü değil" />
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="Cinsiyet" runat="server" />
                                                <asp:HiddenField ID="CalAltGrup" runat="server" />
                                            </td>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">
                                                <asp:Label ID="lTerhisTar" runat="server" Text="Terhis Tarihi"></asp:Label>
                                            </td>
                                            <td class="auto-style5">
                                                <asp:DropDownList ID="pTerhisTar" runat="server" Width="150px" TabIndex="5">
                                                    <asp:ListItem Text="" />
                                                </asp:DropDownList>
                                                <telerik:RadMonthYearPicker ID="pTecil" runat="server" Width="150px" AutoPostBack="true" BackColor="#CCCCCC" Visible="false" TabIndex="6">
                                                    <DateInput runat="server" DisplayDateFormat="MMMM yyyy" DateFormat="MMMM yyyy" AutoPostBack="True" LabelWidth="40%" TabIndex="6">
                                                        <EmptyMessageStyle Resize="None"></EmptyMessageStyle>

                                                        <ReadOnlyStyle Resize="None"></ReadOnlyStyle>

                                                        <FocusedStyle Resize="None"></FocusedStyle>

                                                        <DisabledStyle Resize="None"></DisabledStyle>

                                                        <InvalidStyle Resize="None"></InvalidStyle>

                                                        <HoveredStyle Resize="None"></HoveredStyle>

                                                        <EnabledStyle Resize="None"></EnabledStyle>
                                                    </DateInput>
                                                    <MonthYearNavigationSettings DateIsOutOfRangeMessage="Cancel"></MonthYearNavigationSettings>
                                                </telerik:RadMonthYearPicker>
                                            </td>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Medeni Hal</td>
                                            <td class="auto-style5">
                                                <asp:DropDownList ID="pMedeniHal" runat="server" Width="150px" AutoPostBack="True" TabIndex="7">
                                                    <asp:ListItem Text="" />
                                                    <asp:ListItem Text="Bekar" />
                                                    <asp:ListItem Text="Evli" />
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold;">&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2">
                                    <div id="EsInfo" runat="server">
                                        <table style="width: 100%; border: 1px solid #808080; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px;">
                                            <tr>
                                                <td colspan="2" align="center" style="border: 1px solid #808080; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 14px; width: 50%; font-weight: bold;">Personel Eş Bilgileri</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Eşiniz Bosch'da çalışıyor mu ?</td>
                                                <td>
                                                    <asp:DropDownList ID="EsBoschDurum" runat="server" Width="100px" AutoPostBack="True" TabIndex="12">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Evet" />
                                                        <asp:ListItem Text="Hayır" />
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">
                                                    <asp:Label ID="lEsSicilNo" runat="server" Text="Eş Personel No"></asp:Label>
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="EsSicilNo" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" Width="130px" BackColor="Ivory" BorderWidth="1px" TabIndex="13"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:ImageButton ID="bEsYenile" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" Height="21px" ImageUrl="~/Images/buttonrefresh.png" Width="22px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Eş Ad Soyad</td>
                                                <td>
                                                    <asp:TextBox ID="EsAdSoyad" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" ReadOnly="True" Width="170px" MaxLength="25" BorderWidth="1px" TabIndex="13" onkeypress="return ClearNumbers(event)"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Eş İş Durumu</td>
                                                <td>
                                                    <asp:DropDownList ID="EsIsDurum" runat="server" Width="100px" TabIndex="15" AutoPostBack="True">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Çalışıyor" />
                                                        <asp:ListItem Text="Çalışmıyor" />
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Çalışıyorsa İşyerinde çocukları için AGİ'den faydalanıyor mu ?</td>
                                                <td>
                                                    <asp:DropDownList ID="EsAGIDurum" runat="server" Width="100px" AutoPostBack="True" TabIndex="16">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Evet" />
                                                        <asp:ListItem Text="Hayır" />
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="left">
                                    <div id="CocukInfo" runat="server">
                                        <table style="width: 100%; border: 1px solid #808080; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px;">
                                            <tr>
                                                <td colspan="5" align="center" style="border: 1px solid #808080; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 14px; width: 50%; font-weight: bold;">Çalışanın Bakmakla Yükümlü Olduğu Çocuklarının Durumu</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 5%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">No</td>
                                                <td style="width: 25%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Adı Soyadı</td>
                                                <td style="width: 15%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Doğum Tarihi</td>
                                                <td style="width: 15%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Cinsiyet</td>
                                                <td style="width: 40%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Öğrenimine Devam Ediyor mu?</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl0" runat="server" Text="1."></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="CAdSoyad0" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px" MaxLength="50" BackColor="Ivory" onkeypress="return ClearNumbers(event)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="CDogumTar0" runat="server" Culture="tr-TR" Width="100px" WrapperTableCaption="" AutoPostBack="True" BackColor="Ivory">
                                                        <Calendar ID="Calendar1" runat="server" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                                        </Calendar>
                                                        <DateInput ID="DateInput1" runat="server" AutoPostBack="True" DateFormat="dd.MM.yyyy" DisplayDateFormat="dd.MM.yyyy" LabelWidth="40%">
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
                                                <td>
                                                    <asp:DropDownList ID="CCinsiyet0" runat="server" Width="100px" AutoPostBack="True" BackColor="Ivory">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Erkek" />
                                                        <asp:ListItem Text="Kız" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="Cogrenim0" runat="server" Width="100px" AutoPostBack="True" BackColor="Ivory">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Evet" />
                                                        <asp:ListItem Text="Hayır" />
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl1" runat="server" Text="2." Visible="false"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="CAdSoyad1" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px" MaxLength="50" Visible="False" BackColor="Ivory" onkeypress="return ClearNumbers(event)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="CDogumTar1" runat="server" Culture="tr-TR" Width="100px" WrapperTableCaption="" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <Calendar ID="Calendar2" runat="server" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                                        </Calendar>
                                                        <DateInput ID="DateInput2" runat="server" AutoPostBack="True" DateFormat="dd.MM.yyyy" DisplayDateFormat="dd.MM.yyyy" LabelWidth="40%">
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
                                                <td>
                                                    <asp:DropDownList ID="CCinsiyet1" runat="server" Width="100px" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Erkek" />
                                                        <asp:ListItem Text="Kız" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="Cogrenim1" runat="server" Width="100px" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Evet" />
                                                        <asp:ListItem Text="Hayır" />
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl2" runat="server" Text="3." Visible="false"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="CAdSoyad2" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px" MaxLength="50" Visible="False" BackColor="Ivory" onkeypress="return ClearNumbers(event)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="CDogumTar2" runat="server" Culture="tr-TR" Width="100px" WrapperTableCaption="" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <Calendar ID="Calendar3" runat="server" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                                        </Calendar>
                                                        <DateInput ID="DateInput3" runat="server" AutoPostBack="True" DateFormat="dd.MM.yyyy" DisplayDateFormat="dd.MM.yyyy" LabelWidth="40%">
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
                                                <td>
                                                    <asp:DropDownList ID="CCinsiyet2" runat="server" Width="100px" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Erkek" />
                                                        <asp:ListItem Text="Kız" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="Cogrenim2" runat="server" Width="100px" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Evet" />
                                                        <asp:ListItem Text="Hayır" />
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl3" runat="server" Text="4." Visible="false"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="CAdSoyad3" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px" MaxLength="50" Visible="False" Wrap="False" BackColor="Ivory" onkeypress="return ClearNumbers(event)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="CDogumTar3" runat="server" Culture="tr-TR" Width="100px" WrapperTableCaption="" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <Calendar ID="Calendar4" runat="server" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                                        </Calendar>
                                                        <DateInput ID="DateInput4" runat="server" AutoPostBack="True" DateFormat="dd.MM.yyyy" DisplayDateFormat="dd.MM.yyyy" LabelWidth="40%">
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
                                                <td>
                                                    <asp:DropDownList ID="CCinsiyet3" runat="server" Width="100px" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Erkek" />
                                                        <asp:ListItem Text="Kız" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="Cogrenim3" runat="server" Width="100px" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Evet" />
                                                        <asp:ListItem Text="Hayır" />
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl4" runat="server" Text="5." Visible="false"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="CAdSoyad4" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px" MaxLength="50" Visible="False" Wrap="False" BackColor="Ivory" onkeypress="return ClearNumbers(event)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="CDogumTar4" runat="server" Culture="tr-TR" Width="100px" WrapperTableCaption="" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <Calendar ID="Calendar5" runat="server" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                                        </Calendar>
                                                        <DateInput ID="DateInput5" runat="server" AutoPostBack="True" DateFormat="dd.MM.yyyy" DisplayDateFormat="dd.MM.yyyy" LabelWidth="40%">
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
                                                <td>
                                                    <asp:DropDownList ID="CCinsiyet4" runat="server" Width="100px" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Erkek" />
                                                        <asp:ListItem Text="Kız" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="Cogrenim4" runat="server" Width="100px" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Evet" />
                                                        <asp:ListItem Text="Hayır" />
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl5" runat="server" Text="6." Visible="false"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="CAdSoyad5" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px" MaxLength="50" Visible="False" Wrap="False" BackColor="Ivory" onkeypress="return ClearNumbers(event)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="CDogumTar5" runat="server" Culture="tr-TR" Width="100px" WrapperTableCaption="" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <Calendar ID="Calendar6" runat="server" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                                        </Calendar>
                                                        <DateInput ID="DateInput6" runat="server" AutoPostBack="True" DateFormat="dd.MM.yyyy" DisplayDateFormat="dd.MM.yyyy" LabelWidth="40%">
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
                                                <td>
                                                    <asp:DropDownList ID="CCinsiyet5" runat="server" Width="100px" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Erkek" />
                                                        <asp:ListItem Text="Kız" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="Cogrenim5" runat="server" Width="100px" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Evet" />
                                                        <asp:ListItem Text="Hayır" />
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl6" runat="server" Text="7." Visible="false"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="CAdSoyad6" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px" MaxLength="50" Visible="False" Wrap="False" BackColor="Ivory" onkeypress="return ClearNumbers(event)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="CDogumTar6" runat="server" Culture="tr-TR" Width="100px" WrapperTableCaption="" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <Calendar ID="Calendar7" runat="server" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                                        </Calendar>
                                                        <DateInput ID="DateInput7" runat="server" AutoPostBack="True" DateFormat="dd.MM.yyyy" DisplayDateFormat="dd.MM.yyyy" LabelWidth="40%">
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
                                                <td>
                                                    <asp:DropDownList ID="CCinsiyet6" runat="server" Width="100px" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Erkek" />
                                                        <asp:ListItem Text="Kız" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="COgrenim6" runat="server" Width="100px" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Evet" />
                                                        <asp:ListItem Text="Hayır" />
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl7" runat="server" Text="8." Visible="false"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="CAdSoyad7" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px" MaxLength="50" Visible="False" Wrap="False" BackColor="Ivory" onkeypress="return ClearNumbers(event)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="CDogumTar7" runat="server" Culture="tr-TR" Width="100px" WrapperTableCaption="" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <Calendar ID="Calendar8" runat="server" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                                        </Calendar>
                                                        <DateInput ID="DateInput8" runat="server" AutoPostBack="True" DateFormat="dd.MM.yyyy" DisplayDateFormat="dd.MM.yyyy" LabelWidth="40%">
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
                                                <td>
                                                    <asp:DropDownList ID="CCinsiyet7" runat="server" Width="100px" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Erkek" />
                                                        <asp:ListItem Text="Kız" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="Cogrenim7" runat="server" Width="100px" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Evet" />
                                                        <asp:ListItem Text="Hayır" />
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl8" runat="server" Text="9." Visible="false"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="CAdSoyad8" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px" MaxLength="50" Visible="False" Wrap="False" BackColor="Ivory" onkeypress="return ClearNumbers(event)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="CDogumTar8" runat="server" Culture="tr-TR" Width="100px" WrapperTableCaption="" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <Calendar ID="Calendar9" runat="server" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                                        </Calendar>
                                                        <DateInput ID="DateInput9" runat="server" AutoPostBack="True" DateFormat="dd.MM.yyyy" DisplayDateFormat="dd.MM.yyyy" LabelWidth="40%">
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
                                                <td>
                                                    <asp:DropDownList ID="CCinsiyet8" runat="server" Width="100px" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Erkek" />
                                                        <asp:ListItem Text="Kız" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="Cogrenim8" runat="server" Width="100px" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Evet" />
                                                        <asp:ListItem Text="Hayır" />
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl9" runat="server" Text="10." Visible="false"></asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="CAdSoyad9" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px" MaxLength="50" Visible="False" Wrap="False" BackColor="Ivory" onkeypress="return ClearNumbers(event)"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <telerik:RadDatePicker ID="CDogumTar9" runat="server" Culture="tr-TR" Width="100px" WrapperTableCaption="" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <Calendar ID="Calendar10" runat="server" EnableWeekends="True" FastNavigationNextText="&amp;lt;&amp;lt;" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False">
                                                        </Calendar>
                                                        <DateInput ID="DateInput10" runat="server" AutoPostBack="True" DateFormat="dd.MM.yyyy" DisplayDateFormat="dd.MM.yyyy" LabelWidth="40%">
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
                                                <td>
                                                    <asp:DropDownList ID="CCinsiyet9" runat="server" Width="100px" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Erkek" />
                                                        <asp:ListItem Text="Kız" />
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="Cogrenim9" runat="server" Width="100px" AutoPostBack="True" Visible="False" BackColor="Ivory">
                                                        <asp:ListItem Text="" />
                                                        <asp:ListItem Text="Evet" />
                                                        <asp:ListItem Text="Hayır" />
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 14px;">
                                <td align="left" colspan="2" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 14px;">1- Bu bildirim, işverenlerce yukarıdaki  muhteviyatına uygun olarak çoğaltılıp kullanılabilecektir.
                                    <br />
                                    2- Bildirim, ilk işe girişte verilir. Çalışanın asgari geçim indiriminden yararlanan eş veya çocuk durumunda bir değişiklik meydana gelmesi halinde bildirim yeniden verilir.<br />
                                    3- Çocuklar, sosyal güvenlik yönünden tabi oldukları eşin bildirimine dahil edilir.<br />
                                    4- İndirimin uygulamasında “çocuk” tabiri, mükellefle birlikte oturan veya mükellef tarafından bakılan (nafaka verilenler, evlat edinilenler ile ana veya babasını kaybetmiş torunlardan mükellefle
 birlikte oturanlar dâhil) 18 yaşını veya tahsilde olup 25 yaşını doldurmamış çocukları, “eş” tabiri ise, aralarında yasal evlilik bağı bulunan kişileri ifade eder.
                                    <br />
                                    5- Çalışanlar, çocuklarının, 18. yaşını dolduracağı yılın başından itibaren öğrenimi devam ettiği sürece 25 yaşına kadar AGİ formunu güncellemekle sorumludur.<br />
                                    6- Sadece ücret geliri elde eden eş, “çalışmayan ve herhangi bir geliri olmayan eş” kapsamında değerlendirilmeyecektir. Bunlar dışındakiler ise çalışmayan ve herhangi bir geliri olmayan eş
kapsamında değerlendirilecek olup, münhasıran emekli maaşı alanlar da çalışmayan ve herhangi bir geliri olmayan eş olarak kabul edilecektir.
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 100%; background-color: whitesmoke;">
                    <div id="PrintDoc" runat="server" visible="false">
                        <table style="width: 700px; background-color: white;" cellspacing="5">
                            <tr>
                                <td align="right" colspan="2">
                                    <telerik:RadBarcode ID="RadBarcode1" runat="server" Width="200px" Height="60px" Type="EAN13" Font-Names="Calibri" Font-Size="12px" Visible="false">
                                    </telerik:RadBarcode>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="border: 1px solid #808080; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 20px; font-weight: bold;">AİLE DURUMU VE ÖZLÜK VERİLERİ BİLDİRİMİ</td>
                            </tr>
                            <tr>
                                <td align="center" style="border: 1px solid #808080; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 14px; width: 50%; font-weight: bold;">Personel Bilgileri</td>
                                <td align="center" style="border: 1px solid #808080; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 14px; width: 50%; font-weight: bold;">İletişim / Adres Bilgileri</td>
                            </tr>
                            <tr>
                                <td colspan="2" align="left">
                                    <table style="width: 100%; border: 1px solid #808080; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px;">
                                        <tr>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Personel No</td>
                                            <td>
                                                <asp:Label ID="ySicilNo" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                            </td>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Cep Telefonu</td>
                                            <td>
                                                <asp:Label ID="yCepTel" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Adı Soyadı</td>
                                            <td>
                                                <asp:Label ID="yAdSoyad" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px"></asp:Label>
                                            </td>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">İl</td>
                                            <td>
                                                <asp:Label ID="yIl" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Bölüm</td>
                                            <td>
                                                <asp:Label ID="yBolum" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px"></asp:Label>
                                            </td>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">İlçe</td>
                                            <td>
                                                <asp:Label ID="yIlce" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;" class="auto-style1">Masraf Yeri</td>
                                            <td class="auto-style2">
                                                <asp:Label ID="yMasrafYeri" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px"></asp:Label>
                                            </td>
                                            <td style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;" class="auto-style1">Adres</td>
                                            <td class="auto-style2" rowspan="4" valign="top">
                                                <asp:TextBox ID="yAdres2" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" ReadOnly="True" Width="170px" MaxLength="250" BorderWidth="1px" Height="74px" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">
                                                <asp:Label ID="ylAskerlik" runat="server" Text="Askerlik Durumu"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="yAskerlik" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="150px"></asp:Label>
                                            </td>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">
                                                <asp:Label ID="ylTerhisTar" runat="server" Text="Terhis Tarihi"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="yTerhisTar" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="150px"></asp:Label>
                                            </td>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Medeni Hal</td>
                                            <td>
                                                <asp:Label ID="yMedeniHal" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                            </td>
                                            <td style="width: 20%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold;">&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2">
                                    <div id="yEsInfo" runat="server">
                                        <table style="width: 100%; border: 1px solid #808080; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px;">
                                            <tr>
                                                <td colspan="2" align="center" style="border: 1px solid #808080; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 14px; width: 50%; font-weight: bold;">Personel Eş Bilgileri</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Eşiniz Bosch'da çalışıyor mu ?</td>
                                                <td>
                                                    <asp:Label ID="yEsBoschDurum" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">
                                                    <asp:Label ID="ylEsSicilno" runat="server" Text="Eş Personel No"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yEsSicilNo" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Eş Ad Soyad</td>
                                                <td>
                                                    <asp:Label ID="yEsAdSoyad" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Eş İş Durumu</td>
                                                <td>
                                                    <asp:Label ID="yEsIsDurum" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Çalışıyorsa İşyerinde çocukları için AGİ'den faydalanıyor mu ?</td>
                                                <td>
                                                    <asp:Label ID="yEsAGIDurum" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="left">
                                    <div id="CocukInfo2" runat="server">
                                        <table style="width: 100%; border: 1px solid #808080; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px;">
                                            <tr>
                                                <td colspan="5" align="center" style="border: 1px solid #808080; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 14px; width: 50%; font-weight: bold;">Çalışanın Bakmakla Yükümlü Olduğu Çocuklarının Durumu</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 5%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">No</td>
                                                <td style="width: 25%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Adı Soyadı</td>
                                                <td style="width: 15%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Doğum Tarihi</td>
                                                <td style="width: 15%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Cinsiyet</td>
                                                <td style="width: 40%; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 12px; font-weight: bold; background-color: #EAEAEA;">Öğrenimine Devam Ediyor mu?</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="yNo0" runat="server" Text="1."></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="yCAdSoyad0" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCDogumTar0" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCCinsiyet0" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCOgrenim0" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="yNo1" runat="server" Text="2."></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="yCAdSoyad1" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCDogumTar1" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCCinsiyet1" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCOgrenim1" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="yNo2" runat="server" Text="3."></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="yCAdSoyad2" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCDogumTar2" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCCinsiyet2" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCOgrenim2" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="yNo3" runat="server" Text="4."></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="yCAdSoyad3" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCDogumTar3" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCCinsiyet3" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCOgrenim3" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="yNo4" runat="server" Text="5."></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="yCAdSoyad4" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCDogumTar4" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCCinsiyet4" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCOgrenim4" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="yNo5" runat="server" Text="6."></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="yCAdSoyad5" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCDogumTar5" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCCinsiyet5" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCOgrenim5" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="yNo6" runat="server" Text="7."></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="yCAdSoyad6" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCDogumTar6" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCCinsiyet6" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCOgrenim6" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="yNo7" runat="server" Text="8."></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="yCAdSoyad7" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCDogumTar7" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCCinsiyet7" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCOgrenim7" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="yNo8" runat="server" Text="9."></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="yCAdSoyad8" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCDogumTar8" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCCinsiyet8" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCOgrenim8" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="yNo9" runat="server" Text="10."></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="yCAdSoyad9" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="170px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCDogumTar9" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCCinsiyet9" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="yCOgrenim9" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Width="100px"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 14px;">
                                <td align="left" colspan="2" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 14px;">1- Bu bildirim, işverenlerce yukarıdaki  muhteviyatına uygun olarak çoğaltılıp kullanılabilecektir.
                                    <br />
                                    2- Bildirim, ilk işe girişte verilir. Çalışanın asgari geçim indiriminden yararlanan eş veya çocuk durumunda bir değişiklik meydana gelmesi halinde bildirim yeniden verilir.<br />
                                    3- Çocuklar, sosyal güvenlik yönünden tabi oldukları eşin bildirimine dahil edilir.<br />
                                    4- İndirimin uygulamasında “çocuk” tabiri, mükellefle birlikte oturan veya mükellef tarafından bakılan (nafaka verilenler, evlat edinilenler ile ana veya babasını kaybetmiş torunlardan mükellefle
 birlikte oturanlar dâhil) 18 yaşını veya tahsilde olup 25 yaşını doldurmamış çocukları, “eş” tabiri ise, aralarında yasal evlilik bağı bulunan kişileri ifade eder.
                                    <br />
                                    5- Çalışanlar, çocuklarının, 18. yaşını dolduracağı yılın başından itibaren öğrenimi devam ettiği sürece 25 yaşına kadar AGİ formunu güncellemekle sorumludur.<br />
                                    6- Sadece ücret geliri elde eden eş, “çalışmayan ve herhangi bir geliri olmayan eş” kapsamında değerlendirilmeyecektir. Bunlar dışındakiler ise çalışmayan ve herhangi bir geliri olmayan eş
kapsamında değerlendirilecek olup, münhasıran emekli maaşı alanlar da çalışmayan ve herhangi bir geliri olmayan eş olarak kabul edilecektir.<p />
                                    Üst satırdaki hususları da göz önüne almak suretiyle düzenlediğim asgari geçim indirimine ait bildirimdir.
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left">
                                    <table>
                                        <tr style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 14px;">
                                            <td align="right">Adı ve Soyadı : </td>
                                            <td align="left">
                                                <asp:Label ID="IAdSoyad" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 14px;">
                                            <td align="right">Tarih : </td>
                                            <td align="left">
                                                <asp:Label ID="ITarih" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 14px;">
                                            <td align="right">İmzası :</td>
                                            <td></td>
                                        </tr>
                                        <tr style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 14px;">
                                            <td align="right">&nbsp;</td>
                                            <td>&nbsp;&nbsp;</td>
                                        </tr>
                                        <tr style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: 14px;">
                                            <td align="right">&nbsp;</td>
                                            <td>&nbsp;&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; background-color: whitesmoke;"></td>
            </tr>
        </table>
    </form>
</body>
</html>
