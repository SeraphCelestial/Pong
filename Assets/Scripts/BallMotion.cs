using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallMotion : MonoBehaviour
{
    public float intVX;
    public float intVY;
    private float vX;
    private float vY;
    private float y;
    private int LeftScore;
    private int RightScore;

    Vector2 velocityVector;
    Rigidbody2D rb;
    public Text Player1Score;
    public Text Player2Score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocityVector = new Vector2(intVX, intVY);
        rb.velocity = velocityVector;
        y = Random.Range(4.5f, -4.5f);
    }

    void Update()
    {
        if (LeftScore == 15)
        {
            SceneManager.LoadScene("LeftWin");
        }

        if (RightScore == 15)
        {
            SceneManager.LoadScene("RightWin");
        }
    }

    private void PickNewVelocity()
    {
        Vector2 v;
        do
        {
            vX = Random.Range(10.0f, -10.0f);
            vY = Random.Range(10.0f, -10.0f);
            v = new Vector2(vX, vY);
        } while (v.magnitude < 5);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LeftBoundary")
        {
            RightScore++;
            transform.position = new Vector3(0.0f, y, 0.0f);
            PickNewVelocity();
            rb.velocity = new Vector2(vX, vY);
            Player2Score.text = RightScore.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RB")
        {
            LeftScore++;
            transform.position = new Vector3(0.0f, y, 0.0f);
            PickNewVelocity();
            rb.velocity = new Vector2(vX, vY);
            Player1Score.text = LeftScore.ToString();
        }
    }
}
