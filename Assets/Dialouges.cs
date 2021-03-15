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
    public List<string> battleDialouges;

    [Header("Common")]
    public string chooseAnAttack = "Choose an Attack";

    public static Dialouges instance;

    public void Awake()
    {
        instance = this;
    }
}
