using System;
using System.Collections.Generic;

namespace Unsl
{
    [Serializable]
    public class SaveLoadListData<T>
    {
        public SaveLoadListData(List<T> listObjects)
        {
            ListObjects = listObjects;
        }

        public List<T> ListObjects {get; private set;}
        
        public int Count => ListObjects.Count;
    }
}
