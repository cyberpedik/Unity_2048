using UnityEngine;

public interface ICubeInput
{
    bool IsSelectPressed();
    bool IsSelectHeld();
    bool IsSelectReleased();
    bool TryGetSelectionPosition(Camera cam, Transform cubeTransform, out Vector3 worldPosition);
}
