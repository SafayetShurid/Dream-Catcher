using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingScene : MonoBehaviour
{

    public static StartingScene instance;   
    public Transform dorianNextPosition;

    public void Start()
    {
        instance = this;
        
        DialougeSystem.instance.AddText(Dialouges.instance.basilDialouges);
        DialougeSystem.instance.SetDialougeShowType(DialougeSystem.DialougeShowType.auto);
    }

    public void SettingUpNextPhase()
    {
       
    }

    
}
