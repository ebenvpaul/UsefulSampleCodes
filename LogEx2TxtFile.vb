 Private Sub LogError(ex As Exception)
        Dim message As String = String.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"))
        message += Environment.NewLine
        message += "----------------------------------------------------------------------------------------------------------------------------------"
        message += Environment.NewLine
        message += String.Format("Message: {0}", ex.Message)
        message += Environment.NewLine
        message += String.Format("StackTrace: {0}", ex.StackTrace)
        message += Environment.NewLine
        message += String.Format("Source: {0}", ex.Source)
        message += Environment.NewLine
        message += String.Format("TargetSite: {0}", ex.TargetSite.ToString())
        message += Environment.NewLine
        message += "----------------------------------------------------------------------------------------------------------------------------------"
        message += Environment.NewLine
        Dim path As String = "C:\TestLog\ErrorLog.txt"
        If Not System.IO.File.Exists(path) Then
            System.IO.File.Create(path).Dispose()
        End If
        Using writer As New StreamWriter(path, True)
            writer.WriteLine(message)
            writer.Close()
        End Using
    End Sub
 Private Sub BtnLongProcess()
        If RunWithTimeout(New ThreadStart(AddressOf LongRunningOperation), TimeSpan.FromMilliseconds(5000)) Then
            Console.WriteLine("Worker thread finished.")
        Else
            Console.WriteLine("Worker thread was aborted.")
        End If
    End Sub

    Private Shared Function RunWithTimeout(ByVal threadStart As ThreadStart, ByVal timeout As TimeSpan) As Boolean
        Dim workerThread As Thread = New Thread(threadStart)
        workerThread.Start()
        Dim finished As Boolean = workerThread.Join(timeout)
        If Not finished Then workerThread.Abort()
        Return finished
    End Function

    Private Shared Sub LongRunningOperation()
        Thread.Sleep(4000)
    End Sub
