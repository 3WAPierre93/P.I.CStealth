using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSMovement : MonoBehaviour
{
    public CharacterController controller;
    Vector3 movedirection;

    public float speed = 5f;

    public float turnSmoothTime = 0.1f;

    public float gravity = -20f;

    public float jumpspeed = 6f;

    public Transform cam; 

    float turnSmoothVelocity;



    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,turnSmoothTime);

            transform.rotation = Quaternion.Euler( 0f, angle ,0f );

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if(Input.GetButtonDown("Jump"))
        {
            movedirection.y = jumpspeed;
        }

        // ADD GRAVITY 
        movedirection.y += gravity * Time.deltaTime;
        controller.Move(movedirection * Time.deltaTime);


        
    }
}
