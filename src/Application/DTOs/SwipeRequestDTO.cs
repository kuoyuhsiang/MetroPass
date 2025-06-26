using MetroPass.Domain.Enums;

namespace MetroPass.Application.DTOs;

public class SwipeRequestDTO
{
    public string CardId { get; set; }

    public DateTime TimeStamp { get; set; }

    public MetroStation MetroStation { get; set; }
}
