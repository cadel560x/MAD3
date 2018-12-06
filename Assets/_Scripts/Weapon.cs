using UnityEngine;

public class Weapon : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;

    private SoundController soundController;

    [SerializeField]
    private AudioClip playerShotClip;

    private void Start()
    {
        soundController = FindObjectOfType<SoundController>();
    }

    // Update is called once per frame
    void Update () {
		if( Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        if (soundController)
        {
            soundController.PlayOneShot(playerShotClip);
        }
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
