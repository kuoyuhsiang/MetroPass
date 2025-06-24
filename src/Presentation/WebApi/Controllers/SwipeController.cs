using System.Threading.Tasks;
using AutoMapper;
using MetroPass.Application.DTOs;
using MetroPass.Application.Interface;
using MetroPass.Presentation.WebApi.Models.Request;
using MetroPass.Presentation.WebApi.Models.Response;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MetroPass.Presentation.WebApi;

[ApiController]
public class SwipeController : ControllerBase
{
    private readonly ISwipeCardAppService _SwipeCardAppService;
    private readonly IMapper _mapper;

    public SwipeController(ISwipeCardAppService swipeCardAppService,
                           IMapper mapper)
    {
        _SwipeCardAppService = swipeCardAppService;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("Entry")]
    public async Task<ActionResult<SwipeEntryResponse>> SwipeEntry([FromBody] SwipeEntryRequest request)
    {
        var swipeRequestDTO = _mapper.Map<SwipeRequestDTO>(request);
        var result = await _SwipeCardAppService.SwipeHandler(swipeRequestDTO);

        var response = _mapper.Map<SwipeEntryResponse>(result);
        return Ok(response);
    }
}