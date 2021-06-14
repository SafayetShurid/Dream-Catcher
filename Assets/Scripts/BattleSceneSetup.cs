using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneSetup : MonoBehaviour
{
    public enum TextToShow
    {
        AttackText,BattleSceneIntro
    }
    public DialougeSystem dialougeSystem;
    void Start()
    {
        // dialougeSystem.AddText(Dialouges.instance.battleDialouges);
        //dialougeSystem.SetDialougeShowType(DialougeSystem.DialougeShowType.auto);
        //dialougeSystem.ShowText(Dialouges.instance.battleDialouges);
        
    }

    public void ShowText(TextToShow textToShow)
    {
        switch(textToShow)
        {
            case TextToShow.AttackText:
                dialougeSystem.ShowText(Dialouges.instance.chooseAnAttack,true,()=> { });
                break;
            case TextToShow.BattleSceneIntro:
                dialougeSystem.ShowText(Dialouges.instance.battleStartingDialouges,false, () => { });
                break;
        }
      
    }

    public void TextTrigger()
    {
        dialougeSystem.ShowText(Dialouges.instance.battleStartingDialouges,false, () => { });
    }
}
