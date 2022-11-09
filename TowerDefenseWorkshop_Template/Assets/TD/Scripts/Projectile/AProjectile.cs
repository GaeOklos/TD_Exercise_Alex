namespace GSGD1
{
    using UnityEngine;

    public abstract class AProjectile : MonoBehaviour
    {
		[SerializeField]
		private bool _destroyIfGiveDamage = true;

        [HideInInspector] public int _damage = 1;

        [SerializeField]
        private LayerMask strenght;

        protected virtual void OnTriggerEnter(Collider other)
		{
			if(other.gameObject.layer != gameObject.layer)
			{
                if((strenght.value & 1 << other.gameObject.layer) != 0)
                {
                    Damage(other, _damage * 2);
                }
                else
                {
                    Damage(other, _damage);
                }
            }
            else
            {
                Damage(other, _damage/2);
            }
		}

        private void Damage(Collider other, int damageToTake)
        {
            var damageable = other.GetComponentInParent<Damageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(damageToTake);

                if (_destroyIfGiveDamage == true)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}