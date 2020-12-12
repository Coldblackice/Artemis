﻿using System.Windows.Navigation;
using Artemis.Core.Services;
using Stylet;

namespace Artemis.UI.Screens.SetupWizard.Steps
{
    public class FinishStepViewModel : Screen
    {
        private readonly ICoreService _coreService;

        public FinishStepViewModel(ICoreService coreService)
        {
            _coreService = coreService;
        }

        public void OpenHyperlink(object sender, RequestNavigateEventArgs e)
        {
            Core.Utilities.OpenUrl(e.Uri.AbsoluteUri);
        }

        public void Finish()
        {
            ((SetupWizardViewModel) Parent).SkipOrFinishWizard();
        }

        protected override void OnActivate()
        {
            _coreService.PlayIntroAnimation();
            base.OnActivate();
        }
    }
}