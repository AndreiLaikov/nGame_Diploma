namespace NGame.PlayerMVC
{
    public class PlayerModel
    {
        public float Speed;
        public float Inertia;
        public float JumpForce;

        public bool IsGrounded;
        public bool IsWalled;

        public void SetIsGrounded(bool grounded)
        {
            IsGrounded = grounded;//+ ивент
        }

        public void SetIsWalled(bool walled)
        {
            IsWalled = walled;
        }
    }
}