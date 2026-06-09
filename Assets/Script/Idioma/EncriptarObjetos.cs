using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class EncriptarObjetos : MonoBehaviour
{
    void SaveItemsArchive(string path, string nameArchivo, List<string> listObjetos)
    {
        string fullPath = Path.Combine(path, nameArchivo);

        if (File.Exists(fullPath))
        {
            Debug.Log("Existo,por tanto, no tengo que hacer nada");
            File.WriteAllText(fullPath, FileDataHandler.EncryptDecrypt(File.ReadAllText(fullPath)));
        }
        else
        {
            try
            {
                Debug.Log("Soy el " + path + " y estoy siendo creado");
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        for (int e = 0; e < listObjetos.Count; e++)
                        {
                            writer.WriteLine(listObjetos[e]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Error al intentar crear el archivo" + fullPath + "\n" + e);
            }
        }
    }

    [ContextMenu("Encriptar o desencriptar lista de objetos")]
    public void DecryptarObjetosEspañol()
    {
        string pathEspañol = Application.dataPath + "/Idiomas/Español/Objetos/Lista_Objetos.txt";
        File.WriteAllText(pathEspañol, FileDataHandler.EncryptDecrypt(File.ReadAllText(pathEspañol)));
        //File.WriteAllText(IdiomaGlobalManager.readFromFilePathEspañolCompleto, EncriptarListaObjeto(File.ReadAllText(IdiomaGlobalManager.readFromFilePathEspañolCompleto)));
    }
    [ContextMenu("Encriptar o desencriptar en Ingles")]
    public void DecryptaritemsEnglish()
    {
        string pathEnglish = Application.dataPath + "/Idiomas/Ingles/Items/List_Items.txt";
        File.WriteAllText(pathEnglish, FileDataHandler.EncryptDecrypt(File.ReadAllText(pathEnglish)));
    }
}
