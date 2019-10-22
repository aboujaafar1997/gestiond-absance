Imports MySql.Data.MySqlClient
Imports System.Threading
Imports System.IO
Imports System.Speech.Synthesis


Public Class Etudient

    Public Sub BunifuMaterialTextbox1_OnValueChanged(sender As System.Object, e As System.EventArgs) Handles BunifuMaterialTextbox1.OnValueChanged

    End Sub

    Private Sub BunifuDropdown1_onItemSelected(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub BunifuMaterialTextbox6_OnValueChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub BunifuDatepicker1_onValueChanged(sender As System.Object, e As System.EventArgs) Handles BunifuDatepicker1.onValueChanged

    End Sub
    Sub data_remplir()
        adapter = New MySqlDataAdapter("select * from etudiant", cn)
        adapter.Fill(dtelev)
        Me.BunifuCustomDataGrid1.DataSource = dtelev
    End Sub
    Private Sub Etudient_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        adapter = New MySqlDataAdapter("select NomF from filiere  ", cn)
        adapter.Fill(dtfiliere)
      
        BunifuCustomDataGrid1.Visible = True
        data_remplir()
        ComboBox2.DataSource = dtfiliere
        ComboBox2.DisplayMember = "NomF"
        BunifuThinButton26.Visible = False
      


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)




    End Sub

    Private Sub BunifuCustomDataGrid1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As System.Object, e As System.EventArgs) Handles BunifuFlatButton1.Click
        OpenFileDialog1.Filter = "All Image | *.JPG; *.PNG"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If

    End Sub

    Private Sub BunifuMaterialTextbox2_OnValueChanged(sender As System.Object, e As System.EventArgs) Handles BunifuMaterialTextbox2.OnValueChanged

    End Sub

    Private Sub BunifuMaterialTextbox3_OnValueChanged(sender As System.Object, e As System.EventArgs) Handles BunifuMaterialTextbox3.OnValueChanged

    End Sub

    Private Sub BunifuMaterialTextbox4_OnValueChanged(sender As System.Object, e As System.EventArgs) Handles BunifuMaterialTextbox4.OnValueChanged

    End Sub

    Private Sub BunifuMaterialTextbox5_OnValueChanged(sender As System.Object, e As System.EventArgs) Handles BunifuMaterialTextbox5.OnValueChanged

    End Sub


    Private Sub BunifuCustomLabel6_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel6.Click

    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        ComboBox1.Visible = False



        BunifuCustomDataGrid1.Size = New System.Drawing.Size(732, 690)
        BunifuCustomDataGrid1.Location = New Point(554, 18)
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            ComboBox1.Visible = True
            BunifuCustomDataGrid1.Size = New System.Drawing.Size(1027, 669)
            BunifuCustomDataGrid1.Location = New Point(0, 39)

        End If


    End Sub

    Private Sub BunifuThinButton21_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton21.Click
        Dim ms As New MemoryStream
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        Dim pictuure() As Byte = ms.ToArray
        ms.Close()

        Try
            Dim cmd As MySqlCommand
            cmd = New MySqlCommand("INSERT INTO etudiant(Num_inscription, nom, prenom, telephone ,E_mail, adresse, filiere, CIN, date, image) values (@Num_inscription, @nom, @prenom, @telephone, @E_mail, @adresse, @filiere, @CIN, @date, @image)", cn)
            cmd.Parameters.Add(New MySqlParameter("@Num_inscription", MySqlDbType.VarChar, 100)).Value = BunifuMaterialTextbox1.Text
            cmd.Parameters.Add(New MySqlParameter("@nom", MySqlDbType.VarChar, 15)).Value = BunifuMaterialTextbox2.Text
            cmd.Parameters.Add(New MySqlParameter("@prenom", MySqlDbType.VarChar, 15)).Value = BunifuMaterialTextbox3.Text
            cmd.Parameters.Add(New MySqlParameter("@telephone", MySqlDbType.VarChar, 20)).Value = BunifuMaterialTextbox5.Text
            cmd.Parameters.Add(New MySqlParameter("@E_mail", MySqlDbType.VarChar, 60)).Value = BunifuMaterialTextbox4.Text
            cmd.Parameters.Add(New MySqlParameter("@adresse", MySqlDbType.VarChar, 25)).Value = BunifuMaterialTextbox6.Text
            cmd.Parameters.Add(New MySqlParameter("@filiere", MySqlDbType.VarChar, 15)).Value = ComboBox2.Text
            cmd.Parameters.Add(New MySqlParameter("@CIN", MySqlDbType.VarChar, 20)).Value = BunifuMaterialTextbox7.Text
            cmd.Parameters.Add(New MySqlParameter("@date", MySqlDbType.Date)).Value = BunifuDatepicker1.Value
            cmd.Parameters.Add(New MySqlParameter("@image", MySqlDbType.LongBlob)).Value = pictuure


            cn.Open()

            cmd.ExecuteNonQuery()
            notification.Show()
            BunifuMaterialTextbox1.Text = ""
            BunifuMaterialTextbox2.Text = ""
            BunifuMaterialTextbox3.Text = ""
            BunifuMaterialTextbox4.Text = ""
            BunifuMaterialTextbox5.Text = ""
            BunifuMaterialTextbox7.Text = ""
            ComboBox2.Text = ""
            PictureBox1.Image = Nothing
            data_remplir()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        cn.Close()

    End Sub

    Private Sub BunifuCustomLabel3_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel3.Click

    End Sub

    Private Sub BunifuCustomDataGrid1_CellContentClick_1(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

            Dim dtelev2 As New DataTable
            adapter = New MySqlDataAdapter("select * from etudiant where filiere=@filiere ", cn)
            adapter.SelectCommand.Parameters.Add(New MySqlParameter("@filiere", MySqlDbType.VarChar, 15)).Value = ComboBox1.Text
            adapter.Fill(dtelev2)
            Me.BunifuCustomDataGrid1.DataSource = dtelev2

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        
    End Sub

    Private Sub BunifuCustomDataGrid1_CellContentClick_2(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub BunifuCustomDataGrid1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles BunifuCustomDataGrid1.DoubleClick

        Dim ms As New System.IO.MemoryStream
        cmd = New MySqlCommand("select image from etudiant where Num_inscription='" + BunifuCustomDataGrid1.CurrentRow.Cells(0).Value + "'", cn)
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
        cn.Open()
        Dim dr As MySqlDataReader = cmd.ExecuteReader
        dr.Read()
        If dr.Item(0).ToString <> Nothing Then
            Dim pictcure() As Byte = CType(dr(0), Byte())
            ms = New System.IO.MemoryStream(pictcure)
            Ajouteru.PictureBox2.Image = Image.FromStream(ms)
            fiche_etudiant.PictureBox2.Image = Image.FromStream(ms)

        End If
        cn.Close()

        Dim cmd2 As New MySqlCommand
        cmd2 = New MySqlCommand("select filiere from etudiant where Num_inscription='" + BunifuCustomDataGrid1.CurrentRow.Cells(0).Value + "'", cn)
        Dim dr2 As MySqlDataReader
        cn.Open()
        dr2 = cmd2.ExecuteReader
        While dr2.Read
            Ajouteru.Label13.Text = dr2.Item(0).ToString
        End While

        cn.Close()






        If RadioButton4.Checked = True Then
            If pricipale1.Label1.Text <> "admin" Then

                cmd = New MySqlCommand("select CIN from professeur where NOM='" + pricipale1.Label1.Text + "'or NOM='" + pricipale1.Label1.Text + "'", cn)
                cn.Open()
                Dim num As MySqlDataReader = cmd.ExecuteReader
                num.Read()
                Dim n As String = CType(num(0), String)
                cn.Close()
                Ajouteru.Label10.Text = n
            Else
                Ajouteru.Label10.Text = pricipale1.Label1.Text

            End If

            Ajouteru.Label9.Text = BunifuCustomDataGrid1.CurrentRow.Cells(0).Value
            Ajouteru.Label1.Text = Me.BunifuCustomDataGrid1.CurrentRow.Cells(1).Value + " " + Me.BunifuCustomDataGrid1.CurrentRow.Cells(2).Value
            Ajouteru.Label5.Text = login.TextBox2.Text


            fiche_etudiant.BunifuGauge1.Value = ((BunifuCustomDataGrid1.CurrentRow.Cells(9).Value) * 100) / 8
            Ajouteru.Show()
        End If



        If RadioButton3.Checked = True Then 'fiche d'étudiant avec les info et le conteur'

            fiche_etudiant.BunifuCustomLabel10.Text = BunifuCustomDataGrid1.CurrentRow.Cells(0).Value.ToString
            fiche_etudiant.BunifuCustomLabel5.Text = BunifuCustomDataGrid1.CurrentRow.Cells(1).Value.ToString
            fiche_etudiant.BunifuCustomLabel6.Text = BunifuCustomDataGrid1.CurrentRow.Cells(2).Value.ToString
            fiche_etudiant.BunifuCustomLabel14.Text = BunifuCustomDataGrid1.CurrentRow.Cells(3).Value.ToString
            fiche_etudiant.BunifuCustomLabel4.Text = BunifuCustomDataGrid1.CurrentRow.Cells(4).Value.ToString
            fiche_etudiant.BunifuCustomLabel9.Text = BunifuCustomDataGrid1.CurrentRow.Cells(5).Value.ToString
            fiche_etudiant.BunifuCustomLabel12.Text = BunifuCustomDataGrid1.CurrentRow.Cells(6).Value.ToString
            fiche_etudiant.BunifuCustomLabel7.Text = BunifuCustomDataGrid1.CurrentRow.Cells(7).Value.ToString
            fiche_etudiant.BunifuGauge1.Value = ((BunifuCustomDataGrid1.CurrentRow.Cells(9).Value) * 100) / 8
            fiche_etudiant.Show()
            nomtof = BunifuCustomDataGrid1.CurrentRow.Cells(0).Value





        End If


    End Sub

    Private Sub BunifuCustomDataGrid1_CellContentClick_3(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub BunifuThinButton22_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton22.Click
        Try
            Dim a As Integer
            a = MsgBox("suprimer", 33, "suprimer")
            If a = 1 Then
                cmd = New MySqlCommand("delete from etudiant where Num_inscription = '" + BunifuCustomDataGrid1.CurrentRow.Cells(0).Value + "'", cn)
                cn.Open()
                cmd.ExecuteNonQuery()

                notification.Show()


            End If
        Catch ex As Exception
        End Try




        dtelev.Clear()
        data_remplir()
        cn.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Dim dtc As DataTable = dtelev.Copy
        Dim dv As DataView = dtc.DefaultView
        Try
            dv.RowFilter = "Num_inscription+nom+prenom+CIN like '%" & TextBox1.Text & "%'"
            BunifuCustomDataGrid1.DataSource = dv

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub BunifuThinButton23_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton23.Click
        Try
            cmd = New MySqlCommand("select image from etudiant where Num_inscription='" + BunifuCustomDataGrid1.CurrentRow.Cells(0).Value + "'", cn)
            cn.Open()
            Dim dr As MySqlDataReader = cmd.ExecuteReader
            dr.Read()
            If dr.Item(0).ToString <> Nothing Then


                Dim pictcure() As Byte = CType(dr(0), Byte())
                Dim ms As New System.IO.MemoryStream(pictcure)
                Me.PictureBox1.Image = Image.FromStream(ms)
            End If
            cn.Close()

            BunifuCustomDataGrid1.Size = New System.Drawing.Size(757, 660)
            BunifuCustomDataGrid1.Location = New Point(529, -14)
            BunifuMaterialTextbox1.Text = BunifuCustomDataGrid1.CurrentRow.Cells(0).Value.ToString
            BunifuMaterialTextbox2.Text = BunifuCustomDataGrid1.CurrentRow.Cells(1).Value.ToString
            BunifuMaterialTextbox3.Text = BunifuCustomDataGrid1.CurrentRow.Cells(2).Value.ToString
            BunifuMaterialTextbox4.Text = BunifuCustomDataGrid1.CurrentRow.Cells(3).Value.ToString
            BunifuMaterialTextbox5.Text = BunifuCustomDataGrid1.CurrentRow.Cells(4).Value.ToString
            BunifuMaterialTextbox6.Text = BunifuCustomDataGrid1.CurrentRow.Cells(5).Value.ToString
            ComboBox2.Text = BunifuCustomDataGrid1.CurrentRow.Cells(6).Value
            BunifuMaterialTextbox7.Text = BunifuCustomDataGrid1.CurrentRow.Cells(7).Value
            BunifuDatepicker1.Value = BunifuCustomDataGrid1.CurrentRow.Cells(8).Value

            BunifuThinButton26.Visible = True
            BunifuThinButton21.Visible = False






        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        


    End Sub

    Private Sub BunifuThinButton26_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton26.Click
        Dim ms As New MemoryStream
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        Dim pictuure() As Byte = ms.ToArray
        ms.Close()
        BunifuThinButton26.Visible = False
        BunifuThinButton21.Visible = True
  
        Try
            Dim cmd As MySqlCommand
            cmd = New MySqlCommand("update 	etudiant set Num_inscription=@Num_inscription, telephone=@telephone, nom=@nom, prenom=@prenom, date=@date, adresse=@adresse, filiere=@filiere, E_mail=@E_mail, CIN=@CIN, image=@image where Num_inscription='" + BunifuCustomDataGrid1.CurrentRow.Cells(0).Value + "'", cn)
            cmd.Parameters.Add(New MySqlParameter("@Num_inscription", MySqlDbType.VarChar, 100)).Value = BunifuMaterialTextbox1.Text
            cmd.Parameters.Add(New MySqlParameter("@nom", MySqlDbType.VarChar, 15)).Value = BunifuMaterialTextbox2.Text
            cmd.Parameters.Add(New MySqlParameter("@prenom", MySqlDbType.VarChar, 15)).Value = BunifuMaterialTextbox3.Text
            cmd.Parameters.Add(New MySqlParameter("@telephone", MySqlDbType.VarChar, 20)).Value = BunifuMaterialTextbox5.Text
            cmd.Parameters.Add(New MySqlParameter("@E_mail", MySqlDbType.VarChar, 60)).Value = BunifuMaterialTextbox4.Text
            cmd.Parameters.Add(New MySqlParameter("@adresse", MySqlDbType.VarChar, 25)).Value = BunifuMaterialTextbox6.Text
            cmd.Parameters.Add(New MySqlParameter("@filiere", MySqlDbType.VarChar, 15)).Value = ComboBox2.Text
            cmd.Parameters.Add(New MySqlParameter("@CIN", MySqlDbType.VarChar, 20)).Value = BunifuMaterialTextbox7.Text
            cmd.Parameters.Add(New MySqlParameter("@date", MySqlDbType.Date)).Value = BunifuDatepicker1.Value
            cmd.Parameters.Add(New MySqlParameter("@image", MySqlDbType.LongBlob)).Value = pictuure
            cn.Open()

            cmd.ExecuteNonQuery()
            dtelev.Clear()
            data_remplir()




            notification.Show()
            BunifuMaterialTextbox1.Text = ""
            BunifuMaterialTextbox2.Text = ""
            BunifuMaterialTextbox3.Text = ""
            BunifuMaterialTextbox4.Text = ""
            BunifuMaterialTextbox5.Text = ""
            BunifuMaterialTextbox7.Text = ""
            ComboBox2.Text = ""



            notification.Show()

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        cn.Close()


    End Sub

    Private Sub ComboBox1_Click(sender As System.Object, e As System.EventArgs) Handles ComboBox1.Click 'remplissage du combobox par les fili'
        ComboBox1.DataSource = dtfiliere
        ComboBox1.DisplayMember = "NomF"
    End Sub


    Private Sub BunifuCustomDataGrid1_CellContentClick_4(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton3.CheckedChanged

    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton4.CheckedChanged

    End Sub

    Private Sub BunifuMaterialTextbox6_OnValueChanged_1(sender As System.Object, e As System.EventArgs) Handles BunifuMaterialTextbox6.OnValueChanged

    End Sub

    Private Sub BunifuMaterialTextbox7_OnValueChanged(sender As System.Object, e As System.EventArgs) Handles BunifuMaterialTextbox7.OnValueChanged

    End Sub

    Private Sub BunifuCustomDataGrid1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles BunifuCustomDataGrid1.KeyDown
       


    End Sub

    Private Sub BunifuSwitch1_Click(sender As System.Object, e As System.EventArgs) Handles BunifuSwitch1.Click 'avtiver ou desa la voix par les couleurs'
        If BunifuSwitch1.Value = False Then
            BunifuSwitch1.BackColor = Color.Red

        End If
        If BunifuSwitch1.Value = True Then
            BunifuSwitch1.BackColor = Color.LimeGreen

        End If
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



    Private Sub BunifuThinButton27_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton27.Click 'actualiser'
        adapter = New MySqlDataAdapter("select NomF from filiere  ", cn)
        adapter.Fill(dtelev)
        BunifuCustomDataGrid1.DataSource = dtelev
    End Sub

    Private Sub BunifuCustomDataGrid1_CellContentClick_5(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles BunifuCustomDataGrid1.CellContentClick

    End Sub

    Private Sub BunifuCustomDataGrid1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles BunifuCustomDataGrid1.KeyPress 'la voix qui lit les noms par entrer'
        If BunifuSwitch1.Value And BunifuCustomDataGrid1.CurrentRow.Cells(1).Value <> "" And BunifuCustomDataGrid1.CurrentRow.Cells(2).Value <> "" Then
            Dim sp = New SpeechSynthesizer()
            sp.Speak(BunifuCustomDataGrid1.CurrentRow.Cells(1).Value + BunifuCustomDataGrid1.CurrentRow.Cells(2).Value)
            Threading.Thread.Sleep(100)

        End If
    End Sub

    Private Sub BunifuThinButton24_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton24.Click 'on cliquant sur l'étudiant il passe auto a la liste des et de la 2 année'
        Dim cmd As MySqlCommand
        cmd = New MySqlCommand("update etudiant set filiere=@filiere where Num_inscription='" + BunifuCustomDataGrid1.CurrentRow.Cells(0).Value + "'", cn)
        cmd.Parameters.Add(New MySqlParameter("@filiere", MySqlDbType.VarChar, 15)).Value = BunifuCustomDataGrid1.CurrentRow.Cells(6).Value + "2"
        If cn.State = ConnectionState.Open Then
            cn.Close()

        End If
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        dtelev.Clear()
        data_remplir()
        notification.Show()

    End Sub
End Class
