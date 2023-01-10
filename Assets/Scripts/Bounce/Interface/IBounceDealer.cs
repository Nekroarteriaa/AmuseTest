using UnityEngine;

namespace Bounce.Interface
{
    public interface IBounceDealer
    {
        float BouncinessForceToDeal { get; }
        void DoBounce(Rigidbody2D rigidbody2DToBounce, Vector2 impactNormal, Vector2 currentVelocity);
        void CancelBounce(Rigidbody2D rigidbody2DToBounce);
    }
}