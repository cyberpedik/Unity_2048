using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;

    public GameObject CreateCube(Vector3 position, int number)
    {
        GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);

        CubeNumber cn = cube.GetComponent<CubeNumber>();
        if (cn != null)
        {
            cn.SetNumber(number);
        }

        MoveCube moveScript = cube.GetComponent<MoveCube>();
        if (moveScript != null)
        {
            moveScript.isLastSpawned = false; 
        }

        return cube;
    }
}
