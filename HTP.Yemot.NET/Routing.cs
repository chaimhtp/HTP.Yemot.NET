namespace HTP.Yemot.NET
{
    public class Routing
    {
        public string BaseBranchPath { get; set; }
        public string BranchPath { get; set; }
        private string Path { get; set; }
        private readonly string GoTo = "go_to_folder=";

        /// <summary>
        /// for example:
        /// baseBranchPath = "0/9/"
        /// branchPath = "/6/9/"
        /// </summary>
        public Routing(string branchPath, string baseBranchPath = null)
        {
            this.BaseBranchPath = baseBranchPath;
            this.BranchPath = branchPath;
            this.Path = $"{(!string.IsNullOrWhiteSpace(this.BaseBranchPath) ? this.BaseBranchPath : "")}{this.BranchPath}";
        }
        public Routing() { }

        //public Routing()
        //{
        //}
        //public string FilePath(string fileNum)
        //{
        //    return $"f-{this.BaseBranchPath}{this.BaseFilesPath}{fileNum}.";
        //}
        public string GoToBranch()
        {
            return $"{this.GoTo}{this.Path}";
        }
        public string RestartExtension(string extension)
        {
            this.Path = $"/{extension}";
            string ret = this.GoToBranch();
            return ret;
        }
        public string OneExtensionBack()
        {
            this.Path = "..";
            string ret = this.GoToBranch();
            return ret;
        }
    }
}
