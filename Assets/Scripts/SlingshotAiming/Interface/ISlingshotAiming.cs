using UnityEngine;

namespace SlingshotAiming.Interface
{
    public interface ISlingshotAiming
    {
        void CreateStripsInitialPoint();
        void DoAim(Vector2 inputPosition, Vector2 centerPointPosition, float stripsMaxElasticity);
        void DoStopAiming(Vector2 idleStripPosition);
    }
}