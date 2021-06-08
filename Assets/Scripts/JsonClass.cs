using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JsonClass
{
    public Item[] Items;
}

[System.Serializable]
public class Item
{
    public area[] timeSeries;
}

[System.Serializable]
public class area
{
    public weatherCode[] areas;
}

[System.Serializable]
public class weatherCode
{
    public string[] weatherCodes;
}