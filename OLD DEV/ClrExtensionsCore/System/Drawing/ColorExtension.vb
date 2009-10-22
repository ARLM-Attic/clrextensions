'Copyright (c) 2008, Jonathan Allen

Imports System.Drawing

#If IncludeUntested Then
Public Module ColorExtension
    'Reference: http://en.wikipedia.org/wiki/HSL_color_space


    ''' <summary>
    ''' Create a color from Hue-Saturation-Lightness (HSL)
    ''' </summary>
    ''' <param name="hue">0 to 360</param>
    ''' <param name="saturation">0 to 1</param>
    ''' <param name="lightness">0 to 1</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()> Public Function FromHsl(ByVal hue As Single, ByVal saturation As Single, ByVal lightness As Single) As Drawing.Color
        'todo : Check ranges
        Dim q As Single
        If lightness > 1 / 2 Then
            q = lightness + saturation - (lightness * saturation)
        Else
            q = lightness * (1 + saturation)
        End If

        Dim p = 2 * lightness - q
        Dim hk = hue / 360

        Dim tR = Tc(hk + 1.0F / 3.0F)
        Dim tG = Tc(hk)
        Dim tB = Tc(hk - 1.0F / 3.0F)

        Dim r = C(p, q, tR)
        Dim g = C(p, q, tG)
        Dim b = C(p, q, tB)

        Return Color.FromArgb(CInt(256 * r), CInt(256 * g), CInt(256 * b))

    End Function

    Private Function Tc(ByVal t As Single) As Single
        Select Case t
            Case Is < 0.0F : Return t + 1.0F
            Case Is > 1.0F : Return t - 1.0F
            Case Else : Return t
        End Select
    End Function

    Private Function C(ByVal p As Single, ByVal q As Single, ByVal tc As Single) As Single
        Select Case tc
            Case Is < 1.0F / 6.0F : Return p + ((q - p) * 6.0F * tc)
            Case Is < 1.0F / 2.0F : Return q
            Case Is < 2.0F / 3.0F : Return p + ((q - p) * 6.0F * (2.0F / 3.0F - tc))
            Case Else : Return p
        End Select
    End Function

    ''' <summary>
    ''' Creates a Color object from Hue-Saturation-Value (HSV)
    ''' </summary>
    ''' <param name="hue"></param>
    ''' <param name="saturation"></param>
    ''' <param name="value"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()> Public Function FromHsv(ByVal hue As Single, ByVal saturation As Single, ByVal value As Single) As Drawing.Color
        'todo : Check ranges
        Dim hi = (hue / 60.0F) Mod 6
        Dim f = (hue / 60.0F) - CSng(Math.Floor(hue / 60.0F))
        Dim p = value * (1.0F - saturation)
        Dim q = value * (1.0F - f * saturation)
        Dim t = value * (1.0F - (1.0F - f) * saturation)

        Dim r, g, b As Single
        Select Case hi
            Case 0
                r = value
                g = t
                b = p
            Case 1
                r = q
                g = value
                b = p
            Case 2
                r = p
                g = value
                b = t
            Case 3
                r = p
                g = q
                b = value
            Case 4
                r = t
                g = p
                b = value
            Case 5
                r = value
                g = p
                b = q
        End Select

        Return Drawing.Color.FromArgb(CInt(256 * r), CInt(256 * g), CInt(256 * b))

    End Function


End Module
#End If