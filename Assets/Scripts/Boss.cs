using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : AbstractBoss
{
    
    public GameObject[] appearPosition;
    public GameObject pietiaShotSpawn, pietiaShot;
    private bool isInsideCoroutine = false;
    private Animator animator;
    public GameObject player;
    private bool halfHP = false, summonedPCHs = false;
    public GameObject[] PCHs;
    // Start is called before the first frame update
    void Start()
    {
        hp = 1500;
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isInBossRoom && !isInsideCoroutine)
        {
            StartCoroutine(ShootAndMove());
        }
        if (hp <= 750)
        {
            animator.enabled = true;
            halfHP = true;
        }

        if (hp <= 0)
        {
            animator.SetTrigger("Dead");
            UnsummonPCH();

            GameManager.beatLevel = true;

        }
    }

    private IEnumerator ShootAndMove()
    {
        isInsideCoroutine = true;
        if (halfHP)
        {
            yield return new WaitForSeconds(0.75f);
            if (!summonedPCHs)
            {
                SummonPCH();
                summonedPCHs = true;
            }
        }
        else
        {
            yield return new WaitForSeconds(1f);
        }
        Vector3 dir = player.transform.position - pietiaShotSpawn.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        pietiaShotSpawn.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Instantiate(pietiaShot, pietiaShotSpawn.transform.position, pietiaShotSpawn.transform.rotation);
        gameObject.transform.position = getRandomposition();
        isInsideCoroutine = false;
    }

    private Vector2 getRandomposition()
    {
        var randomPosition = appearPosition[Random.Range(0, appearPosition.Length)].transform.position;
        Debug.Log("Will respawn at " + randomPosition);
        return randomPosition;
    }

    void SummonPCH()
    {
        for (int i = 0; i < PCHs.Length; i++)
        {
            PCHs[i].SetActive(true);
        }
    }

    void UnsummonPCH()
    {

        for (int i = 0; i < PCHs.Length; i++)
        {
            PCHs[i].SetActive(false);
        }

    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
