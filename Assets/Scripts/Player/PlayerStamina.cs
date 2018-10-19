using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour {

    Movement movement;
    public Rigidbody rb;
    

    //stamina
    
    public int maxStamina;
    public int currentStamina;


    private int staminaFallRate;
    public int staminaFallMult;

    private int staminaRegainRate;
    public int staminaRegainMult;

    public Slider staminaSlider;



    private void Start()
    {
        movement = GetComponent<Movement>();

        rb = GetComponent<Rigidbody>();
        currentStamina = maxStamina;

        staminaFallRate = 1;
        staminaRegainRate = 1;

        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = maxStamina;
    }



    void Update () {

        
        //Stamina Control Section

        //If an object moves and l.shift button is pressed
        if(rb.velocity.magnitude > 0 && Input.GetKey(KeyCode.LeftShift))
        {
           
            staminaSlider.value -= Time.deltaTime / staminaFallRate * staminaFallMult;


        }
        else
        {
            
            staminaSlider.value += Time.deltaTime / staminaRegainRate * staminaRegainMult;
        }
        if (staminaSlider.value >= maxStamina)
        {
            staminaSlider.value = maxStamina;
        }
        else if (staminaSlider.value <= 0) {

            staminaSlider.value = 0;
            movement.run = 1;

        }
        else if (staminaSlider.value >= 0)
        {
            movement.run = 1.5f;
        }
        
        
	}
}
