using System;
using System.Collections.Generic;

namespace Unsl
{
    [Serializable]
    public class SaveLoadData<T>
    {
        public SaveLoadData(List<T> listObjects)
        {
            ListObjects = listObjects;
        }

        public List<T> ListObjects {get; private set;}
    }
}
