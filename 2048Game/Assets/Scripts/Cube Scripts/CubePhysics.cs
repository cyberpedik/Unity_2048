using UnityEngine;

public class CubePhysics
{
    private readonly Rigidbody rb;
    private readonly Transform transform;
    private readonly float gravityMultiplier;

    public CubePhysics(Rigidbody rigidbody, Transform cubeTransform, float gravityMultiplier = 2.5f)
    {
        rb = rigidbody;
        transform = cubeTransform;
        this.gravityMultiplier = gravityMultiplier;
    }

    public void ApplyGravityIfFalling()
    {
        if (rb.useGravity && !rb.isKinematic && rb.velocity.y < 0)
        {
            rb.velocity += Physics.gravity * (gravityMultiplier - 1f) * Time.deltaTime;
        }
    }

    public void Launch(float forwardSpeed)
    {
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.velocity = new Vector3(0, 0, forwardSpeed);
    }

    public void StopPhysics()
    {
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    public void EnablePhysics()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    public void DisablePhysics()
    {
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    public void MoveHorizontally(Vector3 worldPosition)
    {
        Vector3 targetPos = new Vector3(worldPosition.x, transform.position.y, transform.position.z);
        rb.MovePosition(targetPos);
    }

    public Rigidbody Rigidbody => rb;
}
