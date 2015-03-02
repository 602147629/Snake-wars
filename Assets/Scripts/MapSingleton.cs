using System;
using UnityEngine;
using System.Collections;

public sealed class MapSingleton : MonoBehaviour
{
    private static readonly MapSingleton instanсe = new MapSingleton();

    static MapSingleton()
    {
    }

    private MapSingleton()
    {
    }

    public static MapSingleton Instance
    {
        get { return instanсe; }
    }

    public void createMap(String name)
    {
        GameObject easy = (GameObject)Instantiate(Resources.Load(name, typeof(GameObject)));
        easy.transform.position = new Vector3(0, 0, 0);
    }
}
