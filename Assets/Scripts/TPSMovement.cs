using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TPSMovement : MonoBehaviour
{
    #region Public
    public CharacterController controller;
    Vector3 movedirection;

    public float speed = 5f;

    public float runspeed = 10f;

    public float jumpforce = 10f;

    public float gravity = -20f;

    public float stealthmove = 2f;

    public float turnSmoothTime = 0.1f;

    public Transform cam;
   
    float turnSmoothVelocity;
    #endregion


    #region Script déplacements
    // Update is called once per frame// \\ Script pour le déplacement et les mouvements et suivis de caméra\\
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
       


        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        if (controller.isGrounded)
        {
            movedirection = transform.forward * speed * vertical;
            movedirection = transform.forward * speed * horizontal;
        }
        #endregion

        // CODE POUR SAUTER 
        if (Input.GetButtonDown("Jump"))
        {
            movedirection.y = jumpforce = 8f;

            Debug.Log("Jump true");
        }
        // ADD GRAVITY 
        movedirection.y += gravity * Time.deltaTime;
        controller.Move(movedirection * Time.deltaTime);
        // Pour Sprinter 
        if (Input.GetButton("Sprint"))
        {

            movedirection = transform.forward * runspeed * vertical;
            movedirection = transform.forward * runspeed * horizontal;

            Debug.Log("Sprint enable");
        }

    }


}








