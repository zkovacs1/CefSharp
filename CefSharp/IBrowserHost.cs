﻿// Copyright © 2010-2015 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using System;
using System.Threading.Tasks;

namespace CefSharp
{
    public interface IBrowserHost : IDisposable
    {
        void StartDownload(string url);
        void Print();
        void SetZoomLevel(double zoomLevel);
        Task<double> GetZoomLevelAsync();
        IntPtr GetWindowHandle();
        void CloseBrowser(bool forceClose);

        void ShowDevTools(IWindowInfo windowInfo = null, int inspectElementAtX = 0, int inspectElementAtY = 0);
        void CloseDevTools();

        void AddWordToDictionary(string word);
        void ReplaceMisspelling(string word);

        void Find(int identifier, string searchText, bool forward, bool matchCase, bool findNext);
        void StopFinding(bool clearSelection);

        /// <summary>
        /// Set whether the browser is focused. (Used for Normal Rendering e.g. WinForms)
        /// </summary>
        /// <param name="focus">set focus</param>
        void SetFocus(bool focus);

        /// <summary>
        /// Send a focus event to the browser. . (Used for OSR Rendering e.g. WPF or OffScreen)
        /// </summary>
        /// <param name="setFocus">set focus</param>
        void SendFocusEvent(bool setFocus);

        /// <summary>
        ///  Send a key event to the browser.
        /// </summary>
        /// <param name="keyEvent">represents keyboard event</param>
        void SendKeyEvent(KeyEvent keyEvent);

        /// <summary>
        /// Send a mouse wheel event to the browser.
        /// </summary>
        /// <param name="x">X-Axis coordinate relative to the upper-left corner of the view.</param>
        /// <param name="y">Y-Axis coordinate relative to the upper-left corner of the view.</param>
        /// <param name="deltaX">Movement delta for X direction.</param>
        /// <param name="deltaY">movement delta for Y direction.</param>
        /// /// <param name="modifiers">click modifiers e.g. Ctrl</param>
        void SendMouseWheelEvent(int x, int y, int deltaX, int deltaY, CefEventFlags modifiers);

        /// <summary>
        /// Invalidate the view. The browser will call CefRenderHandler::OnPaint asynchronously.
        /// This method is only used when window rendering is disabled (OSR). 
        /// </summary>
        /// <param name="type">indicates which surface to re-paint either View or Popup.</param>
        void Invalidate(PaintElementType type);

        /// <summary>
        /// Send a mouse click event to the browser.
        /// </summary>
        /// <param name="x">x coordinate - relative to upper-left corner of view</param>
        /// <param name="y">y coordinate - relative to upper-left corner of view</param>
        /// <param name="mouseButtonType">Mouse ButtonType</param>
        /// <param name="mouseUp">mouse up</param>
        /// <param name="clickCount">click count</param>
        /// <param name="modifiers">click modifiers e.g. Ctrl</param>
        void SendMouseClickEvent(int x, int y, MouseButtonType mouseButtonType, bool mouseUp, int clickCount, CefEventFlags modifiers);

        /// <summary>
        /// Send a mouse move event to the browser
        /// </summary>
        /// <param name="x">x coordinate - relative to upper-left corner of view</param>
        /// <param name="y">y coordinate - relative to upper-left corner of view</param>
        /// <param name="mouseLeave">mouse leave</param>
        /// <param name="modifiers">click modifiers .e.g Ctrl</param>
        void SendMouseMoveEvent(int x, int y, bool mouseLeave, CefEventFlags modifiers);
    }
}
