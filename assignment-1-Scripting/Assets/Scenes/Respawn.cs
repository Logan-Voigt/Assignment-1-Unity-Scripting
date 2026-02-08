using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform _leftBoarder;
    [SerializeField] private Transform _rightBoarder;
    [SerializeField] private float _speed;

    private bool _goingLeft = true;

    private Vector3 _position;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _position = gameObject.transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_position.x < _leftBoarder.position.x) _goingLeft = false;
        
        if (_position.x > _rightBoarder.position.x) _goingLeft = true;
        
        if (_goingLeft)
        {
            _position.x -= _speed * Time.deltaTime;
        } 
        else
        {
            _position.x += _speed * Time.deltaTime;
        }
        gameObject.transform.position = _position;
    }
}
