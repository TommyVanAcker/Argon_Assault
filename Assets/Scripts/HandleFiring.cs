using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleFiring : MonoBehaviour
{
    [SerializeField] GameObject[] bullets;
    [SerializeField] float damagePerHit;
    bool isControlEnabled = true;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessFiring();
        } else
        {
            Fire(false);
        }
        
    }

    private void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            Fire(true);
        }
        else
        {
            Fire(false);

        }
    }

    private void Fire(bool fire)
    {
        foreach (GameObject bullet in bullets)
        {
            var bulletModule = bullet.GetComponent<ParticleSystem>().emission;
            bulletModule.enabled = fire;
        }
    }

    void OnPlayerDeath()
    {
        isControlEnabled = false;
    }

    public float ReceiveDamage()
    {
        return damagePerHit;
    }
}
