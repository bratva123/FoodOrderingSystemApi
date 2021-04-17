Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports FoodOrderingSystem
Imports Newtonsoft.Json

Namespace Controllers
    Public Class CategoryController
        Inherits ApiController
        Dim categOp As CategoryOperation
        Dim resp As New HttpResponseMessage
        Public Sub New()
            categOp = New CategoryOperation
        End Sub

        Public Function GetValues() As HttpResponseMessage
            Try
                Dim categories = categOp.GetAllCategory()
                Dim content = JsonConvert.SerializeObject(categories)
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
                Dim category = categOp.GetCategoryById(id)
                Dim content = JsonConvert.SerializeObject(category)
                resp.StatusCode = HttpStatusCode.OK
                resp.Content = New StringContent(content, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotFound
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function

        Public Function PostValue(<FromBody()> ByVal category As Category) As HttpResponseMessage
            Try
                Dim flag As Integer = categOp.AddCategory(category)
                Dim resp = New HttpResponseMessage
                resp.StatusCode = HttpStatusCode.Created
                resp.Content = New StringContent(flag, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotAcceptable
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function

        Public Function PutValue(<FromBody()> ByVal category As Category) As HttpResponseMessage
            Try
                Dim flag As Integer = categOp.UpdateCategory(category)
                resp.StatusCode = HttpStatusCode.Accepted
                resp.Content = New StringContent(flag, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotAcceptable
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function

        Public Function DeleteValue(ByVal id As Integer) As HttpResponseMessage
            Try
                Dim flag As Integer = categOp.DeleteCategoryById(id)
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