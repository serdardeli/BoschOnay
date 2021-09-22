Imports System.Data
Imports System.Web.UI
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Data.Common
Imports System.Drawing

Public Class AGIFormu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            pTerhisTar.Items.Clear()
            pTerhisTar.Items.Add("")
            For i As Integer = 0 To 40
                pTerhisTar.Items.Add(Now.Year - i)
            Next
            ResetForm()
        Else
            If CnvSicil(pSicilNo.Text) > 0 Then
                Mesaj.Text = ""
                Dim Conndb As New SqlConnection(CnvSQLString(ConfigurationManager.ConnectionStrings("SQLDirect").ToString))
                Dim QKayit As New SqlCommand("SELECT TOP 1 Per_PersNr AS SicilNo, isnull(Per_Vorname,'') + ' ' + isnull(Per_Name,'') AS AdSoyad, isnull(PIn_Fax,'') AS Bolum, isnull(Per_Grp4,'') AS MasrafYeri, isnull(Per_Grp2,'') AS CalAltGrup, isnull(PIn_Geschlecht,'') AS Cinsiyet FROM TPerTab INNER JOIN TPerInd ON Per_PersNr=PIn_PersNr WHERE Per_PersNr=@Per_PersNr AND Per_ZeitAktiv=1", Conndb)
                QKayit.Parameters.Add(New SqlParameter("@Per_PersNr", CnvSicil(pSicilNo.Text)))
                Try
                    Conndb.Open()
                Catch ex As Exception
                    Mesaj.Text = "Veritabanına bağlanılamadı!"
                    Exit Sub
                End Try
                Dim DataOku As SqlDataReader = QKayit.ExecuteReader
                If DataOku.HasRows Then
                    DataOku.Read()
                    pSicilNo.Text = DataOku!SicilNo
                    pSicilNo.ReadOnly = True
                    pSicilNo.BackColor = Color.White
                    If PrintDoc.Visible = False Then
                        Kaydet.Visible = True
                        LKaydet.Visible = True
                    End If
                    pAdSoyad.Text = DataOku!AdSoyad
                    pBolum.Text = DataOku!Bolum
                    pMasrafYeri.Text = DataOku!MasrafYeri
                    Cinsiyet.Value = DataOku!Cinsiyet
                    CalAltGrup.value = DataOku!CalAltGrup
                Else
                    ResetForm()
                    Mesaj.Text = "Personel bilgisi bulunamadı!"
                End If
                DataOku.Close()
                Conndb.Close()
            End If
        End If

        Cogrenim0.Visible = False
        Cogrenim1.Visible = False
        Cogrenim2.Visible = False
        Cogrenim3.Visible = False
        Cogrenim4.Visible = False
        Cogrenim5.Visible = False
        COgrenim6.Visible = False
        Cogrenim7.Visible = False
        Cogrenim8.Visible = False
        Cogrenim9.Visible = False

        If CDogumTar0.SelectedDate IsNot Nothing Then
            Cogrenim0.Visible = DateDiff(DateInterval.Year, CDogumTar0.SelectedDate.Value, Now.Date) > 18
        End If
        If CDogumTar1.SelectedDate IsNot Nothing Then
            Cogrenim1.Visible = DateDiff(DateInterval.Year, CDogumTar1.SelectedDate.Value, Now.Date) > 18
        End If
        If CDogumTar2.SelectedDate IsNot Nothing Then
            Cogrenim2.Visible = DateDiff(DateInterval.Year, CDogumTar2.SelectedDate.Value, Now.Date) > 18
        End If
        If CDogumTar3.SelectedDate IsNot Nothing Then
            Cogrenim3.Visible = DateDiff(DateInterval.Year, CDogumTar3.SelectedDate.Value, Now.Date) > 18
        End If
        If CDogumTar4.SelectedDate IsNot Nothing Then
            Cogrenim4.Visible = DateDiff(DateInterval.Year, CDogumTar4.SelectedDate.Value, Now.Date) > 18
        End If
        If CDogumTar5.SelectedDate IsNot Nothing Then
            Cogrenim5.Visible = DateDiff(DateInterval.Year, CDogumTar5.SelectedDate.Value, Now.Date) > 18
        End If
        If CDogumTar6.SelectedDate IsNot Nothing Then
            COgrenim6.Visible = DateDiff(DateInterval.Year, CDogumTar6.SelectedDate.Value, Now.Date) > 18
        End If
        If CDogumTar7.SelectedDate IsNot Nothing Then
            Cogrenim7.Visible = DateDiff(DateInterval.Year, CDogumTar7.SelectedDate.Value, Now.Date) > 18
        End If
        If CDogumTar8.SelectedDate IsNot Nothing Then
            Cogrenim8.Visible = DateDiff(DateInterval.Year, CDogumTar8.SelectedDate.Value, Now.Date) > 18
        End If
        If CDogumTar9.SelectedDate IsNot Nothing Then
            Cogrenim9.Visible = DateDiff(DateInterval.Year, CDogumTar9.SelectedDate.Value, Now.Date) > 18
        End If

        If CAdSoyad0.Text <> "" And CCinsiyet0.SelectedIndex <> 0 And (Cogrenim0.Visible = False Or Cogrenim0.SelectedIndex <> 0) And CDogumTar0.SelectedDate IsNot Nothing Then
            lbl1.Visible = True
            CAdSoyad1.Visible = True
            CCinsiyet1.Visible = True
            CDogumTar1.Visible = True
        End If

        If CAdSoyad1.Text <> "" And CCinsiyet1.SelectedIndex <> 0 And (Cogrenim1.Visible = False Or Cogrenim1.SelectedIndex <> 0) And CDogumTar1.SelectedDate IsNot Nothing Then
            lbl2.Visible = True
            CAdSoyad2.Visible = True
            CCinsiyet2.Visible = True
            CDogumTar2.Visible = True
        End If

        If CAdSoyad2.Text <> "" And CCinsiyet2.SelectedIndex <> 0 And (Cogrenim2.Visible = False Or Cogrenim2.SelectedIndex <> 0) And CDogumTar2.SelectedDate IsNot Nothing Then
            lbl3.Visible = True
            CAdSoyad3.Visible = True
            CCinsiyet3.Visible = True
            CDogumTar3.Visible = True
        End If

        If CAdSoyad3.Text <> "" And CCinsiyet3.SelectedIndex <> 0 And (Cogrenim3.Visible = False Or Cogrenim3.SelectedIndex <> 0) And CDogumTar3.SelectedDate IsNot Nothing Then
            lbl4.Visible = True
            CAdSoyad4.Visible = True
            CCinsiyet4.Visible = True
            CDogumTar4.Visible = True
        End If

        If CAdSoyad4.Text <> "" And CCinsiyet4.SelectedIndex <> 0 And (Cogrenim4.Visible = False Or Cogrenim4.SelectedIndex <> 0) And CDogumTar4.SelectedDate IsNot Nothing Then
            lbl5.Visible = True
            CAdSoyad5.Visible = True
            CCinsiyet5.Visible = True
            CDogumTar5.Visible = True
        End If

        If CAdSoyad5.Text <> "" And CCinsiyet5.SelectedIndex <> 0 And (Cogrenim5.Visible = False Or Cogrenim5.SelectedIndex <> 0) And CDogumTar5.SelectedDate IsNot Nothing Then
            lbl6.Visible = True
            CAdSoyad6.Visible = True
            CCinsiyet6.Visible = True
            CDogumTar6.Visible = True
        End If

        If CAdSoyad6.Text <> "" And CCinsiyet6.SelectedIndex <> 0 And (COgrenim6.Visible = False Or COgrenim6.SelectedIndex <> 0) And CDogumTar6.SelectedDate IsNot Nothing Then
            lbl7.Visible = True
            CAdSoyad7.Visible = True
            CCinsiyet7.Visible = True
            CDogumTar7.Visible = True
        End If

        If CAdSoyad7.Text <> "" And CCinsiyet7.SelectedIndex <> 0 And (Cogrenim7.Visible = False Or Cogrenim7.SelectedIndex <> 0) And CDogumTar7.SelectedDate IsNot Nothing Then
            lbl8.Visible = True
            CAdSoyad8.Visible = True
            CCinsiyet8.Visible = True
            CDogumTar8.Visible = True
        End If

        If CAdSoyad9.Text <> "" And CCinsiyet9.SelectedIndex <> 0 And (Cogrenim8.Visible = False Or Cogrenim9.SelectedIndex <> 0) And CDogumTar8.SelectedDate IsNot Nothing Then
            lbl9.Visible = True
            CAdSoyad9.Visible = True
            CCinsiyet9.Visible = True
            CDogumTar9.Visible = True
        End If

        If pMedeniHal.SelectedIndex = 2 Then
            EsInfo.Visible = True
        Else
            EsInfo.Visible = False
        End If

        pTerhisTar.Visible = False
        lTerhisTar.Visible = False
        pTecil.Visible = False
        pAskerlik.Visible = False
        lAskerlik.Visible = False

        If UCase(Cinsiyet.Value) <> "BAYAN" Then
            pAskerlik.Visible = True
            lAskerlik.Visible = True

            If pAskerlik.SelectedIndex = 1 Then
                pTerhisTar.Visible = True
                lTerhisTar.Visible = True
                lTerhisTar.Text = "Terhis Tarihi"
            End If

            If pAskerlik.SelectedIndex = 2 Then
                pTecil.Visible = True
                lTerhisTar.Visible = True
                lTerhisTar.Text = "Tecil Tarihi"
            End If
        End If

        If EsAGIDurum.SelectedIndex = 2 Or pMedeniHal.SelectedIndex = 1 Then
            CocukInfo.Visible = True
        Else
            CocukInfo.Visible = False
        End If

        If EsBoschDurum.SelectedIndex = 1 Then
            EsSicilNo.Visible = True
            lEsSicilNo.Visible = True
            bEsYenile.Visible = True
            EsAdSoyad.ReadOnly = True
            EsIsDurum.SelectedIndex = 1
            EsIsDurum.Enabled = False
        Else
            EsSicilNo.Visible = False
            lEsSicilNo.Visible = False
            bEsYenile.Visible = False
            EsAdSoyad.ReadOnly = False
            EsIsDurum.Enabled = True
        End If

        If EsIsDurum.SelectedIndex = 2 Then
            EsAGIDurum.SelectedIndex = 2
            EsAGIDurum.Enabled = False
            CocukInfo.Visible = True
        Else
            EsAGIDurum.Enabled = True
        End If
        pIl.Text = UCase(pIl.Text)
        pIlce.Text = UCase(pIlce.Text)
        pAdres.Text = UCase(pAdres.Text)
        EsAdSoyad.Text = UCase(EsAdSoyad.Text)
        CAdSoyad0.Text = UCase(CAdSoyad0.Text)
        CAdSoyad1.Text = UCase(CAdSoyad1.Text)
        CAdSoyad2.Text = UCase(CAdSoyad2.Text)
        CAdSoyad3.Text = UCase(CAdSoyad3.Text)
        CAdSoyad4.Text = UCase(CAdSoyad4.Text)
        CAdSoyad5.Text = UCase(CAdSoyad5.Text)
        CAdSoyad6.Text = UCase(CAdSoyad6.Text)
        CAdSoyad7.Text = UCase(CAdSoyad7.Text)
        CAdSoyad8.Text = UCase(CAdSoyad8.Text)
        CAdSoyad9.Text = UCase(CAdSoyad9.Text)

    End Sub

    Protected Sub Temizle_Click(sender As Object, e As UI.ImageClickEventArgs) Handles Temizle.Click
        ResetForm()
    End Sub

    Protected Sub Kaydet_Click(sender As Object, e As UI.ImageClickEventArgs) Handles Kaydet.Click
        Mesaj.Text = ""
        Dim Tipi As Integer = 0

        If pAdSoyad.Text = "" Then
            Mesaj.Text = "Personel bilgisi girilmemiş!"
            Exit Sub
        End If

        If pMedeniHal.SelectedIndex <= 0 Then
            Mesaj.Text = "Medeni hal bilgisini tam giriniz."
            Exit Sub
        End If

        If pMedeniHal.SelectedIndex = 2 Then
            If EsAdSoyad.Text = "" Then
                Mesaj.Text = "Eş bilgisini tam giriniz."
                Exit Sub
            End If
            If EsBoschDurum.SelectedIndex <= 0 Then
                Mesaj.Text = "'Eşiniz Bosch'da çalışıyor mu ?' bilgisini tam giriniz."
                Exit Sub
            End If
            If EsIsDurum.SelectedIndex <= 0 Then
                Mesaj.Text = "'Eş iş durumu' bilgisini tam giriniz."
                Exit Sub
            End If
            If EsAGIDurum.SelectedIndex <= 0 Then
                Mesaj.Text = "'Çalışıyorsa İşyerinde çocukları için AGİ'den faydalanıyor mu ?' bilgisini tam giriniz."
                Exit Sub
            End If
        End If

        If CAdSoyad0.Text <> "" And CocukInfo.Visible Then
            If Not (CCinsiyet0.SelectedIndex <> 0 And (Cogrenim0.Visible = False Or Cogrenim0.SelectedIndex <> 0) And CDogumTar0.SelectedDate IsNot Nothing) Then
                Mesaj.Text = "1. Çocuk bilgisini tam giriniz."
                Exit Sub
            End If
        End If

        If CAdSoyad1.Text <> "" And CocukInfo.Visible Then
            If Not (CCinsiyet1.SelectedIndex <> 0 And (Cogrenim1.Visible = False Or Cogrenim1.SelectedIndex <> 0) And CDogumTar1.SelectedDate IsNot Nothing) Then
                Mesaj.Text = "2. Çocuk bilgisini tam giriniz."
                Exit Sub
            End If
        End If

        If CAdSoyad2.Text <> "" And CocukInfo.Visible Then
            If Not (CCinsiyet2.SelectedIndex <> 0 And (Cogrenim2.Visible = False Or Cogrenim2.SelectedIndex <> 0) And CDogumTar2.SelectedDate IsNot Nothing) Then
                Mesaj.Text = "3. Çocuk bilgisini tam giriniz."
                Exit Sub
            End If
        End If

        If CAdSoyad3.Text <> "" And CocukInfo.Visible Then
            If Not (CCinsiyet3.SelectedIndex <> 0 And (Cogrenim3.Visible = False Or Cogrenim3.SelectedIndex <> 0) And CDogumTar3.SelectedDate IsNot Nothing) Then
                Mesaj.Text = "4. Çocuk bilgisini tam giriniz."
                Exit Sub
            End If
        End If

        If CAdSoyad4.Text <> "" And CocukInfo.Visible Then
            If Not (CCinsiyet4.SelectedIndex <> 0 And (Cogrenim4.Visible = False Or Cogrenim4.SelectedIndex <> 0) And CDogumTar4.SelectedDate IsNot Nothing) Then
                Mesaj.Text = "5. Çocuk bilgisini tam giriniz."
                Exit Sub
            End If
        End If

        If CAdSoyad5.Text <> "" And CocukInfo.Visible Then
            If Not (CCinsiyet5.SelectedIndex <> 0 And (Cogrenim5.Visible = False Or Cogrenim5.SelectedIndex <> 0) And CDogumTar5.SelectedDate IsNot Nothing) Then
                Mesaj.Text = "6. Çocuk bilgisini tam giriniz."
                Exit Sub
            End If
        End If

        If CAdSoyad6.Text <> "" And CocukInfo.Visible Then
            If Not (CCinsiyet6.SelectedIndex <> 0 And (COgrenim6.Visible = False Or COgrenim6.SelectedIndex <> 0) And CDogumTar6.SelectedDate IsNot Nothing) Then
                Mesaj.Text = "7. Çocuk bilgisini tam giriniz."
                Exit Sub
            End If
        End If

        If CAdSoyad7.Text <> "" And CocukInfo.Visible Then
            If Not (CCinsiyet7.SelectedIndex <> 0 And (Cogrenim7.Visible = False Or Cogrenim7.SelectedIndex <> 0) And CDogumTar7.SelectedDate IsNot Nothing) Then
                Mesaj.Text = "8. Çocuk bilgisini tam giriniz."
                Exit Sub
            End If
        End If

        If CAdSoyad8.Text <> "" And CocukInfo.Visible Then
            If Not (CCinsiyet8.SelectedIndex <> 0 And (Cogrenim8.Visible = False Or Cogrenim8.SelectedIndex <> 0) And CDogumTar8.SelectedDate IsNot Nothing) Then
                Mesaj.Text = "9. Çocuk bilgisini tam giriniz."
                Exit Sub
            End If
        End If

        If CAdSoyad9.Text <> "" And CocukInfo.Visible Then
            If Not (CCinsiyet9.SelectedIndex <> 0 And (Cogrenim9.Visible = False Or Cogrenim9.SelectedIndex <> 0) And CDogumTar9.SelectedDate IsNot Nothing) Then
                Mesaj.Text = "10. Çocuk bilgisini tam giriniz."
                Exit Sub
            End If
        End If

        If UCase(Cinsiyet.Value) = "BAY" Then
            ylAskerlik.Visible = True
            yAskerlik.Visible = True
            yTerhisTar.Visible = True
            ylTerhisTar.Visible = True

            If pAskerlik.SelectedIndex <= 0 Then
                Mesaj.Text = "Askerlik durumunu giriniz!"
                Exit Sub
            End If

            If pAskerlik.SelectedIndex = 1 And pTerhisTar.SelectedIndex = 0 Then
                Mesaj.Text = "Askerlik terhis tarihini giriniz!"
                Exit Sub
            End If

            If pAskerlik.SelectedIndex = 2 And pTecil.SelectedDate Is Nothing Then
                Mesaj.Text = "Askerlik tecil tarihini giriniz!"
                Exit Sub
            End If
        Else
            ylAskerlik.Visible = False
            yAskerlik.Visible = False
            yTerhisTar.Visible = False
            ylTerhisTar.Visible = False
        End If

        If pCepNo.Text.Length < 10 Then
            Mesaj.Text = "Lütfen geçerli bir telefon bilgisi giriniz!"
            Exit Sub
        End If
        If pIl.Text.Length < 3 Then
            Mesaj.Text = "Lütfen geçerli il bilgisi giriniz!"
            Exit Sub
        End If
        If pIlce.Text.Length < 3 Then
            Mesaj.Text = "Lütfen geçerli ilçe bilgisi giriniz!"
            Exit Sub
        End If
        If pAdres.Text.Length < 20 Then
            Mesaj.Text = "Lütfen adres bilgisini tam giriniz!"
            Exit Sub
        End If

        Dim SQLStr As String = ""
        SQLStr = "INSERT INTO BoschAGI (SicilNo, AdSoyad, Bolum, MasrafYeri, Askerlik, TerhisTar, TecilTar, MedeniHal, CepTel, IlAdi, IlceAdi, Adres, EsBoschDurum, EsSicilNo, EsAdSoyad, EsIsDurum, EsAGIDurum, Tipi, AAdSoyad, ADTarihi, ACinsiyet, AOgrenim, Tarih, Barkod, ODurum, Cinsiyet, CalAltGrup)"
        SQLStr = SQLStr & " OUTPUT Inserted.IdNr VALUES (@SicilNo, @AdSoyad, @Bolum, @MasrafYeri, @Askerlik, @TerhisTar, @TecilTar, @MedeniHal, @CepTel, @IlAdi, @IlceAdi, @Adres, @EsBoschDurum, @EsSicilNo, @EsAdSoyad, @EsIsDurum, @EsAGIDurum, @Tipi, @AAdSoyad, @ADTarihi, @ACinsiyet, @AOgrenim, @Tarih, @Barkod,2, @Cinsiyet, @CalAltGrup)"

        Dim ConnDb As New SqlConnection(CnvSQLString(ConfigurationManager.ConnectionStrings("SQLDirect").ToString))
        Dim QKayit As New SqlCommand(SQLStr, ConnDb)
        Dim UKayit As New SqlCommand("", ConnDb)

        QKayit.Parameters.Add(New SqlParameter("@SicilNo", pSicilNo.Text))
        QKayit.Parameters.Add(New SqlParameter("@AdSoyad", pAdSoyad.Text))
        QKayit.Parameters.Add(New SqlParameter("@Bolum", pBolum.Text))
        QKayit.Parameters.Add(New SqlParameter("@MasrafYeri", pMasrafYeri.Text))
        QKayit.Parameters.Add(New SqlParameter("@Askerlik", pAskerlik.SelectedIndex))
        QKayit.Parameters.Add(New SqlParameter("@TerhisTar", IIf(pAskerlik.SelectedIndex = 1, pTerhisTar.SelectedItem.ToString, 0)))
        QKayit.Parameters.Add(New SqlParameter("@TecilTar", IIf(pAskerlik.SelectedIndex = 2, pTecil.SelectedDate, DBNull.Value)))
        QKayit.Parameters.Add(New SqlParameter("@MedeniHal", pMedeniHal.SelectedIndex))
        QKayit.Parameters.Add(New SqlParameter("@CepTel", pCepNo.Text))
        QKayit.Parameters.Add(New SqlParameter("@IlAdi", pIl.Text))
        QKayit.Parameters.Add(New SqlParameter("@IlceAdi", pIlce.Text))
        QKayit.Parameters.Add(New SqlParameter("@Adres", pAdres.Text))
        QKayit.Parameters.Add(New SqlParameter("@EsBoschDurum", IIf(pMedeniHal.SelectedIndex = 2, EsBoschDurum.SelectedIndex, 0)))
        QKayit.Parameters.Add(New SqlParameter("@EsSicilNo", IIf(pMedeniHal.SelectedIndex = 2, EsSicilNo.Text, "")))
        QKayit.Parameters.Add(New SqlParameter("@EsAdSoyad", IIf(pMedeniHal.SelectedIndex = 2, EsAdSoyad.Text, "")))
        QKayit.Parameters.Add(New SqlParameter("@EsIsDurum", IIf(pMedeniHal.SelectedIndex = 2, EsIsDurum.SelectedIndex, 0)))
        QKayit.Parameters.Add(New SqlParameter("@EsAGIDurum", IIf(pMedeniHal.SelectedIndex = 2, EsAGIDurum.SelectedIndex, 0)))
        QKayit.Parameters.Add(New SqlParameter("@Tarih", Now))
        QKayit.Parameters.Add(New SqlParameter("@Tipi", 0))
        QKayit.Parameters.Add(New SqlParameter("@Barkod", ""))
        QKayit.Parameters.Add(New SqlParameter("@AAdSoyad", IIf(CocukInfo.Visible, IIf(CAdSoyad0.Text <> "", CAdSoyad0.Text, ""), "")))
        QKayit.Parameters.Add(New SqlParameter("@ADTarihi", IIf(CocukInfo.Visible, IIf(CAdSoyad0.Text <> "", CDogumTar0.SelectedDate, DBNull.Value), DBNull.Value)))
        QKayit.Parameters.Add(New SqlParameter("@ACinsiyet", IIf(CocukInfo.Visible, IIf(CAdSoyad0.Text <> "", CCinsiyet0.SelectedIndex, 0), 0)))
        QKayit.Parameters.Add(New SqlParameter("@AOgrenim", IIf(CocukInfo.Visible, IIf(CAdSoyad0.Text <> "", Cogrenim0.SelectedIndex, 0), 0)))
        QKayit.Parameters.Add(New SqlParameter("@Cinsiyet", Cinsiyet.Value))
        QKayit.Parameters.Add(New SqlParameter("@CalAltGrup", CalAltGrup.Value))

        Try
            ConnDb.Open()
        Catch ex As Exception
            Mesaj.Text = "Veritabanına bağlanılamadı!"
            Exit Sub
        End Try

        Dim Barcode As Long = 0L
        Barcode = QKayit.ExecuteScalar()

        If Barcode > 0 Then
            RadBarcode1.Text = "8" & Format(Barcode, "00000000000")
            QKayit.Parameters("@Barkod").Value = RadBarcode1.Text & CheckSum(RadBarcode1.Text)
            UKayit.CommandText = "UPDATE BoschAGI SET Barkod='" & RadBarcode1.Text & CheckSum(RadBarcode1.Text) & "' WHERE IdNr=" & Barcode
            UKayit.ExecuteNonQuery()
        Else
            Mesaj.Text = "Veriler kaydedilemedi!"
            ConnDb.Close()
            Exit Sub
        End If

        If pAskerlik.SelectedIndex = 2 Then
            pTecil.Visible = False
        End If

        If CAdSoyad1.Text <> "" And CocukInfo.Visible Then
            QKayit.Parameters("@Tipi").Value = 1
            QKayit.Parameters("@AAdSoyad").Value = CAdSoyad1.Text
            QKayit.Parameters("@ADTarihi").Value = CDogumTar1.SelectedDate
            QKayit.Parameters("@ACinsiyet").Value = CCinsiyet1.SelectedIndex
            QKayit.Parameters("@AOgrenim").Value = Cogrenim1.SelectedIndex
            QKayit.ExecuteNonQuery()
        End If

        If CAdSoyad2.Text <> "" And CocukInfo.Visible Then
            QKayit.Parameters("@Tipi").Value = 2
            QKayit.Parameters("@AAdSoyad").Value = CAdSoyad2.Text
            QKayit.Parameters("@ADTarihi").Value = CDogumTar2.SelectedDate
            QKayit.Parameters("@ACinsiyet").Value = CCinsiyet2.SelectedIndex
            QKayit.Parameters("@AOgrenim").Value = Cogrenim2.SelectedIndex
            QKayit.ExecuteNonQuery()
        End If

        If CAdSoyad3.Text <> "" And CocukInfo.Visible Then
            QKayit.Parameters("@Tipi").Value = 3
            QKayit.Parameters("@AAdSoyad").Value = CAdSoyad3.Text
            QKayit.Parameters("@ADTarihi").Value = CDogumTar3.SelectedDate
            QKayit.Parameters("@ACinsiyet").Value = CCinsiyet3.SelectedIndex
            QKayit.Parameters("@AOgrenim").Value = Cogrenim3.SelectedIndex
            QKayit.ExecuteNonQuery()
        End If

        If CAdSoyad4.Text <> "" And CocukInfo.Visible Then
            QKayit.Parameters("@Tipi").Value = 4
            QKayit.Parameters("@AAdSoyad").Value = CAdSoyad4.Text
            QKayit.Parameters("@ADTarihi").Value = CDogumTar4.SelectedDate
            QKayit.Parameters("@ACinsiyet").Value = CCinsiyet4.SelectedIndex
            QKayit.Parameters("@AOgrenim").Value = Cogrenim4.SelectedIndex
            QKayit.ExecuteNonQuery()
        End If

        If CAdSoyad5.Text <> "" And CocukInfo.Visible Then
            QKayit.Parameters("@Tipi").Value = 5
            QKayit.Parameters("@AAdSoyad").Value = CAdSoyad5.Text
            QKayit.Parameters("@ADTarihi").Value = CDogumTar5.SelectedDate
            QKayit.Parameters("@ACinsiyet").Value = CCinsiyet5.SelectedIndex
            QKayit.Parameters("@AOgrenim").Value = Cogrenim5.SelectedIndex
            QKayit.ExecuteNonQuery()
        End If

        If CAdSoyad6.Text <> "" And CocukInfo.Visible Then
            QKayit.Parameters("@Tipi").Value = 6
            QKayit.Parameters("@AAdSoyad").Value = CAdSoyad6.Text
            QKayit.Parameters("@ADTarihi").Value = CDogumTar6.SelectedDate
            QKayit.Parameters("@ACinsiyet").Value = CCinsiyet6.SelectedIndex
            QKayit.Parameters("@AOgrenim").Value = COgrenim6.SelectedIndex
            QKayit.ExecuteNonQuery()
        End If

        If CAdSoyad7.Text <> "" And CocukInfo.Visible Then
            QKayit.Parameters("@Tipi").Value = 7
            QKayit.Parameters("@AAdSoyad").Value = CAdSoyad7.Text
            QKayit.Parameters("@ADTarihi").Value = CDogumTar7.SelectedDate
            QKayit.Parameters("@ACinsiyet").Value = CCinsiyet7.SelectedIndex
            QKayit.Parameters("@AOgrenim").Value = Cogrenim7.SelectedIndex
            QKayit.ExecuteNonQuery()
        End If

        If CAdSoyad8.Text <> "" And CocukInfo.Visible Then
            QKayit.Parameters("@Tipi").Value = 8
            QKayit.Parameters("@AAdSoyad").Value = CAdSoyad8.Text
            QKayit.Parameters("@ADTarihi").Value = CDogumTar8.SelectedDate
            QKayit.Parameters("@ACinsiyet").Value = CCinsiyet8.SelectedIndex
            QKayit.Parameters("@AOgrenim").Value = Cogrenim8.SelectedIndex
            QKayit.ExecuteNonQuery()
        End If

        If CAdSoyad9.Text <> "" And CocukInfo.Visible Then
            QKayit.Parameters("@Tipi").Value = 9
            QKayit.Parameters("@AAdSoyad").Value = CAdSoyad9.Text
            QKayit.Parameters("@ADTarihi").Value = CDogumTar9.SelectedDate
            QKayit.Parameters("@ACinsiyet").Value = CCinsiyet9.SelectedIndex
            QKayit.Parameters("@AOgrenim").Value = Cogrenim9.SelectedIndex
            QKayit.ExecuteNonQuery()
        End If

        If Barcode > 0 Then
            Mesaj.Text = "Bilgiler kaydedildi! Yazdırabilirsiniz..."
            PrintDoc.Visible = True
            yEsInfo.Visible = EsInfo.Visible
            CocukInfo2.Visible = CocukInfo.Visible
            yCOgrenim0.Visible = Cogrenim0.Visible
            yCOgrenim1.Visible = Cogrenim1.Visible
            yCOgrenim2.Visible = Cogrenim2.Visible
            yCOgrenim3.Visible = Cogrenim3.Visible
            yCOgrenim4.Visible = Cogrenim4.Visible
            yCOgrenim5.Visible = Cogrenim5.Visible
            yCOgrenim6.Visible = COgrenim6.Visible
            yCOgrenim7.Visible = Cogrenim7.Visible
            yCOgrenim8.Visible = Cogrenim8.Visible
            yCOgrenim9.Visible = Cogrenim9.Visible

            'QKayit.CommandText = "DELETE EAGI WHERE SicilNo=@SicilNo AND Barkod<>@Barkod AND OUser IS Null"
            'QKayit.ExecuteNonQuery()

            InputDoc.Visible = False

            ySicilNo.Text = pSicilNo.Text
            yAdSoyad.Text = pAdSoyad.Text
            IAdSoyad.Text = pAdSoyad.Text
            ITarih.Text = Format(Now.Date, "dd.MM.yyyy")
            yBolum.Text = pBolum.Text
            yMasrafYeri.Text = pMasrafYeri.Text
            yAskerlik.Text = pAskerlik.SelectedItem.Text
            yTerhisTar.Visible = True
            ylTerhisTar.Visible = True
            If pAskerlik.SelectedIndex = 1 Then
                yTerhisTar.Text = pTerhisTar.SelectedItem.Text
                ylTerhisTar.Text = "Terhis Tarihi"
            Else
                If pAskerlik.SelectedIndex = 2 Then
                    yTerhisTar.Text = Format(pTecil.SelectedDate, "MMMM yyyy")
                    ylTerhisTar.Text = "Tecil Tarihi"
                Else
                    yTerhisTar.Visible = False
                    ylTerhisTar.Visible = False
                End If
            End If
            yMedeniHal.Text = pMedeniHal.SelectedItem.Text

            yCepTel.Text = pCepNo.Text
            yIl.Text = pIl.Text
            yIlce.Text = pIlce.Text
            yAdres2.Text = pAdres.Text

            yEsBoschDurum.Text = EsBoschDurum.SelectedItem.Text
            yEsSicilNo.Text = EsSicilNo.Text
            yEsAdSoyad.Text = EsAdSoyad.Text
            ylEsSicilno.Visible = lEsSicilNo.Visible
            yEsSicilNo.Visible = EsSicilNo.Visible
            yEsIsDurum.Text = EsIsDurum.SelectedItem.Text
            yEsAGIDurum.Text = EsAGIDurum.SelectedItem.Text

            yCAdSoyad0.Visible = False
            yCAdSoyad1.Visible = False
            yCAdSoyad2.Visible = False
            yCAdSoyad3.Visible = False
            yCAdSoyad4.Visible = False
            yCAdSoyad5.Visible = False
            yCAdSoyad6.Visible = False
            yCAdSoyad7.Visible = False
            yCAdSoyad8.Visible = False
            yCAdSoyad9.Visible = False

            yCCinsiyet0.Visible = False
            yCCinsiyet1.Visible = False
            yCCinsiyet2.Visible = False
            yCCinsiyet3.Visible = False
            yCCinsiyet4.Visible = False
            yCCinsiyet5.Visible = False
            yCCinsiyet6.Visible = False
            yCCinsiyet7.Visible = False
            yCCinsiyet8.Visible = False
            yCCinsiyet9.Visible = False

            yCDogumTar0.Visible = False
            yCDogumTar1.Visible = False
            yCDogumTar2.Visible = False
            yCDogumTar3.Visible = False
            yCDogumTar4.Visible = False
            yCDogumTar5.Visible = False
            yCDogumTar6.Visible = False
            yCDogumTar7.Visible = False
            yCDogumTar8.Visible = False
            yCDogumTar9.Visible = False

            yNo0.Visible = False
            yNo1.Visible = False
            yNo2.Visible = False
            yNo3.Visible = False
            yNo4.Visible = False
            yNo5.Visible = False
            yNo6.Visible = False
            yNo7.Visible = False
            yNo8.Visible = False
            yNo9.Visible = False

            If CAdSoyad0.Text <> "" Then
                yCAdSoyad0.Text = CAdSoyad0.Text
                yCCinsiyet0.Text = CCinsiyet0.SelectedItem.Text
                yCOgrenim0.Text = Cogrenim0.SelectedItem.Text
                yCDogumTar0.Text = Format(CDogumTar0.SelectedDate, "dd.MM.yyyy")
                yNo0.Visible = True
                yCAdSoyad0.Visible = True
                yCCinsiyet0.Visible = True
                yCDogumTar0.Visible = True
            End If

            If CAdSoyad1.Text <> "" Then
                yCAdSoyad1.Text = CAdSoyad1.Text
                yCCinsiyet1.Text = CCinsiyet1.SelectedItem.Text
                yCOgrenim1.Text = Cogrenim1.SelectedItem.Text
                yCDogumTar1.Text = Format(CDogumTar1.SelectedDate, "dd.MM.yyyy")
                yNo1.Visible = True
                yCAdSoyad1.Visible = True
                yCCinsiyet1.Visible = True
                yCDogumTar1.Visible = True
            End If

            If CAdSoyad2.Text <> "" Then
                yCAdSoyad2.Text = CAdSoyad2.Text
                yCCinsiyet2.Text = CCinsiyet2.SelectedItem.Text
                yCOgrenim2.Text = Cogrenim2.SelectedItem.Text
                yCDogumTar2.Text = Format(CDogumTar2.SelectedDate, "dd.MM.yyyy")
                yNo2.Visible = True
                yCAdSoyad2.Visible = True
                yCCinsiyet2.Visible = True
                yCDogumTar2.Visible = True
            End If

            If CAdSoyad3.Text <> "" Then
                yCAdSoyad3.Text = CAdSoyad3.Text
                yCCinsiyet3.Text = CCinsiyet3.SelectedItem.Text
                yCOgrenim3.Text = Cogrenim3.SelectedItem.Text
                yCDogumTar3.Text = Format(CDogumTar3.SelectedDate, "dd.MM.yyyy")
                yNo3.Visible = True
                yCAdSoyad3.Visible = True
                yCCinsiyet3.Visible = True
                yCDogumTar3.Visible = True
            End If

            If CAdSoyad4.Text <> "" Then
                yCAdSoyad4.Text = CAdSoyad4.Text
                yCCinsiyet4.Text = CCinsiyet4.SelectedItem.Text
                yCOgrenim4.Text = Cogrenim4.SelectedItem.Text
                yCDogumTar4.Text = Format(CDogumTar4.SelectedDate, "dd.MM.yyyy")
                yNo4.Visible = True
                yCAdSoyad4.Visible = True
                yCCinsiyet4.Visible = True
                yCDogumTar4.Visible = True
            End If

            If CAdSoyad5.Text <> "" Then
                yCAdSoyad5.Text = CAdSoyad5.Text
                yCCinsiyet5.Text = CCinsiyet5.SelectedItem.Text
                yCOgrenim5.Text = Cogrenim5.SelectedItem.Text
                yCDogumTar5.Text = Format(CDogumTar5.SelectedDate, "dd.MM.yyyy")
                yNo5.Visible = True
                yCAdSoyad5.Visible = True
                yCCinsiyet5.Visible = True
                yCDogumTar5.Visible = True
            End If

            If CAdSoyad6.Text <> "" Then
                yCAdSoyad6.Text = CAdSoyad6.Text
                yCCinsiyet6.Text = CCinsiyet6.SelectedItem.Text
                yCOgrenim6.Text = COgrenim6.SelectedItem.Text
                yCDogumTar6.Text = Format(CDogumTar6.SelectedDate, "dd.MM.yyyy")
                yNo6.Visible = True
                yCAdSoyad6.Visible = True
                yCCinsiyet6.Visible = True
                yCDogumTar6.Visible = True
            End If

            If CAdSoyad7.Text <> "" Then
                yCAdSoyad7.Text = CAdSoyad7.Text
                yCCinsiyet7.Text = CCinsiyet7.SelectedItem.Text
                yCOgrenim7.Text = Cogrenim7.SelectedItem.Text
                yCDogumTar7.Text = Format(CDogumTar7.SelectedDate, "dd.MM.yyyy")
                yNo7.Visible = True
                yCAdSoyad7.Visible = True
                yCCinsiyet7.Visible = True
                yCDogumTar7.Visible = True
            End If

            If CAdSoyad8.Text <> "" Then
                yCAdSoyad8.Text = CAdSoyad8.Text
                yCCinsiyet8.Text = CCinsiyet8.SelectedItem.Text
                yCOgrenim8.Text = Cogrenim8.SelectedItem.Text
                yCDogumTar8.Text = Format(CDogumTar8.SelectedDate, "dd.MM.yyyy")
                yNo8.Visible = True
                yCAdSoyad8.Visible = True
                yCCinsiyet8.Visible = True
                yCDogumTar8.Visible = True
            End If

            If CAdSoyad9.Text <> "" Then
                yCAdSoyad9.Text = CAdSoyad9.Text
                yCCinsiyet9.Text = CCinsiyet9.SelectedItem.Text
                yCOgrenim9.Text = Cogrenim9.SelectedItem.Text
                yCDogumTar9.Text = Format(CDogumTar9.SelectedDate, "dd.MM.yyyy")
                yNo9.Visible = True
                yCAdSoyad9.Visible = True
                yCCinsiyet9.Visible = True
                yCDogumTar9.Visible = True
            End If

            Kaydet.Visible = False
            Yazdir.Visible = True
            LKaydet.Visible = False
            LYazdir.Visible = True
            RadBarcode1.Visible = True
        End If
    End Sub

    Private Sub ResetForm()

        InputDoc.Visible = True
        PrintDoc.Visible = False

        pSicilNo.Text = ""
        pSicilNo.ReadOnly = False
        pSicilNo.BackColor = pIl.BackColor

        pAdSoyad.Text = ""
        pBolum.Text = ""
        pMasrafYeri.Text = ""
        Cinsiyet.Value = "Bay"
        pAskerlik.SelectedIndex = 0
        pTerhisTar.SelectedIndex = 0
        pMedeniHal.SelectedIndex = 0

        EsInfo.Visible = False
        CocukInfo.Visible = True
        EsAGIDurum.Enabled = True
        EsIsDurum.Enabled = True

        pCepNo.Text = ""
        pIl.Text = ""
        pIlce.Text = ""
        pAdres.Text = ""

        EsBoschDurum.SelectedIndex = 0
        EsSicilNo.Text = ""
        EsAdSoyad.Text = ""
        EsIsDurum.SelectedIndex = 0
        EsAGIDurum.SelectedIndex = 0

        CAdSoyad0.Text = ""
        CAdSoyad1.Text = ""
        CAdSoyad2.Text = ""
        CAdSoyad3.Text = ""
        CAdSoyad4.Text = ""
        CAdSoyad5.Text = ""
        CAdSoyad6.Text = ""
        CAdSoyad7.Text = ""
        CAdSoyad8.Text = ""
        CAdSoyad9.Text = ""

        CCinsiyet0.SelectedIndex = 0
        CCinsiyet1.SelectedIndex = 0
        CCinsiyet2.SelectedIndex = 0
        CCinsiyet3.SelectedIndex = 0
        CCinsiyet4.SelectedIndex = 0
        CCinsiyet5.SelectedIndex = 0
        CCinsiyet6.SelectedIndex = 0
        CCinsiyet7.SelectedIndex = 0
        CCinsiyet8.SelectedIndex = 0
        CCinsiyet9.SelectedIndex = 0

        Cogrenim0.SelectedIndex = 0
        Cogrenim1.SelectedIndex = 0
        Cogrenim2.SelectedIndex = 0
        Cogrenim3.SelectedIndex = 0
        Cogrenim4.SelectedIndex = 0
        Cogrenim5.SelectedIndex = 0
        COgrenim6.SelectedIndex = 0
        Cogrenim7.SelectedIndex = 0
        Cogrenim8.SelectedIndex = 0
        Cogrenim9.SelectedIndex = 0

        CDogumTar0.SelectedDate = Nothing
        CDogumTar1.SelectedDate = Nothing
        CDogumTar2.SelectedDate = Nothing
        CDogumTar3.SelectedDate = Nothing
        CDogumTar4.SelectedDate = Nothing
        CDogumTar5.SelectedDate = Nothing
        CDogumTar6.SelectedDate = Nothing
        CDogumTar7.SelectedDate = Nothing
        CDogumTar8.SelectedDate = Nothing
        CDogumTar9.SelectedDate = Nothing

        CAdSoyad0.Visible = True
        CAdSoyad1.Visible = False
        CAdSoyad2.Visible = False
        CAdSoyad3.Visible = False
        CAdSoyad4.Visible = False
        CAdSoyad5.Visible = False
        CAdSoyad6.Visible = False
        CAdSoyad7.Visible = False
        CAdSoyad8.Visible = False
        CAdSoyad9.Visible = False

        CCinsiyet0.Visible = True
        CCinsiyet1.Visible = False
        CCinsiyet2.Visible = False
        CCinsiyet3.Visible = False
        CCinsiyet4.Visible = False
        CCinsiyet5.Visible = False
        CCinsiyet6.Visible = False
        CCinsiyet7.Visible = False
        CCinsiyet8.Visible = False
        CCinsiyet9.Visible = False

        Cogrenim0.Visible = True
        Cogrenim1.Visible = False
        Cogrenim2.Visible = False
        Cogrenim3.Visible = False
        Cogrenim4.Visible = False
        Cogrenim5.Visible = False
        COgrenim6.Visible = False
        Cogrenim7.Visible = False
        Cogrenim8.Visible = False
        Cogrenim9.Visible = False

        CDogumTar0.Visible = True
        CDogumTar1.Visible = False
        CDogumTar2.Visible = False
        CDogumTar3.Visible = False
        CDogumTar4.Visible = False
        CDogumTar5.Visible = False
        CDogumTar6.Visible = False
        CDogumTar7.Visible = False
        CDogumTar8.Visible = False
        CDogumTar9.Visible = False

        lbl0.Visible = True
        lbl1.Visible = False
        lbl2.Visible = False
        lbl3.Visible = False
        lbl4.Visible = False
        lbl5.Visible = False
        lbl6.Visible = False
        lbl7.Visible = False
        lbl8.Visible = False
        lbl9.Visible = False

        Mesaj.Text = ""
        Kaydet.Visible = False
        Yazdir.Visible = False
        LKaydet.Visible = False
        LYazdir.Visible = False
        RadBarcode1.Visible = False
        pSicilNo.Focus()
    End Sub

    Private Function CheckSum(ByVal BarkodStr As String) As Integer
        Dim X As Integer = 0
        Dim Y As Integer = 0
        Dim j As Integer = 12
        For i As Integer = 1 To 12
            If i Mod 2 = 0 Then
                X += Val(Mid(BarkodStr, j, 1))
            Else
                Y += Val(Mid(BarkodStr, j, 1))
            End If
            j -= 1
        Next
        Dim Z As Integer = X + (3 * Y)
        Return ((10 - (Z Mod 10)) Mod 10)
    End Function

    Private Function CnvSicil(ByVal Sicil As String) As Long
        Try
            Return CLng(Sicil)
        Catch ex As Exception
            Mesaj.Text = "Lütfen sicil numarasını numerik değer olarak giriniz!"
            Return 0
        End Try
    End Function

    Private Sub bEsYenile_Click(sender As Object, e As EventArgs) Handles bEsYenile.Click
        Mesaj.Text = ""
        Dim Conndb As New SqlConnection(CnvSQLString(ConfigurationManager.ConnectionStrings("SQLDirect").ToString))
        Dim QKayit As New SqlCommand("SELECT TOP 1 Per_PersNr AS SicilNo, isnull(Per_Vorname,'') + ' ' + isnull(Per_Name,'') AS AdSoyad FROM TPerTab WHERE Per_PersNr=@Per_PersNr AND Per_ZeitAktiv=1", Conndb)
        QKayit.Parameters.Add(New SqlParameter("@Per_PersNr", CnvSicil(EsSicilNo.Text)))
        Try
            Conndb.Open()
        Catch ex As Exception
            Mesaj.Text = "Veritabanına bağlanılamadı!"
            Exit Sub
        End Try
        Dim DataOku As SqlDataReader = QKayit.ExecuteReader
        If DataOku.HasRows Then
            DataOku.Read()
            EsSicilNo.Text = DataOku!SicilNo
            EsAdSoyad.Text = DataOku!AdSoyad
        Else
            Mesaj.Text = "Eş personel bilgisi bulunamadı!"
        End If
        DataOku.Close()
        Conndb.Close()
    End Sub
End Class