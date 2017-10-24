using System;
using System.Collections.Generic;

namespace FileSearchSinceTime
{
    public abstract class Component
    {
        public string Name;
        public DateTime Updated;

        public virtual string ParseUpdated()
        {
            return Updated.ToString("yyyy-MM-dd");
        }
        
    }
}