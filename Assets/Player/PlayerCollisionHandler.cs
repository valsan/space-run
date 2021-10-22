using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{
    ScoreBoard scoreBoard;
    TerrainGenerator terrainGenerator;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        terrainGenerator = FindObjectOfType<TerrainGenerator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            scoreBoard.IncreaseScore(15);
            terrainGenerator.IncreaseSpeed();
            other.GetComponent<Renderer>().enabled = false;
        }
        if (other.tag == "Obstacle")
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
