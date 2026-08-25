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
        /// branchPath = "/6/9/"
        /// baseBranchPath = "/0/"
        /// </summary>
        public Routing(string branchPath, string baseBranchPath = null)
        {
            this.BaseBranchPath = baseBranchPath;
            this.BranchPath = branchPath;
            this.Path = (!string.IsNullOrWhiteSpace(this.BaseBranchPath) ? this.BaseBranchPath : "") + this.BranchPath;
        }
        public Routing()
        {
        }
        public string GoToBranch()
        {
            return this.GoTo + this.Path;
        }
        /// <summary>
        /// מעבר מחדש לשלוחה הרצויה
        /// </summary>
        public string RestartExtension(string extension)
        {
            this.Path = "/" + extension;
            return GoToBranch();
        }
        /// <summary>
        /// חזרה שלוחה אחת אחורה
        /// </summary>
        public string OneExtensionBack()
        {
            this.Path = "..";
            return GoToBranch();
        }
    }
}
