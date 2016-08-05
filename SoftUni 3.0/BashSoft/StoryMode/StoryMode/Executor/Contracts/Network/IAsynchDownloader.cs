namespace Executor.Contracts.Network
{
    public interface IAsynchDownloader
    {
        void DownloadAsync(string fileURL);
    }
}
