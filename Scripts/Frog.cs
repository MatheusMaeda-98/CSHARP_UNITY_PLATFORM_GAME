using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Frog : MonoBehaviour
{   
    private Rigidbody2D rig;
    private Animator anim;
    public float speed;
    public Transform rightCol;
    public Transform leftCol;
    public Transform headPoint;
    private bool colliding;
    public LayerMask layer;
    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.linearVelocity = new Vector2(speed, rig.linearVelocity.y); //movimento do inimigo sem mecher o eixo y
        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer); //criando 2 colisores que delimita o inimigo

        if(colliding)
        {   
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1f;
        }
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            float height = col.contacts[0].point.y - headPoint.position.y; //altura entre o 1° contato e a posição da cabeça do inimigo

            if(height > 0) //morte do frog (lembre colocar o headpoint abaixo do boxcollider do frog)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                speed = 0;
                anim.SetTrigger("die");
                boxCollider2D.enabled = false; //desabilitando os colisores
                circleCollider2D.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, 0.33f); //destroy o inimigo dps de 1 seg
            }
            else
            {
                GameController.instance.ShowGameOver();
                Destroy(col.gameObject);
            }

        }
    }
        
}
