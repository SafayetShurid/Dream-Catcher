using UnityEngine;
using UnityEngine.EventSystems;

// If there is no selected item, set the selected item to the event system's first selected item
public class ControllerRefocus : MonoBehaviour
{
    
    public GameObject lastselect;
    public EventSystem eventSystem;

    void Start()
    {
        // lastselect = new GameObject();
        // Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
       
    }

  

    // Update is called once per frame
    void Update()
    {

       if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {

        }

        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastselect);
        }
        else
        {
            lastselect = EventSystem.current.currentSelectedGameObject;
        }
    }

}