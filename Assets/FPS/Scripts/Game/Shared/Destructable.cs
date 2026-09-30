using UnityEngine;
using UnityEngine.Events;

namespace Unity.FPS.Game
{
	public class Destructable : MonoBehaviour
	{
		Health m_Health;

		public UnityEvent OnDeath, OnReceiveDamage;

		void Start()
		{
			m_Health = GetComponent<Health>();
			DebugUtility.HandleErrorIfNullGetComponent<Health, Destructable>(m_Health, this, gameObject);

			// Subscribe to damage & death actions
			m_Health.OnDie += OnDie;
			m_Health.OnDamaged += OnDamaged;
		}

		void OnDamaged(float damage, GameObject damageSource)
		{
			// TODO: damage reaction
			if (OnReceiveDamage != null)
				OnReceiveDamage.Invoke();
		}

		void OnDie()
		{
			// this will call the OnDestroy function
			// if (OnDeath != null)
			OnDeath.Invoke();
			//else
			//  Destroy(gameObject);
		}
	}
}