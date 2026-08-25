using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence
{
    void LoadData(GameData gameData);

    void SaveData(ref GameData gameData);
}
public interface IDataPersistenceNoCrypted 
{
    void LoadDataNoCrypted(NoEncryptedGameData noEncryptedGameData);

    void SavaDataNoCrypted(ref NoEncryptedGameData noEncryptedGameData);

}
public interface IDataLanguage
{
    void LoadDataLanguage(LanguageData languageData);

    void SaveDataLanguage(ref LanguageData languageData);
}
public interface IDataItemName
{
    void LoadDataItemName(ItemDataLanguage itemDataLanguage);

    void SaveDataItemName(ref ItemDataLanguage itemDataLanguage);
}
public interface IDataInterfaceText
{
    void LoadDataInterfaceText(InterfaceText interfaceDataText);

    void SaveDataInterfaceText(ref InterfaceText interfaceDataText);
}
