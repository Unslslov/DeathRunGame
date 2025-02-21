using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Unsl
{
public static class FileSaveLoad
{
    private const string SaveFolderName = "Saves";
    private const string SaveFileNameSettings = "SaveSettingsFile.json";
    private const string SaveFileNameKnifes = "SaveNameKnifesFile.json";
    private const string SaveFileStarsOnLevels = "SaveStarsOnLevelsFile.json";
    private const string SaveFileBestResultOnLevels = "SaveBestResultOnLevelsFile.json";
    private const string SaveFileBestTimeRunOnLevels = "SaveBestTimeRunOnLevelsFile.json";
    private const string SaveFileMoney = "SaveMoneyFile.json";
    private const string SaveFileTutorial = "SaveTutorialFile.json";

    private static string SaveDataFolder => Path.Combine(Application.persistentDataPath, SaveFolderName);

    private static string SaveSettingFilePath => Path.Combine(Application.persistentDataPath, SaveFileNameSettings);

    private static string SaveKnifeFilePath => Path.Combine(Application.persistentDataPath, SaveFileNameKnifes);

    private static string SaveMoneyPath => Path.Combine(Application.persistentDataPath, SaveFileMoney);

    private static string SaveStarsOnLevelsPath => Path.Combine(Application.persistentDataPath, SaveFileStarsOnLevels);
    private static string SaveBestResultOnLevelsPath => Path.Combine(Application.persistentDataPath, SaveFileBestResultOnLevels);
    private static string SaveBestTimeRunOnLevelsPath => Path.Combine(Application.persistentDataPath, SaveFileBestTimeRunOnLevels);
    private static string SaveTutroialPath => Path.Combine(Application.persistentDataPath, SaveFileTutorial);

    public static void Save<T>(List<T> data, TypeSave type)
    {
        try
        {
            if(!Directory.Exists(SaveDataFolder))
                Directory.CreateDirectory(SaveDataFolder); 

            var SaveFile = new SaveLoadListData<T>(data);
            var serializedSaveFile = JsonConvert.SerializeObject(SaveFile);

            switch(type)
            {
                case TypeSave.Knives:
                {
                    File.WriteAllText(SaveKnifeFilePath, serializedSaveFile);
                    Debug.Log(Path.Combine(Application.persistentDataPath, SaveFileNameKnifes));
                    break;
                }
                case TypeSave.Settings:
                {
                    File.WriteAllText(SaveSettingFilePath, serializedSaveFile);
                    Debug.Log(Path.Combine(Application.persistentDataPath, SaveFileNameSettings));
                    break;
                }
                case TypeSave.CountStarsOnLevels:
                {
                    File.WriteAllText(SaveStarsOnLevelsPath, serializedSaveFile);
                    Debug.Log(Path.Combine(Application.persistentDataPath, SaveFileStarsOnLevels));
                    break;
                }
                case TypeSave.BestResultOnLevels:
                {
                    File.WriteAllText(SaveBestResultOnLevelsPath, serializedSaveFile);
                    Debug.Log(Path.Combine(Application.persistentDataPath, SaveFileBestResultOnLevels));
                    break;
                }
                case TypeSave.BestTimeRunOnLevels:
                {
                    File.WriteAllText(SaveBestTimeRunOnLevelsPath, serializedSaveFile);
                    Debug.Log(Path.Combine(Application.persistentDataPath, SaveFileBestTimeRunOnLevels));
                    break;
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            throw;
        }
    }

    public static void Save<T>(T data, bool typeSave = true)
    {
        try
        {
            if(!Directory.Exists(SaveDataFolder))
                Directory.CreateDirectory(SaveDataFolder); 

            var SaveFile = new SaveLoadData<T>(data);
            var serializedSaveFile = JsonConvert.SerializeObject(SaveFile);

            if(typeSave == true)
            {
                File.WriteAllText(SaveMoneyPath, serializedSaveFile);
                Debug.Log(Path.Combine(Application.persistentDataPath, SaveFileMoney));
            }
            else
            {
                File.WriteAllText(SaveTutroialPath, serializedSaveFile);
                Debug.Log(Path.Combine(Application.persistentDataPath, SaveFileTutorial));
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            throw;
        }
    }

    public static SaveLoadListData<T> LoadList<T>(TypeSave type)
    {

        string saveFilePath = string.Empty;

        switch(type)
        {
            case TypeSave.Knives:
            {
                saveFilePath = SaveKnifeFilePath;
                break;
            }
            case TypeSave.Settings:
            {
                saveFilePath = SaveSettingFilePath;
                break;
            }
            case TypeSave.CountStarsOnLevels:
            {
                saveFilePath = SaveStarsOnLevelsPath;
                break;
            }
            case TypeSave.BestResultOnLevels:
            {
                saveFilePath = SaveBestResultOnLevelsPath;
                break;
            }
            case TypeSave.BestTimeRunOnLevels:
            {
                saveFilePath = SaveBestTimeRunOnLevelsPath;
                break;
            }
            default:
            {
                Debug.LogError($"Unsupported TypeSave: {type}");
                return null;
            }
        }

        if (!File.Exists(saveFilePath) && type == TypeSave.Knives) 
        { 
            Debug.LogError($"Can't load save file. File {saveFilePath} doesn't exist. The create Default Weapon"); 
            
            List<T> defaultData = new List<T>();

            if (typeof(T) == typeof(string)) 
            {
                defaultData.Add((T)(object)"Axe");
            }

            SaveLoadListData<T> axe = new SaveLoadListData<T>(defaultData); 
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
            return JsonConvert.DeserializeObject<SaveLoadListData<T>>(serializedFile);
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static SaveLoadData<T> Load<T>(bool saveType = true)
    {

        string saveFilePath = string.Empty;

        if(saveType == true)
            saveFilePath = SaveMoneyPath;
        else
            saveFilePath = SaveTutroialPath;

        if (!File.Exists(saveFilePath))
        {
            Debug.LogError($"Can't load save file. File {saveFilePath} is doesn't exist.");
          
            return null;
        }
       
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