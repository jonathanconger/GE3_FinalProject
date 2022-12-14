using UnityEngine;

public class WindHazard : MonoBehaviour
{
	[SerializeField] public float windSpeed = 10f;
	[SerializeField] public bool affectsArrows = true;
    [SerializeField] public bool affectsPlayer = false;

	private void OnTriggerStay2D(Collider2D collision)
	{
		// wind for arrows
		if (affectsArrows && collision.CompareTag("Arrow"))
		{
			collision.GetComponent<Rigidbody2D>().AddForce(transform.up * windSpeed * Time.deltaTime, ForceMode2D.Impulse);
		}

		// wind for player
		if (affectsPlayer && collision.CompareTag("Player"))
		{
			collision.GetComponent<Rigidbody2D>().AddForce(transform.up * windSpeed * Time.deltaTime, ForceMode2D.Impulse);
		}
	}
}
