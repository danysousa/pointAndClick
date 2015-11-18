using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

	public GameObject	prefabExplosion;
	public int damage = 100;

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
			Debug.Log("##AIE##"+(int)( damage * (PlayerManager.instance.player.getLevel()+1) ));
			h.receiveDamage( (int)( damage * (PlayerManager.instance.player.getLevel()+1) ) );
		}
	}

	private IEnumerator KillOnAnimationEnd( GameObject explosion )
	{
		yield return new WaitForSeconds( 5f );
		Destroy( explosion );
		GameObject.Destroy( this.gameObject );
	}
}
