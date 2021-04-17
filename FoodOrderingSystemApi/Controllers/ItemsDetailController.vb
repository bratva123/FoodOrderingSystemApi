Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports Newtonsoft.Json
Imports FoodOrderingSystem

Namespace Controllers
    Public Class ItemsDetailController
        Inherits ApiController

        Dim resp As New HttpResponseMessage
        Dim itemdetOp As ItemsDetailOperation
        Public Sub New()
            itemdetOp = New ItemsDetailOperation
        End Sub


        Public Function GetValue(ByVal id As Integer) As HttpResponseMessage
            Try
                Dim itemDet = itemdetOp.GetItemsDetailById(id)
                Dim content = JsonConvert.SerializeObject(itemDet)
                resp.StatusCode = HttpStatusCode.OK
                resp.Content = New StringContent(content, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotFound
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function

        Public Function PostValue(<FromBody()> ByVal itemDet As ItemsDetail) As HttpResponseMessage
            Try
                Dim flag As Integer = itemdetOp.AddItemsDetail(itemDet)
                Dim resp = New HttpResponseMessage
                resp.StatusCode = HttpStatusCode.Created
                resp.Content = New StringContent(flag, Encoding.UTF8, "application/json")
            Catch ex As Exception
                resp.StatusCode = HttpStatusCode.NotAcceptable
                resp.Content = New StringContent(ex.Message, Encoding.UTF8, "application/json")
            End Try
            Return resp
        End Function

        Public Function PutValue(<FromBody()> ByVal item As ItemsDetail) As HttpResponseMessage
            Try
                Dim flag As Integer = itemdetOp.UpdateItemsDetail(item)
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