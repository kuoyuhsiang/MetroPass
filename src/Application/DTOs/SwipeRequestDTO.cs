using MetroPass.Domain.Enums;

namespace MetroPass.Application.DTOs;

public class SwipeRequestDTO
{
    public string CardNo { get; set; } = string.Empty;

    public int Fare { get; set; }

    public MetroStation MetroStation { get; set; }
    
    public Direction Direction { get; set; }
}
