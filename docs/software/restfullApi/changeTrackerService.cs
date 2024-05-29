using CSharpFunctionalExtensions;
namespace Lab6_DB.Services;

public class ChangeTrackerService
{

    public Dictionary<string, object> CompareDatafiles(DatafilesForChangesCheck oldDatafile, DatafilesForChangesCheck newDatafile)
    {
        var changes = new Dictionary<string, object>();

        var properties = typeof(DatafilesForChangesCheck).GetProperties();
        foreach (var property in properties)
        {
            var oldValue = property.GetValue(oldDatafile);
            var newValue = property.GetValue(newDatafile);

            if (oldValue != null && oldValue.Equals(newValue))
            {
                changes.Add(property.Name, "no changes");
            }
            else if (oldValue != null && !oldValue.Equals(newValue))
            {
                changes.Add(property.Name, new { old = oldValue, @new = newValue });
            }
            else
            {
                changes.Add(property.Name, "no changes");
            }
        }

        return changes;
    }

}