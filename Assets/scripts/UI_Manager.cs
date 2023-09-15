using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private Text _score;
    [SerializeField] private Text _restartGameText;
    [SerializeField] private Text _gameOver;
    [SerializeField] private Image _livesImg;
    private GameManager _gameManager;
    [SerializeField] private Sprite[] livesSprites;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _score.text = "score : " + 0 ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(int playerScore)
    {
        _score.text = "score :  " + playerScore.ToString();
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
