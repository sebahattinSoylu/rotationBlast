using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool donsunmu;

    public float speed;

    public Transform center;

    private Vector2 direction;
   

    private bool geriDonsunmu;
    private void Start()
    {
        donsunmu = false;
        center.GetComponent<CircleCollider2D>().enabled = false;
    }

    void Update()
    {
       
        
        if (transform.position.x > 3 || transform.position.x < -3 || transform.position.y > 3 ||
            transform.position.y < -3)
        {
            GetComponent<Rigidbody2D>().velocity=Vector2.zero;
            
            center.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<TrailRenderer>().enabled = false;
            GameManager.instance.OyunuBaslat();
            donsunmu = false;
        }
        
        if (donsunmu)
        {
           
            transform.RotateAround(Vector3.zero,Vector3.forward, 100*Time.deltaTime);
        }

      
        
    }

    public void IleriFirlat()
    {
        donsunmu = false;
        geriDonsunmu = false;
        this.GetComponent<TrailRenderer>().enabled = true;
        
        GetComponent<Rigidbody2D>().AddForce(this.transform.right*speed);
        Invoke(nameof(ColliderOpen),.2f);
    }

    void ColliderOpen()
    {
        center.GetComponent<CircleCollider2D>().enabled = true;
    }
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Center"))
        {

            geriDonsunmu = false;
            
            GetComponent<Rigidbody2D>().velocity=Vector2.zero;
            direction = transform.position-col.transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) *Mathf.Rad2Deg;
            this.transform.rotation=Quaternion.Euler(0,0,angle);
            GameManager.instance.RastgeleRenkDegistir();
            donsunmu = true;
            
        }
       

       
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "hedefCircle")
        {
           
            //GetComponent<Rigidbody2D>().velocity=Vector2.zero;
         
            GameManager.instance.PuaniArtir();
        }

        
    }
}
