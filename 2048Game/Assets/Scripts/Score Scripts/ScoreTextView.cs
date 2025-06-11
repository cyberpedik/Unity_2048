using TMPro;
using UnityEngine;

public class ScoreTextView : MonoBehaviour
{
    [SerializeField] private TextMeshPro TextMeshPro3D;

    public void UpdateScoreText(int newScore)
    {
        if (TextMeshPro3D != null)
        {
            TextMeshPro3D.text = newScore.ToString();
        }
    }
}
