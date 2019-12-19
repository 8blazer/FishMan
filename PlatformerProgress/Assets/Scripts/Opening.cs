using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Opening : MonoBehaviour
{
    public GameObject warning;
    public GameObject boulder;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            warning.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (timer > 4)
        {
            warning.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (timer > 5)
        {
            boulder.GetComponent<SpriteRenderer>().enabled = true;
            boulder.GetComponent<Rigidbody2D>().AddTorque(10);
            boulder.GetComponent<Rigidbody2D>().velocity = new Vector3(-10, 0, 0);
        }
        if (timer > 5.75f)
        {
            SceneManager.LoadScene("FirstLevel");
        }
    }
}
