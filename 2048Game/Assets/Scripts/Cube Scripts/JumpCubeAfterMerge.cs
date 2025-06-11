using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class JumpCubeAfterMerge : MonoBehaviour
{
    private Rigidbody rb;
    [HideInInspector] public bool applyImpulseOnStart = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;

            if (applyImpulseOnStart)
            {
                Vector3 impulse = new Vector3(Random.Range(-1f, 1f), 5f, Random.Range(-1f, 1f));
                rb.velocity = impulse;
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
}
