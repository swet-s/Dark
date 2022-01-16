using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Vector3 firePoint;
    public Equip equip;
    private GunManager currentgun = null;

  
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            currentgun = collision.GetComponent<GunManager>();

            if (currentgun.currentlyEquipedGun == null || currentgun.currentlyEquipedGun == gameObject)
            {
                ScoreManager ammo = collision.GetComponent<ScoreManager>();
                equip.enabled = true;
                if (currentgun.ammoCount > 0)
                {
                    currentgun.fireButton.gameObject.SetActive(true);
                    currentgun.fireButton.enabled = true;
                    currentgun.firejoy.enabled = true;
                }
                else
                {
                    currentgun.fireButton.gameObject.SetActive(false);
                    currentgun.fireButton.enabled = false;
                    currentgun.firejoy.enabled = false;
                }
                
                ammo.UpdateAmmo(currentgun.ammoCount);
            }

            else
            {
                ScoreManager ammo = collision.GetComponent<ScoreManager>();
                Equip other = currentgun.currentlyEquipedGun.GetComponent<Equip>();
                equip.enabled = true;
                other.enabled = false;
                if (currentgun.ammoCount > 0)
                {
                    currentgun.fireButton.enabled = true;
                    currentgun.firejoy.enabled = true;
                }
                else
                {
                    currentgun.fireButton.enabled = false;
                    currentgun.firejoy.enabled = false;
                }
                ammo.UpdateAmmo(currentgun.ammoCount);
            }
           
        }
    }

}
