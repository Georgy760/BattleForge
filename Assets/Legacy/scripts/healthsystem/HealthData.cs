using System;
using UnityEngine;

namespace healthsystem
{
    public class HealthData : IDamageable
    {
        public float MaxHealth { get; set; }
        public float MinHealth { get; set; }
        
        private float _currentHealth;

        private float _currentHealthNormalized;
        public float CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = Mathf.Clamp(value, MinHealth, MaxHealth);
        }

        public float CurrentHealthNormalized
        {
            get => _currentHealth/100;
        }

        public event EventHandler HealthChanged;
        public event EventHandler HealthDepleted;
        public void ReduceHealthPoints(float amount)
        {
            CurrentHealth -= amount;
        }

        public void RestoreHealthPoints(float amount)
        {
            CurrentHealth += amount;
        }

        public HealthData(float max, float min, float initial)
        {
            MaxHealth = max;
            MinHealth = min;
            CurrentHealth = initial;
        }

        public HealthData()
        {
            //NOP
        }
    }
}