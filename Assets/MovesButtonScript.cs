using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovesButtonScript : MonoBehaviour
{
    private Button button;
    public GameObject movesPanel;
    public DialougeSystem dialougeSystem;  
    private Action move;

    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            button.onClick.Invoke();
        }
    }

    public void MoveSelected(GameObject button)
    {
        if(button.name.Equals("Cut"))
        {
           move = () => BattleScenePlayer.instance.DealDamage(Moves.Cut);
            dialougeSystem.ShowText(Dialouges.instance.henryUsed + " " + Moves.Cut.ToString(),true, move);
        }
        else if(button.name.Equals("Scratch"))
        {
            move = () => BattleScenePlayer.instance.DealDamage(Moves.Scratch);
            dialougeSystem.ShowText(Dialouges.instance.henryUsed + " " + Moves.Scratch.ToString(), true,move);
        }
        else if (button.name.Equals("Rage"))
        {
            move = () => BattleScenePlayer.instance.DealDamage(Moves.Rage);
            dialougeSystem.ShowText(Dialouges.instance.henryUsed + " " + Moves.Rage.ToString(), true, move);
        }
        else if (button.name.Equals("Slash"))
        {
            move = () => BattleScenePlayer.instance.DealDamage(Moves.Slash);
            dialougeSystem.ShowText(Dialouges.instance.henryUsed + " " + Moves.Slash.ToString(), true, move);
        }
        movesPanel.SetActive(false);

    }

   
}
