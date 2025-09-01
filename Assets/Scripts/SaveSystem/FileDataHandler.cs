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

    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
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

    public void Save(GameData data)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);

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
