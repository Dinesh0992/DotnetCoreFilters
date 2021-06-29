using System;
using System.ComponentModel.DataAnnotations;
using DotnetCoreFilters.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCoreFilters.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [DebugResourceFilter2]
    //[DebugResourceFilter]  done in startup 
     //[DebugActionFilter]
    public class ProductController : Controller
    {
        //  [Route("products")]
        [HttpGet]
        public string Get()
        {
            return "Lots of Products";
        }
        /*
      //  [Route("products/{id}")]
      [HttpGet("{id}")]
        public string GetbyId(int id, [FromQuery]bool isActive)
        {
            return $"Lots of Products:{id}, Status : {isActive}";
        }
        */

        [HttpGet]
        public string GetbyObjectId([FromQuery] ProductDTO pd)
        {
            return $"Lots of ProductID:{pd.Id}, ProductName : {pd.name}";
        }

        [HttpPost]
      [DebugActionFilter]
      [DebugResourceFilter3]
        public IActionResult GetbyObjectPost([FromBody] ProductDTO pd)
        {
            // if (pd.ReleaseDate >= DateTime.Today)
            // {
            //     ModelState.AddModelError(nameof(pd.ReleaseDate), "The product release should be  a past date.");
            //     return BadRequest(ModelState);
            // }
            return Ok($"Lots of ProductID:{pd.Id}, ProductName : {pd.name}");
        }

        public class ProductDTO
        {
            [Required]
            public int Id { get; set; }
            [Required]
            [StringLength(10, ErrorMessage = "name max length is 10")]
            public string name { get; set; }
            [Required]
            [ReleaseDatePastValidate]
            public DateTime ReleaseDate { get; set; }
        }

        public class ReleaseDatePastValidate : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var prdDTO = (ProductDTO)validationContext.ObjectInstance;
                if (prdDTO.ReleaseDate >= DateTime.Today)
                {
                    return new ValidationResult("The product release should be  a past date");
                }
                return ValidationResult.Success;

            }

        }

    }
}
