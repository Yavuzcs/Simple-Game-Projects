using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake_Controller : MonoBehaviour
{
    private Vector2 direction;

    [SerializeField] private GameObject TailPrefab;

    private List<GameObject> _Tail = new List<GameObject>();
    void Start()
    {
        Reset();
        ResetTail();
    }

    
    void Update()
    {
        Movement();
    }

    private void FixedUpdate()
    {
        SnakeMove();
        MoveTail();
    }

    public void CreateTail()
    {
        GameObject newTail = Instantiate(TailPrefab);
        newTail.transform.position = _Tail[_Tail.Count - 1].transform.position;
        _Tail.Add(newTail);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void SnakeMove()
    {
        float x, y;
        x = transform.position.x + direction.x;
        y = transform.position.y + direction.y;

        transform.position = new Vector2(x, y);
    }

    private void Movement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }

    }
    private void Reset()
    {
        direction = Vector2.right;
        Time.timeScale = 0.1f;
    }

    private void ResetTail()
    {
        for (int i = 1; i < _Tail.Count; i++)
        {
            Destroy(_Tail[i]);
        }

        _Tail.Clear();
        _Tail.Add(gameObject);

        for (int i = 0; i < 3; i++)
        {
            CreateTail();
        }
    }


    private void MoveTail()
    {
        for (int i = _Tail.Count - 1; i > 0; i--)
        {
            _Tail[i].transform.position = _Tail[i - 1].transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            RestartGame();
        }
    }
}
