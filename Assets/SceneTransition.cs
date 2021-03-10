using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;
    [SerializeField]
    private Vector2 playerPosition;
    [SerializeField]
    private TransitionPosition transitionPosition;

    //public GameObject sceneTransition;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TransitionFinished()
    {
        this.gameObject.SetActive(false);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transitionPosition.initialValue = playerPosition;
        //sceneTransition.SetActive(true);       
        LoadScene();
    }
}
