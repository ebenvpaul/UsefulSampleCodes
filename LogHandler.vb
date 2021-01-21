Imports System.IO
Imports System.Reflection

Public Class LogHandler


    Public Sub LogError(Optional ex As Exception = Nothing, Optional ByVal fnName As String = "")
        Try


            Dim message As String = String.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"))
            message += Environment.NewLine
            message += "----------------------------------------------------------------------------------------------------------------------------------"
            message += Environment.NewLine
            message += "Reached " + fnName + " Called"
            message += Environment.NewLine
            If Not ex Is Nothing Then
                message += String.Format("Exception Message: {0}", ex.Message)
                message += Environment.NewLine
                message += String.Format("StackTrace: {0}", ex.StackTrace)
                message += Environment.NewLine
                message += String.Format("Source: {0}", ex.Source)
                message += Environment.NewLine
                message += String.Format("TargetSite: {0}", ex.TargetSite.ToString())
                message += Environment.NewLine
            End If

            message += "----------------------------------------------------------------------------------------------------------------------------------"
            message += Environment.NewLine

            Dim Dir As String = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\Log"
            Dim path As String = Dir + "\ErrorLog.txt"

            If Not System.IO.Directory.Exists(Dir) Then
                System.IO.Directory.CreateDirectory(Dir)
            End If

            If Not System.IO.File.Exists(path) Then
                System.IO.File.Create(path).Dispose()
            End If
            Using writer As New StreamWriter(path, True)
                writer.WriteLine(message)
                writer.Close()
            End Using

        Catch exce As Exception

        End Try
    End Sub
End Class
