using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorRed;
    public Color colorPurple;

    void Start()
    {
        SetRandomColor();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) 
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(col.gameObject);
            return;
        }

        if (col.tag != currentColor)
        {
            Debug.Log("Destroy");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void SetRandomColor() 
    {
        int index = Random.Range(0,4);

        switch (index)
        {
            case 0:
            currentColor = "Cyan";
            sr.color = colorCyan;
            break;
            case 1:
            currentColor = "Yellow";
            sr.color = colorYellow;
            break;
            case 2:
            currentColor = "Red";
            sr.color = colorRed;
            break;
            case 3:
            currentColor = "Purple";
            sr.color = colorPurple;
            break; 
        }
    }
}
