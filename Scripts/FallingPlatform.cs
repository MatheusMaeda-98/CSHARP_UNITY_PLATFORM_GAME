using UnityEngine;
using UnityEngine.UIElements;

public class FallingPlatform : MonoBehaviour

{   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float fallingTime;
    private TargetJoint2D target;
    private BoxCollider2D boxColl;

    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }
        
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("Falling", fallingTime);
        }


    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
          
        if(collider.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }

    }  

    void Falling()
        {
            target.enabled = false;
            boxColl.isTrigger = true;
        }

}
