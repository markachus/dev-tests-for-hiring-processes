' NOTE: You can use the "Rename" command on the context menu to change the interface name "IService1" in both code and config file together.
Imports SP.TourismApp.Model.Entities

<ServiceContract()>
Public Interface SPTourismService

    ''' <summary>
    ''' A user signs up or registers with email or facebook account.
    ''' </summary>
    ''' <param name="email"></param>
    ''' <param name="useFacebookAccount"></param>
    ''' <returns>Facebook identity token</returns>
    <OperationContract()>
    Function SignUp(email As String, Optional useFacebookAccount As Boolean = False) As String

    ''' <summary>
    ''' List available activities filtering distance and category, all of them optional (nullable) parameters
    ''' </summary>
    ''' <param name="minDistance"></param>
    ''' <param name="maxDistance"></param>
    ''' <param name="categoryId"></param>
    ''' <returns>List of activities matching the criteria</returns>
    <OperationContract()>
    Function ListActivities(minDistance As Integer?, maxDistance As Integer?, categoryId As Integer?) As List(Of Activity)

    <OperationContract()>
    Function GetActivityDetails(activityId As Integer, ByRef act As Activity, ByRef availableDatesInCurrentMonth As List(Of Date))

    ''' <summary>
    ''' A user posts a comment on an activity and ratess it as well
    ''' </summary>
    ''' <param name="activityId"></param>
    ''' <param name="userId"></param>
    ''' <param name="comment"></param>
    ''' <param name="rate"></param>
    ''' <returns>Post Id</returns>
    <OperationContract()>
    Function Post(activityId As Integer, userId As Integer, comment As String, rate As Integer) As Integer

    ''' <summary>
    ''' A user books or makes a reservation for an activity in date
    ''' </summary>
    ''' <param name="activityId"></param>
    ''' <param name="userId"></param>
    ''' <param name="forDate"></param>
    ''' <returns>Reservation Id</returns>
    <OperationContract()>
    Function BookActivity(activityId As Integer, userId As Integer, forDate As Date) As Integer

    <OperationContract()>
    Sub ModifyProfile(userId As Integer, newFirstName As String, newLastName As String, newCountry As String)

    <OperationContract()>
    Function ListMyReservations(userId As Integer) As List(Of Reservation)

End Interface

