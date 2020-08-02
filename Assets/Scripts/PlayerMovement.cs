using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("General Settings")]
    [Tooltip("in ms^-1")]
    [SerializeField] float speed = 20f;

    [Header("Screen Limits")]
    [Tooltip("in m")]
    [SerializeField] float xMinScreenPos = -10f;
    [Tooltip("in m")]
    [SerializeField] float xMaxScreenPos = 10f;
    [Tooltip("in m")]
    [SerializeField] float yMinScreenPos = -7f;
    [Tooltip("in m")]
    [SerializeField] float yMaxScreenPos = 8f;

    [Header("Player Play Area")]
    [SerializeField] float positionPitchFactor = -4f;
    [SerializeField] float controlPitchFactor = -16f;
    [SerializeField] float positionYawFactor = 4f;
    [SerializeField] float controlRollFactor = -15f;


    float xThrow, yThrow;
    bool isControlEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if(isControlEnabled){
            ProcessTranslation();
            ProcessRotation();
        }
        

    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = (transform.localPosition.y * positionPitchFactor);
        float pitchDueToControlThrow = (yThrow * controlPitchFactor);

        float pitch = pitchDueToPosition + pitchDueToControlThrow; 
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        Vector3 shipRotation = new Vector3(pitch, yaw, roll);
        transform.localRotation = Quaternion.Euler(shipRotation);

    }

    private void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffsetThisFrame = xThrow * speed * Time.deltaTime;
        float yOffsetThisFrame = yThrow * speed * Time.deltaTime;

        float rawlocalXPos = transform.localPosition.x + xOffsetThisFrame;
        float rawLocalYPos = transform.localPosition.y + yOffsetThisFrame;

        float clampedXPos = Mathf.Clamp(rawlocalXPos, xMinScreenPos, xMaxScreenPos);
        float clampedYPos = Mathf.Clamp(rawLocalYPos, yMinScreenPos, yMaxScreenPos);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
    void OnPlayerDeath() //Called by string reference
    {
        isControlEnabled = false;

    }

    
}
