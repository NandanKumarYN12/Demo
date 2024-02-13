
Imports System
Imports System.Text
Imports System.Security.Cryptography
Public Class ClsEncryptDecrypt
    Public Shared Function EncryptData(ByVal textData As String, ByVal Encryptionkey As String) As String
        Dim objrij As RijndaelManaged = New RijndaelManaged()
        objrij.Mode = CipherMode.CBC
        objrij.Padding = PaddingMode.PKCS7
        Dim passBytes As Byte() = Encoding.UTF8.GetBytes(Encryptionkey)
        Dim IV As Byte() = New Byte(15) {}
        objrij.Key = passBytes
        Dim textData1 As Byte() = Encoding.UTF8.GetBytes(textData)
        Dim textDataByte As Byte() = New Byte(textData1.Length + 16 - 1) {}
        Array.Copy(IV, 0, textDataByte, 0, 16)
        Array.Copy(textData1, 0, textDataByte, 16, textData1.Length)
        Dim objtransform As ICryptoTransform = objrij.CreateEncryptor()
        Return Convert.ToBase64String(objtransform.TransformFinalBlock(textDataByte, 0, textDataByte.Length))
    End Function
    Public Shared Function DecryptData(ByVal EncryptedText As String, ByVal Encryptionkey As String) As String
        Dim objrij As RijndaelManaged = New RijndaelManaged()
        objrij.Mode = CipherMode.CBC
        objrij.Padding = PaddingMode.PKCS7
        Dim encryptedTextByte As Byte() = Convert.FromBase64String(EncryptedText)
        Dim passBytes As Byte() = Encoding.UTF8.GetBytes(Encryptionkey)
        Dim IV As Byte() = New Byte(15) {}
        Array.Copy(encryptedTextByte, 0, IV, 0, IV.Length)
        objrij.Key = passBytes
        objrij.IV = IV
        Dim dec As Byte() = New Byte(encryptedTextByte.Length - 16 - 1) {}
        Array.Copy(encryptedTextByte, 16, dec, 0, dec.Length)
        Dim TextByte As Byte() = objrij.CreateDecryptor().TransformFinalBlock(dec, 0, dec.Length)
        Return Encoding.UTF8.GetString(TextByte)
    End Function

End Class
