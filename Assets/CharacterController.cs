using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]

public class CharacterController : MonoBehaviour
{

	public float speed = 1.5f; // �������� ��������
	public float acceleration = 100; // ���������
	public float jumpForce = 5; // ���� ������
	public float jumpDistance = 0.75f; // ���������� �� ������ �������, �� ����������� (������������ ������� � ����������� �� �������� �������)
	public bool facingRight = true; // � ����� ������� ������� �������� �� ������?
	public KeyCode jumpButton = KeyCode.Space; // ������� ��� ������
	public float HP;

	private Vector3 direction;
	private int layerMask;
	private Rigidbody2D body;

	void Start()
	{
		body = GetComponent<Rigidbody2D>();
		body.freezeRotation = true;
		layerMask = 1 << gameObject.layer | 1 << 2;
		layerMask = ~layerMask;
	}

	bool GetJump() // ���������, ���� �� ��������� ��� ������
	{
		bool result = false;

		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, jumpDistance, layerMask);
		if (hit.collider)
		{
			result = true;
		}

		return result;
	}

	void FixedUpdate()
	{
		body.AddForce(direction * body.mass * speed * acceleration);

		if (Mathf.Abs(body.velocity.x) > speed)
		{
			body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed, body.velocity.y);
		}
	}

	void Flip() // ��������� �� �����������
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void Update()
	{
		Debug.DrawRay(transform.position, Vector3.down * jumpDistance, Color.red); // ���������, ��� ���������� ��������� jumpDistance

		if (Input.GetKeyDown(jumpButton) && GetJump())
		{
			body.velocity = new Vector2(0, jumpForce);
		}

		float h = Input.GetAxis("Horizontal");

		direction = new Vector2(h, 0);

		if (h > 0 && !facingRight) Flip(); else if (h < 0 && facingRight) Flip();
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Enemy")
		    HP -= 50;
	
	    if(HP <= 0)
	
		Application.LoadLevel("Death");
	}
}