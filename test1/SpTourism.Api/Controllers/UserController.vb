Imports System.Transactions
Imports SP.TourismApp.Model
Imports SP.TourismApp.Model.Entities

Namespace Controllers

    Public Class UserController
        Function Post(activityId As Integer, userId As Integer, comment As String, rate As Integer) As Integer
            Try

                Dim newPOst As Post = Nothing
                Using tx As New TransactionScope()

                    Using ctx As New SPTourismContext

                        Dim act As Activity = ctx.Activities.Where(Function(a) a.Id = activityId).SingleOrDefault()
                        If act Is Nothing Then Throw New Exception("Activity not found")

                        Dim user As User = ctx.Users.Where(Function(u) u.Id = userId).SingleOrDefault()
                        If user Is Nothing Then Throw New Exception("User not found")

                        'Should be done with factory
                        newPOst = New Post()
                        With newPOst
                            .Activity = act
                            .User = user
                            .Comment = comment
                            .Rate = rate
                            .CreationDate = Date.Today
                        End With

                        ctx.SaveChanges()
                    End Using

                    Return newPOst.Id
                End Using

            Catch ex As Exception
                'do som logging
                Throw ex
            End Try
        End Function

    End Class

End Namespace
