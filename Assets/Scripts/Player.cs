using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public Character currentNPC;
    public GameObject currentObject;
    public Transform triggerDetector;
    private GameObject currentGrabbedGameobject;

   


    public void SetCurrentNPC(Character npc)
    {
        currentNPC = npc;        
    }


    public void GrabGameObject(GameObject obj)
    {
        //obj.SetActive(true);
        obj.transform.SetParent(this.transform);
        currentGrabbedGameobject = obj;
    }

    public void SetGrabObjPosition(string pos)
    {
        switch (pos)
        {
            case "up":
                break;
            case "left":
                currentGrabbedGameobject.transform.localPosition = new Vector3(-0.21f, -0.211f);
                break;
            case "right":
                break;
            case "down":
                currentGrabbedGameobject.transform.localPosition = new Vector3(0.047f, -0.211f);
                break;
            default:
                break;
        }



    }
}