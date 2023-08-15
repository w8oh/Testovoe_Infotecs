using System.IO.Compression;
using CopyAppWorker.Archive.interfaces;
using CopyAppWorker.Settings.Interfaces;
using CopyAppWorker.Settings.Models;

namespace CopyAppWorker.Archive.Services;

public class ArchiveService: IArchiveService
{

    public async void ToArchive(string path) 
    {
      
         ZipFile.CreateFromDirectory(path, path + @".zip");

        //ZipFile.ExtractToDirectory(path + @".zip", path);
    } 
}