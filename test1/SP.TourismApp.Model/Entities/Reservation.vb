Imports System.ComponentModel.DataAnnotations

Namespace Entities

    Public Class Reservation
        Inherits TourismBase

        Public Property User As User
        Public Property Activity As Activity

        <Required>
        Public Property ForDate As Date


    End Class

End Namespace
