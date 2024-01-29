namespace FileSericeWorker.Service.StorageService
{
    public class StorageService: IStorageService
    {
        private readonly string _storagePath;
        public StorageService(string initalPath)
        {
            _storagePath = initalPath;
            InitialDirectoryToStoreFile();
        }
        private void InitialDirectoryToStoreFile()
        {
            var path = Path.GetFullPath(_storagePath);
            if (!File.Exists(path)) {
                Directory.CreateDirectory(_storagePath);
            }
            
        }
        public void Test()
        {
            InitialDirectoryToStoreFile();
        }
    }
}
