Imports MySql.Data.MySqlClient
Public Class statistique
    Dim active_ajoutation As Boolean = False
    Private Sub statistique_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        
        dtfiliere.Clear()
        adapter = New MySqlDataAdapter("select NomF from filiere  ", cn)
        adapter.Fill(dtfiliere)
        ComboBox1.DataSource = dtfiliere
        ComboBox1.DisplayMember = "NomF"
        Dim cmd2 As MySqlCommand
        cmd2 = New MySqlCommand("select DATE_FORMAT(a.date, '%m') as mois,(count(a.N_etudiant))*2 as nbr from   absance a group by DATE_FORMAT(a.date, '%m') ", cn)
        cn.Open()
        Dim num As MySqlDataReader = cmd2.ExecuteReader
        While num.Read()
            Chart1.Series("Tous ESTG").Points.AddXY(num.GetString("mois"), num.GetUInt64("nbr"))
        End While


        cn.Close()

        active_ajoutation = True


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        If active_ajoutation = True Then




            If Chart1.Series.IsUniqueName(ComboBox1.Text) And ComboBox1.Text <> "" Then
                Chart1.Series.Add(ComboBox1.Text)
                Dim cmd2 As MySqlCommand
                cmd2 = New MySqlCommand("select DATE_FORMAT(a.date, '%m') as mois,(count(a.N_etudiant))*2 as nbr from   absance a WHERE filiere='" + ComboBox1.Text + "' group by DATE_FORMAT(a.date, '%m')", cn)
                cn.Open()
                Dim num As MySqlDataReader = cmd2.ExecuteReader
                While num.Read()
                    Chart1.Series(ComboBox1.Text).Points.AddXY(num.GetString("mois"), num.GetUInt64("nbr"))
                End While


                cn.Close()
            End If


        End If
    End Sub

    Private Sub BunifuThinButton21_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton21.Click
        Try
            Chart1.Series.Remove(Chart1.Series(ComboBox1.Text))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        


    End Sub

    Private Sub ComboBox1_Click(sender As System.Object, e As System.EventArgs) Handles ComboBox1.Click

    End Sub
End Class
