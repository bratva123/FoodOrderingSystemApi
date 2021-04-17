Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Newtonsoft.Json
Imports FoodOrderingSystem

Namespace Controllers
    Public Class LocationController
        Inherits ApiController

        Dim locOp As LocationOperation
        Dim resp As New HttpResponseMessage


        Public Sub New()
            locOp = New LocationOperation
        End Sub


        Public Function GetValue(ByVal id As Integer) As HttpResponseMessage
            Try
                Dim role = locOp.GetLocationById(id)
                Dim content = JsonConvert.SerializeObject(role)
                resp.StatusCode = HttpStatusCode.OK
                resp.Content = New StringContent(content, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotFound
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function

        Public Function PostValue(<FromBody()> ByVal loc As Location) As HttpResponseMessage
            Try
                Dim flag As Integer = locOp.AddLocation(loc)
                resp.StatusCode = HttpStatusCode.Created
                resp.Content = New StringContent(flag, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotAcceptable
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function

        Public Function PutValue(<FromBody()> ByVal loc As Location) As HttpResponseMessage
            Try
                Dim flag As Integer = locOp.UpdateLocation(loc)
                resp.StatusCode = HttpStatusCode.Accepted
                resp.Content = New StringContent(flag, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotAcceptable
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try

            Return resp
        End Function

        Public Function DeleteValue(ByVal id As Integer)
            Try
                Dim flag As Integer = locOp.DeleteLocationById(id)
                resp.StatusCode = HttpStatusCode.OK
                resp.Content = New StringContent(flag, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotFound
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function
    End Class
End Namespace