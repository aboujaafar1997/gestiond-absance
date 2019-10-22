Imports MySql.Data.MySqlClient
Public Class feliere1

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        BunifuCustomDataGrid1.Size = New System.Drawing.Size(757, 660)
        BunifuCustomDataGrid1.Location = New Point(529, -14)
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        BunifuCustomDataGrid1.Size = New System.Drawing.Size(1027, 669)
        BunifuCustomDataGrid1.Location = New Point(0, 39)
    End Sub

    Private Sub feliere1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Threading.Thread.Sleep(100)
        dtfiliere.Clear()

        adapter = New MySqlDataAdapter("select f.NomF,count(e.nom) as nbr from filiere f ,etudiant e where e.filiere=f.NomF group by f.NomF ", cn)
        adapter.Fill(dtfiliere)
        Me.BunifuCustomDataGrid1.DataSource = dtfiliere

    End Sub

    Private Sub BunifuThinButton21_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton21.Click
        Try
            Dim cmd As MySqlCommand
            cmd = New MySqlCommand("INSERT INTO filiere values (@NomF)", cn)
            Dim cmd2 As MySqlCommand
            cmd2 = New MySqlCommand("INSERT INTO filiere values (@NomF)", cn)
            cmd.Parameters.Add(New MySqlParameter("@NomF", MySqlDbType.VarChar, 20)).Value = BunifuMaterialTextbox1.Text

            cmd2.Parameters.Add(New MySqlParameter("@NomF", MySqlDbType.VarChar, 20)).Value = BunifuMaterialTextbox1.Text + "2"
            cn.Open()
            cmd.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()

            notification.Show()
            BunifuMaterialTextbox1.Text = ""
            dtfiliere.Clear()
            adapter = New MySqlDataAdapter("select f.NomF,count(e.nom) as nbr from filiere f ,etudiant e where e.filiere=f.NomF group by f.NomF ", cn)
            adapter.Fill(dtfiliere)
            Me.BunifuCustomDataGrid1.DataSource = dtfiliere

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        cn.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Dim dtc As DataTable = dtfiliere.Copy
        Dim dv As DataView = dtc.DefaultView
        Try
            dv.RowFilter = "Nomf like '%" & TextBox1.Text & "%'"
            BunifuCustomDataGrid1.DataSource = dv

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub BunifuThinButton22_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton22.Click
        Try
            Dim a As Integer
            a = MsgBox("suprimer", 33, "suprimer")
            If a = 1 Then
                cmd = New MySqlCommand("delete from filiere where NomF= '" + BunifuCustomDataGrid1.CurrentRow.Cells(0).Value + "'", cn)
                cn.Open()

                cmd.ExecuteNonQuery()

                notification.Show()


                adapter = New MySqlDataAdapter("select * from matiere", cn)
                adapter.Fill(dtmat)
                Me.BunifuCustomDataGrid1.DataSource = dtmat

            End If
        Catch ex As Exception
        End Try
        cn.Close()

    End Sub
End Class
