using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using HairongWu.Extensions;

namespace HairongWu
{

    /// <summary>
    /// Author: HairongWu
    /// Description: This script demonstrates how to run UI function of in-game in Unity
    /// </summary>
    public class UI : MonoBehaviour
    {
        #region Instance Variables aka Non-Static Member Variables 
        public GameObject manaPanel;
        public GameObject weaponPanel;
        public GameObject magicPanel;
        public GameObject livesPanel;
        public GameObject protectionPanel;

        public Sprite pantiesImage;
        public Sprite armorImage;
        public Sprite lifeImage;
        public Sprite bottleFullImage;
        public Sprite bottleEmptyImage;
        public Sprite magicImage;

        public Sprite JavlineImage;
        public Sprite AxeImage;
        public Sprite BombImage;
        public Sprite WhipImage;
        public Sprite BuleFireImage;

        [Range(1, 10)]
        public int magicCost;
        [Range(1, 2)]
        public int defaultArmorNumber;
        [HideInInspector]
        public bool magicable;

        private Dictionary<WeaponType, Sprite> weaponImage;
        private WeaponType equipedWeapon;


        private int livesNumber;



        private ArmorDurable[] armorDurables;
        private Panties panties;
        private Life[] lives;
        private Bottle[] bottles;
        #endregion


        #region Unity Methods
        void Start()
        {
            weaponImage = new Dictionary<WeaponType, Sprite>
            {
                [WeaponType.Javline] = JavlineImage,
                [WeaponType.Axe] = AxeImage,
                [WeaponType.Bomb] = BombImage,
                [WeaponType.Whip] = WhipImage,
                [WeaponType.BuleFire] = BuleFireImage
            };

            magicPanel.GetComponent<Image>().sprite = magicImage;

            lives = livesPanel.GetComponentsInChildren<Life>();
            armorDurables = protectionPanel.GetComponentsInChildren<ArmorDurable>();
            panties = protectionPanel.GetComponentInChildren<Panties>();
            bottles = manaPanel.GetComponentsInChildren<Bottle>();

            lives.ForEach(life => life.InitializeLife());


            Reborn();

        }

        #endregion

        #region Custom Public Methods 

        public IEnumerator RebornWithDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            Reborn();
        }
        public void Reborn()
        {
            //Reset equipped Weapon
            ChangeWeapon(WeaponType.Javline);

            //Reset Mana and Magic
            AddMana(bottles.Count());
            CostMana();


            //Reset armor and panties
            armorDurables.Take(defaultArmorNumber).ForEach(a => a.Recover());
            panties.Recover();

        }

        public bool GetKilled()
        {
            var lastLife = lives.LastOrDefault(life => life.isLifeOn);
            if (lastLife != null)
            {
                lastLife.LostLife();
                StartCoroutine("RebornWithDelay", 1f);
                return false;
            }
            return true;
        }

        public ProtectionStatus GetAttacked()
        {
            var lastArmorDurable = armorDurables.LastOrDefault(a => a.isArmorOn);

            if (lastArmorDurable != null)
            {
                lastArmorDurable.GetAttacked();
            }
            else if (panties.isPantiesOn)
            {
                panties.GetAttacked();
            }

            if (!panties.isPantiesOn)
            {
                return ProtectionStatus.Killed;
            }
            else if (!armorDurables.Any(a => a.isArmorOn))
            {
                return ProtectionStatus.ArmorBreak;
            }
            else
            {
                return ProtectionStatus.None;
            }

        }

        public void ChangeWeapon(WeaponType weaponType)
        {
            equipedWeapon = weaponType;
            UpdateWeaponImage();
        }



        public void CostMana()
        {
            var fullBottles = bottles.Where(b => b.isBottleFull);
            if (fullBottles.Count() >= magicCost)
            {
                fullBottles.TakeLast(magicCost).ForEach(b => b.BottleCost());
            }

            magicable = (bottles.Count(b => b.isBottleFull) >= magicCost);
            UpdateMagicImage();
        }

        public void AddMana(int gainedMana)
        {
            var emptyBottles = bottles.Where(b => !b.isBottleFull);
            if (emptyBottles.Count() < gainedMana)
            {
                emptyBottles.ForEach(b => b.BottleRecharge());
            }
            else
            {
                emptyBottles.Take(gainedMana).ForEach(b => b.BottleRecharge());
            }

            magicable = (bottles.Count(b => b.isBottleFull) >= magicCost);
            UpdateMagicImage();


        }
        #endregion

        #region Custom Private Methods 

        private void UpdateWeaponImage()
        {
            weaponPanel.GetComponent<Image>().sprite = weaponImage[equipedWeapon];
        }

        private void UpdateMagicImage()
        {

            if (magicable)
            {
                magicPanel.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
            }
            else
            {
                magicPanel.GetComponent<Image>().color = new Color(255, 255, 255, 0f);
            }
        }

        #endregion

    }

    public enum WeaponType
    {
        Javline = 1,
        Axe,
        Bomb,
        Whip,
        BuleFire
    }

    public enum ProtectionStatus
    {
        None = 1,
        ArmorBreak,
        Killed
    }


}