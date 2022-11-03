using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListMissions : MonoBehaviour
{
    public static ListMissions listaMissions;

    public List<MainMission> missionsMap;
    private void Awake()
    {
        if (ListMissions.listaMissions == null)
        {
            ListMissions.listaMissions = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
