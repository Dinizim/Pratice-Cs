using Asp.Versioning;
using AutoMapper;
using EmployeeManeger.Application.ViewModel;
using EmployeeManeger.Domain.DTOs;
using EmployeeManeger.Domain.Models.EmployeeAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManeger.Controllers;

[ApiVersion(1.0)]
[ApiController]
[Route("api/v{version:apiVersion}/Employee")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ILogger<EmployeeController> _logger;
    private readonly IMapper _mapper;

    public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger, IMapper mapper)
    {
        _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public IActionResult Get(int pageNumber, int pageQuantity)
    {
        return Ok(_employeeRepository.Get(pageNumber, pageQuantity));
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id) //with AutoMapper
    {
        var employee = _employeeRepository.get(id);
        if (employee == null)
        {
            return NotFound();
        }
        var employeeDTOs = _mapper.Map<EmployeeDTO>(employee);

        return Ok(employeeDTOs);
    }

    [HttpPost]
    [Authorize]
    public IActionResult Add([FromForm] EmployeeViewModel employeeView)
    {
        var filePath = Path.Combine("Storage", employeeView.Photo.FileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            employeeView.Photo.CopyTo(stream);
        }

        var employee = new Employee(employeeView.Name, employeeView.Age, filePath);
        _employeeRepository.Add(employee);
        return Ok();
    }

    [HttpPost("{id}/download")]
    [Authorize]
    public IActionResult DownloadPhoto(int id)
    {
        var employee = _employeeRepository.get(id);
        if (employee == null)
        {
            return NotFound();
        }
        var dataBytes = System.IO.File.ReadAllBytes(employee.photo);

        return File(dataBytes, "image/jpeg");
    }

    [HttpGet("log")]
    public IActionResult Log()
    {
        _logger.LogError("This is Logger Error");
        _logger.LogWarning("This is Logger Warning");
        _logger.LogInformation("This is Logger Information");
        _logger.LogCritical("This is Logger Critical");

        return Ok();
    }
}