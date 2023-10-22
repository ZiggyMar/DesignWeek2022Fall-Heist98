using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSpot : MonoBehaviour
{
    private Quaternion _startRotation;
    public float turnDist = 15f;
    public GameObject door;
    public float currentDist;
    
    // Start is called before the first frame update
    void Start()
    {
        _startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        currentDist += (Input.GetAxis("Vertical") * -1) * 25 * Time.deltaTime;
        currentDist = Mathf.Clamp(currentDist, -turnDist, turnDist);
        //transform.rotation = _startRotation * Quaternion.Euler(0.0f,Mathf.Sin(Time.time) * turnDist, 0.0f);
        transform.rotation = _startRotation * Quaternion.Euler(0.0f,currentDist + (Mathf.Sin(Time.time) * 3), 0.0f);
    }
}
