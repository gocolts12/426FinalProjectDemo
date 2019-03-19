using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerController : NetworkBehaviour
{
    Rigidbody rb;
    Transform t;
    public int playernum;
    public float speed = 25.0f;
    public float rotationspeed = 90;
    public Text[] playerNumber;
    public NetworkStartPosition[] starts;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
        if (isLocalPlayer)
        {
            Camera.main.gameObject.transform.position = t.position;
            Camera.main.gameObject.transform.rotation = t.rotation;
            Camera.main.gameObject.transform.parent = t;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;

        if (Input.GetKey(KeyCode.W))
            rb.velocity += this.transform.forward * speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.S))
            rb.velocity -= this.transform.forward * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
            t.rotation *= Quaternion.Euler(0, rotationspeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.A))
            t.rotation *= Quaternion.Euler(0, -rotationspeed * Time.deltaTime, 0);
    }
}
