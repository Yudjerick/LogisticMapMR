using UnityEngine;

public abstract class MovingType: ScriptableObject
{
    public abstract void ApplyTypeFeatures(VehicleMover vehicleMover);
}