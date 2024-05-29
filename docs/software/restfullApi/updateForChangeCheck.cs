using Lab6_DB.Migrations;

namespace Lab6_DB.Services;

public class DatafilesForChangesCheck
{
    public string Alias { get; set; } = null!;

    public string Mime { get; set; } = null!;

    public string Description { get; set; } = null!;

    public float Size { get; set; }

    public DateTime UploadedAt { get; set; }

    public int UserId { get; set; }

    public string? Url { get; set; }
    
    public static DatafilesForChangesCheck ToEntity(Datafile datafile)
    {
        return new DatafilesForChangesCheck
        {
            Alias = datafile.Alias,
            Mime = datafile.Mime,
            Description = datafile.Description,
            Size = datafile.Size,
            UploadedAt = datafile.UploadedAt,
            UserId = datafile.UserId,
            Url = datafile.Url
        };
    }
}
    