using Unity.VisualScripting;
using UnityEngine;

public class Trampoline : MonoBehaviour
{   
    public float jumpForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private BoxCollider2D boxColl;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")

        {   
            anim.SetTrigger("jump");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
        }
    }
    // Update is called once per fram
}
