using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingScene : MonoBehaviour
{

    public static StartingScene instance;   
    public Transform dorianNextPosition;
    public DialougeSystem dialougeSystem;

    public void Start()
    {
        instance = this;

        dialougeSystem.AddText(Dialouges.instance.basilDialouges);
        dialougeSystem.SetDialougeShowType(DialougeSystem.DialougeShowType.auto);
    }

    public void SettingUpNextPhase()
    {
       
    }

    
}
