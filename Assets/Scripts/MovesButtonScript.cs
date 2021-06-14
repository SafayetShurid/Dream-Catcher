using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MovesButtonScript : MonoBehaviour
{
    private Button button;
    public GameObject movesPanel;
    public DialougeSystem dialougeSystem;  
    private Action move;
    private bool isSelected;

    private Tween anim;

    void Start()
    {
        anim = transform.DOLocalMoveY(transform.localPosition.y + 3f, 0.5f).SetLoops(1000, LoopType.Yoyo).SetEase(Ease.Linear);
        anim.Pause();

        button = GetComponent<Button>();
        if(button.name=="Cut")
        {
            SelectedAnimation();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(isSelected)
            {
                button.onClick.Invoke();
                movesPanel.SetActive(false);
                Invoke("WeirdButtonFix", 0.75f);
                SoundManager.instance.PlayOtherSource(SoundManager.instance.buttonPressedClip);
            }
          
        }
    }

    private void WeirdButtonFix()
    {
        movesPanel.SetActive(false);
    }

    public void MoveSelected(GameObject button)
    {
        movesPanel.SetActive(false);
        if (button.name.Equals("Cut"))
        {
            move = () =>
            {
                BattleScenePlayer.instance.DealDamage(Moves.Cut);
               
            };

            dialougeSystem.ShowText(Dialouges.instance.henryUsed + " " + Moves.Cut.ToString(),true, move);
          
        }
        else if(button.name.Equals("Scratch"))
        {
            move = () =>
            {
                BattleScenePlayer.instance.DealDamage(Moves.Scratch);
               
            }; 
            dialougeSystem.ShowText(Dialouges.instance.henryUsed + " " + Moves.Scratch.ToString(), true,move);
        }
        else if (button.name.Equals("Rage"))
        {
            move = () =>
            {
                BattleScenePlayer.instance.DealDamage(Moves.Rage);
                
            };
            dialougeSystem.ShowText(Dialouges.instance.henryUsed + " " + Moves.Rage.ToString(), true, move);
        }
        else if (button.name.Equals("Slash"))
        {
            move = () =>
            {
                BattleScenePlayer.instance.DealDamage(Moves.Slash);
              
            };
            dialougeSystem.ShowText(Dialouges.instance.henryUsed + " " + Moves.Slash.ToString(), true, move);
        }
       
          
    }

    public void SelectedAnimation()
    {
        isSelected = true;
       
        if(!anim.IsPlaying())
        {
            anim.Play();
        }
       
        SoundManager.instance.PlayOtherSource(SoundManager.instance.moveChangeClip);
    }
    public void DeselectedAnimation()
    {
        isSelected = false;
        anim.Pause();
    }




}
