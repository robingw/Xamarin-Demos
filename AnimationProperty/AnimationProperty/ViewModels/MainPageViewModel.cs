using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AnimationProperty.Models;

namespace AnimationProperty.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private MainPageModel model;

        public MainPageViewModel()
        {
            model = new MainPageModel();

            Refresh();
        }

        protected override async Task UpdateModelAsync()
        {
            DateTime time = DateTime.Now;

            Hour = time.Hour;
            Minute = time.Minute;
            Second = time.Second;

            float currentSenond = time.Hour * (60 * 60) + time.Minute * 60 + time.Second;
            float totalSecond = 24 * 60 * 60;
            Percent = currentSenond / totalSecond;
        }

        #region 属性

        /// <summary>
        /// (Hour)当前几点
        /// </summary>
        public int Hour
        {
            set { SetAnimationIntProperty(model.Hour, value); }
            get { return model.Hour; }
        }

        /// <summary>
        /// (Minute)当前分钟
        /// </summary>
        public int Minute
        {
            set { SetAnimationIntProperty(model.Minute, value); }
            get { return model.Minute; }
        }

        /// <summary>
        /// (Second)当前秒
        /// </summary>
        public int Second
        {
            set { SetAnimationIntProperty(model.Second, value); }
            get { return model.Second; }
        }

        /// <summary>
        /// (Percent)今天已过百分比
        /// </summary>
        public float Percent
        {
            set { SetAnimationFloatProperty(model.Percent, value); }
            get { return model.Percent; }
        }

        /// <summary>
        /// (ChangeIntPropertyValue)动态改变整型属性
        /// </summary>
        protected override async Task ChangeIntPropertyValue(int value, [CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case "Hour":
                    model.Hour = value;
                    break;
                case "Minute":
                    model.Minute = value;
                    break;
                case "Second":
                    model.Second = value;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// (ChangeIntPropertyValue)动态改变浮点型属性
        /// </summary>
        protected override async Task ChangeFloatPropertyValue(float value, [CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case "Percent":
                    model.Percent = value;
                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}
