using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform enemyExpParent;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerCollider();
    }

    private void AddNonTriggerCollider()
    {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        Instantiate(deathFX, gameObject.transform.position, Quaternion.identity, enemyExpParent);
        Destroy(gameObject);
    }
}
