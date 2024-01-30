using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerMov
{

    public class Walking : MonoBehaviour
    {
        Animator anim;
        public Camera playerCamera;
        public float walkSpeed = 1f;
        public float runSpeed = 1f;
        public float jumpPower = 7f;
        public float gravity = 10f;
        public float lookSpeed = 2f;
        public float lookXLimit = 45f;
        public float defaultHeight = 2f;
        public float crouchHeight = 1f;
        public float crouchSpeed = 3f;


        private Vector3 moveDirection = Vector3.zero;
        private float rotationX = 0;
        private CharacterController characterController;

        private bool canMove = true;
        public int damage;


        private bool targetHit;

        AudioSource audioSource;
        public AudioClip drunkWalking;


        void Start()
        {
            characterController = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            anim = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
        }
        void steps()
        {
            audioSource.PlayOneShot(drunkWalking);
        }
        void Drinking()
        {
            walkSpeed = 0f;
            runSpeed = 0f;
        }
        void DoneDrinking()
        {
            walkSpeed = 1f;
            walkSpeed = 1f;
        }
        void Update()
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            {
                moveDirection.y = jumpPower;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }

            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.R) && canMove)
            {
                characterController.height = crouchHeight;
                walkSpeed = crouchSpeed;
                runSpeed = crouchSpeed;

            }


            characterController.Move(moveDirection * Time.deltaTime);

            if (canMove)
            {
                rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
            }

            if (Input.GetKey("w") || Input.GetKey("up") || Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("s") || Input.GetKey("left") || Input.GetKey("right") || Input.GetKey("down"))
            {
                anim.SetBool(("walk"), true);
            }
            else
            {
                anim.SetBool("walk", false);
            }
            if (Input.GetKey("e"))
            {
                Drinking();
                Invoke("DoneDrinking", 10f);

            }
            if (Input.GetMouseButtonDown(0) == true)
            {
                anim.SetTrigger("throw");
            }

            if (Input.GetMouseButtonDown(1) == true)
            {
                anim.SetTrigger("punch");
            }

            if (Input.GetKey("t"))
            {
                anim.SetTrigger("die");
            }
        } 
    }
}


