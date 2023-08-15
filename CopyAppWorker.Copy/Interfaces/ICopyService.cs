namespace CopyAppWorker.Copy.Interfaces;

public interface ICopyService
{
    public Task<string> ToCopy();
}