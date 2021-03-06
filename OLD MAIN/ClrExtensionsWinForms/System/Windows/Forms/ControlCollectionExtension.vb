Imports System.Windows.Forms


#If IncludeUntested Then
Public Module ControlCollectionExtension

    ''' <summary>
    ''' Returns all the controls in the tree using a breadth-first algorythm. This is a live enumerator, it won't dump everything in the graph into one giant list.
    ''' </summary>
    ''' <param name="this"></param>
    ''' <returns></returns>
    ''' <remarks>This doesn't have precautions against circular references.</remarks>
    <Untested()> <Extension()> Function AllChildControls(ByVal this As Control.ControlCollection) As IEnumerable(Of Control)
        Return New ControlEnumerable(this)
    End Function
End Module
#End If