using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManger : MonoBehaviour
{
    [Header("Script")]
    public scoreSystem scoreSystem;
    public wicketOut wicketout;
    public batesMan batesMan;

    [Header("GameUI")]
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI ballNum;
    public GameObject outUI;

    private void Start()
    {
        outUI.SetActive(false);
    }

    private void Update()
    {
        scoreUI.text = "score " + scoreSystem.totalScore;
        ballNum.text = "ball " + scoreSystem.currentBallCount;

        if (scoreSystem.currentBallCount >= 6 || wicketout.isWicketOut || batesMan.LBW)
        {
            scoreSystem.currentBallCount = 0;
            wicketout.isWicketOut = false;
            batesMan.LBW = false;

            outUI.SetActive(true);

            Time.timeScale = 0;
            // FIXED LINE
            Invoke("changeTheScene", 5f);
        }
    }

    void changeTheScene()
    {
        SceneManager.LoadScene("BallerScene");
    }
}
