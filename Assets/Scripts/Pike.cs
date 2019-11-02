using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pike : MonoBehaviour
{
    private GameObject Player;
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(gameObject.transform.position, Player.transform.position) >2f)
        {
            Disable();
        }
        else
        {
            Enable();
        }
    }

    private void Disable()
    {   
        spriteRenderer.enabled = false;
        polygonCollider.enabled = false;
    }
    private void Enable()
    {
        spriteRenderer.enabled = true;
        polygonCollider.enabled = true;
    }
}
