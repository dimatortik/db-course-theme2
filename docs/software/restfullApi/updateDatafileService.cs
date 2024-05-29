using System.Security.Cryptography;
using System.Text;
using Lab6_DB.Context;
using Lab6_DB.Contracts;
using Lab6_DB.Migrations;
using Newtonsoft.Json;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;


namespace Lab6_DB.Services;

public class UpdateDatafileService(MyDbContext context, ChangeTrackerService changeTrackerService)
{
    public async Task<Result<UpdateResponse>> UpdateDatafile(UpdateDatasetRequest request)
    { 
        var dataset = await context.Datasets
            .FindAsync(request.DatasetId);
        if (dataset == null)
        {
            return Result.Failure<UpdateResponse>("Dataset not found");
        }
        
        var primaryDatafile = await context.Datafiles.FindAsync(dataset.DatafileId);
        if (primaryDatafile == null)
        {
            return Result.Failure<UpdateResponse>("Datafile not found");
        }
        var finalDatafile = new Datafile
        {
            Guid = primaryDatafile.Guid,
            Alias = request.Datafile.Alias ?? primaryDatafile.Alias,
            Mime = request.Datafile.Mime ?? primaryDatafile.Mime,
            Description = request.Datafile.Description ?? primaryDatafile.Description,
            Size = request.Datafile.Size,
            UploadedAt = DateTime.UtcNow,
            UserId = request.UserId,
            Url = request.Datafile.Url
        };
        await context.Datafiles.AddAsync(finalDatafile);
        await context.SaveChangesAsync();
        
        dataset.DatafileId = finalDatafile.Id;
        await context.SaveChangesAsync();
        
        var diff = changeTrackerService.CompareDatafiles(
            DatafilesForChangesCheck.ToEntity(primaryDatafile), 
            DatafilesForChangesCheck.ToEntity(finalDatafile));

        var update = new Update
        {
            Hash = ComputeSha256Hash(request.Message),
            UpdatedAt = DateTime.UtcNow,
            Message = request.Message,
            Difference = JsonConvert.SerializeObject(diff),
            UserId = request.UserId,
            DatasetId = request.DatasetId,

        };
        await context.Updates.AddAsync(update);
        await context.SaveChangesAsync();
        
        return Result.Success(UpdateResponse.ToResponse(update, diff));
    }    
    
    public async Task<Result<List<UpdateResponse>>> GetUpdatesById(int datasetId)
    {
        var updates = await context.Updates
            .Where(u => u.DatasetId == datasetId)
            .OrderBy(u => u.UpdatedAt)
            .ToListAsync();
        if (updates.Count == 0)
        {
            return Result.Failure<List<UpdateResponse>>("No updates found");
        }
        
        return Result.Success(UpdateResponse.ToList(updates));
    }
    
    public string ComputeSha256Hash(string rawData)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
    
}
