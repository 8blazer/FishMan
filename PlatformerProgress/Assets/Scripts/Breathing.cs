using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Breathing : MonoBehaviour
{
    Animator animator;
    public static int oxygen;
    public bool inWater;
    float timer = 0;
    public Text oxygenText;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "FirstLevel")
        {
            oxygen = 30;
            inWater = false;
        }
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oxygen == 30)
        {
            animator.speed = .1f;
        }
        else if (oxygen > 25)
        {
            animator.speed = .2f;
        }
        else if (oxygen > 20)
        {
            animator.speed = .3f;
        }
        else if (oxygen > 15)
        {
            animator.speed = .4f;
        }
        else if (oxygen > 10)
        {
            animator.speed = .5f;
        }
        else if (oxygen > 5)
        {
            animator.speed = .6f;
        }
        else
        {
            animator.speed = .7f;
        }
        if (inWater == false)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                oxygen--;
                if (oxygen == 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                timer = 0;
            }
        }
        if (inWater && oxygen < 30)
        {
            oxygen++;
        }
        oxygenText.text = oxygen.ToString();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            inWater = true;
            timer = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Water")
        {
            inWater = false;
        }
    }
}
