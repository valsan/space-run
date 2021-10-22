using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] GameObject myprefab;

    [Tooltip("The speed of the terrain")]
    [SerializeField] float speed;
    [SerializeField] float increaseSpeedMultiplier;

    GameObject currentTerrainBlock;
    GameObject nextTerrainBlock;

    float prefabLength = 200;

    void Start()
    {
        currentTerrainBlock = Instantiate(myprefab, transform.position + Vector3.forward * (prefabLength * 0.5f), Quaternion.identity);
        nextTerrainBlock = Instantiate(myprefab, transform.position + Vector3.forward * (prefabLength * 1.5f), Quaternion.identity);
    }

    public void IncreaseSpeed()
    {
        speed *= increaseSpeedMultiplier;
    }

    private void Update()
    {
        currentTerrainBlock.transform.Translate(Vector3.back * speed * Time.deltaTime);
        nextTerrainBlock.transform.Translate(Vector3.back * speed * Time.deltaTime);
        if(currentTerrainBlock.transform.position.z + prefabLength * 0.5f < 0)
        {
            Destroy(currentTerrainBlock);
            currentTerrainBlock = nextTerrainBlock;
            nextTerrainBlock = Instantiate(myprefab, transform.position + Vector3.forward * (prefabLength * 1.5f), Quaternion.identity);
        }
    }
}
