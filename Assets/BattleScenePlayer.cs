using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Moves
{
    Cut,Scratch,Rage,Slash
}

public class BattleScenePlayer : MonoBehaviour
{

    public Hud hud;
    public int health;
    public DialougeSystem dialougeSystem;

    public static BattleScenePlayer instance;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    public void DealDamage(Moves moves)
    {
        switch(moves)
        {
            case Moves.Cut:
                BattleSceneOpponent.instance.TakeDamage(20,()=> { });
                break;
            case Moves.Scratch:
                BattleSceneOpponent.instance.TakeDamage(20, () => { });
                break;
            case Moves.Slash:
                BattleSceneOpponent.instance.TakeDamage(20, () => { });
                break;
            case Moves.Rage:
                BattleSceneOpponent.instance.TakeDamage(20, () => { });
                break;
        }
    }

    public void AttackTurn()
    {
        dialougeSystem.ShowText(Dialouges.instance.chooseAnAttack,true,()=> { });
    }
}
