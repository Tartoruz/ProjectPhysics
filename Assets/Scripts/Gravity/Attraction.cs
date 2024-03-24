using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attraction : MonoBehaviour
{
    [SerializeField] public float attractionForce = 10f;
    [SerializeField] public float attractionRange = 5f;

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attractionRange);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                Rigidbody playerRigidbody = collider.GetComponent<Rigidbody>();
                if (playerRigidbody != null)
                {
                    Vector3 direction = transform.position - collider.transform.position;
                    float distance = direction.magnitude;

                    if (distance > 0)
                    {
                        float attractionStrength = attractionForce * 1000 / distance;
                        Vector3 attraction = direction.normalized * attractionStrength;

                        playerRigidbody.AddForce(attraction);
                    }
                }
            }
        }
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync(2);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attractionRange);
    }
    
}
