using ServiceContracts.DTO;

namespace ServiceContracts;

/// <summary>
/// Represents business logic to manipulate Tester entity
/// </summary>
public interface ITestersService
{
    /// <summary>
    /// Adds a new Tester to list of Testers
    /// </summary>
    /// <param name="testerAddRequest">TesterAddRequest</param>
    /// <returns>Returns TesterResponse with generated TesterId</returns>
    TesterResponse AddTester(TesterAddRequest? testerAddRequest);

    /// <summary>
    /// Gets all Testers
    /// </summary>
    /// <returns>Returns a List of TestersResponse objects</returns>
    List<TesterResponse> GetAllTesters();

    /// <summary>
    /// Gets Tester by id
    /// </summary>
    /// <param name="id">Tester Guid</param>
    /// <returns>Returns TesterResponse object</returns>
    TesterResponse? GetTesterById(Guid? id);

    /// <summary>
    ///  Returns filtered list of Testers filtered by searchBy and searchString
    /// </summary>
    /// <param name="searchBy">Search field to filter</param>
    /// <param name="searchString">Search string to search</param>
    /// <returns>Return filtered list based on searchBy and searchString</returns>
    List<TesterResponse> GetFilteredTesters(string searchBy, string searchString);
}