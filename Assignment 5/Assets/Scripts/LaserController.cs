using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{

    public AudioSource laserSound;

    public GameObject spawnPoint;

    private Vector3 TSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        TSpawnPoint = spawnPoint.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter(Collider other)
    {
        if (this.tag.Contains("Laser"))
        {
            if (other.gameObject.tag.Contains("RedPlayer"))
            {
                //Debug.Log("This Should Teleport");
                Instantiate(laserSound);
                other.gameObject.transform.position = TSpawnPoint;
            }
            else
            {

            }

        }
    }
}
