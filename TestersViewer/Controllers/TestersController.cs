using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;

namespace TestersViewer.Controllers;

[Route("[controller]")]
public class TestersController : Controller
{
    private readonly IDevStreamsService _devStreamsService;
    private readonly ITestersService _testersService;

    public TestersController(ITestersService testersService, IDevStreamsService devStreamsService)
    {
        _testersService = testersService;
        _devStreamsService = devStreamsService;
    }

    [Route("[action]")]
    [Route("/")]
    public IActionResult Index(
        string searchBy,
        string? searchString,
        string sortBy = nameof(TesterResponse.TesterName),
        SortOrderOptions sortOrder = SortOrderOptions.Asc)
    {
        // Search
        ViewBag.SearchFields = new Dictionary<string, string>
        {
            [nameof(TesterResponse.TesterName)] = "Name",
            [nameof(TesterResponse.DevStream)] = "Stream",
            [nameof(TesterResponse.Position)] = "Position",
            [nameof(TesterResponse.Skills)] = "Skills",
            [nameof(TesterResponse.Age)] = "Age",
            [nameof(TesterResponse.Email)] = "Email",
            [nameof(TesterResponse.Gender)] = "Gender",
            [nameof(TesterResponse.MonthsOfWorkExperience)] = "Works for"
        };

        var testers = _testersService.GetFilteredTesters(searchBy, searchString);

        ViewBag.CurrentSearchBy = searchBy;
        ViewBag.CurrentSearchString = searchString;

        // Sort
        var sortedTesters = _testersService.GetSortedTesters(testers, sortBy, sortOrder);

        ViewBag.CurrentSortBy = sortBy;
        ViewBag.CurrentSortOrder = sortOrder.ToString();

        return View(sortedTesters);
    }


    // triggers on click create
    [HttpGet]
    [Route("[action]")]
    public IActionResult Create()
    {
        var devStreams = _devStreamsService.GetAllDevStreams();
        ViewBag.DevStreams = devStreams;

        ViewBag.devStreams = devStreams.Select(x => new SelectListItem
        {
            Text = x.DevStreamName,
            Value = x.DevStreamId.ToString()
        });

        return View();
    }

    // accepts submitted form
    [HttpPost]
    [Route("[action]")]
    public IActionResult Create(TesterAddRequest tester)
    {
        if (!ModelState.IsValid)
        {
            var devStreams = _devStreamsService.GetAllDevStreams();
            ViewBag.DevStreams = devStreams;

            ViewBag.Errors = ModelState.Values.SelectMany(x => x.Errors).Select(e => e.ErrorMessage).ToList();

            return View();
        }

        var testerResponse = _testersService.AddTester(tester);

        return RedirectToAction("Index", "Testers");
    }

    [HttpGet]
    [Route("[action]/{testerId}")] // testers/1
    public IActionResult Edit(Guid testerId)
    {
        var testerResponse = _testersService.GetTesterById(testerId);
        if (testerResponse is null) return RedirectToAction("Index", "Testers");

        var testerUpdateRequest = testerResponse.ToTesterUpdateRequest();

        var devStreams = _devStreamsService.GetAllDevStreams();
        ViewBag.DevStreams = devStreams;

        ViewBag.devStreams = devStreams.Select(x => new SelectListItem
        {
            Text = x.DevStreamName,
            Value = x.DevStreamId.ToString()
        });

        return View(testerUpdateRequest);
    }

    [HttpPost]
    [Route("[action]/{testerId}")] // testers/1
    public IActionResult Edit(TesterUpdateRequest testerUpdateRequest)
    {
        var testerResponse = _testersService.GetTesterById(testerUpdateRequest.TesterId);
        if (testerResponse is null) return RedirectToAction("Index", "Testers");

        if (ModelState.IsValid)
        {
            var updatedTester = _testersService.UpdateTester(testerUpdateRequest);
            return RedirectToAction("Index", "Testers");
        }

        var devStreams = _devStreamsService.GetAllDevStreams();
        ViewBag.DevStreams = devStreams;

        ViewBag.devStreams = devStreams.Select(x => new SelectListItem
        {
            Text = x.DevStreamName,
            Value = x.DevStreamId.ToString()
        });

        return View(testerResponse.ToTesterUpdateRequest());
    }

    [HttpGet]
    [Route("[action]/{testerId}")]
    public IActionResult Delete(Guid? testerId)
    {
        var testerResponse = _testersService.GetTesterById(testerId);
        if (testerResponse is null) return RedirectToAction("Index", "Testers");

        return View(testerResponse);
    }

    [HttpPost]
    [Route("[action]/{testerId}")]
    public IActionResult Delete(TesterUpdateRequest testerUpdateRequest)
    {
        var testerResponse = _testersService.GetTesterById(testerUpdateRequest.TesterId);
        if (testerResponse is null) return RedirectToAction("Index", "Testers");

        _testersService.DeleteTester(testerUpdateRequest.TesterId);
        return RedirectToAction("Index", "Testers");
    }
}