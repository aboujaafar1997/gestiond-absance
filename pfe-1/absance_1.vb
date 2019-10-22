Imports MySql.Data.MySqlClient
Imports System.Threading
Imports System.IO
Public Class absance_1
    Private Sub BunifuThinButton21_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub BunifuThinButton21_Click_1(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton21.Click
        If ((BunifuCustomDataGrid1.Columns.Count = 0) Or (BunifuCustomDataGrid1.Rows.Count = 0)) Then
            Exit Sub
        End If
        Dim dset As New DataSet
        'create datatable
        dset.Tables.Add()
        'ajouter des colones
        For i As Integer = 0 To BunifuCustomDataGrid1.ColumnCount - 1
            dset.Tables(0).Columns.Add(BunifuCustomDataGrid1.Columns(i).HeaderText)
        Next
        'ajouter les lines a datatable
        Dim dr1 As DataRow
        For i As Integer = 0 To BunifuCustomDataGrid1.RowCount - 1
            dr1 = dset.Tables(0).NewRow
            For j As Integer = 0 To BunifuCustomDataGrid1.Columns.Count - 1
                dr1(j) = BunifuCustomDataGrid1.Rows(i).Cells(j).Value
            Next
            dset.Tables(0).Rows.Add(dr1)
        Next

        Dim excel As New Microsoft.Office.Interop.Excel.Application
        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

        wBook = excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()

        Dim dt As System.Data.DataTable = dset.Tables(0)
        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0

        For Each dc In dt.Columns
            colIndex = colIndex + 1
            excel.Cells(1, colIndex) = dc.ColumnName
        Next

        For Each dr In dt.Rows
            rowIndex = rowIndex + 1
            colIndex = 0
            For Each dc In dt.Columns
                colIndex = colIndex + 1
                excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)

            Next
        Next
        Dim r As New Random
        wSheet.Columns.AutoFit()
        Dim strFileName As String = "C:\Users\othmane\Desktop\" + Date.Now.Month.ToString + Date.Now.Second.ToString + ".xlsx"
        Dim blnFileOpen As Boolean = False
        Try
            Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
            fileTemp.Close()
        Catch ex As Exception
            blnFileOpen = False
        End Try

        If System.IO.File.Exists(strFileName) Then
            System.IO.File.Delete(strFileName)
        End If

        If System.IO.File.Exists(strFileName) Then
            System.IO.File.Delete(strFileName)
        End If
        wBook.SaveAs(strFileName)
        excel.Workbooks.Open(strFileName)
        excel.Visible = True
        MsgBox("enregistre avec le nom " + Date.Now.Day.ToString + Date.Now.Second.ToString + ".xlsx")
    End Sub

    Private Sub BunifuThinButton22_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton22.Click
        Try
            Dim a As Integer
            a = MsgBox("suprimer", 33, "suprimer")
            If a = 1 Then
                cmd = New MySqlCommand("delete from absance where n= " & BunifuCustomDataGrid1.CurrentRow.Cells(0).Value, cn)
                cn.Open()
                cmd.ExecuteNonQuery()

                notification.Show()


            End If
        Catch ex As Exception
        End Try
        cn.Close()
        Try
            Dim cmd2 As MySqlCommand
            Dim cmd3 As MySqlCommand
            cmd2 = New MySqlCommand("update etudiant set nbr_pou_msg=nbr_pou_msg-2 where Num_inscription=" & BunifuCustomDataGrid1.CurrentRow.Cells(3).Value, cn)
            cmd3 = New MySqlCommand("update etudiant set nomber_abs=nomber_abs-2 where Num_inscription=" & BunifuCustomDataGrid1.CurrentRow.Cells(3).Value, cn)
            cn.Open()
            cmd2.ExecuteNonQuery()
            cmd3.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
 
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Dim dtabsance As New DataTable
        adapter = New MySqlDataAdapter("select * from absance", cn)
        adapter.Fill(dtabsance)
        Dim dtc As DataTable = dtabsance.Copy
        Dim dv As DataView = dtc.DefaultView
        Try
            dv.RowFilter = "n+n_prof+nom_prof+n_etudiant+nom_etudiant+matiere+type+heur+date+note+filiere like '%" & TextBox1.Text & "%'"
            BunifuCustomDataGrid1.DataSource = dv

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        'Dim dtabsance2 As New DataTable
        'adapter = New MySqlDataAdapter("select * from absance where filiere=@filiere ", cn)
        'adapter.SelectCommand.Parameters.Add(New MySqlParameter("@filiere", MySqlDbType.VarChar, 15)).Value = ComboBox2.Text
        'adapter.Fill(dtabsance2)
        'Me.BunifuCustomDataGrid1.DataSource = dtabsance2

    End Sub

    Private Sub BunifuThinButton23_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton23.Click
        Dim dtabsance As New DataTable
        adapter = New MySqlDataAdapter("select * from absance", cn)
        adapter.Fill(dtabsance)
        Me.BunifuCustomDataGrid1.DataSource = dtabsance
    End Sub

    Private Sub absance_1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim dtabsance As New DataTable
        adapter = New MySqlDataAdapter("select * from absance", cn)
        adapter.Fill(dtabsance)
        Me.BunifuCustomDataGrid1.DataSource = dtabsance
    End Sub

    Private Sub BunifuThinButton24_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton24.Click
        OpenFileDialog1.Filter = "All Image | *.JPG; *.PNG"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If

        Dim ms As New MemoryStream
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        Dim pictuure() As Byte = ms.ToArray

        Try
            Dim cmd As New MySqlCommand
            cmd = New MySqlCommand("update absance set Justification=@Justification where n=" & BunifuCustomDataGrid1.CurrentRow.Cells(0).Value, cn)
            cmd.Parameters.Add(New MySqlParameter("@Justification", MySqlDbType.LongBlob)).Value = pictuure

            cn.Open()
            cmd.ExecuteNonQuery()
            notification.Show()
            cn.Close()
        Catch ex As Exception

        End Try
        Try
            Dim cmd2 As MySqlCommand
            Dim cmd3 As MySqlCommand
            cmd2 = New MySqlCommand("update etudiant set nbr_pou_msg=nbr_pou_msg-2 where Num_inscription='" + BunifuCustomDataGrid1.CurrentRow.Cells(3).Value + "'", cn)
            cmd3 = New MySqlCommand("update etudiant set nomber_abs=nomber_abs-2 where Num_inscription='" + BunifuCustomDataGrid1.CurrentRow.Cells(3).Value + "'", cn)
            cn.Open()
            cmd2.ExecuteNonQuery()
            cmd3.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub BunifuCustomDataGrid1_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomDataGrid1.Click

        cmd = New MySqlCommand("select justification from absance where n=" & BunifuCustomDataGrid1.CurrentRow.Cells(0).Value, cn)
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim dr As MySqlDataReader = cmd.ExecuteReader
        dr.Read()
        If dr.Item(0).ToString <> Nothing Then
            Dim pictcure() As Byte = CType(dr(0), Byte())
            Dim ms As New System.IO.MemoryStream(pictcure)
            PictureBox1.Image = Image.FromStream(ms)
        Else
            PictureBox1.Image = Nothing


        End If
        cn.Close()
    End Sub
End Class
