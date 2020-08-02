using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log(other.gameObject.name + "collided with enemey");
        
    }

    private void OnTriggerEnter(Collider other) {
        //Debug.Log(other.gameObject.name + "triggered enemy");
    }
}
