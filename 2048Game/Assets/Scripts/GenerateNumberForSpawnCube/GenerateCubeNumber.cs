using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultNumberGenerator : INumberGenerate
{
    public int GetNumber()
    {
        return Random.value < 0.75f ? 2 : 4;
    }
}

