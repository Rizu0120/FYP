using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed; //player move speed setting
    public float jumpForce; //player jump height setting
    public CharacterController controller; //player controller

    private Vector3 moveDirection; //move in 3vector(3D = x,y,z)
    public float gravityScale; //gravity density setting

    public Transform pivot; //camera related component with player
    public float rotateSpeed; //player rotate speed

    public GameObject playerModel;

    public Animator animator;

    public AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //old movemennt control wihtout following camera direction
        // moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);

        //move with camera direction
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed; //move speed evenly in any direction
        moveDirection.y = yStore;

        //jump
        if (controller.isGrounded)
        {
            moveDirection.y = -gravityScale;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
                jumpSound.Play();
            }
        }
        
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);

        //Move player in different direction based on camera look direction
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

        //set condition for Animator, animation transition
        animator.SetBool("isGrounded", controller.isGrounded); //detect if isGrounded from function (controller.isGrounded)
        animator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal")))); //detect speed
    }
}
