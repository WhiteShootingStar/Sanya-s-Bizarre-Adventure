using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformLast : MonoBehaviour
{
    private float timeToExistOrDissapear;
    private bool isPresent;
    public float timeToChange = 2f;
    private SpriteRenderer renderer;
    private Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        isPresent = true;
        timeToExistOrDissapear = timeToChange;
        renderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        timeToExistOrDissapear -= Time.deltaTime;
        if (timeToExistOrDissapear <= 0f)
        {
            sleep(isPresent);
            timeToExistOrDissapear = timeToChange;
        }



    }

    void sleep(bool exists)
    {

        if (isPresent)
        {
            renderer.enabled = false;
            col.enabled = false;
            isPresent = false;

        }
        else
        {
            renderer.enabled = true;
            col.enabled = true;
            isPresent = true;

        }
    }
}
