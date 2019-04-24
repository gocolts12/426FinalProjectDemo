using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileController : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject invert_sphere;
    public ScoreKeeper ui;
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
        if (this.tag.Contains("BlueTile"))
        {
            if (other.gameObject.tag.Contains("RedPlayer"))
            {
                Debug.Log("This Should Teleport");
                Instantiate(invert_sphere, other.gameObject.transform.position, other.gameObject.transform.rotation);
                other.gameObject.transform.position = TSpawnPoint;
                ui.P1Explode();
            }
            else
            {

            }
          
        }
        if (this.tag.Contains("RedTile"))
        {
            if (other.gameObject.tag.Contains("BluePlayer"))
            {
                Instantiate(invert_sphere, other.gameObject.transform.position, other.gameObject.transform.rotation);
                other.gameObject.transform.position = TSpawnPoint;
                ui.P2Explode();
            }
            else
            {

            }
        }
    }
}
