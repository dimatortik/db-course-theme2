using Lab6_DB.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab6_DB.Controllers;
[ApiController]
public class UpdateController : ControllerBase
{
    private readonly UpdateDatafileService _updateDatafileService;

    public UpdateController( UpdateDatafileService updateDatafileService)
    {
        _updateDatafileService = updateDatafileService;
    }

    [HttpPost]
    [Route("api/updates")]
    public async Task<IActionResult> Update([FromBody] UpdateDatasetRequest request)
    {
        var update = await _updateDatafileService.UpdateDatafile(request);
        return update.IsSuccess? Ok(update.Value) : BadRequest(update.Error);

    }
    [HttpGet]
    [Route("api/updates/{datasetId}")]
    public async Task<IActionResult> GetUpdates(int datasetId)
    {
        var updates = await _updateDatafileService.GetUpdatesById(datasetId);
        return updates.IsSuccess? Ok(updates.Value) : NotFound(updates.Error);
    }
}
