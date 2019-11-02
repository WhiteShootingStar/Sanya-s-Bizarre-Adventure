using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossZone : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Camera camera;
    private float cameraPrevState;
    public GameObject wall;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        cameraPrevState = camera.orthographicSize;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            ChangeCamera();
            collision.gameObject.GetComponent<Sanya>().Jumpspeed = 50;
            GameManager.isInBossRoom = true;
            wall.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            ChangeCameraBack();
            collision.gameObject.GetComponent<Sanya>().Jumpspeed = 30;
            GameManager.isInBossRoom = false;
        }
    }

    void ChangeCamera()
    {
        camera.orthographicSize = boxCollider.size.y / 1.7f;
        camera.gameObject.GetComponent<FollowCamera>().follow = false;
        camera.transform.position = boxCollider.bounds.center;
    }
    void ChangeCameraBack()
    {
        camera.orthographicSize = cameraPrevState;
        camera.gameObject.GetComponent<FollowCamera>().follow = true;
    }
}
