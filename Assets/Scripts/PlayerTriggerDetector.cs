using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTriggerDetector : MonoBehaviour
{
    public Player player;

    public bool watchNearby;
    public bool fridgeNearby;
    public bool clawNearby;
    private bool watchScenePlayed;
    private bool cakeScenePlayed;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) )
        {
            if(watchNearby && !watchScenePlayed)
            {
                TimelineActivator.instance.ActivateTimeLine(TimeLine.timeline3);
                watchScenePlayed = true;
            }

            if (fridgeNearby && !cakeScenePlayed && watchScenePlayed)
            {
                TimelineActivator.instance.ActivateTimeLine(TimeLine.timeline4);
                cakeScenePlayed = true;
            }

            if(clawNearby)
            {
                GameObject.FindGameObjectWithTag("Claw").SetActive(false);
                Invoke("LoadScene", 1f);
            }

        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<NPC>() != null)
        {
            player.SetCurrentNPC(collision.gameObject.GetComponent<NPC>());
            Debug.Log("NPC Entered");
        }               

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<NPC>()==null)
        {
          
        }

        if (collision.gameObject.CompareTag("Watch"))
        {
            watchNearby = false;           
        }

        if (collision.gameObject.CompareTag("Fridge"))
        {
            fridgeNearby = false;
        }

        if (collision.gameObject.CompareTag("Claw"))
        {
            clawNearby = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<NPC>() == null)
        {
            player.SetCurrentNPC(null);
        }
        else
        {
            player.SetCurrentNPC(collision.gameObject.GetComponent<NPC>());
        }

        if (collision.gameObject.CompareTag("Watch"))
        {
            watchNearby = true;           
        }

        if (collision.gameObject.CompareTag("Fridge"))
        {
            fridgeNearby = true;
        }
        if (collision.gameObject.CompareTag("Claw"))
        {
            clawNearby = true;
        }

    }
}
