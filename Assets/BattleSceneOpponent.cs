using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneOpponent : MonoBehaviour
{
    public Hud hud;
    public int health;
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

    public void TakeDamage(int damage,Action afterDamageTaken)
    {
        health -= damage;
        afterDamageTaken();
    }
}
