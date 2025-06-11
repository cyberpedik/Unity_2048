using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlateDetector : MonoBehaviour
{
    private bool hasCrossedStartLine = false;
    private bool hasTriggeredGameOver = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("secretPlate"))
        {
            if (!hasCrossedStartLine)
            {
                hasCrossedStartLine = true;
            }
            else if (!hasTriggeredGameOver)
            {
                hasTriggeredGameOver = true;
                GameOverCube gameOverCube = FindObjectOfType<GameOverCube>();
                if (gameOverCube != null)
                {
                    gameOverCube.GameOver();
                }
            }

            MoveCube moveScript = GetComponent<MoveCube>();
            if (moveScript != null)
            {
                moveScript.isPassedTrigger = true;
            }
        }
    }
}
