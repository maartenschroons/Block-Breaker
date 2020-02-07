
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 0f;
    [SerializeField] float yPush = 0f;
    [SerializeField] float RandomVelocity = 0.2f;
    Rigidbody2D myrigidBody2D;
    Vector2 paddleToBallVector;

    bool launched = false;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myrigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!launched)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myrigidBody2D.velocity = new Vector2(xPush, yPush);
            launched = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Vector2 velocityTweak = new Vector2(
            Random.Range(0f, RandomVelocity),
            Random.Range(0f, RandomVelocity)
            );
        if (launched)
        {
            GetComponent<AudioSource>().Play();
            myrigidBody2D.velocity += velocityTweak;
        }
    }
}
