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

    [SerializeField] private List<Slider> SettingsSlider;


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
        List<float> SettingsSliderValue = SettingsSlider.Select(values => values.value).ToList();

        if(SettingsSlider.Count != 0)
        {
            FileSaveLoad save = new FileSaveLoad();

            save.Save(SettingsSliderValue, TypeSave.Settings);
        }
    }

    private void OnDisable() 
    {
        _saveSettingsButton.onClick.RemoveListener(SetSettingsCount);
    }
}
}