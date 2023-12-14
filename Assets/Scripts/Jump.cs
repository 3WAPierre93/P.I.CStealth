using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;
using UnityEngine;

namespace Assets.Scripts
{

    internal class Jump
    {
        #region publicForJump
        public CharacterController controller;

        Vector3 movedirection;

        public float gravity = -20f;

        public float jumpforce = 8f;
        #endregion
        public void Update()

        {
            // CODE POUR SAUTER 
            if (Input.GetButtonDown("Jump"))
          {
            movedirection.y = jumpforce = 8f;

            Debug.Log("Jump true");
          }
          // ADD GRAVITY 
          movedirection.y += gravity * Time.deltaTime;
          controller.Move(movedirection * Time.deltaTime);


        }
    
    }

}