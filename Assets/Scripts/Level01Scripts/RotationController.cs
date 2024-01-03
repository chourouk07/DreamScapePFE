using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotationController : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private TotemPoleController totemPoleController;
    #region rotation variables
    [SerializeField] private GameObject[] objectsToRotate;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private int targetRotation = 0;
    [SerializeField] private float totalRotation;
    [SerializeField] private bool isMoving=false;
    #endregion
    #region Create Event
    public delegate void EndRotationEventHandler(object source, EventArgs args);
    public event EndRotationEventHandler EndRotationEvent;
    #endregion
    string IInteractable.InteractionPrompt => _prompt;

    bool IInteractable.Interact(Interactor interactor)
    {
        Debug.Log(_prompt);
        isMoving= true;
        totemPoleController.SetCurrentRotationController(this);
        return true;
    }

    private void Update()
    {
        if (isMoving)
        {
            RotateObjects();
        }
    }

    void RotateObjects()
    {
        if (totalRotation <= targetRotation)
        {
            foreach (GameObject obj in objectsToRotate)
            {
                obj.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
                totalRotation += rotationSpeed * Time.deltaTime;
            }
        }
        else
        {
            isMoving = false;
            totalRotation = 0;
            OnEndRotationEvent();
        }
    }

    void OnEndRotationEvent()
    {
        if (EndRotationEvent != null)
        {
            EndRotationEvent.Invoke(this, EventArgs.Empty);
        }
    }
}

