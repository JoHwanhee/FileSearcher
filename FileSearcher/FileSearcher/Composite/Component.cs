using System;
using System.Collections.Generic;

namespace FileSearchr.Composite
{
    public abstract class Component
    {
        public string Type { get; protected set; }
        public string Name { get; protected set; }
        public string FullName { get; protected set; }
        public DateTime Updated { get; protected set; }

        public List<Component> Children { get; } = new List<Component>();
        public virtual bool AddChlid(Component component)
        {
            Children.Add(component);
            return true;
        }

        public virtual string GetUpdatedDateString()
        {
            return Updated.ToString("yyyy-MM-dd");
        }
        
    }
}