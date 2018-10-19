using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement : MonoBehaviour {

    public float speed;
    Rigidbody rb;
    int floorMask;
    float camRayLength = 100f;
    public float run;
    

    


    


    
    

    
    
    
    




    private void Awake()
    {
        
        floorMask = LayerMask.GetMask("Floor");
        
        
    }
    void Start()
    {
        


        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        Turning();
        FastWalk();
        
        


    }
   
    void Turning()
    {

        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            rb.MoveRotation(newRotation);

        }
    }
    public void FastWalk()
    {
        if (Input.GetKey(KeyCode.LeftShift)) {

            
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed * run);
            
                 
                }
        else
        {
            
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);
            
        }
       
 


}
    
    
    

    
    
    
    

}
