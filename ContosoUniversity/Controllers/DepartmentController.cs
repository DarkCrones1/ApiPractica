using Microsoft.AspNetCore.Mvc;
using ContosoUniversity.Reposotories.DepartmentRepository;
using ContosoUniversity.Domain.Entities;

public class DepartmentController :ControllerBase
{
    private DepartmentRepository _Drepository;
    public DepartmentController()
    {
        _Drepository = new DepartmentRepository();
    }

    [HttpGet]
    [Route("Deparment")]
    public IActionResult Get(){
        return Ok(_Drepository.Get());
    }

    [HttpGet]
    [Route("Department/{id:int}")]
    public IActionResult Get(int id){
        return Ok(_Drepository.Get(id));
    }

    [HttpGet]
    [Route("Deparment/findby")]
    public IActionResult Get([FromQuery]Department department){
        return Ok(_Drepository.Get(department));
    }
}