using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Unsl
{
[RequireComponent(typeof(Button))]
public class SaveKnifes : MonoBehaviour
{
    [SerializeField] Button  _saveSettingsButton;

    [SerializeField] private List<string> _knifes = new List<string>();


    private void OnEnable() 
    {
        _saveSettingsButton.onClick.AddListener(SetSettingsCount);
    }

    private void SetSettingsCount()
    {
        FileSaveLoad.Save(_knifes, TypeSave.Knives);
    }

    private void OnDisable() 
    {
        _saveSettingsButton.onClick.RemoveListener(SetSettingsCount);
    }
}
}