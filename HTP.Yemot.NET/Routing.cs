namespace HTP.Yemot.NET
{
    public class Routing
    {
        public string BaseBranchPath { get; set; }
        public string BaseFilesPath { get; set; }
        private readonly string GoTo = "go_to_folder=";

        /// <summary>
        /// for example:
        /// baseBranchPath = "/6/9/"
        /// baseFilesPath = "0/9/"
        /// </summary>
        public Routing(string baseBranchPath, string baseFilesPath)
        {
            this.BaseBranchPath = baseBranchPath;
            this.BaseFilesPath = baseFilesPath;
        }
        public string FilePath(string fileNum)
        {
            return $"f-{this.BaseBranchPath}{this.BaseFilesPath}{fileNum}.";
        }
        public string GoToBranch(string branchPath)
        {
            return $"{this.BaseBranchPath}{this.GoTo}{branchPath}";
        }

    }
}
