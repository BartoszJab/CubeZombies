using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour {

    public GameObject bullet;
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.collider.tag == "pistolBullet")
        {
            Destroy(bullet);
        }
    }
}
