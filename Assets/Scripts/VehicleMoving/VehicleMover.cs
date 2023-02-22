using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class VehicleMover : MonoBehaviour
{
    public Vector2[] points;
    public float maxDistance;
    public int _targetIndex;
    public Quaternion _targetRotation;
    public int _direction;
    private MovingType movingType;

    [HideInInspector] public BrushPreset brushPreset;
    void Start()
    {
        _targetIndex = 0;
        _direction = 1;
    }

    private void FixedUpdate()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, 
            _targetRotation, 1.5f * brushPreset.speed );
    }

    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition,points[_targetIndex], 
            Time.deltaTime * brushPreset.speed);
        if (Mathf.Abs(((Vector2)transform.localPosition - points[_targetIndex]).magnitude) <= maxDistance)
        {
            brushPreset.movingType.ApplyTypeFeatures(this);
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

    public Quaternion RotateToPoint(Vector2 point)
    {
        return Quaternion.Euler(0,Vector2.SignedAngle(point-(Vector2)transform.localPosition,
            transform.parent.InverseTransformDirection(transform.forward)),0);
    }

    public void RotateInstantly()
    {
        transform.Rotate(0, Vector2.SignedAngle(points[1] - (Vector2)transform.localPosition,
            transform.parent.InverseTransformDirection(transform.forward)), 0, Space.Self);
    }
}
