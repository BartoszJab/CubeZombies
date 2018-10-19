using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shooting : MonoBehaviour {

    public Text ammoText;
    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public float Bullet_Forward_Force;
    

    public Animator animator;

    //ammo
    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadTime = 18f;
    private bool isReloading = false;


    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    void Start () {

        currentAmmo = maxAmmo;
	}
	
	// Update is called once per frame
	void Update () {
        //AMMO
        
        ammoText.text = "Ammo: "+currentAmmo.ToString();
        //AMMO   
         if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetKeyDown("r")){
            
            StartCoroutine(Reload());
            return;

        }

        if (Time.timeScale != 0)
        {
            if (Input.GetKeyDown("mouse 0"))
            {



                currentAmmo--;
                FindObjectOfType<AudioManager>().Play("Shoot");

                GameObject Temporary_Bullet_Handler;
                Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

                Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 180);

                Rigidbody Temporary_Rigidbody;
                Temporary_Rigidbody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

                Temporary_Rigidbody.AddForce(transform.forward * Bullet_Forward_Force);

                Destroy(Temporary_Bullet_Handler, 5f);


            }
        }
       
        


    }
    
    IEnumerator Reload()
    {
        
        isReloading = true;
        animator.SetBool("Reloading", true);
        FindObjectOfType<AudioManager>().Play("Reloading");
        yield return new WaitForSeconds(reloadTime- .25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(reloadTime - .25f);
        currentAmmo = maxAmmo;
        isReloading = false;
        
       
    }

    
}
