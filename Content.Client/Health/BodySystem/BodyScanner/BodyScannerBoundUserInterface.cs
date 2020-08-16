﻿using System.Collections.Generic;
using Content.Shared.Health.BodySystem.BodyScanner;
using Robust.Client.GameObjects.Components.UserInterface;
using Robust.Shared.GameObjects.Components.UserInterface;
using Robust.Shared.ViewVariables;

namespace Content.Client.Health.BodySystem.BodyScanner
{
    public class BodyScannerBoundUserInterface : BoundUserInterface
    {
        [ViewVariables]
        private BodyScannerDisplay _display;

        [ViewVariables]
        private BodyScannerTemplateData _template;

        [ViewVariables]
        private Dictionary<string, BodyScannerBodyPartData> _parts;

        public BodyScannerBoundUserInterface(ClientUserInterfaceComponent owner, object uiKey) : base(owner, uiKey)
        {
        }

        protected override void Open()
        {
            base.Open();
            _display = new BodyScannerDisplay(this);
            _display.OnClose += Close;
            _display.OpenCentered();
        }

        protected override void UpdateState(BoundUserInterfaceState state)
        {
            base.UpdateState(state);

            if (!(state is BodyScannerInterfaceState scannerState))
                return;

            _template = scannerState.Template;
            _parts = scannerState.Parts;

            _display.UpdateDisplay(_template, _parts);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}
