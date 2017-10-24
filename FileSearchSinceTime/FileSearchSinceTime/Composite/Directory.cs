using System;
using System.Collections.Generic;

namespace FileSearchSinceTime
{
    public class Directory : Component
    {
        private readonly List<Component> _files = new List<Component>();
        
        public void AddComponent(Component component)
        {
            _files.Add(component);
        }

        public void RemoveComponent(Component component)
        {
            _files.Remove(component);
        }

        public IEnumerable<Component> GetFiles()
        {
            return _files;
        }
    }
}