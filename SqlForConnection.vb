Imports System.Data.SqlClient

Public Class ErbenSql

    Private ConnDb As SqlConnection
    Private _logquery = " INSERT INTO BoschUserLog (ModulNo,Uygulama,Userid,Tipi,Yapilan) VALUES(@ModulNo,@Uygulama,@Userid,@Tipi,@Yapilan) "
    Private _logqueryyetki = " INSERT INTO BoschYetkiLog (YetkiNo,DegisenAlan,EskiVeri,YeniVeri,Tarih,Tipi,Kullanici,KullaniciYetkiKodu) VALUES(@YetkiNo,@DegisenAlan,@EskiVeri,@YeniVeri,@Tarih,@Tipi,@Kullanici,@KullaniciYetkiKodu) "

    Public Sub New()
        ConnDb = New SqlConnection(CnvSQLString(ConfigurationManager.ConnectionStrings("SQLDirect").ConnectionString))
        Try
            ConnDb.Open()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ConnDbClose()
        Try
            ConnDb.Close()
        Catch ex As Exception

        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Function GetValue(ByVal SQLStr As String) As DataTable
        Dim MyTable As New DataTable
        If ConnDb.State = ConnectionState.Open Then
            Dim QKayit As New SqlCommand(SQLStr, ConnDb)
            QKayit.CommandTimeout = ConnDb.ConnectionTimeout
            Dim DataOku As SqlDataReader = QKayit.ExecuteReader
            MyTable.Load(DataOku)
        End If
        Return MyTable
    End Function

    Public Function GetValue(ByVal SQLStr As String, ByVal QParam() As SqlParameter) As DataTable
        Dim MyTable As New DataTable
        If ConnDb.State = ConnectionState.Open Then
            Dim QKayit As New SqlCommand(SQLStr, ConnDb)
            QKayit.CommandTimeout = ConnDb.ConnectionTimeout
            QKayit.Parameters.AddRange(QParam)
            Dim DataOku As SqlDataReader = QKayit.ExecuteReader
            MyTable.Load(DataOku)
            QKayit.Parameters.Clear()
        End If
        Return MyTable
    End Function

    Public Function RunSQL(ByVal SQLStr As String) As Boolean
        Dim Deger As Boolean = False
        If ConnDb.State = ConnectionState.Open Then
            Try
                Dim QKayit As New SqlCommand(SQLStr, ConnDb)
                QKayit.CommandTimeout = ConnDb.ConnectionTimeout
                QKayit.ExecuteNonQuery()
                Deger = True
            Catch ex As Exception
                Deger = False
            End Try
        End If
        Return Deger
    End Function

    Public Function RunSQL(ByVal SQLStr As String, ByVal QParam() As SqlParameter) As Boolean
        Dim Deger As Boolean = False
        If ConnDb.State = ConnectionState.Open Then
            Try
                Dim QKayit As New SqlCommand(SQLStr, ConnDb)
                QKayit.CommandTimeout = ConnDb.ConnectionTimeout
                QKayit.Parameters.AddRange(QParam)
                QKayit.ExecuteNonQuery()
                Deger = True
                QKayit.Parameters.Clear()
            Catch ex As Exception
                Deger = False
            End Try
        End If
        Return Deger
    End Function

    Public Function AddLog(ByVal QParam() As SqlParameter) As Boolean
        Dim Deger As Boolean = False
        If ConnDb.State = ConnectionState.Open Then
            Try
                Dim QKayit As New SqlCommand(_logquery, ConnDb)
                QKayit.CommandTimeout = ConnDb.ConnectionTimeout
                QKayit.Parameters.AddRange(QParam)
                QKayit.ExecuteNonQuery()
                Deger = True
            Catch ex As Exception
                Deger = False
            End Try
        End If
        Return Deger
    End Function

    Public Function AddLogYetki(ByVal YetkiNo As String, ByVal DegisenAlan As String, ByVal EskiVeri As String, ByVal YeniVeri As String, ByVal Tipi As String, ByVal Kullanici As String, ByVal KullaniciYetkiKodu As String) As Boolean
        Dim Deger As Boolean = False
        If ConnDb.State = ConnectionState.Open Then
            Try
                Dim logParamyetki(7) As SqlParameter
                logParamyetki(0) = New SqlParameter("@YetkiNo", YetkiNo)
                logParamyetki(1) = New SqlParameter("@DegisenAlan", DegisenAlan)
                logParamyetki(2) = New SqlParameter("@EskiVeri", EskiVeri)
                logParamyetki(3) = New SqlParameter("@YeniVeri", YeniVeri)
                logParamyetki(4) = New SqlParameter("@Tarih", Now)
                logParamyetki(5) = New SqlParameter("@Tipi", Tipi) ' 0:Ekleme , 1:Değiştirme , 2:Silme
                logParamyetki(6) = New SqlParameter("@Kullanici", Kullanici)
                logParamyetki(7) = New SqlParameter("@KullaniciYetkiKodu", KullaniciYetkiKodu)

                Dim QKayit As New SqlCommand(_logqueryyetki, ConnDb)
                QKayit.CommandTimeout = ConnDb.ConnectionTimeout
                QKayit.Parameters.AddRange(logParamyetki)
                QKayit.ExecuteNonQuery()
                Deger = True
            Catch ex As Exception
                Deger = False
            End Try
        End If
        Return Deger
    End Function

    Public Function ScalarSQL(ByVal SQLStr As String) As Long
        Dim Deger As Long = 0
        If ConnDb.State = ConnectionState.Open Then
            Try
                Dim QKayit As New SqlCommand(SQLStr, ConnDb)
                QKayit.CommandTimeout = ConnDb.ConnectionTimeout
                Deger = QKayit.ExecuteScalar
            Catch ex As Exception
                Deger = 0
            End Try
        End If
        Return Deger
    End Function

    Public Function ScalarSQL(ByVal SQLStr As String, ByVal QParam() As SqlParameter) As Long
        Dim Deger As Long = 0
        If ConnDb.State = ConnectionState.Open Then
            Try
                Dim QKayit As New SqlCommand(SQLStr, ConnDb)
                QKayit.CommandTimeout = ConnDb.ConnectionTimeout
                QKayit.Parameters.AddRange(QParam)
                Deger = QKayit.ExecuteScalar
                QKayit.Parameters.Clear()
            Catch ex As Exception
                Deger = 0
            End Try
        End If
        Return Deger
    End Function


End Class
