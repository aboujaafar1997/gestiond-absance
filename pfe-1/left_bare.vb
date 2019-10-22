Public Class left_bare

    Private Sub PictureBox11_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox11.Click

    End Sub
    Private Sub PictureBox4_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Private Sub PictureBox6_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Private Sub PictureBox8_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Private Sub BunifuImageButton1_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Private Sub PictureBox13_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox13.Click

    End Sub
    Private Sub BunifuCustomLabel3_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Private Sub BunifuCustomLabel4_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Private Sub BunifuCustomLabel7_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    Private Sub BunifuCustomLabel8_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel8.Click
        Panel1.Left = BunifuCustomLabel8.Top
        Panel1.Height = BunifuCustomLabel8.Height
        pricipale1.Utilisateur1.BringToFront()
        pricipale1.Utilisateur1.Visible = False
        pricipale1.BunifuTransition1.ShowSync(pricipale1.Utilisateur1)
        Me.Visible = False

    End Sub
    Private Sub BunifuCustomLabel10_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel10.Click
        Panel1.Left = BunifuCustomLabel10.Top
        Panel1.Height = BunifuCustomLabel10.Height
        pricipale1.Historique2.BringToFront()
        pricipale1.Historique2.Visible = False
        pricipale1.BunifuTransition1.ShowSync(pricipale1.Historique2)
        Me.Visible = False
    End Sub
    Private Sub UserControl1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BunifuImageButton2_Click(sender As System.Object, e As System.EventArgs) Handles BunifuImageButton2.Click

        Me.Visible = False

    End Sub

    Private Sub BunifuCustomLabel4_Click_1(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel4.Click
        Panel1.Left = BunifuCustomLabel4.Top
        Panel1.Height = BunifuCustomLabel4.Height
        pricipale1.Feliere11.BringToFront()
        pricipale1.Feliere11.Visible = False
        pricipale1.BunifuTransition1.ShowSync(pricipale1.Feliere11)
        Me.Visible = False

    End Sub

    Private Sub BunifuCustomLabel2_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel2.Click
        Panel1.Top = BunifuCustomLabel2.Top
        Panel1.Height = BunifuCustomLabel2.Height
        pricipale1.Etudient3.BringToFront()
        pricipale1.Etudient3.Visible = False
        pricipale1.BunifuTransition1.ShowSync(pricipale1.Etudient3)
        Me.Visible = False
    End Sub

    Private Sub BunifuCustomLabel5_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel5.Click
        Panel1.Top = BunifuCustomLabel5.Top
        Panel1.Height = BunifuCustomLabel5.Height
        pricipale1.Matiere1.BringToFront()
        pricipale1.Matiere1.Visible = False
        pricipale1.BunifuTransition1.ShowSync(pricipale1.Matiere1)
        Me.Visible = False
    End Sub

    Private Sub BunifuCustomLabel9_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel9.Click
        Panel1.Left = BunifuCustomLabel9.Top
        Panel1.Height = BunifuCustomLabel9.Height
        pricipale1.Statistique1.BringToFront()
        pricipale1.Statistique1.Visible = False
        pricipale1.BunifuTransition1.ShowSync(pricipale1.Statistique1)
        Me.Visible = False
    End Sub

    Private Sub BunifuCustomLabel3_Click_1(sender As System.Object, e As System.EventArgs)
        Panel1.Left = BunifuCustomLabel3.Top
        Panel1.Height = BunifuCustomLabel3.Height
        pricipale1.Absance_11.BringToFront()
        pricipale1.Absance_11.Visible = False
        pricipale1.BunifuTransition1.ShowSync(pricipale1.Absance_11)
        Me.Visible = False
    End Sub

    Private Sub BunifuCustomLabel7_Click_1(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel7.Click
        Panel1.Left = BunifuCustomLabel7.Top
        Panel1.Height = BunifuCustomLabel7.Height
        pricipale1.Professeur1.BringToFront()
        pricipale1.Professeur1.Visible = False
        pricipale1.BunifuTransition1.ShowSync(pricipale1.Professeur1)
        Me.Visible = False
    End Sub

    Private Sub BunifuCustomLabel3_Click_2(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel3.Click
        Panel1.Left = BunifuCustomLabel3.Top
        Panel1.Height = BunifuCustomLabel3.Height
        pricipale1.Absance_11.BringToFront()
        pricipale1.Absance_11.Visible = False
        pricipale1.BunifuTransition1.ShowSync(pricipale1.Absance_11)
        Me.Visible = False
    End Sub
End Class
