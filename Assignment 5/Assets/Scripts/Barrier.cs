using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{

    Rigidbody rB;
    public ParticleSystem p;
    public AudioSource aS;
    public Light light;
    private Vector3 location;

    private void Start()
    {
        location = this.gameObject.transform.position;
        rB = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RedPlayer")
        {
            Debug.Log("Yo");
            p.transform.position = other.transform.position;
            Instantiate(p);
            
            p.Play();
            Instantiate(aS, other.transform);
            light.transform.position = other.transform.position;
            Instantiate(light);
            aS.Play();
            light.enabled = true;



            
            
            
            
        }
    }
}
