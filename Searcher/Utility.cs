using System;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;


namespace Searcher
{
	internal class Utility
    {
        public static string GetVersion(string file)
        {
            var vers = FileVersionInfo.GetVersionInfo(file);
            return vers.ProductVersion;
        }

        public static DataTable GetFileDatas(string[] filePaths)
        {
            var output = new DataTable();
            output.Columns.Add("Name", typeof(string));
            output.Columns.Add("Path", typeof(string));
            output.Columns.Add("Version", typeof(string));
            output.Columns.Add("Created", typeof(DateTime));
            output.Columns.Add("Opened", typeof(DateTime));
            output.Columns.Add("Modified", typeof(DateTime));
            output.Columns.Add("Size", typeof(string));

            foreach (var filePath in filePaths)
            {
                var row = output.NewRow();
                GetFileData(filePath, row);
                output.Rows.Add(row);
            }

            return output;
        }

        private static void GetFileData(string filePath, DataRow input)
        {
	        if (!File.Exists(filePath)) return;

	        var fi = new FileInfo(filePath);
	        var vers = FileVersionInfo.GetVersionInfo(filePath);
	        input["Name"] = fi.Name;
	        input["Path"] = filePath;
	        input["Version"] = vers.ProductVersion;
	        input["Created"] = fi.CreationTime;
	        input["Opened"] = fi.LastAccessTime;
	        input["Modified"] = fi.LastWriteTime;
	        input["Size"] = fi.Length + " bytes";
        }

        public static void TestRegexPattern(string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) throw new ArgumentException("Regex Pattern Is Empty.");

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            Regex.Match("", pattern);
        }

        #region search stuff methods
        internal static void SearchFolder(SearchParameters sp,
		    IDictionary<string, Exception> failedFiles, Dictionary<FileInfo, string> matchFiles,
		    ToolStripStatusLabel status, Label fileCount)
	    {
			SearchFolder(sp, sp.RootFolder, failedFiles, matchFiles, status, fileCount);
	    }

	    private static void SearchFolder( SearchParameters sp, string searchPath, IDictionary<string, Exception> failedFiles, Dictionary<FileInfo, string> matchFiles, ToolStripStatusLabel status, Control fileCount )
	    {
		    if ( sp.CancellationToken.IsCancellationRequested
			     || !Directory.Exists(searchPath)
		         || sp.SkipFolders().Any( skip => searchPath.ToUpper().Contains( skip.ToUpper() )
		                                          || skip.ToUpper().Contains( searchPath.ToUpper() ) ) )
			    return;

		    MultiThread.UpdateToolStripStatus( status, searchPath );
			SearchFiles(sp, searchPath, failedFiles, matchFiles);
		    MultiThread.SetProperty( fileCount, "Text", "Found Files:" + matchFiles.Count );

			if ( !sp.IsRecursive)
			    return;

		    var dirs = Directory.GetDirectories( searchPath );
		    foreach ( var dir in dirs )
		    {
			    SearchFolder( sp, dir, failedFiles, matchFiles, status, fileCount );
		    }
	    }

	    private static void SearchFiles(SearchParameters sp, string filePath, IDictionary<string, Exception> failedFiles, Dictionary<FileInfo, string> matchFiles)
	    {
		    try
		    {
			    var files = Directory.GetFiles( filePath );
			    foreach ( var file in files )
			    {
				    try
				    {
					    SearchFile( sp, file, matchFiles);
				    }
				    catch ( Exception x ) { failedFiles.Add( file, x ); }
			    }
		    }
		    catch ( Exception x )
		    {
			    if ( !x.Message.StartsWith( "Access" ) )
			    { failedFiles.Add( filePath, x ); }
		    }
		}

		private static void SearchFile( SearchParameters sp, string filePath, Dictionary<FileInfo, string> matchFiles)
		{
			if (sp.CancellationToken.IsCancellationRequested)
				return;

			var fi = new FileInfo( filePath );
			if ( SkipFile( sp.SkipExtensions(), sp.SearchExtensions(), fi ) )
			    return;

			var matchLine = string.Empty;
			var match = SearchString(sp, filePath);
		    if ( !match && sp.CheckContents )
		    {
			    match = SearchContents( sp, filePath, out matchLine );
		    }

			if (match)
			{
			    matchFiles.Add(fi, matchLine);
			}
		}

        public static bool SearchContents(SearchParameters sp, string filePath, out string firstMatch)
        {
            firstMatch = null;
            var fi = new FileInfo(filePath);
            if(fi.Length > 50 * 1024 * 1024) { }

            var buffer = new StringBuilder();
            using (var reader = new StreamReader(filePath))
            {
                var temp = new char[1024];
                for (var len = reader.Read(temp, 0, 1024); len != 0; len = reader.Read(temp, 0, 1024))
                {
                    buffer.Append(temp);
                    if(SearchString(sp, buffer.ToString()))
                    {
                        firstMatch = buffer.ToString();
                        return true;
                    }

                    while (buffer.Length > 4096){buffer.Remove(0, 1024);}
                }
            }

            return false;
        }

	    private static bool SearchString(SearchParameters sp, string hayStack)
	    {
		    if ( sp.IsRegex )
		    {
			    return Regex.IsMatch(hayStack, sp.SearchString);
		    }
		    return CultureInfo.CurrentCulture.CompareInfo.IndexOf(hayStack, sp.SearchString, CompareOptions.IgnoreCase) >=0;
	    }

		public static void AddRow( DataTable dataSource, FileInfo fi, string matchLine )
	    {
		    var tempRow = dataSource.NewRow();

	        foreach (var prop in fi.GetType().GetProperties())
	        {
	            if (dataSource.Columns.Contains(prop.Name))
	            {
	                tempRow[prop.Name] = prop.GetValue(fi);
	            }
	        }

	        if (dataSource.Columns.Contains("First Match"))
	        {
	            tempRow["First Match"] = matchLine.Trim();
            }

		    dataSource.Rows.Add( tempRow );
	    }

	    private static bool SkipFile( IEnumerable<string> skip, IEnumerable<string> search, FileSystemInfo fsi )
	    {
		    if ( skip.Contains( fsi.Extension ) )
		    {
			    return true;
		    }

		    IEnumerable<string> includedFiles = search as string[] ?? search.ToArray();
		    return includedFiles.Any() && !( includedFiles.Contains( fsi.Extension )
		                                     || includedFiles.Contains( fsi.Extension.TrimStart( '.' ) ) );
	    }
		#endregion
	}

	public class SearchParameters
    {
        public string SearchString { get; set; }

	    public string RootFolder { get; set; }

	    public string[] SkipFolder { get; set; }

	    public string[] SearchExtension { get; set; }

	    public string[] SkipExtension { get; set; }

	    public CancellationToken CancellationToken { get; }


	    public bool CheckContents;
        public bool IsRegex;
        public bool IsRecursive;

	    public SearchParameters(CancellationToken cancellationToken)
	    {
		    CancellationToken = cancellationToken;
	    }

	    public string[] SkipFolders()
        {
            return SkipFolder;
        }

        public string[] SearchExtensions()
        {
            var output = SearchExtension;
            for (var i = 0; i < output.Length; i++) { if (!output[i].StartsWith(".")) { output[i] = '.' + output[i]; } }
            return output;
        }

        public string[] SkipExtensions()
        {
            var output = SkipExtension;
            for (var i = 0; i < output.Length; i++) { if (!output[i].StartsWith(".")) { output[i] = '.' + output[i]; } }
            return output;
        }
    }

    public class FileContext
    {
        public List<ContextGroup> Chunks = new List<ContextGroup>();
        public string FilePath;

        public FileContext(string filePath)
        {
            FilePath = filePath;
        }
    }

    public class ContextGroup
    {
        public List<ContextLine> Lines = new List<ContextLine>();
    }

    public class ContextLine
    {
        public int LineNumber;
        public string Line;

        public ContextLine(int lineNumber, string line)
        {
            LineNumber = lineNumber;
            Line = line;
        }
    }
}
