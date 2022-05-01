' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
''' 
Imports Windows.UI.Xaml.Controls.Maps
Imports Windows.Devices.Geolocation
Imports Windows.UI.Popups

Public NotInheritable Class MainPage
    Inherits Page

    Public Sub New()
        InitializeComponent()
        CrearMapaDinamicamente()
    End Sub

    Public Async Sub CrearMapaDinamicamente()
        Dim myMap2 = New MapControl()
        myMap2.Style = MapStyle.Terrain
        myMap2.ZoomInteractionMode = MapInteractionMode.GestureAndControl
        myMap2.TiltInteractionMode = MapInteractionMode.GestureAndControl
        myMap2.Width = 1000
        myMap2.Height = 600
        myMap2.HorizontalAlignment = HorizontalAlignment.Left
        myMap2.VerticalAlignment = VerticalAlignment.Top
        myMap2.Margin = New Thickness(100, 100, 0, 0)
        myMap2.MapServiceToken = "d1nT6L6BIW1KVTo7492l~AyUKF1AqM59hXqXhVXEIEw~AiiTK8OBYeGp0a0Q0U85jJ9rEmjwhVPSEYlAyizxDGAauac2yBdVZmGSSWqnEDos"
        ParentPanel.Children.Add(myMap2)

        If (Await Geolocator.RequestAccessAsync() = GeolocationAccessStatus.Allowed) Then
            Dim geolocator = New Geolocator()
            Dim pos = Await geolocator.GetGeopositionAsync()
            Dim myPosition = pos.Coordinate.Point
            myMap2.Center = myPosition
            myMap2.ZoomLevel = 12
            myMap2.LandmarksVisible = True

            Dim myLandMarks = New List(Of MapElement)()

            Dim tes = New BasicGeoposition()
            tes.Latitude = -0.98989
            tes.Longitude = -78.56566

            Dim myPoint = New Geopoint(tes)

            Dim myMark = New MapIcon
            myMark.Location = myPoint
            myMark.Title = "TES"

            myLandMarks.Add(myMark)

            Dim landMarksLayer = New MapElementsLayer()
            landMarksLayer.MapElements = myLandMarks

            myMap2.Layers.Add(landMarksLayer)
            myMap2.Center = myPoint
            myMap2.ZoomLevel = 14


            'Dim messageDialog = New MessageDialog("Mensaje de prueba", "Prueba")
            'messageDialog.Commands.Add(New UICommand("Ok", New UICommandInvokedHandler(actionBoton)))
            'Await messageDialog.ShowAsync()

        End If


    End Sub

    Private Sub actionBoton()

    End Sub

End Class
