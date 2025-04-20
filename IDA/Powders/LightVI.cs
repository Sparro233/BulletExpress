namespace BulletExpress.IDA.Powders
{
	public class LightVI : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.scale *= 1.5f;
            dust.velocity *= 0.4f;
            dust.noGravity = true;
            dust.noLight = false;
        }

        public override bool Update(Dust dust)
        {
            dust.scale *= 0.93f;
            if (dust.scale < 0.5f)
            {
                dust.active = false;
            }
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;

            float light = 0.1f * dust.scale;
            Lighting.AddLight(dust.position, light, light, light);
            return false;
        }
    }
}
