using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TimeLine
{
    timeline1,timeline2,timeline3,timeline4
}

public class TimelineActivator : MonoBehaviour
{
    public GameObject timeLine1;
    public GameObject timeLine2;
    public GameObject timeLine3;
    public GameObject timeLine4;

    public static TimelineActivator instance;

    void Awake()
    {
        instance = this;
    }   

    public void ActivateTimeLine(TimeLine timeLine)
    {
        switch (timeLine)
        {
            case TimeLine.timeline1:
                timeLine1.SetActive(true);
                break;
            case TimeLine.timeline2:
                timeLine2.SetActive(true);
                break;
            case TimeLine.timeline3:
                timeLine3.SetActive(true);
                break;
            case TimeLine.timeline4:
                timeLine4.SetActive(true);
                break;
        }

    }
}