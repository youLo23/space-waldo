using UnityEngine;
using System.Collections;

public class PlayerWeaponController : MonoBehaviour {

	public GameObject mainShot;
    public GameObject seconShot;
    public Transform mainSpawn;
    public Transform[] secSpawns;
	public float fireRate;
	public float updateRate;
    public int weaponIndex;
    public string currentWeapon;

    private float nextFire;
	private float nextUpdate;
	private AudioSource audi;
    public string[] weapons;

	// Use this for initialization
	void Start () {
		audi = GetComponent<AudioSource>();
        weapons = new string[] {"default", "highRate", "3spawn", "3spawnDivergent"};
        weaponIndex = 0;
    }
	
	// Update is called once per frame
	void Update () {
        currentWeapon = weapons[weaponIndex];
        if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
            Fire();
			audi.Play();
		}
		
		if (Time.time > nextUpdate) {
			nextUpdate = Time.time + updateRate;
		}
        if (Input.GetKeyDown(KeyCode.W)) {
            weaponIndex = (weaponIndex + 1) % weapons.Length;
        }

    }
    void Fire() {
        switch (currentWeapon) {
            case "default":
                fireRate = 0.25f;
                break;
            case "highRate":
                fireRate = 0.05f;
                break;
            case "3spawn":
                fireRate = 0.25f;
                foreach (Transform spawn in secSpawns) {
                    Instantiate(seconShot, spawn.position, spawn.rotation);
                }
                break;
            case "3spawnDivergent":
                fireRate = 0.25f;
                for (int i = 0; i < secSpawns.Length; i++) {
                    Instantiate(seconShot, secSpawns[i].position, Quaternion.Euler(0, (2*i-1)*20, 0));
                }
                break;
            default:
                break;
        }
        Instantiate(mainShot, mainSpawn.position, mainSpawn.rotation);
    }
}
