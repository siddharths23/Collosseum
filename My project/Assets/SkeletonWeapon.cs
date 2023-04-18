using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGCharacterAnims.Actions;
using RPGCharacterAnims.Extensions;
using RPGCharacterAnims.Lookups;

namespace RPGCharacterAnims
{
    public class SkeletonWeapon : MonoBehaviour
    {
        private RPGCharacterController rpgCharacterController;
        private RPGCharacterWeaponController rpgCharacterWeaponController;
        public FMODUnity.EventReference MyEvent;
        // Start is called before the first frame update
        void Start()
        {
            rpgCharacterController = GetComponent<RPGCharacterController>();
            rpgCharacterWeaponController = GetComponent<RPGCharacterWeaponController>();
            
            var switchWeaponContext = new SwitchWeaponContext();
            // TwoHanded weapon.
			foreach (var weapon in WeaponGroupings.TwoHandedWeapons) {
				if (rpgCharacterController.rightWeapon != weapon) {
					var label = weapon.ToString();
					if (label.StartsWith("TwoHand")) { label = label.Replace("TwoHand", "2H "); }
					
						
						switchWeaponContext.type = "Switch";
						switchWeaponContext.side = "None";
						switchWeaponContext.leftWeapon = Weapon.Unarmed;
						switchWeaponContext.rightWeapon = weapon;
					
				}
				
			}

            rpgCharacterController.TryStartAction(HandlerTypes.SwitchWeapon, switchWeaponContext);
        }
    

     

        

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
               Attacks();
                FMODUnity.RuntimeManager.PlayOneShot(MyEvent, GetComponent<Transform>().position);

            }
        }
        
        private void Attacks()
        {
            // Check if Attack Action exists.
            if (!rpgCharacterController.HandlerExists(HandlerTypes.Attack)) { return; }

            // End special attack.
            if (rpgCharacterController.CanEndAction(HandlerTypes.Attack)) {
                rpgCharacterController.EndAction(HandlerTypes.Attack); 
            }
            // Check if can start Attack Action.
            if (!rpgCharacterController.CanStartAction(HandlerTypes.Attack)) { return; }
           
            // TwoHanded Attack.
            if (rpgCharacterController.hasTwoHandedWeapon) {
                rpgCharacterController.StartAction(HandlerTypes.Attack, new AttackContext("Attack", Side.None)); 
            }
        }
    }
}