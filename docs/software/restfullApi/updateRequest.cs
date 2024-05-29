namespace Lab6_DB.Services;

public record UpdateDatasetRequest(
    string Message,
    int DatasetId,
    int UserId,
    UpdateDatafileRequest Datafile);



public record UpdateDatafileRequest(
    string Url,
    string? Alias,
    string? Mime,
    string? Description,
    float Size);


