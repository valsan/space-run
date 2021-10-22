using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBlockPopulator : MonoBehaviour
{
    [SerializeField] GameObject coin;
    [SerializeField] GameObject obstacle;
    [SerializeField] int numberOfObjects;

    void Start()
    {
        for (int x = 0; x < numberOfObjects; x++)
        {
            float randomXPos = Random.Range(-4.5f, 4.5f);
            if (Random.Range(0f,1f) < 0.5)
            {
                GameObject newCoin = Instantiate(coin, transform);
                newCoin.transform.Translate(new Vector3(randomXPos, 1, -100 + (200/numberOfObjects) * x));
            } else
            {
                GameObject newObstacle = Instantiate(obstacle, transform);
                newObstacle.transform.Translate(new Vector3(randomXPos, 0.5f, -100 + (200 / numberOfObjects) * x));
            }
        }
    }
}
