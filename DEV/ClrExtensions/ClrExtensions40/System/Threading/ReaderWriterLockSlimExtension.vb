'Copyright (c) 2008, Jonathan Allen


#If ClrVersion >= 35 Then
Public Module ReaderWriterLockSlimExtension

    <Extension()> Function ReadSection(ByVal lock As Global.System.Threading.ReaderWriterLockSlim) As IDisposable
        If lock Is Nothing Then Throw New ArgumentNullException("lock")

        Return New LockToken(lock, LockMode.Read)
    End Function

    <Extension()> Function UpgradeableReadSection(ByVal lock As Global.System.Threading.ReaderWriterLockSlim) As IDisposable
        If lock Is Nothing Then Throw New ArgumentNullException("lock")

        Return New LockToken(lock, LockMode.Upgradable)
    End Function

    <Extension()> Function WriteSection(ByVal lock As Global.System.Threading.ReaderWriterLockSlim) As IDisposable
        If lock Is Nothing Then Throw New ArgumentNullException("lock")

        Return New LockToken(lock, LockMode.Write)
    End Function

    Private NotInheritable Class LockToken
        Implements IDisposable
        Private ReadOnly m_Mode As LockMode
        Private ReadOnly m_Lock As Global.System.Threading.ReaderWriterLockSlim
        Private m_Disposed As Boolean = False

        '<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")>
        '<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>
        '<        'Private Sub ObjectInvariant()
        '        'End Sub


        Friend Sub New(ByVal lock As Global.System.Threading.ReaderWriterLockSlim, ByVal mode As LockMode)
            If lock Is Nothing Then Throw New ArgumentNullException("lock")
            If Not mode.EnumIsDefined Then Throw New ArgumentOutOfRangeException("mode")

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
