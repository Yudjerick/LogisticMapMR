using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BrushPreset", order = 1)]
public class BrushPreset : ScriptableObject
{
    
    public GameObject truckModel;
    public float speed;
    public Material bakedLineMaterial;
    public Material selectedLineMaterial;
    public float lineWidthMultiplier;
    public float lineRelief;
    public MovingType movingType;
    
}
