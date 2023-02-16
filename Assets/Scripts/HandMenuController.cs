using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMenuController : MonoBehaviour
{
    [SerializeField] private Transform map;

    [SerializeField] private BrushPreset[] brushPresets;

    [SerializeField] private PathCreator pathCreator;
    public void DeleteAllLines()
    {
        for (int i = 0; i < map.childCount; i++)
        {
            Destroy(map.GetChild(i).gameObject);
        }
    }
}
