using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class GunManager : MonoBehaviour
{
    public GameObject currentlyEquipedGun;
    public bool hasAGun = true;
    public int ammoLimit = 60;
    private GameObject gunObject;
    private GameObject  miniGun;
    public int ammoCount;
    [HideInInspector]
    public float gunMovement = 0f;
    [HideInInspector]
    public Joystick firejoy;
    [HideInInspector]
    public Button fireButton;
    GameObject spark;

    public float reloadSpeed = 0.2f;
    public int reloadFreq = 2;
    public int reloadCount = 0;
    bool notDone = true;

    public GameObject shootCanvas;

    private void Awake()
    {
        spark = Resources.Load<GameObject>("Spark");
        GameObject canvas = Resources.Load<GameObject>("ShootCanvas");
        miniGun  = Resources.Load<GameObject>("GunPref");
        shootCanvas = Instantiate(canvas);
        fireButton = shootCanvas.GetComponentInChildren<Button>();
        firejoy = shootCanvas.GetComponentInChildren<Joystick>();


        //fireButton.onClick.AddListener(() => { shoot(); });

        EventTrigger trigger = shootCanvas.GetComponentInChildren<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { ShootNow(true); });
        trigger.triggers.Add(entry);

        EventTrigger trigger2 = shootCanvas.GetComponentInChildren<EventTrigger>();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerUp;
        entry2.callback.AddListener((data) => { ShootNow(false); });
        trigger2.triggers.Add(entry2);


        if (hasAGun)
        {
            GameObject gunclone = Instantiate(miniGun);
            Equip player = gunclone.GetComponent<Equip>();
            player.player = gameObject.transform;
        }
            
        ammoCount = PlayerPrefs.GetInt("TotalAmmo", 30);
        
    }

    public bool isShooting = false;
    public void ShootNow(bool shooting)
    {
        isShooting = shooting;
    }

    private void Start()
    {
        fireButton.gameObject.SetActive(false);
        firejoy.enabled = false;
    }
    public void Getgun(GameObject miniGun)
    {
        gunObject = miniGun;
    }

    public void Update()
    {
        gunMovement = firejoy.Horizontal;
        currentlyEquipedGun = gunObject;
        if (isShooting)
            shoot();
    }


    public void GetAmmos(int count)
    {
        Gun gun = gunObject.GetComponent<Gun>();
        ScoreManager bulletcount = gun.equip.player.GetComponent<ScoreManager>();
        ammoCount += count;
        if (ammoCount > ammoLimit)
            ammoCount = ammoLimit;
        bulletcount.UpdateAmmo(ammoCount);
        
    }

    public void shoot()
    {
        if (reloadCount < reloadFreq)
        {
            reloadCount++;
            Gun gun = gunObject.GetComponent<Gun>();
            if (gun.equip.enabled)
            {
                FindObjectOfType<AudioCreater>().PlayShot();
                ScoreManager bulletcount = gun.equip.player.GetComponent<ScoreManager>();
                GameObject sparkclone;

                if (gun.equip.gunisFlipped)
                {
                    Vector3 revFirePoint = new Vector3(-gun.firePoint.x, gun.firePoint.y, gun.firePoint.z);
                    Instantiate(gun.bullet, gunObject.transform.position + revFirePoint, gunObject.transform.rotation);
                    sparkclone = Instantiate(spark, gunObject.transform.position + revFirePoint, gunObject.transform.rotation);
                }

                else
                {
                    Instantiate(gun.bullet, gunObject.transform.position + gun.firePoint, gunObject.transform.rotation);
                    sparkclone = Instantiate(spark, gunObject.transform.position + gun.firePoint, gunObject.transform.rotation);
                }

                sparkclone.transform.SetParent(gun.transform);
                Destroy(sparkclone, 0.1f);

                ammoCount--;
                bulletcount.UpdateAmmo(ammoCount);
            }
            if (ammoCount == 0)
            {
                fireButton.enabled = false;
                firejoy.enabled = false;
                isShooting = false;
                StartCoroutine("AmmoZero");
            }
        }
        else
        {
            if (notDone)
            {
                StartCoroutine("Reload");
                notDone = false;
            }
        }
    }
    IEnumerator AmmoZero()
    {
        yield return new WaitForSeconds(0f);
        OnAmmoCountZero.Invoke();
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadSpeed);
        reloadCount = 0;
        notDone = true;
    }


    [Header("Events")]

    public UnityEvent OnAmmoCountZero;
    public class BoolEvent : UnityEvent<bool> { }


}
