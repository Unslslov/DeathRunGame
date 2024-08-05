using System;
using System.Collections.Generic;

namespace Unsl
{
[Serializable]
    public class SaveLoadSettingsData
    {
        public SaveLoadSettingsData(List<float> settings)
        {
            Settings = settings;
        }
        public List<float> Settings {get; private set;}
    }
}