namespace BulletExpress.IDA.Powders
{
	public class Cookie : ModDust
	{
		public override void OnSpawn(Dust dust)
        {
            //将灰尘的初始大小乘以1.5
            dust.scale *= 1.5f;
            //将尘埃的起始速度乘以0.4，使其减速
            dust.velocity *= 0.4f; 
            //使尘埃没有重力
            dust.noGravity = true;
            //使尘埃不发光
            dust.noLight = true; 
        }

		public override bool Update(Dust dust) 
		{
            //调用灰尘处于活动状态的每一帧
            dust.scale *= 0.96f;
            if (dust.scale < 0.5f)
            {
                dust.active = false;
            }
            dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.15f;
            //返回false以防止默认行为
            return false; 
		}
	}
}
