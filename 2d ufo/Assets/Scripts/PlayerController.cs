using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public Text countText;
    public Text winText;
    private int count;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        setText();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement*speed);



    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("pickup"))
        {
            col.gameObject.SetActive(false);
            count = count + 1;
            setText();
        }
        
    }
    void setText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "You Win";
        }
  
    }
}
