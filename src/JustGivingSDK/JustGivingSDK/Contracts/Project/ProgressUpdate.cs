using System;

namespace JustGivingSDK.Contracts.Project
{
    public class ProgressUpdate
    {
        public string Title { get; set; }

        public string AuthorName { get; set; }

        public string Content { get; set; }

        public DateTime DatePublished { get; set; }
    }
}