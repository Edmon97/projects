using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FileBrowserApp.Models
{
    public class Explorer
    {
        /// <summary>
        /// get all directories, files with files in subdirectories by path
        /// as result function return json with:
        /// - path to parent directory (parent);
        /// - current path (path);
        /// - list of directories by path (directories);
        /// - list of files by path (files);
        /// - list of files in subdirectories (subdir);
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetAllInFolder(string path = "Computer")
        {
            string parent=null;
            if (!path.Equals("Computer"))
            {
                DirectoryInfo parentDI = new DirectoryInfo(path).Parent;
                if (parentDI == null)
                    parent = "Computer";
                else
                    parent = parentDI.FullName;
            }
            else
                parent = path;

            var dList = GetDirectoriesList(path);
            var fList = GetFilesList(path);

            List<File> other_files = new List<File>();
            other_files.AddRange(fList);
            dList.ForEach(d => 
            {
                var files = GetFilesList(d.Path);
                other_files.AddRange(files);
            });

            string result = JsonConvert.SerializeObject(new
            {
                parent = parent,
                path = path,
                directories = dList,
                files = fList,
                subdir = other_files
            });

            return result;
        }

        /// <summary>
        /// get all directories by path
        /// </summary>
        /// <param name="path"></param>
        /// <returns>
        /// list directories (List<Directory>)
        /// </returns>
        public static List<Directory> GetDirectoriesList(string path)
        {
            var directorylist = new List<Directory>();
            string[] directories = null;
            
            if (path == "Computer")
                directories = System.IO.Directory.GetLogicalDrives();
            else
                directories = System.IO.Directory.GetDirectories(path);

            directories.ToList().ForEach(d =>
            {
                Directory temp = new Directory()
                {
                    Path = d,
                    Name = (Path.GetFileName(d) != "") ? Path.GetFileName(d) : d
                };
                directorylist.Add(temp);
            });
            return directorylist;
        }

        /// <summary>
        /// get all files by path
        /// </summary>
        /// <param name="path"></param>
        /// <returns>
        /// list files (List<File>)
        /// </returns>
        public static List<File> GetFilesList(string path)
        {
            var filelist = new List<File>();
            string[] files = null;
            if (path != "Computer")
            {
                try
                {
                    files = System.IO.Directory.GetFiles(path);
                    if (files != null)
                        files.ToList().ForEach(f =>
                        {
                            File temp = new File()
                            {
                                Name = Path.GetFileName(f),
                                Path = f,
                                Size = new FileInfo(f).Length / 1000
                            };
                            filelist.Add(temp);
                        });
                }
                catch (Exception ex) { }
            }
            return filelist;
        }

        /// <summary>
        /// open file on server by path (only for computer where app is hosted)
        /// </summary>
        /// <param name="path"></param>
        public static void OpenFile(string path)
        {
            Process.Start(path);
        }

        /// <summary>
        /// check path on directory or file
        /// </summary>
        /// <param name="path"></param>
        /// <returns>
        /// true - directory
        /// false - file
        /// </returns>
        public static bool IsDirectory(string path)
        {
            if (path.Equals("Computer") || System.IO.Directory.Exists(path))
                return true;
            return false;
        }

        public static string CheckPath(string path)
        {
            string result = null;
            if (!Explorer.IsDirectory(path))
            {
                Explorer.OpenFile(path);
                FileInfo info = new FileInfo(path);
                path = info.Directory.FullName;
            }
            result = Explorer.GetAllInFolder(path);
            return result;
        }
    }
}