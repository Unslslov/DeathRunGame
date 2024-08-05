using System;

namespace  Unsl
{
[Serializable]
    
    public struct SaveFile
    {
        public DateTime SaveTime {get;}
        public SaveLoadSettingsData Data {get;}

        public SaveFile(SaveLoadSettingsData data)
        {
            Data = data;
            SaveTime = DateTime.Now;
        }
    }
}