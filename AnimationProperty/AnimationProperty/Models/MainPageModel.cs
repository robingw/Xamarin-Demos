using System;
namespace AnimationProperty.Models
{
    public class MainPageModel
    {
        // 启动时间
        public int Hour;
        public int Minute;
        public int Second;

        // 今天已过的百分比
        public float Percent;

        public MainPageModel()
        {
            Hour = 0;
            Minute = 0;
            Second = 0;
            Percent = 0.0f;
        }
    }
}
