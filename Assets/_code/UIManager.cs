using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI")]

    [SerializeField] bool IsRunning;
    public bool isRunning { get { return IsRunning; } set { IsRunning = value; } }

    [SerializeField] GameObject createUI;
    public GameObject CreateUI { get { return createUI; } set { createUI = value; } }

    [SerializeField] int CountdownTime;
    public int countdownTime { get { return CountdownTime; } set { CountdownTime = value; } }

    [SerializeField] TextMeshProUGUI countdown;
    public TextMeshProUGUI Countdown { get { return countdown; } set { countdown = value; } }



    [Header("Screen Animator")]

    [SerializeField] Animator screenAni;
    public Animator ScreenAni { get { return screenAni; } set { screenAni = value; } }


    [Header("Screen Animator")]
    [SerializeField] AudioSource[] audioSoure;
    public AudioSource[] AudioSoure { get { return audioSoure; } set { audioSoure = value; } }

    // ==== ==== ====

    [Header("CountDown")]
    [SerializeField] GameObject countdownTextMesh;
    public GameObject CountdownTextMesh { get { return countdownTextMesh; } set { countdownTextMesh = value; } }


    private void Awake()
    {
        countdownTextMesh.SetActive(false);
        audioSoure[0].Play();
    }


    // ==== ==== ====

    public void CountDownUse()
    {
        CountdownTime = 3;
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        audioSoure[0].mute = true;

        while (CountdownTime > 0)
        {
            countdown.text = CountdownTime.ToString();
            audioSoure[2].Play();
            yield return new WaitForSeconds(1f);

            CountdownTime--;
        }
        countdownTextMesh.SetActive(false);
        audioSoure[3].Play();
        audioSoure[1].Play();
        audioSoure[1].mute = false;
    }
}
