using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerControl : MonoBehaviour {

    // public game objects for interacting with 
    public GameObject OpenBook;
    public GameObject ClosedBook; 

    private bool bookStatus;

    // Controller and Collider object reference 
    private SteamVR_TrackedObject trackedObj;
    private GameObject collidingObject;
    
    // Use this for initialization
    void Awake () {
        bookStatus = true;

        trackedObj = GetComponent<SteamVR_TrackedObject>();

        toggleBook(); 
	}

    // Not sure what this does but whatever. 
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    // Managing Collisions and triggers
    private void SetCollidingObject(Collider col)
    {
        // 1
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        // 2
        collidingObject = col.gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("HELLOHELLOHELLOHELLOHELLO");
        SetCollidingObject(other);
    }

    // 2
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    // 3
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    // Book Functions 
    void toggleBook()
    {
        bookStatus = !bookStatus; 
        OpenBook.SetActive(bookStatus);
        ClosedBook.SetActive(!bookStatus);
    }

    bool isBook(GameObject go )
    {
        if (GameObject.ReferenceEquals(go, OpenBook) || GameObject.ReferenceEquals(go, ClosedBook))
        {
            Debug.Log("It is a book!!!");
            return true;
        } else
        {
            Debug.Log("It is NOT A BOOK");
            return false; 
        }
            
    }
	
	// Update is called once per frame
	void Update () {
        if (Controller.GetHairTriggerDown())
        {
            if (collidingObject)
            {
                if (isBook(collidingObject))
                {
                    toggleBook(); 
                }
            }
        }
    }
}
