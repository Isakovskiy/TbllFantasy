using System.Net;

namespace TbllFantasy.Middlewares;

public class ExceptionHandlingMiddleware
{
	public ExceptionHandlingMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	private readonly RequestDelegate _next;

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch(Exception ex)
		{
			//logging
			context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
			Console.WriteLine(ex);
		}
	}
}
