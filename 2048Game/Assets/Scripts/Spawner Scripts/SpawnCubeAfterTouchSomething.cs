using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCubeAfterTouchSomething : MonoBehaviour
{
    private bool hasSpawnedNextCube = false;

    private void OnCollisionEnter(Collision collision)
    {
        MoveCube moveScript = GetComponent<MoveCube>();

        if (moveScript != null && moveScript.isLastSpawned && moveScript.isReleased &&
            !hasSpawnedNextCube &&
            (collision.gameObject.CompareTag("Cube") || collision.gameObject.CompareTag("Boundary")))
        {
            hasSpawnedNextCube = true;

            Spawner spawner = FindObjectOfType<Spawner>();
            if (spawner != null)
            {
                spawner.SpawnCube();
            }
        }
    }
}
