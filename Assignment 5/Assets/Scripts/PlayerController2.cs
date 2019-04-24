using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerController2 : NetworkBehaviour
{
    Rigidbody rb;
    Transform t;
    public GameObject EyeLevel;
    Transform el;
    public int playernum;
    public float speed = 25.0f;
    public float jumpforce = 200.0f;
    public float rotationspeed = 90.0f;
    public float turnspeed = 2.0f;
    public Text[] playerNumber;
    private bool onGround;
    public NetworkStartPosition[] starts;
    public AudioSource jump;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
        el = EyeLevel.GetComponent<Transform>();
        if (isLocalPlayer)
        {
            Camera.main.gameObject.transform.position = el.position;
            Camera.main.gameObject.transform.rotation = el.rotation;
            Camera.main.gameObject.transform.parent = el;
        }
        onGround = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;

        if (Input.GetKey(KeyCode.W))
            rb.position += this.transform.forward * speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.S))
            rb.position -= this.transform.forward * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
            //t.rotation *= Quaternion.Euler(0, rotationspeed * Time.deltaTime, 0);
            rb.position += this.transform.right * speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.A))
            //t.rotation *= Quaternion.Euler(0, -rotationspeed * Time.deltaTime, 0);
            rb.position -= this.transform.right * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && onGround == true)
        {
            
           Instantiate(jump);

            jump.Play();
            Debug.Log(onGround);
            rb.AddForce(Vector3.up * 15.0f, ForceMode.Impulse);
            onGround = false;
            
        }

        float h = turnspeed * Input.GetAxis("Mouse X");
        float v = turnspeed * Input.GetAxis("Mouse Y");

        Camera.main.gameObject.transform.Rotate(-1.0f * v, 0, 0);
        transform.Rotate(0, h, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }
}
