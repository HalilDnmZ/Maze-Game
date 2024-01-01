using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;
using UnityEngine.Events;

public class CharacterDeath : MonoBehaviour
{
    [Header("Custom Event")]
    public UnityEvent myEvents;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(myEvents == null)
        {
            print("myEventTriggerOnEnter was triggered but myEvent was Null");
        }
        else
        {
            print("myEventTriggerOnEnter Activated. Triggering "+ myEvents);
            myEvents.Invoke();
        }
    }
}
