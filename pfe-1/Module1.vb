Imports MySql.Data.MySqlClient
Module Module1
    Public cn As New MySqlConnection("server=127.0.0.1; port=3306; database= gestionabscence; uid=root; password=")
    Public adapter As MySqlDataAdapter
    Public dt1 As New DataTable
    Public cmd As MySqlCommand
    Public lodin As Integer = 1
    Public passe As String
    Public dtfiliere As New DataTable
    Public dtmat As New DataTable
    Public dtelev As New DataTable
    Public dtprofeseur As New DataTable
    Public nomtof As String

    Public Function sha256(ByVal hach As String) As String
        Dim objimplsercry As New Security.Cryptography.SHA1CryptoServiceProvider
        Dim bytestring() As Byte = System.Text.Encoding.ASCII.GetBytes(hach)
        bytestring = objimplsercry.ComputeHash(bytestring)
        Dim finalstring As String = Nothing
        For Each bt As Byte In bytestring
            finalstring &= bt.ToString
        Next
        Return finalstring
    End Function


End Module
