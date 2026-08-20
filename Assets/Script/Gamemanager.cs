using UnityEngine;
using UnityEngine.InputSystem;

public class Gamemanager : MonoBehaviour
{


    [SerializeField]
    private int playerScore;
    public int PlayerScore { get { return playerScore; } set { playerScore = value; } }

    [SerializeField]
    private GameObject[] ballPositions;

    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private GameObject cueBall;

    [SerializeField]
    private GameObject BallLine;

    [SerializeField]
    private GameObject cam;

    [SerializeField]
    private float xInput = 0f;

    public static Gamemanager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;

    }

    // Update is called once per frame
    void Start()
    {
        SetBall(BallColor.Red, 1);
        SetBall(BallColor.Yellow, 2);
        SetBall(BallColor.Green, 3);
        SetBall(BallColor.Brown, 4);
        SetBall(BallColor.Blue, 5);
        SetBall(BallColor.Pink, 6);
        SetBall(BallColor.Black, 7);

        CameraBehindCueball();
    }

    void Update()
    {
        RotateBall();

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            ShootBall();

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            xInput = -0.1f;

        else if (Keyboard.current.aKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            xInput = 0.1f;

        else 
            xInput = 0f; 

        if (Keyboard.current.backspaceKey.wasPressedThisFrame)
            StopBall();

    }

    private void SetBall(BallColor col,int i)
    {
       GameObject obj= Instantiate(ballPrefab, 
            ballPositions[i].transform.position, 
            Quaternion.identity );

        Ball b = obj.GetComponent<Ball>();
        b.SetColorAndPoint(col);
    }

    private void ShootBall()
    {
        Rigidbody rb = cueBall.GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * 50, ForceMode.Impulse);
        BallLine.SetActive(false);

        cam.transform.parent = null;
        cam.transform.position = new Vector3(0f, 30f,-42f);
        cam.transform.eulerAngles = new Vector3(45f, 0f, 0f);
    }

    private void RotateBall()
    {
        if (cueBall != null)
            cueBall.transform.Rotate(0f, xInput, 0f);
    }
    private void StopBall()
    {
       Rigidbody rb = cueBall.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        cueBall.transform.eulerAngles = new Vector3 (0f, 0f, 0f);
        BallLine.SetActive(true);
        CameraBehindCueball();
    }

    private void CameraBehindCueball()
    {
        cam.transform.parent = cueBall.transform;
        cam.transform.position = cueBall.transform.position + new Vector3(0f, 7f, -15f);
        cam.transform.eulerAngles = new Vector3(30f, 0f, 0f);
    }
}



