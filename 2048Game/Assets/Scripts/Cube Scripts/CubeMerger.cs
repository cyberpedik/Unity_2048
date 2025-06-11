using UnityEngine;

public class CubeMerger : MonoBehaviour
{
    public AudioSource MergeAudio;
    private IMergeStrategy mergeStrategy;
    public bool HasMerged { get; set; } = false;
    public IMergeStrategy Strategy
    {
        get => mergeStrategy;
        set => mergeStrategy = value;
    }

    void Start()
    {
        mergeStrategy = new DefaultMergeStrategy();
    }

    private void OnCollisionEnter(Collision collision)
    {
        mergeStrategy?.TryMerge(this, collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        mergeStrategy?.TryMerge(this, collision);
    }
}
