using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {
    public GameObject Bullet;
    
   
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            
            Destroy(Bullet);
        }
        if (collision.collider.tag == "Building")
        {

            Destroy(Bullet);
        }
        


    }
}
