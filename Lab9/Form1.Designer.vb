<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Show_Files = New System.Windows.Forms.Button()
        Me.File_List = New System.Windows.Forms.ListBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Send_Files = New System.Windows.Forms.Button()
        Me.Play = New System.Windows.Forms.Button()
        Me.Pause = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Show_Files
        '
        Me.Show_Files.Location = New System.Drawing.Point(289, 25)
        Me.Show_Files.Name = "Show_Files"
        Me.Show_Files.Size = New System.Drawing.Size(103, 29)
        Me.Show_Files.TabIndex = 0
        Me.Show_Files.Text = "Show_Files"
        Me.Show_Files.UseVisualStyleBackColor = True
        '
        'File_List
        '
        Me.File_List.FormattingEnabled = True
        Me.File_List.ItemHeight = 16
        Me.File_List.Location = New System.Drawing.Point(289, 60)
        Me.File_List.Name = "File_List"
        Me.File_List.Size = New System.Drawing.Size(248, 196)
        Me.File_List.Sorted = True
        Me.File_List.TabIndex = 1
        '
        'SerialPort1
        '
        Me.SerialPort1.PortName = "COM4"
        '
        'Send_Files
        '
        Me.Send_Files.Location = New System.Drawing.Point(434, 25)
        Me.Send_Files.Name = "Send_Files"
        Me.Send_Files.Size = New System.Drawing.Size(103, 29)
        Me.Send_Files.TabIndex = 2
        Me.Send_Files.Text = "Send_Files"
        Me.Send_Files.UseVisualStyleBackColor = True
        '
        'Play
        '
        Me.Play.Location = New System.Drawing.Point(289, 272)
        Me.Play.Name = "Play"
        Me.Play.Size = New System.Drawing.Size(103, 29)
        Me.Play.TabIndex = 3
        Me.Play.Text = "Play"
        Me.Play.UseVisualStyleBackColor = True
        '
        'Pause
        '
        Me.Pause.Location = New System.Drawing.Point(434, 272)
        Me.Pause.Name = "Pause"
        Me.Pause.Size = New System.Drawing.Size(103, 29)
        Me.Pause.TabIndex = 4
        Me.Pause.Text = "Pause"
        Me.Pause.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Pause)
        Me.Controls.Add(Me.Play)
        Me.Controls.Add(Me.Send_Files)
        Me.Controls.Add(Me.File_List)
        Me.Controls.Add(Me.Show_Files)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Show_Files As Button
    Friend WithEvents File_List As ListBox
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents Send_Files As Button
    Friend WithEvents Play As Button
    Friend WithEvents Pause As Button
End Class
