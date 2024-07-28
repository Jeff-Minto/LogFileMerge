using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFileMerge.Repositories.LogFileMergeRepository
{
    internal class LogsMergeRepository : ILogsMergeRepository
    {
        private IDictionary<DateTime, string> _logEntries = new Dictionary<DateTime, string>();

        /// <summary>
        /// Process log files in specified directories and merge and sort into a single archive file
        /// </summary>
        /// <param name="logFileLocations"></param>
        /// <param name="mergedFilePath"></param>
        /// <returns></returns>
        public string MergeLogFiles(List<string?> logFileLocations, string mergedFilePath)
        {
            string result = Validation(logFileLocations, mergedFilePath);

            if (result != string.Empty)
            {
                return result;
            }

            // Process each log file
            foreach (string? logFilePath in logFileLocations)
            {
                // Directory specified must exist
                if (Directory.Exists(logFilePath))
                {                   
                    string[] logfiles = Directory.GetFiles(logFilePath);

                    StringBuilder sb = new StringBuilder();

                    foreach (string logName in Directory.GetFiles(logFilePath, "*.log"))
                    {
                        PopulateDictionary(logName);
                    }
                }
                else
                {
                    return "Log file directory does not exist.";
                }
            }

            // Sort dictionary by log entry date time 
            IOrderedEnumerable<KeyValuePair<DateTime, string>> orderedMergeLog 
                = _logEntries.OrderBy(x => x.Key);

            if (Directory.Exists(mergedFilePath))
            {
                // Create archive file and add sorted items 
                using (StreamWriter outfile =
                    File.CreateText(mergedFilePath + "Archive_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log"))
                {
                    foreach (var item in orderedMergeLog)
                    {
                        // Format datetime back to expected sting format before writing to archive file
                        outfile.WriteLine(item.Key.ToString("yyyy-MM-dd hh:mm:ss.fff") + " " + item.Value);
                    }
                }

                // Delete the source log files 
                foreach (string? cleanFilePath in logFileLocations)
                {
                    if (cleanFilePath != null)
                    {
                        DirectoryInfo dir = new DirectoryInfo(cleanFilePath);

                        foreach (FileInfo file in dir.GetFiles("*.log"))
                        {
                            file.Delete();
                        }
                    }
                }

                return "Processing finished.";
            }
            else
            {
                return "Log archive directory does not exist.";
            }           
        }

        /// <summary>
        /// Validate parameters to ensure they are populated
        /// </summary>
        /// <param name="logFileLocations"></param>
        /// <param name="mergedFilePath"></param>
        /// <returns></returns>
        private static string Validation(List<string?> logFileLocations, string mergedFilePath)
        {
            string message = string.Empty;

            if (logFileLocations == null)
            {
                return "No log file locations have been specified";               
            }

            if (logFileLocations.Count < 1)
            {
                return "No log file locations have been specified";
            }

            if (string.IsNullOrEmpty(mergedFilePath))
            {
                message = "No archive file path was specified";
            }

            return message;
        }

        /// <summary>
        /// Add items from log files to dictionary for the specified log file
        /// </summary>
        /// <param name="logName"></param>
        private void PopulateDictionary(string logName)
        {
            using (StreamReader sr = new StreamReader(logName))
            {
                while (!sr.EndOfStream)
                {
                    // Need to reack each line so the data can be formatted into a suitable type for sorting
                    string? line = sr.ReadLine();

                    if (line != null)
                    {
                        // Extract Date and Message
                        string date = line.Substring(0, 23);
                        string message = line.Substring(24, line.Length - 24);

                        // Parse the date string into a real date so it can be sorted by date time rather by
                        // string
                        var logDate = DateTime.Parse(date);

                        _logEntries.Add(logDate, message);
                    }
                }
            }
        }           
    }    
}
