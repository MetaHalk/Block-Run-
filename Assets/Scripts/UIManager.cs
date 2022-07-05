using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject zigzagPanel;

    public GameObject gameoverPanel;
    public GameObject tapText;
    public Text score;
    public Text highScore1;
    public Text highScore2;


    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        highScore1.text = "Highest Score: " + PlayerPrefs.GetInt("highScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
    
        tapText.SetActive(false);
        zigzagPanel.GetComponent<Animator>().Play("PanelAnimation");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameoverPanel.SetActive(true);
    }

    public void PlayAgain()
    {
      
        SceneManager.LoadScene(1);
    }
}
