using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomZones : MonoBehaviour
{
    public int roomID;
    private PlayerThief pt;
    public List<GameObject> doors = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == pt.gameObject)
        {
            pt.roomID = roomID;
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        pt = FindObjectOfType<PlayerThief>();
    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        if (pt.hasLost || pt.hasWon) return;
        //bool allClosed = true;
        foreach (GameObject door in doors)
        {
            if (door != null)
            {
                if (door.activeSelf)
                {
                    count++;
                    Debug.Log("some not closed!");
                }
            }
        }

        if (count == doors.Count && pt.roomID == roomID)
        {
            
            pt.lose();
        }
    }
}
