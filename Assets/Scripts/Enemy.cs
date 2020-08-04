using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] int scorePerHit = 12;
    [Range(10f, 500f)]
    [SerializeField] float healthPoints = 100f;
    [Header("References")]
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform enemyExpParent;

    ScoreBoard scoreBoard;
    HandleFiring handleFiring;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        handleFiring = FindObjectOfType<HandleFiring>();
    }

    private void AddNonTriggerCollider()
    {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (healthPoints <= Mathf.Epsilon)
        {
            KillEnemy();
        }

    }

    private void ProcessHit()
    {
        scoreBoard.ScoreHit(scorePerHit);
        healthPoints -= handleFiring.ReceiveDamage();
    }

    private void KillEnemy()
    {
        Instantiate(deathFX, gameObject.transform.position, Quaternion.identity, enemyExpParent);
        Destroy(gameObject);
    }
}
