using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private int count;
    public Text countText;
    public Text winText;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D> ();
       count = 0;
       winText.text = " ";
       SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKey("escape"))
     Application.Quit();  
    }
    void FixedUpdate()
    {
        float movehorizontal = Input.GetAxis ("Horizontal");
        float movevertical = Input.GetAxis ("Vertical");

        Vector2 movement = new Vector2 (movehorizontal, movevertical);
        rb.AddForce(movement* speed);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
    if (other.gameObject.CompareTag ("Pickup"))
    {
        other.gameObject.SetActive (false);
        count = count + 1;
        SetCountText();
    }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}
