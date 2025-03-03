using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;


public class CharacterController : MonoBehaviour
{
    public Rigidbody2D myRidgidBody;
    public float jumpforce = 10;
    public GameStateManager logic;
    private bool birdIsAlive = true;
    AudioManager audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            Jump();
            audioManager.PlaySFX(audioManager.jump);
        }

        if (transform.position.y > 17 || transform.position.y < -20)
        {
            if (birdIsAlive)
            {
                logic.gameOver();
                birdIsAlive = false;
                audioManager.PlaySFX(audioManager.endGame);
            }
        }
    }

    void Jump()
    {
        //player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * jumpforce;
        myRidgidBody.linearVelocity = Vector2.up * jumpforce;
    }
    private void Awake (){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public bool getBirdAlive(){
        return birdIsAlive;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
       logic.gameOver();
       birdIsAlive = false;
       audioManager.PlaySFX(audioManager.endGame);
    }
}
