using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D characterController;
    public float runSpeed = 40f;
    float horzMove;
    public Animator animator;
    bool jump;
    bool crouch;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetChildComponent<Animator>();
    }
    

    // Update is called once per frame
    void Update()
    {
        horzMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (horzMove != 0) {
            animator.SetBool("walk", true);
        
        }
        else
        {
            animator.SetBool("walk", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("jump", true);
            jump = true;
        }
        else
        {
            animator.SetBool("jump", false);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            animator.SetBool("crouch", true);
            crouch = true;
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            animator.SetBool("crouch", false);
            crouch = false;
        }

    }

    private void FixedUpdate()
    {
        characterController.Move(horzMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }
}
