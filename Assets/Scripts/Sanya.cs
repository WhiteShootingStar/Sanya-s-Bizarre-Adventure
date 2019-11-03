using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sanya : MonoBehaviour
{
    public float Movespeed = 20;
    public float Jumpspeed = 10;
    public bool CanJump = true;
    public bool facingRight = true;

    private Rigidbody2D rigidbody2d;

    public GameObject Bullet, BulletSpawnPosition;
    public Transform startSpawnPosition;
    public static Vector2? spawnPosition;
    [SerializeField] private Animator animator;
    public bool GODMODE = false;
    // Start is called before the first frame update


    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");

        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        GameManager.isInBossRoom = false;
        
    }



    void Start()
    {
        //GameManager.GetInstance().startSpawnPosition = startSpawnPosition;
        // GameManager.GetInstance().spawnPosition = spawnPosition;
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.velocity = Vector2.zero;
        Jumpspeed = 30;
        Debug.Log(Jumpspeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.isPlayerDead)
        {
            //float xDisplacement = Input.GetAxis("Horizontal") * Movespeed * Time.deltaTime*100;
            //rigidbody2d.velocity = new Vector2(xDisplacement, rigidbody2d.velocity.y);
            Move();
            Shoot();
        }
       
       
        animator.SetFloat("velocity.y", rigidbody2d.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Terrain"))
        {
            CanJump = true;
            animator.SetTrigger("grounded");
            Debug.Log("Grounded");
        }
        if (collision.tag.Equals("Danger") || collision.tag.Equals("PCH") || collision.tag.Equals("Boss"))
        {
            if (!GODMODE)
            {
                Die();
                GameManager.isPlayerDead = true;
            }
            // transform.position = SpawnPosition.transform.position;
          
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {

            transform.Translate(Vector2.left * Movespeed * Time.deltaTime, Space.World);
            if (facingRight)
            {

                transform.Rotate(Vector2.up * 180);
                facingRight = false;
            }
            animator.SetBool("IsMoving", true);
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2d.
            transform.Translate(Vector2.right * Movespeed * Time.deltaTime, Space.World);
            if (!facingRight)
            {
                transform.Rotate(Vector2.up * 180);
                facingRight = true;
            }
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && CanJump)
        {
            rigidbody2d.AddForce(Vector2.up * Jumpspeed, ForceMode2D.Impulse);
            CanJump = false;
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Bullet, BulletSpawnPosition.transform.position, BulletSpawnPosition.transform.rotation);
        }
    }
    void Die()
    {
        //transform.position = GameManager.Spawn;
        //Debug.Log(spawnPosition);

        //// SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //if (spawnPosition != null)
        //{
        //    transform.position = spawnPosition.Value;
        //}
        //else
        //{
        //    transform.position = startSpawnPosition.transform.position;
        //}

    }

    public static void SetSpawnPosition(Vector2 position)
    {
        spawnPosition = position;
    }
}
