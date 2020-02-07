using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int blockCount;
    SceneLoader sceneLoader;
    GameStatus gameStatus;
    public void addBlock()
    {
        blockCount++;
    }
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    public void destroyBlock()
    {
        blockCount--;
        gameStatus.addScore();
        if (blockCount <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

}
