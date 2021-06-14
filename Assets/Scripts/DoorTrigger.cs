using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DoorTrigger : MonoBehaviour
{
    public Player player;
    public TransitionPosition transitionPosition;
   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            SceneTransition.instance.FadeToWhite();
            Camera.main.transform.position = transitionPosition.cameraPosition;
            player.gameObject.transform.position = transitionPosition.playerPosition;
            if (transitionPosition.roomName == "Room2")
            {
                Invoke("ActiveTimeline", 0.1f);
            }
        }

        
      
    }

    private void ActiveTimeline()
    {
        TimelineActivator.instance.ActivateTimeLine(TimeLine.timeline2);
    }

}
