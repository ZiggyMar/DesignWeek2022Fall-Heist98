using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICamTimestamp : MonoBehaviour
{
    private TextMeshProUGUI _label;
    public CamSwitcher _cs;
    private void Awake()
    {
        _label = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DateTime timestampDate = new DateTime(1998, DateTime.Now.Month, DateTime.Now.Day);
        var index = _cs.camIndex + 1;
        _label.text = "CAM" + index.ToString("00") + "\n" + System.DateTime.Now.ToString("hh:mm:ss tt") + " " + timestampDate.ToString("yyyy/MM/dd");
    }
}
