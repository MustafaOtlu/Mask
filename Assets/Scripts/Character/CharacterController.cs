using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public float speed = 5f;
    public  bool canMove = true;
    int IlerlemeIndex;
    public Text txt;





    void Update()
    {
        IlerlemeIndex = PlayerPrefs.GetInt("IlerlemeIndex", 1);
        if (txt != null) { txt.text = ("Level : " + IlerlemeIndex).ToString(); }
        

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
        if (!Input.GetKey(KeyCode.E))
            return;

        if (other.CompareTag("LVL_1") && IlerlemeIndex == 2)
        {
            SceneManager.LoadScene(2);
        }
        else if (other.CompareTag("LVL_2") && IlerlemeIndex == 3)
        {
            SceneManager.LoadScene(3);
        }
        else if (other.CompareTag("LVL_3") && IlerlemeIndex == 4)
        {
            SceneManager.LoadScene(4);
        }

    }

}
