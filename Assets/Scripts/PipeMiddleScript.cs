using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public GameStateManager logic; //game logic reference

  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == 3){
            logic.AddPoint(1);
        }
    }
}
