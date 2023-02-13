using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMover : MonoBehaviour
{
    public Vector2[] points;
    [SerializeField] private float speed;
    [SerializeField] private float maxDistance;
    private int _targetIndex;
    private Quaternion _targetRotation;
    private int _direction;

    void Start()
    {
        _targetIndex = 0;
        _direction = 1;
    }

    private void FixedUpdate()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, _targetRotation, 0.15f);
    }

    void Update()
    {
        
        transform.localPosition = Vector3.MoveTowards(transform.localPosition,points[_targetIndex], Time.deltaTime * speed);
        if (Mathf.Abs(((Vector2)transform.localPosition - points[_targetIndex]).magnitude) <= maxDistance)
        {
            
            _targetIndex += _direction;
            
            if (_targetIndex == points.Length && _direction == 1)
            {
                
                _targetIndex = 1;
                transform.localPosition = points[0];
                RotateInstantly();
            }
            _targetRotation = transform.localRotation*RotateToPoint(points[_targetIndex]) ;
            /*if (_targetIndex == points.Length && _direction == 1)
            {
                _targetIndex = points.Length - 2;
                _direction = -1;
            }
            else if(_targetIndex == 0 && _direction == -1)
            {
                _targetIndex = 1;
                _direction = 1;
            }*/
        }
        
    }

    public void SetPath(List<Vector2> path)
    {
        points = path.ToArray();
    }

    public void GoToStartPosition()
    {
        transform.localPosition = points[0];
        RotateInstantly();
    }

    Quaternion RotateToPoint(Vector2 point)
    {
        /*transform.Rotate(0,Vector2.SignedAngle(point-(Vector2)transform.localPosition,
            transform.parent.InverseTransformDirection(transform.forward)),0,Space.Self);*/
        
        return Quaternion.Euler(0,Vector2.SignedAngle(point-(Vector2)transform.localPosition,
            transform.parent.InverseTransformDirection(transform.forward)),0);
    }

    public void RotateInstantly()
    {
        transform.Rotate(0, Vector2.SignedAngle(points[1] - (Vector2)transform.localPosition,
            transform.parent.InverseTransformDirection(transform.forward)), 0, Space.Self);
    }

    /*Vector2 GetLocalForward()
    {
        return new Vector2(transform.forward.)
    }*/
    
}
