using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Henry : MonoBehaviour
{
    public GameObject watch;
    public GameObject cake;
    public Material material;
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToHenry()
    {

        material.EnableKeyword("ROUNDWAVEUV_ON");
        material.DOFloat(0, "_RoundWaveStrength", 2f);
        Debug.Log("Singal Received");       

    }

    public void ChangToDorian()
    {
        material.EnableKeyword("ROUNDWAVEUV_ON");
        material.DOFloat(1, "_RoundWaveStrength", 2f).OnComplete(() =>
        {
            material.DisableKeyword("ROUNDWAVEUV_ON");
           // GetComponent<SpriteRenderer>().enabled = false;
        });
        
    }

    public void ChangeWatchPosition()
    {
        Vector3 pos = new Vector3(2.63f,13.73f,0);
        watch.transform.localPosition = pos;
    }


    public void ChangeCakePosition()
    {
       
        Vector3 pos = new Vector3(-0.67f, -0.92f, 0);
      
        cake.transform.localPosition = pos;
        cake.transform.parent = null;
    }

    public void ChangePosition()
    {
        Vector3 pos = new Vector3(4.83f,14.24f);
        this.transform.position = pos;
    }
}
