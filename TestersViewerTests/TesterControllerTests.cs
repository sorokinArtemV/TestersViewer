using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using TestersViewer.Controllers;
using Xunit.Abstractions;

namespace TestersViewerTests;

public class TesterControllerTests
{
    private readonly IDevStreamsService _devStreamsService;
    private readonly Mock<IDevStreamsService> _devStreamsServiceMock;
    private readonly Fixture _fixture;
    private readonly ILogger<TestersController> _logger;
    private readonly Mock<ILogger<TestersController>> _loggerMock;

    private readonly ITestersAdderService _testersAdderService;

    private readonly Mock<ITestersAdderService> _testersAdderServiceMock;
    private readonly ITestersDeleterService _testersDeleterService;
    private readonly Mock<ITestersDeleterService> _testersDeleterServiceMock;
    private readonly ITestersGetterService _testersGetterService;
    private readonly Mock<ITestersGetterService> _testersGetterServiceMock;
    private readonly ITestersSorterService _testersSorterService;
    private readonly Mock<ITestersSorterService> _testersSorterServiceMock;
    private readonly ITestersUpdaterService _testersUpdaterService;
    private readonly Mock<ITestersUpdaterService> _testersUpdaterServiceMock;
    private readonly ITestOutputHelper _testOutputHelper;


    public TesterControllerTests(ITestOutputHelper testOutputHelper)
    {
        _devStreamsServiceMock = new Mock<IDevStreamsService>();
        _devStreamsService = _devStreamsServiceMock.Object;
        _testOutputHelper = testOutputHelper;
        _fixture = new Fixture();
        _loggerMock = new Mock<ILogger<TestersController>>();
        _logger = _loggerMock.Object;

        _testersAdderServiceMock = new Mock<ITestersAdderService>();
        _testersDeleterServiceMock = new Mock<ITestersDeleterService>();
        _testersSorterServiceMock = new Mock<ITestersSorterService>();
        _testersGetterServiceMock = new Mock<ITestersGetterService>();
        _testersUpdaterServiceMock = new Mock<ITestersUpdaterService>();

        _testersAdderService = _testersAdderServiceMock.Object;
        _testersDeleterService = _testersDeleterServiceMock.Object;
        _testersGetterService = _testersGetterServiceMock.Object;
        _testersSorterService = _testersSorterServiceMock.Object;
        _testersUpdaterService = _testersUpdaterServiceMock.Object;
    }

    #region Index

    [Fact]
    public async Task Index_ShallReturnViewResult_WithTestersList()
    {
        var testersResponseList = _fixture.Create<List<TesterResponse>>();
        var testersController = new TestersController(
            _devStreamsService,
            _logger,
            _testersGetterService,
            _testersAdderService,
            _testersSorterService,
            _testersDeleterService,
            _testersUpdaterService
        );

        _testersGetterServiceMock
            .Setup(x => x.GetFilteredTesters(It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(testersResponseList);

        _testersSorterServiceMock
            .Setup(x => x.GetSortedTesters(
                It.IsAny<List<TesterResponse>>(),
                It.IsAny<string>(),
                It.IsAny<SortOrderOptions>()))
            .ReturnsAsync(testersResponseList);

        var actionResult = await testersController.Index(
            _fixture.Create<string>(),
            _fixture.Create<string>(),
            _fixture.Create<string>(),
            _fixture.Create<SortOrderOptions>());

        var viewResult = Assert.IsType<ViewResult>(actionResult);

        viewResult.ViewData.Model.Should().BeAssignableTo<IEnumerable<TesterResponse>>();
        viewResult.ViewData.Model.Should().BeEquivalentTo(testersResponseList);
    }

    #endregion

    #region Create

    [Fact]
    public async Task Create_ShallRedirectToIndex_IfNoModelErrorsWereFound()
    {
        var testerAddRequest = _fixture.Create<TesterAddRequest>();
        var testerResponse = _fixture.Create<TesterResponse>();
        var devStreams = _fixture.Create<List<DevStreamResponse>>();

        _devStreamsServiceMock
            .Setup(x => x.GetAllDevStreams())
            .ReturnsAsync(devStreams);

        _testersAdderServiceMock
            .Setup(x => x.AddTester(It.IsAny<TesterAddRequest>()))
            .ReturnsAsync(testerResponse);

        var testersController = new TestersController(
            _devStreamsService,
            _logger,
            _testersGetterService,
            _testersAdderService,
            _testersSorterService,
            _testersDeleterService,
            _testersUpdaterService
        );

        var actionResult = await testersController.Create(testerAddRequest);

        var redirectResult = Assert.IsType<RedirectToActionResult>(actionResult);

        redirectResult.ActionName.Should().Be("Index");
    }

    #endregion
}