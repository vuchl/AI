using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace TowerDefence
{
    public class Enemy : MonoBehaviour
    {
        public float maxHealth = 100f;
        [Header("UI")]
        public GameObject healthBarUI;
        public Vector2 healthBarOffset = new Vector2(0f, 5f);
        private Slider healthSider;
        private float health = 100f;

        void Start()
        {
            health = maxHealth;
        }

        Vector3 GetHealthBarPos()
        {
            Camera cam = Camera.main;
            Vector2 position = cam.WorldToScreenPoint(transform.position);
            return position + healthBarOffset;
        }

        void Update()
        {
            if(healthSider)
            {
                healthSider.transform.position = GetHealthBarPos();
            }
        }
        public void SpawnHealthBar(Transform parent)
        {
            GameObject clone = Instantiate(healthBarUI, GetHealthBarPos(), Quaternion.identity, parent);
            healthSider = clone.GetComponent<Slider>();
        }
        public void DealDamage(float damage)
        {
            // 
            health -= damage;
            //
            if (health <= 0)
            {
                //
                Destroy(gameObject);
            }
        }
    }
}