using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool isGameOver =false;
    public Button ReplayBtn;
    public GameObject PauseGamePanel;
    public GameObject player; 
    public GameObject Asteorid;
 

    // Start is called before the first frame update
    void Start()
    {
       

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && isGameOver)
        {
            SceneManager.LoadScene(01);
        }
        

    }
    public void CheckGameOver()
    {
        isGameOver = true;
        ReplayBtn.gameObject.SetActive(true);

    }
    public void Replay()
    {
        SceneManager.LoadScene("SampleScene");

    }
    public void PauseGame()
    {
        //_animator.SetBool("isPaused", true);
        player.SetActive(false);
        Asteorid.SetActive(false);
        PauseGamePanel.SetActive(true);
        PauseGamePanel.transform.parent.GetComponent<Animator>().SetBool("isPaused", true);

        Time.timeScale = 0f;
    }
    public void ResumeBtn()
    {
        Time.timeScale = 1f;
        PauseGamePanel.SetActive(false);
        Asteorid.SetActive(true);
        player.SetActive(true);

    }
    public void QuitBtn()
    {
        Application.Quit();
        Debug.Log("quit the application");
    }
}
