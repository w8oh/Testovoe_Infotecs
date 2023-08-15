using System.IO.Compression;
using CopyAppWorker.Archive.Interfaces;

namespace CopyAppWorker.Archive.Services;

public class ArchiveService: IArchiveService
{

    public async void ToArchive(string path) 
    {
        ZipFile.CreateFromDirectory(path, path + @".zip");
    } 
}