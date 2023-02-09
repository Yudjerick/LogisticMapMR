using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawingInputSystem : MonoBehaviour, IMixedRealityPointerHandler
{
    [SerializeField] private PathCreator pathCreator;
    private bool _isDrawing;
    [SerializeField] private float optimizationRadius;
    void FinishDrawing(MixedRealityPointerEventData eventData)
    {
        var point = pathCreator.CalculateLocalPoint(eventData.Pointer.Position);
        if (point.x != -0.0625f && point.y != 0f)
        {
            pathCreator.points.Add(point);
        }
        _isDrawing = false;
        pathCreator.BakeLine();
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        if (eventData.Handedness == Handedness.Right)
        {
            pathCreator.CreateLine();
            _isDrawing = true;
        }
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        if (_isDrawing && eventData.Handedness == Handedness.Right)
        {
            var point = pathCreator.CalculateLocalPoint(eventData.Pointer.Position);
            if (Math.Abs(point.x) >= 0.5 || Math.Abs(point.y) >= 0.5)
            {
                FinishDrawing(eventData);
                return;
            }
            if (pathCreator.points.Count == 0)
            {
                pathCreator.points.Add(point);
                return;
            }
            if ((point - pathCreator.points[pathCreator.points.Count-1]).magnitude > optimizationRadius)
            {
                pathCreator.points.Add(point);
            }
        }
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        if (_isDrawing && eventData.Handedness == Handedness.Right)
        {
            FinishDrawing(eventData);
        }
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        
    }
}
