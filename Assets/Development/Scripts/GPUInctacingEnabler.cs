using UnityEngine;

namespace Bomber
{
    [RequireComponent(typeof(MeshRenderer))]
    public class GPUInctacingEnabler : MonoBehaviour
    {
        private void Awake()
        {
            MaterialPropertyBlock materialProperty = new MaterialPropertyBlock();
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.SetPropertyBlock(materialProperty);
        }

    }
}
