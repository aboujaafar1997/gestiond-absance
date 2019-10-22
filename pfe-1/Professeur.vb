Imports MySql.Data.MySqlClient
Imports System.IO
Public Class Professeur

    Private Sub Professeur_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Threading.Thread.Sleep(10)
        BunifuThinButton24.Visible = False
        adapter = New MySqlDataAdapter("select * from professeur ", cn)
        adapter.Fill(dtprofeseur)
        Me.BunifuCustomDataGrid1.DataSource = dtprofeseur


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub BunifuCustomDataGrid1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub BunifuCustomLabel1_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel1.Click

    End Sub

    Private Sub BunifuMaterialTextbox1_OnValueChanged(sender As System.Object, e As System.EventArgs) Handles BunifuMaterialTextbox1.OnValueChanged

    End Sub

    Private Sub BunifuMaterialTextbox2_OnValueChanged(sender As System.Object, e As System.EventArgs) Handles BunifuMaterialTextbox2.OnValueChanged

    End Sub

    Private Sub BunifuMaterialTextbox3_OnValueChanged(sender As System.Object, e As System.EventArgs) Handles BunifuMaterialTextbox3.OnValueChanged

    End Sub

    Private Sub BunifuMaterialTextbox4_OnValueChanged(sender As System.Object, e As System.EventArgs) Handles BunifuMaterialTextbox4.OnValueChanged

    End Sub

    Private Sub BunifuCustomLabel2_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel2.Click

    End Sub

    Private Sub BunifuCustomLabel3_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel3.Click

    End Sub

    Private Sub BunifuCustomLabel4_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel4.Click

    End Sub

    Private Sub BunifuCustomLabel6_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel6.Click

    End Sub

    Private Sub BunifuDatepicker1_onValueChanged(sender As System.Object, e As System.EventArgs) Handles BunifuDatepicker1.onValueChanged

    End Sub

    Private Sub BunifuCustomLabel7_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel7.Click

    End Sub

    Private Sub BunifuMaterialTextbox6_OnValueChanged(sender As System.Object, e As System.EventArgs) Handles BunifuMaterialTextbox6.OnValueChanged

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged

        BunifuCustomDataGrid1.Size = New System.Drawing.Size(704, 625)
        BunifuCustomDataGrid1.Location = New Point(582, 14)
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        BunifuCustomDataGrid1.Size = New System.Drawing.Size(1027, 669)
        BunifuCustomDataGrid1.Location = New Point(0, 39)
    End Sub

    Private Sub BunifuThinButton21_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton21.Click
        Dim ms As New MemoryStream
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        Dim pictuure() As Byte = ms.ToArray
        ms.Close()
        Try
            Dim cmd As MySqlCommand
            cmd = New MySqlCommand("INSERT INTO professeur(CIN, NOM, Prenom, E_mail, telephone, adresse, date, image) values (@CIN, @NOM, @Prenom, @E_mail, @telephone, @Adresse, @date, @image)", cn)
            cmd.Parameters.Add(New MySqlParameter("@CIN", MySqlDbType.VarChar, 15)).Value = BunifuMaterialTextbox6.Text
            cmd.Parameters.Add(New MySqlParameter("@NOM", MySqlDbType.VarChar, 10)).Value = BunifuMaterialTextbox1.Text
            cmd.Parameters.Add(New MySqlParameter("@Prenom", MySqlDbType.VarChar, 15)).Value = BunifuMaterialTextbox2.Text
            cmd.Parameters.Add(New MySqlParameter("@telephone", MySqlDbType.VarChar, 15)).Value = BunifuMaterialTextbox3.Text
            cmd.Parameters.Add(New MySqlParameter("@E_mail", MySqlDbType.VarChar, 25)).Value = BunifuMaterialTextbox5.Text
            cmd.Parameters.Add(New MySqlParameter("@Adresse", MySqlDbType.VarChar, 30)).Value = BunifuMaterialTextbox4.Text
            cmd.Parameters.Add(New MySqlParameter("@date", MySqlDbType.Date)).Value = BunifuDatepicker1.Value
            cmd.Parameters.Add(New MySqlParameter("@image", MySqlDbType.LongBlob)).Value = pictuure
            cn.Open()

            cmd.ExecuteNonQuery()
            dtprofeseur.Clear()

            adapter = New MySqlDataAdapter("select * from professeur ", cn)
            adapter.Fill(dtprofeseur)
            Me.BunifuCustomDataGrid1.DataSource = dtprofeseur
            notification.Show()
            BunifuMaterialTextbox1.Text = ""
            BunifuMaterialTextbox2.Text = ""
            BunifuMaterialTextbox3.Text = ""
            BunifuMaterialTextbox4.Text = ""
            BunifuMaterialTextbox5.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        cn.Close()

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As System.Object, e As System.EventArgs) Handles BunifuFlatButton1.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            OpenFileDialog1.Filter = "All Image | *.JPG; *.PNG"
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If



    End Sub

    Private Sub BunifuCustomDataGrid1_CellContentClick_1(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Dim dtc As DataTable = dtprofeseur.Copy
        Dim dv As DataView = dtc.DefaultView
        Try
            dv.RowFilter = " CIN+NOM+Prenom+date+telephone+Adresse+E_mail like '%" & TextBox1.Text & "%'"
            BunifuCustomDataGrid1.DataSource = dv

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub BunifuCustomLabel8_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel8.Click

    End Sub

    Private Sub BunifuThinButton24_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton24.Click
        Dim ms As New MemoryStream
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        Dim pictuure() As Byte = ms.ToArray
        ms.Close()
        BunifuThinButton24.Visible = False
        BunifuThinButton21.Visible = True

        Try
            Dim cmd As MySqlCommand
            cmd = New MySqlCommand("update 	professeur set CIN=@CIN, telephone=@telephone, NOM=@NOM, Prenom=@Prenom, date=@date, Adresse=@Adresse, filiere=@filiere, E_mail=@E_mail, CIN=@CIN, image=@image where CIN='" & +BunifuCustomDataGrid1.CurrentRow.Cells(0).Value + "'", cn)
            cmd.Parameters.Add(New MySqlParameter("@CIN", MySqlDbType.VarChar, 100)).Value = BunifuMaterialTextbox6.Text
            cmd.Parameters.Add(New MySqlParameter("@NOM", MySqlDbType.VarChar, 15)).Value = BunifuMaterialTextbox1.Text
            cmd.Parameters.Add(New MySqlParameter("@Prenom", MySqlDbType.VarChar, 15)).Value = BunifuMaterialTextbox2.Text
            cmd.Parameters.Add(New MySqlParameter("@telephone", MySqlDbType.VarChar, 20)).Value = BunifuMaterialTextbox3.Text
            cmd.Parameters.Add(New MySqlParameter("@E_mail", MySqlDbType.VarChar, 60)).Value = BunifuMaterialTextbox5.Text
            cmd.Parameters.Add(New MySqlParameter("@Adresse", MySqlDbType.VarChar, 25)).Value = BunifuMaterialTextbox4.Text
            cmd.Parameters.Add(New MySqlParameter("@date", MySqlDbType.Date)).Value = BunifuDatepicker1.Value
            cmd.Parameters.Add(New MySqlParameter("@image", MySqlDbType.LongBlob)).Value = pictuure
            cn.Open()

            cmd.ExecuteNonQuery()
            dtelev.Clear()




            notification.Show()
            dtprofeseur.Clear()

            adapter = New MySqlDataAdapter("select * from professeur ", cn)
            adapter.Fill(dtprofeseur)
            Me.BunifuCustomDataGrid1.DataSource = dtprofeseur
            notification.Show()







            BunifuMaterialTextbox1.Text = ""
            BunifuMaterialTextbox2.Text = ""
            BunifuMaterialTextbox3.Text = ""
            BunifuMaterialTextbox4.Text = ""
            BunifuMaterialTextbox5.Text = ""
            BunifuMaterialTextbox6.Text = ""
            PictureBox1.Image = Nothing




            notification.Show()

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
                cmd = New MySqlCommand("delete from professeur where CIN = '" + BunifuCustomDataGrid1.CurrentRow.Cells(0).Value + "'", cn)
                cn.Open()

                cmd.ExecuteNonQuery()

                notification.Show()
                dtprofeseur.Clear()

                adapter = New MySqlDataAdapter("select * from professeur ", cn)
                adapter.Fill(dtprofeseur)
                Me.BunifuCustomDataGrid1.DataSource = dtprofeseur


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

    Private Sub BunifuCustomDataGrid1_CellContentClick_2(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles BunifuCustomDataGrid1.CellContentClick

    End Sub

    Private Sub BunifuThinButton23_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton23.Click
        Try
            cmd = New MySqlCommand("select image from professeur where CIN='" + BunifuCustomDataGrid1.CurrentRow.Cells(0).Value + "'", cn)
            cn.Open()
            Dim dr As MySqlDataReader = cmd.ExecuteReader
            dr.Read()
            Dim pictcure() As Byte = CType(dr(0), Byte())
            Dim ms As New System.IO.MemoryStream(pictcure)
            cn.Close()
            Me.PictureBox1.Image = Image.FromStream(ms)
            BunifuCustomDataGrid1.Size = New System.Drawing.Size(757, 660)
            BunifuCustomDataGrid1.Location = New Point(529, -14)
            BunifuMaterialTextbox6.Text = BunifuCustomDataGrid1.CurrentRow.Cells(0).Value
            BunifuMaterialTextbox1.Text = BunifuCustomDataGrid1.CurrentRow.Cells(1).Value
            BunifuMaterialTextbox2.Text = BunifuCustomDataGrid1.CurrentRow.Cells(2).Value
            BunifuMaterialTextbox5.Text = BunifuCustomDataGrid1.CurrentRow.Cells(3).Value
            BunifuMaterialTextbox3.Text = BunifuCustomDataGrid1.CurrentRow.Cells(4).Value
            BunifuMaterialTextbox4.Text = BunifuCustomDataGrid1.CurrentRow.Cells(5).Value
            BunifuDatepicker1.Value = BunifuCustomDataGrid1.CurrentRow.Cells(6).Value

            BunifuThinButton24.Visible = True
            BunifuThinButton21.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub BunifuCustomDataGrid1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles BunifuCustomDataGrid1.DoubleClick
        cmd = New MySqlCommand("select image from professeur where CIN='" + BunifuCustomDataGrid1.CurrentRow.Cells(0).Value + "'", cn)
        cn.Open()
        Dim dr As MySqlDataReader = cmd.ExecuteReader

        dr.Read()
        If dr.Item(0).ToString <> Nothing Then
            Dim pictcure() As Byte = CType(dr(0), Byte())
            Dim ms As New System.IO.MemoryStream(pictcure)
            fiche__profvb.PictureBox2.Image = Image.FromStream(ms) 'envoyer les info vers la forme fiche'
        End If
        cn.Close()


        fiche__profvb.BunifuCustomLabel5.Text = BunifuCustomDataGrid1.CurrentRow.Cells(0).Value
        fiche__profvb.BunifuCustomLabel12.Text = BunifuCustomDataGrid1.CurrentRow.Cells(1).Value
        fiche__profvb.BunifuCustomLabel11.Text = BunifuCustomDataGrid1.CurrentRow.Cells(2).Value
        fiche__profvb.BunifuCustomLabel14.Text = BunifuCustomDataGrid1.CurrentRow.Cells(3).Value
        fiche__profvb.BunifuCustomLabel10.Text = BunifuCustomDataGrid1.CurrentRow.Cells(4).Value
        fiche__profvb.BunifuCustomLabel9.Text = BunifuCustomDataGrid1.CurrentRow.Cells(5).Value
        fiche__profvb.BunifuCustomLabel8.Text = BunifuCustomDataGrid1.CurrentRow.Cells(6).Value
        fiche__profvb.Show()

    End Sub
End Class
