using System;
using System.IO;
using System.Data;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;


namespace Searcher
{
    class Utility
    {
        public static string GetVersion(string file)
        {
            FileVersionInfo vers = FileVersionInfo.GetVersionInfo(file);
            return vers.ProductVersion;
        }

        public static DataTable GetFileDatas(string[] FilePaths)
        {
            DataTable Output = new DataTable();
            Output.Columns.Add("Name", typeof(string));
            Output.Columns.Add("Path", typeof(string));
            Output.Columns.Add("Version", typeof(string));
            Output.Columns.Add("Created", typeof(DateTime));
            Output.Columns.Add("Opened", typeof(DateTime));
            Output.Columns.Add("Modified", typeof(DateTime));
            Output.Columns.Add("Size", typeof(string));

            foreach (string FilePath in FilePaths)
            {
                DataRow Row = Output.NewRow();
                GetFileData(FilePath, Row);
                Output.Rows.Add(Row);
            }

            return Output;
        }

        private static void GetFileData(string FilePath, DataRow Input)
        {
            if(File.Exists(FilePath)){

                FileInfo FI = new FileInfo(FilePath);
                FileVersionInfo vers = FileVersionInfo.GetVersionInfo(FilePath);
                Input["Name"] = FI.Name;
                Input["Path"] = FilePath;
                Input["Version"] = vers.ProductVersion;
                Input["Created"] = FI.CreationTime;
                Input["Opened"] = FI.LastAccessTime;
                Input["Modified"] = FI.LastWriteTime;
                Input["Size"] = FI.Length + " bytes";
            }
        }
    }

    public class SearchParameters
    {
        private char[] splitString = ", ".ToCharArray();


        public string SearchString { get { return MatchCase ? searchString : searchString.ToUpper(); } set { searchString = value; } }
        public string RootFolder { get { return MatchCase ? rootFolder : rootFolder.ToUpper(); } set { rootFolder = value; } }
        public string SkipFolder { get { return MatchCase ? skipFolder : skipFolder.ToUpper(); } set { skipFolder = value; } }
        public string SearchExtension { get { return MatchCase ? searchExtension : searchExtension.ToUpper(); } set { searchExtension = value; } }
        public string SkipExtension { get { return MatchCase ? skipExtension : skipExtension.ToUpper(); } set { skipExtension = value; } }
        
        private string searchString;
        private string rootFolder;
        private string skipFolder;
        private string searchExtension;
        private string skipExtension;

        public bool CheckContents;
        public bool MatchCase;
        public bool isRegex;
        public bool isRecursive;

        public string[] SkipFolders()
        {
            return SkipFolder.Split(splitString, StringSplitOptions.RemoveEmptyEntries);
        }

        public string[] SearchExtensions()
        {
            string[] output = SearchExtension.Split(splitString, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < output.Length; i++) { if (!output[i].StartsWith(".")) { output[i] = '.' + output[i]; } }
            return output;
        }

        public string[] SkipExtensions()
        {
            string[] output = SkipExtension.Split(splitString, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < output.Length; i++) { if (!output[i].StartsWith(".")) { output[i] = '.' + output[i]; } }
            return output;
        }
    }

    public class FileContext
    {
        public List<ContextGroup> Chunks = new List<ContextGroup>();
        public string FilePath;

        public FileContext(string FilePath)
        {
            this.FilePath = FilePath;
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

        public ContextLine(int LineNumber, string Line)
        {
            this.LineNumber = LineNumber;
            this.Line = Line;
        }
    }
}
