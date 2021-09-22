Module MBosch

    Public Function RmvTrChr(ByVal bStr As String) As String
        bStr = bStr.Replace("ü", "u")
        bStr = bStr.Replace("ğ", "g")
        bStr = bStr.Replace("ı", "i")
        bStr = bStr.Replace("ş", "s")
        bStr = bStr.Replace("ö", "o")
        bStr = bStr.Replace("ç", "c")
        bStr = bStr.Replace("Ğ", "G")
        bStr = bStr.Replace("Ü", "U")
        bStr = bStr.Replace("Ş", "S")
        bStr = bStr.Replace("İ", "I")
        bStr = bStr.Replace("Ö", "O")
        bStr = bStr.Replace("Ç", "C")
        Return bStr
    End Function

    Public Function RmvErrChr(ByVal bStr As String) As String
        bStr = bStr.Replace("'", "")
        bStr = bStr.Replace("-", "")
        Return bStr
    End Function

    Public Function SplitNumber(ByVal Veri As String) As String
        Dim NewVeri As String = ""
        If Len(Veri) > 0 Then
            For i As Integer = 1 To Len(Veri)
                If InStr("0123456789+", Mid(Veri, i, 1)) > 0 Then
                    NewVeri = NewVeri & Mid(Veri, i, 1)
                End If
            Next
        End If
        Return NewVeri
    End Function

    Private Function UnCnvPass(ByVal UPassTxt As String) As String
        Dim CnvText As String = ""
        Dim CnvChr As String = ""
        Dim Chkno As Integer = 0
        Chkno = Val("&H" & Mid(UPassTxt, 3, 1))
        Dim CnvBoy As Integer = Val("&H" & Mid(UPassTxt, 1 + Chkno, 1) & Mid(UPassTxt, 5 + Chkno, 1))
        For i As Integer = 1 To CnvBoy
            CnvText = CnvText & Chr(Val("&H" & Mid(UPassTxt, 23 + i + 3 * i, 2)))
        Next
        Return CnvText
    End Function

    Public Function CnvSQLString(ByVal USQLStr As String) As String
        Dim CnvSQLText As String = ""
        If USQLStr = "" Then Return ""
        Dim ParseSQLStr() As String = USQLStr.Split(";")
        For Each Satir As String In ParseSQLStr
            If Satir.ToUpper.Replace(" ", "").Contains("PASSWORD=") Then
                CnvSQLText &= ";PASSWORD=" & UnCnvPass(Satir.Split("=")(1))
            Else
                CnvSQLText &= ";" & Satir
            End If
        Next
        Return CnvSQLText
    End Function

    Public Function Hafta(ByVal Tarih As Date) As Integer

        Dim Yilbasi As Date = New Date(Year(Tarih), 1, 1)
        Dim HaftaH As Integer = (DateDiff(DateInterval.Day, Yilbasi, Tarih) + Weekday(Yilbasi, Microsoft.VisualBasic.FirstDayOfWeek.Monday)) / 7
        Return HaftaH

    End Function

    Public Function HaftaGun(ByVal Tarih As Date) As String
        Return Choose(Weekday(Tarih, Microsoft.VisualBasic.FirstDayOfWeek.Monday), "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar")
    End Function

    Public Enum KnownColors As UInteger
        AliceBlue = &HFFF0F8FFUI
        AntiqueWhite = &HFFFAEBD7UI
        Aqua = &HFF00FFFFUI
        Aquamarine = &HFF7FFFD4UI
        Azure = &HFFF0FFFFUI
        Beige = &HFFF5F5DCUI
        Bisque = &HFFFFE4C4UI
        Black = &HFF000000UI
        BlanchedAlmond = &HFFFFEBCDUI
        Blue = &HFF0000FFUI
        BlueViolet = &HFF8A2BE2UI
        Brown = &HFFA52A2AUI
        BurlyWood = &HFFDEB887UI
        CadetBlue = &HFF5F9EA0UI
        Chartreuse = &HFF7FFF00UI
        Chocolate = &HFFD2691EUI
        Coral = &HFFFF7F50UI
        CornflowerBlue = &HFF6495EDUI
        Cornsilk = &HFFFFF8DCUI
        Crimson = &HFFDC143CUI
        Cyan = &HFF00FFFFUI
        DarkBlue = &HFF00008BUI
        DarkCyan = &HFF008B8BUI
        DarkGoldenrod = &HFFB8860BUI
        DarkGray = &HFFA9A9A9UI
        DarkGreen = &HFF006400UI
        DarkKhaki = &HFFBDB76BUI
        DarkMagenta = &HFF8B008BUI
        DarkOliveGreen = &HFF556B2FUI
        DarkOrange = &HFFFF8C00UI
        DarkOrchid = &HFF9932CCUI
        DarkRed = &HFF8B0000UI
        DarkSalmon = &HFFE9967AUI
        DarkSeaGreen = &HFF8FBC8FUI
        DarkSlateBlue = &HFF483D8BUI
        DarkSlateGray = &HFF2F4F4FUI
        DarkTurquoise = &HFF00CED1UI
        DarkViolet = &HFF9400D3UI
        DeepPink = &HFFFF1493UI
        DeepSkyBlue = &HFF00BFFFUI
        DimGray = &HFF696969UI
        DodgerBlue = &HFF1E90FFUI
        FireBrick = &HFFB22222UI
        FloralWhite = &HFFFFFAF0UI
        ForestGreen = &HFF228B22UI
        Fuchsia = &HFFFF00FFUI
        Gainsboro = &HFFDCDCDCUI
        GhostWhite = &HFFF8F8FFUI
        Gold = &HFFFFD700UI
        Goldenrod = &HFFDAA520UI
        Gray = &HFF808080UI
        Green = &HFF008000UI
        GreenYellow = &HFFADFF2FUI
        Honeydew = &HFFF0FFF0UI
        HotPink = &HFFFF69B4UI
        IndianRed = &HFFCD5C5CUI
        Indigo = &HFF4B0082UI
        Ivory = &HFFFFFFF0UI
        Khaki = &HFFF0E68CUI
        Lavender = &HFFE6E6FAUI
        LavenderBlush = &HFFFFF0F5UI
        LawnGreen = &HFF7CFC00UI
        LemonChiffon = &HFFFFFACDUI
        LightBlue = &HFFADD8E6UI
        LightCoral = &HFFF08080UI
        LightCyan = &HFFE0FFFFUI
        LightGoldenrodYellow = &HFFFAFAD2UI
        LightGreen = &HFF90EE90UI
        LightGray = &HFFD3D3D3UI
        LightPink = &HFFFFB6C1UI
        LightSalmon = &HFFFFA07AUI
        LightSeaGreen = &HFF20B2AAUI
        LightSkyBlue = &HFF87CEFAUI
        LightSlateGray = &HFF778899UI
        LightSteelBlue = &HFFB0C4DEUI
        LightYellow = &HFFFFFFE0UI
        Lime = &HFF00FF00UI
        LimeGreen = &HFF32CD32UI
        Linen = &HFFFAF0E6UI
        Magenta = &HFFFF00FFUI
        Maroon = &HFF800000UI
        MediumAquamarine = &HFF66CDAAUI
        MediumBlue = &HFF0000CDUI
        MediumOrchid = &HFFBA55D3UI
        MediumPurple = &HFF9370DBUI
        MediumSeaGreen = &HFF3CB371UI
        MediumSlateBlue = &HFF7B68EEUI
        MediumSpringGreen = &HFF00FA9AUI
        MediumTurquoise = &HFF48D1CCUI
        MediumVioletRed = &HFFC71585UI
        MidnightBlue = &HFF191970UI
        MintCream = &HFFF5FFFAUI
        MistyRose = &HFFFFE4E1UI
        Moccasin = &HFFFFE4B5UI
        NavajoWhite = &HFFFFDEADUI
        Navy = &HFF000080UI
        OldLace = &HFFFDF5E6UI
        Olive = &HFF808000UI
        OliveDrab = &HFF6B8E23UI
        Orange = &HFFFFA500UI
        OrangeRed = &HFFFF4500UI
        Orchid = &HFFDA70D6UI
        PaleGoldenrod = &HFFEEE8AAUI
        PaleGreen = &HFF98FB98UI
        PaleTurquoise = &HFFAFEEEEUI
        PaleVioletRed = &HFFDB7093UI
        PapayaWhip = &HFFFFEFD5UI
        PeachPuff = &HFFFFDAB9UI
        Peru = &HFFCD853FUI
        Pink = &HFFFFC0CBUI
        Plum = &HFFDDA0DDUI
        PowderBlue = &HFFB0E0E6UI
        Purple = &HFF800080UI
        Red = &HFFFF0000UI
        RosyBrown = &HFFBC8F8FUI
        RoyalBlue = &HFF4169E1UI
        SaddleBrown = &HFF8B4513UI
        Salmon = &HFFFA8072UI
        SandyBrown = &HFFF4A460UI
        SeaGreen = &HFF2E8B57UI
        Seashell = &HFFFFF5EEUI
        Sienna = &HFFA0522DUI
        Silver = &HFFC0C0C0UI
        SkyBlue = &HFF87CEEBUI
        SlateBlue = &HFF6A5ACDUI
        SlateGray = &HFF708090UI
        Snow = &HFFFFFAFAUI
        SpringGreen = &HFF00FF7FUI
        SteelBlue = &HFF4682B4UI
        Tan = &HFFD2B48CUI
        Teal = &HFF008080UI
        Thistle = &HFFD8BFD8UI
        Tomato = &HFFFF6347UI
        Turquoise = &HFF40E0D0UI
        Violet = &HFFEE82EEUI
        Wheat = &HFFF5DEB3UI
        White = &HFFFFFFFFUI
        WhiteSmoke = &HFFF5F5F5UI
        Yellow = &HFFFFFF00UI
        YellowGreen = &HFF9ACD32UI
    End Enum

End Module
