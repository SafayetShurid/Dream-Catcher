using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
    Player,NPC
}

public class Character : MonoBehaviour
{

    public CharacterType characterType;
    public string characterName;   
    [SerializeField]
    protected List<string> dialouges;
    public Sprite characterFaceSprite;
   

    public List<string> GetDialouges()
    {
        return dialouges;
    }

    public virtual void SayDialouge()
    {
       
    }

    public virtual void SayDialouge(int lineNumber)
    {

    }

    public virtual void SayDialouge(int from,int to)
    {

    }

    public virtual void SetupDialougeSystemHud()
    {
        DialougeSystem.instance.image.sprite = characterFaceSprite;
        DialougeSystem.instance.characterNameText.text = characterName;
    }
}
