using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSceneOpponent : MonoBehaviour
{
    public enum AttackPhase
    {
        Phase1, Phase2,Phase3, Phase4, Phase5, Phase6, Phase7, Phase8
    }

    public Hud hud;
    public int health;
    public AttackPhase currentPhase;
    public DialougeSystem dialougeSystem;

    public static BattleSceneOpponent instance;

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage, Action afterDamageTaken)
    {
        health -= damage;
        afterDamageTaken();
        AttackTurn(currentPhase);
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
                break;
            case AttackPhase.Phase2:
                dialougeSystem.ShowText(Dialouges.instance.attackPhase2Dialouges, false, () =>
                {
                    BattleScenePlayer.instance.AttackTurn();
                    currentPhase++;
                });
                break;
            case AttackPhase.Phase3:
                dialougeSystem.ShowText(Dialouges.instance.attackPhase3Dialouges, false, () =>
                {
                    BattleScenePlayer.instance.AttackTurn();
                    currentPhase++;
                });
                break;
            case AttackPhase.Phase4:
                dialougeSystem.ShowText(Dialouges.instance.attackPhase4Dialouges, false, () =>
                {
                    BattleScenePlayer.instance.AttackTurn();
                    currentPhase++;
                });
                break;
            case AttackPhase.Phase5:
                dialougeSystem.ShowText(Dialouges.instance.attackPhase5Dialouges, false, () =>
                {
                    BattleScenePlayer.instance.AttackTurn();
                    currentPhase++;
                });
                break;
            case AttackPhase.Phase6:
                dialougeSystem.ShowText(Dialouges.instance.attackPhase6Dialouges, false, () =>
                {
                    BattleScenePlayer.instance.AttackTurn();
                    currentPhase++;
                });
                break;
           
        }
    }
}
