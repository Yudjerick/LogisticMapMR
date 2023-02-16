using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MovingTypes/OneWayMovingType", order = 1)]
    public class OneWayMovingType: MovingType
    {
        public override void ApplyTypeFeatures(VehicleMover vehicleMover)
        {
            vehicleMover._targetIndex += vehicleMover._direction;
            if (vehicleMover._targetIndex == vehicleMover.points.Length && vehicleMover._direction == 1)
            {
                
                vehicleMover._targetIndex = 1;
                vehicleMover.transform.localPosition = vehicleMover.points[0];
                vehicleMover.RotateInstantly();
            }
            vehicleMover._targetRotation = vehicleMover.transform.localRotation
                                           * vehicleMover.RotateToPoint(vehicleMover.points[vehicleMover._targetIndex]);
        }
    }
}