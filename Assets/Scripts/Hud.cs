using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Hud : MonoBehaviour
{
    public Slider slider;

    public RectTransform rectTransform;
    public float moveAmount;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        transform.DOLocalMoveY(transform.localPosition.y + 1f, 0.5f).SetLoops(1000, LoopType.Yoyo).SetEase(Ease.Linear);

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log(transform.localPosition.y);
        }

    }

    public void ReduceSliderValue(float amount)
    {
        StartCoroutine(ReduceSliderValueRoutine(amount));
    }

    IEnumerator ReduceSliderValueRoutine(float amount)
    {
        float target = slider.value - amount;
        while(slider.value>target)
        {
            yield return new WaitForSeconds(0.05f);
            slider.value -= 0.5f;
        }        
    }
}
