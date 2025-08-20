# How to get bounds of the WPF GridControl

This example demonstrates how to get bounds of the [WPF GridControl](https://help.syncfusion.com/wpf/gridcontrol/overview).

`GridControl` does not have built-in property to get it’s bounds. Please use any one of the following suggestions to get the grid bounds.

### Suggestion 1

In order to get the grid’s position on the screen with size, the `FrameworkElement.TransformToAncestor` method can be used with parent container instance (window).

``` csharp
//parsing the grid as framework element with container
Rect rect = GetBoundingBox(grid as FrameworkElement, this);
private Rect GetBoundingBox(FrameworkElement element, Window containerWindow)
{
    GeneralTransform transform = element.TransformToAncestor(containerWindow);
    //To get the left and top location of the element.
    Point topLeft = transform.Transform(new Point(0, 0));
    //To get the right and bottom point of the element using height and width.
    Point bottomRight = transform.Transform(new Point(element.ActualWidth, element.ActualHeight));
    return new Rect(topLeft, bottomRight);
}
```

### Suggestion 2

`PointToScreen` method of grid and parent container can be used to get the position of GridControl in window by subtracting the window position from control position.

``` csharp
Point position = this.grid.PointToScreen(new Point(0d, 0d));
 Point controlPosition = this.PointToScreen(new Point(0d, 0d));
//To get grid's exact position on the window.
position.X -= controlPosition.X;
position.Y -= controlPosition.Y;
```