namespace BulletExpress.IDA.Powders
{
	public class LightII : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.scale *= 1.5f;
            dust.velocity *= 0.2f;
            dust.noGravity = true;
            dust.noLight = false;
        }

        public override bool Update(Dust dust)
        {
            if (dust.scale < 0.5f)
            {
                dust.active = false;
            }
            dust.scale *= 0.96f;
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;

            float light = 0.1f * dust.scale;
            Lighting.AddLight(dust.position, light, light, light);
            return false;
        }
    }
}
