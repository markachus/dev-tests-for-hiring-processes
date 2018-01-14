Imports System
Imports System.Data.Entity
Imports System.Data.Entity.ModelConfiguration.Conventions
Imports System.Linq
Imports SP.TourismApp.Model.Entities


Public Class SPTourismContext
    Inherits DbContext

    ' Your context has been configured to use a 'TourismModel' connection string from your application's 
    ' configuration file (App.config or Web.config). By default, this connection string targets the 
    ' 'SP.TourismApp.Model.TourismModel' database on your LocalDb instance. 
    ' 
    ' If you wish to target a different database and/or database provider, modify the 'TourismModel' 
    ' connection string in the application configuration file.
    Public Sub New()
        MyBase.New("name=TourismModel")
    End Sub

    ' Add a DbSet for each entity type that you want to include in your model. For more information 
    ' on configuring and using a Code First model, see http:'go.microsoft.com/fwlink/?LinkId=390109.
    ' Public Overridable Property MyEntities() As DbSet(Of MyEntity)

    Public Property Users As DbSet(Of Entities.User)

    Public Property Activities As DbSet(Of Entities.Activity)


    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        modelBuilder.Conventions.Remove(Of PluralizingTableNameConvention)()

        modelBuilder.Entity(Of Activity).HasMany(Of Category)(Function(a) a.Categories).WithMany()
        modelBuilder.Entity(Of Reservation).HasRequired(Of User)(Function(r) r.User).WithMany(Function(u) u.Reservations)
        modelBuilder.Entity(Of Reservation).HasRequired(Of Activity)(Function(r) r.Activity).WithMany()


        modelBuilder.Entity(Of Post).HasRequired(Of User)(Function(p) p.User).WithMany(Function(u) u.Posts)

        modelBuilder.Entity(Of Post).HasRequired(Of Activity)(Function(p) p.Activity).WithMany()


    End Sub

End Class



'Public Class MyEntity
'    Public Property Id() As Int32
'    Public Property Name() As String
'End Class