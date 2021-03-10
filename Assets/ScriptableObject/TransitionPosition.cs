using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class TransitionPosition : ScriptableObject,ISerializationCallbackReceiver
{

    public Vector2 initialValue;
    public Vector2 defaultValue;

    public void OnAfterDeserialize()
    {
        initialValue = defaultValue;
    }

    public void OnBeforeSerialize()
    {
       
    }

    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
