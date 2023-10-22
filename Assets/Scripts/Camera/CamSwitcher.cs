using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    public List<CamSpot> camPoints = new List<CamSpot>();
    public int camIndex = 0;
    public TextMeshProUGUI labelNoCam;
    public TextMeshProUGUI labelDoorCount;
    public UICamSubtitle camSubtitle;
    private int[] uiDoorIDs = new int[4];
    public float uiRejectCloseTimer;
    float waitTime = 1.25f;
    public float blinkTime;
    private float blinkLength = 0.33f;
    public bool blink;
    
    void resetBlink()
    {
        blink = false;
        blinkTime = blinkLength;
    }
    public void switchCam()
    {   
        camIndex++;
        if (camIndex > camPoints.Count - 1)
        {
            camIndex = 0;
        }
        Debug.Log(camIndex);
        UpdateCamPosition();
        UpdateDoorInfo();
    }

    public void switchCamToNum(int num)
    {
        camIndex = num - 1;
        Debug.Log(camIndex);
        UpdateCamPosition();
        UpdateDoorInfo();
    }

    public void UpdateDoorInfo()
    {
       labelNoCam.gameObject.SetActive(camPoints[camIndex].door == null);
       labelDoorCount.text = "";

       for (int i = 0; i < uiDoorIDs.Length; i++)
       {
           if (uiDoorIDs[i] != 0)
           {
               if (uiDoorIDs[i] - 1 == camIndex)
               {
                   labelDoorCount.text += "<color=\"yellow\"><sprite name=\"icon_door_cl\"> " + uiDoorIDs[i].ToString("00") + ". <color=\"white\">";
               }
               else
               {
                   labelDoorCount.text += "<sprite name=\"icon_door_cl\"> " + uiDoorIDs[i].ToString("00") + ". ";
               }
               
           }
           else
           {
               labelDoorCount.text += "<sprite name=\"icon_door_op\"> --. ";
           }
       }
       
       // foreach (CamSpot cs in camPoints)
       // {
       //     if (cs.door != null)
       //     {
       //         if (cs.door.activeSelf)
       //         {
       //             labelDoorCount.text += "<sprite name=\"icon_door\">";
       //         }
       //     }
       // }
    }

    int getDoorOpenCount()
    {
        int count = 0;
        foreach (CamSpot cs in camPoints)
        {
            if (cs.door != null)
            {
                if (cs.door.activeSelf)
                {
                    count++;
                }
            }
        }

        return count;
    }

    bool checkDoorClosedAtIndex(int index)
    {
        return camPoints[index].door.activeSelf;
    }
    
    void UpdateCamPosition()
    {
        this.transform.position = camPoints[camIndex].transform.position;
        this.transform.rotation = camPoints[camIndex].transform.rotation;
    }

    public void ToggleDoor()
    {
        if (camPoints[camIndex].door == null) return;
        ChangeDoorStatus(!camPoints[camIndex].door.activeSelf);
    }
    
    public void ChangeDoorStatus(bool open)
    {
        if (!open && getDoorOpenCount() >= uiDoorIDs.Length)
        {
            uiRejectCloseTimer = waitTime;
            resetBlink();
            return;
        }
        if (!open && checkDoorClosedAtIndex(camIndex)) return;
        if (open && !checkDoorClosedAtIndex(camIndex)) return;
        if (camPoints[camIndex].door != null) camPoints[camIndex].door.SetActive(!open);
        camSubtitle.ShowSubtitle((open? "OPEN" : "CLOSE"));
        if (!open)
        {
            for (int i = 0; i < uiDoorIDs.Length; i++)
            {
                if (uiDoorIDs[i] == 0)
                {
                    uiDoorIDs[i] = camIndex + 1;
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < uiDoorIDs.Length; i++)
            {
                if (uiDoorIDs[i] == camIndex + 1)
                {
                    uiDoorIDs[i] = 0;
                    break;
                }
            }
        }
        UpdateDoorInfo();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Open all doors by default
        foreach (CamSpot cs in camPoints)
        {
            if (cs.door != null) cs.door.SetActive(false);
        }
        
        UpdateDoorInfo();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCamPosition();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switchCam();
        }
        
        
     
            if (uiRejectCloseTimer > 0)
            {
                uiRejectCloseTimer -= Time.deltaTime;

           
                if (blinkTime > 0) 
                {
                    blinkTime -= Time.deltaTime;
                    if (blinkTime <= 0)
                    {
                        blink = !blink;
                        blinkTime = blinkLength;
                    }
                }
                if (!blink) labelDoorCount.color = Color.red;
                else labelDoorCount.color = Color.white;

            }
            else
            {
                blink = false;
                labelDoorCount.color = Color.white;
            }
        
        
        
    }
}
