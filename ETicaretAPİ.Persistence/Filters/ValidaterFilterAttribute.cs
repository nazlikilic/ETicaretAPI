using ETicaretAPİ.Domain.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ETicaretAPİ.APİ.Filters
{
   
    public class ValidaterFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                var errors= context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();

                context.Result= new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400, errors));
                
            }
        }


    }
}
