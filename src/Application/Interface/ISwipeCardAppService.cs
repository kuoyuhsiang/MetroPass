using MetroPass.Application.DTOs;

namespace MetroPass.Application.Interface;

public interface ISwipeCardAppService
{
    Task<SwipeResponseDTO> SwipeHandler(SwipeRequestDTO swipeRequestDTO);
}