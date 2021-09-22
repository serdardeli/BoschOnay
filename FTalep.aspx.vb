Imports Telerik.Reporting.Processing
Imports Telerik.Web.UI.Calendar

Public Class FTalep
    Inherits System.Web.UI.Page

    Public Sub New()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            rizintipi.SelectedIndex = 0
            ResetForm()
        End If
        Tarih.Text = Now.Date.ToString("dd.MM.yyyy")
    End Sub

    Protected Sub RefreshData()
        Mesaj.Text = ""
        If SicilNo.Value = 0 Then
            ResetForm()
            Mesaj.Text = "Lütfen geçerli bir sicil numarası giriniz."
        Else
            Mesaj.Text = ""
            BTemizle.Visible = True
            BYenile.Visible = False
            SicilNo.ReadOnly = True

            TAdSoyad.Visible = True
            TGrup0.Visible = True
            TGrup1.Visible = True
            TGrup2.Visible = True
            TGrup3.Visible = True
            TGrup4.Visible = True
            TKisim.Visible = True

            BasTar.Visible = True
            BitTar.Visible = True
            TSure.Visible = True
            Tipi.Visible = True
            TAciklama.Visible = True

            RAdSoyad.Visible = True
            RGrup0.Visible = True
            RGrup1.Visible = True
            RGrup2.Visible = True
            RGrup3.Visible = True
            RGrup4.Visible = True
            RKisim.Visible = True

            RBasTar.Visible = True
            RBitTar.Visible = True
            RSure.Visible = True
            RGun.Visible = True
            RTipi.Visible = True
            RAciklama.Visible = True

            RadLabel1.Visible = True
            rizintipi.Visible = True
            BYazdir.Visible = True
            Label2.Visible = True
            Label3.Visible = True

            Dim UDate As Date = Now
            Dim SQLStr As String = ""
            Dim RSql As New SqlForConnection
            Dim pTable As DataTable = RSql.GetValue("SELECT isnull(Grp00,'') AS Grp00, isnull(Grp01,'') AS  Grp01, isnull(Grp02,'') AS Grp02, isnull(Grp03,'') AS Grp03, isnull(Grp04,'') AS Grp04, isnull(Grp05,'') AS Grp05, isnull(GrpName00,'') AS GrpName00, isnull(GrpName01,'') AS GrpName01, isnull(GrpName02,'') AS GrpName02, isnull(GrpName03,'') GrpName03, isnull(GrpName04,'') AS GrpName04 , isnull(GrpName05,'') AS GrpName05 FROM BoschLisans")
            If Not pTable Is Nothing Then
                If pTable.Rows.Count > 0 Then
                    SQLStr = "SELECT Per_PersNr AS SicilNo, (isnull(Adi,'') + ' ' + isnull(Soyadi,'')) AS AdSoyad, "
                    If pTable.Rows(0)!Grp00 <> "" Then
                        SQLStr = SQLStr & " isnull(" & pTable.Rows(0)!Grp00 & ",'') AS Grp00,"
                    Else
                        SQLStr = SQLStr & " '' AS Grp00,"
                    End If
                    If pTable.Rows(0)!Grp01 <> "" Then
                        SQLStr = SQLStr & " isnull(" & pTable.Rows(0)!Grp01 & ",'') AS Grp01,"
                    Else
                        SQLStr = SQLStr & " '' AS Grp01,"
                    End If
                    If pTable.Rows(0)!Grp02 <> "" Then
                        SQLStr = SQLStr & " isnull(" & pTable.Rows(0)!Grp02 & ",'') AS Grp02,"
                    Else
                        SQLStr = SQLStr & " '' AS Grp02,"
                    End If
                    If pTable.Rows(0)!Grp03 <> "" Then
                        SQLStr = SQLStr & " isnull(" & pTable.Rows(0)!Grp03 & ",'') AS Grp03,"
                    Else
                        SQLStr = SQLStr & " '' AS Grp03,"
                    End If
                    If pTable.Rows(0)!Grp04 <> "" Then
                        SQLStr = SQLStr & " isnull(" & pTable.Rows(0)!Grp04 & ",'') AS Grp04,"
                    Else
                        SQLStr = SQLStr & " '' AS Grp04,"
                    End If
                    If pTable.Rows(0)!Grp05 <> "" Then
                        SQLStr = SQLStr & " isnull(" & pTable.Rows(0)!Grp05 & ",'') AS Grp05,"
                    Else
                        SQLStr = SQLStr & " '' AS Grp05,"
                    End If
                End If
            End If

            If SQLStr = "" Then
                ResetForm()
                Mesaj.Text = "Ayar bilgileri alınamadı!"
                BYazdir.Visible = False
                Label2.Visible = False
                Label3.Visible = False
                Exit Sub
            End If

            SQLStr = SQLStr & "isnull(PerTipi,0) AS PerTipi, isnull(Yiliz,0) AS Yiliz, isnull(Aktif,0) Aktif,isnull(Per_grp2,0) AS Per_grp2  FROM BoschPertab WHERE Per_PersNr=@SicilNo"
            Dim mTable As DataTable = RSql.GetValue(SQLStr, {New SqlParameter("@Bastar", Now.Date), New SqlParameter("@Bittar", Now.Date), New SqlParameter("@Sicilno", SicilNo.Text)})

            If Not mTable Is Nothing Then
                If mTable.Rows.Count > 0 Then
                    If mTable.Rows(0)!Aktif = 0 Then
                        ResetForm()
                        Mesaj.Text = "Personel pasif! İzin planlaması yapılamaz!"
                        BYazdir.Visible = False
                        Label2.Visible = False
                        Label3.Visible = False
                        Exit Sub
                    End If

                    'Sicil no yazıldıktan sonra tuşa basıldığında sadece boschpertab taki Per_grp2 Yonetici parametresinde belirtilenler girebilecek
                    Dim _Per_grp2() = ConfigurationManager.AppSettings("Per_grp2").Split(",")
                    Dim _izinok = ""
                    For Each _kontrol As String In _Per_grp2
                        If _kontrol = mTable.Rows(0)!Per_grp2.ToString() Then
                            _izinok = "1"
                            Exit For
                        End If
                    Next

                    If _izinok = "" Then
                        ResetForm()
                        Mesaj.Text = "Bu sistemden sadece saat ücretli çalışanlar için talep oluşturulabilir"
                        BYazdir.Visible = False
                        Label2.Visible = False
                        Label3.Visible = False
                        Exit Sub
                    End If

                    If mTable.Rows(0)!Pertipi = 0 Then
                        ResetForm()
                        Mesaj.Text = "Talep oluşturma yetkiniz yok! İzin planlaması yapılamaz!"
                        BYazdir.Visible = False
                        Label2.Visible = False
                        Label3.Visible = False
                        Exit Sub
                    End If

                    Dim i As Integer = 0
                    Dim Gun As Integer = 0
                    Dim Satir As DataRow = mTable.Rows(0)
                    Dim MaasTipi As Integer = 0

                    Dim vBastar As Date = Now.Date
                    Dim vBittar As Date = Now.Date
                    Dim BasBTar As Date = Now.Date
                    Dim BasETar As Date = Now.Date
                    Dim BitBTar As Date = Now.Date
                    Dim BitETar As Date = Now.Date
                    Dim TalepMin As Integer
                    Dim TalepMax As Integer
                    Dim vAvansGun As Integer = 0
                    Dim MaasStr As String = ""
                    Dim GunlukSaat As Decimal = 0

                    Dim Deger As Integer

                    Deger = ConfigurationManager.AppSettings("TalepBas")
                    If Not Deger = Nothing Then
                        BasBTar = DateAdd(DateInterval.Day, Deger, Now.Date)
                        BitBTar = BasBTar
                    End If
                    Deger = ConfigurationManager.AppSettings("TalepBit")
                    If Not Deger = Nothing Then
                        BasETar = DateAdd(DateInterval.Day, Deger, Now.Date)
                    End If
                    Deger = ConfigurationManager.AppSettings("TalepSon")
                    If Not Deger = Nothing Then
                        BitETar = DateAdd(DateInterval.Day, Deger, Now.Date)
                    End If
                    TalepMin = ConfigurationManager.AppSettings("TalepMin")
                    If TalepMin = Nothing Then
                        TalepMin = 1
                    Else
                        vBittar = DateAdd(DateInterval.Day, TalepMin, vBastar)
                    End If

                    TalepMax = ConfigurationManager.AppSettings("TalepMax")
                    If TalepMax = Nothing Then TalepMax = 20

                    MaasStr = ConfigurationManager.AppSettings("Saatlik")
                    If Not MaasStr = Nothing Then
                        MaasStr = "," & MaasStr & ","
                        If InStr(MaasStr, "," & Satir!Grp02 & ",") > 0 Then
                            MaasTipi = 1
                        End If
                    End If

                    MaasStr = ConfigurationManager.AppSettings("Aylik")
                    If Not MaasStr = Nothing Then
                        MaasStr = "," & MaasStr & ","
                        If InStr(MaasStr, "," & Satir!Grp02 & ",") > 0 Then
                            MaasTipi = 2
                        End If
                    End If

                    MaasStr = ConfigurationManager.AppSettings("Yonetici")
                    If Not MaasStr = Nothing Then
                        MaasStr = "," & MaasStr & ","
                        If InStr(MaasStr, "," & Satir!Grp02 & ",") > 0 Then
                            MaasTipi = 3
                        End If
                    End If

                    MaasTip.Value = MaasTipi
                    CalGun.Value = mTable.Rows(0)!PerTipi
                    Yiliz.Value = Int(mTable.Rows(0)!Yiliz)

                    BasTar.SelectedDate = vBastar
                    BitTar.SelectedDate = vBittar
                    BasTar.MinDate = BasBTar
                    BasTar.MaxDate = BasETar
                    BitTar.MinDate = BitBTar
                    BitTar.MaxDate = BitETar

                    RGrup0.Text = pTable.Rows(0)!GrpName00
                    RGrup1.Text = pTable.Rows(0)!GrpName01
                    RGrup2.Text = pTable.Rows(0)!GrpName02
                    RGrup3.Text = pTable.Rows(0)!GrpName03
                    RGrup4.Text = pTable.Rows(0)!GrpName04
                    TGrup0.Text = Satir!Grp00
                    TGrup1.Text = Satir!Grp01
                    TGrup2.Text = Satir!Grp02
                    TGrup3.Text = Satir!Grp03
                    TGrup4.Text = Satir!Grp04
                    TKisim.Text = Satir!Grp05

                    TAdSoyad.Text = Satir!AdSoyad

                    Dim Mazlist As String = ConfigurationManager.AppSettings("TalepIzin")
                    Tipi.Items.Clear()

                    If Mazlist IsNot Nothing Then
                        Mazlist = Mazlist.Replace(" ", "")
                        Mazlist = Mazlist.Replace("'", "")
                        Mazlist = Mazlist.Replace("-", "")
                        Dim Mazeretler() As String = Mazlist.Split(",")
                        For Each Mazeret As String In Mazeretler
                            Tipi.Items.Add(New Telerik.Web.UI.RadComboBoxItem With {.Text = Mazeret})
                        Next
                    End If

                    Hesapla()
                Else
                    ResetForm()
                    Mesaj.Text = "Personel bilgisi bulunamadı!"
                End If
            Else
                ResetForm()
                Mesaj.Text = "Personel bilgisi bulunamadı!"
            End If
            RSql.ConnDbClose()
        End If
    End Sub

    Protected Sub Yenile_Click(sender As Object, e As EventArgs) Handles BYenile.Click
        RefreshData()
    End Sub

    Private Sub ResetForm()
        avans.Checked = False
        avans.Visible = False
        RadLabel2.Visible = False

        BYazdir.Visible = True
        Label2.Visible = True
        Label3.Visible = True
        Mesaj.Text = ""
        SicilNo.Value = 0
        SicilNo.ReadOnly = False
        Mesaj.Text = ""
        TAdSoyad.Text = ""
        TGrup0.Text = ""
        TGrup1.Text = ""
        TGrup2.Text = ""
        TGrup3.Text = ""
        TGrup4.Text = ""
        TKisim.Text = ""
        ITarih.Text = ""
        avans.Checked = False
        avans.Visible = False
        BasTar.SelectedDate = Now.Date
        BitTar.SelectedDate = Now.Date
        TSure.Text = ""
        Tipi.SelectedIndex = 0
        TAciklama.Text = ""

        BYenile.Visible = True

        BTemizle.Visible = False
        BYazdir.Visible = False
        Label2.Visible = False
        Label3.Visible = False

        Mesaj.Text = ""
        TAdSoyad.Visible = False
        TGrup0.Visible = False
        TGrup1.Visible = False
        TGrup2.Visible = False
        TGrup3.Visible = False
        TGrup4.Visible = False
        TKisim.Visible = False

        BasTar.Visible = False
        BitTar.Visible = False
        TSure.Visible = False
        Tipi.Visible = False
        TAciklama.Visible = False

        RAdSoyad.Visible = False
        RGrup0.Visible = False
        RGrup1.Visible = False
        RGrup2.Visible = False
        RGrup3.Visible = False
        RGrup4.Visible = False
        RKisim.Visible = False

        RBasTar.Visible = False
        RBitTar.Visible = False
        RSure.Visible = False
        RTipi.Visible = False
        RGun.Visible = False
        RAciklama.Visible = False

        RadLabel1.Visible = False
        rizintipi.Visible = False
    End Sub

    Private Sub Temizle_Click(sender As Object, e As EventArgs) Handles BTemizle.Click
        ResetForm()
    End Sub

    Private Sub BasTar_SelectedDateChanged(sender As Object, e As SelectedDateChangedEventArgs) Handles BasTar.SelectedDateChanged
        Hesapla()
        Select Case rizintipi.SelectedIndex
            Case 1, 2
                BitTar.Enabled = False
                BitTar.SelectedDate = BasTar.SelectedDate
            Case 0
                BitTar.Enabled = True
        End Select
    End Sub

    Private Sub BitTar_SelectedDateChanged(sender As Object, e As SelectedDateChangedEventArgs) Handles BitTar.SelectedDateChanged
        Hesapla()
    End Sub

    Private Sub Yazdir_Click(sender As Object, e As EventArgs) Handles BYazdir.Click
        Dim _sr As Double = 0.0
        Dim RSql As New SqlForConnection
        Dim _yapilan = ""
        Mesaj.Text = ""
        _sr = TSure.Text

        If _sr = 0 Then
            Mesaj.Text = "Süre=0 olamaz! Lütfen tarih aralığını kontrol edin!"
            Exit Sub
        End If

        If (rizintipi.SelectedIndex = 1 Or rizintipi.SelectedIndex = 2) And DateDiff(DateInterval.Day, BasTar.SelectedDate.Value, BitTar.SelectedDate.Value, Microsoft.VisualBasic.FirstDayOfWeek.Monday) >= 1 Then
            Mesaj.Text = "Seçilen tarihler ayni olmalı"
            Exit Sub
        End If

        If BasTar.SelectedDate > BitTar.SelectedDate Then
            Mesaj.Text = "Başlangıç tarihi bitiş tarihinden büyük olamaz."
            'BasTar.SelectedDate = Now.Date
            Return
        End If

        '29.06.2021	ileriye dönük talep yapılabilmeli. parametrik olmalı
        If ConfigurationManager.AppSettings("TalepBit") < DateDiff(DateInterval.Day, BitTar.SelectedDate.Value, Now.Date, Microsoft.VisualBasic.FirstDayOfWeek.Monday) Then
            Mesaj.Text = "Talep süresi en fazla " & ConfigurationManager.AppSettings("TalepBit") & " olabilir."
            BasTar.SelectedDate = Now.Date
            Return
        End If

        '29.06.2021	Geçmiş aylara yıllık izin talebi yapılamamalı, en fazla içinde bulunduğumuz ayın ilk gününden itibaren yapılabilmeli
        If BasTar.SelectedDate.Value.Date < CDate("01." & Now.Date.Month & "." & Now.Date.Year) Then
            Mesaj.Text = "Geçmiş aylara ait izin talebi yapılamaz."
            'BasTar.SelectedDate = Now.Date
            Return
        End If

        'Sicil, İzne çıkış tarihi, İşe başlama tarihi ve süre db de aynı kayıttan var ise ve reddedilmemiş ise “Bu talep daha önceden oluşturulmuştur. “ diyecek ve kaydetmeyecektir. Reddedilmiş ise kayıt yapabilir 
        Dim _querykontrol = " SELECT * FROM BoschOnay WHERE Sicilno=@Sicilno AND Bastar=@Bastar AND Bittar=@Bittar AND Sure=@Sure AND  Durumu in(0,1) "
        Dim kontrolParametre(3) As SqlParameter
        kontrolParametre(0) = New SqlParameter("@SicilNo", SicilNo.Text)
        kontrolParametre(1) = New SqlParameter("@BasTar", BasTar.SelectedDate)
        kontrolParametre(2) = New SqlParameter("@BitTar", BitTar.SelectedDate)
        kontrolParametre(3) = New SqlParameter("@Sure", _sr)
        If RSql.GetValue(_querykontrol, kontrolParametre).Rows.Count > 0 Then
            Mesaj.Text = "Bu talep daha önceden oluşturulmuştur"
            Return
        End If

        Dim zParametre(16) As SqlParameter
        zParametre(0) = New SqlParameter("@SicilNo", SicilNo.Text)
        zParametre(1) = New SqlParameter("@Tarih", Now.Date)
        zParametre(2) = New SqlParameter("@BasTar", BasTar.SelectedDate)
        zParametre(3) = New SqlParameter("@BitTar", BitTar.SelectedDate)
        zParametre(4) = New SqlParameter("@Tipi", 0)
        zParametre(5) = New SqlParameter("@Kodu", Tipi.SelectedItem.Text)
        zParametre(6) = New SqlParameter("@KUserId", "TALEP")
        zParametre(7) = New SqlParameter("@Aciklama", TAciklama.Text)
        zParametre(8) = New SqlParameter("@Sure", _sr)
        zParametre(9) = New SqlParameter("@GSure", 0)
        zParametre(10) = New SqlParameter("@AvansOk", IIf(avans.Checked, 1, 0))
        zParametre(11) = New SqlParameter("@Vekil", "")
        zParametre(12) = New SqlParameter("@VekilKisim", "")
        zParametre(13) = New SqlParameter("@MaasTipi", MaasTip.Value)
        zParametre(14) = New SqlParameter("@Kisim", TKisim.Text)
        zParametre(15) = New SqlParameter("@GTipi", rizintipi.SelectedValue)
        zParametre(16) = New SqlParameter("@TUserid", HttpContext.Current.User.Identity.Name)

        KayitNdx.Value = RSql.ScalarSQL("INSERT INTO BoschOnay (Sicilno, Tarih, Bastar, Bittar, Tipi, Kodu, Durumu, KUserid, KUDate, Aciklama, Sure, GSure, AvansOk, Vekil, VekilKisim, MaasTipi, Kisim, GTipi,TUserid,TUDate) VALUES (@Sicilno, @Tarih, @Bastar, @Bittar, @Tipi, @Kodu, 0, @KUserId, GETDATE(), @Aciklama, @Sure, @GSure, @AvansOk, @Vekil, @VekilKisim, @MaasTipi, @Kisim, @GTipi,@TUserid,GETDATE()); SELECT SCOPE_IDENTITY() AS SIRANO", zParametre)

        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "Talep", "alert('Talebiniz onaya gönderilmiştir. Onay durumunu Mytime sistemindeki yıllık izin talep raporundan takip edebilirsiniz');", True)

        'Dim deviceInfo As New Hashtable()
        'deviceInfo("JavaScript") = "this.print({bUI: true, bSilent: false, bShrinkToFit: true});"
        'Dim ReportProcessor As New ReportProcessor()
        'Dim reportSource As New Telerik.Reporting.InstanceReportSource()

        'Dim renderingResult = ReportProcessor.RenderReport("PDF", reportSource, deviceInfo)


        '04.08.2021 tarihinde kaldırıldı. Mail(RE: Bosch onay istek-1 revize1)
        'Dim MyReport As New RBosch_MForm01
        'MyReport.ReportParameters("Ndx").Value = KayitNdx.Value
        'MyReport.SqlDataSource1.ConnectionString = CnvSQLString(ConfigurationManager.ConnectionStrings("SQLDirect").ConnectionString)
        'Dim InsReports As New Telerik.Reporting.InstanceReportSource
        'InsReports.ReportDocument = MyReport
        'RaporGoster.ReportSource = InsReports
        'RaporGoster.RefreshReport()

        'Response.Clear()
        'Response.ContentType = renderingResult.MimeType
        'Response.Cache.SetCacheability(HttpCacheability.Private)
        'Response.Expires = -1
        'Response.Buffer = True
        'Response.BinaryWrite(renderingResult.DocumentBytes)
        'Response.End() 
        MainPage.Visible = True
        ResetForm()
        'PrintPage.Visible = True
    End Sub

    Private Sub Hesapla()
        Mesaj.Text = ""

        If BasTar.SelectedDate > BitTar.SelectedDate Then
            Mesaj.Text = "Başlangıç tarihi bitiş tarihinden büyük olamaz."
            'BasTar.SelectedDate = Now.Date
            Return
        End If

        If BasTar.SelectedDate Is Nothing Then
            BYazdir.Visible = False
            Label2.Visible = False
            Label3.Visible = False
            Exit Sub
        End If
        If BitTar.SelectedDate Is Nothing Then
            BYazdir.Visible = False
            Label2.Visible = False
            Label3.Visible = False
            Exit Sub
        End If

        If (rizintipi.SelectedIndex = 1 Or rizintipi.SelectedIndex = 2) And DateDiff(DateInterval.Day, BasTar.SelectedDate.Value, BitTar.SelectedDate.Value, Microsoft.VisualBasic.FirstDayOfWeek.Monday) >= 1 Then
            Mesaj.Text = "Seçilen tarihler aynı olmalı"
            BYazdir.Visible = False
            Label2.Visible = False
            Label3.Visible = False
            Exit Sub
        End If

        If (rizintipi.SelectedIndex = 1 Or rizintipi.SelectedIndex = 2) Then
            TSure.Text = "0,5"
        End If

        '29.06.2021	ileriye dönük talep yapılabilmeli. parametrik olmalı
        If ConfigurationManager.AppSettings("TalepBit") < DateDiff(DateInterval.Day, BitTar.SelectedDate.Value, Now.Date, Microsoft.VisualBasic.FirstDayOfWeek.Monday) Then
            Mesaj.Text = "Talep süresi en fazla " & ConfigurationManager.AppSettings("TalepBit") & " olabilir."
            'BasTar.SelectedDate = Now.Date
            BYazdir.Visible = False
            Label2.Visible = False
            Label3.Visible = False
            Return
        End If

        '29.06.2021	Geçmiş aylara yıllık izin talebi yapılamamalı, en fazla içinde bulunduğumuz ayın ilk gününden itibaren yapılabilmeli
        If BasTar.SelectedDate.Value.Date < CDate("01." & Now.Date.Month & "." & Now.Date.Year) Then
            Mesaj.Text = "Geçmiş aylara ait izin talebi yapılamaz."
            'BasTar.SelectedDate = Now.Date
            BYazdir.Visible = False
            Label2.Visible = False
            Label3.Visible = False
            Return
        End If

        Dim Tar1 As Date = BasTar.SelectedDate
        Dim Tar2 As Date = BitTar.SelectedDate
        Dim MTarih As Date = Now.Date
        Dim MSure As Integer = 0
        Dim HSure As Integer = 0
        Dim Bulundu As Boolean = False
        MSure = DateDiff(DateInterval.Day, Tar1, Tar2)
        If MSure > 0 Then
            Dim RSQL As New SqlForConnection
            Dim mTable As New DataTable
            For i As Integer = 0 To MSure - 1
                MTarih = DateAdd(DateInterval.Day, i, Tar1)
                If CalGun.Value = 6 Then
                    If Weekday(MTarih, Microsoft.VisualBasic.FirstDayOfWeek.Monday) >= 7 Then
                        Continue For
                    End If
                End If
                If CalGun.Value = 5 Then
                    If Weekday(MTarih, Microsoft.VisualBasic.FirstDayOfWeek.Monday) >= 6 Then
                        Continue For
                    End If
                End If
                mTable = RSQL.GetValue("SELECT IdNr FROM BoschTatil WHERE Fei_Monat=MONTH(@Tarih) AND Fei_Tag=DAY(@Tarih) AND (Fei_Jahr=0 OR Fei_Jahr>=YEAR(@Tarih))", {New SqlParameter("@Tarih", MTarih)})
                If mTable.Rows.Count > 0 Then
                    Continue For
                End If
                HSure = HSure + 1
            Next
            RSQL.ConnDbClose()
        End If

        'If Yiliz.Value < HSure Then
        '    Mesaj.Text = "'" & Yiliz.Value & "' günden fazla izin talebinde bulunamazsınız!"
        '    TSure.Text = 0
        'Else

        BYazdir.Visible = True
        Label2.Visible = True
        Label3.Visible = True

        '29.06.2021 Yıllık izin talebinde talep edilen gün sayısı, haftalık çalışma gününe eşit veya büyükse avans talebi yapılabilmeli
        If CalGun.Value <= MSure Then
            avans.Visible = True
            RadLabel2.Visible = True
        Else
            avans.Checked = False
            avans.Visible = False
            RadLabel2.Visible = False
        End If

        TSure.Text = HSure
        Mesaj.Text = ""
    End Sub

    'Private Sub Geri_Click(sender As Object, e As ImageClickEventArgs) Handles Geri.Click
    '    'PrintPage.Visible = False
    '    MainPage.Visible = True
    '    ResetForm()
    'End Sub

    'Private Sub RaporGoster_PreRender(sender As Object, e As EventArgs) Handles RaporGoster.PreRender
    '    Dim MyReport As New RBosch_MForm01
    '    MyReport.ReportParameters("Ndx").Value = KayitNdx.Value
    '    MyReport.SqlDataSource1.ConnectionString = CnvSQLString(ConfigurationManager.ConnectionStrings("SQLDirect").ConnectionString)
    '    Dim InsReports As New Telerik.Reporting.InstanceReportSource
    '    InsReports.ReportDocument = MyReport
    '    RaporGoster.ReportSource = InsReports
    '    RaporGoster.RefreshReport()
    'End Sub

    Protected Sub rizintipi_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles rizintipi.SelectedIndexChanged
        Mesaj.Text = ""
        Tipi.SelectedIndex = rizintipi.SelectedIndex
        Select Case rizintipi.SelectedIndex
            Case 1, 2
                BitTar.Enabled = False
                BitTar.SelectedDate = BasTar.SelectedDate
                TSure.Text = "0,5"
            Case 0
                BitTar.Enabled = True
                TSure.Text = "1"
        End Select
        Hesapla()
    End Sub
End Class