using Microsoft.AspNetCore.Mvc;
using ContosoUniversity.Reposotories.CourseRepository;
using ContosoUniversity.Domain.Entities;

public class CourseController :ControllerBase
{
    private CourseRepository _Crepository;
    public CourseController()
    {
        _Crepository = new CourseRepository();
    }

    [HttpGet]
    [Route("Course")]
    public IActionResult Get(){
        return Ok(_Crepository.Get());
    }

    [HttpGet]
    [Route("Course/{id:int}")]
    public IActionResult Get(int id){
        return Ok(_Crepository.Get(id));
    }

    [HttpGet]
    [Route("Course/findby")]
    public IActionResult Get([FromQuery]Course course){
        return Ok(_Crepository.Get(course));
    }
}