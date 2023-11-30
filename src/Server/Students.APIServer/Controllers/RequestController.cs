using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.APIServer.Services;
using Students.Models;
using System;
using System.Diagnostics;

namespace Students.APIServer.Controllers;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class RequestController : Controller
{
    //private readonly IRequestRepository _requestRepository;
    private readonly ILogger<Request> _logger;
    private readonly IRequestService _requestService;
    public RequestController(IRequestService service, ILogger<Request> logger) 
    {
        //_requestRepository = requestRepository;
        _logger = logger;
        _requestService = service;
    }
    [HttpGet("GetByGUID")]
    public async Task<IActionResult> FindById(Guid id)
    {

        try
        {
            var form = await _requestService.FindById(id);
            if (form == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new DefaultResponse
                    {
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                    });
            }

            return StatusCode(StatusCodes.Status200OK, form);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting Entity by Id");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new DefaultResponse
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }
    }
    [HttpPost("GetRequestByPhoneAsync")]
    public async Task<IActionResult> FindRequestByPhoneFromRequestAsync(Request item)
    {
        try
        {
            var form = await _requestService.FindRequestByPhoneFromRequestAsync(item);
            if (form == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new DefaultResponse
                    {
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                    });
            }

            return StatusCode(StatusCodes.Status200OK, form);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting Entity by Id");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new DefaultResponse
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }
    }
    [HttpPost("GetRequestByEmailAsync")]
    public async Task<IActionResult> FindRequestByEmailFromRequestAsync(Request item)
    {
        try
        {
            var form = await _requestService.FindRequestByEmailFromRequestAsync(item);
            if (form == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new DefaultResponse
                    {
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                    });
            }

            return StatusCode(StatusCodes.Status200OK, form);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting Entity by Id");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new DefaultResponse
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var form = await _requestService.Get();
            if (form == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new DefaultResponse
                    {
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                    });
            }

            return StatusCode(StatusCodes.Status200OK, form);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting Entity by Id");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new DefaultResponse
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }
    }
    [HttpGet("GetAll2")]
    public async Task<IActionResult> Get(Func<Request, bool> predicate)
    {
        try
        {
            var form = await _requestService.Get(predicate);
            if (form == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new DefaultResponse
                    {
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                    });
            }

            return StatusCode(StatusCodes.Status200OK, form);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting Entity by Id");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new DefaultResponse
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }
    }

    [HttpGet("FindRequesListByStudentGuidAsync")]
    public async Task<IActionResult> FindRequesListByStudentGuidAsync(Guid id)
    {
        try
        {
            var form = await _requestService.FindRequesListByStudentGuidAsync(id);
            if (form == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new DefaultResponse
                    {
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                    });
            }

            return StatusCode(StatusCodes.Status200OK, form);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting Entity by Id");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new DefaultResponse
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }
    }
    [HttpPost("Create")]
    public async Task<IActionResult> Create(Request item)
    {
        try
        {
            var form = await _requestService.Create(item);
            if (form == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new DefaultResponse
                    {
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                    });
            }

            return StatusCode(StatusCodes.Status200OK, form);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting Entity by Id");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new DefaultResponse
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }
    }
    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove(Request item)
    {
        try
        {
            await _requestService.Remove(item);
            
            return StatusCode(StatusCodes.Status200OK);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting Entity by Id");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new DefaultResponse
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }
    }
    [HttpPut("Update")]
    public async Task<IActionResult> Update(Request item)
    {
        try
        {
            var form = await _requestService.Update(item);
            if (form == null)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new DefaultResponse
                    {
                        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                    });
            }

            return StatusCode(StatusCodes.Status200OK, form);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while getting Entity by Id");
            return StatusCode(StatusCodes.Status500InternalServerError,
                new DefaultResponse
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                });
        }
    }
}
    
