using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerThief : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 3;
    public float rotationSpeed = 1.2f;
    public float speedLimit;
    public float cashMoney = 0;
    public TextMeshProUGUI labelCash;
    public float cashGoal = 140000;
    public bool hasWon;
    public bool hasLost;
    public TextMeshProUGUI labelEnd;
    public PlayerSecurity ps;
    public int roomID;
    public Animator animator;
    //CharacterController controller;
    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //controller = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void win()
    {
        labelEnd.gameObject.SetActive(true);
        labelEnd.color = Color.yellow;
        labelEnd.text = "YOU ROBBED THEM BLIND!\nCONGRATULATIONS!";
        hasLost = false;
        hasWon = true;
        ps.lose();
        
    }
    
    public void lose()
    {
        labelEnd.gameObject.SetActive(true);
        labelEnd.color = Color.red;
        labelEnd.text = "BUSTED!\nBETTER LUCK NEXT TIME...";
        hasLost = true;
        hasWon = false;
        ps.win();   
        
    }
    public void addMoney(float dollaz)
    {
        cashMoney += dollaz;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(roomID);
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !hasWon && !hasLost)
        {
            
            Vector3 myForward = transform.TransformDirection(Vector3.forward);
            rb.AddForce(myForward * (moveSpeed * Time.deltaTime));
            if (rb.velocity.magnitude > speedLimit)
            {
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, speedLimit);
            }
            
    
        }

        labelCash.text = "$" + cashMoney.ToString("F0");

        if (Input.GetKey(KeyCode.H))
        {
            cashMoney += 1000;
        }

        if (cashMoney >= cashGoal && !hasWon)
        {
            win();
        }
        //float horizontalSpeed  = new Vector3(controller.velocity.x, 0, controller.velocity.z).magnitude;
        Debug.Log(rb.velocity.magnitude);
        
        if (rb.velocity.magnitude > 1)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
        
    }
}
