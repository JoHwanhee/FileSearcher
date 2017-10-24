using System;

namespace FileSearchSinceTime
{
    [AttributeUsage(System.AttributeTargets.All, AllowMultiple = true)]
    public class ComponentInfoAttribute : Attribute
    {
        public string ItemName;
        public string Summary;

        public ComponentInfoAttribute(string name, string summary = "")
        {
            ItemName = name;
            Summary = summary;
        }
    }
}