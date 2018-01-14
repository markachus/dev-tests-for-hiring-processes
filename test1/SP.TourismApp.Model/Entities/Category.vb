Imports System.ComponentModel.DataAnnotations

Namespace Entities

    Public Class Category
        Inherits TourismBase

        <Required, MaxLength(255)>
        Public Property Description As String

    End Class

End Namespace