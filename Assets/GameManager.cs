using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool isGameOver =false;
    public Button ReplayBtn;

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
}
