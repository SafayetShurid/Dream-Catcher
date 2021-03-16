using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialouges : MonoBehaviour
{
    [TextArea]
    [Header("Basil")]
    public List<string> basilDialouges;

    [Header("Battle Scene")]   
    [TextArea]
    public List<string> battleStartingDialouges;

    [Header("Common")]
    public string chooseAnAttack = "Choose an Attack";
    public string henryUsed = "Henry Used";
    public string itsNotveryEffective = "It's not very effective........";
    public string itsSuperEffective = "It's super effective........";

    public static Dialouges instance;

    private void Awake()
    {
        instance = this;
    }

}
