using ScriptableVariables.Float;
using ScriptableVariables.Vector2Unity;
using SlingshotShooting.Interface;
using UnityEngine;

namespace SlingshotShooting.Behaviour
{
    public class SlingshotShootingBehaviour : MonoBehaviour, ISlingshotShooting
    {
        [SerializeField] 
        private Rigidbody2D birdRigidbody2D;
        
        

        [SerializeField] 
        private float shootingForce;

        public void DoPrepareForShooting()
        {
            birdRigidbody2D.isKinematic = true;
            birdRigidbody2D.velocity = Vector2.zero;
            birdRigidbody2D.angularVelocity = 0f;
        }

        public void DoShoot(Vector2 stripsPosition, Vector2 centerPointPosition, float stripsMaxElasticity)
        {
            birdRigidbody2D.isKinematic = false;
            Vector2 direction = (centerPointPosition - stripsPosition).normalized;
            Vector2 stripMagnitude = Vector2.ClampMagnitude(stripsPosition - centerPointPosition, stripsMaxElasticity);
            stripMagnitude.x = (stripMagnitude.x > 0) ? -stripMagnitude.x : stripMagnitude.x;
            stripMagnitude.y = (stripMagnitude.y > 0.5f) ? -stripMagnitude.y : stripMagnitude.y;
            birdRigidbody2D.AddForce(-direction * (stripMagnitude * shootingForce), ForceMode2D.Impulse);
        }

        // public void DoShoot()
        // {
        //     // birdRigidbody2D.isKinematic = false;
        //     // Vector2 direction = (slingshotCenterPointScriptableVariable.Value - currentStripPositionScriptableVariable.Value).normalized;
        //     // birdRigidbody2D.AddForce(direction * shootingForce, ForceMode2D.Impulse);
        //     
        //     birdRigidbody2D.isKinematic = false;
        //     Vector2 direction = (slingshotCenterPointScriptableVariable.Value - currentStripPositionScriptableVariable.Value).normalized;
        //     Vector2 stripMagnitude = Vector2.ClampMagnitude(currentStripPositionScriptableVariable.Value - slingshotCenterPointScriptableVariable.Value, 3);
        //     stripMagnitude.x = (stripMagnitude.x > 0) ? -stripMagnitude.x : stripMagnitude.x;
        //     stripMagnitude.y = (stripMagnitude.y > 0.5f) ? -stripMagnitude.y : stripMagnitude.y;
        //     print(stripMagnitude);
        //     birdRigidbody2D.AddForce(-direction * (stripMagnitude * shootingForce), ForceMode2D.Impulse);
        // }
    }
}