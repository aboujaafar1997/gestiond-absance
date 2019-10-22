Imports MySql.Data.MySqlClient
Public Class Ajouteru

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()

    End Sub

    Private Sub Ajouteru_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Label5.Text = pricipale1.Label1.Text
        ComboBox3.DataSource = dtmat
        ComboBox3.DisplayMember = "Nom_mat"
        ComboBox1.Items.Add("cours")
        ComboBox1.Items.Add("TD")
        ComboBox1.Items.Add("TP")
        ComboBox4.Items.Add("8-10")
        ComboBox4.Items.Add("10-12")
        ComboBox4.Items.Add("14-16")
        ComboBox4.Items.Add("16-18")



    End Sub

    Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub Label5_Click(sender As System.Object, e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub BunifuThinButton21_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton21.Click
        Try
            Dim cmd As MySqlCommand
            cmd = New MySqlCommand("INSERT INTO absance(n_prof, nom_prof, n_etudiant, nom_etudiant, filiere, matiere, type, heur, date, note) values (@n_prof, @nom_prof, @n_etudiant, @nom_etudiant, @filiere, @matiere, @type, @heur, @date, @note)", cn)
            cmd.Parameters.Add(New MySqlParameter("@n_prof", MySqlDbType.VarChar, 30)).Value = Label10.Text
            cmd.Parameters.Add(New MySqlParameter("@nom_prof", MySqlDbType.VarChar, 30)).Value = Label5.Text
            cmd.Parameters.Add(New MySqlParameter("@n_etudiant", MySqlDbType.VarChar, 30)).Value = Label9.Text
            cmd.Parameters.Add(New MySqlParameter("@nom_etudiant", MySqlDbType.VarChar, 30)).Value = Label1.Text
            cmd.Parameters.Add(New MySqlParameter("@filiere", MySqlDbType.VarChar, 30)).Value = Label13.Text
            cmd.Parameters.Add(New MySqlParameter("@matiere", MySqlDbType.VarChar, 30)).Value = ComboBox3.Text
            cmd.Parameters.Add(New MySqlParameter("@type", MySqlDbType.VarChar, 30)).Value = ComboBox1.Text
            cmd.Parameters.Add(New MySqlParameter("@heur", MySqlDbType.VarChar, 30)).Value = ComboBox4.Text
            cmd.Parameters.Add(New MySqlParameter("@date", MySqlDbType.Date)).Value = BunifuDatepicker1.Value
            cmd.Parameters.Add(New MySqlParameter("@note", MySqlDbType.VarChar, 30)).Value = TextBox1.Text

            Dim cmd2 As MySqlCommand
            Dim cmd3 As MySqlCommand
            cmd2 = New MySqlCommand("update etudiant set nbr_pou_msg=nbr_pou_msg+2 where Num_inscription='" + Label9.Text + "'", cn)
            cmd3 = New MySqlCommand("update etudiant set nomber_abs=nomber_abs+2 where Num_inscription='" + Label9.Text + "'", cn)






            cn.Open()
            cmd3.ExecuteNonQuery()
            cmd2.ExecuteNonQuery()
            cmd.ExecuteNonQuery()


            notification.Show()
            cn.Close()
            Me.Close()

     

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        cn.Close()
    End Sub

    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged

    End Sub

    Private Sub Label10_Click(sender As System.Object, e As System.EventArgs) Handles Label10.Click

    End Sub
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Private Sub Panelm_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Panelm.MouseDown 'changer le mouvement dans le bureau..tal la fin'
        drag = True
        mousex = Windows.Forms.Cursor.Position.X
        mousey = Windows.Forms.Cursor.Position.Y

    End Sub

    Private Sub Panelm_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Panelm.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey

            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If

    End Sub

    Private Sub Panelm_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Panelm.MouseUp
        drag = False

    End Sub
End Class