using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PointMover : MonoBehaviour
{
    public float speed = 1f;
    private Vector3 _targetPosition;
    
    private void Start()
    {
        _targetPosition = transform.position;
    }
    
    public void MoveTo(Vector3 position)
    {
        _targetPosition = position;
    }
    
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);
    }
}
