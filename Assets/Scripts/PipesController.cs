using UnityEngine;
using UnityEngine.Rendering;

public class PipesController : MonoBehaviour
{
    public float moveSpeed = 5;
    public int deadSpace = -45;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = transform.position + ((Vector3.left * moveSpeed) * Time.deltaTime);
        
        if (transform.position.x < deadSpace) 
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}
