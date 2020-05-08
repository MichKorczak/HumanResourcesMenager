namespace HumanResourcesManager.Api.Infrastructure
{
	using System;
	using System.Net;
	using System.Threading.Tasks;
	using HumanResourcesManager.Core.Exceptions;
	using Microsoft.AspNetCore.Http;
	using Newtonsoft.Json;

	public class CustomExceptionAttribute
	{
		private readonly RequestDelegate _next;

		public CustomExceptionAttribute(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (ManagerException ex)
			{
				await HandleExceptionAsync(httpContext, ex);
			}
		}

		private async Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			switch (exception.Message)
			{
				case ErrorsMessage.RegistrationErrorMessage:
					context.Response.ContentType = "application/json";
					context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

					var response =
						JsonConvert.SerializeObject(new { context.Response.StatusCode, exception.Message });
					await context.Response.WriteAsync(response);
					break;
				default:
					break;
			}
		}
	}
}