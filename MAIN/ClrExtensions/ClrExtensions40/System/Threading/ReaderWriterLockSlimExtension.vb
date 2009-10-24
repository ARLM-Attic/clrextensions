'Copyright (c) 2008, Jonathan Allen


#If ClrVersion >= 35 Then
Public Module ReaderWriterLockSlimExtension

    <Extension()> Public Function ReadSection(ByVal lock As Global.System.Threading.ReaderWriterLockSlim) As IDisposable
        Return New LockToken(lock, LockMode.Read)
    End Function

    <Extension()> Public Function UpgradeableReadSection(ByVal lock As Global.System.Threading.ReaderWriterLockSlim) As IDisposable
        Return New LockToken(lock, LockMode.Upgradable)
    End Function

    <Extension()> Public Function WriteSection(ByVal lock As Global.System.Threading.ReaderWriterLockSlim) As IDisposable
        Return New LockToken(lock, LockMode.Write)
    End Function

    Private NotInheritable Class LockToken
        Implements IDisposable
        Private m_Mode As LockMode
        Private m_Lock As Global.System.Threading.ReaderWriterLockSlim
        Private m_Disposed As Boolean = False

        Friend Sub New(ByVal lock As Global.System.Threading.ReaderWriterLockSlim, ByVal mode As LockMode)
            m_Lock = lock
            m_Mode = mode
            Select Case mode
                Case LockMode.Read
                    m_Lock.EnterReadLock()
                Case LockMode.Upgradable
                    m_Lock.EnterUpgradeableReadLock()
                Case LockMode.Write
                    m_Lock.EnterWriteLock()
            End Select
        End Sub

        Private Sub Dispose(ByVal disposing As Boolean)
            If Not Me.m_Disposed Then
                If disposing Then
                    Select Case m_Mode
                        Case LockMode.Read
                            m_Lock.ExitReadLock()
                        Case LockMode.Upgradable
                            m_Lock.ExitUpgradeableReadLock()
                        Case LockMode.Write
                            m_Lock.ExitWriteLock()
                    End Select
                End If
                m_Lock = Nothing
            End If
            Me.m_Disposed = True
        End Sub

        Private Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
        End Sub

    End Class

    Private Enum LockMode
        Read
        Upgradable
        Write
    End Enum

End Module

#End If