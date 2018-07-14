﻿using UnityEngine;

namespace RPG.Weapons
{
    [CreateAssetMenu(menuName = ("RPG/Weapon"))]
    public class WeaponConfig : ScriptableObject
    {

        public Transform gripTransform;

        [SerializeField] GameObject weaponPrefab;
        [SerializeField] AnimationClip[] attackAnimations;

        [SerializeField] float timeBetweenAnimationCyclesMin = .25f;
        [SerializeField] float timeBetweenAnimationCyclesMax = .75f;

        [SerializeField] float maxAttackRange = 2f;
        [SerializeField] float additionalDamage = 10f;
        [SerializeField] float damageDelay = .5f;

        [SerializeField] bool rangedAttack = false;
        [SerializeField] GameObject rangedAttackPrefab; // may be null if ranged attack is false, if true e.g. an arrow

        public GameObject GetWeaponPrefab()
        {
            return weaponPrefab;
        }

        public AnimationClip[] GetAttackAnimations()
        {
            RemoveAnimationEvents();
            return attackAnimations;
        }

        public float GetTimeBetweenAnimationCycles()
        {
            return Random.Range(timeBetweenAnimationCyclesMin, timeBetweenAnimationCyclesMax);
        }

        public float GetMaxAttackRange()
        {
            return maxAttackRange;
        }

        public float GetAdditionalDamage()
        {
            return additionalDamage;
        }

        public float GetDamageDelay()
        {
            return damageDelay;
        }

        public bool GetRangedAttack()
        {
            return rangedAttack;
        }

        public GameObject GetRangedAttackPrefab()
        {
            return rangedAttackPrefab;
        }

        // Method removes all animation events so they cannot break existing code.
        private void RemoveAnimationEvents()
        {
            foreach(AnimationClip attackAnimation in attackAnimations)
            {
                attackAnimation.events = new AnimationEvent[0];
            }
        }
    }
}
