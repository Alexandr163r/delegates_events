namespace DelegatesEventsConsoleApp.Services;

public class FileSearcher
{
    public event EventHandler<FileFoundEventArgs>? FileFound;

    public void Search(string directory)
    {
        foreach (var file in Directory.EnumerateFiles(directory))
        {
            var args = new FileFoundEventArgs(file);
            FileFound?.Invoke(this, args);
                    
            if (args.CancelRequested)
            {
                return;
            }
        }
    }
}