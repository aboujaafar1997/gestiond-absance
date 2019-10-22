Imports MySql.Data.MySqlClient
Imports System.Speech.Synthesis
Public Class login


    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox3_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox3.Click
        Me.Close()

    End Sub

    Private Sub BunifuThinButton21_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton21.Click
        Dim cin As String
        Try
            adapter = New MySqlDataAdapter("select * from utilisateur where ID = @ID and PWD = @PWD", cn)
            adapter.SelectCommand.Parameters.Add(New MySqlParameter("@ID", MySqlDbType.VarChar, 50)).Value = TextBox2.Text
            adapter.SelectCommand.Parameters.Add(New MySqlParameter("@PWD", MySqlDbType.VarChar, 50)).Value = TextBox1.Text
            adapter.Fill(dt1)  'datatable:stocker les données de la base de donnée'
            If dt1.Rows.Count > 0 Then 'vérifier si la base de donnée est pleine'
                pricipale1.Show()
                NotifyIcon1.ShowBalloonTip(20, "Beinvenu", TextBox2.Text, ToolTipIcon.Info) 'notification qui s'affiche une fois que nous sommes connecter'

                cn.Open()
                If Me.TextBox2.Text <> "admin" Then
                    'historique si ce n'est pas l'admin il doit insérer qu'il est l'utilisateur et sa
                    Dim cmd2 As MySqlCommand
                    cmd2 = New MySqlCommand("select CIN from utilisateur where ID='" + TextBox2.Text + "'", cn)


                    Dim num2 As MySqlDataReader = cmd2.ExecuteReader

                    While num2.Read()
                        cin = num2.GetString(0)

                    End While

                    Dim cmd0 As MySqlCommand
                    cmd0 = New MySqlCommand("INSERT INTO historique(CIN, Nom, date) values (@CIN, @Nom, @date)", cn)
                    cmd0.Parameters.Add(New MySqlParameter("@CIN", MySqlDbType.VarChar, 30)).Value = cin
                    cmd0.Parameters.Add(New MySqlParameter("@Nom", MySqlDbType.VarChar, 30)).Value = TextBox2.Text
                    cmd0.Parameters.Add(New MySqlParameter("@date", MySqlDbType.VarChar, 30)).Value = Date.Now.ToString

                    cn.Close()
                    cn.Open()
                    cmd0.ExecuteNonQuery()

                End If

                cn.Close()
                Close()
            Else
                MsgBox("le utilisateur ou le mote de passe incorecte !", MsgBoxStyle.Exclamation, "Ereur !!")

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
      



    End Sub

    Private Sub login_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load 'afficher c'est quoi le mdp'
        TextBox1.PasswordChar = "*"
        TextBox1.Text = "admin"
        TextBox2.Text = "admin"

    End Sub

    Private Sub PictureBox4_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox4.Click

    End Sub
    Dim a As Integer = 1
    Private Sub diaporama_Tick(sender As System.Object, e As System.EventArgs) Handles diaporama.Tick 'annimation'
        If a = 1 Then
            PictureBox4.Visible = False
            a = a * -1
        Else
            PictureBox4.Visible = True
            a = a * -1
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged 'afficher le mdp'
        If CheckBox1.Checked = True Then
            TextBox1.PasswordChar = ""
        Else
            TextBox1.PasswordChar = "*"
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim cin As String
        Try
            adapter = New MySqlDataAdapter("select * from utilisateur where ID = @ID and PWD = @PWD", cn)
            adapter.SelectCommand.Parameters.Add(New MySqlParameter("@ID", MySqlDbType.VarChar, 50)).Value = TextBox2.Text
            adapter.SelectCommand.Parameters.Add(New MySqlParameter("@PWD", MySqlDbType.VarChar, 50)).Value = sha256(TextBox1.Text)
            adapter.Fill(dt1)  'datatable:stocker les données de la base de donnée'
            If dt1.Rows.Count > 0 Then 'vérifier si la base de donnée est pleine'
                pricipale1.Show()
                pricipale1.Label1.Text = TextBox2.Text
                NotifyIcon1.ShowBalloonTip(20, "Beinvenu", TextBox2.Text, ToolTipIcon.Info) 'notification qui s'affiche une fois que nous sommes connecter'

                cn.Open()
                If Me.TextBox2.Text <> "admin" Then
                    'historique si ce n'est pas l'admin il doit insérer qu'il est l'utilisateur et sa
                    Dim cmd2 As MySqlCommand
                    cmd2 = New MySqlCommand("select CIN from utilisateur where ID='" + TextBox2.Text + "'", cn)


                    Dim num2 As MySqlDataReader = cmd2.ExecuteReader

                    While num2.Read()
                        cin = num2.GetString(0)

                    End While

                    Dim cmd0 As MySqlCommand
                    cmd0 = New MySqlCommand("INSERT INTO historique(CIN, Nom, date) values (@CIN, @Nom, @date)", cn)
                    cmd0.Parameters.Add(New MySqlParameter("@CIN", MySqlDbType.VarChar, 30)).Value = cin
                    cmd0.Parameters.Add(New MySqlParameter("@Nom", MySqlDbType.VarChar, 30)).Value = TextBox2.Text
                    cmd0.Parameters.Add(New MySqlParameter("@date", MySqlDbType.VarChar, 30)).Value = Date.Now.ToString

                    cn.Close()
                    cn.Open()
                    cmd0.ExecuteNonQuery()

                End If

                cn.Close()
                Close()
            Else
                MsgBox("le utilisateur ou le mote de passe incorecte !", MsgBoxStyle.Exclamation, "Ereur !!")

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer


    Private Sub BunifuGradientPanel1_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles BunifuGradientPanel1.MouseDown 'changer le mouvement dans le bureau..tal la fin'
        drag = True
        mousex = Windows.Forms.Cursor.Position.X
        mousey = Windows.Forms.Cursor.Position.Y

    End Sub

    Private Sub BunifuGradientPanel1_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles BunifuGradientPanel1.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey

            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If

    End Sub

    Private Sub BunifuGradientPanel1_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles BunifuGradientPanel1.MouseUp
        drag = False

    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick

    End Sub
End Class

