using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript2 : MonoBehaviour
{
    private Camera cam2;

    // Start is called before the first frame update
    void Start()
    {
        cam2 = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        cam2.rect = new Rect(0.5f, 0.0f, 0.5f, 1.0f);
    }
}
