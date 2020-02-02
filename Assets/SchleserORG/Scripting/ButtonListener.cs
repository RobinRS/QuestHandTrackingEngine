using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using UnityEngine.Events;

public class ButtonListener : MonoBehaviour
{
    public UnityEvent proximityEvent;
    public UnityEvent contactEvent;
    public UnityEvent actionEvent;
    public UnityEvent defaultEvent;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ButtonController>().InteractableStateChanged.AddListener(initEvent);  
    }

    void initEvent(InteractableStateArgs args)
    {
        if (args.NewInteractableState == InteractableState.ProximityState)
            proximityEvent.Invoke();
        else if (args.NewInteractableState == InteractableState.ContactState)
            contactEvent.Invoke();
        else if (args.NewInteractableState == InteractableState.ActionState)
            actionEvent.Invoke();
        else
            defaultEvent.Invoke();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
