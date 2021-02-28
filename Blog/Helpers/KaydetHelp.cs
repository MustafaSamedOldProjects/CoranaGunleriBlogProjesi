using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Helpers
{
    public class KaydetHelp
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        public KaydetHelp(IWebHostEnvironment webHostEnvironment)
        {
            hostingEnvironment = webHostEnvironment;
        }
        public string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return filename;
        }

        public string GetPathAndFilename(string filename)
        {
            var X = this.hostingEnvironment.WebRootPath + "\\AnaKlasor\\Resimler\\" + filename;
            return X;
        }

    }
}
