using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICamSubtitle : MonoBehaviour
{
    private string subtitle;
    private float waitTime;
    private float blinkTime;
    private float blinkLength = 0.3225f;
    private bool blink;
    [SerializeField] private TextMeshProUGUI labelSubtitle;

    public void ShowSubtitle(string text)
    {
        resetBlink();
        waitTime = 1.25f;
        subtitle = text;
        labelSubtitle.text = "<" + subtitle + ">";
    }

    void resetBlink()
    {
        blink = false;
        blinkTime = blinkLength;
    }

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;

           
            if (blinkTime > 0) 
            {
                blinkTime -= Time.deltaTime;
                if (blinkTime <= 0)
                {
                    blink = !blink;
                    blinkTime = blinkLength;
                }
            }
            labelSubtitle.enabled = !blink;

        }
        else
        {
            labelSubtitle.enabled = false;
        }
        
        
    }
}
