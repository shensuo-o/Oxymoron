using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";

    private string dataFileName = "";

    private bool useEncryption = false;

    private readonly string encryptionCodeWord = "mcemployees";

    public FileDataHandler (string dataDirPath, string dataFileName, bool useEncryption)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.useEncryption = useEncryption;
    }

    public GameData Load(string profileID)
    {
        if(profileID == null)
        {
            return null;
        }

        string fullPath = Path.Combine(dataDirPath, profileID, dataFileName);
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                //Load Json dataFile
                string dataToLoad = "";

                using (FileStream stream = new FileStream (fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader (stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                //Dencrypt data if desired
                if (useEncryption)
                {
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }

                //De-serialize Json dataFile
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error while loading the dataFile: " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void Save(GameData data, string profileID)
    {
        if (profileID == null)
        {
            return;
        }

        string fullPath = Path.Combine(dataDirPath, profileID, dataFileName);

        try
        {
            //Create directory
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //Serialize gameData to Json
            string dataToStore = JsonUtility.ToJson(data, true);

            //Encrypt data if desired
            if (useEncryption)
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }

            //Write the Json file
            using (FileStream stream = new FileStream (fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e) 
        {
            Debug.LogError("Error while saving to dataFile: " + fullPath + "\n" + e);
        }
    }

    public Dictionary<string, GameData> LoadAllProfiles()
    {
        Dictionary<string, GameData> profilesDictionary = new Dictionary<string, GameData>();

        IEnumerable<DirectoryInfo> dirInfos = new DirectoryInfo(dataDirPath).EnumerateDirectories();
        foreach (DirectoryInfo dirInfo in dirInfos)
        {
            string profileID = dirInfo.Name;
            string fullPath = Path.Combine (dataDirPath, profileID, dataFileName);

            if (!File.Exists(fullPath))
            {
                Debug.LogWarning("Skipping directory with no save data from directoryProfiles: " + profileID);
                continue;
            }

            GameData profileData = Load(profileID);

            if (profileData != null)
            {
                profilesDictionary.Add(profileID, profileData);
            }
            else
            {
                Debug.LogError("Error loading profile " + profileID);
            }
        }

        return profilesDictionary;
    }

    public string GetRecentProfile()
    {
        string mostRecentProfile = null;
        Dictionary<string, GameData> profilesData = LoadAllProfiles();

        foreach(KeyValuePair<string, GameData> pair in profilesData)
        {
            string profileID = pair.Key;
            GameData data = pair.Value;
            if (data == null)
            {
                continue;
            }

            if(mostRecentProfile == null)
            {
                mostRecentProfile = profileID;
            }
            else
            {
                DateTime mostRecentDate = DateTime.FromBinary(profilesData[mostRecentProfile].lastUpdated);
                DateTime newDate = DateTime.FromBinary(data.lastUpdated);

                if (newDate > mostRecentDate)
                {
                    mostRecentProfile = profileID;
                }
            }
        }
        return mostRecentProfile;
    }

    //Encrypt or decrypt the Json data
    private string EncryptDecrypt (string data)
    {
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }
        return modifiedData;
    }
}
