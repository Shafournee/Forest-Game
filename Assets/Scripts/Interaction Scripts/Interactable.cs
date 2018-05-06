using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Interactable : MonoBehaviour {

    //Text used for writing to screen
    [SerializeField] string text;

    //GameObjects
    private GameObject canvas;
    private GameObject player;

    //Dialogue text on the screen
    private GameObject dialogue;

    // Use this for initialization
    public virtual void Start () {
        canvas = GameObject.FindGameObjectWithTag("Canvas");

        //Find the dialogue box
        dialogue = canvas.transform.Find("Dialogue").gameObject;

        //Find the Player
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Draw the text of the object onto the screen
    public virtual void Interact()
    {
        DrawTextOnScreen();
        PlayerInteractableMovement();
    }

    void DrawTextOnScreen()
    {
        dialogue.GetComponent<Text>().text = text;
    }

    //Make the player move to the interactable
    void PlayerInteractableMovement()
    {
        StartCoroutine(player.GetComponent<Player>().MoveToInteractable(transform));
    }
}
