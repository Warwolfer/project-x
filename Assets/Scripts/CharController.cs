using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 4f;
    [SerializeField]
    bool facingLeft = true;
    Vector3 forward, right;
    bool isMoving = false;
    Collider itemInRange;
    public bool IsMoving { get => isMoving; set => isMoving = value; }
    TMPro.TextMeshPro charText;

    // Start is called before the first frame update
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        charText = GetComponentInChildren<TMPro.TextMeshPro>();
        charText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       

    }


    public void Move(float horizontal, float vertical)
    {
        IsMoving = true;
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * horizontal;
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * vertical;

        if (rightMovement.x > 0)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }


        transform.position += rightMovement + upMovement;
    }

    public void PickUp()
    {
        if(itemInRange != null)
        {
            GetComponentInChildren<Animator>().Play("KamaPick");
            itemInRange.gameObject.SetActive(false);
            saySomething("Aku menemukan [" + itemInRange.gameObject.name + "]");
            itemInRange = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            itemInRange = other;
        }

        if (other.gameObject.CompareTag("Room"))
        {
            StartCoroutine(other.GetComponent<Room>().FadeIn());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            itemInRange = null;
        }

        if (other.gameObject.CompareTag("Room"))
        {
            StartCoroutine(other.GetComponent<Room>().Fade());
        }
    }

    public void saySomething(string text){
        StartCoroutine(makeTextAppear(text, 2f));
    }

    IEnumerator makeTextAppear(string text, float duration){
        charText.gameObject.SetActive(true);
        charText.text = text;
        yield return new WaitForSeconds(2f);
        charText.gameObject.SetActive(false);
        yield return null;
    }

}
