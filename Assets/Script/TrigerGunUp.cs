using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerGunUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Debug.Log("Play");
    }

}
