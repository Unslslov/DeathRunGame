using System;
using System.Collections.Generic;

namespace Unsl
{
    [Serializable]
    public class SaveLoadData<T>
    {
        public SaveLoadData(T item)
        {
            this.item = item;
        }

        public T item {get; private set;}
    }
}