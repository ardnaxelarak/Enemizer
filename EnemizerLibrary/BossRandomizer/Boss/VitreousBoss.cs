namespace EnemizerLibrary
{
    public class VitreousBoss : Boss
    {
        public VitreousBoss() : base(BossType.Vitreous)
        {
            BossPointer = new byte[] { 0x57, 0xE4 };
            BossGraphics = 22; // TODO: really?
            BossSpriteId = SpriteConstants.Vitreous_LargeEyeballSprite;
            BossNode = "mire-vitreous";

            BossSpriteArray = new byte[]
            {
                0x05, 0x07, 0xBD // vitreous
            };
        }
    }
}
