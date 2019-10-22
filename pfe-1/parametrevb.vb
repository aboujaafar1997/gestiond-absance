Imports System.IO.Ports
Public Class parametrevb

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As System.Object, e As System.EventArgs) Handles BunifuFlatButton1.Click
        Dim ds As New DataSet
        ds.ReadXml("message.xml")
        Dim dr As DataRow = ds.Tables(0).Rows(0)
        dr("port") = ComboBox1.Text
        ds.WriteXml("message.xml")
        Dim dr1 As DataRow = ds.Tables(0).Rows(0)
        dr1("sms") = BunifuMetroTextbox1.Text
        ds.WriteXml("message.xml")
        MsgBox("update message")


    End Sub

    Private Sub BunifuSwitch1_Click(sender As System.Object, e As System.EventArgs) Handles BunifuSwitch1.Click
        If BunifuSwitch1.Value = False Then
            BunifuSwitch1.BackColor = Color.Red


        End If
        If BunifuSwitch1.Value = True Then
            BunifuSwitch1.BackColor = Color.LimeGreen


        End If
        Dim ds As New DataSet
        ds.ReadXml("message.xml")
        Dim dr1 As DataRow = ds.Tables(0).Rows(0)

        dr1("tf") = BunifuSwitch1.Value
        ds.WriteXml("message.xml")
        MsgBox("update ")


    End Sub

    Private Sub parametrevb_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BunifuCustomDataGrid1.Visible = False
        ComboBox1.Items.Add("COM1")
        ComboBox1.Items.Add("COM2")
        ComboBox1.Items.Add("COM3")
        ComboBox1.Items.Add("COM4")
        ComboBox1.Items.Add("COM5")
        ComboBox1.Items.Add("COM6")
        ComboBox1.Items.Add("COM7")
        ComboBox1.Items.Add("COM8")
        ComboBox1.Items.Add("COM9")
        ComboBox1.Items.Add("COM10")
        ComboBox1.Items.Add("COM11")
        ComboBox1.Items.Add("COM12")
        ComboBox1.Items.Add("COM13")
        Dim ds As New DataSet
        ds.ReadXml("message.xml")
        BunifuCustomDataGrid1.DataSource = ds.Tables(0)
        BunifuMetroTextbox1.Text = BunifuCustomDataGrid1.Rows(0).Cells(0).Value
        ComboBox1.Text = BunifuCustomDataGrid1.Rows(0).Cells(1).Value
        BunifuSwitch1.Value = BunifuCustomDataGrid1.Rows(0).Cells(2).Value
        If BunifuSwitch1.Value = False Then
            BunifuSwitch1.BackColor = Color.Red

        End If





    End Sub

    Private Sub Panel1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles Panel1.DoubleClick, Panelm.DoubleClick
        Me.Top = Cursor.Position.Y
        Me.Left = Cursor.Position.X
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged



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

    Private Sub BunifuiOSSwitch1_OnValueChange(sender As System.Object, e As System.EventArgs) Handles BunifuiOSSwitch1.OnValueChange
        If BunifuiOSSwitch1.Value = True Then
            BunifuCustomDataGrid1.Visible = True
        End If
        If BunifuiOSSwitch1.Value = False Then
            BunifuCustomDataGrid1.Visible = False
        End If
    End Sub
End Class
