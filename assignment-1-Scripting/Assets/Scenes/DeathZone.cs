using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DeathZone : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPoint;
    void OnTriggerEnter2D(Collider2D collider)
    {   
        GameObject ball =  collider.gameObject;
        
        if (ball.CompareTag("Ball"))
        {
            // Wait 2 seconds and respawn ball.
            const float respawnTimer = 2;
            StartCoroutine(RespawnBall(ball, respawnTimer));
        }
    }

    private IEnumerator RespawnBall(GameObject ball, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        
        ball.transform.position = _spawnPoint.transform.position;
        Rigidbody2D rigidBodyBall = ball.GetComponent<Rigidbody2D>();
        rigidBodyBall.linearVelocity = Vector2.zero;
    }
}

