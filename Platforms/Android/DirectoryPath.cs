using MyStore_MAUI.Platforms.Android;
using MyStore_MAUI.Service;

[assembly: Dependency(typeof(DirectoryPath))]
namespace MyStore_MAUI.Platforms.Android
{
    public class DirectoryPath : IDirectory
    {
        public string GetDirectoryPath()
        {
            return "dsd"; //Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).AbsolutePath;
        }
    }
}
