using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //message shown to player when looking at object
    public string promptMessage;

    public void BaseInteract()
    {
        Interact();
    }
    
    
    protected virtual void Interact()
    {
        //To be overwritten by subclasses
    }
    
    

}
