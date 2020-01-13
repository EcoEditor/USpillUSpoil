using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("YOU WIN!");

    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            print("YOU WIN!");
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        
    }

}

