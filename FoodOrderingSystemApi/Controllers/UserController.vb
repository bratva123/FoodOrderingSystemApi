Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports FoodOrderingSystem
Imports Newtonsoft.Json

Namespace Controllers
    Public Class UserController
        Inherits ApiController
        Dim userOp As UserOperation
        Dim resp As New HttpResponseMessage

        Public Sub New()
            userOp = New UserOperation
        End Sub
        ' GET: api/User
        'Public Function GetValues() As HttpResponseMessage
        '    Try
        '        Dim roles = userOp.Get()
        '        Dim content = JsonConvert.SerializeObject(roles)
        '        resp.StatusCode = HttpStatusCode.OK
        '        resp.Content = New StringContent(content, Encoding.UTF8, "application/json")
        '    Catch ex As Exception
        '        resp.StatusCode = HttpStatusCode.NoContent
        '        resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
        '    End Try
        '    Return resp
        'End Function

        Public Function GetValue(ByVal id As Integer) As HttpResponseMessage
            Try
                Dim role = userOp.GetUserById(id)
                Dim content = JsonConvert.SerializeObject(role)
                resp.StatusCode = HttpStatusCode.OK
                resp.Content = New StringContent(content, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotFound
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function

        Public Function PostValue(<FromBody()> ByVal user As User) As HttpResponseMessage
            Try
                Dim flag As Integer = userOp.AddUser(user)
                resp.StatusCode = HttpStatusCode.Created
                resp.Content = New StringContent(flag, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotAcceptable
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function

        Public Function PutValue(<FromBody()> ByVal user As User) As HttpResponseMessage
            Try
                Dim flag As Integer = userOp.UpdateUser(user)
                resp.StatusCode = HttpStatusCode.Accepted
                resp.Content = New StringContent(flag, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotAcceptable
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try

            Return resp
        End Function
    End Class
End Namespace