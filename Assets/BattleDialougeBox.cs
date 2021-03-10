using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialougeBox : MonoBehaviour
{
    public Text dialougeText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDiaolouge(string dialouge)
    {
        dialougeText.text = dialouge;
    }
}
