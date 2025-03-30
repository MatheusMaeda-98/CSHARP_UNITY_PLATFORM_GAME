using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour


{ 
    public float Speed;
    public float JumpForce;
    public bool isJumping;
    public bool doubleJump;
    bool isBlowing;
    private Animator anim;
    private Rigidbody2D rig;


    void Start()
    {
     rig = GetComponent<Rigidbody2D>();
     anim = GetComponent<Animator>();   
    }

    void Update()
    {
        Move() ;
        Jump() ;    
    }


    void Move() //movimento do player
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        if(Input.GetAxis("Horizontal") > 0f)
        
        {    anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if(Input.GetAxis("Horizontal") < 0f)
        
        {    anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);  
        }
        if(Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("walk", false);
        }
    }

    void Jump() // double Jump e força do jump
    {
        if(Input.GetButtonDown("Jump") && !isBlowing)
        {   
            if(!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse); 
                doubleJump = true;
            }

        else
            {
                if(doubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse); 
                    doubleJump = false;
                }
                    
            }
             
        }	
    }

    void OnCollisionEnter2D(Collision2D collision) //GAMEOVER and double Jump Component
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
        }

        if(collision.gameObject.tag == "Spike")  //morte por espinhos
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Saw") //morte por serra
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
    }	

    

    void OnCollisionExit2D(Collision2D collision) // double jump component
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
        
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 11)
        {
            isBlowing = true;
        }
    }
    
        void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 11)
        {
            isBlowing = false;
        }
    }
    
}   
