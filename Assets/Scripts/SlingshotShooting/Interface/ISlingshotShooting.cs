using UnityEngine;

namespace SlingshotShooting.Interface
{
    public interface ISlingshotShooting
    {
        void DoPrepareForShooting();
        void DoShoot(Vector2 stripsPosition, Vector2 centerPointPosition, float stripsMaxElasticity);
    }
}