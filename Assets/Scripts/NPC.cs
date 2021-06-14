using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    
    public bool textStaysinHud;    

    public override void SayDialouge()
    {
        SetupDialougeSystemHud();
        DialougeSystem.instance.ShowText(dialouges, textStaysinHud, () => { });
    }

    public override void SayDialouge(int lineNumber)
    {
        SetupDialougeSystemHud();
        DialougeSystem.instance.ShowText(dialouges[lineNumber], textStaysinHud, () => { });
    }
   
}
