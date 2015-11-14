using UnityEngine;
using System.Collections;

public class SpawnerZ : MonoBehaviour {

	public Zombie[]		zombies;
	private Zombie		currentZombie;
	private bool		respawnInProgress = false;

	public float		timeRespawn = 10f;

	void Start ()
	{
		this.newZombie();
	}
	
	void Update ()
	{
		if (respawnInProgress == false && this.currentZombie != null && !this.currentZombie.isAlive())
			StartCoroutine(this.respawnZombie());
	}


	IEnumerator		respawnZombie()
	{
		respawnInProgress = true;
		float transition = 0.05f;
		currentZombie.GetComponent<CharacterController>().enabled = false;
		currentZombie.GetComponent<SphereCollider>().enabled = false;
		yield return new WaitForSeconds(3f);
		currentZombie.GetComponent<Animator>().enabled = false;
		while (transition < 1f)
		{
			this.currentZombie.transform.position += (Vector3.down * 0.05f);
			transition += 0.05f;
			yield return new WaitForSeconds(0.02f);
		}
		GameObject.DestroyImmediate(this.currentZombie.gameObject);
		
		yield return new WaitForSeconds(this.timeRespawn);
		this.currentZombie = null;
		
		this.newZombie();
		respawnInProgress = false;
	}

	private void	newZombie()
	{
		if (zombies.GetLength(0) == 0)
			return;

		this.currentZombie = GameObject.Instantiate(zombies[Random.Range(0, zombies.GetLength(0))]);
		this.currentZombie.transform.position = this.transform.position;
		StartCoroutine(spawnTransition());
	}

	private IEnumerator		spawnTransition()
	{
		float transition = 0.05f;
		this.currentZombie.GetComponent<NavMeshAgent>().enabled = false;
		this.currentZombie.GetComponent<CharacterController>().enabled = false;
		this.currentZombie.GetComponent<SphereCollider>().enabled = false;
		this.currentZombie.GetComponent<Animator>().enabled = false;
		this.currentZombie.transform.position -= Vector3.up;

		while (transition < 1f)
		{
			this.currentZombie.transform.position += (Vector3.up * 0.05f);
			transition += 0.05f;
			yield return new WaitForSeconds(0.02f);
		}
		yield return new WaitForSeconds(0.3f);
		this.currentZombie.GetComponent<NavMeshAgent>().enabled = true;
		this.currentZombie.GetComponent<CharacterController>().enabled = true;
		this.currentZombie.GetComponent<SphereCollider>().enabled = true;
		this.currentZombie.GetComponent<Animator>().enabled = true;
	}

}
