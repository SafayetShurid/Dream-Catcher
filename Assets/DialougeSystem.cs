﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeSystem : MonoBehaviour
{
    [TextArea]
    public List<string> lines;
    public Text text;

    private int currentLineIndex =0;
    private bool previousLineFinished =true;
    private bool fullTextShown;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && !fullTextShown)
        {
            if(previousLineFinished)
            showText();
        }
    }

    public void showText()
    {
        text.text = string.Empty;
        previousLineFinished = false;
        StartCoroutine(showTextRoutine(currentLineIndex));
    }

    IEnumerator showTextRoutine(int index)
    {

        char[] letters = lines[index].ToCharArray();
        foreach(char c in letters)
        {
            text.text += c;
            yield return new WaitForSeconds(0.05f);
        }

        currentLineIndex++;
        previousLineFinished = true;
       
        if (currentLineIndex>=lines.Count)
        {
            currentLineIndex = 0;
            fullTextShown = true;
            text.text = string.Empty;
        }


    }
}
