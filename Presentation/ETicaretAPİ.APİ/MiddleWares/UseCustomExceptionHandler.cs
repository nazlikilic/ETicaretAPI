using ETicaretAPİ.Domain.Entities.DTOs;
using ETicaretAPİ.Persistence.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace ETicaretAPİ.APİ.MiddleWares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomeException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException=> 404,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;

                    var response = CustomResponseDto<NoContentDto>.Fail(context.Response.StatusCode, exceptionFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));


                });
            });
        }

    }
}
