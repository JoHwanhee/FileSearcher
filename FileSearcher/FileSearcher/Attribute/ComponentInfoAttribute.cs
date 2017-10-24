using System;

namespace FileSearchr.Attribute
{
    [AttributeUsage(System.AttributeTargets.All, AllowMultiple = true)]
    public class ComponentInfoAttribute : System.Attribute
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