using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubeFactory cubeFactory;
    private Vector3 spawnPosition = new Vector3(0, 0.5f, -4);
    private GameObject lastCube;
    private INumberGenerate numberGenerator;
    private ICubeInput sharedInput;

    private void Awake()
    {
        numberGenerator = new DefaultNumberGenerator();
        sharedInput = new TouchpadCubeInput(); 
    }

    private void Start()
    {
        SpawnCube();
    }

    public void SpawnCube()
    {
        ResetLastCube();

        GameObject newCube = cubeFactory.CreateCube(spawnPosition, numberGenerator.GetNumber());
        lastCube = newCube;

        MoveCube moveScript = newCube.GetComponent<MoveCube>();
        if (moveScript != null)
        {
            moveScript.isLastSpawned = true;
            moveScript.Initialize(sharedInput);
        }
    }

    public GameObject SpawnCubeAndReturn(int number, Vector3 pos)
    {
        GameObject newCube = cubeFactory.CreateCube(pos, number);

        MoveCube moveScript = newCube.GetComponent<MoveCube>();
        if (moveScript != null)
        {
            moveScript.Initialize(sharedInput);
        }

        return newCube;
    }

    private void ResetLastCube()
    {
        if (lastCube != null && lastCube.TryGetComponent(out MoveCube oldScript))
        {
            oldScript.isLastSpawned = false;
        }
    }
}