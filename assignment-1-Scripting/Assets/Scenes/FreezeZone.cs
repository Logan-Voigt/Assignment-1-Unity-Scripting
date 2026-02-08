using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FreezeZone : MonoBehaviour
{
    [SerializeField] private Color _frozenColor = Color.lightSkyBlue;
    [SerializeField] private float _frozenTime = 2.5f;
    [SerializeField] private float _freezeDelay = 0.25f;
    
    private SpriteRenderer _spriteRenderer;
    private Color _originalColor;

    private void Start()
    {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Rigidbody2D BallRogodBody2D = other.gameObject.GetComponent<Rigidbody2D>();

            StartCoroutine(freeze(BallRogodBody2D));
        }
    }

    private IEnumerator freeze(Rigidbody2D BallRogodBody2D)
    {
        yield return new WaitForSeconds(_freezeDelay);
        
        _spriteRenderer.color = _frozenColor;
        
        
        float defaultGravity = BallRogodBody2D.gravityScale;
        
        BallRogodBody2D.linearVelocity = Vector2.zero;
        BallRogodBody2D.gravityScale = 0;

        yield return new WaitForSeconds(_frozenTime);
        
        _spriteRenderer.color = _originalColor;
        BallRogodBody2D.gravityScale = defaultGravity;
        

    }
    
    
}
