using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionBox : MonoBehaviour {

    KeyCode interationKey = KeyCode.Z;

    GameObject nearbyInteractable;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Interact();
	}

    //HANDLES DETECTION OF INTERACTABLE OBJECTS

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.GetComponent<Interactable>() != null)
        {
            nearbyInteractable = collider.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<Interactable>() != null)
        {
            nearbyInteractable = null;
        }
    }

    private void Interact()
    {
        if(Input.GetKey(interationKey) && nearbyInteractable != null)
        {
            nearbyInteractable.GetComponent<Interactable>().Interact();
        }
    }
}
