// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace System.ServiceModel.Dispatcher
{
    internal class SharedRuntimeState
    {
        private bool _isImmutable;
        private bool _enableFaults = true;
        private bool _isOnServer;
        private bool _manualAddressing;
        private bool _validateMustUnderstand = true;

        internal SharedRuntimeState(bool isOnServer)
        {
            _isOnServer = isOnServer;
        }

        internal bool EnableFaults
        {
            get { return _enableFaults; }
            set { _enableFaults = value; }
        }

        internal bool IsOnServer
        {
            get { return _isOnServer; }
        }

        internal bool ManualAddressing
        {
            get { return _manualAddressing; }
            set { _manualAddressing = value; }
        }

        internal bool ValidateMustUnderstand
        {
            get { return _validateMustUnderstand; }
            set { _validateMustUnderstand = value; }
        }

        internal void LockDownProperties()
        {
            _isImmutable = true;
        }

        internal void ThrowIfImmutable()
        {
            if (_isImmutable)
            {
                if (this.IsOnServer)
                {
                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(SR.SFxImmutableServiceHostBehavior0));
                }
                else
                {
                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(SR.SFxImmutableChannelFactoryBehavior0));
                }
            }
        }
    }
}
