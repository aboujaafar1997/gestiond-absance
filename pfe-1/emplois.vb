Imports MySql.Data.MySqlClient
Imports System.Threading
Imports System.IO
Public Class emplois

    Private Sub emplois_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
     
        adapter = New MySqlDataAdapter("select NomF from filiere  ", cn)
        adapter.Fill(dtfiliere)
        ComboBox2.DataSource = dtfiliere
        ComboBox2.DisplayMember = "NomF"
        Dim dtemlois As New DataTable
        adapter = New MySqlDataAdapter("select * from emplois  ", cn)
        adapter.Fill(dtemlois)
        BunifuCustomDataGrid1.DataSource = dtemlois
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As System.Object, e As System.EventArgs) Handles BunifuFlatButton1.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            OpenFileDialog1.Filter = "All Image | *.JPG; *.PNG"
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub


    Private Sub BunifuCustomDataGrid1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub BunifuThinButton22_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton22.Click
        Dim ms As New MemoryStream
        PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
        Dim pictuure() As Byte = ms.ToArray
        ms.Close()

        Try
            Dim cmd As MySqlCommand
            cmd = New MySqlCommand("INSERT INTO emplois(NomF, image) values (@NomF,  @image)", cn)
            cmd.Parameters.Add(New MySqlParameter("@NomF", MySqlDbType.VarChar, 100)).Value = ComboBox2.Text
            cmd.Parameters.Add(New MySqlParameter("@image", MySqlDbType.LongBlob)).Value = pictuure



            cn.Open()

            cmd.ExecuteNonQuery()
            notification.Show()


            ComboBox2.Text = ""
            PictureBox1.Image = Nothing
            Dim dtemlois As New DataTable
            adapter = New MySqlDataAdapter("select * from emplois  ", cn)
            adapter.Fill(dtemlois)
            BunifuCustomDataGrid1.DataSource = dtemlois

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        cn.Close()
    End Sub

    Private Sub BunifuThinButton21_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton21.Click
        Try
            Dim a As Integer
            a = MsgBox("suprimer", 33, "suprimer")
            If a = 1 Then
                cmd = New MySqlCommand("delete from emplois where id = " & BunifuCustomDataGrid1.CurrentRow.Cells(0).Value, cn)
                cn.Open()
                cmd.ExecuteNonQuery()

                notification.Show()
                Dim dtemlois As New DataTable
                adapter = New MySqlDataAdapter("select * from emplois  ", cn)
                adapter.Fill(dtemlois)
                BunifuCustomDataGrid1.DataSource = dtemlois

            End If
        Catch ex As Exception
        End Try



        cn.Close()
    End Sub

    Private Sub PictureBox1_Click_1(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub BunifuCustomDataGrid1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles BunifuCustomDataGrid1.DoubleClick
        cmd = New MySqlCommand("select image from emplois where id=" & BunifuCustomDataGrid1.CurrentRow.Cells(0).Value, cn)
        cn.Open()
        Dim dr As MySqlDataReader = cmd.ExecuteReader
        dr.Read()
        Dim pictcure() As Byte = CType(dr(0), Byte())
        Dim ms As New System.IO.MemoryStream(pictcure)
        affiche_emplois.PictureBox3.Image = Image.FromStream(ms)
        affiche_emplois.Show()



        cn.Close()
    End Sub

    Private Sub BunifuCustomDataGrid1_CellContentClick_1(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles BunifuCustomDataGrid1.CellContentClick

    End Sub
End Class
