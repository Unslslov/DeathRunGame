using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Unsl
{
public class FileSaveLoad
{
    private const string SaveFolderName = "Saves";
    private const string SaveFileNameSettings = "SaveSettingsFile.json";
    private const string SaveFileNameKnifes = "SaveNameKnifesFile.json";

    private static string SaveDataFolder => Path.Combine(Application.persistentDataPath, SaveFolderName);

    private static string SaveSettingFilePath => Path.Combine(Application.persistentDataPath, SaveFileNameSettings);

    private static string SaveKnifeFilePath => Path.Combine(Application.persistentDataPath, SaveFileNameKnifes);

    public void Save<T>(List<T> data, TypeSave type)
    {
        try
        {
            if(!Directory.Exists(SaveDataFolder))
                Directory.CreateDirectory(SaveDataFolder); 

            var SaveFile = new SaveLoadData<T>(data);
            var serializedSaveFile = JsonConvert.SerializeObject(SaveFile);

            if(type == TypeSave.Settings)
            {
                File.WriteAllText(SaveSettingFilePath, serializedSaveFile);
            }
            else if(type == TypeSave.Knives)
            {
                File.WriteAllText(SaveKnifeFilePath, serializedSaveFile);
            }

            Debug.Log(Path.Combine(Application.persistentDataPath, SaveFileNameSettings));
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            throw;
        }
    }

    public static SaveLoadData<T> Load<T>(TypeSave type)
    {

        string saveFilePath = string.Empty;

        bool isKnives = type == TypeSave.Knives;

        if (isKnives)
        {
            saveFilePath = SaveKnifeFilePath;
        }
        else if (type == TypeSave.Settings)
        {
            saveFilePath = SaveSettingFilePath;
        }
        else
        {
            Debug.LogError($"Unsupported TypeSave: {type}");
            return null;
        }

        if (!File.Exists(saveFilePath) && isKnives) 
        { 
            Debug.LogError($"Can't load save file. File {saveFilePath} doesn't exist. The create Default Weapon"); 
            
            List<T> defaultData = new List<T>();

            if (typeof(T) == typeof(string)) 
            {
                defaultData.Add((T)(object)"Axe");
            }

            SaveLoadData<T> axe = new SaveLoadData<T>(defaultData); 
            return axe; 
        } 
        else if (!File.Exists(saveFilePath))
        {
            Debug.LogError($"Can't load save file. File {saveFilePath} is doesn't exist.");
          
            return null;
        }
       
        Debug.Log(saveFilePath);
       
        try
        {
            var serializedFile = File.ReadAllText(saveFilePath);

            if (string.IsNullOrEmpty(serializedFile))
            {
                Debug.LogError($"Loaded file {saveFilePath} is empty.");
                return null;
            }

            Debug.Log($"Save to {saveFilePath}");
            return JsonConvert.DeserializeObject<SaveLoadData<T>>(serializedFile);
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
}