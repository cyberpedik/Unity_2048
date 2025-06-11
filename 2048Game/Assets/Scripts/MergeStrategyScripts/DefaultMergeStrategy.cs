using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMergeStrategy : IMergeStrategy
{
    
    public void TryMerge(CubeMerger cubeMerger, Collision collision)
    {
        if (cubeMerger.HasMerged) return;

        if (!collision.gameObject.CompareTag("Cube")) return;

        CubeNumber thisCubeNumber = cubeMerger.GetComponent<CubeNumber>();
        CubeNumber otherCubeNumber = collision.gameObject.GetComponent<CubeNumber>();
        MoveCube otherMoveCube = collision.gameObject.GetComponent<MoveCube>();
        CubeMerger otherMergeCube = collision.gameObject.GetComponent<CubeMerger>();

        if (otherCubeNumber == null || thisCubeNumber == null || otherMergeCube == null || otherMoveCube == null)
            return;

        if (otherCubeNumber.number != thisCubeNumber.number || otherMergeCube.HasMerged)
            return;

        cubeMerger.HasMerged = true;
        otherMergeCube.HasMerged = true;

        Rigidbody rb = cubeMerger.GetComponent<Rigidbody>();
        CubePhysics thisPhysics = new CubePhysics(rb, cubeMerger.transform);
        thisPhysics.StopPhysics();

        Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();
        CubePhysics otherPhysics = new CubePhysics(otherRb, collision.transform);
        otherPhysics.StopPhysics();

        int newNumber = thisCubeNumber.number * 2;
        ScoreCounter.Instance?.AddScore(thisCubeNumber.number / 2);

        cubeMerger.MergeAudio?.Play();

        Vector3 spawnPos = (cubeMerger.transform.position + collision.transform.position) / 2f;

        Object.Destroy(collision.gameObject);
        Object.Destroy(cubeMerger.gameObject);

        Spawner spawner = Object.FindObjectOfType<Spawner>();
        if (spawner != null)
        {
            GameObject newCube = spawner.SpawnCubeAndReturn(newNumber, spawnPos);

            JumpCubeAfterMerge jumpCube = newCube.GetComponent<JumpCubeAfterMerge>();
            if (jumpCube != null)
                jumpCube.applyImpulseOnStart = true;

            Rigidbody newRb = newCube.GetComponent<Rigidbody>();
            if (newRb != null)
            {
                CubePhysics newPhysics = new CubePhysics(newRb, newCube.transform);
                newPhysics.EnablePhysics();
            }

            MoveCube moveScript = newCube.GetComponent<MoveCube>();
            if (moveScript != null)
            {
                moveScript.skipStartPhysicsSetup = true;
                moveScript.isSelected = false;
                moveScript.isReleased = true;
                moveScript.hasLaunched = false;
            }

            if (newNumber == 2048)
            {
                GameOverCube gameOverCube = Object.FindObjectOfType<GameOverCube>();
                gameOverCube?.GameOver();
            }
        }
    }
}
