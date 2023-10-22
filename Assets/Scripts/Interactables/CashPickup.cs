using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashPickup : MonoBehaviour
{
    public float value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerThief>())
        {
            other.gameObject.GetComponent<PlayerThief>().addMoney(value);
        }
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
