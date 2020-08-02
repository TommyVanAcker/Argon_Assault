using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ok as long as only script

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("in seconds")][SerializeField] float levelLoadDelay = 3f;
    [Tooltip("Explosion gameObject")][SerializeField] GameObject deathFX;

    
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        Invoke("ReloadLevel",levelLoadDelay);
        
    }

    private void ReloadLevel()// string referenced
    {
        SceneManager.LoadScene(1);

    }
}
