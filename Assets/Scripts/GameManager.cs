using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] 
    private UiManager _uiManager;
    
    //Reset the Level
    public static GameManager _instance { get; private set;}
    public int _world { get; private set; }
    public int _level { get; private set; }
    public int _lives { get; private set; }
    public int _pearls { get; private set; }
    
    
    private void Awake()
    {
        //check if another instance already exists if yes destroy
        if (_instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            _instance = this;
            //dont destroy gameObject if we load the scene or different levels
            DontDestroyOnLoad(gameObject);

        }
    }

    private void OnDestroy()
    {
        if (_instance == this)
        {
            //next gameObject is created it will reassign
            _instance = null;
        }
    }

    private void Start()
    {
        //start the game
        StartGame();
    }

    private void StartGame()
    {
        _lives = 2;
        _pearls = 0;
        
        //ui for lives and pearls
        _uiManager.UpdatePearl(_pearls);
        _uiManager.UpdateLives(_lives);

        //load level 1-1
        LoadLevel(1, 1);
    }

    
    //loading new levels in style of x-x
    public void LoadLevel(int _world, int _level)
    {
        this._world = _world;
        this._level = _level;

        SceneManager.LoadScene($"{_world}-{_level}");
    }

    
    //Reset level if we are dead
    public void LevelReset(float _delay)
    {
        Invoke(nameof(DiverDeath), _delay);
    }
    
    
    public void DiverDeath()
    {
        //take away live
        _lives--;
        //update text
       _uiManager.UpdateLives(_lives);
        

        //check if we still have lives
        if (_lives > 0)
        {
            //if yes reload the current scene
            LoadLevel(_world, _level);
        }
        else
        {
            //no lives game over scene is loaded
            GameOver();
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }


    //add pearls and update ui manager
    public void AddPearl()
    {
        _pearls++;
        _uiManager.UpdatePearl(_pearls);
        
    }
    

}
