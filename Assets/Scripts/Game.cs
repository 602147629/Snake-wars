using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    public static int points;
    public int countWals = 10;
    private string _pointsString;
    private int _lastPonts = -1;
 
    public static string numberCombination;
    private int randomNumber;
    public Text text;
    private MapSingleton mapSingleton = MapSingleton.Instance;

    public void Awake()
    {
        switch (SelectIntricacy.intricacy)
        {
            case "easy":
            mapSingleton.createMap("Prefabs/Lab1");
            break;
            case "average":
            mapSingleton.createMap("Prefabs/Lab1");         
            break;
            case "complex":
            mapSingleton.createMap("Prefabs/Lab1");
            break;
        }
        points = 0;

        for (int i = 0; i < 10; i++)
        {
            randomNumber = Random.Range(0, 9);
            Food.GenerateNewFood("Prefabs/Food " + randomNumber);
                   
        }
    }

    public void Update()
    {
        if (_lastPonts == points) return;

        _lastPonts = points;
        _pointsString = "Score: " + points.ToString("0000");

        text.text = numberCombination;
    }


    public void OnGUI()
    {
        GUI.color = Color.yellow;
        GUI.Label(new Rect(20, 20, 200, 20), _pointsString ?? "");
    }
        
}