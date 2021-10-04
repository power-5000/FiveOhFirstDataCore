using FiveOhFirstDataCore.Data.Structures.Calendar;
using Microsoft.AspNetCore.Components;

namespace FiveOhFirstDataCore.Components.Calendar.Render;

public partial class Event
{
    [Parameter]
    public double? Top { get; set; }

    [Parameter]
    public double? Left { get; set; }

    [Parameter]
    public double? Width { get; set; }

    [Parameter]
    public double? Height { get; set; }

    [Parameter]
    public CalendarEventData? EventData { get; set; }

    [CascadingParameter]
    public Calendar Calendar { get; set; }

    string Style { get; set; }

    protected override void OnParametersSet()
    {

        var style = new List<string>();

        if (Top.HasValue)
        {
            style.Add($"top: {Top}em");
        }

        if (Left.HasValue)
        {
            style.Add($"left: {Left}%");
        }

        if (Width.HasValue)
        {
            style.Add($"width: {Width}%");
        }

        if (Height.HasValue)
        {
            style.Add($"height: {Height}em");
        }

        Style = String.Join(";", style);
    }

}

//TODO: Add onclick for event
