Module Module1

    Sub Main()
        Dim lock As New Threading.ReaderWriterLockSlim

        Try
            lock.EnterReadLock()
            'code
        Finally
            lock.ExitReadLock()
        End Try



    End Sub

End Module
