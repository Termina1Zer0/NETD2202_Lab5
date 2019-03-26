Option Strict On
Imports System.IO

Public Class TextEditorForm

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuOpen.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Try
                Dim reader As New StreamReader(OpenFileDialog1.FileName)
                txtEditText.Text() = reader.ReadToEnd()
                reader.Close()
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            End Try
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuSave.Click
        SaveFileDialog1.Filter = "TXT Files (*.txt)|*.txt"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, txtEditText.Text(), False)
            Catch ex As Exception
                Console.WriteLine(ex.ToString())
            End Try
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Application.Exit()
    End Sub

End Class