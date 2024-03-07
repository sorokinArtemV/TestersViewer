using ServiceContracts;
using ServiceContracts.DTO;
using Services;

namespace TestersViewerTests;

public class DevStreamsServiceTests
{
    private readonly IDevStreamsService _devStreamsService;

    public DevStreamsServiceTests()
    {
        _devStreamsService = new DevStreamsService();
    }


    #region AddDevStream

    [Fact]
    public void AddDevStream_ShouldThrowArgumentNullException_WhenDevStreamAddRequestIsNull()
    {
        DevStreamAddRequest? request = null;

        Assert.Throws<ArgumentNullException>(() => _devStreamsService.AddDevStream(request));
    }

    [Fact]
    public void AddDevStream_ShouldThrowArgumentException_WhenDevStreamAddRequestNameIsNull()
    {
        var request = new DevStreamAddRequest { DevStreamName = null };

        Assert.Throws<ArgumentNullException>(() => _devStreamsService.AddDevStream(request));
    }

    [Fact]
    public void AddDevStream_ShouldThrowArgumentException_WhenDevStreamAddRequestNameIsDuplicated()
    {
        var requestOne = new DevStreamAddRequest { DevStreamName = "Crew" };
        var requestTwo = new DevStreamAddRequest { DevStreamName = "Crew" };

        Assert.Throws<ArgumentException>(() =>
        {
            _devStreamsService.AddDevStream(requestOne);
            _devStreamsService.AddDevStream(requestTwo);
        });
    }

    [Fact]
    public void AddDevStream_ShouldTAddDevStreamToListOfDevStreams_WhenDevStreamAddRequestIsValid()
    {
        var request = new DevStreamAddRequest() { DevStreamName = "Crew" };

        var response = _devStreamsService.AddDevStream(request);

        Assert.True(response.DevStreamId != Guid.Empty);
    }

    #endregion

    #region GetAllDevStreams

    [Fact]
    public void GetAllDevStreams_ShouldBeEmpty_BeforeAddingDevStreams()
    {
        var devStreamsList = _devStreamsService.GetAllDevStreams();

        Assert.Empty(devStreamsList);
    }

    [Fact]
    public void GetAllDevStreams_ShouldShowAllDevStreams_WheDevStreamsAreAdded()
    {
        List<DevStreamResponse> devStreamsExpectedResponses = [];

        List<DevStreamAddRequest> devStreamAddRequests =
        [
            new DevStreamAddRequest { DevStreamName = "Crew" },
            new DevStreamAddRequest { DevStreamName = "New Year" },
            new DevStreamAddRequest { DevStreamName = "Artillery" }
        ];

        foreach (var devStreamAddRequest in devStreamAddRequests)
        {
            devStreamsExpectedResponses.Add(_devStreamsService.AddDevStream(devStreamAddRequest));
        }
        
        var devStreamsList = _devStreamsService.GetAllDevStreams();

        foreach (var expectedResponse in devStreamsExpectedResponses)
        {
            Assert.Contains(expectedResponse, devStreamsList);
        }
    }

    #endregion
}