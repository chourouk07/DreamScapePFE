using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TotemPoleController : MonoBehaviour
{
    [SerializeField] private GameObject[] totemParts;
    [SerializeField] private GameObject door1;
    [SerializeField] private bool isSameRotation;
    [SerializeField] private RotationController rotationController;
    [SerializeField] private bool _startChecking = false;

    public void SetCurrentRotationController(RotationController newRotationController)
    {
        // unsubscribe from the previous RotationController's event
        if (rotationController != null)
        {
            rotationController.EndRotationEvent -= OnEndRotationEvent;
        }

        // Set the new RotationController
        rotationController = newRotationController;

        // Subscribe to the new RotationController's event
        if (rotationController != null)
        {
            rotationController.EndRotationEvent += OnEndRotationEvent;
        }
    }

    void OnEndRotationEvent(object source, EventArgs e)
    {
        Debug.Log("End Rotation");
        _startChecking= true;
        if (CheckArray())
        {
            Debug.Log("Same Rotation");
            door1.SetActive(false);
            _startChecking= false;
            rotationController.EndRotationEvent -= OnEndRotationEvent;
            rotationController = null;

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
