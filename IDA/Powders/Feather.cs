namespace BulletExpress.IDA.Powders
{
	public class Feather : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.scale *= 1.5f;
            dust.velocity *= 0.4f;
            dust.noGravity = true;
            dust.noLight = true;
        }

        public override bool Update(Dust dust)
        {
            dust.scale *= 0.99f;
            if (dust.scale < 0.5f)
            {
                dust.active = false;
            }
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            return false;
        }
    }
}
