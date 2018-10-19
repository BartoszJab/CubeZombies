using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    
    

    public GameManager gameManager;
    public GameObject Enemy;
    int maxHealth = 100;
    public int currentHealth;
    int pistolDamage = 35;
    
    





    // Use this for initialization
    void Start()
    {
        gameManager.GetComponent<GameManager>();
        currentHealth = maxHealth;
    }

    

    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.collider.tag == "pistolBullet")
        {
            currentHealth = currentHealth - pistolDamage;
            


        }


    }



    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentHealth);



        
        Killed();

    }

    private void Killed()
    {
        if (currentHealth <= 0)
        {

            gameManager.addPoint();
            Destroy(Enemy);

        }
       
    }


   

  








}
