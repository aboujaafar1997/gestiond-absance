Imports System.Threading
Imports MySql.Data.MySqlClient

Public Class utilisateur

    Private Sub BunifuCustomDataGrid1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub utilisateur_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim dtuser As New DataTable
        adapter = New MySqlDataAdapter("select * from utilisateur", cn)
        adapter.Fill(dtuser)
        Me.BunifuCustomDataGrid1.DataSource = dtuser
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        BunifuCustomDataGrid1.Size = New System.Drawing.Size(704, 625)
        BunifuCustomDataGrid1.Location = New Point(582, 10)
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        BunifuCustomDataGrid1.Size = New System.Drawing.Size(1027, 669)
        BunifuCustomDataGrid1.Location = New Point(0, 39)
      
    End Sub

    Private Sub BunifuThinButton21_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton21.Click
        Try
            Dim cmd As MySqlCommand
            cmd = New MySqlCommand("INSERT INTO utilisateur values (@CIN, @ID, @PWD)", cn)
            cmd.Parameters.Add(New MySqlParameter("@CIN", MySqlDbType.VarChar, 30)).Value = BunifuMaterialTextbox3.Text
            cmd.Parameters.Add(New MySqlParameter("@ID", MySqlDbType.VarChar, 30)).Value = BunifuMaterialTextbox1.Text
            cmd.Parameters.Add(New MySqlParameter("@PWD", MySqlDbType.VarChar, 60)).Value = sha256(BunifuMaterialTextbox2.Text)


            cn.Open()

            cmd.ExecuteNonQuery()
            notification.Show()
            BunifuMaterialTextbox1.Text = ""
            BunifuMaterialTextbox2.Text = ""
            Dim dtuser As New DataTable
            adapter = New MySqlDataAdapter("select * from utilisateur", cn)
            adapter.Fill(dtuser)
            Me.BunifuCustomDataGrid1.DataSource = dtuser

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        cn.Close()
    End Sub

    Private Sub BunifuThinButton22_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton22.Click
        Try
            Dim a As Integer
            a = MsgBox("suprimer", 33, "suprimer")
            If a = 1 Then
                cmd = New MySqlCommand("delete from utilisateur where CIN = '" + BunifuCustomDataGrid1.CurrentRow.Cells(0).Value + "'", cn)
                cn.Open()
                cmd.ExecuteNonQuery()

                notification.Show()
                Dim dtuser As New DataTable
                adapter = New MySqlDataAdapter("select * from utilisateur", cn)
                adapter.Fill(dtuser)
                Me.BunifuCustomDataGrid1.DataSource = dtuser

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BunifuThinButton25_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton25.Click
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

    Private Sub BunifuThinButton23_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Dim dtabsance As New DataTable
        adapter = New MySqlDataAdapter("select * from utilisateur", cn)
        adapter.Fill(dtabsance)
        Dim dtc As DataTable = dtabsance.Copy
        Dim dv As DataView = dtc.DefaultView
        Try
            dv.RowFilter = "ID+PWD like '%" & TextBox1.Text & "%'"
            BunifuCustomDataGrid1.DataSource = dv

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BunifuCustomDataGrid1_DoubleClick(sender As System.Object, e As System.EventArgs)
        Dim mot As String = BunifuCustomDataGrid1.CurrentRow.Cells(1).Value
        MsgBox("ID :" + BunifuCustomDataGrid1.CurrentRow.Cells(0).Value + vbCrLf + "le mote de passe :" + sha256(mot))
    End Sub
End Class


