using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialouges : MonoBehaviour
{
    [TextArea]
    [Header("Basil")]
    public List<string> basilDialouges;

    public static Dialouges instance;

    public void Awake()
    {
        instance = this;
    }
}
