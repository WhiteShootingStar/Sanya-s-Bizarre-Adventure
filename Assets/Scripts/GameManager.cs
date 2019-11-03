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
    private AbstractBoss boss;
    private float maxFillAmount;
    public Image hpImage;

    public GameObject humanity;
    private AudioSource audio;
    private Animator humanityAnimator;
    public GameObject DeathContainer;
    public AudioClip winClip, deathClip, backGroundClip;
    public Transform startSpawnPosition;
    public static Vector2? spawnPosition;
    public int nextSceneIndex;
   
    private bool youddied = false;

    public GameObject[] toDestroy;

    public static Vector3 Spawn;
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
       
            boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<AbstractBoss>();
        
        
        
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

        Debug.Log(maxFillAmount + " Is max hp");
    }

    // Update is called once per frame
    void Update()
    {
        if (isInBossRoom)
        {
            hpImage.gameObject.SetActive(true);
            hpImage.fillAmount = boss.hp / maxFillAmount;

            Debug.Log(maxFillAmount);
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
            Invoke("NextLevel",8f);
        }
        //if (isGameOver && Input.GetKeyDown("1"))
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
    }

    

    public void Respawn()
    {
        Debug.Log(spawnPosition);

        
        if (spawnPosition != null)
        {
          player.transform.position = spawnPosition.Value;
            Spawn = spawnPosition.Value;
        }
        else
        {
          player.transform.position = startSpawnPosition.transform.position;
            Spawn = startSpawnPosition.transform.position;
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isPlayerDead = false;
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
    void NextLevel()
    {
       Debug.Log( SceneManager.sceneCountInBuildSettings + " available scenes");
      //  DestroyAll();
        SceneManager.LoadScene(nextSceneIndex);
        player.transform.position = spawnPosition.Value;
        player.Jumpspeed = 30;
    }
    void DestroyAll()
    {
        for(int i=0; i < toDestroy.Length; i++)
        {
           
            SceneManager.MoveGameObjectToScene(toDestroy[i], SceneManager.GetSceneByBuildIndex(nextSceneIndex));
           // Destroy(toDestroy[i]);
        }
    }
}
