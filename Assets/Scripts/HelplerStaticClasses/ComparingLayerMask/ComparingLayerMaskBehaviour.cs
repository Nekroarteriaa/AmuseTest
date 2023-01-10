
using UnityEngine;

namespace HelplerStaticClasses.ComparingLayerMask
{
    public static class ComparingLayerMaskBehaviour
    {
        public static bool AreLayerMaskEquals(LayerMask desiredLayerMaskComprobation, int hittedObjectLayer)
        {
            return (((1 << hittedObjectLayer) & desiredLayerMaskComprobation) != 0);
        }
    }
}