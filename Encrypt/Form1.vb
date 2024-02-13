Public Class Form1
    Dim EncryptionKey As String
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            If TextBox1.Text = "" Then
                EncryptionKey = "832d2cc9bc984cdc920296ade6f1b517"
            End If
            EncryptionKey = Convert.ToString(TextBox1.Text)
            Dim vReadData As String = Convert.ToString(RichTextBox1.Text)
            Dim DecryptedData As String = ClsEncryptDecrypt.DecryptData(vReadData, EncryptionKey)
            RichTextBox2.Text = DecryptedData
            MsgBox("Nandan Kumar Y N")
            MsgBox("Nandan Kumar Y N")
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = "" Then
                EncryptionKey = "832d2cc9bc984cdc920296ade6f1b517"
            End If
            EncryptionKey = Convert.ToString(TextBox1.Text)
            Dim vReadData As String = Convert.ToString(RichTextBox1.Text)
            Dim EncryptedData As String = ClsEncryptDecrypt.EncryptData(vReadData, EncryptionKey)
            RichTextBox2.Text = EncryptedData
            MsgBox(EncryptedData)
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
