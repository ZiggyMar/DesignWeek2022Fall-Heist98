using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSecurity : MonoBehaviour
{
    private CamSwitcher cs;
    public bool hasLost;
    public bool hasWon;
    public TextMeshProUGUI labelEnd;
    public PlayerThief pt;
    public void win()
    {
        labelEnd.gameObject.SetActive(true);
        labelEnd.color = Color.yellow;
        labelEnd.text = "YOU TRAPPED THE THIEF!\nGOOD WORK!";
        hasLost = false;
        hasWon = true;
        
    }
    
    public void lose()
    {
        labelEnd.gameObject.SetActive(true);
        labelEnd.color = Color.red;
        labelEnd.text = "THE THIEF GOT AWAY...\nYOU'RE FIRED!";
        hasLost = true;
        hasWon = false;
        
    }
    
    private void Awake()
    {
        cs = GetComponent<CamSwitcher>();
    }

    public void CommandDoor(bool open)
    {
        if (hasLost || hasWon) return;
        cs.ChangeDoorStatus(open);
    }

    // Start is called before the first frame update
    void Start()
    {
        cs.camIndex = 0;
        cs.ChangeDoorStatus(false);
        cs.camIndex = 1;
        cs.ChangeDoorStatus(false);
        cs.camIndex = 0;
        cs.UpdateDoorInfo();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            CommandDoor(true);
        }   
        if (Input.GetKeyDown(KeyCode.P))
        {
            CommandDoor(false);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1)) cs.switchCamToNum(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) cs.switchCamToNum(2);
        if (Input.GetKeyDown(KeyCode.Alpha3)) cs.switchCamToNum(3);
        if (Input.GetKeyDown(KeyCode.Alpha4)) cs.switchCamToNum(4);
        if (Input.GetKeyDown(KeyCode.Alpha5)) cs.switchCamToNum(5);
        if (Input.GetKeyDown(KeyCode.Alpha6)) cs.switchCamToNum(6);
        if (Input.GetKeyDown(KeyCode.Alpha7)) cs.switchCamToNum(7);
        if (Input.GetKeyDown(KeyCode.Alpha8)) cs.switchCamToNum(8);
        if (Input.GetKeyDown(KeyCode.Alpha9)) cs.switchCamToNum(9);
        if (Input.GetKeyDown(KeyCode.Alpha0)) cs.switchCamToNum(10);
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);

     
    }
}
