using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    // public Text infoText;

    //  private bool isGameOver = false;
    public static bool isInBossRoom = false;
    public static bool beatLevel = false;
    public static bool isPlayerDead = false;
    private Sanya player;
    private Boss boss;
    private float maxFillAmount;
    public Image hpImage;

    public GameObject humanity;
    private AudioSource audio;
    private Animator humanityAnimator;
    public GameObject DeathContainer;
    public AudioClip winClip, deathClip, backGroundClip;
    public Transform startSpawnPosition;
    public static Vector2? spawnPosition;

   
    private bool youddied = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = gameObject.GetComponent<GameManager>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static GameManager GetInstance()
    {
        return instance;
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Sanya>();
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
        audio = GameObject.FindGameObjectWithTag("Background").GetComponent<AudioSource>();
        startSpawnPosition = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>();
        maxFillAmount = boss.hp;
        humanityAnimator = humanity.GetComponent<Animator>();
        humanityAnimator.enabled = false;
        humanity.SetActive(false);
        DeathContainer.SetActive(false);
        isPlayerDead = false;
        audio.clip = backGroundClip;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInBossRoom)
        {
            hpImage.gameObject.SetActive(true);
            hpImage.fillAmount = boss.hp / maxFillAmount;
        }
        else
        {
            hpImage.gameObject.SetActive(false);
        }
        if (isPlayerDead)
        {
            Time.timeScale = 0;
            DeathContainer.SetActive(true);
            if (!youddied)
            {
                audio.clip = deathClip;
                audio.Play();
                youddied = true;
            }
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (beatLevel)
        {
            audio.loop = false;
            audio.clip = winClip;
            audio.Play();
            humanity.SetActive(true);
            humanityAnimator.enabled = true;
           // audio.PlayOneShot(winClip);
            beatLevel = false;
        }
        //if (isGameOver && Input.GetKeyDown("1"))
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
    }

    //public void GameOver()
    //{
    //    infoText.text = "GAME OVER - PRESS 1 TO RESET ";
    //    isGameOver = true;
    //}

    public void Respawn()
    {
        Debug.Log(spawnPosition);

        
        if (spawnPosition != null)
        {
          player.transform.position = spawnPosition.Value;
        }
        else
        {
          player.transform.position = startSpawnPosition.transform.position;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isPlayerDead = false;
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
    
}
