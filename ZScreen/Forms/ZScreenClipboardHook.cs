﻿using System;
using System.Windows.Forms;
using HelpersLib;
using ZScreenLib;

namespace ZScreenGUI
{
    public partial class ZScreen : ZScreenCoreUI
    {
        private static Timer tmrClipboardMonitor = new Timer() { Interval = 1000, Enabled = true };

        #region Clipboard Methods

        private void tmrClipboardMonitor_Tick(object sender, EventArgs e)
        {
            try
            {
                if (IsReady && !Engine.IsClipboardUploading)
                {
                    bool uploadImage = false, uploadText = false, uploadFile = false, shortenUrl = false;
                    string cbText = string.Empty;
                    if (Engine.ConfigUI.MonitorImages)
                    {
                        uploadImage = Clipboard.ContainsImage();
                    }
                    if (Engine.ConfigUI.MonitorText && Clipboard.ContainsText())
                    {
                        cbText = Clipboard.GetText();
                        uploadText = !string.IsNullOrEmpty(cbText);
                    }
                    if (Engine.ConfigUI.MonitorFiles)
                    {
                        uploadFile = Clipboard.ContainsFileDropList();
                    }
                    if (Engine.ConfigUI.MonitorUrls && Clipboard.ContainsText())
                    {
                        cbText = Clipboard.GetText();
                        shortenUrl = !string.IsNullOrEmpty(cbText) && FileSystem.IsValidLink(cbText) && cbText.Length > Engine.ConfigUI.ShortenUrlAfterUploadAfter;
                    }

                    if ((uploadImage || uploadText || uploadFile || shortenUrl) && (cbText != Engine.zPreviousSetClipboardText))
                    {
                        UploadUsingClipboard();
                    }
                }
            }
            catch (Exception ex)
            {
                DebugHelper.WriteLine(ex.ToString());
            }
        }

        #endregion Clipboard Methods
    }
}