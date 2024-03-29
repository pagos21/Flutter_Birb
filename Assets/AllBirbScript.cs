using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AllBirbScript : MonoBehaviour
{
    //Creo uno slot dove slavare il rigidbody
    public Rigidbody2D myRigidbody;
    public float flatStrength;
    public LogicScript logic;
    public bool isBirdOK = true;
    //forza di torsione quando colpisce un oggetto
    public float torque = 0;
    public float bounceForce = 40f;
    // Start is called before the first frame update (start viene eseguito solo una volta)
    void Start()
    {
        //gameObject.name = "Bob the Borb";
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame (ogni songolo frame chima questa funzione)
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && isBirdOK)
            {
                myRigidbody.velocity = Vector2.up * flatStrength;
            }
        }
        if (transform.position.y > 17|| transform.position.y < -15 || transform.position.x < -46)
        {
            isBirdOK = false;
            logic.gameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.layer);
        myRigidbody.AddTorque(torque);
        //rb = GetComponent<Rigidbody2D>();
        //Vector2 backward = -transform.right;
        //Vector2 bounce = Vector2.Reflect(rb.velocity.normalized, collision.contacts[0].normal).normalized;
        //Vector2 bounce2 = new Vector2(-rb.velocity.x, rb.velocity.y);
        //myRigidbody.AddForce(bounce2 * 2 , ForceMode2D.Impulse);
        Vector2 bounceDirectio = collision.contacts[0].normal;
        myRigidbody.AddForce(bounceDirectio * bounceForce, ForceMode2D.Impulse);
        isBirdOK = false;
        logic.gameOver();
    }
}
