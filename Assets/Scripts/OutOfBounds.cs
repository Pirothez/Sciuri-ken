using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] GameObject playerSpawnPoint;

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        if (collision.gameObject.CompareTag("Flower"))
        {
            int index = Random.Range(1, 40);

            string strindex = index.ToString();
            if (gameObject != null && GameManager.gameOver == false)
            {
                Instantiate(Resources.Load("lotus_" + strindex), playerSpawnPoint.transform.position, Quaternion.identity);
            }
        }
    }
}
