using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MovingTypes/AlternatingMovingType", order = 1)]
    public class AlternatingMovingType: MovingType
    {
        public override void ApplyTypeFeatures(VehicleMover vehicleMover)
        {
            vehicleMover._targetIndex += vehicleMover._direction;
            if (vehicleMover._targetIndex == vehicleMover.points.Length && vehicleMover._direction == 1)
            {
                vehicleMover._targetIndex = vehicleMover.points.Length - 2;
                vehicleMover._direction = -1;
            }
            else if(vehicleMover._targetIndex == 0 && vehicleMover._direction == -1)
            {
                vehicleMover._targetIndex = 1;
                vehicleMover._direction = 1;
            }
            vehicleMover._targetRotation = vehicleMover.transform.localRotation * 
                                           vehicleMover.RotateToPoint(vehicleMover.points[vehicleMover._targetIndex]) ;
        }
    }
}