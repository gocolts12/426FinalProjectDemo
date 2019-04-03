using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FollowObject : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
    public float force;
    Rigidbody rB;
    Transform T;
    public string priority1;
    public string priority2;
    public string priority3;
    public string priority4;



    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody>();
        T = GetComponent<Transform>();
       
       
    }

    // Update is called once per frame
    void Update()
    {
        GameObject close = null;
        //The Tag is whatever we want it to be
        GameObject[] a = GameObject.FindGameObjectsWithTag(priority1);
       //GameObject[] b = GameObject.FindGameObjectsWithTag(priority2);
       // GameObject[] c = GameObject.FindGameObjectsWithTag(priority3);
       // GameObject[] d = GameObject.FindGameObjectsWithTag(priority4);
        if (a.Length > 0)
        {
            close = closestModel(a);
        }
        //else if (b.Length > 0)
        //{
        //    close = closestModel(b);
        //}
        //else if (c.Length > 0)
        //{
        //    close = closestModel(c);
        //}

      



      
        
        

        float diffX = close.transform.position.x - this.transform.position.x;
        float diffZ = close.transform.position.z - this.transform.position.z;
        float angle = Mathf.Atan2(diffX, diffZ);
        angle = Mathf.Rad2Deg * angle;




        if (angle < 0) {
            angle = angle + 360;
            


            if (this.transform.eulerAngles.y > 0 && this.transform.eulerAngles.y < 90 || this.transform.eulerAngles.y > angle)
            {
                //if(this.transform.eulerAngles.y - angle > 0)
                    T.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);
                //else
                //    T.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
            }
            else if (this.transform.eulerAngles.y < angle)
            {
                T.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
            }
        }

        else
        {

           
            if (this.transform.eulerAngles.y > 270 && this.transform.eulerAngles.y < 360 || this.transform.eulerAngles.y < angle)
            {
                T.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
            }
            else if (this.transform.eulerAngles.y > angle)
            {
                T.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);
            }

        }
       // Debug.Log(rB.velocity.magnitude);
        if (rB.velocity.magnitude < 7)
        {
            rB.velocity += this.transform.forward * speed * Time.deltaTime;
        }
            //T.forward += this.transform.forward * Time.deltaTime * speed;
        

    //    }
    //    else if (close.transform.position.x > this.transform.position.x)
    //    {
    //        rB.velocity -= this.transform.forward * speed * Time.deltaTime;
    //    }

    //    if (close.transform.position.z < this.transform.position.z)
    //    {
    //        rB.velocity -= this.transform.right * speed * Time.deltaTime;
    //    }
    //    else if (close.transform.position.z > this.transform.position.z)
    //    {
    //        rB.velocity += this.transform.right * speed * Time.deltaTime;
    //    }
    }



    GameObject closestModel(GameObject[] targetModels)
    {
        GameObject closest = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach(GameObject targetModel in targetModels)
        {
            float distance = Vector3.Distance(currentPos, targetModel.transform.position);
            if(distance < minDist)
            {
                closest = targetModel;
                minDist = distance;
            }
        }

        return closest;

    }
}
