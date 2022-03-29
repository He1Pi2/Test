using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hold : MonoBehaviour
{
    public bool hold2;
    public float distanse = 3f;
    RaycastHit2D hit;
    public Transform holdPoint;
    public float throwObject = 5f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!hold2)
            {
                Physics2D.queriesStartInColliders = false;
                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distanse);

                if (hit.collider != null && hit.collider.tag == "zapiska")
                {
                    hold2 = true;
                }
            }
            else
            {
                hold2 = false;
                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null && hit.collider.tag == "zapiska")
                {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwObject;
                }
            }
        }
        if (hold2)
        {
            hit.collider.gameObject.transform.position = holdPoint.position;
        }
    }
    private void onDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distanse);
    }
}
