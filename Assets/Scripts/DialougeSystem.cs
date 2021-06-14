using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeSystem : MonoBehaviour
{
    public enum DialougeShowType
    {
        auto, manual
    }

    [TextArea]
    public List<string> lines;
    public Text dialougeText;
    public Image image;
    public Text characterNameText;
    public DialougeShowType dialougeShowType;
    private bool dialougeStarts;

    
    private int currentLineIndex = 0;
    private bool previousLineFinished = true;
    private bool fullTextShown;


    public static DialougeSystem instance;

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(dialougeShowType.Equals(DialougeShowType.auto) && dialougeStarts)
        {
            if (!fullTextShown)
            {
                if (previousLineFinished)
                    showText();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z) && !fullTextShown)
            {
                if (previousLineFinished)
                    showText();
            }
        }*/

    }

    public void showText()
    {
        dialougeText.text = string.Empty;
        previousLineFinished = false;
        StartCoroutine(showTextRoutine(currentLineIndex));
    }

    IEnumerator showTextRoutine(int index)
    {

        char[] letters = lines[index].ToCharArray();
        foreach (char c in letters)
        {
            dialougeText.text += c;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1.5f);
        currentLineIndex++;
        previousLineFinished = true;

        if (currentLineIndex >= lines.Count)
        {
            currentLineIndex = 0;
            fullTextShown = true;
            dialougeText.text = string.Empty;
            this.gameObject.SetActive(false);
        }


    }

    public void AddText(List<string> texts)
    {
        lines.AddRange(texts);
    }

    public void SetDialougeShowType(DialougeShowType _dialougeShowType)
    {
        dialougeShowType = _dialougeShowType;
        dialougeStarts = true;
    }

    public void ShowText(string textToShow,bool textStaysInHud, Action afterTextShown)
    {
        StartCoroutine(ShowTextRoutine(new List<string>() {textToShow},textStaysInHud,afterTextShown));
    }

    public void ShowText(List<string> textToShow, bool textStaysInHud,Action afterTextShown)
    {
        StartCoroutine(ShowTextRoutine(textToShow, textStaysInHud, afterTextShown));
    }  

    IEnumerator ShowTextRoutine(List<string> textToShow,bool textStaysInHud,Action afterTextShown)
    {
        int index = 0;
        dialougeText.text = string.Empty;
        while (index<textToShow.Count)
        {
            char[] letters = textToShow[index].ToCharArray();
            foreach (char c in letters)
            {
                dialougeText.text += c;
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(1.5f);
            dialougeText.text = textStaysInHud!=true ? string.Empty : dialougeText.text ;
            index++;

        }
        afterTextShown();
       
        // this.gameObject.SetActive(false);

    }
}
