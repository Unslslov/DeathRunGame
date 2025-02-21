using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Unsl
{
[RequireComponent(typeof(Button))]
public class SaveSettings : MonoBehaviour
{
    [SerializeField] Button  _saveSettingsButton;
    [SerializeField] private List<Slider> _settingsSlider;
    [SerializeField] private CameraLook _cameraLook;
    [SerializeField] private AudioSource[] _musicSource;
    [SerializeField] private AudioSource[] _soundSource;

    private void OnValidate() 
    {
        _saveSettingsButton ??= GetComponent<Button>();
    }

    private void OnEnable() 
    {
        _saveSettingsButton.onClick.AddListener(SetSettingsCount);
    }

    private void SetSettingsCount()
    {
        List<float> SettingsSliderValue = _settingsSlider.Select(values => values.value).ToList();

        if(_settingsSlider.Count != 0)
        {
            FileSaveLoad.Save(SettingsSliderValue, TypeSave.Settings);
        }

        if(_cameraLook != null)
        {
            _cameraLook.SetSensivity(_settingsSlider[2].value);
        }
        else 
        {
            Debug.LogError("In SaveSettings not have a  CameraLook");
        }
        
        if(_musicSource != null)
        {
            foreach(var source in _musicSource)
            {
                source.volume  = _settingsSlider[0].value;
            }
        }
        else 
        {
            Debug.LogError("In SaveSettings not have a  MusicSource");
        }
        
        if(_soundSource != null)
        {
            foreach(var source in _soundSource)
            {
                source.volume  = _settingsSlider[1].value;
            }
        }
        else 
        {
            Debug.LogError("In SaveSettings not have a SoundSource");
        }
    }

    private void OnDisable() 
    {
        _saveSettingsButton.onClick.RemoveListener(SetSettingsCount);
    }
}
}