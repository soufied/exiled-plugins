using Exiled.API.Features;
using UnityEngine;

namespace CustomRoleUtr.Api.Components
{
    public class DisableStaminaComp : MonoBehaviour
    {
        public Player Player;
        private void Start()
        {
            Player = Player.Get(gameObject);
            Player.Stamina = 0f;
        }
        public void Destroy() => Destroy(gameObject);
        private void FixedUpdate()
        {
            Player.Stamina = 0f;
        }
    }
}