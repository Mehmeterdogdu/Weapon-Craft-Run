using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int SpeedZ = 5;
    public int SpeedX = 3;
    public float WayWidth = 3.5f;
    float MouseControlWay = 0f;

    public float FireRate = 1f;
    private float BulletTimer=0f;

    public GameObject[] weaponPrefaps = null;
    public GameObject[] bulletPrefaps = null;
    public int WeaponLevel = 1;
    public float bulletDistanc = 1f;
    public float bulletSpeed = 9f;
    public float BulletLifeTimer=2f;

    public bool isGameStart = false;

    public Image Background;
    public Image LoseScreen;

    public GameObject GameCreater;



    void Start()
    {
        Instantiate(GameCreater);
        bulletSpeed = bulletSpeed + SpeedZ;

        for (int i = 1; i < weaponPrefaps.Length; i++)
        {
            // Prefab'i oluþtururken scale'ini ayarla
            GameObject newWeapon = Instantiate(weaponPrefaps[i],transform);

            // Scale deðerlerini ayarla
            newWeapon.transform.localScale = new Vector3(4f, 6f, 3f);
            newWeapon.transform.rotation = new Quaternion(0f,180f,0f,0f);
            newWeapon.SetActive(false);
        }

        transform.GetChild(WeaponLevel-1).GetComponent<Transform>().gameObject.SetActive(true);

        LoseScreen.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStart)
        {
            PlayerMove();
            CreateBullet();
        }
        
    }

    public void PlayerMove()
    {
        float MousePositionx = Input.mousePosition.x;

        if (MousePositionx <= 360)
        {
            MouseControlWay = -SpeedX;
        }
        else if (MousePositionx <= 720)
        {
            MouseControlWay = 0;
        }
        else if (MousePositionx > 720)
        {
            MouseControlWay = SpeedX;
        }

        if (transform.position.x >= WayWidth && MouseControlWay == SpeedX)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + SpeedZ * Time.deltaTime);
        }
        else if (transform.position.x <= -WayWidth && MouseControlWay == -SpeedX)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + SpeedZ * Time.deltaTime);
        }
        else
            transform.position = new Vector3(transform.position.x + MouseControlWay * Time.deltaTime, transform.position.y, transform.position.z + SpeedZ * Time.deltaTime);


    }

    public void CreateBullet()
    {
        BulletTimer += Time.deltaTime; 
        Vector3 BulletCreatePoint = new Vector3(transform.position.x, transform.position.y, transform.position.z + bulletDistanc);

       
        if (BulletTimer >= FireRate)
        {

            Instantiate(bulletPrefaps[WeaponLevel], BulletCreatePoint, Quaternion.identity);
            BulletTimer = 0.0f; 
        }
    }

    public float GetBulletSpeed()
    {
        return bulletSpeed;
    }
    public void ChangeFireRate(float value)
    {
        if (value != 0)
        {
            FireRate = FireRate / (value / 4);

            if (FireRate <= 0.01f)
            {
                FireRate = 0.01f;
            }
        }
    }
    public void ChangeLifeTime(float value)
    {
        if (value != 0)
        {
            BulletLifeTimer = BulletLifeTimer + value;
        }
    }
    public void LevelUpWeapon(int value)
    {
        WeaponLevel = value + WeaponLevel;
        if (WeaponLevel >= bulletPrefaps.Length)
            WeaponLevel = bulletPrefaps.Length - 1;

        for (int i = 0; i < weaponPrefaps.Length-1; i++)
        {
            transform.GetChild(i).GetComponent<Transform>().gameObject.SetActive(false);
        }

        transform.GetChild(WeaponLevel-1).GetComponent<Transform>().gameObject.SetActive(true);


    }

    
    public void RestardGame()
    {
        SpeedZ = 5;
        SpeedX = 3;
        WayWidth = 3.5f;

        FireRate = 1f;
        BulletTimer = 0f;

        WeaponLevel = 1;
        bulletDistanc = 1f;
        bulletSpeed = 4f;
        BulletLifeTimer = 2f;

        for (int i = 0; i < weaponPrefaps.Length - 1; i++)
        {
            transform.GetChild(i).GetComponent<Transform>().gameObject.SetActive(false);
        }

        transform.GetChild(0).GetComponent<Transform>().gameObject.SetActive(true);

        transform.position =new Vector3(0, 1.22000003f, -3.55999994f);
        Destroy(GameCreater.gameObject);
        Instantiate(GameCreater);
    }

    public void LoseGame()
    {
        isGameStart = false;
        LoseScreen.gameObject.SetActive(true);
        
    }


}
