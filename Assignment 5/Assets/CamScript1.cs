using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript1 : MonoBehaviour
{
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;    
    }

    // Update is called once per frame
    void Update()
    {
        cam.rect = new Rect(0f, 0.0f, 0.5f, 1.0f);
    }
}
