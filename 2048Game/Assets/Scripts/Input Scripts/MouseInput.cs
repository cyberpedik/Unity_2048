using UnityEngine;

public class TouchpadCubeInput : ICubeInput
{
    private int selectedFingerId = -1;

    public bool IsSelectPressed()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                if (touch.phase == TouchPhase.Began)
                {
                    selectedFingerId = touch.fingerId;
                    return true;
                }
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            selectedFingerId = 0;
            return true;
        }
        return false;
    }

    public bool IsSelectHeld()
    {
        if (selectedFingerId == -1) return false;

        if (Input.touchCount > 0)
        {
            foreach (var touch in Input.touches)
            {
                if (touch.fingerId == selectedFingerId &&
                    (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary))
                    return true;
            }
        }
        else
        {
            return Input.GetMouseButton(0);
        }

        return false;
    }

    public bool IsSelectReleased()
    {
        if (selectedFingerId == -1) return false;

        if (Input.touchCount > 0)
        {
            foreach (var touch in Input.touches)
            {
                if (touch.fingerId == selectedFingerId && 
                    (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
                {
                    selectedFingerId = -1;
                    return true;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            selectedFingerId = -1;
            return true;
        }
        return false;
    }

    public bool TryGetSelectionPosition(Camera cam, Transform cubeTransform, out Vector3 worldPosition)
    {
        worldPosition = Vector3.zero;

        if (selectedFingerId == -1)
            return false;

        Vector3 screenPos;

        if (Input.touchCount > 0)
        {
            foreach (var touch in Input.touches)
            {
                if (touch.fingerId == selectedFingerId)
                {
                    screenPos = touch.position;
                    screenPos.z = cam.WorldToScreenPoint(cubeTransform.position).z;
                    worldPosition = cam.ScreenToWorldPoint(screenPos);
                    return true;
                }
            }
            return false;
        }
        else
        {
            screenPos = Input.mousePosition;
            screenPos.z = cam.WorldToScreenPoint(cubeTransform.position).z;
            worldPosition = cam.ScreenToWorldPoint(screenPos);
            return true;
        }
    }
}
