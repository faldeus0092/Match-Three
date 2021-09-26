using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static int highScore;
    // singleton
    #region Singleton

    private static ScoreManager _instance = null;

    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreManager>();

                if (_instance == null)
                {
                    Debug.LogError("Fatal Error: ScoreManager not Found");
                }
            }

            return _instance;
        }
    }

    #endregion

    public int tileRatio;
    public int comboRatio;

    public int HighScore { get { return highScore; } }
    public int CurrentScore { get { return currentScore; } }

    private int currentScore;

    // reset setiap restart
    // Start is called before the first frame update
    private void Start()
    {
        ResetCurrentScore();
    }

    public void ResetCurrentScore()
    {
        currentScore = 0;
    }

    // rumus menambah skor
    public void IncrementCurrentScore(int tileCount, int comboCount)
    {
        currentScore += (tileCount * tileRatio) * (comboCount * comboRatio);
        SoundManager.Instance.PlayScore(comboCount > 1);
    }
    
    // set hs
    public void SetHighScore()
    {
        highScore = currentScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
