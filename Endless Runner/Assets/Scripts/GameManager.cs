using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Animations;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public bool playing = false;
    private float timer;

    public Animator playerAnim;

    public GameObject holdDPanel;
    private bool dPanelOff = false;

    private void Update()
    {
        HoldD();

        if (Input.GetKeyDown(KeyCode.D))
        {
            dPanelOff = true;
        }
        else
        {
            playerAnim.StopPlayback();
        }

        if (playing)
        {
            timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer % 60F);
            int milliseconds = Mathf.FloorToInt((timer * 100F) % 100F);
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
        }

        if (dPanelOff)
        {
            holdDPanel.SetActive(false);
        }
    }

    private void HoldD()
    {
        holdDPanel.SetActive(true);   
    }
}
