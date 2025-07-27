namespace DelegatesEventsConsoleApp.Services;

public class FileFoundEventArgs : EventArgs
{
    public string FileName { get; }
    public bool CancelRequested { get; set; }

    public FileFoundEventArgs(string fileName)
    {
        FileName = fileName;
    }
}