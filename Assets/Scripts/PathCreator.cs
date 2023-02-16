using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    [HideInInspector] public List<Vector2> points;
    public BrushPreset brushPreset;
    
    private float _multiplierX;
    private float _multiplierY;
    private GameObject _line;
    

    private void Start()
    {
        _line = null;
    }

    public void CreateLine()
    {
        _line = new GameObject("line")
        {
            transform =
            {
                parent = gameObject.transform,
                localPosition = Vector3.zero,
                localRotation = Quaternion.Euler(Vector3.zero),
                localScale = Vector3.one
            }
        };

        _line.transform.localPosition -= Vector3.forward * brushPreset.lineRelief;
        _lineRenderer = _line.AddComponent<LineRenderer>();
        _lineRenderer.widthMultiplier = brushPreset.lineWidthMultiplier;
        _lineRenderer.material = brushPreset.selectedLineMaterial;
        _lineRenderer.textureMode = LineTextureMode.Tile;
        brushPreset.selectedLineMaterial.mainTextureScale = new Vector2(1/brushPreset.lineWidthMultiplier,1);
        _lineRenderer.useWorldSpace = false;
        points = new List<Vector2>();
    }

    public void BakeLine()
    {
        if (points.Count < 3)
        {
            Destroy(_line);
            return;
        }

        if (brushPreset.bakedLineMaterial != null)
        {
            _lineRenderer.material = brushPreset.bakedLineMaterial;
            _lineRenderer.material.mainTextureScale = new Vector2(1/brushPreset.lineWidthMultiplier,1);
        }

        var instantiate = Instantiate(brushPreset.truckModel,_line.transform);
        instantiate.transform.localRotation = Quaternion.Euler(0, 90, -90);
        var vehicleMover = instantiate.GetComponent<VehicleMover>();
        vehicleMover.SetPath(points);
        vehicleMover.GoToStartPosition();
        vehicleMover.brushPreset = brushPreset;
        _line = null;
    }
    
    void Update()
    {
        _multiplierX = transform.localScale.x * transform.parent.localScale.x;
        _multiplierY = transform.localScale.y * transform.parent.localScale.y;
        if(_line == null)
            return;
        Vector3[] lineRendererPositions = new Vector3[points.Count];
        for (int i = 0; i < points.Count; i++)
        {
            lineRendererPositions[i] = points[i];
        }

        _lineRenderer.positionCount = points.Count;
        _lineRenderer.SetPositions(lineRendererPositions);
    }
    public Vector2 CalculateLocalPoint(Vector3 point)
    {
        Vector3 r = point - transform.position;
        Vector2 localPoint = new Vector2(Vector3.Dot(r, transform.right)/_multiplierX, Vector3.Dot(r, transform.up)/_multiplierY);
        return localPoint;
    }
}
