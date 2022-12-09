using System;
using System.Collections.Generic;

namespace Data.Shop
{
    [Serializable]
    public class SaveObject
    {
        public string title;
        public int count = 0;

        public SaveObject(string title)
        {
            this.title = title;
        }
    }

    [Serializable]
    public class Save
    {
        public List<SaveObject> data = new List<SaveObject>();
    }
}