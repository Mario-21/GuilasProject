using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<TKey,TValue> : Dictionary<TKey,TValue>, ISerializationCallbackReceiver
{
    [SerializeField] public List<TKey> keys = new List<TKey>();

    [SerializeField] public List<TValue> values = new List<TValue>();

    //Save the dictionary to list
    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();
        foreach (KeyValuePair<TKey,TValue>   pair in this)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }

    //Load the Dictionary to List
    public void OnAfterDeserialize()
    {
        this.Clear();
        if(keys.Count != values.Count)
        {
            Debug.LogError("Se ha intentado deserealizar un objeto del SerializableDictionary, pero la cantidad de Keys (" + keys.Count + 
                ") no coincide con el numero de values (" + values.Count + ") esto indica que algo ha salido mal");
        }
        
        for(int i = 0; i < keys.Count; i++)
        {
            this.Add(keys[i], values[i]);
        }
    }
}
