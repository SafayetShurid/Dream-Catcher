using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeSystem : MonoBehaviour
{
    [TextArea]
    public List<string> lines;
    public Text text;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            showText();
        }
    }

    public void showText()
    {
        StartCoroutine(showTextRoutine(0));
    }

    IEnumerator showTextRoutine(int index)
    {

        char[] letters = lines[index].ToCharArray();
        foreach(char c in letters)
        {
            text.text += c;
            yield return new WaitForSeconds(0.05f);
        }
       


    }
}
