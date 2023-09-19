using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private Text _score;
    public Text _bestText; 
    [SerializeField] private Text _restartGameText;
    [SerializeField] private Text _gameOver;
    [SerializeField] private Image _livesImg;
    private GameManager _gameManager;
    int score=0;
    private int bestScore;
    [SerializeField] private Sprite[] livesSprites;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _score.text = "Score : " + 0 ;
        bestScore = PlayerPrefs.GetInt("HighScore", 0);
        _bestText.text = "Best : " + bestScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(int playerScore)
    {
        score += 10;
        _score.text = "Score :  " + playerScore.ToString();
    }

    public void CheckForBestScore()
    {
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("HighScore",bestScore );
            Debug.Log(bestScore);
            _bestText.text="Best : "+ bestScore.ToString();
        }

    }

    public void UpdateLives(int currentLives)
    {
        _livesImg.sprite = livesSprites[currentLives]; 
        if (currentLives == 0)
        {
            _gameOver.gameObject.SetActive(true);
            _restartGameText.gameObject.SetActive(true); 
            StartCoroutine(FlickerGameOver());
            _gameManager.CheckGameOver();

        }
    }
    public IEnumerator FlickerGameOver()
    {
        while (true)
        {
            _gameOver.text = "GAME OVER";
            yield return new WaitForSeconds(.5f);
            _gameOver.text = " ";
            yield return new WaitForSeconds(.5f);
        }
    }
}
