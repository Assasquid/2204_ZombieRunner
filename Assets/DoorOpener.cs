using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] float upDistance = 2.5f; 
    [SerializeField] float speed = 2.0f;
    [SerializeField] float timeOpened = 2.0f;

    bool moving = false;
    bool opening = true;
    Vector3 endPos;
    Vector3 startPos;
    float delay = 0.0f;

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + new Vector3(0, upDistance, 0);
    }

    void Update()
    {
        if(moving)
        {
            if(opening)
            {
                MoveDoor(endPos);
            }

            else
            {
                MoveDoor(startPos);
            }
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            moving = true;
        }    
    }

    void MoveDoor(Vector3 goalPos)
    {
        float distance = Vector3.Distance(transform.position, goalPos);
        if(distance > .1f)
        {
            transform.position = Vector3.Lerp(transform.position, goalPos, speed * Time.deltaTime);
        }
        
        else
        {
            if(opening)
            {
                delay += Time.deltaTime;
                if(delay > timeOpened)
                {
                    opening = false;
                }
            }

            else
            {
                moving = false;
                opening = true;
            }
        }
    }
}
