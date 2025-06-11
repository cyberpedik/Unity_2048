using TMPro;
using UnityEngine;


public class GameOverCube : MonoBehaviour
{
   [SerializeField] private TextMeshPro gameOverText;
    private bool isGameOver = false;

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        MoveCube[] allCubes = FindObjectsOfType<MoveCube>();
        foreach (var cube in allCubes)
        {
            cube.isSelected = false;
            cube.isReleased = true;
            cube.enabled = false;
        }

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "Game Over";
        }
    }
}
