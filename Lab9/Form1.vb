Imports System.Threading
Public Class Form1
    Delegate Sub ListBoxDelegate(ByVal command As Integer, ByVal myStr As String)
    Dim ListBoxDel As New ListBoxDelegate(AddressOf ListBoxDelMethod)

    Dim PC_Comm As New Thread(AddressOf PC_Comm_method)
    Dim ShowFiles As Integer = 1
    Dim StartFileList As Integer = 2
    Dim EndFileList As Integer = 3
    Dim SendSelectedFile As Integer = 4
    Dim SendPlay As Integer = 5
    Dim SendPause As Integer = 6

    Dim ShowFilesStr As String = "1"
    Dim StartFileListStr As String = "2"
    Dim EndFileListStr As String = "3"
    Dim SendSelectedFileStr As String = "4"
    Dim SendPlayStr As String = "5"
    Dim SendPauseStr As String = "6"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Try to open the seial port 
        Try
            SerialPort1.Open()
        Catch
            Debug.WriteLine("Failed to open serial port")
        End Try

        ' Make this a background thread so it automatically
        ' aborts when the main program stops.
        PC_Comm.IsBackground = True
        ' Set the thread priority to lowest
        PC_Comm.Priority = ThreadPriority.Lowest
        ' Start the thread
        PC_Comm.Start()

    End Sub
    ' Delegate function that accesses the ListBox object
    ' command = 2 - clear the contents of the ListBox
    ' command = 3 - add the string to the ListBox
    Public Sub ListBoxDelMethod(ByVal command As Integer, ByVal myStr As String)

        If command = StartFileList Then
            File_List.Items.Clear()
        ElseIf command = EndFileList Then
            File_List.Items.Add(myStr)
        End If
    End Sub
    ' Thread that monitors the receive items on the serial port
    Private Sub PC_Comm_method()
        Dim str As String
        While 1
            If SerialPort1.IsOpen Then
                Try
                    str = SerialPort1.ReadLine() ' Wait for start string
                Catch ex As Exception
                End Try

                'String.Compare return values:
                ' Less than zero: strA precedes strB in the sort order.
                'Zero" strA occurs in the same position as strB in the sort order.
                'Greater than zero: strA follows strB in the sort order.
                If Not String.Compare(str, StartFileListStr) Then
                    ' Received a StartFileList response
                    ' clear the list
                    ' Use the delegate to access the ListBox
                    File_List.Invoke(ListBoxDel, StartFileList, "")
                    ' get next string
                    Try
                        str = SerialPort1.ReadLine() ' read file name
                    Catch ex As Exception
                    End Try
                    While String.Compare(str, EndFileListStr)
                        ' The read string is a file name and not the EndFileList
                        File_List.Invoke(ListBoxDel, EndFileList, str)
                        Try
                            str = SerialPort1.ReadLine() ' read file name
                        Catch ex As Exception
                        End Try
                    End While
                    ' While loop ends when a 3 is received
                End If
            Else
                Threading.Thread.Sleep(500)
            End If
        End While
    End Sub

    Private Sub Show_Files_Click(sender As Object, e As EventArgs) Handles Show_Files.Click
        If SerialPort1.IsOpen Then
            ' Send Show_Files command
            SerialPort1.Write(ShowFilesStr, 0, 1)
        End If
    End Sub

    Private Sub Send_Files_Click(sender As Object, e As EventArgs) Handles Send_Files.Click
        Dim b(1) As Byte
        b(0) = 0

        If SerialPort1.IsOpen Then
            If Not (File_List.SelectedIndex = -1) Then
                SerialPort1.Write(SendSelectedFileStr, 0, 1)
                SerialPort1.Write(File_List.SelectedItem.ToString())
                SerialPort1.Write(b, 0, 1)
            End If
        End If
    End Sub

    Private Sub File_List_SelectedIndexChanged(sender As Object, e As EventArgs) Handles File_List.SelectedIndexChanged

    End Sub

    Private Sub Play_Click(sender As Object, e As EventArgs) Handles Play.Click
        If SerialPort1.IsOpen Then

            SerialPort1.Write(SendPlayStr, 0, 1)
        End If
    End Sub

    Private Sub Pause_Click(sender As Object, e As EventArgs) Handles Pause.Click
        If SerialPort1.IsOpen Then

            SerialPort1.Write(SendPauseStr, 0, 1)
        End If
    End Sub
End Class

