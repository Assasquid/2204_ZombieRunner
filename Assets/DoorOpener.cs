using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] float doorMovementSpeed = 1f;
    [SerializeField] float doorMovementDuration = 1f;
    [SerializeField] float doorWaitingTime = 3f;
    //[SerializeField] float doorCoefficient = 0.2f;
    
    //Rigidbody rb;

    bool isOpened;
    bool isOpening;
    bool isClosing;
    bool isClosed;

    void Start()
    {
        isOpened = false;
        isOpening = false;
        isClosing = false;

        //rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {  
        if(other.tag == "Player" && isOpened == false)
        {
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        isOpening = true;
        Debug.Log("Door opening");

        yield return new WaitForSeconds(doorMovementDuration);
        
        Debug.Log("Door opened");
        isOpened = true;
        isOpening = false;

        StartCoroutine(WaitToClose());
    }

    IEnumerator WaitToClose()
    {
        Debug.Log("Start waiting");
        yield return new WaitForSeconds(doorWaitingTime);
        Debug.Log("Done waiting");
        
        StartCoroutine(CloseDoor());
    }

    IEnumerator CloseDoor()
    {
        isClosing = true;
        Debug.Log("Door closing");

        yield return new WaitForSeconds(doorMovementDuration);

        Debug.Log("Door closed");
        isOpened = false;
        isClosing = false;
    }

    void FixedUpdate()
    {
        if(isOpening == true)
        {
            //rb.MovePosition(transform.position + Vector3.up * doorCoefficient * doorMovementSpeed * Time.fixedTime);
            transform.Translate(0, Time.fixedTime * doorMovementSpeed, 0);
        }

        if(isClosing == true)
        {
            //rb.MovePosition(transform.position + Vector3.down * doorCoefficient * doorMovementSpeed * Time.fixedTime);
            transform.Translate(0, -Time.fixedTime * doorMovementSpeed, 0);
        }
    }
}
