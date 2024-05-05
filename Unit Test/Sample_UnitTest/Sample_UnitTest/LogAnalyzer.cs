namespace Sample_UnitTest
{
    public class LogAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {
            FileExtensionManager mgr = new FileExtensionManager();
            return mgr.IsValid(fileName);
        }
    }
}
