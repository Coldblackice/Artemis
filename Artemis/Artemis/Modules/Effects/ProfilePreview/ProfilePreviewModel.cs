﻿using System.Drawing;
using Artemis.Managers;
using Artemis.Models;
using Artemis.Models.Interfaces;
using Artemis.Models.Profiles;

namespace Artemis.Modules.Effects.ProfilePreview
{
    public class ProfilePreviewModel : EffectModel
    {
        private readonly ProfilePreviewDataModel _previewDataModel;

        public ProfilePreviewModel(MainManager mainManager) : base(mainManager)
        {
            Name = "Profile Preview";
            _previewDataModel = new ProfilePreviewDataModel();
        }

        public ProfileModel SelectedProfile { get; set; }

        public override void Dispose()
        {
            Initialized = false;
            SelectedProfile = null;
        }

        public override void Enable()
        {
            Initialized = true;
        }

        public override void Update()
        {
        }

        public override Bitmap GenerateBitmap()
        {
            var bitmap = MainManager.KeyboardManager.ActiveKeyboard.KeyboardBitmap(4);

            if (SelectedProfile == null)
                return bitmap;

            var keyboardRect = MainManager.KeyboardManager.ActiveKeyboard.KeyboardRectangle(4);
            var image = SelectedProfile.GenerateBitmap<ProfilePreviewDataModel>(keyboardRect, _previewDataModel, true);

            // Draw on top of everything else
            using (var g = Graphics.FromImage(bitmap))
                g.DrawImage(image, 0, 0);

            return bitmap;
        }
    }

    public class ProfilePreviewDataModel : IGameDataModel
    {
    }
}