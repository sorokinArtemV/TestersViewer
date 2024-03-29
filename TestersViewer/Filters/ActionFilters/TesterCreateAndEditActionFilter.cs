using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceContracts;
using TestersViewer.Controllers;

namespace TestersViewer.Filters.ActionFilters;

public class TesterCreateAndEditActionFilter : IAsyncActionFilter
{
    private readonly IDevStreamsService _devStreamsService;

    public TesterCreateAndEditActionFilter(IDevStreamsService devStreamsService)
    {
        _devStreamsService = devStreamsService;
    }


    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.Controller is TestersController testersController)
        {
            if (!testersController.ModelState.IsValid)
            {
                var devStreams = await _devStreamsService.GetAllDevStreams();
                testersController.ViewBag.DevStreams = devStreams.Select(x => new SelectListItem
                {
                    Text = x.DevStreamName,
                    Value = x.DevStreamId.ToString()
                });

                testersController.ViewBag.Errors = testersController.ModelState.Values.SelectMany(x => x.Errors)
                    .Select(e => e.ErrorMessage).ToList();

                var tester = context.ActionArguments["tester"];

                // short circuit
                // ReSharper disable once Mvc.ViewNotResolved
                context.Result = testersController.View(tester);
            }
            else
            {
                await next();
            }
        }
        else
        {
            await next();
        }
    }
}