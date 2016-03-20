using UnityEngine;
using System.Collections;

public class bandit_spawn : MonoBehaviour {
    public int level;
    public bool ambush;
    public GameObject Bandit;
    public GameObject bandit;
    public Transform target;
    public GameObject Player;
    public GameObject player;
    public bool debug;
    // Use this for initialization
    void Start () {
        player = Instantiate(Player, transform.position, gameObject.GetComponent<Transform>().rotation) as GameObject;
        player.GetComponent<movement>().spawner = gameObject;
        if (!debug) {
            if (ambush)
            {
                for (int i = 0; i < level+1; i++) {
                    Vector2 pos = new Vector2(Random.Range(-8, 8), Random.Range(-8, 8));
                    bandit = Instantiate(Bandit, pos, Quaternion.identity) as GameObject;
                    bandit.GetComponent<bandit_movement>().target = player;
                    bandit.transform.LookAt(player.transform.position);
                    transform.Rotate(0, -90, 0);
                }

            }
            else {
                for (int i = 0; i < level; i++) {
                    Vector2 pos = new Vector2(Random.Range(8, 1), Random.Range(-8, 8));
                    bandit = Instantiate(Bandit, pos, Bandit.transform.rotation) as GameObject;
                    bandit.GetComponent<bandit_movement>().target = player;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
