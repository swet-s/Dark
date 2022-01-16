using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering.Universal;

public class Controller : MonoBehaviour
{

	public float speed = 5f;
	public Vector2 jumpSpeed = new Vector2(5f, 9f);
	public bool jumpAvailable = false;
	public bool isUnderWater = false;
	public Light2D lightCircle;
	public Light2D pointLight;
	[HideInInspector]
	public float movementX = 0f;
	[HideInInspector]
	public float movementY = 0f;
	private Joystick joy;
	private Rigidbody2D rb;

	public void IsUnderWater(bool say)
    {
		isUnderWater = say;
    }

	private void Awake()
	{
		// Load the controller
		GameObject canvas = Resources.Load<GameObject>("CanvasPrefab");
		GameObject clone = Instantiate(canvas);
		Button jumpButton = clone.GetComponentInChildren<Button>();

		//jumpButton.onClick.AddListener(() => { Jump(false); });

		// Better for touch inputs
		EventTrigger trigger = clone.GetComponentInChildren<EventTrigger>();
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerDown;
		entry.callback.AddListener((data) => { Jump(); });
		trigger.triggers.Add(entry);

		joy = clone.GetComponentInChildren<Joystick>();

	}

    void Start()
	{
		lightCircle.intensity = 2;
		int playerIndex = PlayerPrefs.GetInt("PlayerIndex", 1);
		rb = GetComponent<Rigidbody2D>();
		PlayerSprite.ChangeSprite(gameObject, playerIndex);
		if (playerIndex == 0)
		{
			lightCircle.color = new Color(0.5f, 0.5f, 0.2f, 1.0f);
			pointLight.color = new Color(0.5f, 0.5f, 0.2f, 1.0f);
		}
		if (playerIndex == 1)
		{
			lightCircle.color = new Color(0.2f, 0.3f, 1.0f, 1.0f);
			pointLight.color = new Color(0.2f, 0.5f, 1.0f, 1.0f);
		}
		else if (playerIndex == 2)
		{
			GameObject bow = Resources.Load<GameObject>("Bow");
			GameObject bowCopy = Instantiate(bow, transform.position, Quaternion.identity);
			bowCopy.GetComponent<Bow>().player = transform;
			lightCircle.color = new Color(0.5f, 0.2f, 1.0f, 1.0f);
			pointLight.color = new Color(0.5f, 0.2f, 1.0f, 1.0f);
		}
		if (isUnderWater)
        {
			GameObject dive = Resources.Load<GameObject>("Dive");
			GameObject diveCopy = Instantiate(dive, transform.position, Quaternion.identity);
			diveCopy.GetComponent<Dive>().player = transform;
		}
	}


	void Update()
	{
		movementX = joy.Horizontal;
		movementY = joy.Vertical;
		if (movementX != 0f)
		{
			rb.velocity = new Vector2(movementX * speed, rb.velocity.y);
		}
		if (rb.gravityScale == 0 || isUnderWater)
        {
			if (movementY != 0f)
			{
				rb.velocity = new Vector2(rb.velocity.x, movementY * speed);
			}
			rb.velocity = new Vector2(rb.velocity.x, movementY * speed);
		}

		if (joy.Vertical > 0.4f)
		{
			Jump();
		}

		//if (joy.Vertical < -0.8f)
		//{
		//	rb.velocity = new Vector2(rb.velocity.x, movementY * speed);
		//}

	}

    private void FixedUpdate()
	{
		if (rb.velocity.y < 0)
		{
			rb.gravityScale = 2.5f;
		}
		else if (rb.velocity.y > 0)
		{
			rb.gravityScale = 2.0f;
		}
        else
        {
			rb.gravityScale = 1f;
        }
	}

    public void Jump()
    {
		if (jumpAvailable)
		{
			FindObjectOfType<AudioCreater>().PlayJump();
			rb.velocity = new Vector2(rb.velocity.x, jumpSpeed.y*1.4f);
			//rb.AddForce(Vector2.up * jumpSpeed.y, ForceMode2D.Impulse);
			jumpAvailable = false;
		}
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.layer == 8)
		{
			jumpAvailable = true;
		}
	}

}
