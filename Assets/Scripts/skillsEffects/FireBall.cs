using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	public GameObject	prefabExplosion;
	public int damage = 30;

	// Use this for initialization
	void Start () {
		GameObject explosion = Instantiate( prefabExplosion, transform.position, Quaternion.identity ) as GameObject;
		StartCoroutine( KillOnAnimationEnd( explosion ) );
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter( Collider col )
	{
		if ( col.gameObject.tag == "Ennemy" )
		{

			Humanoid h = col.gameObject.GetComponent<Humanoid>();
			h.receiveDamage( (int)( damage ) );
		}
	}

	private IEnumerator KillOnAnimationEnd( GameObject explosion )
	{
		yield return new WaitForSeconds( 5f );
		Destroy( explosion );
		GameObject.Destroy( this.gameObject );
	}
}
