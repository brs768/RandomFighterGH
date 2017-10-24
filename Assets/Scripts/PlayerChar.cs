using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerChar : MonoBehaviour
{

    //Variables used to handle rotation and movement
    Vector3 mousePos = new Vector3();
    Vector3 PCPos = new Vector3();
    float angle;

    //Variables used to track and display Health
    float currentHealth = 100f;
    float maxHealth = 100f;
    public GameObject healthBar;

    //Sprites for animations
    //TODO: Change to array and multiple bitmap
    public Sprite attack;
    public Sprite standard;


    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        WASDMovement();
        Rotation();
        Attack();
        updateHealth();
    }

    //Includes transform positions for WASD movement
    void WASDMovement()
    {
        //Vector3 PCpos = this.transform.position;
        Vector3 PCpos = this.GetComponent<SpriteRenderer>().transform.position;


        //up
        if (Input.GetKey("w") == true)
        {
            this.transform.position = new Vector3(PCpos.x, PCpos.y + .1f, PCpos.z);
        }

        //down
        if (Input.GetKey("s") == true)
        {
            this.transform.position = new Vector3(PCpos.x, PCpos.y - .1f, PCpos.z);
        }

        //right
        if (Input.GetKey("d") == true)
        {
            this.transform.position = new Vector3(PCpos.x + .1f, PCpos.y, PCpos.z);
        }

        //left
        if (Input.GetKey("a") == true)
        {
            this.transform.position = new Vector3(PCpos.x - .1f, PCpos.y, PCpos.z);
        }

        //up right
        if (Input.GetKey("w") == true && Input.GetKey("d") == true)
        {
            this.transform.position = new Vector3(PCpos.x + .1f, PCpos.y + .1f, PCpos.z);
        }

        //up left
        if (Input.GetKey("w") == true && Input.GetKey("a") == true)
        {
            this.transform.position = new Vector3(PCpos.x - .1f, PCpos.y + .1f, PCpos.z);
        }

        //down right
        if (Input.GetKey("s") == true && Input.GetKey("d") == true)
        {
            this.transform.position = new Vector3(PCpos.x + .1f, PCpos.y - .1f, PCpos.z);
        }

        //down left
        if (Input.GetKey("s") == true && Input.GetKey("a") == true)
        {
            this.transform.position = new Vector3(PCpos.x - .1f, PCpos.y - .1f, PCpos.z);
        }

    }

    //Makes the PC face the mouse pointer
    void Rotation()
    {
        mousePos = Input.mousePosition;

        mousePos.z = 9f; //distance mouse is from object
        //PCPos = Camera.main.WorldToScreenPoint(this.transform.position);
        PCPos = Camera.main.WorldToScreenPoint(this.GetComponent<SpriteRenderer>().transform.position);

        mousePos.x = mousePos.x - PCPos.x;
        mousePos.y = mousePos.y - PCPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        GetComponent<SpriteRenderer>().transform.rotation = Quaternion.Euler(0, 0, angle - 125);

    }

    //TODO: Change this so you can't hold down attack and add additional functionality
    //Currently only changes the sprite when left mouse is clicked.
    void Attack()
    {
        if (Input.GetMouseButton(0))
        {

            this.GetComponent<SpriteRenderer>().sprite = attack;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = standard;
        }
    }

    //TODO: Add collision so the player can kill enemies without being hurt
    //Handles collisions for the PC, currently only have 1 collision
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            currentHealth -= 5;
        }
    }

    //Relays updated health information to the hp bar
    void updateHealth()
    {
        float barFill = currentHealth / 100f;
        healthBar.GetComponent<Image>().fillAmount = barFill;
    }

}


//Githubtest
