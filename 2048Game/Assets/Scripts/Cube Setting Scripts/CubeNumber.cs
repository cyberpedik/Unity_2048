using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CubeNumber : MonoBehaviour
{
    [HideInInspector] public int number;
    private Renderer rend;
    private List<TextMeshPro> numberTexts = new List<TextMeshPro>();
    private ColorStrategy colorStrategy;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        numberTexts.AddRange(GetComponentsInChildren<TextMeshPro>());
        colorStrategy = new DefaultColorStrategy();
        UpdateVisuals();
    }

    public void SetNumber(int newNumber)
    {
        number = newNumber;
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        foreach (TextMeshPro text in numberTexts)
        {
            if (text != null)
                text.text = number.ToString();
        }

        if (rend != null && colorStrategy != null)
            rend.material.color = colorStrategy.GetColor(number);
    }
}