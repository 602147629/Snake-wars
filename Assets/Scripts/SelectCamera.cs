using UnityEngine;
using System.Collections;

public class SelectCamera : MonoBehaviour 
{
    public static bool typeCam = false;

    public void chooseFirstCamera()
    {
        typeCam = true;
    }    
    
    public void chooseSecondCamera()
    {
        typeCam = false;
    }
}
