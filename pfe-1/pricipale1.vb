Imports System.Threading
Imports MySql.Data.MySqlClient
Imports System.IO.Ports
Imports System.Speech.Synthesis


Public Class pricipale1

    Private Sub Panel2_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub BunifuCustomLabel2_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel2.Click
        'aanimation et usercontrol'

        Panel3.Left = BunifuCustomLabel2.Left
        Panel3.Width = BunifuCustomLabel2.Width
        Etudient3.BringToFront()
        Etudient3.Visible = False
        BunifuTransition1.ShowSync(Etudient3)

    End Sub

    Private Sub BunifuCustomLabel1_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel1.Click

        Panel3.Left = BunifuCustomLabel1.Left
        Panel3.Width = BunifuCustomLabel1.Width
        Emplois1.BringToFront()
        Emplois1.Visible = False
        BunifuTransition1.ShowSync(Emplois1)
    End Sub

    Private Sub BunifuCustomLabel3_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel3.Click
        Absance_11.BringToFront()
        Absance_11.Visible = False
        BunifuTransition1.ShowSync(Absance_11)


        Panel3.Left = BunifuCustomLabel3.Left
        Panel3.Width = BunifuCustomLabel3.Width
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
        parametrevb.Close()
        fiche__profvb.Close()
        fiche_etudiant.Close()
        Ajouteru.Close()
        affiche_emplois.Close()


    End Sub

    Private Sub Etudient1_Load(sender As System.Object, e As System.EventArgs)


    End Sub

    Private Sub BunifuCustomLabel4_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel4.Click

        Panel3.Left = BunifuCustomLabel4.Left
        Panel3.Width = BunifuCustomLabel4.Width
        Feliere11.BringToFront()
        Feliere11.Visible = False
        BunifuTransition1.ShowSync(Feliere11)

    End Sub

    Private Sub BunifuCustomLabel7_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel7.Click
        Panel3.Left = BunifuCustomLabel7.Left
        Panel3.Width = BunifuCustomLabel7.Width
        Professeur1.BringToFront()
        Professeur1.Visible = False
        BunifuTransition1.ShowSync(Professeur1)
    End Sub

    Private Sub BunifuCustomLabel5_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel5.Click
        Panel3.Left = BunifuCustomLabel5.Left
        Panel3.Width = BunifuCustomLabel5.Width
        Matiere1.BringToFront()
        Matiere1.Visible = False
        BunifuTransition1.ShowSync(Matiere1)
    End Sub

    Public Sub loding_Tick(sender As System.Object, e As System.EventArgs) Handles loding.Tick 'chargement'
        If lodin = 6 Then
            Absance_11.BringToFront()
            loding.Enabled = False
            Chargement1.Visible = False


        Else
            lodin += 1

        End If




    End Sub

    Private Sub PictureBox9_Click(sender As System.Object, e As System.EventArgs) 'afficher le parametre'
        parametrevb.Show()


    End Sub

    Private Sub PictureBox9_MouseEnter(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub BunifuCustomLabel2_MouseEnter(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel2.MouseEnter








    End Sub

    Private Sub BunifuImageButton1_Click(sender As System.Object, e As System.EventArgs) Handles BunifuImageButton1.Click
        parametrevb.Show()

    End Sub

    Private Sub BunifuCustomLabel6_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Chargement1_Load(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs)







    End Sub

    Private Sub pricipale1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Left_bare1.Visible = False
        Dim sp = New SpeechSynthesizer()
        sp.Speak("bienvenu monsieur " + login.TextBox2.Text) 'dire bienvenu une fois qu on cick sur verifier'

        If login.TextBox2.Text = "admin" Then
            'red xml et remplir
            Dim ds As New DataSet
            ds.ReadXml("message.xml")
            parametrevb.BunifuCustomDataGrid1.DataSource = ds.Tables(0)
            parametrevb.BunifuMetroTextbox1.Text = parametrevb.BunifuCustomDataGrid1.Rows(0).Cells(0).Value
            parametrevb.ComboBox1.Text = parametrevb.BunifuCustomDataGrid1.Rows(0).Cells(1).Value
            parametrevb.BunifuSwitch1.Value = parametrevb.BunifuCustomDataGrid1.Rows(0).Cells(2).Value

            'Message
            'port
            If SerialPort.IsOpen Then
                SerialPort.Close()

            End If

            If parametrevb.BunifuSwitch1.Value = True Then

                SerialPort.PortName = parametrevb.ComboBox1.Text
                SerialPort.BaudRate = 9600
                SerialPort.Parity = Parity.None
                SerialPort.StopBits = StopBits.One
                SerialPort.DataBits = 8
                SerialPort.Handshake = Handshake.RequestToSend
                SerialPort.DtrEnable = True
                SerialPort.RtsEnable = True
                SerialPort.NewLine = vbCrLf


                Dim q As String = "select telephone from etudiant where nbr_pou_msg>=12"
                Dim dtmsg As New DataTable
                adapter = New MySqlDataAdapter(q, cn)
                adapter.Fill(dtmsg)
                MsgBox("nbr de message quand va envoyer" & dtmsg.Rows.Count)
                If dtmsg.Rows.Count > 0 Then
                    Try
                        SerialPort.Open()
                    Catch ex As Exception
                        MsgBox("svp le modeme n'est pas dans le port '" & SerialPort.PortName & "'" & vbCrLf & "reconncte le ou choisie le port correcte")
                    End Try
                    

                    Try
                        If SerialPort.IsOpen() Then


                            For i = 0 To dtmsg.Rows.Count - 1
                                Dim tele As String = dtmsg.Rows.Item(i).Item(0)
                                MsgBox(tele)

                                With SerialPort
                                    .Write("at+cmgf=1" & vbCrLf)
                                    Threading.Thread.Sleep(100)
                                    .Write("at+cmgs=" & Chr(34) & tele & Chr(34) & vbCrLf)
                                    .Write(parametrevb.BunifuMetroTextbox1.Text & Chr(26))
                                    Threading.Thread.Sleep(100)

                                End With
                                Dim cmd As MySqlCommand
                                cmd = New MySqlCommand("update 	etudiant set nbr_pou_msg=@nbr_pou_msg where telephone=" + tele, cn)
                                cmd.Parameters.Add(New MySqlParameter("@nbr_pou_msg", MySqlDbType.Int64, 10)).Value = 0
                                cn.Close()
                                cn.Open()
                                cmd.ExecuteNonQuery()
                                If cn.State = ConnectionState.Open Then
                                    cn.Close()
                                End If
                            Next
                            MsgBox("des msg son envoyer")


                            If cn.State = ConnectionState.Open Then
                                cn.Close()


                            End If
                        End If




                    Catch ex As Exception

                        MsgBox(ex.Message)
                    End Try

                End If
            End If

        End If







        Label1.Text = login.TextBox2.Text 'ecrit le nom d'utilisateur
        If login.TextBox2.Text <> "admin" Then 'si ce n'est pas l'admin on doit afficher que les formes dont le professeur est besoin et peut accéder'
            BunifuCustomLabel10.Visible = False
            BunifuCustomLabel9.Visible = False
            BunifuCustomLabel7.Visible = False
            BunifuCustomLabel4.Visible = False
            BunifuCustomLabel8.Visible = False
            BunifuCustomLabel5.Visible = False




            PictureBox4.Visible = False
            PictureBox13.Visible = False
            PictureBox5.Visible = False
            PictureBox6.Visible = False
            PictureBox11.Visible = False
            PictureBox12.Visible = False
            BunifuImageButton1.Visible = False


            BunifuCustomLabel1.Location = BunifuCustomLabel7.Location 'pour remettre les forms en ordre et les b1 classer'
            BunifuCustomLabel2.Location = BunifuCustomLabel4.Location

            PictureBox7.Location = PictureBox4.Location
            PictureBox3.Location = PictureBox6.Location


            Etudient3.BunifuCustomDataGrid1.Size = New System.Drawing.Size(1027, 669)
            Etudient3.BunifuCustomDataGrid1.Location = New Point(0, 39)
            Emplois1.BunifuCustomDataGrid1.Size = New System.Drawing.Size(1027, 669)
            Emplois1.BunifuCustomDataGrid1.Location = New Point(0, 39)

            Etudient3.RadioButton1.Visible = False
            Etudient3.RadioButton2.Visible = False


            Etudient3.BunifuThinButton23.Visible = False
            Etudient3.BunifuThinButton22.Visible = False
            Etudient3.BunifuThinButton24.Visible = False
            Etudient3.BunifuThinButton25.Visible = False





        End If

    End Sub


    Private Sub Absance_11_Load(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Chargement1_Load_1(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub PictureBox2_Click_1(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub PictureBox10_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox10.Click

        Me.WindowState = FormWindowState.Maximized



    End Sub

    Private Sub PictureBox2_Click_2(sender As System.Object, e As System.EventArgs) Handles PictureBox2.Click
        MsgBox("cette application et un PFE programme par aboujaafar othmane fasla hafsa sanae latif pour plus des informations contacte:0615885422")
    End Sub

    Private Sub BunifuCustomLabel6_Click_1(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel6.Click
      
    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panelm.Paint

    End Sub

    Private Sub BunifuCustomLabel8_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel8.Click
        Utilisateur1.BringToFront()
        Utilisateur1.Visible = False
        BunifuTransition1.ShowSync(Utilisateur1)


        Panel3.Left = BunifuCustomLabel3.Left
        Panel3.Width = BunifuCustomLabel3.Width
    End Sub

    Private Sub Utilisateur1_Load(sender As System.Object, e As System.EventArgs) Handles Utilisateur1.Load

    End Sub

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub BunifuCustomLabel9_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel9.Click
        Statistique1.BringToFront()
        Statistique1.Visible = False
        BunifuTransition1.ShowSync(Statistique1)


        Panel3.Left = BunifuCustomLabel9.Left
        Panel3.Width = BunifuCustomLabel9.Width
    End Sub

    Private Sub BunifuCustomLabel6_DoubleClick(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel6.DoubleClick
        Me.Top = Cursor.Position.Y
        Me.Left = Cursor.Position.X
    End Sub

    Private Sub BunifuSeparator1_Load(sender As System.Object, e As System.EventArgs) Handles BunifuSeparator1.Load

    End Sub

    Private Sub PictureBox4_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox4.Click

    End Sub

    Private Sub PictureBox3_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox3.Click

    End Sub

    Private Sub PictureBox5_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox5.Click

    End Sub

    Private Sub Chargement1_Load_2(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Emplois1_Load(sender As System.Object, e As System.EventArgs) Handles Emplois1.Load

    End Sub

    Private Sub BunifuCustomLabel10_Click(sender As System.Object, e As System.EventArgs) Handles BunifuCustomLabel10.Click 'historique'
        Historique2.BringToFront()
        Historique2.Visible = False
        BunifuTransition1.ShowSync(Historique2)


        Panel3.Left = BunifuCustomLabel10.Left
        Panel3.Width = BunifuCustomLabel10.Width
    End Sub

    Private Sub PictureBox13_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox13.Click

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

    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs)
        login.Show()
        Me.Close()
    End Sub

    Private Sub BunifuThinButton21_Click(sender As System.Object, e As System.EventArgs) Handles BunifuThinButton21.Click
        login.Show()
        Me.Close()

    End Sub

    Private Sub PictureBox6_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox6.Click

    End Sub

    Private Sub PictureBox7_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox7.Click

    End Sub

    Private Sub PictureBox12_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox12.Click

    End Sub

    Private Sub PictureBox8_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox8.Click

    End Sub

    Private Sub BunifuImageButton2_Click(sender As System.Object, e As System.EventArgs)
    
    End Sub

    Private Sub BunifuImageButton2_Click_1(sender As System.Object, e As System.EventArgs) Handles BunifuImageButton2.Click

        If Label1.Text = "admin" Then
            Left_bare1.BringToFront()
            Left_bare1.Visible = False
            BunifuTransition2.ShowSync(Left_bare1)

        End If
    

    End Sub
End Class

