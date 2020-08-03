using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    [SerializeField] int scorePerHit = 12;
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform enemyExpParent;

    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
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
        scoreBoard.ScoreHit(scorePerHit);
    }
}
