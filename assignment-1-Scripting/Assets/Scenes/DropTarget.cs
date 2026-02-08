using UnityEngine;

public class DropTarget : MonoBehaviour
{
    [SerializeField] private Color _dropColor;
    [SerializeField] private float _dropTime = 0.1f, _resetDelay = 2f;
        
    private Color _originalColor;
    private bool _isDown;
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isDown) return;
            
        if (!collision.collider.CompareTag("Ball")) return;
            
            
        _isDown = true;
        _spriteRenderer.color = _dropColor;
            
        Invoke(nameof(HideTarget), _dropTime);
    }

    private void HideTarget()
    {
        this.gameObject.SetActive(false);
        Invoke(nameof(ResetTarget), _resetDelay);
    }

    private void ResetTarget()
    {
        _spriteRenderer.color = _originalColor;
        this.gameObject.SetActive(true);
        _isDown = false;
    }
        
}
