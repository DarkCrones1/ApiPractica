using Microsoft.AspNetCore.Mvc;
using ContosoUniversity.Reposotories.PersonRepository;
using ContosoUniversity.Domain.Entities;

public class PersonController :ControllerBase
{
    private PersonRepository _Prepository;
    public PersonController()
    {
        _Prepository = new PersonRepository();
    }

    [HttpGet]
    [Route("Person")]
    public IActionResult Get(){
        return Ok(_Prepository.Get());
    }

    [HttpGet]
    [Route("Person/{id:int}")]
    public IActionResult Get(int id){
        return Ok(_Prepository.Get(id));
    }

    [HttpGet]
    [Route("Person/findby")]
    public IActionResult Get([FromQuery]Person person){
        return Ok(_Prepository.Get(person));
    }
}