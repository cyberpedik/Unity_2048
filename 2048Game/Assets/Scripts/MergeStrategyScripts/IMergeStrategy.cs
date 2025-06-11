using UnityEngine;

public interface IMergeStrategy
{
    void TryMerge(CubeMerger cubeMerger, Collision collision);
}
