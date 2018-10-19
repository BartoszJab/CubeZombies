using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    Movement playerMovement;

    bool isDead;
    bool damaged;


    private void Awake()
    {
        playerMovement = GetComponent<Movement>();
        currentHealth = startingHealth;
    }


    
	
	
	void Update () {
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {                               //(color when hit,color we want, time how fast we want the change 
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
		
	}

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if (currentHealth <= 0 && !isDead)
        {
            FindObjectOfType<GameManager>().GameOver();
            Death();
        }

       

    }
    void Death()
    {
        isDead = true;
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        playerMovement.enabled = false;
    }

}
