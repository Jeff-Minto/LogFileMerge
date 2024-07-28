using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFileMerge.Repositories.LogFileMergeRepository
{
    public interface ILogsMergeRepository
    {
        string MergeLogFiles(List<string?> logFileLocations, string mergedFilePath);
    }
}
