Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Namespace Entities

    Public Class User
        Inherits TourismBase

        <Index("IX_Email", 1, IsUnique:=True)>
        <Required, MaxLength(255)>
        Public Property Email As String

        Public Property TokenFaceBook As String

        <Required, MaxLength(255)>
        Public Property FirstName As String

        <Required, MaxLength(255)>
        Public Property LastName As String

        <Required, MaxLength(3)>
        Public Property Country As String

        Public Property Reservations As HashSet(Of Reservation)

        Public Property Posts As HashSet(Of Post)

    End Class

End Namespace