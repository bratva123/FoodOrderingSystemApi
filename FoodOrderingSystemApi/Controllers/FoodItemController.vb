Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports FoodOrderingSystem
Imports Newtonsoft.Json

Public Class FoodItemController
    Inherits ApiController
    Dim catOp As FoodItemOperation
    Dim resp As New HttpResponseMessage
    Public Sub New()
        Me.catOp = New FoodItemOperation
    End Sub

    <Route("api/FoodItem/getByNameAndCatId/{ch}/{id}")>
    <HttpGet>
    Public Function GetValues(ch As String, id As String) As List(Of FoodItem)

        Dim items = catOp.GetByNameAndCategoryId(ch, Val(id))
        Return items
    End Function

    <Route("api/FoodItem/getByName/{ch}/")>
    <HttpGet>
    Public Function GetItemByName(ch As String) As HttpResponseMessage
        Dim items = catOp.GetItemsByName(ch)
        Dim content = JsonConvert.SerializeObject(items)
        resp.StatusCode = HttpStatusCode.OK
        resp.Content = New StringContent(content, Encoding.UTF8, "application/json")
        Return resp
    End Function

    <Route("api/FoodItem/getAllItem/")>
    <HttpGet>
    Public Function GetALlItem() As HttpResponseMessage
        Try
            Dim items = catOp.GetAllFoodItem()
            Dim content = JsonConvert.SerializeObject(items)
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
            Dim item As New FoodItem
            item = catOp.GetItemById(id)
            Dim content = JsonConvert.SerializeObject(item)
            resp.StatusCode = HttpStatusCode.OK
            resp.Content = New StringContent(content, Encoding.UTF8, "application/json")
        Catch ex As Exception
            resp.StatusCode = HttpStatusCode.NotFound
            resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
        End Try
        Return resp
    End Function

    Public Function PostValue(<FromBody()> ByVal category As FoodItem) As HttpResponseMessage
        Try
            Dim flag As Integer = catOp.AddFoodItem(category)
            resp.StatusCode = HttpStatusCode.Created
            resp.Content = New StringContent(flag, Encoding.UTF8, "application/json")
        Catch ex As Exception
            resp.StatusCode = HttpStatusCode.NotAcceptable
            resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
        End Try

        Return resp
    End Function

    Public Function PutValue(<FromBody()> ByVal category As FoodItem) As HttpResponseMessage
        Try
            Dim flag As Integer = catOp.UpdateFoodItems(category)
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
            Dim flag As Integer = catOp.DeleteFoodItemById(id)
            resp.StatusCode = HttpStatusCode.OK
            resp.Content = New StringContent(flag, Encoding.UTF8, "application/json")
        Catch ex As Exception
            resp.StatusCode = HttpStatusCode.NotFound
            resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
        End Try
        Return resp
    End Function
End Class
