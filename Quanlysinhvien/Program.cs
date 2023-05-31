using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using System.Drawing;
using DevExpress.LookAndFeel;
using Quanlysinhvien.GUI;

namespace Quanlysinhvien
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            WindowsFormsSettings.ForceDirectXPaint();
            WindowsFormsSettings.SetDPIAware();
            WindowsFormsSettings.EnableFormSkins();
            WindowsFormsSettings.DefaultLookAndFeel.SetSkinStyle("The Bizier");
            SetSkinPalette();
            DevExpress.Utils.AppearanceObject.DefaultFont = new Font("Segoe UI", GetDefaultSize());
            WindowsFormsSettings.ScrollUIMode = ScrollUIMode.Touch;
            WindowsFormsSettings.CustomizationFormSnapMode = DevExpress.Utils.Controls.SnapMode.OwnerControl;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("Xmas 2008 Blue");
            Application.Run(new fLogin());
        }
        static float GetDefaultSize()
        {
            return 8.25F;
        }
        static void SetSkinPalette()
        {
            var skin = CommonSkins.GetSkin(WindowsFormsSettings.DefaultLookAndFeel);
            DevExpress.Utils.Svg.SvgPalette palette = skin.CustomSvgPalettes["Office Colorful"];
            skin.SvgPalettes[Skin.DefaultSkinPaletteName].SetCustomPalette(palette);
            LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
        }
    }
}
