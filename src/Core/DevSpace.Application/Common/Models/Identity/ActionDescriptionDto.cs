namespace DevSpace.Application.Common.Models.Identity;

public class ActionDescriptionDto
{
    public string Key => $"{AreaName}:{ControllerName}:{ActionName}";

    public string AreaName { get; set; } = default!;

    public string ControllerName { get; set; } = default!;
    public string ControllerDisplayName { get; set; } = default!;

    public string ActionName { get; set; } = default!;

    public string ActionDisplayName { get; set; } = default!;
    public string ControllerDescription { get; set; } = default!;
}
