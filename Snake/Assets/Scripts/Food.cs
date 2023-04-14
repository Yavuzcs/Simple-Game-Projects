using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private Snake_Controller Snake;
    [SerializeField] private float minX, maxX, minY, maxY;
    void Start()
    {
        RandomFoodPosition();
    }


    private void RandomFoodPosition()
    {
        transform.position = new Vector2(
            Mathf.Round(Random.Range(minX, maxX)) + 0.5f,
            Mathf.Round(Random.Range(minY, maxY)) + 0.5f
            );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Snake"))
        {
            RandomFoodPosition();
            Snake.CreateTail();
        }
    }
}
