using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AmbienceArea
{
    FOREST,

    CAVE,

    WAVES,

    MACHINES,

    CAVE_WET,

    CAVE_TERROR,

    PEOPLE_TALK,

    LAVANDERIA,

    DUCHA,

    VIENTO,

    ASPERSORES,

    BASURA,

    DEFAULT,

    CLOACAS, 

    TURBINA,
    
    STORM,

    ALARM,

    DESIERTO

}
public class AmbienceActual: MonoBehaviour
{
    public static AmbienceArea ambienceNow;
}
