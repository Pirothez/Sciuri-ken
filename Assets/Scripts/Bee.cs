using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Bee : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] int direction = 1;
    [SerializeField] float xBounds = 4f;
    [SerializeField] int pointsGranted = 5;

    private void Update()
    {
        if (transform.position.x < -xBounds || transform.position.x > xBounds)
        {
            Destroy(gameObject);
            LoseHealth();
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed * direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flower"))
        {
            collision.rigidbody.simulated = false;

            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);

            GameObject.Find("Player").GetComponent<Level1>().UpdateScore(pointsGranted);

            Destroy(gameObject, 1f);
        }
    }
    void LoseHealth()
    {
        if (GameObject.Find("Hearts") != null)
        {
            GameObject health = GameObject.Find("Hearts");
            if (health.transform.GetChild(8).gameObject.activeSelf)
            {
                health.transform.GetChild(8).gameObject.SetActive(false);
                health.transform.GetChild(9).gameObject.SetActive(true);
            }
            else if (health.transform.GetChild(6).gameObject.activeSelf)
            {
                health.transform.GetChild(6).gameObject.SetActive(false);
                health.transform.GetChild(7).gameObject.SetActive(true);
            }
            else if (health.transform.GetChild(4).gameObject.activeSelf)
            {
                health.transform.GetChild(4).gameObject.SetActive(false);
                health.transform.GetChild(5).gameObject.SetActive(true);
            }
            else if (health.transform.GetChild(2).gameObject.activeSelf)
            {
                health.transform.GetChild(2).gameObject.SetActive(false);
                health.transform.GetChild(3).gameObject.SetActive(true);
            }
            else if (health.transform.GetChild(0).gameObject.activeSelf)
            {
                health.transform.GetChild(0).gameObject.SetActive(false);
                health.transform.GetChild(1).gameObject.SetActive(true);

                GameObject.Find("Player").GetComponent<Level1>().GameOver();
                Debug.Log("The bee activated GameOver in Level1");
            }
        }
    }



}
