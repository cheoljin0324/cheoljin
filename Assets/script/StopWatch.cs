using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour
{
    [SerializeField] 
    public float startTime;
    [SerializeField]
    Text timetext;

    bool TimeActive = true;
    // Start is called before the first frame update
    void Start()
    {
        timetext.text = startTime.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        StartTime();
    }

    void StartTime()
    {
        if (TimeActive)
        {
            startTime += Time.deltaTime;
            timetext.text = startTime.ToString("F2");
            
        }

    }
}
