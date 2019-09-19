using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private PlayerAvatar avatar;
    private BulletGun bulletGun;

    [SerializeField] protected Slider healthBar;
    protected float maxHealth;
    [SerializeField] protected Slider energyBar;
    protected float maxEnergy;

    void Start() {
        avatar = GameManager.Instance.GetPlayer().GetComponent<PlayerAvatar>();
        maxHealth = avatar.GetMaxHealth();
        bulletGun = avatar.GetComponent<BulletGun>();
        maxEnergy = bulletGun.GetMaxEnergy();
    }
    
    void Update() {
        UpdateBar(healthBar, maxHealth, avatar.GetHealth());
        UpdateBar(energyBar, maxEnergy, bulletGun.GetEnergy());
    }

    void UpdateBar(Slider slide, float max, float value) {
        slide.value = value / max;
        if (value == 0) {
            slide.fillRect.gameObject.SetActive(false);
        } else {
            slide.fillRect.gameObject.SetActive(true);
        }
    }
}
