using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using Valve.VR;

namespace Valve.VR.InteractionSystem
{ 

    public class BookInteract : MonoBehaviour {

        public Hand hand1;
        public Hand hand2;

        public GameObject closedBook;
        public GameObject openBook;

        private bool bookStatus; 

        // Use this for initialization
        void Start() {
            bookStatus = true;
            toggleBook(); 
        }

        public void OnTriggerStay(Collider other)
        {
            if (GameObject.ReferenceEquals(hand1.gameObject, other.gameObject))
            {
                Debug.Log("Hello hand1!");
                if (hand1.controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
                {
                    toggleBook(); 
                }
            }

            if (GameObject.ReferenceEquals(hand2.gameObject, other.gameObject))
            {
                Debug.Log("Hello hand2!");
                if (hand2.controller.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
                {
                    toggleBook();
                }
            }
        }

        // Update is called once per frame
        void Update() {

        }

        private void toggleBook()
        {
            bookStatus = !bookStatus;
            openBook.SetActive(bookStatus);
            closedBook.SetActive(!bookStatus);
        }

    }

}