Module Module1

    Sub Main()
        Dim lock As New Threading.ReaderWriterLockSlim

        Try
            lock.EnterReadLock()
            'code
        Finally
            lock.ExitReadLock()
        End Try

        RaiseEvent fooBar(Nothing, EventArgs.Empty)

    End Sub

    Event fooBar As EventHandler


End Module
