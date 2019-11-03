using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdekBoss : AbstractBoss
{
    public Transform startPlace, endPlace;
    private Vector2 endPlaceConst;
    public Vector2 direction;
    public float moveSpeed;
    private float maxDistance;
    public Animator animator;
    public Transform edekShootPoint;
    private GameObject player;
    public GameObject MSI;
    private bool isInsideCoroutine = false;
    private void Awake()
    {
        endPlaceConst = new Vector2(endPlace.transform.position.x, endPlace.transform.position.y);
        hp = Vector2.Distance(transform.position, endPlaceConst);
    }
    // Start is called before the first frame update

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isInBossRoom)
        {
            float DistanceToFinish = Vector2.Distance(transform.position, endPlaceConst);

            hp = DistanceToFinish;
            moveSpeed += Time.deltaTime / 10f;
            if (hp > 5)
            {
                transform.Translate(direction * moveSpeed * Time.deltaTime);
            }
            if (hp <= 5)
            {
                hp = 0;
                GameManager.beatLevel = true;
                animator.SetTrigger("Die");
                //  gameObject.SetActive(false);
            }
            Debug.Log(isInsideCoroutine);
            if (!isInsideCoroutine)
            {
                StartCoroutine(EdekShoot());
            }
        }
    }


    private IEnumerator EdekShoot()
    {
        isInsideCoroutine = true;
        
        yield return new WaitForSeconds(3f);
        animator.SetTrigger("Shoot");
        Vector3 dir = player.transform.position - edekShootPoint.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        edekShootPoint.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Instantiate(MSI, edekShootPoint.transform.position, edekShootPoint.transform.rotation);

        isInsideCoroutine = false;
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
