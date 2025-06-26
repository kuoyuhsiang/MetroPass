using System.ComponentModel.DataAnnotations;
using MetroPass.Domain.Enums;

namespace MetroPass.Presentation.WebApi.Models.Request;

public class SwipeEntryRequest
{
    [Required]
    public string? CardId { get; set; }      

    [Required]
    public DateTime Timestamp { get; set; }
}