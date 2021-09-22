Public Class FParametre
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            BBaslik.Text = Request("Baslik")

            Dim Renkler As Array = [Enum].GetValues(GetType(KnownColors))
            Array.Sort(Renkler)

            For Each Renk As KnownColors In Renkler
                bCmtRenk.Items.Add(New ListItem(Renk.ToString(), Renk.ToString()))
                bPazRenk.Items.Add(New ListItem(Renk.ToString(), Renk.ToString()))
                bRestaRenk.Items.Add(New ListItem(Renk.ToString(), Renk.ToString()))
                bOnayRenk.Items.Add(New ListItem(Renk.ToString(), Renk.ToString()))
                bGecmisRenk.Items.Add(New ListItem(Renk.ToString(), Renk.ToString()))
                bKilitRenk.Items.Add(New ListItem(Renk.ToString(), Renk.ToString()))
                bPsizFMRenk.Items.Add(New ListItem(Renk.ToString(), Renk.ToString()))
            Next

            Dim RSQL As New SqlForConnection
            Dim SQLStr As String = "SELECT TOP 1 isnull(Firma,'') AS Firma, isnull(Lisans,0) AS Lisans, isnull(LoginUser,0) AS LoginUser, isnull(islemGun,0) AS islemGun, isnull(PlanGun,0) AS PlanGun, isnull(OnayGun,0) AS OnayGun, isnull(OnaySekli,0) AS OnaySekli, isnull(Grp00,'') AS Grp00, isnull(Grp01,'') AS Grp01, isnull(Grp02,'') AS Grp02, isnull(Grp03,'') AS Grp03, isnull(Grp04,'') AS Grp04, isnull(Grp05,'') AS Grp05, isnull(Grp06,'') AS Grp06, isnull(Grp07,'') AS Grp07, isnull(Grp08,'') AS Grp08, isnull(Grp09,'') AS Grp09, isnull(Grp10,'') AS Grp10, isnull(Grp11,'') AS  Grp11, isnull(Grp12,'') AS Grp12, isnull(Grp13,'') AS Grp13, isnull(Grp14,'') AS Grp14, isnull(Grp15,'') AS Grp15, isnull(Grp16,'') AS Grp16, isnull(Grp17,'') AS Grp17, isnull(Grp18,'') AS Grp18, isnull(Grp19,'') AS Grp19, isnull(GrpName00,'') AS GrpName00, isnull(GrpName01,'') AS GrpName01, isnull(GrpName02,'') AS GrpName02, isnull(GrpName03,'') AS GrpName03, isnull(GrpName04,'') AS GrpName04, isnull(GrpName05,'') AS GrpName05, isnull(GrpName06,'') AS GrpName06, isnull(GrpName07,'') AS GrpName07, isnull(GrpName08,'') AS GrpName08, isnull(GrpName09,'') AS GrpName09, isnull(GrpName10,'') AS GrpName10, isnull(GrpName11,'') AS  GrpName11, isnull(GrpName12,'') AS GrpName12, isnull(GrpName13,'') AS GrpName13, isnull(GrpName14,'') AS GrpName14, isnull(GrpName15,'') AS GrpName15, isnull(GrpName16,'') AS GrpName16, isnull(GrpName17,'') AS GrpName17, isnull(GrpName18,'') AS GrpName18, isnull(GrpName19,'') AS GrpName19, getdate() AS SunucuTarihi, isnull(MZDilim, 0) AS MZDilim, isnull(FMDilim, 0) AS FMDilim, isnull(MMDilim, 0) AS MMDilim, isnull(CmtRenk,'White') AS CmtRenk, isnull(PazRenk,'White') AS PazRenk, isnull(RestaRenk,'White') AS RestaRenk, isnull(OnayRenk,'White') AS OnayRenk, isnull(GecmisRenk,'White') AS GecmisRenk, isnull(KilitRenk,'White') AS KilitRenk, isnull(PsizFMRenk,'White') AS PsizFMRenk, isnull(Moduller,'') AS Moduller, isnull(FM1,'') AS FM1, isnull(FM2,'') AS FM2, isnull(FM3,'') AS FM3, isnull(ESNEK,'') AS ESNEK, isnull(NCAL,'') AS NCAL, isnull(Puantaj,0) AS Puantaj, isnull(VardiyaSay,'') AS VardiyaSay, isnull(vFM1,'') AS vFM1, isnull(vFM2,'') AS vFM2, isnull(vFM3,'') AS vFM3, isnull(Kilit,5) AS Kilit"
            SQLStr = SQLStr & " FROM BoschLisans"
            Dim mTable As DataTable = RSQL.GetValue(SQLStr)
            If mTable.Rows.Count > 0 Then
                BKaydet.Visible = True
                Firma.Text = mTable.Rows(0)!Firma
                Lisans.Text = mTable.Rows(0)!Lisans
                LoginUser.SelectedIndex = mTable.Rows(0)!LoginUser
                IslemGun.Text = mTable.Rows(0)!islemGun
                PlanGun.Text = mTable.Rows(0)!PlanGun
                VardiyaSay.Text = mTable.Rows(0)!VardiyaSay
                'OnayGun. = mTable.Rows(0)!OnayGun
                'OnaySekli.SelectedIndex = mTable.Rows(0)!OnaySekli
                Puantaj.SelectedIndex = mTable.Rows(0)!Puantaj
                Kilit.Text = mTable.Rows(0)!Kilit
                For i As Integer = 0 To 4
                    Moduller.Items(i).Selected = IIf(Mid(mTable.Rows(0)!Moduller, i + 1, 1) = "0", False, True)
                Next
                'SunucuTarihi = mTable.Rows(0)!SunucuTarihi

                FM1.Text = mTable.Rows(0)!FM1
                FM2.Text = mTable.Rows(0)!FM2
                FM3.Text = mTable.Rows(0)!FM3
                ESNEK.Text = mTable.Rows(0)!ESNEK
                NCAL.Text = mTable.Rows(0)!NCAL
                vFM1.Text = mTable.Rows(0)!vFM1
                vFM2.Text = mTable.Rows(0)!vFM2
                vFM3.Text = mTable.Rows(0)!vFM3
                MZDilim.SelectedIndex = mTable.Rows(0)!MZDilim
                FMDilim.SelectedIndex = mTable.Rows(0)!FMDilim
                MMDilim.SelectedIndex = mTable.Rows(0)!MMDilim

                bCmtRenk.SelectedValue = mTable.Rows(0)!CmtRenk
                bPazRenk.SelectedValue = mTable.Rows(0)!PazRenk
                bRestaRenk.SelectedValue = mTable.Rows(0)!RestaRenk
                bOnayRenk.SelectedValue = mTable.Rows(0)!OnayRenk
                bGecmisRenk.SelectedValue = mTable.Rows(0)!GecmisRenk
                bKilitRenk.SelectedValue = mTable.Rows(0)!KilitRenk
                bPsizFMRenk.SelectedValue = mTable.Rows(0)!PsizFMRenk

                bCmtRenk.BackColor = Drawing.Color.FromName(mTable.Rows(0)!CmtRenk)
                bPazRenk.BackColor = Drawing.Color.FromName(mTable.Rows(0)!PazRenk)
                bRestaRenk.BackColor = Drawing.Color.FromName(mTable.Rows(0)!RestaRenk)
                bOnayRenk.BackColor = Drawing.Color.FromName(mTable.Rows(0)!OnayRenk)
                bGecmisRenk.BackColor = Drawing.Color.FromName(mTable.Rows(0)!GecmisRenk)
                bKilitRenk.BackColor = Drawing.Color.FromName(mTable.Rows(0)!KilitRenk)
                bPsizFMRenk.BackColor = Drawing.Color.FromName(mTable.Rows(0)!PsizFMRenk)

                Grp00.Text = mTable.Rows(0)!Grp00
                Grp01.Text = mTable.Rows(0)!Grp01
                Grp02.Text = mTable.Rows(0)!Grp02
                Grp03.Text = mTable.Rows(0)!Grp03
                Grp04.Text = mTable.Rows(0)!Grp04
                Grp05.Text = mTable.Rows(0)!Grp05
                Grp06.Text = mTable.Rows(0)!Grp06
                Grp07.Text = mTable.Rows(0)!Grp07
                Grp08.Text = mTable.Rows(0)!Grp08
                Grp09.Text = mTable.Rows(0)!Grp09
                Grp10.Text = mTable.Rows(0)!Grp10
                Grp11.Text = mTable.Rows(0)!Grp11
                Grp12.Text = mTable.Rows(0)!Grp12
                Grp13.Text = mTable.Rows(0)!Grp13
                Grp14.Text = mTable.Rows(0)!Grp14
                Grp15.Text = mTable.Rows(0)!Grp15
                Grp16.Text = mTable.Rows(0)!Grp16
                Grp17.Text = mTable.Rows(0)!Grp17
                Grp18.Text = mTable.Rows(0)!Grp18
                Grp19.Text = mTable.Rows(0)!Grp19
                GrpName00.Text = mTable.Rows(0)!GrpName00
                GrpName01.Text = mTable.Rows(0)!GrpName01
                GrpName02.Text = mTable.Rows(0)!GrpName02
                GrpName03.Text = mTable.Rows(0)!GrpName03
                GrpName04.Text = mTable.Rows(0)!GrpName04
                GrpName05.Text = mTable.Rows(0)!GrpName05
                GrpName06.Text = mTable.Rows(0)!GrpName06
                GrpName07.Text = mTable.Rows(0)!GrpName07
                GrpName08.Text = mTable.Rows(0)!GrpName08
                GrpName09.Text = mTable.Rows(0)!GrpName09
                GrpName10.Text = mTable.Rows(0)!GrpName10
                GrpName11.Text = mTable.Rows(0)!GrpName11
                GrpName12.Text = mTable.Rows(0)!GrpName12
                GrpName13.Text = mTable.Rows(0)!GrpName13
                GrpName14.Text = mTable.Rows(0)!GrpName14
                GrpName15.Text = mTable.Rows(0)!GrpName15
                GrpName16.Text = mTable.Rows(0)!GrpName16
                GrpName17.Text = mTable.Rows(0)!GrpName17
                GrpName18.Text = mTable.Rows(0)!GrpName18
                GrpName19.Text = mTable.Rows(0)!GrpName19
            Else
                Mesaj.Text = "Genel Parameterler bulunamadı!"
                BKaydet.Visible = False
            End If

        End If

    End Sub

    Private Sub BKaydet_Click(sender As Object, e As ImageClickEventArgs) Handles BKaydet.Click
        Dim GrpTopla As String = Grp00.Text & Grp01.Text & Grp02.Text & Grp03.Text & Grp04.Text & Grp05.Text & Grp06.Text & Grp07.Text & Grp08.Text & Grp09.Text & Grp10.Text & Grp11.Text & Grp12.Text & Grp13.Text & Grp14.Text & Grp15.Text & Grp16.Text & Grp17.Text & Grp18.Text & Grp19.Text
        If InStr(GrpTopla.ToUpper, "DELETE") > 0 Or InStr(GrpTopla.ToUpper, "UPDATE") > 0 Or InStr(GrpTopla.ToUpper, "DROP") > 0 Or InStr(GrpTopla.ToUpper, "INSERT") > 0 Then
            Mesaj.Text = "'DELETE', 'INSERT', 'UPDATE', 'DROP' ifadelerini burada kullanamazsınız?"
            Mesaj.ForeColor = Drawing.Color.Red
            Exit Sub
        End If
        Dim RSql As New SqlForConnection
        Dim vParametre(68) As SqlParameter
        vParametre(0) = New SqlParameter("@Firma", Firma.Text)
        vParametre(1) = New SqlParameter("@Lisans", Lisans.Text)
        vParametre(2) = New SqlParameter("@LoginUser", LoginUser.SelectedIndex)
        vParametre(3) = New SqlParameter("@islemGun", IslemGun.Text)
        vParametre(4) = New SqlParameter("@PlanGun", PlanGun.Text)
        vParametre(5) = New SqlParameter("@OnayGun", 0) 'OnayGun)
        vParametre(6) = New SqlParameter("@FM1", FM1.Text)
        vParametre(7) = New SqlParameter("@FM2", FM2.Text)
        vParametre(8) = New SqlParameter("@FM3", FM3.Text)
        vParametre(9) = New SqlParameter("@ESNEK", ESNEK.Text)
        vParametre(10) = New SqlParameter("@Grp00", Grp00.Text)
        vParametre(11) = New SqlParameter("@Grp01", Grp01.Text)
        vParametre(12) = New SqlParameter("@Grp02", Grp02.Text)
        vParametre(13) = New SqlParameter("@Grp03", Grp03.Text)
        vParametre(14) = New SqlParameter("@Grp04", Grp04.Text)
        vParametre(15) = New SqlParameter("@Grp05", Grp05.Text)
        vParametre(16) = New SqlParameter("@Grp06", Grp06.Text)
        vParametre(17) = New SqlParameter("@Grp07", Grp07.Text)
        vParametre(18) = New SqlParameter("@Grp08", Grp08.Text)
        vParametre(19) = New SqlParameter("@Grp09", Grp09.Text)
        vParametre(20) = New SqlParameter("@Grp10", Grp10.Text)
        vParametre(21) = New SqlParameter("@Grp11", Grp11.Text)
        vParametre(22) = New SqlParameter("@Grp12", Grp12.Text)
        vParametre(23) = New SqlParameter("@Grp13", Grp13.Text)
        vParametre(24) = New SqlParameter("@Grp14", Grp14.Text)
        vParametre(25) = New SqlParameter("@Grp15", Grp15.Text)
        vParametre(26) = New SqlParameter("@Grp16", Grp16.Text)
        vParametre(27) = New SqlParameter("@Grp17", Grp17.Text)
        vParametre(28) = New SqlParameter("@Grp18", Grp18.Text)
        vParametre(29) = New SqlParameter("@Grp19", Grp19.Text)
        vParametre(30) = New SqlParameter("@GrpName00", GrpName00.Text)
        vParametre(31) = New SqlParameter("@GrpName01", GrpName01.Text)
        vParametre(32) = New SqlParameter("@GrpName02", GrpName02.Text)
        vParametre(33) = New SqlParameter("@GrpName03", GrpName03.Text)
        vParametre(34) = New SqlParameter("@GrpName04", GrpName04.Text)
        vParametre(35) = New SqlParameter("@GrpName05", GrpName05.Text)
        vParametre(36) = New SqlParameter("@GrpName06", GrpName06.Text)
        vParametre(37) = New SqlParameter("@GrpName07", GrpName07.Text)
        vParametre(38) = New SqlParameter("@GrpName08", GrpName08.Text)
        vParametre(39) = New SqlParameter("@GrpName09", GrpName09.Text)
        vParametre(40) = New SqlParameter("@GrpName10", GrpName10.Text)
        vParametre(41) = New SqlParameter("@GrpName11", GrpName11.Text)
        vParametre(42) = New SqlParameter("@GrpName12", GrpName12.Text)
        vParametre(43) = New SqlParameter("@GrpName13", GrpName13.Text)
        vParametre(44) = New SqlParameter("@GrpName14", GrpName14.Text)
        vParametre(45) = New SqlParameter("@GrpName15", GrpName15.Text)
        vParametre(46) = New SqlParameter("@GrpName16", GrpName16.Text)
        vParametre(47) = New SqlParameter("@GrpName17", GrpName17.Text)
        vParametre(48) = New SqlParameter("@GrpName18", GrpName18.Text)
        vParametre(49) = New SqlParameter("@GrpName19", GrpName19.Text)
        Dim ModulTxt As String = ""
        For i As Integer = 0 To 4
            If Moduller.Items(i).Selected Then
                ModulTxt &= "1"
            Else
                ModulTxt &= "0"
            End If
        Next



        vParametre(50) = New SqlParameter("@Moduller", ModulTxt)
        vParametre(51) = New SqlParameter("@OnaySekli", 0)
        vParametre(52) = New SqlParameter("@MZDilim", MZDilim.SelectedIndex)
        vParametre(53) = New SqlParameter("@FMDilim", FMDilim.SelectedIndex)
        vParametre(54) = New SqlParameter("@MMDilim", MMDilim.SelectedIndex)
        vParametre(55) = New SqlParameter("@CmtRenk", bCmtRenk.SelectedValue)
        vParametre(56) = New SqlParameter("@PazRenk", bPazRenk.SelectedValue)
        vParametre(57) = New SqlParameter("@RestaRenk", bRestaRenk.SelectedValue)
        vParametre(58) = New SqlParameter("@OnayRenk", bOnayRenk.SelectedValue)
        vParametre(59) = New SqlParameter("@GecmisRenk", bGecmisRenk.SelectedValue)
        vParametre(60) = New SqlParameter("@PsizFMRenk", bPsizFMRenk.SelectedValue)
        vParametre(61) = New SqlParameter("@Puantaj", Puantaj.SelectedIndex)
        vParametre(62) = New SqlParameter("@NCAL", NCAL.Text)
        vParametre(63) = New SqlParameter("@KilitRenk", bKilitRenk.SelectedValue)
        vParametre(64) = New SqlParameter("@VardiyaSay", VardiyaSay.Text)
        vParametre(65) = New SqlParameter("@vFM1", vFM1.Text)
        vParametre(66) = New SqlParameter("@vFM2", vFM2.Text)
        vParametre(67) = New SqlParameter("@vFM3", vFM3.Text)
        vParametre(68) = New SqlParameter("@Kilit", Kilit.Text)

        Dim Sonuc As Boolean = RSql.RunSQL("UPDATE BoschLisans SET Firma=@Firma, Lisans=@Lisans, LoginUser=@LoginUser, islemGun=@islemGun, PlanGun=@PlanGun, OnaySekli=@OnaySekli, OnayGun=@OnayGun, Puantaj=@Puantaj, Grp00=@Grp00, Grp01=@Grp01, Grp02=@Grp02, Grp03=@Grp03, Grp04=@Grp04, Grp05=@Grp05, Grp06=@Grp06, Grp07=@Grp07, Grp08=@Grp08, Grp09=@Grp09, Grp10=@Grp10, Grp11=@Grp11, Grp12=@Grp12, Grp13=@Grp13, Grp14=@Grp14, Grp15=@Grp15, Grp16=@Grp16, Grp17=@Grp17, Grp18=@Grp18, Grp19=@Grp19, GrpName00=@GrpName00, GrpName01=@GrpName01, GrpName02=@GrpName02, GrpName03=@GrpName03, GrpName04=@GrpName04, GrpName05=@GrpName05, GrpName06=@GrpName06, GrpName07=@GrpName07, GrpName08=@GrpName08, GrpName09=@GrpName09, GrpName10=@GrpName10, GrpName11=@GrpName11, GrpName12=@GrpName12, GrpName13=@GrpName13, GrpName14=@GrpName14, GrpName15=@GrpName15, GrpName16=@GrpName16, GrpName17=@GrpName17, GrpName18=@GrpName18, GrpName19=@GrpName19, Moduller=@Moduller, MZDilim=@MZDilim, FMDilim=@FMDilim, MMDilim=@MMDilim, CmtRenk=@CmtRenk, PazRenk=@PazRenk, RestaRenk=@RestaRenk, OnayRenk=@OnayRenk, GecmisRenk=@GecmisRenk, PsizFMRenk=@PsizFMRenk, FM1=@FM1, FM2=@FM2, FM3=@FM3, ESNEK=@ESNEK, NCAL=@NCAL, KilitRenk=@KilitRenk, VardiyaSay=@VardiyaSay, vFM1=@vFM1, vFM2=@vFM2, vFM3=@vFM3, Kilit=@Kilit", vParametre)
        RSql.ConnDbClose()
    End Sub

End Class