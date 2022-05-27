using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public Rigidbody2D rigi;
    public Animator anim;
    public Controller control;

    public float Speed = 400.0f;
    float pastSpeed = 0 ;

    GameObject nesne;

    bool nesne_var_mi = false;

    void Start()
    {
        pastSpeed = Speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            rigi.velocity = Vector2.zero;
            rigi.AddForce(transform.up * Speed);
        }

        if (collision.gameObject.name == "Pulley")
        {
            rigi.velocity = Vector2.zero;
            anim.enabled = true;

            if(nesne_var_mi == true)
            {
                if (nesne.gameObject.tag == "Gold")
                {
                    
                    Destroy(nesne);
                    nesne_var_mi = false;

                    control.para_arttir(100);
                }

                if (nesne.gameObject.tag == "Rock")
                {

                    Destroy(nesne);
                    nesne_var_mi = false;

                    control.para_arttir(20);
                }

                if (nesne.gameObject.tag == "Diamond")
                {

                    Destroy(nesne);
                    nesne_var_mi = false;

                    control.para_arttir(250);
                }

                Speed = pastSpeed;
            }
        }


        if (collision.gameObject.tag == "Gold"|| collision.gameObject.tag == "Rock"|| collision.gameObject.tag == "Diamond")
        {
            nesne = collision.gameObject;

            nesne.GetComponent<BoxCollider2D>().enabled = false;
            nesne_var_mi = true;
            rigi.velocity = Vector2.zero;

            if(collision.gameObject.tag != "Diamond")
            {
                float deger = collision.gameObject.transform.localScale.x;
                if (deger <= 0.5f)
                {
                    Speed = pastSpeed;
                }
                else if (deger> 0.5f)
                {
                    Speed *= 0.5f;
                }
            }
            else
            {
                Speed = pastSpeed;
            }
            rigi.AddForce(-transform.up * Speed);

            collision.gameObject.transform.parent = transform;
        }
    }

    public void firlat()
    {
        anim.enabled = false;
        rigi.AddForce(-transform.up * Speed);
    }
}
