using UnityEngine;
using System.Collections;

public class TopCamera : MonoBehaviour {
    public GameObject camera;    

   public void OnMouseDown()
    {
       camera.transform.position = new Vector3(0.01f, 7f, -2f);
       camera.transform.Rotate(10f, 0f, 0f);
    }
}
