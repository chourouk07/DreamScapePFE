using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemPoleController : MonoBehaviour
{
    [SerializeField] private GameObject[] totemParts;
    [SerializeField] private GameObject door1;
    [SerializeField] private bool isSameRotation;

    private void Update()
    {
        isSameRotation = CheckArray();
        if (isSameRotation)
        {
            Debug.Log("Correct Match");
            door1.SetActive(false);
        }
    }

    bool CheckArray()
    {

        Quaternion rotation01 = totemParts[0].transform.rotation;
        float yRotation01 = rotation01.eulerAngles.y;
        yRotation01 = Mathf.Round(yRotation01);
        for (int i = 1; i < totemParts.Length; i++)
        {
            Quaternion rotation = totemParts[i].transform.rotation;

            float yRotation = rotation.eulerAngles.y;
            yRotation = Mathf.Round(yRotation);

            if (yRotation != yRotation01)
            {
                return false;
            }

        }
        return true;
    }
}
