using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{

    public float speed2 = 25.0f;
    public float rotationSpeed2 = 90;
    public float force2 = 250f;

    Rigidbody rb2;
    Transform t2;

    // Use this for initialization
    void Start()
    {

        rb2 = GetComponent<Rigidbody>();
        t2 = GetComponent<Transform>();
    }

    //Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            rb2.velocity += this.transform.forward * speed2* Time.deltaTime;
        else if (Input.GetKey(KeyCode.DownArrow))
            rb2.velocity -= this.transform.forward * speed2 * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
            rb2.rotation *= Quaternion.Euler(0, rotationSpeed2 * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.LeftArrow))
            rb2.rotation *= Quaternion.Euler(0, -rotationSpeed2 * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}