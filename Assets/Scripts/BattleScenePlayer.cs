using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public enum Moves
{
    Cut,Scratch,Rage,Slash
}

public class BattleScenePlayer : MonoBehaviour
{

    public Hud hud;
    public int health;
    public DialougeSystem dialougeSystem;
    public GameObject movesPanel;
    public Animator animator;


    public Material material;
    public Sprite henrySprite;
    public Sprite dorianSprite;

    private Image image;
    private Moves currentMove;

    public static BattleScenePlayer instance;
    void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();
        material = GetComponent<Image>().material;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            
     }
        if (Input.GetKeyDown(KeyCode.L))
        {
            
           

        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    public void DealDamage(Moves moves)
    {
        currentMove = moves;
        ChangeToHenry();
        Invoke("DealDamage", 2f);
       
    }

    public void DealDamage()
    {
        Invoke("ChangeToDorian", 2.1f);
        switch (currentMove)
        {

            case Moves.Cut:
                animator.SetTrigger("Cut");                             
                BattleSceneOpponent.instance.TakeDamage(20, () => {
                    SoundManager.instance.PlayMovesSource(SoundManager.instance.cutClip);
                    BattleSceneOpponent.instance.hud.ReduceSliderValue(20);
                });
                break;
            case Moves.Scratch:
                material.DOFloat(2f, "_ShakeUvSpeed", 0.5f).OnComplete(() => material.DOFloat(0, "_ShakeUvSpeed", 0.5f));
                BattleSceneOpponent.instance.TakeDamage(20, () => {
                    SoundManager.instance.PlayMovesSource(SoundManager.instance.scratchClip);
                    BattleSceneOpponent.instance.hud.ReduceSliderValue(20);
                });
                break;
            case Moves.Slash:
                animator.SetTrigger("Rage");
                BattleSceneOpponent.instance.TakeDamage(20, () => {
                    SoundManager.instance.PlayMovesSource(SoundManager.instance.slashClip);
                    BattleSceneOpponent.instance.hud.ReduceSliderValue(20);
                });
                break;
            case Moves.Rage:
               
                material.DOFloat(1, "_OutlineAlpha", 1.5f).OnComplete(()=> material.DOFloat(0, "_OutlineAlpha", 0.5f));
                
                BattleSceneOpponent.instance.TakeDamage(20, () => {
                    SoundManager.instance.PlayMovesSource(SoundManager.instance.rageClip);
                    BattleSceneOpponent.instance.hud.ReduceSliderValue(20);
                });

                break;
        }
    }

    public void AttackTurn()
    {
        dialougeSystem.ShowText(Dialouges.instance.chooseAnAttack,true,()=> { movesPanel.gameObject.SetActive(true); });
    }

    public void ChangeToHenry()
    {
        
        material.EnableKeyword("DISTORT_ON");
        image.DOFade(0, 1f).OnComplete(() =>
        {
            animator.SetTrigger("Henry");
            image.DOFade(1, 1f);
            material.DisableKeyword("DISTORT_ON");
           
        }
        );
        
    }

    public void ChangeToDorian()
    {
       
        material.EnableKeyword("DISTORT_ON");
        image.DOFade(0, 1f).OnComplete(() =>
        {
            animator.SetTrigger("Dorian");
            image.DOFade(1, 1f);
            material.DisableKeyword("DISTORT_ON");
        }
        );
    }
}
