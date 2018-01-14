Imports System.ComponentModel.DataAnnotations
Namespace Entities

    Partial Public MustInherit Class TourismBase
        <Key, Display(AutoGenerateField:=False)>
        Public Property Id As Integer

        <Required, DataType(DataType.DateTime), Display(AutoGenerateField:=False)>
        Public Property CreationDate As Date = DateTime.Now

        <Display(AutoGenerateField:=False)>
        Public Property UserCreation As String = Threading.Thread.CurrentPrincipal.Identity.Name

        <DataType(DataType.DateTime), Display(AutoGenerateField:=False)>
        Public Property LastUpdateDate As Date?

        <Display(AutoGenerateField:=False)>
        Public Property LastUpdateUser As String

        <Display(AutoGenerateField:=False)>
        Public Property Deleted As Boolean? = False


    End Class

End Namespace
