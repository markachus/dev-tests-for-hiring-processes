Imports System.ComponentModel.DataAnnotations

Namespace Entities

    Public Class Activity
        Inherits TourismBase

        <Required, MaxLength(255)>
        Public Property Description As String
        Public Property Distance As Decimal
        Public Property Price As Decimal
        Public Property Longitude As Double
        Public Property Latitude As Double

        Public Property Categories As HashSet(Of Category)

        Public Property Images As HashSet(Of ActivityImage)


    End Class

End Namespace