using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Students.APIServer.Repository;
using Students.Models;
using System;
using System.Diagnostics;

namespace Students.APIServer.Controllers;

[ApiController]
[Route("[controller]")]
[ApiVersion("1.0")]
public class RequestController : GenericAPiController<Request>
{
    
    private readonly ILogger<Request> _logger;
    private readonly IRequestRepository _requestRepository;
    public RequestController(IGenericRepository<Request> repository, ILogger<Request> logger, IRequestRepository requestRepository) : base(repository, logger)
    {
        _requestRepository = requestRepository;
        _logger = logger;
    }
    public override async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var form = await _requestRepository.FindById(id);
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

    public override async Task<IActionResult> Post(Request request)
    {
        try
        {
            var form = await _requestRepository.Create(request);
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
    
