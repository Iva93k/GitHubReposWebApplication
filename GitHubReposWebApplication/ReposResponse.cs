using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHubReposWebApplication
{
    public class ReposResponse
    {
        public string Name { get; set; }
        public string Full_name { get; set; }
        public bool Private { get; set; }
        public string Html_url { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }

    }
}
