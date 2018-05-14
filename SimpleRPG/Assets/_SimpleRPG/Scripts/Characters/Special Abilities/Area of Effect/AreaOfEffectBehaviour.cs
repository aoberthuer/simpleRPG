﻿using UnityEngine;


namespace RPG.Characters
{
    public class AreaOfEffectBehaviour : AbilityBehaviour
    {

        public override void Use(GameObject target, bool useTargetPosition)
        {
            base.Use(target, useTargetPosition);
            DealRadialDamage();
        }

        private void DealRadialDamage()
        {
            AreaOfEffectConfig aoeConfig = (AreaOfEffectConfig) config;

            float extraDamage = aoeConfig.GetExtraDamage();
            float damageRadius = aoeConfig.getDamageRadius();

            RaycastHit[] raycastHits = Physics.SphereCastAll(
                transform.position,
                damageRadius,
                Vector3.up,
                damageRadius
            );

            foreach (RaycastHit hit in raycastHits)
            {
                HealthSystem healthSystem = hit.collider.gameObject.GetComponent<HealthSystem>();
                bool hitPlayer = hit.collider.gameObject.GetComponent<PlayerControl>();

                if (healthSystem != null && !hitPlayer)
                {
                    float damageToDeal = extraDamage;
                    healthSystem.TakeDamage(damageToDeal);
                }
            }
        }

    }

}
