using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState { Ready, Running, GameOver }

    [SerializeField] GameState curState;
    [SerializeField] Monster[] monsters;
    [SerializeField] PlayerController player;

    [SerializeField] GameObject ready;
    [SerializeField] GameObject over;
    [SerializeField] GameObject score;
    [SerializeField] GameObject dot;


    private void Start()
    {
        
        curState = GameState.Ready;
        monsters = FindObjectsOfType<Monster>();
        player = FindObjectOfType<PlayerController>();

        ready.SetActive(true);
        over.SetActive(false);
        dot.SetActive(false);
        Cursor.visible = false;

        foreach (Monster monster in monsters)
        {
            monster.gameObject.SetActive(false);
        }

    }

    private void Update()
    {
        if (curState == GameState.Ready && Input.GetKeyDown(KeyCode.Space))
        {
            GameStart();
        }
        else if (curState == GameState.GameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("DodgeScene");
        }
        
    }

    public void GameStart()
    {
        curState = GameState.Running;
        player.isMoving = true;
        foreach (Monster monster in monsters)
        {
            monster.gameObject.SetActive(true);
        }
        ready.SetActive(false);
        over.SetActive(false);
        dot.SetActive(true );
    }

    public void GameOver()
    {
        curState = GameState.GameOver;
        player.isMoving = false;

        ready.SetActive(false);
        over.SetActive(true);
        dot.SetActive(false );
    }


}
