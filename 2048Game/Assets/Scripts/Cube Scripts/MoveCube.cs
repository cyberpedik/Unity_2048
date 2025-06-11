using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCube : MonoBehaviour
{
     private Rigidbody rb;
    private Camera cam;
    private CubePhysics cubePhysics;
    private ICubeInput cubeInput;

    [HideInInspector] public bool isSelected = false;
    [HideInInspector] public bool isReleased = false;
    [HideInInspector] public bool hasLaunched = false;
    [HideInInspector] public bool skipStartPhysicsSetup = false;
    [HideInInspector] public bool isPassedTrigger = false;
    [HideInInspector] public bool isLastSpawned = false;

    public float forwardSpeed = 40f;
    public float gravityMultiplier = 2.5f;

    public void Initialize(ICubeInput input)
    {
        cubeInput = input;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        cubePhysics = new CubePhysics(rb, transform, gravityMultiplier);

        if (!skipStartPhysicsSetup)
        {
            cubePhysics.DisablePhysics();
        }
    }

    void Update()
    {
        if (!isReleased && !isPassedTrigger)
        {
            HandleInput();
        }

        cubePhysics.ApplyGravityIfFalling();
    }

    private void HandleInput()
    {
        if (cubeInput == null) return;

        if (cubeInput.IsSelectPressed())
        {
            isSelected = true;
        }

        if (cubeInput.IsSelectHeld() && isSelected)
        {
            if (cubeInput.TryGetSelectionPosition(cam, transform, out Vector3 worldPos))
            {
                cubePhysics.MoveHorizontally(worldPos);
            }
        }

        if (cubeInput.IsSelectReleased() && isSelected)
        {
            isSelected = false;
            isReleased = true;
            hasLaunched = true;
            cubePhysics.Launch(forwardSpeed);
        }
    }
}
