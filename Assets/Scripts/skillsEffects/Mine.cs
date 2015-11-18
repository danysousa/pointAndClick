using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	public GameObject	prefabExplosion;
	private float		maxDammage = 100f;
	
	private SphereCollider	_explosionRange;
	private MeshRenderer	_mesh;
	private bool			_hasExploded;
	
	// Use this for initialization
	void Start () 
	{
		_explosionRange = this.GetComponent<SphereCollider>();
		_mesh = this.GetComponent<MeshRenderer>();
		_hasExploded = false;
		_explosionRange.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	private void startExplosion()
	{
		if ( _hasExploded )
			return ;
		GetComponentInChildren<Light> ().enabled = false;
		_hasExploded = true;
		GameObject explosion = Instantiate( prefabExplosion, transform.position, Quaternion.identity ) as GameObject;
		StartCoroutine( KillOnAnimationEnd( explosion ) );
		_explosionRange.enabled = true;
		_mesh.enabled = false;
	}
	
	void OnTriggerEnter( Collider col )
	{
		if ( col.gameObject.tag == "Ennemy" )
		{
			startExplosion();
			Humanoid h = col.gameObject.GetComponent<Humanoid>();
			
			if ( h == null )
				return ;
			
			float distToCenterBomb = ( this.transform.position - h.transform.position ).magnitude;
			float radius = _explosionRange.radius * _explosionRange.transform.localScale.x;
			
			float delta = Mathf.Abs( ( distToCenterBomb / radius ) - 1 );
			Debug.Log( delta );
			Debug.Log( (int)( maxDammage * delta ) );
			h.receiveDamage( (int)( maxDammage * (PlayerManager.instance.player.getLevel()+1)) );
		}
	}
	
	private IEnumerator KillOnAnimationEnd( GameObject explosion )
	{
		yield return new WaitForSeconds( 5f );
		Destroy( explosion );
		GameObject.Destroy( this.gameObject );
	}
}
