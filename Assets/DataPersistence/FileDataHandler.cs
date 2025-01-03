using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";

    private string dataFileName = "";

    private bool useEncryptionSave = false;
    private bool useEncryptionLoad   = false;
    private readonly string encryptionCodeWord = "racimo";

    public FileDataHandler (string dataDirPath, string dataFileName, bool useEncryptionSave,bool useEncryptionLoad)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.useEncryptionSave = useEncryptionSave;
        this.useEncryptionLoad = useEncryptionLoad;
    }
    public GameData Load()
    {
        //Usar mejor Path.Combine debido se adapta mejor a diferentes sistemas operativos
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;
        //Revisa si existe un archivo que cargar
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToStore = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToStore = reader.ReadToEnd();
                    }

                }
                if (useEncryptionLoad)
                {
                    dataToStore = EncryptDecrypt(dataToStore);
                }
                //Deserealizar los datos del archivo en json para pasar a un objeto en C#
                loadedData = JsonUtility.FromJson<GameData>(dataToStore);
            }
            catch(Exception e)
            {
                Debug.LogError("Error al cargar los archivos desde: " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }
    public void Save(GameData data)
    {
        //Usar mejor Path.Combine debido se adapta mejor a diferentes sistemas operativos
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            //Crea un archivo en el directorio asignado si no hay uno existente
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //Transforma C# gamedata objeto en Json
            string dataToStore = JsonUtility.ToJson(data, true);

            if (useEncryptionSave)
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }

            //Escribe los datos serializados en el archivo
            using (FileStream stream =  new FileStream(fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }

            }
        }
        catch(Exception e)
        {
            Debug.LogError("Error al intentar al intentar guardar el archivo" + fullPath + "\n" + e);
        }
    }
    private string EncryptDecrypt(string data)
    {
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }
        return modifiedData;
    }
}
public class FileDataHandlerNoEncrypt
{
    private string dataDirPathNoEncrypt = "";

    private string dataFileNameNoEncrypt = "";

    public FileDataHandlerNoEncrypt(string dataDirPathNoEncrypt, string dataFileNameNoEncrypt)
    {
        this.dataDirPathNoEncrypt = dataDirPathNoEncrypt;
        this.dataFileNameNoEncrypt = dataFileNameNoEncrypt;
    }
    public NoEncryptedGameData LoadNoEncrypt()
    {
        //Usar mejor Path.Combine debido se adapta mejor a diferentes sistemas operativos
        string fullPath = Path.Combine(dataDirPathNoEncrypt, dataFileNameNoEncrypt);
        NoEncryptedGameData loadedData = null;
        //Revisa si existe un archivo que cargar
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToStore = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToStore = reader.ReadToEnd();
                    }

                }

                //Deserealizar los datos del archivo en json para pasar a un objeto en C#
                loadedData = JsonUtility.FromJson<NoEncryptedGameData>(dataToStore);
            }
            catch (Exception e)
            {
                Debug.LogError("Error al cargar los archivos desde: " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }
    public void SaveNoEncrypt(NoEncryptedGameData dataNoEncrypt)
    {
        //Usar mejor Path.Combine debido se adapta mejor a diferentes sistemas operativos
        string fullPath = Path.Combine(dataDirPathNoEncrypt, dataFileNameNoEncrypt);
        try
        {
            //Crea un archivo en el directorio asignado si no hay uno existente
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //Transforma C# gamedata objeto en Json
            string dataToStore = JsonUtility.ToJson(dataNoEncrypt, true);

            //Escribe los datos serializados en el archivo
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }

            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error al intentar al intentar guardar el archivo" + fullPath + "\n" + e);
        }
    }

}
