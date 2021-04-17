Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports FoodOrderingSystem
Imports Newtonsoft.Json

Namespace Controllers
    Public Class RoleController
        Inherits ApiController
        Dim roleOp As RoleOperation
        Dim resp As New HttpResponseMessage


        Public Sub New()
            roleOp = New RoleOperation
        End Sub

        Public Function GetValues() As HttpResponseMessage
            Try
                Dim roles = roleOp.GetAllRole()
                Dim content = JsonConvert.SerializeObject(roles)
                resp.StatusCode = HttpStatusCode.OK
                resp.Content = New StringContent(content, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NoContent
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function

        Public Function GetValue(ByVal id As Integer) As HttpResponseMessage
            Try
                Dim role = roleOp.GetRoleById(id)
                Dim content = JsonConvert.SerializeObject(role)
                resp.StatusCode = HttpStatusCode.OK
                resp.Content = New StringContent(content, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotFound
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function

        Public Function PostValue(<FromBody()> ByVal role As Role) As HttpResponseMessage
            Try
                Dim flag As Integer = roleOp.AddRole(role)
                resp.StatusCode = HttpStatusCode.Created
                resp.Content = New StringContent(flag, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotAcceptable
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function

        Public Function PutValue(<FromBody()> ByVal role As Role) As HttpResponseMessage
            Try
                Dim flag As Integer = roleOp.UpdateRole(role)
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
                Dim flag As Integer = roleOp.DeleteRole(id)
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