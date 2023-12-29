using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneChecker : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToDisable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i=0; i<objectsToDisable.Length; i++)
            {
                Destroy(objectsToDisable[i]);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
