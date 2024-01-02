using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TotemPoleController : MonoBehaviour
{
    [SerializeField] private GameObject[] totemParts;
    [SerializeField] private GameObject door1;
    [SerializeField] private bool isSameRotation;
    #region Create Event
    public delegate void EndRotationEventHandler();
    public event EndRotationEventHandler OnEndRotationEvent;
    #endregion

    private void Start()
    {
        OnEndRotationEvent += () => { };
    }
    private void Update()
    {
        if (OnEndRotationEvent != null)
        {
            isSameRotation = CheckArray();
            if (isSameRotation)
            {
                door1.SetActive(false);Debug.Log("same rotation");

            }
        }
    }

    public void SubscribeToEndRotationEvent(EndRotationEventHandler handler)
    {
        OnEndRotationEvent += handler;
    }

    public void UnsubscribeFromEndRotationEvent()
    {
        OnEndRotationEvent = null;
    }
    public void InvokeEndRotationEvent()
    {
        OnEndRotationEvent?.Invoke();
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
