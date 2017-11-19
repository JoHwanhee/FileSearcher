using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSearchr.Composite
{
    public abstract class Component
    {
        public string Type { get; protected set; }
        public string Name { get; protected set; }
        public string FullName { get; protected set; }
        public DateTime Updated { get; protected set; }
        public bool IsIgnore { get; protected set; }

        public List<Component> Children { get; } = new List<Component>();
        
        public virtual bool AddChlid(Component component)
        {
            Children.Add(component);
            Console.WriteLine($"[Add] {component.FullName}");
            return true;
        }

        public virtual string GetUpdatedDateString()
        {
            return Updated.ToString("yyyy-MM-dd");
        }

        public virtual bool Delete()
        {
            try
            {
                if (Type == "Folder")
                {
                    DirectoryInfo currentDirectoryInfo = new DirectoryInfo(FullName);
                    currentDirectoryInfo.Delete(true);
                }
                else if (Type == "File")
                {
                    FileInfo fileInfo = new FileInfo(FullName);
                    fileInfo.Delete();
                }

                Console.WriteLine($"[Delete] {FullName}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }

        public virtual bool DeleteTo(string[] deleteFolders)
        {
            try
            {
                foreach (var child in Children)
                {
                    child.DeleteTo(deleteFolders);
                }

                if (deleteFolders.Contains(Name))
                {
                    Delete();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public virtual bool Ignore()
        {
            IsIgnore = true;

            Console.WriteLine($"[Ignore] {FullName}");
            return true;
        }

        public virtual bool IgnoreByNames(string[] ignoreStrings)
        {
            foreach (var child in Children)
            {
                child.IgnoreByNames(ignoreStrings);
            }

            if (ignoreStrings.Contains(Name))
            {
                Ignore();
            }

            return true;
        }

        public virtual bool IgnoreByTimes(DateTime ignoreTime)
        {
            foreach (var child in Children)
            {
                child.IgnoreByTimes(ignoreTime);
            }

            if (Updated <= ignoreTime)
            {
                Ignore();
            }

            return true;
        }

        public virtual bool Remove(Component component)
        {
            Children.Remove(component);
            return true;
        }
    }
}