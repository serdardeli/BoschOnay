Partial Class RBosch_MForm01

    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim EaN13Encoder1 As Telerik.Reporting.Barcodes.EAN13Encoder = New Telerik.Reporting.Barcodes.EAN13Encoder()
        Dim FormattingRule1 As Telerik.Reporting.Drawing.FormattingRule = New Telerik.Reporting.Drawing.FormattingRule()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RBosch_MForm01))
        Dim FormattingRule2 As Telerik.Reporting.Drawing.FormattingRule = New Telerik.Reporting.Drawing.FormattingRule()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.TextBox3 = New Telerik.Reporting.TextBox()
        Me.TextBox4 = New Telerik.Reporting.TextBox()
        Me.TextBox7 = New Telerik.Reporting.TextBox()
        Me.Barcode1 = New Telerik.Reporting.Barcode()
        Me.TextBox10 = New Telerik.Reporting.TextBox()
        Me.TextBox14 = New Telerik.Reporting.TextBox()
        Me.TextBox13 = New Telerik.Reporting.TextBox()
        Me.TextBox15 = New Telerik.Reporting.TextBox()
        Me.TextBox21 = New Telerik.Reporting.TextBox()
        Me.TextBox24 = New Telerik.Reporting.TextBox()
        Me.TextBox27 = New Telerik.Reporting.TextBox()
        Me.TextBox29 = New Telerik.Reporting.TextBox()
        Me.TextBox43 = New Telerik.Reporting.TextBox()
        Me.TextBox44 = New Telerik.Reporting.TextBox()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.TextBox16 = New Telerik.Reporting.TextBox()
        Me.TextBox17 = New Telerik.Reporting.TextBox()
        Me.TextBox48 = New Telerik.Reporting.TextBox()
        Me.TextBox49 = New Telerik.Reporting.TextBox()
        Me.TextBox51 = New Telerik.Reporting.TextBox()
        Me.TextBox54 = New Telerik.Reporting.TextBox()
        Me.TextBox56 = New Telerik.Reporting.TextBox()
        Me.TextBox58 = New Telerik.Reporting.TextBox()
        Me.TextBox59 = New Telerik.Reporting.TextBox()
        Me.TextBox60 = New Telerik.Reporting.TextBox()
        Me.TextBox62 = New Telerik.Reporting.TextBox()
        Me.TextBox61 = New Telerik.Reporting.TextBox()
        Me.TextBox64 = New Telerik.Reporting.TextBox()
        Me.TextBox67 = New Telerik.Reporting.TextBox()
        Me.TextBox65 = New Telerik.Reporting.TextBox()
        Me.TextBox69 = New Telerik.Reporting.TextBox()
        Me.TextBox68 = New Telerik.Reporting.TextBox()
        Me.TextBox72 = New Telerik.Reporting.TextBox()
        Me.TextBox82 = New Telerik.Reporting.TextBox()
        Me.TextBox83 = New Telerik.Reporting.TextBox()
        Me.TextBox84 = New Telerik.Reporting.TextBox()
        Me.TextBox85 = New Telerik.Reporting.TextBox()
        Me.TextBox86 = New Telerik.Reporting.TextBox()
        Me.TextBox87 = New Telerik.Reporting.TextBox()
        Me.TextBox88 = New Telerik.Reporting.TextBox()
        Me.TextBox89 = New Telerik.Reporting.TextBox()
        Me.TextBox90 = New Telerik.Reporting.TextBox()
        Me.TextBox5 = New Telerik.Reporting.TextBox()
        Me.TextBox120 = New Telerik.Reporting.TextBox()
        Me.TextBox121 = New Telerik.Reporting.TextBox()
        Me.SqlDataSource1 = New Telerik.Reporting.SqlDataSource()
        Me.TextBox52 = New Telerik.Reporting.TextBox()
        Me.TextBox53 = New Telerik.Reporting.TextBox()
        Me.TextBox55 = New Telerik.Reporting.TextBox()
        Me.TextBox57 = New Telerik.Reporting.TextBox()
        Me.TextBox63 = New Telerik.Reporting.TextBox()
        Me.TextBox66 = New Telerik.Reporting.TextBox()
        Me.TextBox70 = New Telerik.Reporting.TextBox()
        Me.TextBox71 = New Telerik.Reporting.TextBox()
        Me.TextBox75 = New Telerik.Reporting.TextBox()
        Me.TextBox78 = New Telerik.Reporting.TextBox()
        Me.TextBox80 = New Telerik.Reporting.TextBox()
        Me.TextBox81 = New Telerik.Reporting.TextBox()
        Me.TextBox25 = New Telerik.Reporting.TextBox()
        Me.TextBox26 = New Telerik.Reporting.TextBox()
        Me.TextBox30 = New Telerik.Reporting.TextBox()
        Me.TextBox31 = New Telerik.Reporting.TextBox()
        Me.TextBox33 = New Telerik.Reporting.TextBox()
        Me.TextBox34 = New Telerik.Reporting.TextBox()
        Me.TextBox35 = New Telerik.Reporting.TextBox()
        Me.TextBox36 = New Telerik.Reporting.TextBox()
        Me.TextBox37 = New Telerik.Reporting.TextBox()
        Me.TextBox38 = New Telerik.Reporting.TextBox()
        Me.TextBox39 = New Telerik.Reporting.TextBox()
        Me.TextBox40 = New Telerik.Reporting.TextBox()
        Me.TextBox73 = New Telerik.Reporting.TextBox()
        Me.TextBox74 = New Telerik.Reporting.TextBox()
        Me.TextBox76 = New Telerik.Reporting.TextBox()
        Me.TextBox77 = New Telerik.Reporting.TextBox()
        Me.TextBox79 = New Telerik.Reporting.TextBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(26.99R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox1, Me.TextBox3, Me.TextBox4, Me.TextBox7, Me.Barcode1, Me.TextBox10, Me.TextBox14, Me.TextBox13, Me.TextBox15, Me.TextBox21, Me.TextBox24, Me.TextBox27, Me.TextBox29, Me.TextBox43, Me.TextBox44, Me.TextBox2, Me.TextBox16, Me.TextBox17, Me.TextBox48, Me.TextBox49, Me.TextBox51, Me.TextBox54, Me.TextBox56, Me.TextBox58, Me.TextBox59, Me.TextBox60, Me.TextBox62, Me.TextBox61, Me.TextBox64, Me.TextBox67, Me.TextBox65, Me.TextBox69, Me.TextBox68, Me.TextBox72, Me.TextBox82, Me.TextBox83, Me.TextBox84, Me.TextBox85, Me.TextBox86, Me.TextBox87, Me.TextBox88, Me.TextBox89, Me.TextBox90, Me.TextBox5, Me.TextBox120, Me.TextBox121})
        Me.detail.Name = "detail"
        Me.detail.Style.BackgroundImage.MimeType = ""
        Me.detail.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.RepeatY
        '
        'TextBox1
        '
        Me.TextBox1.Format = "{0:dd.MM.yyyy}"
        Me.TextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.026R), Telerik.Reporting.Drawing.Unit.Cm(0.212R))
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.788R), Telerik.Reporting.Drawing.Unit.Cm(0.6R))
        Me.TextBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox1.Style.Font.Bold = True
        Me.TextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox1.Value = "= Fields.Tarih"
        '
        'TextBox3
        '
        Me.TextBox3.Format = ""
        Me.TextBox3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.969R), Telerik.Reporting.Drawing.Unit.Cm(1.191R))
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.752R), Telerik.Reporting.Drawing.Unit.Cm(0.441R))
        Me.TextBox3.Style.Font.Bold = True
        Me.TextBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox3.Value = "= Fields.SicilNo"
        '
        'TextBox4
        '
        Me.TextBox4.Format = ""
        Me.TextBox4.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.969R), Telerik.Reporting.Drawing.Unit.Cm(1.738R))
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.752R), Telerik.Reporting.Drawing.Unit.Cm(0.441R))
        Me.TextBox4.Style.Font.Bold = True
        Me.TextBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox4.Value = "= Fields.Per_Vorname + "" "" + Fields.Per_Name"
        '
        'TextBox7
        '
        Me.TextBox7.Format = ""
        Me.TextBox7.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.238R), Telerik.Reporting.Drawing.Unit.Cm(8.281R))
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.587R), Telerik.Reporting.Drawing.Unit.Cm(1.026R))
        Me.TextBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox7.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox7.Style.Font.Bold = False
        Me.TextBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox7.Value = "= Fields.Per_Vorname + "" "" + Fields.Per_Name"
        '
        'Barcode1
        '
        Me.Barcode1.Checksum = True
        Me.Barcode1.Encoder = EaN13Encoder1
        Me.Barcode1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.439R), Telerik.Reporting.Drawing.Unit.Cm(5.424R))
        Me.Barcode1.Name = "Barcode1"
        Me.Barcode1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.376R), Telerik.Reporting.Drawing.Unit.Cm(1.318R))
        Me.Barcode1.Stretch = False
        Me.Barcode1.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.Barcode1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.Barcode1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.Barcode1.Value = "= ""4"" + format(""{0:00000000000}"", Fields.IdNr)"
        '
        'TextBox10
        '
        Me.TextBox10.Format = "{0:dd.MM.yyyy}"
        Me.TextBox10.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.238R), Telerik.Reporting.Drawing.Unit.Cm(9.854R))
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.587R), Telerik.Reporting.Drawing.Unit.Cm(0.997R))
        Me.TextBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox10.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox10.Style.Font.Bold = False
        Me.TextBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox10.Value = "= Fields.Tarih"
        '
        'TextBox14
        '
        FormattingRule1.Filters.Add(New Telerik.Reporting.Filter("= Fields.MaasTipi", Telerik.Reporting.FilterOperator.Equal, "1"))
        FormattingRule1.Style.Visible = False
        Me.TextBox14.ConditionalFormatting.AddRange(New Telerik.Reporting.Drawing.FormattingRule() {FormattingRule1})
        Me.TextBox14.Format = ""
        Me.TextBox14.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.699R), Telerik.Reporting.Drawing.Unit.Cm(11.721R))
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.535R), Telerik.Reporting.Drawing.Unit.Cm(0.679R))
        Me.TextBox14.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox14.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox14.Style.Font.Bold = False
        Me.TextBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox14.Value = "= Fields.Vekil"
        '
        'TextBox13
        '
        Me.TextBox13.ConditionalFormatting.AddRange(New Telerik.Reporting.Drawing.FormattingRule() {FormattingRule1})
        Me.TextBox13.Format = ""
        Me.TextBox13.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.98R), Telerik.Reporting.Drawing.Unit.Cm(11.721R))
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.577R), Telerik.Reporting.Drawing.Unit.Cm(0.679R))
        Me.TextBox13.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox13.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox13.Style.Font.Bold = False
        Me.TextBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox13.Value = "= Fields.VekilKisim"
        '
        'TextBox15
        '
        Me.TextBox15.Format = ""
        Me.TextBox15.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.265R), Telerik.Reporting.Drawing.Unit.Cm(3.492R))
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(17.577R), Telerik.Reporting.Drawing.Unit.Cm(0.945R))
        Me.TextBox15.Style.Font.Bold = False
        Me.TextBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox15.Value = resources.GetString("TextBox15.Value")
        '
        'TextBox21
        '
        FormattingRule2.Filters.Add(New Telerik.Reporting.Filter("= Fields.AvansOK", Telerik.Reporting.FilterOperator.Equal, "0"))
        FormattingRule2.Style.Visible = False
        Me.TextBox21.ConditionalFormatting.AddRange(New Telerik.Reporting.Drawing.FormattingRule() {FormattingRule2})
        Me.TextBox21.Format = ""
        Me.TextBox21.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.842R), Telerik.Reporting.Drawing.Unit.Cm(4.623R))
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.054R), Telerik.Reporting.Drawing.Unit.Cm(0.494R))
        Me.TextBox21.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox21.Style.Font.Bold = True
        Me.TextBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox21.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox21.Value = "= IIf(Fields.AvansOK=1,""X"","""")"
        '
        'TextBox24
        '
        Me.TextBox24.Format = ""
        Me.TextBox24.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.969R), Telerik.Reporting.Drawing.Unit.Cm(2.302R))
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.752R), Telerik.Reporting.Drawing.Unit.Cm(0.441R))
        Me.TextBox24.Style.Font.Bold = True
        Me.TextBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox24.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox24.Value = "= Fields.Kisim"
        '
        'TextBox27
        '
        Me.TextBox27.Format = ""
        Me.TextBox27.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.931R), Telerik.Reporting.Drawing.Unit.Cm(1.111R))
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.857R), Telerik.Reporting.Drawing.Unit.Cm(0.494R))
        Me.TextBox27.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox27.Style.Font.Bold = True
        Me.TextBox27.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox27.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox27.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox27.Value = "= IIf(Fields.MaasTipi=1,""Saat Ücretli"", IIf(Fields.MaasTipi=2,""Aylýk Ücretli"",""Yö" &
    "netici""))"
        '
        'TextBox29
        '
        Me.TextBox29.Format = ""
        Me.TextBox29.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.931R), Telerik.Reporting.Drawing.Unit.Cm(1.764R))
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.831R), Telerik.Reporting.Drawing.Unit.Cm(1.526R))
        Me.TextBox29.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox29.Style.Font.Bold = True
        Me.TextBox29.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox29.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox29.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top
        Me.TextBox29.Value = "= Fields.Aciklama"
        '
        'TextBox43
        '
        Me.TextBox43.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.238R), Telerik.Reporting.Drawing.Unit.Cm(0.212R))
        Me.TextBox43.Name = "TextBox43"
        Me.TextBox43.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.869R), Telerik.Reporting.Drawing.Unit.Cm(0.6R))
        Me.TextBox43.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox43.Style.Font.Bold = True
        Me.TextBox43.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox43.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox43.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox43.Value = "Yýllýk Ýzin Talep Formu"
        '
        'TextBox44
        '
        Me.TextBox44.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.107R), Telerik.Reporting.Drawing.Unit.Cm(0.212R))
        Me.TextBox44.Name = "TextBox44"
        Me.TextBox44.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.919R), Telerik.Reporting.Drawing.Unit.Cm(0.6R))
        Me.TextBox44.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox44.Style.Font.Bold = True
        Me.TextBox44.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox44.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox44.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox44.Value = "Talep Tarihi"
        '
        'TextBox2
        '
        Me.TextBox2.Format = ""
        Me.TextBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.265R), Telerik.Reporting.Drawing.Unit.Cm(1.191R))
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.704R), Telerik.Reporting.Drawing.Unit.Cm(0.441R))
        Me.TextBox2.Style.Font.Bold = False
        Me.TextBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox2.Value = "Personel Numarasý"
        '
        'TextBox16
        '
        Me.TextBox16.Format = ""
        Me.TextBox16.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.265R), Telerik.Reporting.Drawing.Unit.Cm(1.764R))
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.704R), Telerik.Reporting.Drawing.Unit.Cm(0.441R))
        Me.TextBox16.Style.Font.Bold = False
        Me.TextBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox16.Value = "Ad  - Soyad"
        '
        'TextBox17
        '
        Me.TextBox17.Format = ""
        Me.TextBox17.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.265R), Telerik.Reporting.Drawing.Unit.Cm(2.302R))
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.704R), Telerik.Reporting.Drawing.Unit.Cm(0.441R))
        Me.TextBox17.Style.Font.Bold = False
        Me.TextBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox17.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox17.Value = "Kýsým"
        '
        'TextBox48
        '
        Me.TextBox48.Format = ""
        Me.TextBox48.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.107R), Telerik.Reporting.Drawing.Unit.Cm(1.138R))
        Me.TextBox48.Name = "TextBox48"
        Me.TextBox48.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.723R), Telerik.Reporting.Drawing.Unit.Cm(0.441R))
        Me.TextBox48.Style.Font.Bold = False
        Me.TextBox48.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox48.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox48.Value = "Tipi"
        '
        'TextBox49
        '
        Me.TextBox49.Format = ""
        Me.TextBox49.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.107R), Telerik.Reporting.Drawing.Unit.Cm(1.738R))
        Me.TextBox49.Name = "TextBox49"
        Me.TextBox49.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.723R), Telerik.Reporting.Drawing.Unit.Cm(0.441R))
        Me.TextBox49.Style.Font.Bold = False
        Me.TextBox49.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox49.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox49.Value = "Açýklama"
        '
        'TextBox51
        '
        Me.TextBox51.ConditionalFormatting.AddRange(New Telerik.Reporting.Drawing.FormattingRule() {FormattingRule2})
        Me.TextBox51.Format = ""
        Me.TextBox51.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.265R), Telerik.Reporting.Drawing.Unit.Cm(4.623R))
        Me.TextBox51.Name = "TextBox51"
        Me.TextBox51.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.577R), Telerik.Reporting.Drawing.Unit.Cm(0.494R))
        Me.TextBox51.Style.Font.Bold = False
        Me.TextBox51.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox51.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox51.Value = "Yýllýk Ýzin avansý istiyorum"
        '
        'TextBox54
        '
        Me.TextBox54.Format = ""
        Me.TextBox54.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.238R), Telerik.Reporting.Drawing.Unit.Cm(5.345R))
        Me.TextBox54.Name = "TextBox54"
        Me.TextBox54.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.869R), Telerik.Reporting.Drawing.Unit.Cm(1.579R))
        Me.TextBox54.Style.Font.Bold = False
        Me.TextBox54.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox54.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox54.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox54.Value = resources.GetString("TextBox54.Value")
        '
        'TextBox56
        '
        Me.TextBox56.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.238R), Telerik.Reporting.Drawing.Unit.Cm(7.056R))
        Me.TextBox56.Name = "TextBox56"
        Me.TextBox56.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.45R), Telerik.Reporting.Drawing.Unit.Cm(0.679R))
        Me.TextBox56.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox56.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox56.Style.Font.Bold = True
        Me.TextBox56.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox56.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox56.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox56.Value = "Talep Eden"
        '
        'TextBox58
        '
        Me.TextBox58.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.689R), Telerik.Reporting.Drawing.Unit.Cm(7.056R))
        Me.TextBox58.Name = "TextBox58"
        Me.TextBox58.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(9.128R), Telerik.Reporting.Drawing.Unit.Cm(0.679R))
        Me.TextBox58.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox58.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox58.Style.Font.Bold = True
        Me.TextBox58.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox58.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox58.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox58.Value = "Üst Amir Onay"
        '
        'TextBox59
        '
        Me.TextBox59.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.238R), Telerik.Reporting.Drawing.Unit.Cm(7.736R))
        Me.TextBox59.Name = "TextBox59"
        Me.TextBox59.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.588R), Telerik.Reporting.Drawing.Unit.Cm(0.546R))
        Me.TextBox59.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox59.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox59.Style.Font.Bold = True
        Me.TextBox59.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox59.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox59.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox59.Value = "Ad Soyad"
        '
        'TextBox60
        '
        Me.TextBox60.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.852R), Telerik.Reporting.Drawing.Unit.Cm(7.736R))
        Me.TextBox60.Name = "TextBox60"
        Me.TextBox60.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.836R), Telerik.Reporting.Drawing.Unit.Cm(0.546R))
        Me.TextBox60.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox60.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox60.Style.Font.Bold = True
        Me.TextBox60.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox60.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox60.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox60.Value = "Kýsým"
        '
        'TextBox62
        '
        Me.TextBox62.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.689R), Telerik.Reporting.Drawing.Unit.Cm(7.736R))
        Me.TextBox62.Name = "TextBox62"
        Me.TextBox62.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.856R), Telerik.Reporting.Drawing.Unit.Cm(0.546R))
        Me.TextBox62.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox62.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox62.Style.Font.Bold = True
        Me.TextBox62.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox62.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox62.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox62.Value = "Ad Soyad"
        '
        'TextBox61
        '
        Me.TextBox61.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.571R), Telerik.Reporting.Drawing.Unit.Cm(7.736R))
        Me.TextBox61.Name = "TextBox61"
        Me.TextBox61.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.245R), Telerik.Reporting.Drawing.Unit.Cm(0.546R))
        Me.TextBox61.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox61.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox61.Style.Font.Bold = True
        Me.TextBox61.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox61.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox61.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox61.Value = "Kýsým"
        '
        'TextBox64
        '
        Me.TextBox64.Format = ""
        Me.TextBox64.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.852R), Telerik.Reporting.Drawing.Unit.Cm(8.281R))
        Me.TextBox64.Name = "TextBox64"
        Me.TextBox64.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.836R), Telerik.Reporting.Drawing.Unit.Cm(1.026R))
        Me.TextBox64.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox64.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox64.Style.Font.Bold = False
        Me.TextBox64.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox64.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox64.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox64.Value = "= Fields.Kisim"
        '
        'TextBox67
        '
        Me.TextBox67.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.238R), Telerik.Reporting.Drawing.Unit.Cm(9.308R))
        Me.TextBox67.Name = "TextBox67"
        Me.TextBox67.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.588R), Telerik.Reporting.Drawing.Unit.Cm(0.543R))
        Me.TextBox67.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox67.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox67.Style.Font.Bold = True
        Me.TextBox67.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox67.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox67.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox67.Value = "Tarih"
        '
        'TextBox65
        '
        Me.TextBox65.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.852R), Telerik.Reporting.Drawing.Unit.Cm(9.308R))
        Me.TextBox65.Name = "TextBox65"
        Me.TextBox65.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.836R), Telerik.Reporting.Drawing.Unit.Cm(0.543R))
        Me.TextBox65.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox65.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox65.Style.Font.Bold = True
        Me.TextBox65.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox65.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox65.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox65.Value = "Ýmza"
        '
        'TextBox69
        '
        Me.TextBox69.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.689R), Telerik.Reporting.Drawing.Unit.Cm(9.308R))
        Me.TextBox69.Name = "TextBox69"
        Me.TextBox69.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.882R), Telerik.Reporting.Drawing.Unit.Cm(0.543R))
        Me.TextBox69.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox69.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox69.Style.Font.Bold = True
        Me.TextBox69.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox69.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox69.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox69.Value = "Tarih"
        '
        'TextBox68
        '
        Me.TextBox68.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.571R), Telerik.Reporting.Drawing.Unit.Cm(9.308R))
        Me.TextBox68.Name = "TextBox68"
        Me.TextBox68.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.245R), Telerik.Reporting.Drawing.Unit.Cm(0.543R))
        Me.TextBox68.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox68.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox68.Style.Font.Bold = True
        Me.TextBox68.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox68.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox68.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox68.Value = "Ýmza"
        '
        'TextBox72
        '
        Me.TextBox72.Format = ""
        Me.TextBox72.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.689R), Telerik.Reporting.Drawing.Unit.Cm(8.281R))
        Me.TextBox72.Name = "TextBox72"
        Me.TextBox72.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.882R), Telerik.Reporting.Drawing.Unit.Cm(1.026R))
        Me.TextBox72.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox72.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox72.Style.Font.Bold = True
        Me.TextBox72.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox72.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox72.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox72.Value = ""
        '
        'TextBox82
        '
        Me.TextBox82.Format = ""
        Me.TextBox82.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.571R), Telerik.Reporting.Drawing.Unit.Cm(8.281R))
        Me.TextBox82.Name = "TextBox82"
        Me.TextBox82.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.245R), Telerik.Reporting.Drawing.Unit.Cm(1.026R))
        Me.TextBox82.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox82.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox82.Style.Font.Bold = True
        Me.TextBox82.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox82.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox82.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox82.Value = ""
        '
        'TextBox83
        '
        Me.TextBox83.Format = "{0:dd.MM.yyyy}"
        Me.TextBox83.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.852R), Telerik.Reporting.Drawing.Unit.Cm(9.854R))
        Me.TextBox83.Name = "TextBox83"
        Me.TextBox83.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.836R), Telerik.Reporting.Drawing.Unit.Cm(0.997R))
        Me.TextBox83.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox83.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox83.Style.Font.Bold = True
        Me.TextBox83.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox83.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox83.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox83.Value = ""
        '
        'TextBox84
        '
        Me.TextBox84.Format = "{0:dd.MM.yyyy}"
        Me.TextBox84.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.689R), Telerik.Reporting.Drawing.Unit.Cm(9.854R))
        Me.TextBox84.Name = "TextBox84"
        Me.TextBox84.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.882R), Telerik.Reporting.Drawing.Unit.Cm(0.997R))
        Me.TextBox84.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox84.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox84.Style.Font.Bold = True
        Me.TextBox84.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox84.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox84.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox84.Value = ""
        '
        'TextBox85
        '
        Me.TextBox85.Format = "{0:dd.MM.yyyy}"
        Me.TextBox85.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.571R), Telerik.Reporting.Drawing.Unit.Cm(9.854R))
        Me.TextBox85.Name = "TextBox85"
        Me.TextBox85.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.245R), Telerik.Reporting.Drawing.Unit.Cm(0.997R))
        Me.TextBox85.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox85.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox85.Style.Font.Bold = True
        Me.TextBox85.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox85.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox85.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox85.Value = ""
        '
        'TextBox86
        '
        Me.TextBox86.ConditionalFormatting.AddRange(New Telerik.Reporting.Drawing.FormattingRule() {FormattingRule1})
        Me.TextBox86.Format = ""
        Me.TextBox86.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.291R), Telerik.Reporting.Drawing.Unit.Cm(11.721R))
        Me.TextBox86.Name = "TextBox86"
        Me.TextBox86.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.408R), Telerik.Reporting.Drawing.Unit.Cm(0.679R))
        Me.TextBox86.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox86.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox86.Style.Font.Bold = True
        Me.TextBox86.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox86.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox86.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox86.Value = "Ad Soyad"
        '
        'TextBox87
        '
        Me.TextBox87.ConditionalFormatting.AddRange(New Telerik.Reporting.Drawing.FormattingRule() {FormattingRule1})
        Me.TextBox87.Format = ""
        Me.TextBox87.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.234R), Telerik.Reporting.Drawing.Unit.Cm(11.721R))
        Me.TextBox87.Name = "TextBox87"
        Me.TextBox87.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.746R), Telerik.Reporting.Drawing.Unit.Cm(0.679R))
        Me.TextBox87.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox87.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox87.Style.Font.Bold = True
        Me.TextBox87.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox87.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox87.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox87.Value = "Kýsým"
        '
        'TextBox88
        '
        Me.TextBox88.ConditionalFormatting.AddRange(New Telerik.Reporting.Drawing.FormattingRule() {FormattingRule1})
        Me.TextBox88.Format = ""
        Me.TextBox88.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.571R), Telerik.Reporting.Drawing.Unit.Cm(11.721R))
        Me.TextBox88.Name = "TextBox88"
        Me.TextBox88.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.455R), Telerik.Reporting.Drawing.Unit.Cm(0.679R))
        Me.TextBox88.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox88.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox88.Style.Font.Bold = True
        Me.TextBox88.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox88.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox88.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox88.Value = "Ýmza"
        '
        'TextBox89
        '
        Me.TextBox89.ConditionalFormatting.AddRange(New Telerik.Reporting.Drawing.FormattingRule() {FormattingRule1})
        Me.TextBox89.Format = ""
        Me.TextBox89.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.291R), Telerik.Reporting.Drawing.Unit.Cm(10.983R))
        Me.TextBox89.Name = "TextBox89"
        Me.TextBox89.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(17.471R), Telerik.Reporting.Drawing.Unit.Cm(0.555R))
        Me.TextBox89.Style.Font.Bold = False
        Me.TextBox89.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox89.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox89.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox89.Value = "Ýzin süresince vekalet edecek:(Bu kýsým yalnýzca maaþlý personel tarafýndan doldu" &
    "rulacaktýr)"
        '
        'TextBox90
        '
        Me.TextBox90.ConditionalFormatting.AddRange(New Telerik.Reporting.Drawing.FormattingRule() {FormattingRule1})
        Me.TextBox90.Format = ""
        Me.TextBox90.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.026R), Telerik.Reporting.Drawing.Unit.Cm(11.721R))
        Me.TextBox90.Name = "TextBox90"
        Me.TextBox90.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.79R), Telerik.Reporting.Drawing.Unit.Cm(0.679R))
        Me.TextBox90.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox90.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox90.Style.Font.Bold = True
        Me.TextBox90.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox90.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox90.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox90.Value = ""
        '
        'TextBox5
        '
        Me.TextBox5.Format = ""
        Me.TextBox5.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.291R), Telerik.Reporting.Drawing.Unit.Cm(12.488R))
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(17.471R), Telerik.Reporting.Drawing.Unit.Cm(0.555R))
        Me.TextBox5.Style.Font.Bold = False
        Me.TextBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.TextBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox5.Value = "HRL-06 Rev:2.0 / 31.08.2017"
        '
        'TextBox120
        '
        Me.TextBox120.Format = ""
        Me.TextBox120.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.265R), Telerik.Reporting.Drawing.Unit.Cm(2.849R))
        Me.TextBox120.Name = "TextBox120"
        Me.TextBox120.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.704R), Telerik.Reporting.Drawing.Unit.Cm(0.441R))
        Me.TextBox120.Style.Font.Bold = False
        Me.TextBox120.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox120.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox120.Value = "Þirket Kodu"
        '
        'TextBox121
        '
        Me.TextBox121.Format = ""
        Me.TextBox121.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.969R), Telerik.Reporting.Drawing.Unit.Cm(2.849R))
        Me.TextBox121.Name = "TextBox121"
        Me.TextBox121.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.752R), Telerik.Reporting.Drawing.Unit.Cm(0.441R))
        Me.TextBox121.Style.Font.Bold = True
        Me.TextBox121.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(12.0R)
        Me.TextBox121.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox121.Value = "= Fields.Per_Grp0"
        '
        'SqlDataSource1
        '
        Me.SqlDataSource1.ConnectionString = "SQLxDirect"
        Me.SqlDataSource1.Name = "SqlDataSource1"
        Me.SqlDataSource1.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@Ndx", System.Data.DbType.[Decimal], "= Parameters.Ndx.Value")})
        Me.SqlDataSource1.SelectCommand = resources.GetString("SqlDataSource1.SelectCommand")
        '
        'TextBox52
        '
        Me.TextBox52.Name = "TextBox52"
        Me.TextBox52.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.01R), Telerik.Reporting.Drawing.Unit.Cm(12.861R))
        Me.TextBox52.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox52.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox52.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox52.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox52.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox52.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox52.StyleName = ""
        '
        'TextBox53
        '
        Me.TextBox53.Name = "TextBox53"
        Me.TextBox53.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.84R), Telerik.Reporting.Drawing.Unit.Cm(12.861R))
        Me.TextBox53.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox53.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox53.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox53.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox53.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox53.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox53.StyleName = ""
        '
        'TextBox55
        '
        Me.TextBox55.Name = "TextBox55"
        Me.TextBox55.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.192R), Telerik.Reporting.Drawing.Unit.Cm(12.861R))
        Me.TextBox55.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox55.Style.Font.Bold = True
        Me.TextBox55.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(20.0R)
        Me.TextBox55.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox55.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox55.StyleName = ""
        '
        'TextBox57
        '
        Me.TextBox57.Name = "TextBox57"
        Me.TextBox57.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.917R), Telerik.Reporting.Drawing.Unit.Cm(12.861R))
        Me.TextBox57.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox57.Style.Font.Bold = True
        Me.TextBox57.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(20.0R)
        Me.TextBox57.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox57.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox57.StyleName = ""
        '
        'TextBox63
        '
        Me.TextBox63.Name = "TextBox63"
        Me.TextBox63.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.325R), Telerik.Reporting.Drawing.Unit.Cm(12.861R))
        Me.TextBox63.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox63.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox63.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox63.StyleName = ""
        '
        'TextBox66
        '
        Me.TextBox66.Name = "TextBox66"
        Me.TextBox66.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.25R), Telerik.Reporting.Drawing.Unit.Cm(12.861R))
        Me.TextBox66.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox66.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox66.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox66.StyleName = ""
        '
        'TextBox70
        '
        Me.TextBox70.Name = "TextBox70"
        Me.TextBox70.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.01R), Telerik.Reporting.Drawing.Unit.Cm(12.861R))
        Me.TextBox70.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox70.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox70.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox70.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox70.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox70.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox70.StyleName = ""
        '
        'TextBox71
        '
        Me.TextBox71.Name = "TextBox71"
        Me.TextBox71.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.84R), Telerik.Reporting.Drawing.Unit.Cm(12.861R))
        Me.TextBox71.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox71.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox71.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox71.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox71.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox71.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox71.StyleName = ""
        '
        'TextBox75
        '
        Me.TextBox75.Name = "TextBox75"
        Me.TextBox75.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.192R), Telerik.Reporting.Drawing.Unit.Cm(12.861R))
        Me.TextBox75.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox75.Style.Font.Bold = True
        Me.TextBox75.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(20.0R)
        Me.TextBox75.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox75.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox75.StyleName = ""
        '
        'TextBox78
        '
        Me.TextBox78.Name = "TextBox78"
        Me.TextBox78.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.917R), Telerik.Reporting.Drawing.Unit.Cm(12.861R))
        Me.TextBox78.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox78.Style.Font.Bold = True
        Me.TextBox78.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(20.0R)
        Me.TextBox78.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox78.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox78.StyleName = ""
        '
        'TextBox80
        '
        Me.TextBox80.Name = "TextBox80"
        Me.TextBox80.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.325R), Telerik.Reporting.Drawing.Unit.Cm(12.861R))
        Me.TextBox80.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox80.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox80.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox80.StyleName = ""
        '
        'TextBox81
        '
        Me.TextBox81.Name = "TextBox81"
        Me.TextBox81.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.25R), Telerik.Reporting.Drawing.Unit.Cm(12.861R))
        Me.TextBox81.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox81.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox81.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox81.StyleName = ""
        '
        'TextBox25
        '
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0R), Telerik.Reporting.Drawing.Unit.Cm(12.861R))
        Me.TextBox25.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox25.Style.Font.Bold = True
        Me.TextBox25.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(20.0R)
        Me.TextBox25.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox25.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox25.StyleName = ""
        '
        'TextBox26
        '
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0R), Telerik.Reporting.Drawing.Unit.Cm(12.861R))
        Me.TextBox26.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox26.Style.Font.Bold = True
        Me.TextBox26.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(20.0R)
        Me.TextBox26.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox26.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox26.StyleName = ""
        '
        'TextBox30
        '
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0R), Telerik.Reporting.Drawing.Unit.Cm(12.861R))
        Me.TextBox30.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox30.Style.Font.Bold = True
        Me.TextBox30.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(20.0R)
        Me.TextBox30.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox30.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox30.StyleName = ""
        '
        'TextBox31
        '
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0R), Telerik.Reporting.Drawing.Unit.Cm(12.861R))
        Me.TextBox31.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox31.Style.Font.Bold = True
        Me.TextBox31.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(20.0R)
        Me.TextBox31.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox31.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox31.StyleName = ""
        '
        'TextBox33
        '
        Me.TextBox33.Name = "TextBox33"
        Me.TextBox33.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.01R), Telerik.Reporting.Drawing.Unit.Cm(0.296R))
        Me.TextBox33.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox33.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox33.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox33.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox33.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox33.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox33.StyleName = ""
        '
        'TextBox34
        '
        Me.TextBox34.Name = "TextBox34"
        Me.TextBox34.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.84R), Telerik.Reporting.Drawing.Unit.Cm(0.296R))
        Me.TextBox34.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox34.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox34.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox34.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox34.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox34.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox34.StyleName = ""
        '
        'TextBox35
        '
        Me.TextBox35.Name = "TextBox35"
        Me.TextBox35.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.192R), Telerik.Reporting.Drawing.Unit.Cm(0.296R))
        Me.TextBox35.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox35.Style.Font.Bold = True
        Me.TextBox35.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(20.0R)
        Me.TextBox35.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox35.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox35.StyleName = ""
        '
        'TextBox36
        '
        Me.TextBox36.Name = "TextBox36"
        Me.TextBox36.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0R), Telerik.Reporting.Drawing.Unit.Cm(0.296R))
        Me.TextBox36.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox36.Style.Font.Bold = True
        Me.TextBox36.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(20.0R)
        Me.TextBox36.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox36.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox36.StyleName = ""
        '
        'TextBox37
        '
        Me.TextBox37.Name = "TextBox37"
        Me.TextBox37.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0R), Telerik.Reporting.Drawing.Unit.Cm(0.296R))
        Me.TextBox37.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox37.Style.Font.Bold = True
        Me.TextBox37.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(20.0R)
        Me.TextBox37.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox37.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox37.StyleName = ""
        '
        'TextBox38
        '
        Me.TextBox38.Name = "TextBox38"
        Me.TextBox38.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.917R), Telerik.Reporting.Drawing.Unit.Cm(0.296R))
        Me.TextBox38.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox38.Style.Font.Bold = True
        Me.TextBox38.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(20.0R)
        Me.TextBox38.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox38.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox38.StyleName = ""
        '
        'TextBox39
        '
        Me.TextBox39.Name = "TextBox39"
        Me.TextBox39.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.325R), Telerik.Reporting.Drawing.Unit.Cm(0.296R))
        Me.TextBox39.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox39.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox39.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox39.StyleName = ""
        '
        'TextBox40
        '
        Me.TextBox40.Name = "TextBox40"
        Me.TextBox40.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.25R), Telerik.Reporting.Drawing.Unit.Cm(0.296R))
        Me.TextBox40.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox40.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox40.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox40.StyleName = ""
        '
        'TextBox73
        '
        Me.TextBox73.Name = "TextBox73"
        Me.TextBox73.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0R), Telerik.Reporting.Drawing.Unit.Cm(0.578R))
        Me.TextBox73.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox73.Style.Font.Bold = True
        Me.TextBox73.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(20.0R)
        Me.TextBox73.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox73.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox73.StyleName = ""
        '
        'TextBox74
        '
        Me.TextBox74.Name = "TextBox74"
        Me.TextBox74.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0R), Telerik.Reporting.Drawing.Unit.Cm(0.578R))
        Me.TextBox74.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox74.Style.Font.Bold = True
        Me.TextBox74.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(20.0R)
        Me.TextBox74.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox74.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox74.StyleName = ""
        '
        'TextBox76
        '
        Me.TextBox76.Name = "TextBox76"
        Me.TextBox76.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.917R), Telerik.Reporting.Drawing.Unit.Cm(0.578R))
        Me.TextBox76.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox76.Style.Font.Bold = True
        Me.TextBox76.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(20.0R)
        Me.TextBox76.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox76.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox76.StyleName = ""
        '
        'TextBox77
        '
        Me.TextBox77.Name = "TextBox77"
        Me.TextBox77.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.325R), Telerik.Reporting.Drawing.Unit.Cm(0.578R))
        Me.TextBox77.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox77.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox77.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox77.StyleName = ""
        '
        'TextBox79
        '
        Me.TextBox79.Name = "TextBox79"
        Me.TextBox79.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.25R), Telerik.Reporting.Drawing.Unit.Cm(0.578R))
        Me.TextBox79.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox79.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox79.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox79.StyleName = ""
        '
        'RBosch_MForm01
        '
        Me.DataSource = Me.SqlDataSource1
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.detail})
        Me.Name = "RBosch_MForm01"
        Me.PageSettings.ContinuousPaper = False
        Me.PageSettings.Landscape = False
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(15.0R), Telerik.Reporting.Drawing.Unit.Mm(15.0R), Telerik.Reporting.Drawing.Unit.Mm(15.0R), Telerik.Reporting.Drawing.Unit.Mm(10.0R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
        ReportParameter1.Name = "Ndx"
        ReportParameter1.Type = Telerik.Reporting.ReportParameterType.[Integer]
        ReportParameter1.Value = "20"
        Me.ReportParameters.Add(ReportParameter1)
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.TextItemBase)), New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.HtmlTextBox))})
        StyleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        StyleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1})
        Me.Width = Telerik.Reporting.Drawing.Unit.Cm(18.0R)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents SqlDataSource1 As Telerik.Reporting.SqlDataSource
    Friend WithEvents TextBox52 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox53 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox55 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox57 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox63 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox66 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox70 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox71 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox75 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox78 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox80 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox81 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox25 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox26 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox30 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox31 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox33 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox34 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox35 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox36 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox37 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox38 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox39 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox40 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox73 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox74 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox76 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox77 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox79 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox3 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox4 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox7 As Telerik.Reporting.TextBox
    Friend WithEvents Barcode1 As Telerik.Reporting.Barcode
    Friend WithEvents TextBox10 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox14 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox13 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox15 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox21 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox24 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox27 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox29 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox43 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox44 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox16 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox17 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox48 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox49 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox51 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox54 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox56 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox58 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox59 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox60 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox62 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox61 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox64 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox67 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox65 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox69 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox68 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox72 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox82 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox83 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox84 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox85 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox86 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox87 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox88 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox89 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox90 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox5 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox120 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox121 As Telerik.Reporting.TextBox
End Class