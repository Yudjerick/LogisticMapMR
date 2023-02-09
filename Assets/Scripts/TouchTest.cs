using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class TouchTest : MonoBehaviour, IMixedRealityPointerHandler
{
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        Debug.Log("pointer down");
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
    }

    public void Log()
    {
        Debug.Log("ggggggggggggg");
    }
}
