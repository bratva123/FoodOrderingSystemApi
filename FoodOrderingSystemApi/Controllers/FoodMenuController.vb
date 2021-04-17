Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports FoodOrderingSystem
Imports Newtonsoft.Json

Namespace Controllers
    Public Class FoodMenuController
        Inherits ApiController

        Dim resp As New HttpResponseMessage
        Dim menuOp As FoodMenuOperation
        Public Sub New()
            menuOp = New FoodMenuOperation
        End Sub

        <Route("api/FoodMenu/getByCatId/{id}")>
        Public Function GetValue(ByVal id As Integer) As HttpResponseMessage
            Try
                Dim item = menuOp.GetByCategoryId(id)
                Dim content = JsonConvert.SerializeObject(item)
                resp.StatusCode = HttpStatusCode.OK
                resp.Content = New StringContent(content, Encoding.UTF8, "application/json")
            Catch ex As FoodOrderException
                resp.StatusCode = HttpStatusCode.NotFound
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function
        <Route("api/FoodMenu/getByCatId/{ch}/{id}")>
        <HttpGet>
        Public Function GetValues(ch As String, id As String) As FoodMenu
            Dim item As New FoodMenu
            Try
                item = menuOp.GetByItemId(id)
            Catch ex As FoodOrderException
                resp.StatusCode = HttpStatusCode.NotFound
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return item
        End Function


        <Route("api/FoodMenu/getByName/{ch}/")>
        <HttpGet>
        Public Function GetItemByName(ch As String) As HttpResponseMessage
            Dim items As New List(Of FoodMenu)
            Try
                items = menuOp.GetByItemName(ch)
                Dim content = JsonConvert.SerializeObject(items)
                resp.StatusCode = HttpStatusCode.OK
                resp.Content = New StringContent(content, Encoding.UTF8, "application/json")
            Catch ex As FoodOrderException
                resp.StatusCode = HttpStatusCode.NotFound
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function

        Public Function PostValue(<FromBody()> ByVal item As FoodMenu) As HttpResponseMessage
            Try
                Dim flag As Integer = menuOp.AddFoodMenu(item)
                Dim resp = New HttpResponseMessage
                resp.StatusCode = HttpStatusCode.Created
                resp.Content = New StringContent(flag, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotAcceptable
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function

        Public Function PutValue(<FromBody()> ByVal item As FoodMenu) As HttpResponseMessage
            Try
                Dim flag As Integer = menuOp.UpdateFoodMenu(item)
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
                Dim flag As Integer = menuOp.DeleteFoodMenuById(id)
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