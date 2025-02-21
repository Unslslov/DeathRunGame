using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unsl;

public class LoadSettings : MonoBehaviour
{
    [SerializeField] List<Slider> _sliders;

    private void Awake() 
    {
        var settingValue = FileSaveLoad.LoadList<float>(TypeSave.Settings);
        
        if(settingValue != null)
        {
            var value = settingValue.ListObjects;

            for(int i = 0; i < _sliders.Count; i++)
            {
                _sliders[i].value = value[i];
            }
        }
        else 
        {
            _sliders[0].value = SettingDefault.MusicValue;
            _sliders[1].value = SettingDefault.SoundValue;
            _sliders[2].value = SettingDefault.SensivityValue;
        }
    }
}
