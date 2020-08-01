using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("General Settings")]
    [Tooltip("in ms^-1")]
    [SerializeField] float xSpeed = 20f;
    [Tooltip("in m")]
    [SerializeField] float XminScreenPos = -10f;
    [Tooltip("in m")]
    [SerializeField] float XmaxScreenPos = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float xOffsetThisFrame = xThrow * xSpeed * Time.deltaTime;
        float rawNewLocalXPosition = transform.localPosition.x + xOffsetThisFrame;
        float clampedXPos = Mathf.Clamp(rawNewLocalXPosition, XminScreenPos, XmaxScreenPos);
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z); 
        
    }
}
