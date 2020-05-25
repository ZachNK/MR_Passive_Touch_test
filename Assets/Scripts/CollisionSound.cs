using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public float second;

    private void OnCollisionEnter(Collision collision)
    {
        FindObjectOfType<Movement>().Vibe(second);
        GetComponentInChildren<AudioSource>().Play();
    }
}