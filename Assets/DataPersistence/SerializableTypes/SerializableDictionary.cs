using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
/*
public class SerializableDictionaryList<TKey, TValue, TValueStorage> : Dictionary<TKey, List<TValue>>, ISerializationCallbackReceiver
    where TValueStorage : SerializableDictionaryList.Storage<TValue>, new()
{

    [SerializeField] public List<TKey> keys = new List<TKey>();

    [SerializeField] private List<TValueStorage> values = new List<TValueStorage>();

    //Save the dictionary to list
    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();

        foreach (KeyValuePair<TKey, List<TValue>> pair in this)
        {
            keys.Add(pair.Key);
            //values.Add(new List<TValue>(pair.Value));
            /*
            for (int i = 0; i < pair.Value.Count; i++)
            {
                values.Add(pair.Value);
            }
            foreach(TValue tValue in pair.Value)
            {
                values.Add(tValue);
            }*/
            //keys.Add();
            //values.Add(pair.Value);
            /*
            foreach (TValue tValue in pair.Value)
            {
                values.Add(tValue);
            }*/
            //values = pair.Value.ToList(); //.Add(pair.Value.ToList());

            //values.Add(pair.Value);
        

        /*
        foreach (KeyValuePair<TKey, List<TValue>> pair in this)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value[1]);
        }


    }
    //Load the Dictionary to List
    public void OnAfterDeserialize()
    {
        this.Clear();
        if (keys.Count != values.Count)
        {
            Debug.LogError($"SerializableDictionaryList deserialization error: Key count ({keys.Count}) != Value count ({values.Count})");
            return;
            /*
            Debug.LogError("Se ha intentado deserealizar un objeto del SerializableDictionary, pero la cantidad de Keys (" + keys.Count +
                ") no coincide con el numero de values (" + values.Count + ") esto indica que algo ha salido mal");
        }
        for (int i = 0; i < keys.Count; i++)
        {
            //valor = values.ToList();
            //this[keys[i]] = new List<TValue>(values[i]);
            //this.Add(keys[i],values[i]);
        }
    }
}
*/
