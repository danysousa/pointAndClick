using UnityEngine;
using System.Collections;

public class Bomber : MonoBehaviour
{
	public float	speed;
	public Vector3	direction;
	public int		bombNum;
	public float	minDropInterval;
	public float	maxDropInterval;

	public GameObject bomb;

	private float	lastDrop;
	private float	nextDrop;
	private int		dropedBomb;

	// Use this for initialization
	void Start ()
	{
		lastDrop = Time.realtimeSinceStartup;
		nextDrop = 0;
		dropedBomb = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ( dropedBomb >= bombNum )
		{
			DestroyImmediate( this.gameObject );
			return ;
		}
		this.transform.position += direction.normalized * speed;
		if ( Time.realtimeSinceStartup > nextDrop )
		{
			Instantiate( bomb, this.transform.position + new Vector3( Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5) ), Quaternion.identity );
			lastDrop = Time.realtimeSinceStartup;
			dropedBomb++;
			nextDrop = lastDrop + Random.Range( minDropInterval, maxDropInterval );
		}
	}

	void setSpeed( float speed )
	{
		this.speed = speed;
	}

	void setDirection( Vector3 direction )
	{
		this.direction = direction;
	}
}
