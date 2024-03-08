using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Text ScoreText;
    private GameObject player;
    public Image Background;
    public Image LoseScreen;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClicked()
    {
        player.GetComponent<PlayerController>().isGameStart = true;
        this.gameObject.SetActive(false);
    }

    public void OpenSettings()
    {
        Debug.Log("Open Settings");
    }
    public void ClickedCalender()
    {
        Debug.Log("ClickedCalender");
    }
    public void ClickedWeaponPass()
    {
        Debug.Log("ClickedWeaponPass");
    }
    public void FireRate()
    {
        Debug.Log("FireRate");
    }
    public void StartYear()
    {
        Debug.Log("StartYear");
    }
    public void DoubleShoot()
    {
        Debug.Log("DoubleShoot");
    }

    public void Restart()
    {
        Background.gameObject.SetActive(true);
        LoseScreen.gameObject.SetActive(false);
        player.GetComponent<PlayerController>().RestardGame();

    }
}
