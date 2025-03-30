using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Box : MonoBehaviour
{   
    public int health;
    public float jumpForce;
    public bool IsUp;
    public Animator anim;
    public GameObject effect;

    void Update ()
    {
    if (health <= 0)
        {
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(transform.parent.gameObject);   //destroi o box pai
        }

    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(IsUp)
            {
            anim.SetTrigger("hit");
            health--;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            }

            else
            {
            
            anim.SetTrigger("hit");
            health--;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -jumpForce), ForceMode2D.Impulse);
            
            }
        }

    }

    
}
