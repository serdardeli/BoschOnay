Imports System.Data
Imports System.Web.UI
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Data.Common

Public Class TSSTalep
    Inherits System.Web.UI.Page

    Dim BarCode As Long = 0

    Protected Sub Kaydet_Click(sender As Object, e As UI.ImageClickEventArgs) Handles Kaydet.Click
        Mesaj.Text = ""
        Dim Tipi As Integer = 0
        If SicilNo.Text = "" Or KimlikNo.Text = "" Or TelNo.Text = "" Or PAdi.Text = "" Or PSoyadi.Text = "" Then
            Mesaj.Text = "İşaretli alanların girilmesi zorunludur!"
            Exit Sub
        End If

        If Not (EsKimlikNo.Text <> "" And EsAdi.Text <> "" And EsSoyadi.Text <> "") And (EsKimlikNo.Text & EsAdi.Text & EsSoyadi.Text) <> "" Then
            Mesaj.Text = "Eş bilgisini tam giriniz."
            Exit Sub
        End If

        If Not (CKimlik0.Text <> "" And CAdi0.Text <> "" And CSoyadi0.Text <> "") And (CKimlik0.Text & CAdi0.Text & CSoyadi0.Text) <> "" Then
            Mesaj.Text = "1. Çocuk bilgisini tam giriniz."
            Exit Sub
        End If

        If Not (CKimlik1.Text <> "" And CAdi1.Text <> "" And CSoyadi1.Text <> "") And (CKimlik1.Text & CAdi1.Text & CSoyadi1.Text) <> "" Then
            Mesaj.Text = "2. Çocuk bilgisini tam giriniz."
            Exit Sub
        End If

        If Not (CKimlik2.Text <> "" And CAdi2.Text <> "" And CSoyadi2.Text <> "") And (CKimlik2.Text & CAdi2.Text & CSoyadi2.Text) <> "" Then
            Mesaj.Text = "3. Çocuk bilgisini tam giriniz."
            Exit Sub
        End If

        If Not (CKimlik3.Text <> "" And CAdi3.Text <> "" And CSoyadi3.Text <> "") And (CKimlik3.Text & CAdi3.Text & CSoyadi3.Text) <> "" Then
            Mesaj.Text = "4. Çocuk bilgisini tam giriniz."
            Exit Sub
        End If

        If Not (CKimlik4.Text <> "" And CAdi4.Text <> "" And CSoyadi4.Text <> "") And (CKimlik4.Text & CAdi4.Text & CSoyadi4.Text) <> "" Then
            Mesaj.Text = "5. Çocuk bilgisini tam giriniz."
            Exit Sub
        End If

        If Not (CKimlik5.Text <> "" And CAdi5.Text <> "" And CSoyadi5.Text <> "") And (CKimlik5.Text & CAdi5.Text & CSoyadi5.Text) <> "" Then
            Mesaj.Text = "6. Çocuk bilgisini tam giriniz."
            Exit Sub
        End If

        If Not (CKimlik6.Text <> "" And CAdi6.Text <> "" And CSoyadi6.Text <> "") And (CKimlik6.Text & CAdi6.Text & CSoyadi6.Text) <> "" Then
            Mesaj.Text = "7. Çocuk bilgisini tam giriniz."
            Exit Sub
        End If

        If Not (EsKimlikNo.Text <> "" Or EsAdi.Text <> "" Or EsSoyadi.Text <> "") Then
            If Not (CKimlik0.Text <> "" Or CAdi0.Text <> "" Or CSoyadi0.Text <> "") Then
                Mesaj.Text = "Enaz Eş veya Çocuklardan bir tane girilmelidir."
                Exit Sub
            End If
        End If

        Dim vTarih As Date = Now
        Tarih.Text = Format(vTarih, "dd.MM.yyyy HH:mm:ss")
        Try
            Dim vSicilno As Long = CLng(SicilNo.Text)
        Catch ex As Exception
            Mesaj.Text = "Lütfen personel numarasını doğru giriniz!"
            Exit Sub
        End Try
        Dim Barcode As Long = 0L
        Dim mTable As DataTable
        'SqlPersonel.Delete()
        Dim RSQL As New SqlForConnection
        Dim mParam(9) As SqlParameter
        mParam(0) = New SqlParameter("@PSicilNo", SicilNo.Text)
        mParam(1) = New SqlParameter("@PAdi", PAdi.Text)
        mParam(2) = New SqlParameter("@PSoyadi", PSoyadi.Text)
        mParam(3) = New SqlParameter("@KimlikNo", KimlikNo.Text)
        mParam(4) = New SqlParameter("@CepTel", TelNo.Text)

        Dim SQLStr As String = "INSERT INTO BoschSigorta (SicilNo, Adi, Soyadi, KimlikNo, CepTel, Tipi, AAdi, ASoyadi, AKimlikNo, Tarih, ODurum, Barkod) OUTPUT Inserted.IdNr VALUES (@PSicilNo, @PAdi, @PSoyadi, @KimlikNo, @CepTel, @Tipi, @AAdi, @ASoyadi, @AKimlikNo, @Tarih, 2, '0')"
        If EsKimlikNo.Text <> "" Then
            mParam(5) = New SqlParameter("@Tipi", Tipi)
            mParam(6) = New SqlParameter("@AAdi", EsAdi.Text)
            mParam(7) = New SqlParameter("@ASoyadi", EsSoyadi.Text)
            mParam(8) = New SqlParameter("@AKimlikNo", EsKimlikNo.Text)
            mParam(9) = New SqlParameter("@Tarih", vTarih)
            mTable = RSQL.GetValue(SQLStr, mParam)
            If mTable.Rows.Count > 0 Then
                If Barcode = 0 Then
                    Barcode = mTable.Rows(0)!IdNr
                End If
            End If
        End If
        If CKimlik0.Text <> "" Then
            Tipi += 1
            mParam(5) = New SqlParameter("@Tipi", Tipi)
            mParam(6) = New SqlParameter("@AAdi", CAdi0.Text)
            mParam(7) = New SqlParameter("@ASoyadi", CSoyadi0.Text)
            mParam(8) = New SqlParameter("@AKimlikNo", CKimlik0.Text)
            mParam(9) = New SqlParameter("@Tarih", vTarih)
            mTable = RSQL.GetValue(SQLStr, mParam)
            If mTable.Rows.Count > 0 Then
                If Barcode = 0 Then
                    Barcode = mTable.Rows(0)!IdNr
                End If
            End If
        End If
        If CKimlik1.Text <> "" Then
            Tipi += 1
            mParam(5) = New SqlParameter("@Tipi", Tipi)
            mParam(6) = New SqlParameter("@AAdi", CAdi1.Text)
            mParam(7) = New SqlParameter("@ASoyadi", CSoyadi1.Text)
            mParam(8) = New SqlParameter("@AKimlikNo", CKimlik1.Text)
            mParam(9) = New SqlParameter("@Tarih", vTarih)
            mTable = RSQL.GetValue(SQLStr, mParam)
            If mTable.Rows.Count > 0 Then
                If Barcode = 0 Then
                    Barcode = mTable.Rows(0)!IdNr
                End If
            End If
        End If
        If CKimlik2.Text <> "" Then
            Tipi += 1
            mParam(5) = New SqlParameter("@Tipi", Tipi)
            mParam(6) = New SqlParameter("@AAdi", CAdi2.Text)
            mParam(7) = New SqlParameter("@ASoyadi", CSoyadi2.Text)
            mParam(8) = New SqlParameter("@AKimlikNo", CKimlik2.Text)
            mParam(9) = New SqlParameter("@Tarih", vTarih)
            mTable = RSQL.GetValue(SQLStr, mParam)
            If mTable.Rows.Count > 0 Then
                If Barcode = 0 Then
                    Barcode = mTable.Rows(0)!IdNr
                End If
            End If
        End If
        If CKimlik3.Text <> "" Then
            Tipi += 1
            mParam(5) = New SqlParameter("@Tipi", Tipi)
            mParam(6) = New SqlParameter("@AAdi", CAdi3.Text)
            mParam(7) = New SqlParameter("@ASoyadi", CSoyadi3.Text)
            mParam(8) = New SqlParameter("@AKimlikNo", CKimlik3.Text)
            mParam(9) = New SqlParameter("@Tarih", vTarih)
            mTable = RSQL.GetValue(SQLStr, mParam)
            If mTable.Rows.Count > 0 Then
                If Barcode = 0 Then
                    Barcode = mTable.Rows(0)!IdNr
                End If
            End If
        End If
        If CKimlik4.Text <> "" Then
            Tipi += 1
            mParam(5) = New SqlParameter("@Tipi", Tipi)
            mParam(6) = New SqlParameter("@AAdi", CAdi4.Text)
            mParam(7) = New SqlParameter("@ASoyadi", CSoyadi4.Text)
            mParam(8) = New SqlParameter("@AKimlikNo", CKimlik4.Text)
            mParam(9) = New SqlParameter("@Tarih", vTarih)
            mTable = RSQL.GetValue(SQLStr, mParam)
            If mTable.Rows.Count > 0 Then
                If Barcode = 0 Then
                    Barcode = mTable.Rows(0)!IdNr
                End If
            End If
        End If
        If CKimlik5.Text <> "" Then
            Tipi += 1
            mParam(5) = New SqlParameter("@Tipi", Tipi)
            mParam(6) = New SqlParameter("@AAdi", CAdi5.Text)
            mParam(7) = New SqlParameter("@ASoyadi", CSoyadi5.Text)
            mParam(8) = New SqlParameter("@AKimlikNo", CKimlik5.Text)
            mParam(9) = New SqlParameter("@Tarih", vTarih)
            mTable = RSQL.GetValue(SQLStr, mParam)
            If mTable.Rows.Count > 0 Then
                If Barcode = 0 Then
                    Barcode = mTable.Rows(0)!IdNr
                End If
            End If
        End If
        If CKimlik6.Text <> "" Then
            Tipi += 1
            mParam(5) = New SqlParameter("@Tipi", Tipi)
            mParam(6) = New SqlParameter("@AAdi", CAdi6.Text)
            mParam(7) = New SqlParameter("@ASoyadi", CSoyadi6.Text)
            mParam(8) = New SqlParameter("@AKimlikNo", CKimlik6.Text)
            mParam(9) = New SqlParameter("@Tarih", vTarih)
            mTable = RSQL.GetValue(SQLStr, mParam)
            If mTable.Rows.Count > 0 Then
                If Barcode = 0 Then
                    Barcode = mTable.Rows(0)!IdNr
                End If
            End If
        End If
        'If CKimlik7.Text <> "" Or CAdi7.Text <> "" Or CSoyadi7.Text <> "" Then
        '    Tipi += 1
        '    SqlPersonel.InsertParameters("Tipi").DefaultValue = Tipi
        '    SqlPersonel.InsertParameters("AAdi").DefaultValue = CAdi7.Text
        '    SqlPersonel.InsertParameters("ASoyadi").DefaultValue = CSoyadi7.Text
        '    SqlPersonel.InsertParameters("AKimlikNo").DefaultValue = CKimlik7.Text
        '    SqlPersonel.InsertParameters("Tarih").DefaultValue = vTarih
        '    SqlPersonel.Insert()
        '    Kaydedildi = True
        'End If
        'If CKimlik8.Text <> "" Or CAdi8.Text <> "" Or CSoyadi8.Text <> "" Then
        '    Tipi += 1
        '    SqlPersonel.InsertParameters("Tipi").DefaultValue = Tipi
        '    SqlPersonel.InsertParameters("AAdi").DefaultValue = CAdi8.Text
        '    SqlPersonel.InsertParameters("ASoyadi").DefaultValue = CSoyadi8.Text
        '    SqlPersonel.InsertParameters("AKimlikNo").DefaultValue = CKimlik8.Text
        '    SqlPersonel.InsertParameters("Tarih").DefaultValue = vTarih
        '    SqlPersonel.Insert()C:\Users\Zeki GÜLTEKİN\OneDrive - Erben Kontrol Sistemleri A.Ş\Erben.2018\progs.net20\BoschOnay\BoschOnay\AGIFormu.aspx
        '    Kaydedildi = True
        'End If
        If Barcode > 0 Then
            Mesaj.Text = "Bilgiler kaydedildi! Yazdırabilirsiniz..."
            RadBarcode1.Text = "3" & Format(Barcode, "00000000000")
            RSQL.RunSQL("UPDATE BoschSigorta SET Barkod=@Barkod WHERE Sicilno=@PSicilNo AND Barkod='0' AND Tarih=@Tarih", {New SqlParameter("@PSicilNo", SicilNo.Text), New SqlParameter("@Barkod", RadBarcode1.Text & CheckSum(RadBarcode1.Text)), New SqlParameter("@Tarih", vTarih)})
            RadBarcode1.Visible = True
            Kaydet.Visible = False
            Yazdir.Visible = True
            LKaydet.Visible = False
            LYazdir.Visible = True
            SicilNo.ReadOnly = True
            KimlikNo.ReadOnly = True
            TelNo.ReadOnly = True
            PAdi.ReadOnly = True
            PSoyadi.ReadOnly = True
            EsAdi.ReadOnly = True
            EsSoyadi.ReadOnly = True
            EsKimlikNo.ReadOnly = True
            CKimlik0.ReadOnly = True
            CKimlik1.ReadOnly = True
            CKimlik2.ReadOnly = True
            CKimlik3.ReadOnly = True
            CKimlik4.ReadOnly = True
            CKimlik5.ReadOnly = True
            CKimlik6.ReadOnly = True
            'CKimlik7.Readonly = true
            'CKimlik8.Readonly = true
            CAdi0.ReadOnly = True
            CAdi1.ReadOnly = True
            CAdi2.ReadOnly = True
            CAdi3.ReadOnly = True
            CAdi4.ReadOnly = True
            CAdi5.ReadOnly = True
            CAdi6.ReadOnly = True
            'CAdi7.Readonly = true
            'CAdi8.Readonly = true
            CSoyadi0.ReadOnly = True
            CSoyadi1.ReadOnly = True
            CSoyadi2.ReadOnly = True
            CSoyadi3.ReadOnly = True
            CSoyadi4.ReadOnly = True
            CSoyadi5.ReadOnly = True
            CSoyadi6.ReadOnly = True
            'CSoyadi7.Readonly = true
            'CSoyadi8.Readonly = true
        Else
            Mesaj.Text = "HATA : Bilgiler kaydedilemedi!"
        End If
    End Sub

    Protected Sub Temizle_Click(sender As Object, e As UI.ImageClickEventArgs) Handles Temizle.Click
        SicilNo.Text = ""
        KimlikNo.Text = ""
        TelNo.Text = ""
        PAdi.Text = ""
        PSoyadi.Text = ""
        EsAdi.Text = ""
        EsSoyadi.Text = ""
        EsKimlikNo.Text = ""
        CKimlik0.Text = ""
        CKimlik1.Text = ""
        CKimlik2.Text = ""
        CKimlik3.Text = ""
        CKimlik4.Text = ""
        CKimlik5.Text = ""
        CKimlik6.Text = ""
        'CKimlik7.Text = ""
        'CKimlik8.Text = ""
        CAdi0.Text = ""
        CAdi1.Text = ""
        CAdi2.Text = ""
        CAdi3.Text = ""
        CAdi4.Text = ""
        CAdi5.Text = ""
        CAdi6.Text = ""
        'CAdi7.Text = ""
        'CAdi8.Text = ""
        CSoyadi0.Text = ""
        CSoyadi1.Text = ""
        CSoyadi2.Text = ""
        CSoyadi3.Text = ""
        CSoyadi4.Text = ""
        CSoyadi5.Text = ""
        CSoyadi6.Text = ""
        'CSoyadi7.Text = ""
        'CSoyadi8.Text = ""
        SicilNo.ReadOnly = False
        KimlikNo.ReadOnly = False
        TelNo.ReadOnly = False
        PAdi.ReadOnly = False
        PSoyadi.ReadOnly = False
        EsAdi.ReadOnly = False
        EsSoyadi.ReadOnly = False
        EsKimlikNo.ReadOnly = False
        CKimlik0.ReadOnly = False
        CKimlik1.ReadOnly = False
        CKimlik2.ReadOnly = False
        CKimlik3.ReadOnly = False
        CKimlik4.ReadOnly = False
        CKimlik5.ReadOnly = False
        CKimlik6.ReadOnly = False
        'CKimlik7.Readonly = false
        'CKimlik8.Readonly = false
        CAdi0.ReadOnly = False
        CAdi1.ReadOnly = False
        CAdi2.ReadOnly = False
        CAdi3.ReadOnly = False
        CAdi4.ReadOnly = False
        CAdi5.ReadOnly = False
        CAdi6.ReadOnly = False
        'CAdi7.Readonly = false
        'CAdi8.Readonly = false
        CSoyadi0.ReadOnly = False
        CSoyadi1.ReadOnly = False
        CSoyadi2.ReadOnly = False
        CSoyadi3.ReadOnly = False
        CSoyadi4.ReadOnly = False
        CSoyadi5.ReadOnly = False
        CSoyadi6.ReadOnly = False
        'CSoyadi7.Readonly = false
        'CSoyadi8.Readonly = false
        Mesaj.Text = ""
        Kaydet.Visible = True
        Yazdir.Visible = False
        LKaydet.Visible = True
        LYazdir.Visible = False
        RadBarcode1.Visible = False
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
End Class