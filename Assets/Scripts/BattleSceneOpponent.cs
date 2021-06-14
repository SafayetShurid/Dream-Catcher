using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class BattleSceneOpponent : MonoBehaviour
{
    public enum AttackPhase
    {
        Phase1, Phase2, Phase3, Phase4, Phase5, Phase6, Phase7, Phase8
    }

    public Hud hud;
    public int health;
    public AttackPhase currentPhase;
    public DialougeSystem dialougeSystem;

    [SerializeField]
    private AudioSource backgroundAudioSource;
    [SerializeField]
    private Transform tacklePosition;

    public static BattleSceneOpponent instance;

    private Material fatherMaterial;
    private GameObject fatherGameObject;
    private Material motherMaterial;
    private GameObject motherGameObject;

    void Start()
    {
        instance = this;
        fatherGameObject = transform.GetChild(1).gameObject;
        motherGameObject = transform.GetChild(0).gameObject;
        fatherMaterial = transform.GetChild(1).GetComponent<Image>().material;
        motherMaterial = transform.GetChild(0).GetComponent<Image>().material;
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage, Action afterDamageTaken)
    {
        health -= damage;
        //material.EnableKeyword("SHAKEUV_ON");
        // material.DOFloat(1.75f, "_ShakeUvSpeed", 1.5f).OnComplete(() => material.DOFloat(0, "_ShakeUvSpeed", 0.0f));
        afterDamageTaken();
        AttackTurn(currentPhase);

    }



    private void FinalTurn()
    {
        SceneTransition.instance.gameObject.SetActive(true);
        SceneTransition.instance.FadeToBlack();
        backgroundAudioSource.DOFade(0, 2f);
    }

    public void AttackTurn(AttackPhase attackPhase)
    {
        StartCoroutine(AttackTurnRoutine(attackPhase));
    }


    IEnumerator AttackTurnRoutine(AttackPhase attackPhase)
    {
        yield return new WaitForSeconds(2f);

        switch (attackPhase)
        {
            case AttackPhase.Phase1:


                dialougeSystem.ShowText(Dialouges.instance.attackPhase1Dialouges, false, () =>
                {
                    BattleScenePlayer.instance.AttackTurn();
                    currentPhase++;
                });
                yield return new WaitForSeconds(4f);
                fatherMaterial.DOFloat(1f, "_ShakeUvSpeed", 0.5f).OnComplete(() => fatherMaterial.DOFloat(0, "_ShakeUvSpeed", 0.5f));
                SoundManager.instance.PlayOtherSource(SoundManager.instance.notEffectiveClip);

                break;
            case AttackPhase.Phase2:

                // SoundManager.instance.PlayOtherSource(SoundManager.instance.notEffectiveClip, 4f);
                dialougeSystem.ShowText(Dialouges.instance.attackPhase2Dialouges, false, () =>
                {

                    BattleScenePlayer.instance.AttackTurn();

                    currentPhase++;
                });
                yield return new WaitForSeconds(2f);

                Tween t = fatherGameObject.transform.DOLocalMove(tacklePosition.localPosition, 1f);
                t.OnComplete(() => t.Rewind());
                SoundManager.instance.PlayOtherSource(SoundManager.instance.notEffectiveClip);
                break;
            case AttackPhase.Phase3:


                dialougeSystem.ShowText(Dialouges.instance.attackPhase3Dialouges, false, () =>
                {

                    BattleScenePlayer.instance.AttackTurn();

                    currentPhase++;
                });
                yield return new WaitForSeconds(2f);
                fatherMaterial.DOFloat(1f, "_FadeAmount", 4f);
                yield return new WaitForSeconds(5f);
                motherMaterial.EnableKeyword("GHOST_ON");
                motherMaterial.DOFloat(1f, "_GhostTransparency", 4f);
                yield return new WaitForSeconds(4f);
                motherMaterial.DisableKeyword("GHOST_ON");
                SoundManager.instance.PlayOtherSource(SoundManager.instance.notEffectiveClip);
                break;
            case AttackPhase.Phase4:


                dialougeSystem.ShowText(Dialouges.instance.attackPhase4Dialouges, false, () =>
                {

                    BattleScenePlayer.instance.AttackTurn();

                    currentPhase++;
                });
                yield return new WaitForSeconds(2f);
                motherMaterial.DOFloat(0.5f, "_ShakeUvSpeed", 2f).OnComplete(() => motherMaterial.DOFloat(0f, "_ShakeUvSpeed",0.1f));
                SoundManager.instance.PlayOtherSource(SoundManager.instance.notEffectiveClip);
                break;
            case AttackPhase.Phase5:

                dialougeSystem.ShowText(Dialouges.instance.attackPhase5Dialouges, false, () =>
                {

                    BattleScenePlayer.instance.AttackTurn();

                    currentPhase++;
                });

                yield return new WaitForSeconds(2f);
                motherMaterial.DOFloat(0.5f, "_ShakeUvSpeed", 2f).OnComplete(() => motherMaterial.DOFloat(0f, "_ShakeUvSpeed", 0.1f));
                SoundManager.instance.PlayOtherSource(SoundManager.instance.notEffectiveClip);

                break;
            case AttackPhase.Phase6:

                dialougeSystem.ShowText(Dialouges.instance.attackPhase6Dialouges, false, () =>
                {
                    BattleScenePlayer.instance.AttackTurn();
                    currentPhase++;
                });
                yield return new WaitForSeconds(2f);
                motherMaterial.DOFloat(1f, "_InnerOutlineAlpha", 4f).OnComplete(() => motherMaterial.DOFloat(0f, "_InnerOutlineAlpha", 1f));
                motherMaterial.DOFloat(100f, "_OutlineGlow", 4f).OnComplete(() => motherMaterial.DOFloat(0f, "_OutlineGlow", 1f));
               
                BattleScenePlayer.instance.hud.slider.DOValue(20f,2f);
                yield return new WaitForSeconds(2f);
                SoundManager.instance.PlayOtherSource(SoundManager.instance.superEffectiveClip);
                
               
               
                break;
            case AttackPhase.Phase7:
                dialougeSystem.ShowText(Dialouges.instance.attackPhase7Dialouges, false, () =>
                {

                });
                yield return new WaitForSeconds(2f);
                FinalTurn();
                break;
        }
    }

    public void DealDamage()
    {

    }
}
