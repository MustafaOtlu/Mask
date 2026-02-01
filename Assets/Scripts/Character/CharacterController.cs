using UnityEngine.SceneManagement;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5f;
    public  bool canMove = true;




    void Update()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);

            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }

            Vector2 tr = transform.position;

            tr.x = Mathf.Clamp(tr.x, -34, 78);
            tr.y = Mathf.Clamp(tr.y, -41, 24);

            transform.position = tr;
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LVL_1"))
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                SceneManager.LoadScene(1);
            }
        }
        if (other.gameObject.CompareTag("LVL_2"))
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                SceneManager.LoadScene(3);
            }
        }
        if (other.gameObject.CompareTag("LVL_3"))
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                SceneManager.LoadScene(4);
            }
        }
        if (other.gameObject.CompareTag("LVL_4"))
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                SceneManager.LoadScene(5);
            }
        }
        if (other.gameObject.CompareTag("LVL_5"))
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                SceneManager.LoadScene(6);
            }
        }
    }
}
