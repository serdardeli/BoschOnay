<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TSSTalep.aspx.vb" Inherits="BoschOnay.TSSTalep" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Tamamlayıcı Sağlık Sigortası Talebi</title>
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
    </script>
    <style type="text/css">
        .auto-style1 {
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
                    <div id="PrintDoc">
                        <table style="width: 700px; background-color: white;" cellspacing="5">
                            <tr>
                                <td align="center">
                                    <table style="border: thin solid #000000; width: 100%; font-family: Calibri; font-size: 18px; font-weight: bold">
                                        <tr>
                                            <td align="center">Tamamlayıcı Sağlık Sigortası</td>
                                        </tr>
                                        <tr>
                                            <td align="center">Bağımlı Sigorta Başvuru Formu</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-family: Calibri; font-size: 12px;" align="left">Toplu İş Sözleşmesi 2017-2019 döneminde geçerli olacak Tamamlayıcı Sağlık Sigortası kapsamına talebiniz olması durumunda ve ücreti sizin tarafınızdan karşılanması şartı ile aile üyeleriniz de TSS kapsamına dahil edilebilmektedir. Sigorta işlemleriinin gerçekleştirilebilmesi için eş ve çocuklarınızın ismi, TC Kimlik Numarası ile sizin TC Kimlik Numaranız ve cep telefonunuza ihtiyaç duyulmaktadır. Verdiğiniz bu kişisel veriler KVKK’ya uygun olarak toplanacak, kaydedilecek ve Anadolu Sigorta tarafından işlenecektir.
                                    <br />
                                    <br />
                                    Haklarınız ile ilgili daha detaylı bilgi için, 6698 sayılı Kişisel Verilerin Korunması Kanunu’nun ilgili hükümlerine uygun olarak hazırlanan aydınlatma metnine <a href="https://www.bosch.com.tr/kisisel-verilerin-korunmasi/">https://www.bosch.com.tr/kisisel-verilerin-korunmasi/</a> adresinden ulaşabilirsiniz.
Bu çerçevede bu forma girdiğiniz kişisel bilgilerinizin diğer Bosch çalışanları ve gerekli üçüncü kişiler tarafından erişebilir olacağını bildiğinizi ve buna rıza gösterdiğinizi beyan ediyor olacaksınız.</td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="border: thin solid #000000; width: 100%">
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label1" runat="server" Text="Çalışan Personel No:" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                                        <td align="left">
                                                            <asp:TextBox ID="SicilNo" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" Width="160px" MaxLength="16" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" style="width: 100%">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="SicilNo" ErrorMessage="(*)" Font-Names="Calibri" Font-Size="12px" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label2" runat="server" Text="Çalışan TC Kimlik No:" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                                        <td align="left">
                                                            <asp:TextBox ID="KimlikNo" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="16" Width="160px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" style="width: 100%">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="KimlikNo" ErrorMessage="(*)" Font-Names="Calibri" Font-Size="12px" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label3" runat="server" Text="Çalışan Cep Telefonu:" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                                        <td align="left">
                                                            <asp:TextBox ID="TelNo" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="16" Width="160px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" style="width: 100%">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TelNo" ErrorMessage="(*)" Font-Names="Calibri" Font-Size="12px" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label6" runat="server" Text="Bağımlı Eş Adı Soyadı" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                                        <td align="left">
                                                            <asp:TextBox ID="EsAdi" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="50" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" style="width: 100%">
                                                            <asp:TextBox ID="EsSoyadi" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="50" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label7" runat="server" Text="Bağımlı Eş TC Kimlik No:" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                                        <td align="left" colspan="2">
                                                            <asp:TextBox ID="EsKimlikNo" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="16" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>

                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label31" runat="server" Text="Bağımlı 1. Çocuk Adı Soyadı:" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                                        <td align="left">
                                                            <asp:TextBox ID="CAdi0" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="50" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 100%" align="left">
                                                            <asp:TextBox ID="CSoyadi0" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="50" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label32" runat="server" Text="Bağımlı 1. Çocuk TC Kimlik No:" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                                        <td align="left" colspan="2" style="width: 100%">
                                                            <asp:TextBox ID="CKimlik0" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="16" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label33" runat="server" Text="Bağımlı 2. Çocuk Adı Soyadı:" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                                        <td align="left">
                                                            <asp:TextBox ID="CAdi1" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="50" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 100%" align="left">
                                                            <asp:TextBox ID="CSoyadi1" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="50" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label34" runat="server" Text="Bağımlı 2. Çocuk TC Kimlik No:" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                                        <td align="left" colspan="2">
                                                            <asp:TextBox ID="CKimlik1" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="16" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label35" runat="server" Text="Bağımlı 3. Çocuk Adı Soyadı:" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                                        <td align="left">
                                                            <asp:TextBox ID="CAdi2" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="50" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" style="width: 100%">
                                                            <asp:TextBox ID="CSoyadi2" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="50" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label36" runat="server" Text="Bağımlı 3. Çocuk TC Kimlik No:" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                                        <td align="left" colspan="2">
                                                            <asp:TextBox ID="CKimlik2" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="16" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label37" runat="server" Text="Bağımlı 4. Çocuk Adı Soyadı:" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                                        <td align="left">
                                                            <asp:TextBox ID="CAdi3" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="50" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" style="width: 100%">
                                                            <asp:TextBox ID="CSoyadi3" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="50" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label38" runat="server" Text="Bağımlı 4. Çocuk TC Kimlik No:" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                                        <td align="left" colspan="2">
                                                            <asp:TextBox ID="CKimlik3" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="16" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style1">
                                                <table>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label39" runat="server" Text="Bağımlı 5. Çocuk Adı Soyadı:" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                                        <td align="left">
                                                            <asp:TextBox ID="CAdi4" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="50" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" style="width: 100%">
                                                            <asp:TextBox ID="CSoyadi4" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="50" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label40" runat="server" Text="Bağımlı 5. Çocuk TC Kimlik No:" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                                        <td align="left" colspan="2">
                                                            <asp:TextBox ID="CKimlik4" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="16" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label41" runat="server" Text="Bağımlı 6. Çocuk Adı Soyadı:" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                                        <td align="left">
                                                            <asp:TextBox ID="CAdi5" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="50" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" style="width: 100%">
                                                            <asp:TextBox ID="CSoyadi5" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="50" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label42" runat="server" Text="Bağımlı 6. Çocuk TC Kimlik No:" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                                        <td align="left" colspan="2">
                                                            <asp:TextBox ID="CKimlik5" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="16" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label43" runat="server" Text="Bağımlı 7. Çocuk Adı Soyadı:" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                                        <td align="left">
                                                            <asp:TextBox ID="CAdi6" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="50" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                        <td align="left" style="width: 100%">
                                                            <asp:TextBox ID="CSoyadi6" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="50" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label44" runat="server" Text="Bağımlı 7. Çocuk TC Kimlik No:" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                                        <td align="left" colspan="2">
                                                            <asp:TextBox ID="CKimlik6" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="16" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>

                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table>
                                        <tr>
                                            <td style="font-family: Calibri; font-size: 12px;" align="left">İşbu belge ile yukarıda bilgilerini paylaştığım bağımlılarımın (Eş ve/veya Çocuk) kişisel verilerinin doğru, güncel ve tam olduğunu beyan ve taahhüt eder; bu bilgilerde herhangi bir değişiklik ve/veya güncelleme olması halinde MESS’e ve Sigorta Şirketine derhal bilgi vereceğimi, söz konusu bilgilerin tam, doğru ve güncel olmaması durumunda tamamlayıcı sağlık sigortası işlemleri ve bu sigorta kapsamında doğacak tüm masraf, kayıp ve zararlardan bizzat sorumlu olduğumu kabul beyan ve taahhüt ederim.</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 100%">
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label28" runat="server" Text="Adı Soyadı:" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                            <td align="left">
                                                <asp:TextBox ID="PAdi" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="50" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="PSoyadi" runat="server" BorderColor="Gainsboro" BorderStyle="Solid" BorderWidth="1px" MaxLength="50" Width="120px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                            </td>
                                            <td align="left">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="PAdi" ErrorMessage="(*)" Font-Names="Calibri" Font-Size="12px" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="left" style="width: 100%">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="PSoyadi" ErrorMessage="(*)" Font-Names="Calibri" Font-Size="12px" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label29" runat="server" Text="Tarih:" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                            <td align="left" colspan="4" class="auto-style2">
                                                <asp:Label ID="Tarih" runat="server" Font-Names="Calibri" Font-Size="12px" Width="200px"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label30" runat="server" Text="İmza:" Font-Names="Calibri" Font-Size="12px" Width="200px" Font-Bold="True"></asp:Label></td>
                                            <td style="width: 100%" colspan="4" align="left">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="right">&nbsp;</td>
                                            <td colspan="4" align="left">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="5">
                                                <telerik:RadBarcode ID="RadBarcode1" runat="server" Width="200px" Height="60px" Type="EAN13" Font-Names="Calibri" Font-Size="12px" Visible="false">
                                                </telerik:RadBarcode>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
