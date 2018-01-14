Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Initial
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Activity",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Description = c.String(nullable := False, maxLength := 255),
                        .Distance = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .Price = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .Longitude = c.Double(nullable := False),
                        .Latitude = c.Double(nullable := False),
                        .CreationDate = c.DateTime(nullable := False),
                        .UserCreation = c.String(),
                        .LastUpdateDate = c.DateTime(),
                        .LastUpdateUser = c.String(),
                        .Deleted = c.Boolean()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateTable(
                "dbo.Category",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Description = c.String(nullable := False, maxLength := 255),
                        .CreationDate = c.DateTime(nullable := False),
                        .UserCreation = c.String(),
                        .LastUpdateDate = c.DateTime(),
                        .LastUpdateUser = c.String(),
                        .Deleted = c.Boolean()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateTable(
                "dbo.ActivityImage",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Path = c.String(),
                        .CreationDate = c.DateTime(nullable := False),
                        .UserCreation = c.String(),
                        .LastUpdateDate = c.DateTime(),
                        .LastUpdateUser = c.String(),
                        .Deleted = c.Boolean(),
                        .Activity_Id = c.Int()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Activity", Function(t) t.Activity_Id) _
                .Index(Function(t) t.Activity_Id)
            
            CreateTable(
                "dbo.User",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Email = c.String(nullable := False, maxLength := 255),
                        .TokenFaceBook = c.String(),
                        .FirstName = c.String(nullable := False, maxLength := 255),
                        .LastName = c.String(nullable := False, maxLength := 255),
                        .Country = c.String(nullable := False, maxLength := 3),
                        .CreationDate = c.DateTime(nullable := False),
                        .UserCreation = c.String(),
                        .LastUpdateDate = c.DateTime(),
                        .LastUpdateUser = c.String(),
                        .Deleted = c.Boolean()
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .Index(Function(t) t.Email, unique := True)
            
            CreateTable(
                "dbo.Post",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Comment = c.String(),
                        .Rate = c.Int(nullable := False),
                        .CreationDate = c.DateTime(nullable := False),
                        .UserCreation = c.String(),
                        .LastUpdateDate = c.DateTime(),
                        .LastUpdateUser = c.String(),
                        .Deleted = c.Boolean(),
                        .Activity_Id = c.Int(nullable := False),
                        .User_Id = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Activity", Function(t) t.Activity_Id, cascadeDelete := True) _
                .ForeignKey("dbo.User", Function(t) t.User_Id, cascadeDelete := True) _
                .Index(Function(t) t.Activity_Id) _
                .Index(Function(t) t.User_Id)
            
            CreateTable(
                "dbo.Reservation",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .ForDate = c.DateTime(nullable := False),
                        .CreationDate = c.DateTime(nullable := False),
                        .UserCreation = c.String(),
                        .LastUpdateDate = c.DateTime(),
                        .LastUpdateUser = c.String(),
                        .Deleted = c.Boolean(),
                        .Activity_Id = c.Int(nullable := False),
                        .User_Id = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Activity", Function(t) t.Activity_Id, cascadeDelete := True) _
                .ForeignKey("dbo.User", Function(t) t.User_Id, cascadeDelete := True) _
                .Index(Function(t) t.Activity_Id) _
                .Index(Function(t) t.User_Id)
            
            CreateTable(
                "dbo.ActivityCategory",
                Function(c) New With
                    {
                        .Activity_Id = c.Int(nullable := False),
                        .Category_Id = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) New With { t.Activity_Id, t.Category_Id }) _
                .ForeignKey("dbo.Activity", Function(t) t.Activity_Id, cascadeDelete := True) _
                .ForeignKey("dbo.Category", Function(t) t.Category_Id, cascadeDelete := True) _
                .Index(Function(t) t.Activity_Id) _
                .Index(Function(t) t.Category_Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Reservation", "User_Id", "dbo.User")
            DropForeignKey("dbo.Reservation", "Activity_Id", "dbo.Activity")
            DropForeignKey("dbo.Post", "User_Id", "dbo.User")
            DropForeignKey("dbo.Post", "Activity_Id", "dbo.Activity")
            DropForeignKey("dbo.ActivityImage", "Activity_Id", "dbo.Activity")
            DropForeignKey("dbo.ActivityCategory", "Category_Id", "dbo.Category")
            DropForeignKey("dbo.ActivityCategory", "Activity_Id", "dbo.Activity")
            DropIndex("dbo.ActivityCategory", New String() { "Category_Id" })
            DropIndex("dbo.ActivityCategory", New String() { "Activity_Id" })
            DropIndex("dbo.Reservation", New String() { "User_Id" })
            DropIndex("dbo.Reservation", New String() { "Activity_Id" })
            DropIndex("dbo.Post", New String() { "User_Id" })
            DropIndex("dbo.Post", New String() { "Activity_Id" })
            DropIndex("dbo.User", New String() { "Email" })
            DropIndex("dbo.ActivityImage", New String() { "Activity_Id" })
            DropTable("dbo.ActivityCategory")
            DropTable("dbo.Reservation")
            DropTable("dbo.Post")
            DropTable("dbo.User")
            DropTable("dbo.ActivityImage")
            DropTable("dbo.Category")
            DropTable("dbo.Activity")
        End Sub
    End Class
End Namespace
