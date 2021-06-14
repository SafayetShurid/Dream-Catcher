using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI ;

[RequireComponent(typeof(Image))]
public class SceneTransition : MonoBehaviour
{

    public static SceneTransition instance;

    private Image image;

    private void Awake()
    {
        instance = this;        
    }

    private void Start()
    {
        image = GetComponent<Image>();
        //FadeToWhite();
    }

    public void FadeToBlack()
    {
        
        image.DOFade(1, 2f);
    }

    public void FadeToWhite()
    {
        var tempColor = image.color;
        tempColor.a = 1f;
        image.color = tempColor;
        image.DOFade(0, 3f);
    }


}
