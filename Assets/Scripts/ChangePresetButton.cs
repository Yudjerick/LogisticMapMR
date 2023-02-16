using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePresetButton : MonoBehaviour
{
    [SerializeField] private PathCreator pathCreator;
    [SerializeField] private BrushPreset brushPreset;

    public void ChangeBrushPreset()
    {
        pathCreator.brushPreset = brushPreset;
    }

}
