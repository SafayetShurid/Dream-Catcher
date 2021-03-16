using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Slider slider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            ReduceSliderValue(20);
        }
    }

    public void ReduceSliderValue(float amount)
    {
        StartCoroutine(ReduceSliderValueRoutine(amount));
    }

    IEnumerator ReduceSliderValueRoutine(float amount)
    {
        float target = slider.value - amount;
        while(slider.value<=target)
        {
            yield return new WaitForSeconds(0.05f);
            slider.value -= 0.5f;
        }
    }
}
