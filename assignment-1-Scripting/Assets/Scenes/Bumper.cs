using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{

    [SerializeField] private float _forceMultiplier = 25;
    [SerializeField] private Color _litColor;
    [SerializeField] private float _litUpTime = 0.5f;
    
    private SpriteRenderer _spriteRenderer;
    private Color _originalColor;

    private void Awake()
    {
         _spriteRenderer = GetComponent<SpriteRenderer>();
         _originalColor =  _spriteRenderer.color;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.rigidbody == null) return;
        
        bool validTag = false;


        if (!collision.gameObject.CompareTag("Ball")) return;
        

        #region adding force
        // Step 1: Get the normal of the first contact point
        Vector2 normal = Vector2.zero;
        if (collision.contactCount > 0)
        {
            ContactPoint2D contact = collision.GetContact(0);
            normal = contact.normal;  // points *outward* from the bumper surface
        }
        // Step 2: If for some reason we didn't get a contact normal, fall back
        if (normal == Vector2.zero)
        {
            Vector2 direction = (collision.rigidbody.position - (Vector2)transform.position).normalized;
            normal = direction;
        }
        // Step 3: Calculate an impulse along the normal
        Vector2 impulse = normal * _forceMultiplier;
        Debug.Log($"Impluse: {impulse}");
        // Step 4: Apply as an instantaneous force (ignores mass scaling)
        collision.rigidbody.AddForce(impulse, ForceMode2D.Impulse); 
        #endregion


        StartCoroutine(LightUp());

    }

    private IEnumerator LightUp()
    {
        SetColor(_litColor);
        
        yield return new WaitForSeconds(1f);
        
        SetColor(_originalColor);
    }
    
    void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }
}

